using System.ComponentModel.DataAnnotations;
using PokedecksBackend.Models.DTOs.Series;

namespace PokedecksBackend.Models.Entities;

public class Series
{
    public Series()
    {
    }

    public Series(AddSeriesDTO dto)
    {
        Id = dto.Id;
        LogoNetworkUri = dto.LogoNetworkUri;
        dto.Sets.ForEach(set => Sets.Add(new Set(set, this)));
    }

    [MaxLength(50)] public string Id { get; set; }
    public Uri? LogoNetworkUri { get; set; }
    public List<Set> Sets { get; set; } = new();
}