using Microsoft.EntityFrameworkCore;
using rest_husky.Models;

namespace rest_husky.Data;

public class ProfileContext : DbContext
{
    public ProfileContext (DbContextOptions<ProfileContext> options)
        : base(options)
        {
        }

        public DbSet<Profile> Profiles => Set<Profile>();
        public DbSet<Buzz> Buzzes => Set<Buzz>();
        public DbSet<Comment> Comments => Set<Comment>();
}