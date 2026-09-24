using Maple2.File.Parser.Flat.Convert;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

/// <summary>
/// Custom-asset registration: derived fields match the stock metadata conventions, registered assets
/// resolve like stock ones, and collisions with existing assets fail. Synthetic index — no game data.
/// </summary>
[TestClass]
public class AssetIndexRegisterTest {
    // One real stock record (GMS2 asset-web-metadata): the cave brick cube NIF.
    private const string StockUuid = "urn:uuid:60424d74-b379-4bf7-8457-7ea5bd6f7459";
    private const string StockLlid = "2a5283e7-0000-0000-0000-000000000000";
    private const string StockRelPath = "/Model/Map/Cave/cube/ca_deform_brick_A01.nif";

    private static AssetIndex BuildIndex() {
        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, leaveOpen: true)) {
            writer.Write((uint) 0x00495341);
            writer.Write(1);

            writer.Write(1); // llidLookup
            writer.Write(StockLlid);
            writer.Write(1);
            writer.Write(StockUuid);

            string[] tagFiles = {
                "application", "cn", "dds", "emergent-flat-model", "emergent-world", "fx-shader-compiled",
                "gamebryo-animation", "gamebryo-scenegraph", "gamebryo-sequence-file", "image", "jp", "kr",
                "lua-behavior", "model", "png", "precache", "script", "shader", "x-shockwave-flash", "x-world",
            };
            var nt = new List<(string Key, Dictionary<string, string> Map)> {
                ("llid", new() { [StockUuid] = StockLlid }),
                ("name", new() { [StockUuid] = "ca_deform_brick_A01" }),
                ("relpath", new() { [StockUuid] = StockRelPath }),
            };
            foreach (string tag in tagFiles) {
                var map = new Dictionary<string, string>();
                if (tag is "application" or "gamebryo-scenegraph") map[StockUuid] = tag;
                nt.Add((tag, map));
            }

            writer.Write(nt.Count);
            foreach ((string key, Dictionary<string, string> map) in nt) {
                writer.Write(key);
                writer.Write(map.Count);
                foreach ((string k, string v) in map) {
                    writer.Write(k);
                    writer.Write(v);
                }
            }
        }
        ms.Position = 0;
        using var reader = new BinaryReader(ms);
        return AssetIndex.Deserialize(reader);
    }

    [TestMethod]
    public void ComputeLlid_MatchesStockRecord() {
        Assert.AreEqual(StockLlid, AssetIndex.ComputeLlid("/model/map/cave/cube/ca_deform_brick_a01.nif"));
    }

    [TestMethod]
    public void Register_DerivesStockStyleFields() {
        AssetIndex.CustomAsset asset = BuildIndex().Register("/Model/Map/Custom/cube/cu_test_cube_A01.nif",
            "application", "gamebryo-scenegraph");

        Assert.AreEqual("cu_test_cube_A01", asset.Name);
        Assert.AreEqual("/model/map/custom/cube/cu_test_cube_a01.nif", asset.LogPath);
        Assert.AreEqual("/Model/Map/Custom/cube", asset.Canonical);
        Assert.AreEqual(AssetIndex.ComputeLlid(asset.LogPath), asset.Llid);
        StringAssert.StartsWith(asset.Uuid, "urn:uuid:");
        Assert.AreEqual('5', asset.Uuid["urn:uuid:".Length + 14], "version-5 uuid");
    }

    [TestMethod]
    public void Registered_ResolvesLikeStock() {
        AssetIndex index = BuildIndex();
        AssetIndex.CustomAsset asset = index.Register("/Model/Map/Custom/cube/cu_test_cube_A01.nif",
            "application", "gamebryo-scenegraph");

        (string name, string path, string tags) = index.GetFields(asset.UrnLlid);
        Assert.AreEqual("cu_test_cube_A01", name);
        Assert.AreEqual("/Model/Map/Custom/cube/cu_test_cube_A01.nif", path);
        Assert.AreEqual("application:gamebryo-scenegraph:cu_test_cube_A01", tags);
        Assert.AreEqual(asset.UrnLlid, index.ResolveLlid("cu_test_cube_a01"));
        Assert.AreEqual("urn:llid:" + StockLlid, index.ResolveLlid("ca_deform_brick_A01"), "stock still resolves");
    }

    [TestMethod]
    public void ResolveLlid_PrefersTheNif_WhenATextureSharesItsName() {
        AssetIndex index = BuildIndex();
        AssetIndex.CustomAsset nif = index.Register("/Model/Map/Custom/cube/cu_same_A01.nif", "application", "gamebryo-scenegraph");
        index.Register("/Model/Map/Textures/Custom/cu_same_A01.dds", "dds", "image"); // registered last

        Assert.AreEqual(nif.UrnLlid, index.ResolveLlid("cu_same_A01"));
    }

    [TestMethod]
    public void Register_IsIdempotent_AndSurvivesSerialization() {
        AssetIndex index = BuildIndex();
        AssetIndex.CustomAsset first = index.Register("/Model/Map/Custom/cube/cu_test_cube_A01.nif", "gamebryo-scenegraph");
        AssetIndex.CustomAsset again = index.Register("/Model/Map/Custom/cube/cu_test_cube_A01.nif", "gamebryo-scenegraph");
        Assert.AreEqual(first.Uuid, again.Uuid);

        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, System.Text.Encoding.UTF8, leaveOpen: true)) index.Serialize(writer);
        ms.Position = 0;
        AssetIndex copy = AssetIndex.Deserialize(new BinaryReader(ms));
        Assert.AreEqual("cu_test_cube_A01", copy.GetFields(first.UrnLlid).Name);
    }

    [TestMethod]
    public void Register_RetailPath_Throws() {
        // Same logpath as the stock cube -> same llid -> must not shadow it.
        Assert.ThrowsException<InvalidOperationException>(() =>
            BuildIndex().Register("/Model/Map/cave/cube/CA_DEFORM_BRICK_A01.nif", "gamebryo-scenegraph"));
    }

    [TestMethod]
    public void Register_RejectsBadInput() {
        AssetIndex index = BuildIndex();
        Assert.ThrowsException<ArgumentException>(() => index.Register("Model/Map/x.nif"));
        Assert.ThrowsException<ArgumentException>(() => index.Register("/Model\\Map\\x.nif"));
        Assert.ThrowsException<ArgumentException>(() => index.Register("/Model/Map/noext"));
        Assert.ThrowsException<ArgumentException>(() => index.Register("/Model/Map/x.nif", "not-a-tag"));
    }

    [TestMethod]
    public void ToNtLines_UseStockLineFormat() {
        AssetIndex.CustomAsset asset = BuildIndex().Register("/Model/Map/Custom/cube/cu_test_cube_A01.nif",
            "application", "gamebryo-scenegraph");
        var lines = asset.ToNtLines().ToDictionary(l => l.File, l => l.Line);

        CollectionAssert.AreEquivalent(
            new[] { "llid.nt", "name.nt", "relpath.nt", "logpath.nt", "canonical.nt", "application.nt", "gamebryo-scenegraph.nt" },
            lines.Keys.ToArray());
        Assert.AreEqual($"<{asset.Uuid}> <http://emergent.net/aweb/1.0/llid> \"{asset.Llid}\".", lines["llid.nt"]);
        Assert.AreEqual($"<{asset.Uuid}> <http://emergent.net/aweb/1.0/tag> \"gamebryo-scenegraph\".", lines["gamebryo-scenegraph.nt"]);
    }
}
