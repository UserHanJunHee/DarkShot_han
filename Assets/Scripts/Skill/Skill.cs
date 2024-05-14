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
        skillName = "���̾� ��";
        skillTag = "LAttack";
        info[0] = "���� ź���� ���� ���̾� ���� �⺻ ������ ��ü�˴ϴ�. ���̾�� ���� �浹�� �����մϴ�.";
        info[1] = "���� ������ �����մϴ�.";
        info[2] = "���� �������� �����մϴ�.";
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
            //��������
            for (int i = 0; i < ObjectManager.instance.explosionList.Count; i++)
            {
                ObjectManager.instance.explosionList[i].GetComponent<Explosion>().SkillLvUp(skillLevel);
            }
            skillLevel++;
        }
        else
        {
            //���������� �� ��ų ���� ���� ����Ʈ���� ����
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
        skillName = "����";
        skillTag = "LAttack";
        info[0] = "�⺻ ������ ����� ���մϴ�. ź������ ����ϴ�.";
        info[1] = "�������� �����մϴ�.";
        info[2] = "���� �����̰� �پ��ϴ�.";
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
            //������ ����
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
        skillName = "ź�� ����";
        skillTag = "Passive";
        info[0] = "ź���� 30% �����մϴ�.";
        info[1] = "ź���� 60% �����մϴ�.";
        info[2] = "ź���� 100%�����մϴ�.";
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
            //2��ȿ��
            CorrectionValueManager.instance.bulletSpeed += 0.3f;
            skillLevel++;
        }
        else
        {
            //3�� ȿ��
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
        skillName = "���ݷ� ����";
        skillTag = "Passive";
        info[0] = "��� ���ݿ� 1�� �߰� �������� ���ϴ�.";
        info[1] = "��� ���ݿ� 2�� �߰� �������� ���ϴ�.";
        info[2] = "��� ���ݿ� 3�� �߰� �������� ���ϴ�.";
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
            //2��ȿ��
            CorrectionValueManager.instance.atk += 1;
            skillLevel++;
        }
        else
        {
            //3�� ȿ��
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
        skillName = "�߻� ���� ����";
        skillTag = "Passive";
        info[0] = "�߻� ������ 15% �����մϴ�.";
        info[1] = "�߻� ������ 30% �����մϴ�.";
        info[2] = "�߻� ������ 50% �����մϴ�.";
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
            //2��ȿ��
            CorrectionValueManager.instance.rateTime += 0.15f;
            skillLevel++;
        }
        else
        {
            //3�� ȿ��
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
        skillName = "�̵� �ӵ� ����";
        skillTag = "Passive";
        info[0] = "�̵� �ӵ��� 20% �����մϴ�.";
        info[1] = "�̵� �ӵ��� 40% �����մϴ�.";
        info[2] = "�̵� �ӵ��� 60% �����մϴ�.";
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
            //2��ȿ��
            CorrectionValueManager.instance.speed += 0.2f;
            skillLevel++;
        }
        else
        {
            //3�� ȿ��
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
        skillName = "ȸ��";
        skillTag = "Repeat";
        info[1] = "ü�� 10 ȸ���մϴ�";
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
        skillName = "��";
        skillTag = "Repeat";
        info[1] = "�� 10�� ȹ��";
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
        skillName = "��ųA";
        skillTag = "AttackSkill";
        info[0] = "����1";
        info[1] = "����2";
        info[2] = "����3";
        skillLevel = 0;
    }


    public override void SkillEffect()
    {
        if (skillLevel == 0)
        {
            //�÷��̾� ��ġ
            //���� �������� �߻�����
            //���� ����� ������ ����?
        }
        else if (skillLevel == 1)
        {
            
        }
        else
        {
            
        }
    }
}