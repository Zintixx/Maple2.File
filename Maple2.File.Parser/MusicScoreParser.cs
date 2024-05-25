using System.Diagnostics;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.MusicScore;

namespace Maple2.File.Parser;

public class MusicScoreParser {
    private readonly M2dReader xmlReader;
    private readonly XmlSerializer musicSerializer;

    public MusicScoreParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        musicSerializer = new XmlSerializer(typeof(MusicScoreData));
    }

    public IEnumerable<(int Id, MusicScoreData Data)> Parse() {
        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("musicscore/"))) {
            var data = musicSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as MusicScoreData;
            Debug.Assert(data != null);

            // Skips "sample.xml"
            if (int.TryParse(Path.GetFileNameWithoutExtension(entry.Name), out int id)) {
                yield return (id, data);
            }
        }
    }
}
