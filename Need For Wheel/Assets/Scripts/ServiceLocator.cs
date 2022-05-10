using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
