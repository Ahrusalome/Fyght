using System.Collections;
using UnityEngine;

public class AlexAttacks : Attack
{
    public override void NormalMD()
    {
        base.NormalMD();
        bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().MDSprites[0];
        nbBulletToFire = 1;
        playerAttack.bounce = 0;
        attackDamage = 60;
    }
    public override void DownDownMD()
    {
        base.DownDownMD();
        System.Random rnd = new System.Random();
        int ind = rnd.Next(1,3);
        if (ind == 1) {
            bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().MDSprites[ind];
            nbBulletToFire = 1;
            playerAttack.bounce =0;
            attackDamage = 70;
        } else {
            nbBulletToFire = 0;
            invocation = true;
        }
    }

    public override void SpecialMD()
    {
        base.SpecialMD();
        bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().MDSprites[0];
        nbBulletToFire = 1;
        playerAttack.bounce = 1;
        attackDamage = 60;
    }

    public override void NormalLD()
    {
        base.NormalLD();
        System.Random rnd = new System.Random();
        int ind = rnd.Next(0,3);
        bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().LDSprites[ind];
        nbBulletToFire = 1;
        playerAttack.bounce =0;
        attackDamage = 70;
    }
    public override void SpecialLD()
    {
        base.SpecialLD();
        invocation = true;
        invocationToSummon = 1;
    }
    public override void DownDownLD()
    {
        base.DownDownLD();
        nbBulletToFire = 1;
        hack = true;
    }
}

