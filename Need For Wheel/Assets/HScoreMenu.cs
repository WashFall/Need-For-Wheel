using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HScoreMenu : MonoBehaviour
{
    public InputManager inputManager;
    public DebugManager debugManager;
    public GameObject pointsCanvas;

    public void Restart()
    {
        inputManager.steering.Disable();
        debugManager.steering.Disable();
        BoostSystem.boost = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        BoostSystem.boost = 0;
        inputManager.steering.Disable();
        debugManager.steering.Disable();
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        pointsCanvas.SetActive(false);
    }
}
