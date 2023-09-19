//implement a new profile.
// needs (userName, Password, Admin 1/0)
namespace rest_husky.Models
{
    public class Profile 
    {
        public int profileId { get; set; }
        public string? userName { get; set; }
        public string? Password { get; set; }
    }
}