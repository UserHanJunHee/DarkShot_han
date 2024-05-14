using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;


    List<Skill> allSkillList = new List<Skill>();//�ʱ�ȭ�� ���� �⺻��
    List<Skill> ranSkillList = new List<Skill>();//���� ���� �� �ִ� ��ų
    public List<Skill> selectSkillList = new List<Skill>();//���� ��ų

    Skill[] repeatSkill = new Skill[2];//�ݺ� ��ų


    int haveSkillNum = 0;
    static int maxHaveSkillNum = 5;
    Skill[] haveSkill = new Skill[maxHaveSkillNum];


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //StartSkillSetting();
    }

 
    public void StartSkillSetting()
    {
        Skill fireball = new FireBall();
        Skill fastBullet = new FastBullet();
        Skill bulletSpeed = new BulletSpeed();
        Skill atkUp = new ATKUp();
        Skill rateTimeDown = new RateTimeDown();
        Skill speedUp = new SpeedUp();

        //�ݺ�����
        Skill recoveryHp = new RecoveryHp();
        Skill money = new Money();

        allSkillList.Add(fireball);
        allSkillList.Add(fastBullet);
        allSkillList.Add(bulletSpeed);
        allSkillList.Add(atkUp);
        allSkillList.Add(rateTimeDown);
        allSkillList.Add(speedUp);

        repeatSkill[0] = recoveryHp;
        repeatSkill[1] = money;

        ranSkillList = allSkillList;
    }
    //��ų �����϶� ������
    public void RemoveRanSkill(string name)
    {
        for (int i = 0; i < selectSkillList.Count; i++)
        {
            if (selectSkillList[i].skillName == name)
            {
                selectSkillList.RemoveAt(i);
            }
        }
    }
    //���� �̾����� �ߺ��ȵǰ� �ϱ� ���ؼ�
    public void RemoveSameTagRanSkill(string skillTag, string skillName)
    {
        for(int i = 0; i< ranSkillList.Count; i++)
        {
            if (ranSkillList[i].skillTag == skillTag && ranSkillList[i].skillName != skillName)
            {
                ranSkillList.RemoveAt(i);
                return;
            }
        }
        for(int i =0; i< selectSkillList.Count; i++)
        {
            if (selectSkillList[i].skillTag == skillTag && selectSkillList[i].skillName != skillName)
            {
                selectSkillList.RemoveAt(i);
            }
        }
    }

    //1����ų ȹ��� ���� ��ų�� �ְ� �ִ� ������ �����ϸ� �������ִ� ��ų�� �� ��
    public void InPutHaveSkill(Skill skill)
    {
        //if(haveSkillNum < maxHaveSkillNum)
        haveSkill[haveSkillNum] = skill;
        haveSkillNum++;
        Debug.Log(haveSkillNum);
        if (haveSkillNum == maxHaveSkillNum)
        {
            ranSkillList.Clear();
            selectSkillList.Clear();

            for (int i = 0; i < haveSkill.Length; i++)
            {
                
                if(!haveSkill[i].completLevelUpSkill)
                {
                    Debug.Log(haveSkill[i].skillName);
                    ranSkillList.Add(haveSkill[i]);
                }
                    
            }

            //bool testSame = false;
            //if (ranSkillList.Count < 1)
            //    return;
            //for(int i = 0; i < ranSkillList.Count; i++)
            //{
            //    ranSkillList.Clear();
                



            //    Debug.Log("�׽�Ʈ ���� 1");
            //    if (testSame)
            //    {
            //        ranSkillList.RemoveAt(i);
            //        i = 0;
            //        testSame = false;
            //    }
            //    for(int j = 0; j < haveSkill.Length; i++)
            //    {
            //        Debug.Log("�׽�Ʈ ���� 2");
            //        if (ranSkillList[i].skillName != haveSkill[j].skillName)
            //        {
            //            Debug.Log("�׽�Ʈ ���� 3");
            //            testSame = true;
                        
                        
            //        }
            //        else
            //        {


            //        }
            //    }
            //}   
        }
    }

    //������ �ִ� ��ų�� ������ �̰� �ƴϸ� �ݺ� ��ų
    public void LvUpRandomSkill()
    {
        for(int i = 0; i < 3; i++)
        {
            if(ranSkillList.Count != 0)
            {
                int ran = Random.Range(0, ranSkillList.Count);
                selectSkillList.Add(ranSkillList[ran]);
                ranSkillList.RemoveAt(ran);
            }
            else
            {
                int ran = Random.Range(0, repeatSkill.Length);
                selectSkillList.Add(repeatSkill[ran]);
                
            }
        }
    }


    public void SelectSkillListClear()
    {
        for(int i = 0; i < selectSkillList.Count; i++)
        {
            ranSkillList.Add(selectSkillList[i]);
        }
        selectSkillList.Clear();
    }
}
