using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bala.EntityModels.Sqlite;

public class JournalEntry
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Date is Required.")]
    public DateTime Date { get; set; } = DateTime.Now; // Default value

    [Required]
    [StringLength(200, ErrorMessage = "Comment is Required.")]
    public string? Comment { get; set; } = string.Empty; // Default value

    [Required]
    [Range(1, 5, ErrorMessage = "Rating Between 1 and 5 is Required.")]
    public int? Rating { get; set; } = 3; // Default value
}
