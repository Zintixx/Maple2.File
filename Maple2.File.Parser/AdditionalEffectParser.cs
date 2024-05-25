using System.Diagnostics;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.AdditionalEffect;

namespace Maple2.File.Parser;

public class AdditionalEffectParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer effectSerializer;

    public AdditionalEffectParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        effectSerializer = new XmlSerializer(typeof(AdditionalEffectLevelData));
    }

    public IEnumerable<(int Id, IList<AdditionalEffectData> Data)> Parse() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("additionaleffect/"))) {
            var root = effectSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as AdditionalEffectLevelData;
            Debug.Assert(root != null);

            IList<AdditionalEffectData> data = root.level;
            if (data == null) continue;

            int effectId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (effectId, data);
        }
    }
}
