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

    [TestMethod]
    [ExpectedException(typeof(FileNotFoundException))]
    public void ImportDevices_InvalidFilePath_ThrowsFileNotFoundException()
    {
        var filePath = "invalidPath.json";

        _jsonImport.ImportDevices(filePath);
    }

    [TestMethod]
    public void ImportDevices_ValidJson_ReturnsCorrectDevices()
    {
        var filePath = "validDevices.json";
        var jsonContent = @"
        {
            'dispositivos': [
                {
                    'nombre': 'Device1',
                    'tipo': 'Type1',
                    'modelo': 'Model1',
                    'id': '1',
                    'movement_detection': false,
                    'fotos': [
                        {
                            'Path': 'path1',
                            'IsPrincipal': true
                        }
                    ]
                }
            ]
        }";
        File.WriteAllText(filePath, jsonContent);

        var result = _jsonImport.ImportDevices(filePath);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("Device1", result[0].Name);
        Assert.AreEqual("Type1", result[0].Type);
        Assert.AreEqual("Model1", result[0].Model);
        Assert.AreEqual("1", result[0].Id);
        Assert.IsFalse(result[0].MovementDetection);
        Assert.AreEqual(1, result[0].Photos.Count);
        Assert.AreEqual("path1", result[0].Photos[0].Path);

        File.Delete(filePath);
    }
}
