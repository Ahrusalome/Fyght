using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    WaitForSeconds OneSec = new WaitForSeconds(0.5f);
    GameManager gameManager;
    LevelUI levelUI;
    public int winsNeeded = 2;
    int currentTurn = 1;
    bool isPlayable = false;
    public Vector3 spawnPoint;
    public HealthBar[] healthBars;
    public List<GameObject> charactersPlayed = new List<GameObject>();
    public List<Vector3> characterPositions = new List<Vector3>();

    // Singleton LevelManager instance to be used by other scripts
    public static LevelManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameManager = GameManager.instance;
        levelUI = LevelUI.instance;
        StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        yield return CreatePlayers();
        yield return InitTurn();
    }

    IEnumerator CreatePlayers()
    {
        for (int i = 0; i < gameManager.selectedCharacters.Count; i++)
        {
            gameManager.selectedCharacters[i].score = 0;
            GameObject playerToSpawn = Instantiate(gameManager.selectedCharacters[i].prefab, spawnPoint, Quaternion.identity);
            playerToSpawn.layer = i + 6;
            charactersPlayed.Add(playerToSpawn);
            characterPositions.Add(playerToSpawn.transform.position);
            spawnPoint.x += 2f;
            HealthManager healthManager = healthBars[i].GetComponent<HealthManager>();
            healthManager = playerToSpawn.GetComponent<HealthManager>();
            playerToSpawn.GetComponent<HealthManager>().healthBar = healthBars[i];
        }
        ManageControls();
        yield return new WaitForEndOfFrame();
    }
    IEnumerator InitTurn()
    {
        levelUI.TextLine1.gameObject.SetActive(false);
        ResetLife();
        yield return EnableControls();
    }

    private void ResetLife()
    {
        foreach (GameObject characters in charactersPlayed)
        {
            characters.GetComponent<HealthManager>().enabled = true;
            characters.GetComponent<HealthManager>().curHealth = characters.GetComponent<HealthManager>().maxHealth;
            characters.GetComponent<HealthManager>().healthBar.SetHealth(characters.GetComponent<HealthManager>().maxHealth);
            characters.GetComponent<Animator>().SetBool("IsDead", false);
        }
    }
    IEnumerator EnableControls()
    {
        levelUI.TextLine1.gameObject.SetActive(true);
        levelUI.TextLine1.text = "Turn " + currentTurn;
        yield return OneSec;
        yield return OneSec;
        for (int i = 3; i > 0; i--)
        {
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

    public void EndTurnPrep()
    {
        isPlayable = false;
        ManageControls();
        levelUI.TextLine1.gameObject.SetActive(true);
        levelUI.TextLine1.text = "K.O.";
        StartCoroutine("EndTurn");
    }

    IEnumerator EndTurn()
    {
        Character winner = FindTheWinner();
        yield return OneSec;
        levelUI.TextLine1.text = winner.name + " wins";
        currentTurn++;
        bool matchOver = isMatchOver();
        if (!matchOver)
        {
            StartCoroutine("InitTurn");
        }
        else
        {
            gameManager.selectedCharacters.Clear();
            charactersPlayed.Clear();
            characterPositions.Clear();
            SceneManager.LoadScene("Selector");
        }
    }

    public bool isMatchOver()
    {
        bool matchOver = false;
        foreach (Character character in gameManager.selectedCharacters)
        {
            if (character.score >= winsNeeded)
            {
                matchOver = true;
            }
        }
        return matchOver;
    }

    public Character FindTheWinner()
    {
        if (charactersPlayed[0].GetComponent<HealthManager>().curHealth <= 0)
        {
            gameManager.selectedCharacters[1].score++;
            levelUI.AddWinIndicator(1);
            return gameManager.selectedCharacters[1];
        }
        else
        {
            gameManager.selectedCharacters[0].score++;
            levelUI.AddWinIndicator(0);
            return gameManager.selectedCharacters[0];
        }
    }
    public void ManageControls()
    {
        foreach (GameObject character in charactersPlayed)
        {
            character.GetComponent<PlayerInput>().enabled = isPlayable;
            character.GetComponent<PlayerAttack>().enabled = isPlayable;
            character.GetComponent<ComboCharacter>().enabled = isPlayable;
        }
    }

    void Update()
    {
        characterPositions[0] = charactersPlayed[0].transform.position;
        characterPositions[1] = charactersPlayed[1].transform.position;
    }
}
