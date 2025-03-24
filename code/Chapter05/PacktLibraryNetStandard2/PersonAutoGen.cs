namespace Packt.Shared;

public partial class Person
{
    public string Origin
    {
        get
        {
            return string.Format("{0} was born on {1}", arg0: Name, arg1: HomePlanet);
        }
    }

    public string Greeting => $"{Name} says Hello";

    public int Age => DateTime.Today.Year - Born.Year;
    public string? FavoriteIceCream {get; set;}

    private string? _favoritePrimaryColor;

    public string? FavoritePrimaryColor
    {
        get => _favoritePrimaryColor;
        set {
            switch (value?.ToLower()) {
                case "red":
                case "green":
                case "blue":
                    _favoritePrimaryColor = value;
                    break;
                default:
                    throw new ArgumentException($" value is not a primary color, choose from red, green, blue");
            }
        }
    }

    private WonderOfTheAncientWorld _favoriteAncientWonder;
    public WonderOfTheAncientWorld FavoriteAncientWonder
    {
        get { return _favoriteAncientWonder;}
        set {
            string wonderName = value.ToString();
            if(wonderName.Contains(",")){
                throw new ArgumentException(message: "Favorite ancient wonder can only have one ancient wonder", paramName: nameof(FavoriteAncientWonder));
            }

            if(!Enum.IsDefined(typeof(WonderOfTheAncientWorld), value)){
                throw new ArgumentException(message: $"{value} is not a member of the WonderOfTheAncientWorld enum", paramName: nameof(FavoriteAncientWonder));
            }

            _favoriteAncientWonder = value;
        }
    }

    public Person this[int index]
    {
        get{
            return Children[index];
        }
        set{
            Children[index] = value;
        }
    }
}