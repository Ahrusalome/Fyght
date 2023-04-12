using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : SceneManagement
{
    public bool isPausedMenu = true;
    private GameObject pauseMenuUI;

    void Start()
    {
        pauseMenuUI = GameObject.Find("CanvasPause");
        buttonOnFocus = GameObject.Find("ResumeButton").GetComponent<Button>();
        buttonOnFocus.Select();
        pauseMenuUI.SetActive(false);
    }

    void OnEscape()
    {
        Debug.Log("Escaping game succeeded");
        if (isPausedMenu)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPausedMenu = !isPausedMenu;
        Debug.Log("Pausing game succeeded");
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPausedMenu = !isPausedMenu;
        Debug.Log("Resuming game succeeded");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        LoadScene("Menu");
        Debug.Log("Loading menu succeeded");
    }
}