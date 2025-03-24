using System.Formats.Asn1;

namespace Packt.Shared;

public class Person : IComparable<Person?>
{
    # region properties
    public string? Name { get; set; }
    public DateTimeOffset Born {get; set; }

    public List<Person> Children = new();
    # endregion

    #region methods
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}.");
    }

    public void WriteChildrenToConsole()
    {
        string term = Children.Count == 1 ? "child" : "children";
        WriteLine($"{Name} has {Children.Count} {term}");
    }
    # endregion

    public List<Person> Spouses = new();

    public bool Married => Spouses.Count > 0;

    public static void Marry(Person p1, Person p2)
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);

        if(p1.Spouses.Contains(p2) || p2.Spouses.Contains(p1)){
            throw new ArgumentException(string.Format("{0} is already married to {1}", arg0: p1.Name, p2.Name));
        } 
        p1.Spouses.Add(p2);
        p2.Spouses.Add(p1);
    }

    public void Marry(Person partner)
    {
        Marry(this, partner); // "this" is the current person.
    }

    public void OutputSpouses()
    {
        if(Married)
        {
            string term = Spouses.Count == 1 ? "person" : "people";
            WriteLine($"{Name} is married to {Spouses.Count} {term}");
            foreach(Person spouse in Spouses){
                WriteLine($" {spouse.Name}");
            }
        } else {
            WriteLine($"{Name} is a singleton");
        }
    }

    public static Person Procreate(Person p1, Person p2)
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);
        if (!p1.Spouses.Contains(p2) && !p2.Spouses.Contains(p1))
        {
            throw new ArgumentException(string.Format(
            "{0} must be married to {1} to procreate with them.",
            arg0: p1.Name, arg1: p2.Name));
        }
        
        Person baby = new()
        {
            Name = $"Baby of {p1.Name} and {p2.Name}",
            Born = DateTimeOffset.Now
        };
        p1.Children.Add(baby);
        p2.Children.Add(baby);
        return baby;
    }

    // Instance method to "multiply".
    public Person ProcreateWith(Person partner)
    {
        return Procreate(this, partner);
    }

    #region operators
    public static bool operator +(Person p1, Person p2)
    {
        Marry(p1, p2);
        return p1.Married && p2.Married;
    }
    public static Person operator *(Person p1, Person p2)
    {
        // Return a reference to the baby that results from multiplying.
        return Procreate(p1, p2);
    }
    #endregion

    #region events
    public EventHandler? Shout;

    public int AngerLevel;

    public void Poke()
    {
        AngerLevel++;
        if (AngerLevel < 3) return;

        // use Shout?.Invoke(this, EventArgs.Empty); as short
        if(Shout is not null){
            Shout(this, EventArgs.Empty);
        }
    }

    public int CompareTo(Person? other)
    {
        int position;
        if (other is not null) {
            if ((Name is not null) && (other.Name is not null)){
                // If both Name values are not null, then
                // use the string implementation of CompareTo.
                position = Name.CompareTo(other.Name);
            } else if ((Name is not null) && (other.Name is null)) {
                position = -1; // this Person precedes other Person.
            } else if ((Name is null) && (other.Name is not null)) {
                position = 1; // this Person follows other Person.
            }
            else {
                position = 0; // this and other are at same position.
            }
        } else if (other is null) {
            position = -1; // this Person precedes other Person.
        } else {
            position = 0; // this and other are at same position.
        }
        
        return position;
    }
    #endregion
}