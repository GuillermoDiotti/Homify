using JSONImporter;

namespace Homify.Tests.JSONImporterTests;

[TestClass]
public class JSONImportTest
{
    [TestMethod]
    public void GetName_Returns_JsonImporter()
    {
        var jsonImport = new JSONImport();

        var result = jsonImport.GetName();

        Assert.AreEqual("Json importer", result);
    }
}
