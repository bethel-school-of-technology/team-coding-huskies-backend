//implement a new profile.
// needs (userName, Password, Admin 1/0)
using System.ComponentModel.DataAnnotations;

namespace rest_husky.Models
{
    public class Profile 
    {
        public int profileId { get; set; }
        [Required]
        public string? userName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}