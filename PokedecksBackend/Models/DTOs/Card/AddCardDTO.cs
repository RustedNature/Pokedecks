namespace PokedecksBackend.Models.DTOs.Card;

public class AddCardDTO
{
    public required string Id { get; set; }
    public required string Name { get; set; }

    public Uri? ImageLowRes { get; set; }
    public Uri? ImageHighRes { get; set; }

    // Relationship
    public required string SetId { get; set; }
}