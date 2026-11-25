namespace RetoExcepciones;

class Program
{
    static void Main(string[] args)
    {
        // Para que las tildes se vean bien en la consola de Windows
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Reto de excepciones: validación de edad ===");
        Console.Write("Ingresa tu edad: ");
        string? entrada = Console.ReadLine();

        try
        {
            // Si el texto no es un número entero, int.Parse lanza una excepción
            int edad = int.Parse(entrada ?? "");

            ValidarEdad(edad);
            Console.WriteLine($"Edad válida: {edad} años.");
        }
        catch (FormatException)
        {
            // El texto no tiene forma de número (por ejemplo "hola")
            Console.WriteLine("Error: debes escribir un número entero, no letras ni símbolos.");
        }
        catch (OverflowException)
        {
            // Es un número, pero no cabe en un int (más de 2.147.483.647 o menos de -2.147.483.648)
            Console.WriteLine("Error: el número es demasiado grande para ser una edad.");
        }
        catch (EdadInvalidaException ex) when (ex.Edad < 0)
        {
            // Filtro con "when": este catch solo se ejecuta si la edad es negativa
            Console.WriteLine($"Error: la edad no puede ser negativa. {ex.Message}");
        }
        catch (EdadInvalidaException ex)
        {
            // Aquí llegan las demás edades inválidas (las mayores a 120)
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            // Se ejecuta siempre, haya error o no
            Console.WriteLine("Proceso de validación finalizado.");
        }
    }

    static void ValidarEdad(int edad)
    {
        if (edad < 0 || edad > 120)
        {
            throw new EdadInvalidaException(edad);
        }
    }
}
