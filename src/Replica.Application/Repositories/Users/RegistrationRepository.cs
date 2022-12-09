using AutoMapper;
using Replica.Application.Helpers;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Users;
using Replica.Shared.Users.Login;
using Replica.Shared.Users.Registration;
using System.Data;
using System.Security.Claims;

namespace Replica.Application.Repositories.Users
{
    public class RegistrationRepository : RepositoryBase
    {
        public RegistrationRepository(IReplicaDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper) { }

        public async Task<LoginDTO> Registration(RegistrationDTO registr, string apiKey)
        {
            var newUser = new User
            {
                FirstName = registr.FirstName,
                LastName = registr.LastName,
                Nickname = registr.Nickname,
                Phone = registr.Phone,
                Email = registr.Email,
                Password = registr.Password,
                Image = registr.Image,
                Role = _dbContext.Roles.First(x => x.Name == "User")
            };

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()),
                new Claim(ClaimTypes.Role, newUser.Role.Name),
                new Claim(ClaimTypes.Name, newUser.Nickname)
            };

            var token = AuthHelpers.GenerateToken(apiKey, claims);
            var refreshToken = AuthHelpers.GenerateRefreshToken();

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.RefreshTokens.AddAsync(new UserRefreshToken
            {
                User = newUser,
                RefreshToken = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddMonths(1)
            });

            await _dbContext.SaveChangesAsync();

            return new LoginDTO
            {
                Token = token,
                RefreshToken = refreshToken,
                Role = newUser.Role.Name
            };
        }

        public async Task<string> AddRole(string roleName)
        {
            var role = new UserRole { Name = roleName };

            await _dbContext.Roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();

            return roleName;
        }
    }
}
