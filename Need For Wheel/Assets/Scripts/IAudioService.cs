using UnityEngine;

public interface IAudioService // The interface for the Sound System
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
