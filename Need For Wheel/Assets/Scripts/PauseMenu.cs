using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    private InputManager inputManager;
    private DebugManager debugManager;
    private GameObject continueButton;
    private GameObject optionsButton;
    private GameObject menuButton;

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

    private void OnEnable()
    {
        continueButton = transform.GetChild(2).gameObject;
        optionsButton = transform.GetChild(3).gameObject;
        menuButton = transform.GetChild(4).gameObject;
        EventSystem.current.SetSelectedGameObject(continueButton);
        continueButton.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color32(233, 165, 6, 255);
        optionsButton.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
        menuButton.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;
    }
}
