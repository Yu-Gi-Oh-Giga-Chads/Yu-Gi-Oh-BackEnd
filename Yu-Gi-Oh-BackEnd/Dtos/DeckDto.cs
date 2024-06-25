namespace Yu_Gi_Oh_BackEnd.Dtos
{
    public record class DeckDto(
        string Name,
        List<string> CardNames,
        List<int> Copies
    );
}
