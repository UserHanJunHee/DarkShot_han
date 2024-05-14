using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected string type;
    protected int hp;
    protected int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
    }
    protected float moveSpeed;
    protected bool isHit;
    private float hitTime = 0;
    protected float maxHitTime;
    protected int expPoint;


    private void Update()
    {
        if(gameObject.activeSelf && !isHit)
        {
            MoveForPlayer();
        }
        else if(isHit)
        {
            hitTime += Time.deltaTime;
            if (hitTime > maxHitTime)
            {
                ReturnOnHit();
            }
        }
        
    }

    protected void MoveForPlayer()
    {
        if (GameManager.instance.playerPos.position.x > transform.position.x)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;

        Vector2 dirVec = (GameManager.instance.playerPos.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().velocity = dirVec * moveSpeed * Time.deltaTime;

    }

    private void DisappearEnemy()
    {
        ObjectManager.instance.ReturnObject(gameObject, type);
    }

    public void OnDamage(int damage, int knockBackPower, Transform transform)
    {
        isHit = true;
        Vector2 dirVec = this.transform.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dirVec.normalized * knockBackPower, ForceMode2D.Impulse);
        hp -= damage + CorrectionValueManager.instance.atk;
        if (hp <= 0)
        {
            DropEXP();
            DisappearEnemy();     
            return;
        }
        hitTime = 0f;
        //Invoke("ReturnOnHit", 0.2f);

        // GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        //GetComponent<Rigidbody2D>().velocity = dirVec * knockBackPower;

    }

    private void ReturnOnHit()
    {
        isHit = false;
    }

    private void DropEXP()
    {
        //보스면 확정 경험치
        if (type == "Boss")
        {
            GameObject exp = ObjectManager.instance.MakeObj("RedEXP");
            exp.GetComponent<EXPItem>().SetExp(expPoint);
            exp.transform.position = transform.position;
            return;
        }
        else if (4 > Random.Range(0, 10))
            return;



        if(expPoint == 1)
        {
            GameObject exp = ObjectManager.instance.MakeObj("BlueEXP");
            exp.GetComponent<EXPItem>().SetExp(expPoint);
            exp.transform.position = transform.position;
        }
        else if (expPoint == 2)
        {
            GameObject exp = ObjectManager.instance.MakeObj("GreenEXP");
            exp.GetComponent<EXPItem>().SetExp(expPoint);
            exp.transform.position = transform.position;
        }
        //else if (expPoint < 100)
        //{
        //    //GameObject exp = ObjectManager.instance.MakeObj("BlueEXP");
        //}
        //else ()
        //{
        //    //GameObject exp = ObjectManager.instance.MakeObj("BlueEXP");
        //}
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision != null && collision.gameObject.tag == "Player")
    //    {
    //        collision.gameObject.GetComponent<Player>().PlayerOnDamage(damage);
    //    }
    //}
}
