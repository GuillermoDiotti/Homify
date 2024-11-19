using Homify.Utility;

namespace Homify.Tests.UtilityTests;

[TestClass]
public class HomifyDateTimeTest
{
    [TestMethod]
    public void Parse_ValidDate_ReturnsParsedDate()
    {
        var validDate = "25/12/2023";

        var result = HomifyDateTime.Parse(validDate);

        Assert.AreEqual("25/12/2023", result);
    }
}
