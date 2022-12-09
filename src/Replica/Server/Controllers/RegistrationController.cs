using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;
using Replica.Shared.Login;
using Replica.Shared.Registration;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly string _secret;

        private readonly RegistrationRepository _repository;
        public RegistrationController(IConfiguration config, RegistrationRepository repository) =>
            (_secret, _repository) = (config.GetValue<string>("Secret"), repository);

        [HttpPost("regist")]
        public async Task<LoginDto> Registration(RegistrationDto registr) =>
            await _repository.Registration(registr, _secret);
    }
}
