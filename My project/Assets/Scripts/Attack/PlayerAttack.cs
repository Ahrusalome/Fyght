using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;
    public GameObject invocationPrefab;
    public bool downDown = false;
    public float cooldown;
    public int bounce = 0;
    private Animator animator;
    private Attack attackScript;
    private string playerName;
    void Start()
    {
        playerName = gameObject.name;
        animator = GetComponent<Animator>();
        switch(playerName) {
            case "Alex(Clone)":
                attackScript = new AlexAttacks();
                break;
            case "Paul(Clone)":
                attackScript = new PaulAttacks();
                break;
        }
        attackScript.Start(this,animator);
    }
    void OnDownDownAttack() {
        downDown = true;
        StartCoroutine("CoolDown", 0.1f);
    }
    IEnumerator CoolDown(float timeToWait) {
        yield return new WaitForSeconds(timeToWait);
        downDown = false;
    }
    void OnMDAttack() {
        attackScript.OnMDAttack();
        if (attackScript.bulletToFire > 0) {
            for(int i = 0; i< attackScript.bulletToFire; i++) {
                InstantiateProjectile(attackScript.bulletDirection[i], firePoints[i]);
            }
        }
        if (attackScript.invocation) {
            Invoke();
        }
    }
    void OnLDAttack() {
        attackScript.OnLDAttack();
        if (attackScript.bulletToFire > 0) {
            for(int i = 0; i< attackScript.bulletToFire; i++) {
                InstantiateProjectile(attackScript.bulletDirection[i], firePoints[i]);
            }
        }
        if (attackScript.invocation) {
            Invoke();
        }
    }
    void InstantiateProjectile(Vector2 direction, Transform firePoint) {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<SpriteRenderer>().sprite = attackScript.bulletSprite;
        bullet.layer = gameObject.layer;
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.bounce = bounce;
        bulletScript.Launch(direction);
        bulletScript.damage = attackScript.attackDamage;
        Debug.Log(attackScript.attackDamage);
        bullet.GetComponent<Stats>().attack = GetComponent<Stats>().attack;
    }
    void Invoke() {
        GameObject invocationGO = Instantiate(invocationPrefab, firePoints[0].position, Quaternion.identity);
        invocationGO.layer = this.gameObject.layer;
        attackScript.invocation = false;
    }
}
