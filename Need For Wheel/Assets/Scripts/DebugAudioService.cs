using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAudioService : IAudioService
{
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
