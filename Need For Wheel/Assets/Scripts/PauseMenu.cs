using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private InputManager inputManager;
    private DebugManager debugManager;

    private void Start()
    {
        debugManager = FindObjectOfType<DebugManager>();
        inputManager = FindObjectOfType<InputManager>();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        debugManager.steering.Disable();
        inputManager.steering.Disable();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
