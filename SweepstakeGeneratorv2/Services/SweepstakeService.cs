using SweepstakeGeneratorv2.Models;

namespace SweepstakeGeneratorv2.Services;

public class SweepstakeService: ISweepstakeService
{
    private static readonly List<Horse> AllHorses = new List<Horse>
    {
        // Assuming these are the horses. Replace with real data.
        new Horse { Name = "Horse 1" },
        new Horse { Name = "Horse 2" },
        new Horse { Name = "Horse 3" },
        new Horse { Name = "Horse 4" },
        new Horse { Name = "Horse 5" },
        new Horse { Name = "Horse 6" },
        new Horse { Name = "Horse 7" },
        new Horse { Name = "Horse 8" },
        new Horse { Name = "Horse 9" },
        new Horse { Name = "Horse 10" },
        new Horse { Name = "Horse 11" },
    };
    
    public List<Person> GenerateSweepstake(List<Person> person)
    {
        if(AllHorses.Count < person.Count)
        {
            throw new Exception("Not enough horses for everyone");
        }
        
        var shuffledHorses = ShuffleHorses(AllHorses);
        var horseQueue = new Queue<Horse>(shuffledHorses);
        
        foreach(var p in person)
        {
            p.Horses = new List<Horse>();
            for(int i =0; i < p.NumHorses; i++)
            {
                if(horseQueue.TryDequeue(out Horse horse))
                {
                    p.Horses.Add(horse);
                }
            }
        }
        
        return person;
    }
    
    public List<Horse> ShuffleHorses(List<Horse> horses)
    {
        var random = new Random();
        return horses.OrderBy(h => random.Next()).ToList();
    }
    
    public List<Horse> GetHorses()
    {
        return AllHorses;
    }
    
    
}