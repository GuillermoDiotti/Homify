

using Homify.Utility;

namespace Homify.Tests.UtilsTests;

[TestClass]
public class AccountCredentialsValidatorTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CheckEmail_EmptyEmail_ThrowsArgumentException()
    {
        var email = string.Empty;
        AccountCredentialsValidator.CheckEmail(email);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CheckEmail_InvalidEmailWithoutAt_ThrowsArgumentException()
    {
        var email = "invalidemail.com";
        AccountCredentialsValidator.CheckEmail(email);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CheckEmail_InvalidEmailWithoutDomain_ThrowsArgumentException()
    {
        var email = "invalidemail@";
        AccountCredentialsValidator.CheckEmail(email);
    }

    [TestMethod]
    public void CheckEmail_ValidEmail_Passes()
    {
        var email = "validemail@example.com";
        AccountCredentialsValidator.CheckEmail(email);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CheckPassword_EmptyPassword_ThrowsArgumentException()
    {
        var password = string.Empty;
        AccountCredentialsValidator.CheckPassword(password);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CheckPassword_ShortPassword_ThrowsArgumentException()
    {
        var password = "Abc1!";
        AccountCredentialsValidator.CheckPassword(password);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CheckPassword_NoSpecialCharacter_ThrowsArgumentException()
    {
        var password = "Password1";
        AccountCredentialsValidator.CheckPassword(password);
    }

    [TestMethod]
    public void CheckPassword_ValidPassword_Passes()
    {
        var password = "Password1!";
        AccountCredentialsValidator.CheckPassword(password);
    }
}
