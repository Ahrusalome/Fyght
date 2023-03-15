using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Character[] characters;
    public Character[] selectedCharacters;
    public Character currentCharacterP1;
    public Character currentCharacterP2;
    
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SetCharacterP1(Character character) {
        currentCharacterP1 = character;
    }
    public void SetCharacterP2(Character character) {
        currentCharacterP2 = character;
    }
}
