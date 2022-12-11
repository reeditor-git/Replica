using AutoMapper;
using IdentityModel;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Server.Infrastructure.Helpers;
using Replica.Shared.Login;
using Replica.Shared.Registration;
using System.Security.Claims;

namespace Replica.Server.Infrastructure.Repositories
{
    public class RegistrationRepository : RepositoryBase, IRegistrationRepository
    {
        public RegistrationRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<LoginDto> Registration(RegistrationDto registr, string secret)
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
                Role = _dbContext.Roles.First(x => x.Name == "user")
            };

            var claims = new List<Claim> {
                new Claim(JwtClaimTypes.Id, newUser.Id.ToString()),
                new Claim(JwtClaimTypes.NickName, newUser.Nickname),
                new Claim(JwtClaimTypes.Role, newUser.Role.Name)
            };

            var token = AuthHelpers.GenerateToken(secret, claims);
            var refreshToken = AuthHelpers.GenerateRefreshToken();

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.RefreshTokens.AddAsync(new RefreshToken
            {
                User = newUser,
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddMonths(1)
            });

            await _dbContext.SaveChangesAsync();

            return new LoginDto
            {
                Token = token,
                RefreshToken = refreshToken,
                Role = newUser.Role.Name
            };
        }

        public async Task<string> AddRole(string roleName)
        {
            var role = new Role { Name = roleName };

            await _dbContext.Roles.AddAsync(role);
            await _dbContext.SaveChangesAsync();

            return roleName;
        }
    }
}
