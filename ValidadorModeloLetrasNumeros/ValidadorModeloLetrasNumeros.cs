using ModeloValidador.Abstracciones;

public class ValidadorModeloLetrasNumeros : IModeloValidador
{
    public bool EsValido(Modelo modelo)
    {
        if (string.IsNullOrEmpty(modelo.Value))
        {
            return false;
        }

        var nombre = modelo.Value;

        if (nombre.Length != 6)
        {
            return false;
        }

        for (var i = 0; i < 3; i++)
        {
            if (!char.IsLetter(nombre[i]))
            {
                return false;
            }
        }

        for (var i = nombre.Length - 3; i < nombre.Length; i++)
        {
            if (!char.IsDigit(nombre[i]))
            {
                return false;
            }
        }

        return true;
    }
}
