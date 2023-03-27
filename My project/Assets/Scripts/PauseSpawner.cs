using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseSpawner : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject menuPrefab;
    void OnEscape() {
        Debug.Log("Pausing game succeeded");
        Instantiate(menuPrefab, spawnPosition.position, spawnPosition.rotation);
    }
}