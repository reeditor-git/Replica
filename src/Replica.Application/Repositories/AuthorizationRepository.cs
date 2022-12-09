using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Helpers;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Shared.Users.Authorization;
using Replica.Shared.Users.Login;
using System.Security.Claims;

namespace Replica.Application.Repositories
{
    public class AuthorizationRepository : RepositoryBase
    {
        public AuthorizationRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<LoginDto> Login(AuthorizationDto auth, string apiKey)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email.ToUpper() == auth.Email.ToUpper())
                ?? throw new NotFoundException(nameof(User), auth.Email);

            //if (user.Password != auth.Password)
            //{
            //    throw new NotFoundException(nameof(User), auth.Password);
            //}

            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Name == "User")
                ?? throw new NotFoundException(nameof(Role), user.Role.Id); ;

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, role.Name),
                new Claim(ClaimTypes.Name, user.Nickname)
            };

            var token = AuthHelpers.GenerateToken(apiKey, claims);
            var refreshToken = AuthHelpers.GenerateRefreshToken();

            await _dbContext.RefreshTokens.AddAsync(new RefreshToken
            {
                User = user,
                Token = refreshToken,
                ExpiryDate = DateTime.UtcNow.AddMonths(1)
            });

            return new LoginDto
            {
                Token = token,
                RefreshToken = refreshToken,
                Role = role.Name
            };
        }
    }
}
