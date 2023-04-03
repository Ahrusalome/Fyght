using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack
{
    public PlayerAttack playerAttack;
    protected Animator animator;
    public Sprite bulletSprite;
    public float cooldown;
    public bool bulletFiredOnMD = false;
    public Vector2 bulletDirection;
    public float VerticalBulletDirection;

    public void Start(PlayerAttack _playerAttack, Animator _animator) {
        playerAttack = _playerAttack;
        animator = _animator;
    }
    public void OnMDAttack() {
        bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().MDSprites[0];
        bulletDirection = playerAttack.GetComponent<Transform>().right;
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
        bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().LDSprites[0];
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
