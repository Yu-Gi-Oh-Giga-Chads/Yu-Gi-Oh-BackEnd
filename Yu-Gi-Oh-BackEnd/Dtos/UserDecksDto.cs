using BusinessLayer;

namespace Yu_Gi_Oh_BackEnd.Dtos
{
    public record class UserDecksDto(
        DeckDto Deck,
        string Username
    );
}
