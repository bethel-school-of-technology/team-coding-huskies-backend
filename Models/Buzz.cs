using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace rest_husky.Models;

public class Buzz 
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? BuzzTitle { get; set; }
    [Required]
    public string? BuzzEmbed { get; set; }
    [Required]
    public string? BuzzDesc { get; set; }
    public ICollection<Comment> Commented { get; } = new List<Comment>();
}