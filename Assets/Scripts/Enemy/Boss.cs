using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    bool canSkillUse = false;
    bool finishSkillUse = true;
    float skillTime = 0f;
    float maxSkillTime = 3f;
    public Boss()
    {
        type = "Boss";
        hp = 200;
        damage = 8;
        moveSpeed = 300f;
        maxHitTime = 0.1f;
        expPoint = 50;
    }

    private void Update()
    {
        if (!canSkillUse && finishSkillUse)
        {
            MoveForPlayer();
            skillTime += Time.deltaTime;
            if (skillTime > maxSkillTime)
                canSkillUse = true;
        }
        else if(canSkillUse)
        {
            skillTime = 0;
            canSkillUse = false;
            finishSkillUse = false;
            Invoke("BossSkill", 1);
        }       
    }

    private void BossSkill()
    {
        Vector2 dirVec = (GameManager.instance.playerPos.position - transform.position).normalized;

        Rigidbody2D rigid = GetComponent<Rigidbody2D>();

        rigid.AddForce(dirVec.normalized * 50, ForceMode2D.Impulse);
        Invoke("FinishSkill", 1.5f);
    }
    private void FinishSkill()
    {
        finishSkillUse = true;
    }
}


