namespace RetoExcepciones;

// Excepción personalizada: hereda de Exception
public class EdadInvalidaException : Exception
{
    // Guardamos la edad para poder usarla después (por ejemplo, en un filtro "when")
    public int Edad { get; }

    public EdadInvalidaException(int edad)
        : base($"La edad {edad} no es válida. Debe estar entre 0 y 120 años.")
    {
        Edad = edad;
    }
}
