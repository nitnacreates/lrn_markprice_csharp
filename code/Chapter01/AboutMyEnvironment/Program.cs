namespace AboutMyEnvironment;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        
        string name = typeof(Program).Namespace ?? "None";
        Console.WriteLine($"Namespace: {name}");

        Console.WriteLine(Environment.CurrentDirectory);
        Console.WriteLine(Environment.OSVersion.VersionString);
    }
}
