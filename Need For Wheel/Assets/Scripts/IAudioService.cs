using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioService
{
    public void UpdateSound();

    public void BuildAudio();
    public void DestroyAudio();

    public void PlayOnce(AudioClip audio);
    public void PlayOnce(string audioName);

    public void StartLoop(AudioClip audio);
    public void StartLoop(string audioName);

    public void StopLoop(AudioClip audio);
    public void StopLoop(string audioName);
}
