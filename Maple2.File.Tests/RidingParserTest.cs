using Maple2.File.Parser;
using Maple2.File.Parser.Xml.Riding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class RidingParserTest {
    [TestMethod]
    public void TestRidingParser() {
        var parser = new RidingParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, Riding data) in parser.Parse()) {
            // Debug.WriteLine($"Parsing Riding: {id}");
            Assert.IsTrue(id >= 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(480, count);
    }

    [TestMethod]
    public void TestRidingPassengerParser() {
        var parser = new RidingParser(TestUtils.XmlReader);

        int count = 0;
        foreach ((int id, IList<PassengerRiding> data) in parser.ParsePassenger()) {
            // Debug.WriteLine($"Parsing PassengerRiding: {id}");
            Assert.IsTrue(id > 0);
            Assert.IsNotNull(data);
            count++;
        }
        Assert.AreEqual(29, count);
    }
}
