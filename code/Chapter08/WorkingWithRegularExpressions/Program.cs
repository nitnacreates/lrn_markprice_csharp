// using StringDictionary = System.Collections.Generic.Dictionary<string, string>;

using System.Collections.ObjectModel;

List<string> cities = new() {"London", "Paris", "Milan" };
cities.Insert(0, "Sydney");
OutputCollection("Initial list", cities);

Dictionary<string, string> keywords = new();
keywords.Add(key: "int", value: "32-bit integer data type");
// Add using positional parameters.
keywords.Add("long", "64-bit integer data type"); 
keywords.Add("float", "Single precision floating point number");
OutputCollection("Dictionary keys", keywords.Keys);
OutputCollection("Dictionary values", keywords.Values);

HashSet<string> names = new();

ReadOnlyDictionary<string, string> values = new();
