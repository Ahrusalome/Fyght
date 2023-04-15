using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack
{
    public PlayerAttack playerAttack;
    public Vector3[] bulletDirection = new Vector3[] {new Vector3(0,0,0)};
    protected Animator animator;
    public Sprite bulletSprite;
    public int invocationToSummon = 0;
    public float cooldown;
    public int nbBulletToFire = 0;
    public bool invocation = false;
    public int attackDamage;
    public int recuperationTime = 10;
    public void Start(PlayerAttack _playerAttack, Animator _animator) {
        playerAttack = _playerAttack;
        animator = _animator;
    }
    public void OnMDAttack() {
        if (playerAttack.GetComponent<PlayerController>().frontSpecialAttack) {
            SpecialMD();
        } else if (playerAttack.downDown) {
            DownDownMD();
        } else{
            NormalMD();
        }
    }
    public virtual void SpecialMD() {
        animator.SetTrigger("SpecialMD");
    }
    public virtual void DownDownMD() {
        animator.SetTrigger("DownDownMD");
    }
    public virtual void NormalMD() {
        animator.SetTrigger("MDAttacking");
    }
    public void OnLDAttack() {
        if (playerAttack.GetComponent<PlayerController>().frontSpecialAttack) {
            SpecialLD();
        } else if (playerAttack.downDown) {
            DownDownLD();
        } else{
            NormalLD();
        }
    }
    public virtual void SpecialLD() {
        animator.SetTrigger("SpecialLD");
    }
    public virtual void DownDownLD() {
        animator.SetTrigger("DownDownLD");
    }
    public virtual void NormalLD() {
        animator.SetTrigger("LDAttacking");
    }
}
