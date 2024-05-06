using SweepstakeGeneratorv2.Models;

namespace SweepstakeGeneratorv2.Services;

public class SweepstakeService: ISweepstakeService
{
    private static readonly List<Horse> AllHorses = new List<Horse>
    {
        new Horse { Name = "1 Noble Yeats" },
        new Horse { Name = "2 Nassalam" },
        new Horse { Name = "3 Coko Beach" },
        new Horse { Name = "4 Capodanno" },
        new Horse { Name = "5 I Am Maximus" },
        new Horse { Name = "6 Minella Indo" },
        new Horse { Name = "7 Corach Rambler" },
        new Horse { Name = "8 Janidil" },
        new Horse { Name = "9 Stattler" },
        new Horse { Name = "10 Mahler Mission" },
        new Horse { Name = "11 Delta Work" },
        new Horse { Name = "12 Foxy Jacks" },
        new Horse { Name = "13 Galvin" },
        new Horse { Name = "14 Farouk d'Alene" },
        new Horse { Name = "15 Eldorado Allen" },
        new Horse { Name = "16 Ain't That A Shame" },
        new Horse { Name = "17 Vanillier" },
        new Horse { Name = "18 Mr Incredible" },
        new Horse { Name = "20 Latenightpass" },
        new Horse { Name = "21 Minella Crooner" },
        new Horse { Name = "22 Adamantly Chosen" },
        new Horse { Name = "23 Mac Tottie" },
        new Horse { Name = "24 Chemical Energy" },
        new Horse { Name = "25 Limerick Lace" },
        new Horse { Name = "26 Meetingofthewaters" },
        new Horse { Name = "27 The Goffer" },
        new Horse { Name = "28 Roi Mage" },
        new Horse { Name = "29 Glengouly" },
        new Horse { Name = "30 Galia Des Liteaux" },
        new Horse { Name = "31 Panda Boy" },
        new Horse { Name = "32 Eklat De Rire" },
        new Horse { Name = "34 Kitty's Light" }
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
    
    //check if horse is already assigned to a person
    public bool IsHorseAssigned(Horse horse, List<Person> people)
    {
        foreach(var p in people)
        {
            if(p.Horses.Contains(horse))
            {
                return true;
            }
        }
        return false;
    }
    
    
}