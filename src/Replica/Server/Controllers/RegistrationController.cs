using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;
using Replica.Shared.Users.Login;
using Replica.Shared.Users.Registration;

namespace Replica.Server.Controllers
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
        public async Task<LoginDto> Registration(RegistrationDto registr) =>
            await _repository.Registration(registr, _apiKey);
    }
}
