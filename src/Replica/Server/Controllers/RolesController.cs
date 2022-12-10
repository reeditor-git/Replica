using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Interfaces;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    public class RolesController : ControllerBase
    {
        private readonly IRegistrationRepository _repository;
        public RolesController(IRegistrationRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<string> AddRole(string roleName) =>
            await _repository.AddRole(roleName);
    }
}
