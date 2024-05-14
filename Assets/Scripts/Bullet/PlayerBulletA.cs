using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletA : Bullet
{
    public PlayerBulletA()
    {
        type = "PlayerBulletA";
        damage = 3;
        bulletSpeed = 8f;
        knockBack = 2;
        maxbulletSafeTime = 2f;
    }

    public override void Attack(Vector3 mousePos)
    {
        base.Attack(mousePos);
    }
}
