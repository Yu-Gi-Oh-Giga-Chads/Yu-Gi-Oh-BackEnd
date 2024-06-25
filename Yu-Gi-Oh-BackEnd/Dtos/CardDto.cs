using System.ComponentModel.DataAnnotations;

namespace Yu_Gi_Oh_BackEnd.Dtos
{
    public record class CardDto(
        int Id,
        string Name,
        string Type,
        string FrameType,
        string Desc,
        int ATK,
        int DEF,
        int Level,
        string Race,
        string Attribute,
        string Ygoprodeck_url
    );
}
