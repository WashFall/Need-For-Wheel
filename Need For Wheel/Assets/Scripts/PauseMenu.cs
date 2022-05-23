using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    private GameObject menuButton;
    private GameObject optionsButton;
    private GameObject continueButton;
    private InputManager inputManager;
    private DebugManager debugManager;

    private void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
        debugManager = FindObjectOfType<DebugManager>();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        debugManager.steering.Disable();
        inputManager.steering.Disable();
    }

    private void OnEnable()
    {
        continueButton = transform.GetChild(2).gameObject;
        optionsButton = transform.GetChild(3).gameObject;
        menuButton = transform.GetChild(4).gameObject;

        EventSystem.current.SetSelectedGameObject(continueButton);
        menuButton.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
        optionsButton.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
        continueButton.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color32(233, 165, 6, 255);
    }
}
