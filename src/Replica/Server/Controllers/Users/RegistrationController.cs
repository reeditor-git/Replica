using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Users;
using Replica.Shared.Users.Login;
using Replica.Shared.Users.Registration;

namespace Replica.Server.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly string _apiKey;

        private readonly RegistrationRepository _repository;
        public RegistrationController(IConfiguration config, RegistrationRepository repository) =>
            (_apiKey, _repository) = (config.GetValue<string>("ApiKey"), repository);

        [HttpPost("regist")]
        public async Task<LoginDTO> Registration(RegistrationDTO registr) =>
            await _repository.Registration(registr, _apiKey);
    }
}
