namespace Yu_Gi_Oh_BackEnd.Dtos
{
    public record class ReturnUserDto(
        int Id,
        string Username,
        string Email,
        string Password,
        DeckDto[] Decks
    );
}
