using Microsoft.AspNetCore.Mvc;

namespace Replica.Server.Controllers.Orders
{
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update()
        {
            return Ok();
        }
    }
}
