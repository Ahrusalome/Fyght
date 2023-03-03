using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerManager : MonoBehaviour
{
    [SerializeField] List<GameObject> fighters = new List<GameObject>();
    private int index = 0;
    
    PlayerInputManager manager;
    void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = fighters[index];
    }
    public void switchPlayer() {
        index++;
        manager.playerPrefab = fighters[index];
    }
}
