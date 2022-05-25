using UnityEngine;

public class ApplePowerup : MonoBehaviour
{
    public PointSystem pointSystem;

    private void OnTriggerEnter(Collider other) // Calls the point multiplier on "pick up"
    {
        if (other.tag == "Player")
        {
            pointSystem.Multiplier();
            Destroy(gameObject);
        }
    }
}
