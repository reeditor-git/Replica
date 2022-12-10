using Replica.Shared.Login;
using Replica.Shared.Registration;

namespace Replica.Application.Interfaces
{
    public interface IRegistrationRepository
    {
        Task<string> AddRole(string roleName);
        Task<LoginDto> Registration(RegistrationDto registr, string secret);
    }
}