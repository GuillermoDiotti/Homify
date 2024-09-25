

using Homify.Exceptions;
using Homify.Utility;

namespace Homify.Tests.UtilsTests;

[TestClass]
public class AccountCredentialsValidatorTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgsNullException))]
    public void CheckEmail_EmptyEmail_ThrowsInvalidFormatException()
    {
        var email = string.Empty;
        AccountCredentialsValidator.CheckEmail(email);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CheckEmail_InvalidEmailWithoutAt_ThrowsInvalidFormatException()
    {
        var email = "invalidemail.com";
        AccountCredentialsValidator.CheckEmail(email);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CheckEmail_InvalidEmailWithoutDomain_ThrowsInvalidFormatException()
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
    [ExpectedException(typeof(ArgsNullException))]
    public void CheckPassword_EmptyPassword_ThrowsInvalidFormatException()
    {
        var password = string.Empty;
        AccountCredentialsValidator.CheckPassword(password);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CheckPassword_ShortPassword_ThrowsInvalidFormatException()
    {
        var password = "Abc1!";
        AccountCredentialsValidator.CheckPassword(password);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidFormatException))]
    public void CheckPassword_NoSpecialCharacter_ThrowsInvalidFormatException()
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
