using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using M2dXmlGenerator;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.Skill;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class SkillParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer nameSerializer;
    private readonly XmlSerializer skillSerializer;

    public SkillParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        nameSerializer = new XmlSerializer(typeof(StringMapping));
        skillSerializer = new XmlSerializer(typeof(SkillData));
    }

    public IEnumerable<(int Id, string Name, SkillData Data)> Parse() {
        Dictionary<int, string> skillNames = new();
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("string/en/skillname"))) {
            XmlReader reader = xmlReader.GetXmlReader(entry);
            var mapping = nameSerializer.Deserialize(reader) as StringMapping;
            Debug.Assert(mapping != null);

            foreach (Key key in mapping.key) {
                skillNames.Add(int.Parse(key.id), key.name);
            }
        }

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("skill/"))) {
            var data = skillSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as SkillData;
            Debug.Assert(data != null);

            if (data.FeatureLocale() == null) continue;

            int skillId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (skillId, skillNames.GetValueOrDefault(skillId), data);
        }
    }
}
