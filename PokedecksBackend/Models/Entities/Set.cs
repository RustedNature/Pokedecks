using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PokedecksBackend.Models.DTOs.Set;

namespace PokedecksBackend.Models.Entities;

public class Set
{
    public Set()
    {
    }

    public Set(AddSetDTO dto, Series series)
    {
        Id = dto.Id;
        Name = dto.Name;
        Logo = dto.Logo;
        Symbol = dto.Symbol;
        CardCountTotal = dto.CardCountTotal;
        CardCountPrintedTotal = dto.CardCountPrintedTotal;
        SeriesId = series.Id;
        Series = series;
        dto.Cards.ForEach(card => Cards.Add(new Card(card, this)));
    }

    [MaxLength(50)] public string Id { get; set; }
    [MaxLength(50)] public string Name { get; set; }
    public Uri? Logo { get; set; }
    public Uri? Symbol { get; set; }
    public int CardCountPrintedTotal { get; set; } //number of cards in the set excluding secret rares
    public int CardCountTotal { get; set; } //number of cards in the set including secret rares

    //SeriesRelationship
    [MaxLength(50)] public string SeriesId { get; set; }
    [JsonIgnore] public Series? Series { get; set; }

    //CardsRelationship
    public List<Card> Cards { get; set; } = [];
}