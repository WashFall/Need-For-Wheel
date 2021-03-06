using UnityEngine;

// An audio service that instead of playing sounds, writes their name in the console
// This is used for testing the system without having the sounds
public class DebugAudioService : IAudioService
{
    public void UpdateSound()
    {
        Debug.Log("Volume updated");
    }

    public void BuildAudio()
    {
        Debug.Log("Audio is Built");
    }

    public void DestroyAudio()
    {
        Debug.Log("Audio is Destroyed");
    }

    public void PlayOnce(AudioClip audio)
    {
        Debug.Log("Clip:Playing " + audio.name);
    }

    public void PlayOnce(string audioName)
    {
        Debug.Log("String:Playing " + audioName);
    }

    public void StartLoop(AudioClip audio)
    {
        Debug.Log("Clip:Looping " + audio.name);
    }

    public void StartLoop(string audioName)
    {
        Debug.Log("String:Looping " + audioName);
    }

    public void StopLoop(AudioClip audio)
    {
        Debug.Log(string.Format("Clip:Stopping {0}-Loop", audio.name));
    }

    public void StopLoop(string audioName)
    {
        Debug.Log($"String:Stopping {audioName}-Loop");
    }
}
