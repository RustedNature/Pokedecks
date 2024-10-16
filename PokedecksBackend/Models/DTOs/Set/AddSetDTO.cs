using PokedecksBackend.Models.DTOs.Card;

namespace PokedecksBackend.Models.DTOs.Set;

public class AddSetDTO
{
    public required string Id { get; set; }
    public required string? Name { get; set; }
    public Uri? Logo { get; set; }

    public Uri? Symbol { get; set; }

    //number of cards in the set excluding secret rares
    public int CardCountPrintedTotal { get; set; }
    public int CardCountTotal { get; set; }

    //SeriesRelationship
    public required string SeriesId { get; set; }
    public required List<AddCardDTO> Cards { get; set; }
}