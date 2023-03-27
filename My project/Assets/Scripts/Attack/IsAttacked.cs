using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAttacked : MonoBehaviour
{
    public LayerMask mask;
    private Animator animator;
    private HealthManager health;
    private int combo;

    void Start() {
        gameObject.layer = gameObject.transform.parent.gameObject.layer;
        gameObject.transform.parent.gameObject.transform.Find("hitbox").gameObject.layer = gameObject.transform.parent.gameObject.layer;
        if (gameObject.layer == 6) {
            mask = LayerMask.GetMask("Player2");
        } else {
            mask = LayerMask.GetMask("Player1");
        }
        animator = GetComponentInParent<Animator>();
        health = this.GetComponentInParent<HealthManager>();
    }
    void Update() {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("IsAttacked")) {
            combo = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(((1 << other.gameObject.layer) & mask) != 0 && other.name == "hitbox") {
            Debug.Log("oui");
            health.DamagePlayer(DamageToTake(other));
            animator.SetTrigger("IsAttacked");
            combo++;
        }
    }
    float DamageToTake(Collider2D other) {
        float baseDamage = 0;
        AnimatorStateInfo ennemiAnimatorState = other.gameObject.GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0);
        if(ennemiAnimatorState.IsName("SDAttack 1")) {
            baseDamage = 50;
        }
        if(ennemiAnimatorState.IsName("SDAttack 2")) {
            baseDamage = 55;
        }
        if(ennemiAnimatorState.IsName("SDAttack 3") || ennemiAnimatorState.IsName("MDAttack")) {
            baseDamage = 60;
        }
        if(ennemiAnimatorState.IsName("LDAttack")) {
            baseDamage = 70;
        }
        float damage = ((baseDamage * (1+other.GetComponentInParent<Stats>().attack/10f) ) * (1 + combo/10f)) / (1+GetComponentInParent<Stats>().defense/10f);
        return damage;
    }
}
