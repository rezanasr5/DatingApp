using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("Photos")]
public class Photo
{
    public int id { get; init; }
    
    [MaxLength(100)]
    public required string Url { get; init; }

    public bool IsMain { get; set; }

    [MaxLength(10)]
    public string? PublicId { get; set; }

    /// <summary>
    /// Navigation property
    /// </summary>
    public int AppUserId { get; set; }

    /// <summary>
    /// Navigation property
    /// </summary>
    public AppUsers AppUsers { get; set; } = null!;
}