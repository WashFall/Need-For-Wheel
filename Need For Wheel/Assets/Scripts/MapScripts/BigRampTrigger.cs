using UnityEngine;

public class BigRampTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            ServiceLocator.sound.PlayOnce("yahoo");
            PlayerController.State = PlayerState.Flying;
        }
    }
}
