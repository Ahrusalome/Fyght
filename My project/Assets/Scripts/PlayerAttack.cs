using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float cooldown;
    private Animator animator;
    private int meleeHit = 0;
    private float lastMeleeHit;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnMDAttack() {
        animator.SetTrigger("MDAttacking");
    }
    void OnLDAttack() {
        animator.SetTrigger("LDAttacking");
    }
}
