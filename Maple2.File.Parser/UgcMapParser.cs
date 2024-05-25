using System.Diagnostics;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml;

namespace Maple2.File.Parser;

public class UgcMapParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer ugcMapSerializer;
    private readonly XmlSerializer exportedUgcMapSerializer;

    public UgcMapParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.ugcMapSerializer = new XmlSerializer(typeof(UgcMap));
        this.exportedUgcMapSerializer = new XmlSerializer(typeof(ExportedUgcMap));
    }

    public IEnumerable<(int Id, UgcMap Data)> Parse() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("ugcmap/"))) {
            var data = ugcMapSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as UgcMap;
            Debug.Assert(data != null);

            int id = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (id, data);
        }
    }

    public IEnumerable<(string Id, ExportedUgcMap Data)> ParseExported() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("exportedugcmap/"))) {
            var data = exportedUgcMapSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as ExportedUgcMap;
            Debug.Assert(data != null);

            string id = Path.GetFileNameWithoutExtension(entry.Name);
            yield return (id, data);
        }
    }
}
