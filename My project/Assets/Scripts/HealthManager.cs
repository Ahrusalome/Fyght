using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    private int curHealth = 0;
    public HealthBar healthBar;
    void Start()
    {
        curHealth = maxHealth;
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
        // set anim die + launch 2nd round or end
    }
}
