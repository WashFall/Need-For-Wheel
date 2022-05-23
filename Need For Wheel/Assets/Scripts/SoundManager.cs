using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void Awake() // Sets the Audio Service
    {
        ServiceLocator.SetAudioService(new NormalAudioService());
    }

    private void Start() // Starts the background music
    {
        ServiceLocator.GetAudioService().StartLoop("surf");
    }
}
