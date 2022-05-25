using UnityEngine;
using UnityEngine.SceneManagement;

public class HScoreMenu : MonoBehaviour
{
    public GameObject pointsCanvas;
    public InputManager inputManager;
    public DebugManager debugManager;

    // The functions for the buttons on the High Score screen
    public void Restart()
    {
        BoostSystem.boost = 0;
        inputManager.steering.Disable();
        debugManager.steering.Disable();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        BoostSystem.boost = 0;
        SceneManager.LoadScene(0);
        inputManager.steering.Disable();
        debugManager.steering.Disable();
    }

    private void OnEnable()
    {
        pointsCanvas.SetActive(false);
    }
}
