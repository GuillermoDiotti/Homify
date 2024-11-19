using JSONImporter;

namespace Homify.Tests.JSONImporterTests;

[TestClass]
public class JSONImportTest
{
    private JSONImport? _jsonImport;

    [TestInitialize]
    public void SetUp()
    {
        _jsonImport = new JSONImport();
    }

    [TestMethod]
    public void GetName_Returns_JsonImporter()
    {
        var result = _jsonImport.GetName();

        Assert.AreEqual("Json importer", result);
    }

    [TestMethod]
    public void ImportDevices_EmptyDevices_ReturnsEmptyList()
    {
        var filePath = "emptyDevices.json";
        var jsonContent = @"{ 'Devices': [] }";
        File.WriteAllText(filePath, jsonContent);

        var result = _jsonImport.ImportDevices(filePath);

        Assert.AreEqual(0, result.Count);

        File.Delete(filePath);
    }
}
