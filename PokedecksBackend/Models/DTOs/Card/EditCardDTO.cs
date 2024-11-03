using System.ComponentModel.DataAnnotations;

namespace PokedecksBackend.Models.DTOs.Card;

public class EditCardDTO
{
    [MaxLength(50)] public string? Name { get; set; }

    public Uri? ImageLowRes { get; set; }
    public Uri? ImageHighRes { get; set; }
}