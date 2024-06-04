using System;
using System.ComponentModel.DataAnnotations;

namespace Bala.Shared;

public class JournalEntry
{   
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; } = DateTime.Now; // Default value

    [Required]
    [StringLength(200)]
    public string? Commend { get; set; } = string.Empty; // Default value

    [Required]
    public int? Rating { get; set; } = 3; // Default value
}
