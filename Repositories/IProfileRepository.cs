//implement a interface for the dependancy injection.
//the interface will have crud operations of create,read will not be using delete,update.

using rest_husky.Models;

namespace rest_husky.Repositories;
public interface IProfileRepository
{
    Profile CreateProfile(Profile newProfile);

    string SiginIn(string name, string Password);

}
    

