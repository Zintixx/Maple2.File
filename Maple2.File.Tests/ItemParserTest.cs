using M2dXmlGenerator;
using Maple2.File.Parser;
using Maple2.File.Parser.Tools;
using Maple2.File.Parser.Xml.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class ItemParserTest {
    [TestMethod]
    public void TestItemParser() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new ItemParser(TestUtils.XmlReader, "en");

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.ItemSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.ItemSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, ItemData data) in parser.Parse()) {
            // Debug.WriteLine($"Parsing item: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);

            count++;
        }
        Assert.AreEqual(35309, count);
    }

    [TestMethod]
    public void TestItemParserNew() {
        Filter.Load(TestUtils.XmlReader, "KR", "Live");
        var parser = new ItemParser(TestUtils.XmlReader, "kr");

        // parser.NameSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.NameSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;
        // parser.ItemSerializer.UnknownElement += TestUtils.UnknownElementHandler;
        // parser.ItemSerializer.UnknownAttribute += TestUtils.UnknownAttributeHandler;

        int count = 0;
        foreach ((int id, string name, ItemData data) in parser.ParseNew()) {
            // Debug.WriteLine($"Parsing item: {id} ({name})");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(35970, count);
    }

    [TestMethod]
    public void TestItemNames() {
        Filter.Load(TestUtils.XmlReader, "NA", "Live");
        var parser = new ItemParser(TestUtils.XmlReader, "en");
        var itemNames = parser.ItemNames();

        Assert.AreEqual(34038, itemNames.Count);
    }
}

