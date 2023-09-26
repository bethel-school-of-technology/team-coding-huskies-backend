// base controller for the profile data model, going to go though many versions.
using rest_husky.Models;
using rest_husky.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace rest_husky.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProfileController : ControllerBase
{
    private readonly ILogger<ProfileController> _logger;

    private readonly IProfileRepository _profileRepository;

    public ProfileController(ILogger<ProfileController> logger, IProfileRepository proRepo)
    {
        _logger = logger;
        _profileRepository = proRepo;
    }

    [HttpGet]
    [Route("{profileId}")]

    public ActionResult<Profile> GetProfileById(int profileId)
    {
        var profile = _profileRepository.GetProfileById(profileId);

        if(profile is not null)
        {
            return profile;
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [Route("register")]
    public IActionResult CreateProfile(Profile newProfile)
    {
        if (newProfile == null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        var profile = _profileRepository.CreateProfile(newProfile);

        return CreatedAtAction(nameof(GetProfileById), new { profileId = profile!.ProfileId }, profile);
    }

    [HttpGet]
    [Route("login")]
    public ActionResult<string> SignIn(string name, string password)
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("{profileId}")]

    public IActionResult DeleteProfile(int profileId)
    {
        var profile = _profileRepository.GetProfileById(profileId);

        if(profile is not null)
        {
            _profileRepository.DeletePrfileById(profileId);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}