using UnityEngine;
using System;

public class PaulAttacks : Attack
{
    public bool OnJuice = false;
    public bool Drunk = false;
    private Stats stats;
    //Paul's normal light distance attack : fire a random card, in regards of what he'll fire, he'll inflict different damage
    public override void NormalMD()
    {
        base.NormalMD();
        System.Random rnd = new System.Random();
        int ind = rnd.Next(0,3);
        bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().MDSprites[ind];
        nbBulletToFire = 1;
        playerAttack.bounce =0;
        switch(ind) {
            case 0:
            attackDamage = 50;
            break;
            case 1:
            attackDamage = 60;
            break;
            case 2:
            attackDamage = 70;
            break;
        }
    }
    // Paul's light distance attack when combo with the front directional input : he'll fire 3 cards
    public override void SpecialMD()
    {
        base.SpecialMD();
        bulletDirection = new Vector3[] {new Vector3(0,0,0), new Vector3(0,0.3f,0), new Vector3(0,0.6f,0)};
        System.Random rnd = new System.Random();
        int ind = rnd.Next(1,3);
        bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().MDSprites[ind];
        nbBulletToFire = 3;
        playerAttack.bounce =0;
        attackDamage = 60;
    }

    //Paul's light distance attack when combo with double down input : he'll change state, to a quicker but less offensive self
    public override void DownDownMD() {
        stats = playerAttack.GetComponent<Stats>();
        base.DownDownMD();
        if (OnJuice == true) {
            stats.speed = 12;
            stats.attack = 14;
            stats.defense = 15;
            stats.dexterity = 10;
            OnJuice = false;
        } else {
            stats.speed = 14;
            stats.attack = 11;
            stats.defense = 13;
            stats.dexterity = 13;
            OnJuice = true;
        }
        Drunk = false;
    }

    //Paul's heavy distance attack : he'll fire a rubik's cube
    public override void NormalLD()
    {
        base.NormalLD();
        bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().LDSprites[0];
        nbBulletToFire = 1;
        playerAttack.bounce =0;
        attackDamage = 70;
    }

    //Paul's heavy distance attack with front input : the rubik's cube will bounce against a wall
    public override void SpecialLD()
    {
        base.SpecialLD();
        bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().LDSprites[0];
        nbBulletToFire = 1;
        playerAttack.bounce = 1;
        attackDamage = 75;
    }

    //Paul's heavy distance attack when combo with double down input : he'll change state, to a slower but more offensive self
    public override void DownDownLD()
    {
        base.DownDownLD();
        if (Drunk == true) {
            stats.speed = 12;
            stats.attack = 14;
            stats.defense = 15;
            stats.dexterity = 10;
            Drunk = false;
        } else {
            stats.speed = 10;
            stats.attack = 18;
            stats.defense = 15;
            stats.dexterity = 8;
            Drunk = true;
        }
        OnJuice = false;
    }
}

