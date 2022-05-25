using UnityEngine;
using UnityEngine.InputSystem;

// This class was used for debug commands in game, but now it handles pause menu logic
// and checks if there is a controller connected to the machine
public class DebugManager : MonoBehaviour
{
    public bool gamePaused;
    public Steering steering;
    public GameObject player;
    public GameObject pauseMenu;
    public InputManager inputManager;
    public GameObject optionsMenu, hscore1, hscore2, hscore3;

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
         if (Keyboard.current.escapeKey.wasPressedThisFrame || 
            Gamepad.current.startButton.wasPressedThisFrame)
        {
            if (!gamePaused)
                PauseGame();
            else if(!optionsMenu.gameObject.activeSelf || 
                        !hscore1.gameObject.activeSelf ||
                        !hscore2.gameObject.activeSelf || 
                        !hscore3.gameObject.activeSelf)
                            ContinueGame();
        }
    }

    private void KeyboardDebugOnly(InputAction.CallbackContext context)
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!gamePaused)
                PauseGame();
            else if(!optionsMenu.gameObject.activeSelf || 
                        !hscore1.gameObject.activeSelf ||
                        !hscore2.gameObject.activeSelf || 
                        !hscore3.gameObject.activeSelf)
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
