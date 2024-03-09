using SweepstakeGeneratorv2.Models;

namespace SweepstakeGeneratorv2.Services;

public interface ISweepstakeService
{
    public List<Person> GenerateSweepstake(List<Person> people);
    
    public List<Horse> ShuffleHorses(List<Horse> horses);
    
    public List<Horse> GetHorses();
    
}