using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NormalAudioService : IAudioService
{
    private int sourceCount = 20;
    private List<AudioClip> clips;
    private List<AudioSource> sources;
    private string audioPath = "SFX/";
    private Dictionary<string, AudioClip> audioKeys;

    public void BuildAudio()
    {
        sources = new List<AudioSource>();
        for(int i = 0; i < sourceCount; i++)
        {
            AudioSource source = new GameObject().AddComponent<AudioSource>();
            sources.Add(source);
        }

        clips = new List<AudioClip>();
        clips.AddRange(Resources.LoadAll<AudioClip>(audioPath));

        audioKeys = new Dictionary<string, AudioClip>();
        foreach(AudioClip clip in clips)
        {
            audioKeys.Add(clip.name, clip);
        }
    }

    public void DestroyAudio()
    {
        for(int i = 0; i < sourceCount; i++)
        {
            MonoBehaviour.Destroy(sources[i]);
        }
    }

    public void PlayOnce(AudioClip audio)
    {
        GetAvailableSource().PlayOneShot(audio);
    }

    public void PlayOnce(string audioName)
    {
        GetAvailableSource().PlayOneShot(audioKeys[audioName]);
    }

    public void StartLoop(AudioClip audio)
    {
        AudioSource audioSource = GetAvailableSource();
        audioSource.loop = true;
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void StartLoop(string audioName)
    {
        AudioSource audioSource = GetAvailableSource();
        audioSource.loop = true;
        audioSource.clip = audioKeys[audioName];
        audioSource.Play();
    }

    public void StopLoop(AudioClip audio)
    {
        foreach(AudioSource source in sources)
        {
            if(source.clip == audio)
            {
                source.Stop();
                source.clip = null;
                source.loop = false;
            }
        }
    }

    public void StopLoop(string audioName)
    {
        foreach(AudioSource source in sources)
        {
            if(source.clip.name == audioName)
            {
                source.Stop();
                source.clip = null;
                source.loop = false;
            }
        }
    }

    private AudioSource GetAvailableSource()
    {
        foreach (AudioSource source in sources)
        {
            if (source.isPlaying == false)
            {
                return source;
            }
        }

        return sources.Where(x => x.loop == false).ToList()[0];
    }
}
