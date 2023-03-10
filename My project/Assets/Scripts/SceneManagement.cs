using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
   public void LoadScene(string SceneToLoad) {
      SceneManager.LoadSceneAsync(SceneToLoad);
   }
}
