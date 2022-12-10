using Replica.Shared.Authorization;
using Replica.Shared.Login;

namespace Replica.Application.Interfaces
{
    public interface IAuthorizationRepository
    {
        Task<LoginDto> Login(AuthorizationDto auth, string secret);
    }
}