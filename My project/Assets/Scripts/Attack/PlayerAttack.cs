using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool downDown = false;
    public float cooldown;
    private Animator animator;
    private int meleeHit = 0;
    private float lastMeleeHit;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnDownDownAttack() {
        downDown = true;
        StartCoroutine("CoolDown");
    }
    IEnumerator CoolDown() {
        yield return new WaitForSeconds(0.1f);
        downDown = false;
    }
    void OnMDAttack() {
        if (this.GetComponent<PlayerController>().frontSpecialAttack) {
            animator.SetTrigger("SpecialMD");
        } else if (downDown) {
            animator.SetTrigger("DownDownMD");
        } else{
            animator.SetTrigger("MDAttacking");
        }
    }
    void OnLDAttack() {
                if (this.GetComponent<PlayerController>().frontSpecialAttack) {
            animator.SetTrigger("SpecialLD");
        } else if (downDown) {
            animator.SetTrigger("DownDownLD");
        } else{
            animator.SetTrigger("LDAttacking");
        }
    }
}
