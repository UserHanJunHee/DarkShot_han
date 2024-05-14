using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected string type;
    protected int damage;
    protected float bulletSpeed;
    protected int knockBack;


    private float bulletSafeTime = 0;
    protected float maxbulletSafeTime;


    private void Update()
    {
        if (gameObject.activeSelf)
        {
            if (maxbulletSafeTime > bulletSafeTime)
            {
                bulletSafeTime += Time.deltaTime;
            }
            else
            {
                DisappearBullet();
            }
        }
    }


    public virtual void Attack(Vector3 mousePos)
    {
        transform.position = GameManager.instance.playerPos.position;
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        Vector2 dirVec = (mousePos - transform.position).normalized;
        //Invoke("DisappearBullet", 3f);

        float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - 90));
        rigid.AddForce(dirVec.normalized * (bulletSpeed + (bulletSpeed * CorrectionValueManager.instance.bulletSpeed)), ForceMode2D.Impulse);
        //rigid.velocity = (dirVec.normalized * bulletSpeed) * Time.deltaTime;


        //Vector2 dirVec = (GameManager.instance.playerPos.position - transform.position).normalized;
        //GetComponent<Rigidbody2D>().velocity = dirVec * moveSpeed * Time.deltaTime;
    }

    protected void DisappearBullet()
    {
        bulletSafeTime = 0f;
        ObjectManager.instance.ReturnObject(gameObject, type);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision != null && collision.gameObject.tag == "Enemy")
    //    {
    //        collision.gameObject.GetComponent<Enemy>().OnDamage(damage, knockBack, transform);
    //        DisappearBullet();
    //        Debug.Log("Å×½ºÆ®");
    //    }
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Enemy" && type != "BoomBullet")
        {
            //CancelInvoke();
            DisappearBullet();
            collision.gameObject.GetComponent<Enemy>().OnDamage(damage, knockBack, transform);
        }
    }
}
