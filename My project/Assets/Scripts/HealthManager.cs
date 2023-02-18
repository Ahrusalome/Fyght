using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int curHealth = 0;
    public HealthBar healthBar;
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) {
            DamagePlayer(10);
            Debug.Log(curHealth);
        }
    }
    public void DamagePlayer(int damage) {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }
}
