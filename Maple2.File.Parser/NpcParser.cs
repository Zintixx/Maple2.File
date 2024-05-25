using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Npc;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class NpcParser {
    private readonly M2dReader xmlReader;
    public readonly XmlSerializer NameSerializer;
    public readonly XmlSerializer NpcSerializer;

    public NpcParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.NameSerializer = new XmlSerializer(typeof(StringMapping));
        this.NpcSerializer = new XmlSerializer(typeof(NpcDataRoot));
    }

    public IEnumerable<(int Id, string Name, NpcData Data, List<EffectDummy> Dummy)> Parse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/npcname.xml"));
        var mapping = NameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> npcNames = mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("npc/"))) {
            reader = XmlReader.Create(new StringReader(Sanitizer.SanitizeNpc(xmlReader.GetString(entry))));
            var root = NpcSerializer.Deserialize(reader) as NpcDataRoot;
            Debug.Assert(root != null);

            NpcData data = root.environment;
            if (data == null) continue;

            int npcId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (npcId, npcNames.GetValueOrDefault(npcId), data, root.effectdummy);
        }
    }
}
