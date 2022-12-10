using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Server.Infrastructure.Helpers;
using Replica.Shared.Authorization;
using Replica.Shared.Login;
using System.Security.Claims;

namespace Replica.Server.Infrastructure.Repositories
{
    public class AuthorizationRepository : RepositoryBase, IAuthorizationRepository
    {
        public AuthorizationRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<LoginDto> Login(AuthorizationDto auth, string secret)
        {
            var user = await _dbContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email.ToUpper() == auth.Email.ToUpper())
                ?? throw new EmailNotFoundException(auth.Email);

            if (user.Password != auth.Password)
            {
                throw new PasswordException(auth.Email);
            }

            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Name == user.Role.Name)
                ?? throw new NotFoundException(nameof(Role), user.Role.Id); ;

            var claims = new List<Claim> {
                new Claim("Id", user.Id.ToString()),
                new Claim("Role", user.Role.Name),
                new Claim("Nickname", user.Nickname)
            };

            var token = AuthHelpers.GenerateToken(secret, claims);
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
