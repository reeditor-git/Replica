using Microsoft.AspNetCore.Mvc;
using Replica.Server.Controllers.Base;

namespace Replica.Server.Controllers.Orders
{
    //[Authorize]
    public class CategoryController : ApiController
    {
        [HttpGet("[action]")]
        //[Authorize(Roles = "")]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }

        [HttpGet]
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

        [HttpDelete]
        public async Task<ActionResult> DeleteWithoutSubcategories()
        {
            return Ok();
        }
    }
}
