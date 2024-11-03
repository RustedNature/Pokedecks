using System.ComponentModel.DataAnnotations;

namespace PokedecksBackend.Models.DTOs.Set;

public class EditSetDTO
{
    [MaxLength(50)] public string? Name { get; set; }
    public Uri? Logo { get; set; }
    public Uri? Symbol { get; set; }
    public int? CardCountPrintedTotal { get; set; }
    public int? CardCountTotal { get; set; }
}