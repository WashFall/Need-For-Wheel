using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        if(EventSystem.current?.currentSelectedGameObject)
            EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TMP_Text>().color = new Color32(233, 165, 6, 255);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
                Application.Quit();
    }
}
