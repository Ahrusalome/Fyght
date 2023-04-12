using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public HealthManager playerHealth;
    
    private void Start()
    {
        healthBar = GetComponent<Slider>();
        if (this.gameObject.name == "HealthBarP1") {
            playerHealth = GameManager.instance.selectedCharacters[0].prefab.GetComponent<HealthManager>();
        } else {
            playerHealth = GameManager.instance.selectedCharacters[1].prefab.GetComponent<HealthManager>();
        }
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
    }

    public void SetHealth(float hp) {
        healthBar.value = hp;
    }
}
