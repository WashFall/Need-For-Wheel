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


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        steering = new Steering();
        steering.Ground.Enable();

        steering.Ground.Debug.performed += DebugCommands;
    }
    private void DebugCommands(InputAction.CallbackContext context)
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
