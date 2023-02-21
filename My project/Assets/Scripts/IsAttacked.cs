using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAttacked : MonoBehaviour
{
    public LayerMask mask;
    private HealthManager health;

    void Start() {
        health = this.GetComponentInParent<HealthManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(((1 << other.gameObject.layer) & mask) != 0 && other.name == "hitbox") {
            health.DamagePlayer(10);
        }
    }
    
}
