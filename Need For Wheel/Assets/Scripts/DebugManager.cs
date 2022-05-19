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

    public Steering steering;

    [SerializeField]
    private bool gamepadConnected;
    private bool gamePaused;

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
        if (Keyboard.current.rKey.wasPressedThisFrame || Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            steering.Disable();
            inputManager.steering.Disable();
            BoostSystem.boost = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!gamePaused)
                PauseGame();
            else
                ContinueGame();
        }
        else if (Keyboard.current.gKey.wasPressedThisFrame || Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            inputManager.invertControls = inputManager.invertControls ? false : true;
        }
        else if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            PlayerController.State = PlayerState.Flying;
        }
    }

    private void KeyboardDebugOnly(InputAction.CallbackContext context)
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            steering.Disable();
            BoostSystem.boost = 0;
            inputManager.steering.Disable();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!gamePaused)
                PauseGame();
            else
                ContinueGame();
        }
        else if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            inputManager.invertControls = inputManager.invertControls ? false : true;
        }
        else if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            PlayerController.State = PlayerState.Flying;
        }
    }

    private void ContinueGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
        inputManager.pauseMenu.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
        inputManager.pauseMenu?.gameObject.SetActive(true);
    }
}
