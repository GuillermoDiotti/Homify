using ModeloValidador.Abstracciones;

public class ValidadorModeloSoloLetras : IModeloValidador
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

        foreach (var c in nombre)
        {
            if (!char.IsLetter(c))
            {
                return false;
            }
        }

        return true;
    }
}
