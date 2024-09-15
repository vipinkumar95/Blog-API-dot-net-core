using BlogAPI.Data;
using BlogAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly IRespositiory<Category> db;

        public CategoryController(IRespositiory<Category> respositiory)
        {
            db = respositiory;   
        }

        [HttpGet]
        public async Task<ActionResult> Index() 
        {
            var data = await db.GetAll();
            return Ok(data);
        }
    }
}
