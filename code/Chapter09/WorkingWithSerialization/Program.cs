using System.Xml.Serialization;
using Packt.Shared;

List<Person> people = new()
{
    new(initialSalary: 30_000M) 
    {
        FirstName = "Alice",
        LastName = "Smith",
        DateOfBirth = new(year: 1974, month: 3, day: 14)
    },
    new(initialSalary: 40_000M) 
    {
        FirstName = "Bob",
        LastName = "Jones",
        DateOfBirth = new(year: 1969, month: 11, day: 23)
    },
    new(initialSalary: 20_000M)
    {
        FirstName = "Charlie",
        LastName = "Cox",
        DateOfBirth = new(year: 1984, month: 5, day: 4),
        Children = new()
        {
        new(initialSalary: 0M)
        {
            FirstName = "Sally",
            LastName = "Cox",
            DateOfBirth = new(year: 2012, month: 7, day: 12)
        }
        }
    }
};
SectionTitle("Serializing as XML");

XmlSerializer xs = new(type: people.GetType());

string path = Combine(CurrentDirectory, "people.xml");
using(FileStream stream = File.Create(path))
{
    xs.Serialize(stream, people);
}
OutputFileInfo(path);

SectionTitle("Serializing with JSON");
string jsonPath = Combine(CurrentDirectory, "people.json");
using(StreamWriter jsonStream = File.CreateText(jsonPath)){
    Newtonsoft.Json.JsonSerializer jss = new();
    jss.Serialize(jsonStream, people);
}
OutputFileInfo(jsonPath);