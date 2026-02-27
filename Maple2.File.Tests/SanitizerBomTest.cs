using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class SanitizerBomTest {
    private const string XML_CONTENT = "<?xml version=\"1.0\" encoding=\"utf-8\"?><ms2><item id=\"1\" name=\"TestItem\" /></ms2>";

    [XmlRoot("ms2")]
    public class Ms2Root {
        [XmlElement("item")]
        public ItemElement? Item { get; set; }
    }

    public class ItemElement {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty;
    }

    [TestMethod]
    public void TestParseXmlWithoutBom() {
        byte[] data = Encoding.UTF8.GetBytes(XML_CONTENT);
        string xml = Encoding.Default.GetString(data);

        var serializer = new XmlSerializer(typeof(Ms2Root));
        using var reader = new StringReader(xml);
        var result = (Ms2Root?) serializer.Deserialize(reader);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Item);
        Assert.AreEqual(1, result.Item.Id);
        Assert.AreEqual("TestItem", result.Item.Name);
    }

    [TestMethod]
    public void TestParseXmlWithBom() {
        byte[] bom = [0xEF, 0xBB, 0xBF];
        byte[] content = Encoding.UTF8.GetBytes(XML_CONTENT);
        byte[] data = [.. bom, .. content];

        // Simulate M2dReader.GetString() which strips BOM
        string xml = Encoding.Default.GetString(data);
        if (xml.Length > 0 && xml[0] == '\uFEFF') {
            xml = xml[1..];
        }

        var serializer = new XmlSerializer(typeof(Ms2Root));
        using var reader = new StringReader(xml);
        var result = (Ms2Root?) serializer.Deserialize(reader);

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Item);
        Assert.AreEqual(1, result.Item.Id);
        Assert.AreEqual("TestItem", result.Item.Name);
    }
}
