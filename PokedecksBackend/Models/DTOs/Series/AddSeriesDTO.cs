using PokedecksBackend.Models.DTOs.Set;

namespace PokedecksBackend.Models.DTOs.Series;

public class AddSeriesDTO
{
    public required string Id { get; set; }
    public Uri? LogoNetworkUri { get; set; }

    public required List<AddSetDTO> Sets { get; set; }
}