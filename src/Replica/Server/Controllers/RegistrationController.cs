using Microsoft.AspNetCore.Mvc;
using Replica.Application.Interfaces;
using Replica.Shared.Login;
using Replica.Shared.Registration;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly string _secret;

        private readonly IRegistrationRepository _repository;
        public RegistrationController(IConfiguration config, IRegistrationRepository repository) =>
            (_secret, _repository) = (config.GetValue<string>("Secret"), repository);

        [HttpPost]
        public async Task<LoginDto> Registration(RegistrationDto registr) =>
            await _repository.Registration(registr, _secret);
    }
}
