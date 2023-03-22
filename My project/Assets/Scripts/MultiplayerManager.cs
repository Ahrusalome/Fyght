using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerManager : MonoBehaviour
{
    List<GameObject> players = new List<GameObject>();
    private int index = 0;

    PlayerInputManager manager;
    void Start()
    {
        players.Add(GameManager.instance.currentCharacterP1.mouse);
        players.Add(GameManager.instance.currentCharacterP2.mouse);
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = players[index];
    }
    public void switchPlayer()
    {
        index++;
        
        manager.playerPrefab = players[index];
    }
}
