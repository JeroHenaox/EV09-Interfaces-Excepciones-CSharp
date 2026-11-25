namespace RetoInterfaces;

// La interfaz solo dice QUÉ debe poder hacer un reproductor,
// pero no dice CÓMO lo hace. Eso lo decide cada clase que la implemente.
public interface IMediaPlayer
{
    void Play();
    void Pause();
    void Stop();
    string GetCurrentTrack();
}
