using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PokedecksBackend.Models.DTOs.Card;

namespace PokedecksBackend.Models.Entities;

public class Card
{
    public Card()
    {
    }

    public Card(AddCardDTO dto, Set set)
    {
        Id = dto.Id;
        Name = dto.Name;
        ImageLowRes = dto.ImageLowRes;
        ImageHighRes = dto.ImageHighRes;
        SetId = set.Id;
        Set = set;
    }

    //todo bei others
    [MaxLength(50)] public string Id { get; set; }
    [MaxLength(50)] public string Name { get; set; }

    public Uri? ImageLowRes { get; set; }
    public Uri? ImageHighRes { get; set; }

    // Relationship
    [MaxLength(50)] public string SetId { get; set; }

    [JsonIgnore] public Set? Set { get; set; }
}