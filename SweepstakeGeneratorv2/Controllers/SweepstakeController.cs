using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SweepstakeGeneratorv2.Models;
using SweepstakeGeneratorv2.Services;

namespace SweepstakeGeneratort;

[ApiController]
[Route("[controller]")]
public class SweepstakeController : ControllerBase
{
    private readonly ISweepstakeService _sweepstakeService;
    
    public SweepstakeController(ISweepstakeService sweepstakeService)
    {
        _sweepstakeService = sweepstakeService;
    }
    
    [HttpPost]
    public ActionResult GenerateSweepstake([FromBody] List<Person> persons, int numHorses)
    {
        if(persons == null || persons.Count == 0)
        {
            return BadRequest("No people to generate sweepstake for");
        }

        try
        {
            var result = _sweepstakeService.GenerateSweepstake(persons);
            return Ok(result);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
    
}