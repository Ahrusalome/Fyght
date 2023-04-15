using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadSceneAsync("Selector");
        Debug.Log("Loading game succeeded");
    }

    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quitting game succeeded");
    }
}