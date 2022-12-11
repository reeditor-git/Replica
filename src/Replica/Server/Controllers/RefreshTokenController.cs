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
        protected readonly IRefreshTokenRepository _repository;
        public RefreshTokenController(IRefreshTokenRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<RefreshTokenDto> Refresh(RefreshTokenDto entity, string secret) => 
            await _repository.Refresh(entity, secret);
    }
}
