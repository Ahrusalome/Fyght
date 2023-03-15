using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    WaitForSeconds OneSec = new WaitForSeconds(1);
    GameManager gameManager;
    LevelUI levelUI;
    public int winsNeeded = 2;
    int currentTurn = 1;
    bool isPlayable;
    public static LevelManager instance;
    public Vector3 spawnPoint;
    public HealthBar[] healthBars;
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        gameManager = GameManager.instance;
        levelUI = LevelUI.instance;
        StartCoroutine("StartGame");
    }
    void Update()
    {
        
    }
    IEnumerator StartGame() {
        yield return CreatePlayers();
        yield return InitTurn();
    }
    IEnumerator CreatePlayers(){
        for (int i= 0; i<gameManager.selectedCharacters.Length; i++) {
            GameObject playerToSpawn = Instantiate(gameManager.selectedCharacters[i].prefab, spawnPoint, Quaternion.identity);
            spawnPoint.x += 2f;
            Stats stats = playerToSpawn.GetComponent<Stats>();
            stats.maxHealth = gameManager.selectedCharacters[i].maxHealth;
            stats.curHealth = gameManager.selectedCharacters[i].maxHealth;
            HealthManager healthManager = healthBars[i].GetComponent<HealthManager>() ;
            healthManager = playerToSpawn.GetComponent<HealthManager>();
            playerToSpawn.GetComponent<HealthManager>().healthBar = gameManager.selectedCharacters[i].healthBar;
        }
        yield return new WaitForEndOfFrame();
    }
    IEnumerator InitTurn() {
        levelUI.TextLine1.gameObject.SetActive(false);
        levelUI.TextLine2.gameObject.SetActive(false);
        yield return EnableControls();
    }

    IEnumerator EnableControls() {
        levelUI.TextLine1.gameObject.SetActive(true);
        levelUI.TextLine1.text = "Turn "+currentTurn;
        yield return OneSec;
        yield return OneSec;
        for (int i = 3; i > 0; i--) {
            levelUI.TextLine1.text = i.ToString();
            yield return OneSec;
        }
        levelUI.TextLine1.text = "FIGHT!";
        yield return OneSec;
        isPlayable = true;
        ManageControls();
        yield return OneSec;
        levelUI.TextLine1.gameObject.SetActive(false);
    }

    public void EndTurnPrep() {
        levelUI.TextLine1.gameObject.SetActive(true);
        levelUI.TextLine1.text = "K.O.";
        isPlayable = false;
        ManageControls();
        StartCoroutine("EndTurn");
    }

    IEnumerator EndTurn() {
        Character winner = FindTheWinner();
        yield return OneSec;
        levelUI.TextLine1.text = winner.name + " wins";
        currentTurn++;
        bool matchOver = isMatchOver();
        if (!matchOver) {
            StartCoroutine("InitTurn");
        } else {
            SceneManager.LoadScene("SelectionScene");
        }
    }

    public bool isMatchOver() {
        bool matchOver = false;
        foreach (Character character in gameManager.selectedCharacters) {
            if (character.score >= winsNeeded) {
                matchOver = true;
            }
        }
        return matchOver;
    }

    public Character FindTheWinner() {
        if (gameManager.selectedCharacters[0].curHealth == 0) {
            gameManager.selectedCharacters[1].score++;
            levelUI.AddWinIndicator(1);
            return gameManager.selectedCharacters[1];
        } else {
            gameManager.selectedCharacters[0].score++;
            levelUI.AddWinIndicator(0);
            return gameManager.selectedCharacters[0];
        }
    }
    public void ManageControls() {
        foreach (Character character in gameManager.selectedCharacters) {
            character.prefab.GetComponent<PlayerAttack>().enabled = isPlayable;
            character.prefab.GetComponent<ComboCharacter>().enabled = isPlayable;
        }
    }
}
