using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yu_Gi_Oh_BackEnd.Dtos;

namespace Yu_Gi_Oh_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInfoController : Controller
    {
        YuGiOhDbContext _yuGiOhDbContext = new YuGiOhDbContext();

        public DeckDto DeckToDeckDto(Deck lastDeck)
        {
            List<string> cards = new List<string>();
            foreach (var card in lastDeck.Cards)
            {
                cards.Add(card.Name);
            }
            DeckDto newDeck = new DeckDto(
                lastDeck.Name,
                cards,
                lastDeck.Copies
            );
            return newDeck;
        }

        [HttpGet("{username}")]
        public async Task<ReturnUserDto> GetUserInfo(string username)
        {
            User[] users = await _yuGiOhDbContext.Users.ToArrayAsync();

            User currUser = users.SingleOrDefault(u=>u.UserName.Equals(username));
            if(currUser is null)
            {
                throw new Exception("No such User");
            }
            List<DeckDto> decks = new List<DeckDto>();
            if (currUser.Decks.Count > 0)
            {
                foreach (var deck in currUser.Decks)
                {
                    DeckDto newDeck = DeckToDeckDto(deck);
                    decks.Add(newDeck);
                }
            }
            
            ReturnUserDto returnUser = new ReturnUserDto(
                currUser.Id,
                currUser.UserName,
                currUser.Email,
                currUser.Password,
                decks.ToArray()
            );
            decks.ForEach(d=>Console.WriteLine(d.Name));
            return returnUser;
        }
    }
}
