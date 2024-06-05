using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bala.Shared;

public class JournalEntry
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; } = DateTime.Now; // Default value

    [Required]
    [StringLength(200)]
    public string? Comment { get; set; } = string.Empty; // Default value

    [Required]
    [Range(1, 5)]
    public int? Rating { get; set; } = 3; // Default value
}
