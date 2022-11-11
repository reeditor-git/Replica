using Microsoft.AspNetCore.Mvc;
using Replica.Server.Controllers.Base;

namespace Replica.Server.Controllers.Orders
{
    public class TableController : ApiController
    {
        [HttpGet("[action]")]
        //[Authorize(Roles = "")]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> Create()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            return Ok();
        }
    }
}
