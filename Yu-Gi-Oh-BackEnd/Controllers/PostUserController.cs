using Microsoft.AspNetCore.Mvc;
using DataLayer;
using BusinessLayer;
using Yu_Gi_Oh_BackEnd.Dtos;

namespace Yu_Gi_Oh_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostUserController : Controller
    {
        YuGiOhDbContext _yuGiOhDbContext = new YuGiOhDbContext();
        [HttpPost]
        public async Task<IActionResult> postNewUser([FromBody] UserDto newUser)
        {
            User user = new User();
            user.UserName = newUser.Username;
            user.Password = newUser.Password;
            user.Email = newUser.Email;
            _yuGiOhDbContext.Users.Add(user);
            await _yuGiOhDbContext.SaveChangesAsync();
            return Ok(newUser);
        }
    }
}
