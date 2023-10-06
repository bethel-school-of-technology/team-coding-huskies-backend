using rest_husky.Models;
using rest_husky.Data;
using Microsoft.EntityFrameworkCore;

namespace rest_husky.Repositories;

public class ProfileRepository : IProfileRepository
{

    private readonly ProfileContext _context;

    public ProfileRepository(ProfileContext context)
    {
        _context = context;
    }
    public Profile CreateProfile(Profile newProfile)
    {
        _context.Profiles.Add(newProfile);
        _context.SaveChanges();

        return newProfile;
    }

    public Profile? GetProfileById(int userId)
    {
        return _context.Profiles
            .Include(p => p.Buzzes)
            .Include(p => p.Comments)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == userId);
    }

    public string SiginIn(string name, string Password)
    {
        throw new NotImplementedException();
    }

    public void DeletePrfileById(int profileId)
    {
        var profileToDelete = _context.Profiles.Find(profileId);

        if (profileToDelete is not null)
        {
            _context.Profiles.Remove(profileToDelete);
            _context.SaveChanges();
        }
    }
}