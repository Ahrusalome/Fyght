using System.Collections;
using UnityEngine;

public class AlexAttacks : Attack
{
    public override void NormalMD()
    {
        base.NormalMD();
        bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().MDSprites[0];
        bulletToFire = 1;
        playerAttack.bounce = 0;
    }
    public override void DownDownMD()
    {
        base.DownDownMD();
        System.Random rnd = new System.Random();
        int ind = rnd.Next(1,3);
        if (ind == 1) {
            bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().MDSprites[ind];
            bulletToFire = 1;
            playerAttack.bounce =0;
        } else {
            bulletToFire = 0;
            invocation = true;
        }
    }

    public override void NormalLD()
    {
        base.NormalLD();
        bulletSprite = playerAttack.GetComponent<BulletSpriteHandler>().LDSprites[0];
    }
}

