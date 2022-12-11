using Replica.Shared.RefreshToken;

namespace Replica.Application.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshTokenDto> Refresh(RefreshTokenDto entity, string secret);
    }
}