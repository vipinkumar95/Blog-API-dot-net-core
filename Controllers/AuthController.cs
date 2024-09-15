using BlogAPI.Data;
using BlogAPI.Model;
using BlogAPI.ViewModel;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IRespositiory<User> db;
        public AuthController(IRespositiory<User> respositiory)
        {
            db = respositiory;
        }


        [HttpPost]
        public async Task<IResult> Login([FromBody] LoginViewModel model)
        {
            var data = (await db.GetAllFeatured(x => x.Email == model.Email)).FirstOrDefault();
            if (data is not null && data.Password==model.Password)
            {
                var claimpricipal = new ClaimsPrincipal(
                    new ClaimsIdentity(
                        new[]{new Claim(ClaimTypes.Name,model.Email)},
                        BearerTokenDefaults.AuthenticationScheme
                        )
                    );
                return Results.SignIn(claimpricipal);
            }
            else
            {
                return Results.BadRequest();
            }
        }
    }
}
