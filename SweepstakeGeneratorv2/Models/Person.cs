namespace SweepstakeGeneratorv2.Models;

public class Person
{
    public string Name {get; set;}
    public int NumHorses {get; set;}
    
    public List<Horse> Horses {get; set;}
    
    public Person(string name, int numHorses)
    {
        Name = name;
        this.NumHorses = numHorses;
        Horses = new List<Horse>();
    }
    
    
}