using rest_husky.Models;
using rest_husky.Data;
using Microsoft.EntityFrameworkCore;
using Bcrypt = BCrypt.Net.BCrypt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace rest_husky.Repositories;

public class ProfileRepository : IProfileRepository
{

    private readonly ProfileContext _context;
    private static IConfiguration _config;

    public ProfileRepository(ProfileContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    public IEnumerable<Profile> GetAllProfiles()
    {
        return _context.Profiles
            .Include(b => b.Buzzes)
            .AsNoTracking()
            .ToList();
    }
    public Profile CreateProfile(Profile newProfile)
    {

        var passwordHash = Bcrypt.HashPassword(newProfile.Password);
        newProfile.Password = passwordHash;


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

    public string SiginIn(string email, string Password)
    {
        var profile = _context.Profiles.SingleOrDefault(x => x.Email == email);
        var verified = false;

        if (profile != null) {
            verified = Bcrypt.Verify(Password, profile.Password);
        }

        if (profile == null || !verified)
        {
            return String.Empty;
        }
        
        // Create & return JWT
        return BuildToken(profile);

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

    private string BuildToken(Profile profile)
    {
        var secret = _config.GetValue<string>("TokenSecret");
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, profile.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, profile.Email ?? ""),
            new Claim(JwtRegisteredClaimNames.Name, profile.userName ?? "")
        };

        var jwt = new JwtSecurityToken(
        claims: claims,
        expires: DateTime.Now.AddMinutes(60),
        signingCredentials: signingCredentials);

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }
}