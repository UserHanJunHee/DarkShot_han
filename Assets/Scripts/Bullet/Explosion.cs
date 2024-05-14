using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    int damage = 8;
    int knockBack = 10;


    public void SkillLvUp(int i)
    {
        if(i == 1)
        {
            transform.localScale = new Vector3(3f, 3f, 3f);
        }
        else if(i == 2)
        {
            damage += 4;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().OnDamage(damage, knockBack, transform);
        }
    }

    private void DisappearExplosion()//밖에서 애니메이션 이밴트로 해줬음
    {
        ObjectManager.instance.ReturnObject(gameObject, "Explosion");
    }
}
