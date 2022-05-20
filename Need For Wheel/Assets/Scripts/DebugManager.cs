using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DebugManager : MonoBehaviour
{
    public GameObject player;
    public InputManager inputManager;
    public GameObject pauseMenu;
    public GameObject optionsMenu, hscore1, hscore2, hscore3;
    public bool gamePaused;

    public Steering steering;

    [SerializeField]
    private bool gamepadConnected;

    void Start()
    {
        steering = new Steering();
        steering.Ground.Enable();

        gamepadConnected = Gamepad.all.Count < 1 ? false : true;

        if (gamepadConnected)
            steering.Ground.Debug.performed += DebugCommands;
        else
            steering.Ground.Debug.performed += KeyboardDebugOnly;
    }

    private void DebugCommands(InputAction.CallbackContext context)
    {
         if (Keyboard.current.escapeKey.wasPressedThisFrame || Gamepad.current.startButton.wasPressedThisFrame)
        {
            if (!gamePaused)
                PauseGame();
            else if(!optionsMenu.gameObject.activeSelf || !hscore1.gameObject.activeSelf
                || !hscore2.gameObject.activeSelf || !hscore3.gameObject.activeSelf)
                ContinueGame();
        }
    }

    private void KeyboardDebugOnly(InputAction.CallbackContext context)
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!gamePaused)
                PauseGame();
            else if(!optionsMenu.gameObject.activeSelf || !hscore1.gameObject.activeSelf
                || !hscore2.gameObject.activeSelf || !hscore3.gameObject.activeSelf)
                ContinueGame();
        }
    }

    public void ContinueGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }
}
