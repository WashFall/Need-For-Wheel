// An access point to the Audio Service
// This is used to enable a switch of Audio Services without having to change all calls
public static class ServiceLocator
{
    public static IAudioService sound;

    public static IAudioService GetAudioService()
    {
        return sound;
    }

    public static void SetAudioService(IAudioService newService)
    {
        if (sound != null)
        {
            sound.DestroyAudio();
        }

        sound = newService;
        sound.BuildAudio();
    }
}
