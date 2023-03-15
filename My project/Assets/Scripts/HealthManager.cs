using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public HealthBar healthBar;
    private Animator animator;
    private int curHealth = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
        curHealth = GetComponent<Stats>().maxHealth;
    }

    void Update() {
        
    }
    public void DamagePlayer(int damage) {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
        if (curHealth <= 0) {
            Die();
        }
    }
    public void Die() {
        Debug.Log(this.name + " is dead");
        animator.SetBool("IsDead", true);
        LevelManager.instance.EndTurnPrep();
    }
    public void BackToLife() {
        curHealth = maxHealth;
    }
}
