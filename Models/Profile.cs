using System.ComponentModel.DataAnnotations;

namespace rest_husky.Models
{
    public class Profile 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? userName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Password { get; set; }

        public bool IsAdmin { get; set; }
    
        public ICollection<Buzz> Buzzes { get; } = new List<Buzz>();

        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}