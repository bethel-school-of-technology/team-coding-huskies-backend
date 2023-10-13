//implement a interface for the dependancy injection.
//the interface will have crud operations of create,read will not be using delete,update.

using rest_husky.Models;

namespace rest_husky.Repositories;
public interface IProfileRepository
{
    IEnumerable<Profile> GetAllProfiles();
    Profile CreateProfile(Profile newProfile);

    string SiginIn(string email, string Password);

    Profile? GetProfileById(int userId);

    void DeletePrfileById(int profileId);

}
    

