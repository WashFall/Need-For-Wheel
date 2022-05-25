using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NormalAudioService : IAudioService
{
    private int sourceCount = 20;
    private List<AudioClip> clips;
    private string audioPath = "SFX/";
    private List<AudioSource> sources;
    private Dictionary<string, AudioClip> audioKeys;

    public void UpdateSound() // Changes the volume for every Audio Source
    {
        foreach(AudioSource source in sources)
        {
            source.volume = PlayerPrefs.GetFloat("volume");
        }
    }

    public void BuildAudio() // Creates all the Audio Sources and adds all Audio Clips to array
    {
        sources = new List<AudioSource>();
        for(int i = 0; i < sourceCount; i++)
        {
            AudioSource source = new GameObject().AddComponent<AudioSource>();
            sources.Add(source);
            source.volume = PlayerPrefs.GetFloat("volume");
        }

        clips = new List<AudioClip>();
        clips.AddRange(Resources.LoadAll<AudioClip>(audioPath));

        audioKeys = new Dictionary<string, AudioClip>();
        foreach(AudioClip clip in clips)
        {
            audioKeys.Add(clip.name, clip);
        }
    }

    public void DestroyAudio() // Destroys all Audio Sources
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

    // Makes sure to use a source that is not playing any sounds at the moment
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
