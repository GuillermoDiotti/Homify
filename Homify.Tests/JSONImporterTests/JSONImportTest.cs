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
}
