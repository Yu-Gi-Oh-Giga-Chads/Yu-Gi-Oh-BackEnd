using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Yu_Gi_Oh_BackEnd.Controllers
{
    [ApiController]
    [Route("getloginusers")]
    public class FetchUsersController : Controller
    {
        YuGiOhDbContext _yugiohContext = new YuGiOhDbContext();
        [HttpGet(Name = "getloginusers")]
        public IEnumerable<Object> GetAllUsers()
        {
            //User[] users = _yugiohContext.Users.ToArray();
            var result =
                from user in _yugiohContext.Users
                select new { user.UserName, user.Password };
            return result;
        }
    }
}
