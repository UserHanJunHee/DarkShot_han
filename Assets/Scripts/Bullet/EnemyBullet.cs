using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    public EnemyBullet()
    {
        type = "EnemyBullet";
        damage = 6;
        bulletSpeed = 5f;
        knockBack = 0;
        maxbulletSafeTime = 3f;
    }

    public void Attack()
    {
        Vector2 dirVec = (GameManager.instance.playerPos.position - transform.position).normalized;

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();

        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90));
        rigid.AddForce(dirVec.normalized * bulletSpeed , ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {

            DisappearBullet();
            collision.gameObject.GetComponent<Player>().PlayerOnDamage(damage);
        }
    }
}
