using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    void Start()
    {
        Instantiate(GameManager.instance.currentCharacterP1.prefab, transform.position, Quaternion.identity);
        Instantiate(GameManager.instance.currentCharacterP2.prefab, transform.position, Quaternion.identity);
    }
}
