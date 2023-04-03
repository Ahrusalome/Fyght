using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MainMenu
{
    public bool isPausedMenu = false;
    public GameObject pauseMenuUI;

    void Start() {
        pauseMenuUI.SetActive(isPausedMenu);    
    }

    void OnEscape() {  
        Debug.Log("Escaping game succeeded");
        if (!isPausedMenu) {
            PauseGame();
        } else {
            ResumeGame();
        }
    }

    public void PauseGame() {
        pauseMenuUI.SetActive(true);    
        Time.timeScale = 0f;
        isPausedMenu = !isPausedMenu;
        Debug.Log("Pausing game succeeded");
    }

    public void ResumeGame() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPausedMenu = !isPausedMenu;
        Debug.Log("Resuming game succeeded");
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Menu"); 
        Debug.Log("Loading menu succeeded");
    }
}