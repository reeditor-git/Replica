using AutoMapper;
using IdentityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Server.Infrastructure.Helpers;
using Replica.Shared.RefreshToken;

namespace Replica.Server.Infrastructure.Repositories
{
    public class RefreshTokenRepository : RepositoryBase, IRefreshTokenRepository
    {
        public RefreshTokenRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<RefreshTokenDto> Refresh(RefreshTokenDto entity, string secret)
        {
            var principal = AuthHelpers.GetPrincipalFromExpiredToken(secret, entity.Token);
            var userIdStr = principal.FindFirst(JwtClaimTypes.Id).Value;
            var userId = Guid.Parse(userIdStr);
            var userRefreshToken = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Token == entity.RefreshToken);

            if (userRefreshToken == null)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }

            _dbContext.RefreshTokens.Remove(userRefreshToken);

            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {

                await _dbContext.SaveChangesAsync();
                throw new SecurityTokenException("Token is expired");

            }
            var newJwtToken = AuthHelpers.GenerateToken(secret, principal.Claims);
            var newRefreshToken = AuthHelpers.GenerateRefreshToken();

            await _dbContext.RefreshTokens.AddAsync(new RefreshToken
            {
                UserId = userId,
                Token = newRefreshToken,
                ExpiryDate = DateTime.UtcNow.AddMonths(1),

            });

            await _dbContext.SaveChangesAsync();

            return new RefreshTokenDto
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken
            };
        }
    }
}
