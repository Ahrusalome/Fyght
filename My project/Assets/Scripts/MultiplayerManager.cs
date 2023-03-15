using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiplayerManager : MonoBehaviour
{
    List<GameObject> fighters = new List<GameObject>();
    private int index = 0;

    public List<Vector3> playersPositions = new List<Vector3>();

    PlayerInputManager manager;
    void Start()
    {
        fighters.Add(GameManager.instance.currentCharacterP1.prefab);
        fighters.Add(GameManager.instance.currentCharacterP2.prefab);
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = fighters[index];
    }
    public void switchPlayer()
    {
        index++;
        
        manager.playerPrefab = fighters[index];
    }

    void Update()
    {
        if (this.gameObject.transform.childCount == 3)
        {
            if (playersPositions.Count == 0)
            {
                playersPositions.Add(this.gameObject.transform.GetChild(1).position);
                playersPositions.Add(this.gameObject.transform.GetChild(2).position);
            }
            playersPositions[0] = this.gameObject.transform.GetChild(1).position;
            playersPositions[1] = this.gameObject.transform.GetChild(2).position;
        }
    }



}
