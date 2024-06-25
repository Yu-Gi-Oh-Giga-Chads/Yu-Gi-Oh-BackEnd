using Microsoft.AspNetCore.Mvc;
using DataLayer;
using BusinessLayer;
using Yu_Gi_Oh_BackEnd.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Yu_Gi_Oh_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDecksController : Controller
    {
        YuGiOhDbContext _yugiohContext = new YuGiOhDbContext();

        [HttpGet]
        public async Task<IEnumerable<Deck>> GetAllDecks([FromBody] UserDto user)
        {
            User currUser = await _yugiohContext.Users.SingleOrDefaultAsync(u => u.UserName.Equals(user.Username));
            if (currUser is null)
            {
                throw new Exception("NoSuchUserException");
            }
            Deck[] decks = currUser.Decks.ToArray();
            return decks;
        }
    }
}
