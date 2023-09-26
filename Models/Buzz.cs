using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace rest_husky.Models;

public class Buzz 
{
    [Key]
    public int BuzzId { get; set; }
    [Required]
    public string? BuzzEmbed { get; set; }
    [JsonIgnore]
    public ICollection<Comment>? Commented { get; set; }
}