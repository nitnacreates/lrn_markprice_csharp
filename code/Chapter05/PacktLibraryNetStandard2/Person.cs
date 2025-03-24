namespace Packt.Shared;

public partial class Person
{
    public string? Name;
    public DateTimeOffset Born;

    public WonderOfTheAncientWorld BucketList;

    public List<Person> Children = new();

    public readonly string HomePlanet = "Earth";
    public readonly DateTime Instantiated;

    public Person()
    {
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }
}