using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool downDown = false;
    public float cooldown;
    private Animator animator;
    private Attack attackScript;
    private string playerName;
    void Start()
    {
        playerName = gameObject.name;
        animator = GetComponent<Animator>();
        switch(playerName) {
            case "Alex":
                attackScript = new AlexAttacks();
                break;
            case "Paul":
                attackScript = new PaulAttacks();
                break;
        }
        attackScript.Start(this,animator);
    }
    void OnDownDownAttack() {
        downDown = true;
        StartCoroutine("CoolDown", 0.2f);
    }
    IEnumerator CoolDown(float timeToWait) {
        yield return new WaitForSeconds(timeToWait);
        downDown = false;
    }
    void OnMDAttack() {
        attackScript.OnMDAttack();
    }
    void OnLDAttack() {
        attackScript.OnLDAttack();
    }
}
