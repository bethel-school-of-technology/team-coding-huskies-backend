using Microsoft.VisualBasic;
using rest_husky.Models;

namespace rest_husky.Repositories;

public class ProfileRepository : IProfileRepository
{
    private List<Profile> mockProfiles;
   public void MockProfileRepo() 
   {

        mockProfiles = new List<Profile>
        {
            new Profile {ProfileId = 1, userName = "AndreasD", Password = "password1!"},
            new Profile {ProfileId = 2, userName = "RobertB", Password = "password2!"},
            new Profile {ProfileId = 3, userName = "JaycobC", Password = "password3!"}
        };
    }
    public Profile CreateProfile(Profile newProfile)
    {
       var MaxId = mockProfiles.Select(p => p.ProfileId).DefaultIfEmpty().DefaultIfEmpty().Max();
       newProfile.ProfileId = MaxId + 1;
       mockProfiles.Add(newProfile);
       return newProfile;
    }

    public string SiginIn(string name, string Password)
    {
        throw new NotImplementedException();
    }
}