using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Achieve;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class AchieveParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer achieveSerializer;

    public AchieveParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        nameSerializer = new XmlSerializer(typeof(StringMapping));
        achieveSerializer = new XmlSerializer(typeof(AchievesData));
    }

    public IEnumerable<(int Id, string Name, AchieveData Data)> Parse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/achievename.xml"));
        var mapping = nameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> achieveNames = mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("achieve/"))) {
            reader = XmlReader.Create(new StringReader(Sanitizer.RemoveEmpty(xmlReader.GetString(entry))));
            var root = achieveSerializer.Deserialize(reader) as AchievesData;
            Debug.Assert(root != null);

            AchieveData data = root.achieves;
            if (data == null) continue;

            int achieveId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (achieveId, achieveNames.GetValueOrDefault(achieveId), data);
        }
    }
}
