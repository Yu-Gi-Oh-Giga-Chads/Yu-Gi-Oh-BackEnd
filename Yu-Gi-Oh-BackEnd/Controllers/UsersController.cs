using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yu_Gi_Oh_BackEnd.Dtos;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace Yu_Gi_Oh_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        YuGiOhDbContext _yugiohContext = new YuGiOhDbContext();

        [HttpGet]
        public async Task<string> GetAllUsers()
        {
            User[] users = await _yugiohContext.Users.ToArrayAsync();

            List<LoginUserDto> loginUsers = new List<LoginUserDto>();
            foreach (var user in users)
            {
                LoginUserDto userDto = new LoginUserDto(
                    user.UserName,
                    user.Password
                );
                loginUsers.Add(userDto);
            }
            return JsonConvert.SerializeObject(loginUsers.ToArray());
        }
    }
}
