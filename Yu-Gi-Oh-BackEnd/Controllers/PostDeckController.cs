using Microsoft.AspNetCore.Mvc;
using DataLayer;
using BusinessLayer;
using Yu_Gi_Oh_BackEnd.Dtos;
namespace Yu_Gi_Oh_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostDeckController : Controller
    {
        YuGiOhDbContext _yuGiOhDbContext = new YuGiOhDbContext();
        
        public Deck DeckDtoToDeck(DeckDto lastDeck)
        {
            Deck newDeck = new Deck();
            newDeck.Name = lastDeck.Name;
            List<Card> cards = _yuGiOhDbContext.Cards.ToList();

            foreach(var card in lastDeck.CardNames)
            {
                newDeck.Cards.Add(cards.SingleOrDefault(c => c.Name.Equals(card)));
            }

            newDeck.Copies = lastDeck.Copies;
            newDeck.DateCreated = DateTime.Now;
            newDeck.LastEdited = DateTime.Now;
            return newDeck;
        }
        [HttpPost]
        public async Task<IActionResult> postNewDeck([FromBody] UserDecksDto deck)
        {
            User currUser = _yuGiOhDbContext.Users.SingleOrDefault(u => u.UserName.Equals(deck.Username));
            if (currUser is null)
            {
                throw new Exception("NoSuchUserException");
            }
            Deck newDeck = DeckDtoToDeck(deck.Deck);
            currUser.Decks.Add(newDeck);
            await _yuGiOhDbContext.SaveChangesAsync();
            _yuGiOhDbContext.Decks.Add(newDeck);
            await _yuGiOhDbContext.SaveChangesAsync();
            return Ok(deck);
        }
    }
}
