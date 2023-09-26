using System.ComponentModel.DataAnnotations;

namespace rest_husky.Models;

public class Comment 
{
    [Key]
    public int CommentId { get; set; }
    [Required]
    public string? Text { get; set; }
}