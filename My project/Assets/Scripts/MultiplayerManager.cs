using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerManager : MonoBehaviour
{
    List<GameObject> fighters = new List<GameObject>();
    private int index = 0;
    
    PlayerInputManager manager;
    void Start()
    {
        fighters.Add(GameManager.instance.currentCharacterP1.prefab);
        fighters.Add(GameManager.instance.currentCharacterP2.prefab);
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = fighters[index];
    }
    public void switchPlayer() {
        index++;
        this.gameObject.transform.position += new Vector3(0f, -2f, 0f);
        manager.playerPrefab = fighters[index];
    }
}
