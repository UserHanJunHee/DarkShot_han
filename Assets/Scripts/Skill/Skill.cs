using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public string skillName { get; set; }
    public string skillTag { get; set; }
    protected string[] info = new string[3];
    protected int skillLevel;
    public bool completLevelUpSkill { get; set; } = false;

    public virtual void SkillEffect()
    {
        if(skillLevel == 0)
        {
            SkillManager.instance.InPutHaveSkill(this);
        }
    }

    protected void CompletSkillLvUp()
    {
        SkillManager.instance.RemoveRanSkill(skillName);
    }

    public string SkillInfo()
    {
        return info[skillLevel];
    }
}

public class FireBall : Skill
{
    float rateTime = 2f;
    protected Player playerComponent = GameManager.instance.PlayerComponent();
    public FireBall()
    {
        skillName = "파이어 볼";
        skillTag = "LAttack";
        info[0] = "느린 탄속을 가진 파이어 볼로 기본 공격이 대체됩니다. 파이어볼은 적과 충돌시 폭발합니다.";
        info[1] = "폭발 범위가 증가합니다.";
        info[2] = "폭발 데미지가 증가합니다.";
        skillLevel = 0;
    }

    public override void SkillEffect()
    {
        if (skillLevel == 0)
        {
            playerComponent.ChangeBulletType(2, rateTime);
            SkillManager.instance.RemoveSameTagRanSkill(skillTag, skillName);
            base.SkillEffect();
            skillLevel++;
        }
        else if (skillLevel == 1)
        {
            //범위증가
            for (int i = 0; i < ObjectManager.instance.explosionList.Count; i++)
            {
                ObjectManager.instance.explosionList[i].GetComponent<Explosion>().SkillLvUp(skillLevel);
            }
            skillLevel++;
        }
        else
        {
            //데미지증가 및 스킬 구매 가능 리스트에서 빼기
            for (int i = 0; i < ObjectManager.instance.explosionList.Count; i++)
            {
                ObjectManager.instance.explosionList[i].GetComponent<Explosion>().SkillLvUp(skillLevel);
            }
            CompletSkillLvUp();
            completLevelUpSkill = true;
        }
    }
}

public class FastBullet : Skill
{
    float rateTime = 0.3f;
    protected Player playerComponent = GameManager.instance.PlayerComponent();
    public FastBullet()
    {
        skillName = "난사";
        skillTag = "LAttack";
        info[0] = "기본 공격이 연사로 변합니다. 탄퍼짐이 생깁니다.";
        info[1] = "데미지가 증가합니다.";
        info[2] = "재사격 딜레이가 줄어듭니다.";
        skillLevel = 0;
    }

    public override void SkillEffect()
    {
        if (skillLevel == 0)
        {
            playerComponent.ChangeBulletType(1, rateTime);
            SkillManager.instance.RemoveSameTagRanSkill(skillTag, skillName);
            base.SkillEffect();
            skillLevel++;
        }
        else if (skillLevel == 1)
        {
            //데미지 증가
            for (int i = 0; i < ObjectManager.instance.explosionList.Count; i++)
            {
                ObjectManager.instance.playerBulletBList[i].GetComponent<PlayerBulletB>().SkillLvUp(skillLevel);
            }
            skillLevel++;
        }
        else
        {
            playerComponent.ChangeBulletType(1, rateTime - 0.1f);
            CompletSkillLvUp();
            completLevelUpSkill = true;
        }
    }
}

public class BulletSpeed : Skill
{
    public BulletSpeed()
    {
        skillName = "탄속 증가";
        skillTag = "Passive";
        info[0] = "탄속이 30% 증가합니다.";
        info[1] = "탄속이 60% 증가합니다.";
        info[2] = "탄속이 100%증가합니다.";
        skillLevel = 0;
    }

    public override void SkillEffect()
    {
        if (skillLevel == 0)
        {
            base.SkillEffect();
            CorrectionValueManager.instance.bulletSpeed += 0.3f;
            skillLevel++;
        }
        else if (skillLevel == 1)
        {
            //2렙효과
            CorrectionValueManager.instance.bulletSpeed += 0.3f;
            skillLevel++;
        }
        else
        {
            //3렙 효과
            CorrectionValueManager.instance.bulletSpeed += 0.4f;
            CompletSkillLvUp();
            completLevelUpSkill = true;
        }
    }
}

public class ATKUp : Skill
{
    public ATKUp()
    {
        skillName = "공격력 증가";
        skillTag = "Passive";
        info[0] = "모든 공격에 1의 추가 데미지가 들어갑니다.";
        info[1] = "모든 공격에 2의 추가 데미지가 들어갑니다.";
        info[2] = "모든 공격에 3의 추가 데미지가 들어갑니다.";
        skillLevel = 0;
    }

    public override void SkillEffect()
    {
        if (skillLevel == 0)
        {
            base.SkillEffect();
            CorrectionValueManager.instance.atk += 1;
            skillLevel++;
        }
        else if (skillLevel == 1)
        {
            //2렙효과
            CorrectionValueManager.instance.atk += 1;
            skillLevel++;
        }
        else
        {
            //3렙 효과
            CorrectionValueManager.instance.atk += 1;
            CompletSkillLvUp();
            completLevelUpSkill = true;
        }
    }
}


public class RateTimeDown : Skill
{
    public RateTimeDown()
    {
        skillName = "발사 간격 감소";
        skillTag = "Passive";
        info[0] = "발사 간격이 15% 감소합니다.";
        info[1] = "발사 간격이 30% 감소합니다.";
        info[2] = "발사 간격이 50% 감소합니다.";
        skillLevel = 0;
    }

    public override void SkillEffect()
    {
        if (skillLevel == 0)
        {
            base.SkillEffect();
            CorrectionValueManager.instance.rateTime += 0.15f;
            skillLevel++;
        }
        else if (skillLevel == 1)
        {
            //2렙효과
            CorrectionValueManager.instance.rateTime += 0.15f;
            skillLevel++;
        }
        else
        {
            //3렙 효과
            CorrectionValueManager.instance.rateTime += 0.2f;
            CompletSkillLvUp();
            completLevelUpSkill = true;
        }
    }
}


public class SpeedUp : Skill
{
    public SpeedUp()
    {
        skillName = "이동 속도 증가";
        skillTag = "Passive";
        info[0] = "이동 속도가 20% 증가합니다.";
        info[1] = "이동 속도가 40% 증가합니다.";
        info[2] = "이동 속도가 60% 증가합니다.";
        skillLevel = 0;
    }

    public override void SkillEffect()
    {
        if (skillLevel == 0)
        {
            base.SkillEffect();
            CorrectionValueManager.instance.speed += 0.2f;
            skillLevel++;
        }
        else if (skillLevel == 1)
        {
            //2렙효과
            CorrectionValueManager.instance.speed += 0.2f;
            skillLevel++;
        }
        else
        {
            //3렙 효과
            CorrectionValueManager.instance.speed += 0.2f;
            CompletSkillLvUp();
            completLevelUpSkill = true;
        }
    }
}


public class RecoveryHp : Skill
{
    public RecoveryHp()
    {
        skillName = "회복";
        skillTag = "Repeat";
        info[1] = "체력 10 회복합니다";
        skillLevel = 1;
    }

    public override void SkillEffect()
    {
        GameManager.instance.PlayerComponent().RecoveryHp(10);
    }
}

public class Money : Skill
{
    public Money()
    {
        skillName = "돈";
        skillTag = "Repeat";
        info[1] = "돈 10원 획득";
        skillLevel = 1;
    }

    public override void SkillEffect()
    {
        SaveDataFile.instance.GainMoney(10);
    }
}



public class SkillA : Skill
{
    public SkillA()
    {
        skillName = "스킬A";
        skillTag = "AttackSkill";
        info[0] = "설명1";
        info[1] = "설명2";
        info[2] = "설명3";
        skillLevel = 0;
    }


    public override void SkillEffect()
    {
        if (skillLevel == 0)
        {
            //플레이어 위치
            //몇초 간격으로 발사할지
            //가장 가까운 적한테 쏠꺼임?
        }
        else if (skillLevel == 1)
        {
            
        }
        else
        {
            
        }
    }
}