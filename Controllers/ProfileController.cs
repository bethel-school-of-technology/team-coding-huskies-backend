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

    [HttpPost]
    [Route("register")]
    public ActionResult CreateProfile(Profile profile)
    {
        if (profile == null || !ModelState.IsValid)
        {
            return BadRequest();
        }
        return NoContent();
    }

    [HttpGet]
    [Route("login")]
    public ActionResult<string> SignIn(string name, string password)
    {
        throw new NotImplementedException();
    }
}