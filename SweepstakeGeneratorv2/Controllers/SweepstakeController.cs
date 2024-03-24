using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SweepstakeGeneratorv2.Models;
using SweepstakeGeneratorv2.Services;

[ApiController]
[Route("[controller]")]
public class SweepstakeController : ControllerBase
{
    private readonly ISweepstakeService _sweepstakeService;
    private readonly ILogger<SweepstakeController> _logger;

    
    public SweepstakeController(ISweepstakeService sweepstakeService, ILogger<SweepstakeController> logger)
    {
        _sweepstakeService = sweepstakeService;
        _logger = logger;
    }
    
    [HttpPost]
    public ActionResult GenerateSweepstake([FromBody] List<Person> persons)
    {
        int numHorses = _sweepstakeService.GetHorses().Count;
    
        if (persons == null || persons.Count == 0)
        {
            _logger.LogError("No people to generate sweepstake for");
            return BadRequest("No people to generate sweepstake for");
        }

        int totalPersonHorses = 0;
        // Check if the number of horses in request per person exceeds the number of horses available
        foreach (var p in persons)
        {
            totalPersonHorses += p.NumHorses;
            if (p.NumHorses > numHorses)
            {
                _logger.LogError("Not enough horses for everyone");
                return BadRequest("Not enough horses for everyone");
            }
        }

        if (totalPersonHorses > numHorses)
        {
            _logger.LogError("Not enough horses for everyone");
            return BadRequest("Not enough horses for everyone");
        }
        else if (totalPersonHorses < numHorses)
        {
            _logger.LogError("Not all horses have been assigned to a person");
            return BadRequest("Not all horses have been assigned to a person");
        }
        else
        {
            try
            {
                var result = _sweepstakeService.GenerateSweepstake(persons);
                _logger.LogInformation("Sweepstake generated successfully");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating sweepstake");
                return BadRequest(ex.Message);
            }
        }

        
    }
    
    [HttpGet]
    public ActionResult GetHorses()
    {
        try
        {
            var horses = _sweepstakeService.GetHorses();
            _logger.LogInformation("Horses retrieved successfully");
            return Ok(horses);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving horses");
            return BadRequest(ex.Message);
        }
    }

    
}