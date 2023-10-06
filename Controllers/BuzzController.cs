
using Microsoft.AspNetCore.Mvc;
using rest_husky.Models;
using rest_husky.Repositories;

namespace rest_husky.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuzzController : ControllerBase
{
    private readonly ILogger<BuzzController> _logger;
    private readonly IBuzzRepository _buzzRepo;

    public BuzzController(ILogger<BuzzController> logger, IBuzzRepository buzzRepository)
    {
        _logger = logger;
        _buzzRepo = buzzRepository;
    }

    [HttpGet]
    public IEnumerable<Buzz> GetBuzzes()
    {
        return _buzzRepo.GetAllBuzz();
    }

    [HttpGet("{BuzzId}")]
   public ActionResult<Buzz> GetBuzzById(int BuzzId)
   {
         var buzz = _buzzRepo.GetBuzzById(BuzzId);

        if(buzz is not null)
        {
            return buzz;
        }
        else
        {
            return NotFound();
        }
   }
    [HttpPost("{profileId}")]
    public IActionResult BuzzCreate(int profileId, Buzz NewBuzz)
    {
        var profile = _buzzRepo.GetProfileById(profileId);

        if (!ModelState.IsValid || NewBuzz == null)
        {
            return BadRequest();
        }

        var buzz = _buzzRepo.CreateBuzz(profile, NewBuzz);
        
        return Created(nameof(GetBuzzById), NewBuzz);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBuzz(int id)
    {
        var buzz = _buzzRepo.GetBuzzById(id);

        if(buzz is not null)
        {
            _buzzRepo.DeleteBuzz(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Buzz> UpdateBuzz(Buzz buzz)
    {

        if (!ModelState.IsValid || buzz == null)
        {
            return BadRequest();
        }

        return Ok(_buzzRepo.UpdateBuzz(buzz));
    }
}