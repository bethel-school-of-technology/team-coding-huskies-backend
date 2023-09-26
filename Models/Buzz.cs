using System.ComponentModel.DataAnnotations;

namespace rest_husky.Models;

public class Buzz 
{
    public int Id { get; set; }
    [Required]
    public string? BuzzEmbed { get; set; }

}