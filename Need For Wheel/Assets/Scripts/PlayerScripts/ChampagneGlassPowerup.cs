using UnityEngine;

public class ChampagneGlassPowerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // Calls the speed up function on "pick up"
    {
        if(other.tag == "Player")
        {
            other.GetComponent<DrivingControls>().SpeedPowerUp();
            Destroy(gameObject);
        }
    }
}
