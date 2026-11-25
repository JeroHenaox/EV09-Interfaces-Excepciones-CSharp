namespace RetoInterfaces;

public class MusicPlayer : IMediaPlayer
{
    // Encapsulamiento: estos campos son privados, solo se cambian con los métodos de la clase
    private string current_track = "";
    private bool is_playing = false;
    private bool is_paused = false;

    // Método adicional que no está en la interfaz
    public void LoadTrack(string track_name)
    {
        if (string.IsNullOrWhiteSpace(track_name))
        {
            Console.WriteLine("No se puede cargar una pista sin nombre.");
            return;
        }

        current_track = track_name;
        is_playing = false;
        is_paused = false;
        Console.WriteLine($"Pista cargada: {current_track}");
    }

    public void Play()
    {
        if (current_track == "")
        {
            Console.WriteLine("No hay ninguna pista cargada. Usa LoadTrack primero.");
            return;
        }

        if (is_playing)
        {
            Console.WriteLine($"La pista '{current_track}' ya se está reproduciendo.");
            return;
        }

        if (is_paused)
        {
            Console.WriteLine($"Reanudando: {current_track}");
        }
        else
        {
            Console.WriteLine($"Reproduciendo: {current_track}");
        }

        is_playing = true;
        is_paused = false;
    }

    public void Pause()
    {
        if (!is_playing)
        {
            Console.WriteLine("No hay nada reproduciéndose para pausar.");
            return;
        }

        is_playing = false;
        is_paused = true;
        Console.WriteLine($"Pausado: {current_track}");
    }

    public void Stop()
    {
        if (current_track == "")
        {
            Console.WriteLine("No hay ninguna pista cargada.");
            return;
        }

        if (!is_playing && !is_paused)
        {
            Console.WriteLine($"La pista '{current_track}' ya está detenida.");
            return;
        }

        is_playing = false;
        is_paused = false;
        Console.WriteLine($"Detenido: {current_track}");
    }

    public string GetCurrentTrack()
    {
        if (current_track == "")
        {
            return "Ninguna pista cargada";
        }

        return current_track;
    }
}
