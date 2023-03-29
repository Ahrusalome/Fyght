using UnityEngine;
using UnityEngine.SceneManagement;

// This script is used to load scenes and quit the game
public class SceneManagement : MonoBehaviour
{
   // Load a scene by name
   public void LoadScene(string SceneToLoad) {
      SceneManager.LoadSceneAsync(SceneToLoad);
   }
   
   // Quit the game
   public void QuitGame() {
      Application.Quit();
   }
}
