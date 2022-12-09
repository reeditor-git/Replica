using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Users;
using Replica.Shared.Users.Authorization;
using Replica.Shared.Users.Login;

namespace Replica.Server.Controllers.Users
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
