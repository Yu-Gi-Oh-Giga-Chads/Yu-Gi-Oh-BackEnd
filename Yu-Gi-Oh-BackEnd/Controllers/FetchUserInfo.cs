using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Yu_Gi_Oh_BackEnd.Controllers
{
    [ApiController]
    [Route("/hi")]
    public class FetchUserInfoController : Controller
    {
        YuGiOhDbContext _yugiohContext = new YuGiOhDbContext();
        [HttpGet(Name = "getuser")]
        public Object GetUserInfo([FromBody] string username)
        {
            User[] users = _yugiohContext.Users.ToArray();
            var result =
                from user in users
                where user.UserName == username
                select new 
                {
                    user.Id,
                    user.UserName,
                    user.Password,
                    Decks = user.Decks.ToArray() 
                };
            return result;
        }
    }
}
