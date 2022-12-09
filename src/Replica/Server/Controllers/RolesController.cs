using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RegistrationRepository _repository;
        public RolesController(RegistrationRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<string> AddRole(string roleName) =>
            await _repository.AddRole(roleName);
    }
}
