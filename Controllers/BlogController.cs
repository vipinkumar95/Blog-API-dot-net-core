using BlogAPI.Data;
using BlogAPI.Model;
using BlogAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public readonly IRespositiory<Blog> db;
        public BlogController(IRespositiory<Blog> respositiory)
        {
            db = respositiory;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogList() 
        {
            var data = await db.GetAll();
            return Ok(data);
        }


        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBlog(int id)
        {
            var blog = await db.GetById(id);
            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult> AddBlog(BlogViewModel model)
        {
           var blog =  new Blog();
            {
                blog.CategoryId = model.CategoryId;
                blog.Title = model.Title;
                blog.Description = model.Description;
                blog.Content = model.Content;
                blog.Image =model.Image;
                blog.Isfeatured = model.Isfeatured;
            };
            await db.AddAsync(blog);
            await db.Savechangesasync();
            return Ok(model);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBlog(int id, [FromBody] BlogViewModel model)
        {
            var blog =  await db.GetById(id);
            blog.Description = blog.Description;
            blog.Title = blog.Title;
            blog.Content = blog.Content;
            blog.Isfeatured = blog.Isfeatured;
            blog.Image = blog.Image;
           await db.UpdateAsync(blog);
            await db.Savechangesasync();
            return Ok(blog);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> BlogDelete(int id)
        {
            await db.DeleteAsync(id);
            await db.Savechangesasync();
            return Ok();
        }


        [HttpGet("featured")]
        public async Task<ActionResult> GetFeaturedList()
        {
            var blog = await db.GetAllFeatured(x => x.Isfeatured == true);
            return Ok(blog);
        }
    }
}
