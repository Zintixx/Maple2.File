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
        string locale = "NA";
        Filter.Load(TestUtils.XmlReader, locale, "Live");
        var parser = new ItemParser(TestUtils.XmlReader, locale);

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
        string locale = "KR";
        Filter.Load(TestUtils.XmlReader, locale, "Live");
        var parser = new ItemParser(TestUtils.XmlReader, locale);

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
        string locale = "NA";
        Filter.Load(TestUtils.XmlReader, locale, "Live");
        var parser = new ItemParser(TestUtils.XmlReader, locale);
        var itemNames = parser.ItemNames();

        Assert.AreEqual(34038, itemNames.Count);
    }
}

