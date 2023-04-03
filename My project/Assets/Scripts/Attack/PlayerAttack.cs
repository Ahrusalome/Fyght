using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
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
        if (attackScript.bulletFiredOnMD && !downDown) {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<SpriteRenderer>().sprite = attackScript.bulletSprite;
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.SetDirection(attackScript.bulletDirection);
        }
    }
    void OnLDAttack() {
        attackScript.OnLDAttack();
    }
}
