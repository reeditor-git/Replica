using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Interfaces;
using Replica.Shared.RefreshToken;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefreshTokenController : Controller
    {
        private readonly string _secret;

        protected readonly IRefreshTokenRepository _repository;
        public RefreshTokenController(IConfiguration config, IRefreshTokenRepository repository) =>
            (_secret, _repository) = (config.GetValue<string>("Secret"), repository);

        [HttpPost]
        public async Task<RefreshTokenDto> Refresh(RefreshTokenDto entity) => 
            await _repository.Refresh(entity, _secret);
    }
}
