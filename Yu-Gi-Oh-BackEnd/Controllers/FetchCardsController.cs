using Microsoft.AspNetCore.Mvc;
using DataLayer;
using BusinessLayer;

namespace Yu_Gi_Oh_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FetchCardsController : Controller
    {

        YuGiOhDbContext _yugiohContext = new YuGiOhDbContext();

        [HttpGet(Name = "alldecks")]
        public IEnumerable<Deck> GetAllDecks([FromBody] User user)
        {
            User currUser = _yugiohContext.Users.SingleOrDefault(u => u.Id == user.Id);
            if (currUser is null)
            {
                throw new Exception("NoSuchUserException");
            }
            Deck[] decks = currUser.Decks.ToArray();
            return decks;
        }
    }
}
