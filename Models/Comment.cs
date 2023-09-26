using System.ComponentModel.DataAnnotations;

namespace rest_husky.Models;

public class Comment 
{
    public int Id { get; set; }
    [Required]
    public string? Text { get; set; }
    //public int FK ProfileId
    //public int FK PostId
}