using Spectre.Console;
using Packt.Shared; // To use Viper.
using System.Xml;

SectionTitle("Writing to XML streams");

string xmlFile = Combine(CurrentDirectory, "streams.xml");

FileStream? xmlFileStream = null;
XmlWriter? xml = null;

try
{
    xmlFileStream = File.Create(xmlFile);
    xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });
    xml.WriteStartDocument();
    xml.WriteStartElement("callsigns");

    foreach(string item in Viper.Callsigns){
        xml.WriteElementString("callsign", item);
    }

    xml.WriteEndElement();
} catch(Exception ex) {
    WriteLine($"{ex.GetType()} says {ex.Message}");
} finally {
    if(xml != null) {
        xml.Close();
        WriteLine("The XML writer's unmanaged resources have been disposed.");
    }

    if(xmlFileStream != null) {
        xmlFileStream.Close();
        WriteLine("The file stream's unmanaged resources have been disposed.");
    }
}
OutputFileInfo(xmlFile);