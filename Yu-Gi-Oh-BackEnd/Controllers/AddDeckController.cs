using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Yu_Gi_Oh_BackEnd.Dtos;

namespace Yu_Gi_Oh_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddDeckController : Controller
    {
        YuGiOhDbContext _yuGiOhDbContext = new YuGiOhDbContext();

        [HttpPost]
        public async Task<IActionResult> AddDeck([FromBody] AddDeckDto deck)
        {
            try
            {
                User currUser = _yuGiOhDbContext.Users.SingleOrDefault(u => u.UserName.Equals(deck.Username));
                if (currUser is null)
                {
                    throw new Exception("NoSuchUserException");
                }
                Deck newDeck = new Deck();
                newDeck.Name = deck.Deckname;
                currUser.Decks.Add(newDeck);
                await _yuGiOhDbContext.SaveChangesAsync();
                _yuGiOhDbContext.Decks.Add(newDeck);
                await _yuGiOhDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Bali go");
            }
            return Ok(deck);
        }
    }
}
