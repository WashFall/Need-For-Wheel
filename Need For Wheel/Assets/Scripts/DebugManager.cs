using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DebugManager : MonoBehaviour
{
    public GameObject player;
    public InputManager inputManager;

    private Steering steering;

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
        if (Keyboard.current.rKey.wasPressedThisFrame || Gamepad.current.buttonWest.wasPressedThisFrame)
        {
            steering.Disable();
            inputManager.steering.Disable();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame || Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            QuitGame();
        }
        else if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            var pc = player.GetComponent<PlayerController>();
            pc.increaseGravity = pc.increaseGravity ? false : true;
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
            inputManager.steering.Disable();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            QuitGame();
        }
        else if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            player.GetComponent<PlayerController>().GravitySwitch();
        }
        else if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            PlayerController.State = PlayerState.Flying;
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
