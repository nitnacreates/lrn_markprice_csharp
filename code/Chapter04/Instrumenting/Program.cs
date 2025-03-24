using System.Diagnostics;
using Microsoft.Extensions.Configuration;


// string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt");
string logPath = Path.Combine(Directory.GetCurrentDirectory() , "log.txt");

Console.WriteLine($"Writing to: {logPath}");

TextWriterTraceListener logFile = new (File.CreateText(logPath));
Trace.Listeners.Add(logFile);

Trace.AutoFlush = true;

Debug.WriteLine("Debug says, I am watching!");
Trace.WriteLine("Trace says, I am watching!");

string settingsFile = "appsettings.json";
string settingsPath = Path.Combine(Directory.GetCurrentDirectory(), settingsFile);

Console.WriteLine("Processing: {0}", settingsPath);
Console.WriteLine("--{0} contents --", settingsFile);
Console.WriteLine(File.ReadAllText(settingsPath));
Console.WriteLine("------");

ConfigurationBuilder builder = new();
builder.SetBasePath(Directory.GetCurrentDirectory());

builder.AddJsonFile(settingsFile, optional: false, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build();
TraceSwitch ts = new(
    displayName: "PacktSwich",
    description: "This switch is set via JSON config"
);
configuration.GetSection("PacktSwitch").Bind(ts);
Console.WriteLine($"Trace switch vakye: {ts.Value}");
Console.WriteLine($"Trace Switch level: {ts.Level}");

Trace.WriteLineIf(ts.TraceError, "Trace Error");
Trace.WriteLineIf(ts.TraceWarning, "Trace warning"); 
Trace.WriteLineIf(ts.TraceInfo, "Trace information"); 
Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");

int unitsInStock = 12;
LogSourceDetails(unitsInStock > 10);

Debug.Close();
Trace.Close();

Console.WriteLine("Press any key to exit");
Console.ReadLine();