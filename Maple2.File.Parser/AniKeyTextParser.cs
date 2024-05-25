using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.Parser.Xml;

namespace Maple2.File.Parser;

public class AniKeyTextParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer aniSerializer;

    public AniKeyTextParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        aniSerializer = new XmlSerializer(typeof(AnimationData));
    }

    public IEnumerable<AnimationData> Parse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("anikeytext.xml"));
        var data = aniSerializer.Deserialize(reader) as AnimationData;
        Debug.Assert(data != null);

        yield return data;
    }
}
