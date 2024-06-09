using Microsoft.AspNetCore.Mvc;
using DataLayer;
using BusinessLayer;
namespace Yu_Gi_Oh_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostDecksController : Controller
    {
        YuGiOhDbContext _yuGiOhDbContext = new YuGiOhDbContext();

        [HttpPost("api/addnewdeck")]
        public IActionResult postNewDeck([FromBody] DeckUser deckUser)
        {
            User currUser = _yuGiOhDbContext.Users.SingleOrDefault(u => u.Id == deckUser.User.Id);
            if (currUser is null)
            {
                throw new Exception("NoSuchUserException");
            }
            currUser.Decks.Add(deckUser.Deck);
            _yuGiOhDbContext.SaveChangesAsync();
            _yuGiOhDbContext.Decks.Add(deckUser.Deck);
            _yuGiOhDbContext.SaveChangesAsync();
            return CreatedAtAction("Added new deck", new Deck { Id = deckUser.Deck.Id });
        }
    }
}
