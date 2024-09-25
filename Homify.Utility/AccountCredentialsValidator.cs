namespace Homify.Utility;

using System;
using System.Text.RegularExpressions;

public static class AccountCredentialsValidator
{
    public static void CheckEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("El correo no puede estar vacío.");
        }

        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        if (!Regex.IsMatch(email, emailPattern))
        {
            throw new ArgumentException("El correo no es válido. Debe contener '@' y un dominio válido.");
        }
    }

    public static void CheckPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("La contraseña no puede estar vacía.");
        }

        if (password.Length < 6)
        {
            throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
        }

        var specialCharPattern = @"[!@#$%^&*(),.?""{}|<>]";

        if (!Regex.IsMatch(password, specialCharPattern))
        {
            throw new ArgumentException("La contraseña debe contener al menos un carácter especial.");
        }
    }
}
