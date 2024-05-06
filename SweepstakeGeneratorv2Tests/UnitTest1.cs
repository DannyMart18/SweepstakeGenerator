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

        // Initialize the service
        _sweepstakeService = new SweepstakeService();
    }

    [Test]
    public void GenerateSweepstake_AssignsHorsesCorrectly_When_EnoughHorsesAvailable()
    {
        List<Person> people = new List<Person>();
        Person person1 = new Person("Alice", 5);
        
        people.Add(person1);
      

        // Act
        var result = _sweepstakeService.GenerateSweepstake(people);

        // Assert
        Assert.AreEqual(5, result[0].Horses.Count);
      
    }
    
    [Test]
    public void GenerateSweepstake_AssignsHorsesCorrectly_When_MoreHorsesSelected()
    {
        List<Person> people = new List<Person>();
        Person person1 = new Person("Alice", 55);
        
        people.Add(person1);
      

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => _sweepstakeService.GenerateSweepstake(people));
        Assert.That(ex.Message, Is.EqualTo("Not enough horses for everyone"));
      
    }

}