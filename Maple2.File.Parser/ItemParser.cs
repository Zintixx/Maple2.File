using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using Maple2.File.IO;
using Maple2.File.IO.Crypto.Common;
using Maple2.File.Parser.Xml.Item;
using Maple2.File.Parser.Xml.String;

namespace Maple2.File.Parser;

public class ItemParser {
    private readonly M2dReader xmlReader;
    public readonly XmlSerializer NameSerializer;
    public readonly XmlSerializer ItemSerializer;

    public ItemParser(M2dReader xmlReader) {
        this.xmlReader = xmlReader;
        this.NameSerializer = new XmlSerializer(typeof(StringMapping));
        this.ItemSerializer = new XmlSerializer(typeof(ItemDataRoot));
    }

    public IEnumerable<(int Id, string Name, ItemData Data)> Parse() {
        XmlReader reader = xmlReader.GetXmlReader(xmlReader.GetEntry("en/itemname.xml"));
        var mapping = NameSerializer.Deserialize(reader) as StringMapping;
        Debug.Assert(mapping != null);

        Dictionary<int, string> itemNames = mapping.key.ToDictionary(key => int.Parse(key.id), key => key.name);

        foreach (PackFileEntry entry in xmlReader.Files.Where(entry => entry.Name.StartsWith("item/"))) {
            var root = ItemSerializer.Deserialize(xmlReader.GetXmlReader(entry)) as ItemDataRoot;
            Debug.Assert(root != null);

            ItemData data = root.environment;
            if (data == null) continue;

            int itemId = int.Parse(Path.GetFileNameWithoutExtension(entry.Name));
            yield return (itemId, itemNames.GetValueOrDefault(itemId), data);
        }
    }
}
