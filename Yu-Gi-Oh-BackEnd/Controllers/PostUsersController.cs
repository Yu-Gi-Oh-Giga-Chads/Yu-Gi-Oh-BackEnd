using Microsoft.AspNetCore.Mvc;
using DataLayer;
using BusinessLayer;

namespace Yu_Gi_Oh_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostUsersController : Controller
    {
        YuGiOhDbContext _yuGiOhDbContext = new YuGiOhDbContext();
        [HttpPost("api/addnewuser")]
        public IActionResult postNewUser([FromBody] User newUser)
        {
            _yuGiOhDbContext.Users.Add(newUser);
            _yuGiOhDbContext.SaveChangesAsync();
            return CreatedAtAction("Added new user", new User { Id = newUser.Id });
        }
    }
}
