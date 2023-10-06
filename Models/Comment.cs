using System.ComponentModel.DataAnnotations;

namespace rest_husky.Models;

public class Comment 
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Text { get; set; }
}