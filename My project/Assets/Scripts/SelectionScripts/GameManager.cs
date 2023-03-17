using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Character[] characters;
    public List<Character> selectedCharacters= new List<Character>();
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    
    }

    public void SetCharacter(Character character) {
        selectedCharacters.Add(character);
    }
}
