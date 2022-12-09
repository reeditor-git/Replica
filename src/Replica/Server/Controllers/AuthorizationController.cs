using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;
using Replica.Shared.Users.Authorization;
using Replica.Shared.Users.Login;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly string _apiKey;

        private readonly AuthorizationRepository _repository;
        public AuthorizationController(IConfiguration config, AuthorizationRepository repository) =>
            (_apiKey, _repository) = (config.GetValue<string>("ApiKey"), repository);

        [HttpPost("login")]
        public async Task<LoginDto> Login(AuthorizationDto auth) =>
            await _repository.Login(auth, _apiKey);
    }
}
