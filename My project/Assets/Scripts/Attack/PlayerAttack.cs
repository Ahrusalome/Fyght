using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;
    public GameObject[] invocationPrefab;
    public bool downDown = false;
    public float cooldown;
    public int bounce = 0;
    private Animator animator;
    private Attack attackScript;
    private string playerName;
    void Start()
    {
        //Check the player's name to know whose attacks it'll have to launch
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

    //If the player do 2 times the down input and an attack input soon after, will change the behaviour of the attacks
    void OnDownDownAttack() {
        downDown = true;
        StartCoroutine("CoolDown", 0.1f);
    }

    //Reset the "down down" change if the player don't attack soon enough
    IEnumerator CoolDown(float timeToWait) {
        yield return new WaitForSeconds(timeToWait);
        downDown = false;
    }

    //Launch the light ranged attack
    void OnMDAttack() {
        attackScript.OnMDAttack();
        // if the player's light ranged attack has to instanciate a projectile, it will
        if (attackScript.nbBulletToFire > 0) {
            for(int i = 0; i< attackScript.nbBulletToFire; i++) {
                InstantiateProjectile(attackScript.bulletDirection[i], firePoints[i]);
            }
        }
        // if the player's light ranged attack has to instanciate an invocation, it will
        if (attackScript.invocation) {
            Invoke(attackScript.invocationToSummon);
        }
    }

    //Launch the heavy ranged attack
    void OnLDAttack() {
        attackScript.OnLDAttack();
        if (attackScript.nbBulletToFire > 0) {
            for(int i = 0; i< attackScript.nbBulletToFire; i++) {
                InstantiateProjectile(attackScript.bulletDirection[i], firePoints[i]);
            }
        }
        if (attackScript.invocation) {
            Invoke(attackScript.invocationToSummon);
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
    void Invoke(int invocationIndex) {
        GameObject invocationGO = Instantiate(invocationPrefab[invocationIndex], firePoints[0].position, Quaternion.identity);
        invocationGO.layer = this.gameObject.layer;
        attackScript.invocation = false;
        attackScript.invocationToSummon = 0;
    }
}
