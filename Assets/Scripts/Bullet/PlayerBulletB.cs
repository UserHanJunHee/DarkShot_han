using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletB : Bullet
{
    public PlayerBulletB()
    {
        type = "PlayerBulletB";
        damage = 2;
        bulletSpeed = 10f;
        knockBack = 1;
        maxbulletSafeTime = 2f;
    }
    public void SkillLvUp(int i)
    {
        if (i == 1)
        {
            damage += 2;
        }
        else if (i == 2)
        {

        }
    }

    public override void Attack(Vector3 mousePos)
    {

        transform.position = GameManager.instance.playerPos.position;
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        Vector2 dirVec = (mousePos - transform.position).normalized;
        //dirVec.x += Random.Range(-0.1f, 0.1f);
        //dirVec.y += Random.Range(-0.1f, 0.1f);
        Vector2 xy = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90));
        rigid.AddForce((dirVec.normalized + xy ) * (bulletSpeed + (bulletSpeed * CorrectionValueManager.instance.bulletSpeed)), ForceMode2D.Impulse);

    }
}
