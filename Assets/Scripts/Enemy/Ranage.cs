using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranage : Enemy
{
    float fireTime = 0f;
    float maxFireTime = 3f;
    public Ranage()
    {
        type = "Ranage";
        hp = 8;
        damage = 3;
        moveSpeed = 50f;
        maxHitTime = 0.2f;
        expPoint = 2;

    }

    private void Update()
    {
        MoveForPlayer();
        RanageAttack();
    }

    private void RanageAttack()
    {
        if(fireTime < maxFireTime)
        {
            fireTime += Time.deltaTime;
        }
        else
        {
            GameObject enemyBullet = ObjectManager.instance.MakeObj("EnemyBullet");
            enemyBullet.transform.position = transform.position;
            enemyBullet.GetComponent<EnemyBullet>().Attack();
            fireTime = 0;
        }
    }
}
