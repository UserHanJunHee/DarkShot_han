using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBullet : Bullet
{
    public BoomBullet()
    {
        type = "BoomBullet";
        damage = 1;
        bulletSpeed = 5f;
        knockBack = 0;
        maxbulletSafeTime = 3f;
    }

    public override void Attack(Vector3 mousePos)
    {
        base.Attack(mousePos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Enemy")
        {
            GameObject obj = ObjectManager.instance.MakeObj("Explosion");
            obj.transform.position = transform.position;
            DisappearBullet();
            collision.gameObject.GetComponent<Enemy>().OnDamage(damage, knockBack, transform);
        }
    }
}
