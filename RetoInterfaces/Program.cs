namespace RetoInterfaces;

class Program
{
    static void Main(string[] args)
    {
        // Para que las tildes se vean bien en la consola de Windows
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Reto de interfaces: reproductor de música ===");
        Console.WriteLine();

        MusicPlayer reproductor = new MusicPlayer();

        // También podemos manejar el objeto a través de la interfaz
        IMediaPlayer control = reproductor;

        Console.WriteLine("1. Intentar reproducir sin cargar nada:");
        control.Play();
        Console.WriteLine();

        Console.WriteLine("2. Primera pista:");
        reproductor.LoadTrack("Cumbia Paisa");
        control.Play();
        control.Pause();
        Console.WriteLine($"Pista actual: {control.GetCurrentTrack()}");
        control.Play();
        control.Stop();
        Console.WriteLine();

        Console.WriteLine("3. Segunda pista:");
        reproductor.LoadTrack("Salsa Suave");
        control.Play();
        Console.WriteLine($"Pista actual: {control.GetCurrentTrack()}");
        control.Stop();
        Console.WriteLine();

        Console.WriteLine("Fin de la demostración.");
    }
}
