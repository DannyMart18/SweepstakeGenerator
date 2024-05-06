using NUnit.Framework;
using SweepstakeGeneratorv2.Services;  // Adjust based on your actual namespace
using SweepstakeGeneratorv2.Models;  // If your tests involve model classes



public class Tests
{
    
    SweepstakeService _sweepstakeService;
    [SetUp]
    public void Setup()
    {
        // Resetting the static list if necessary (if tests can modify it)
        SweepstakeService.AllHorses = new List<Horse>
        {
            new Horse { Name = "1 Noble Yeats" }
        };

        // Initialize the service
        _sweepstakeService = new SweepstakeService();
    }

    [Test]
    public void GenerateSweepstake_AssignsHorsesCorrectly_When_EnoughHorsesAvailable()
    {
        List<Person> people = new List<Person>();
        Person person1 = new Person("Alice", 1);
        
        people.Add(person1);
      

        // Act
        var result = _sweepstakeService.GenerateSweepstake(people);

        // Assert
        Assert.AreEqual(1, result[0].Horses.Count);
      
    }
    
    [Test]
    public void GenerateSweepstake_AssignsHorsesCorrectly_When_MoreHorsesSelected()
    {
        List<Person> people = new List<Person>();
        Person person1 = new Person("Alice", 5);
        Person person2 = new Person("James", 2);
        
        people.Add(person1);
        people.Add(person2);
      

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _sweepstakeService.GenerateSweepstake(people));
        Assert.That(ex.Message, Is.EqualTo("Not enough horses for everyone"));
      
    }

}