using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class Photo
{
    public int id { get; init; }
    
    [MaxLength(100)]
    public required string Url { get; init; }

    public bool IsMain { get; set; }

    [MaxLength(10)]
    public string? PublicId { get; set; }
    
}