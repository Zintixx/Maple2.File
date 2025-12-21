using Maple2.File.Parser.Flat;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Maple2.File.Tests;

[TestClass]
public class ModelToNifResolverTest {
  private static ModelToNifResolver? resolver;

  [ClassInitialize]
  public static void ClassInitialize(TestContext context) {
    resolver = new ModelToNifResolver(
        TestUtils.ExportedReader,
        TestUtils.AssetMetadataReader,
        "flat"
    );
  }

  [TestMethod]
  public void Test_tr_floor_brick_B01() => TestModel("tr_floor_brick_B01_");

  [TestMethod]
  public void Test_tr_floor_brick_C01() => TestModel("tr_floor_brick_C01_");

  [TestMethod]
  public void Test_he_ground_rock_A05() => TestModel("he_ground_rock_A05_");

  [TestMethod]
  public void Test_tr_deform_brick_C01() => TestModel("tr_deform_brick_C01_");

  [TestMethod]
  public void Test_co_fluid_water_B02() => TestModel("co_fluid_water_B02_");

  [TestMethod]
  public void Test_tr_floor_brick_B03() => TestModel("tr_floor_brick_B03_");

  [TestMethod]
  public void Test_li_deform_portal_A03() => TestModel("li_deform_portal_A03_");

  [TestMethod]
  public void Test_he_ground_rock_B02() => TestModel("he_ground_rock_B02_");

  [TestMethod]
  public void Test_he_deform_portal_A03() => TestModel("he_deform_portal_A03_");

  [TestMethod]
  public void Test_ic_fi_nature_tree_I02() => TestModel("ic_fi_nature_tree_I02_");

  [TestMethod]
  public void Test_tr_floor_asphalt_A02() => TestModel("tr_floor_asphalt_A02_");

  [TestMethod]
  public void Test_tr_deform_stair_B02() => TestModel("tr_deform_stair_B02_");

  [TestMethod]
  public void Test_he_ground_grass_A02() => TestModel("he_ground_grass_A02_");

  [TestMethod]
  public void Test_tr_deform_brick_A03() => TestModel("tr_deform_brick_A03_");

  private void TestModel(string modelName) {
    string? nifAssetName = resolver?.GetNifAssetName(modelName);

    Assert.IsNotNull(nifAssetName, $"NIF asset not found for model: {modelName}");
    Assert.IsFalse(string.IsNullOrEmpty(nifAssetName), $"NIF asset name is empty for model: {modelName}");

    Console.WriteLine($"Model: {modelName} -> NIF Asset: {nifAssetName}");

    // Get full info for additional validation
    (string? name, string? path, string? tags) = resolver?.GetNifAssetInfo(modelName) ?? (null, null, null);
    Assert.IsNotNull(path, $"NIF asset path not found for model: {modelName}");
    Assert.IsTrue(
        path!.EndsWith(".nif", StringComparison.OrdinalIgnoreCase) ||
        (tags != null && tags.Contains("gamebryo-scenegraph")),
        $"Asset for {modelName} is not a NIF file. Path: {path}, Tags: {tags}"
    );
  }


  [TestMethod]
  public void TestInvalidModelName() {
    // Test with an invalid model name
    string? nifAssetName = resolver?.GetNifAssetName("this_model_does_not_exist_12345");

    Assert.IsNull(nifAssetName);
  }
}
