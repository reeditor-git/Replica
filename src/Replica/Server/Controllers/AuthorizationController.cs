using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;
using Replica.Shared.Authorization;
using Replica.Shared.Login;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly string _secret;

        private readonly AuthorizationRepository _repository;
        public AuthorizationController(IConfiguration config, AuthorizationRepository repository) =>
            (_secret, _repository) = (config.GetValue<string>("Secret"), repository);

        [HttpPost("login")]
        public async Task<LoginDto> Login(AuthorizationDto auth) =>
            await _repository.Login(auth, _secret);
    }
}
