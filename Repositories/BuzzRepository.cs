

using Microsoft.EntityFrameworkCore;
using rest_husky.Data;
using rest_husky.Models;

namespace rest_husky.Repositories;

public class BuzzRepository : IBuzzRepository
{
    private readonly ProfileContext _context;

    public BuzzRepository(ProfileContext context)
    {
        _context = context;
    }

    public Profile GetProfileById(int profileId)
    {
        var profile = _context.Profiles.Single(b => b.Id == profileId);

        return profile;
    }

    public Buzz CreateBuzz(Profile ParentProfile, Buzz newBuzz)
    {
        _context.Attach(ParentProfile);
        ParentProfile.Buzzes.Add(newBuzz);
        _context.SaveChanges();

        return newBuzz;
    }

    public void DeleteBuzz(int buzzId)
    {
        var buzzToDelete = _context.Buzzes.Find(buzzId);
        if (buzzToDelete is not null)
        {
            _context.Buzzes.Remove(buzzToDelete);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Buzz> GetAllBuzz()
    {
        return _context.Buzzes
            .Include(b => b.Commented)
            .AsNoTracking()
            .ToList();
    }

    public Buzz? GetBuzzById(int BuzzId)
    {
        return _context.Buzzes
            .Include(b => b.Commented)
            .AsNoTracking()
            .SingleOrDefault(b => b.Id == BuzzId);
    }

    public Buzz? UpdateBuzz(Buzz buzz)
    {
        var originBuzz = _context.Buzzes.Find(buzz.Id);
        if (originBuzz != null)
        {
            originBuzz.BuzzTitle = buzz.BuzzTitle;
            originBuzz.BuzzEmbed = buzz.BuzzEmbed;
            originBuzz.BuzzDesc = buzz.BuzzDesc;
            _context.SaveChanges();
        }
        return originBuzz;
    }
}