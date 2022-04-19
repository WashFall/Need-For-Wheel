using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DebugManager : MonoBehaviour
{
    public InputManager inputManager;

    private PlayerInput playerInput;
    private Steering steering;
    [SerializeField]
    private bool gamepadConnected;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

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
            inputManager.steering.Disable();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame || Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

    }

    private void KeyboardDebugOnly(InputAction.CallbackContext context)
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            inputManager.steering.Disable();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
