using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.SetAudioService(new NormalAudioService());
    }

    private void Start()
    {
        ServiceLocator.GetAudioService().StartLoop("surf");
    }
}
