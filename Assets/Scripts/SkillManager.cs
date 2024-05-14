using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;


    List<Skill> allSkillList = new List<Skill>();//초기화를 위한 기본값
    List<Skill> ranSkillList = new List<Skill>();//현재 뽑을 수 있는 스킬
    public List<Skill> selectSkillList = new List<Skill>();//뽑힌 스킬

    Skill[] repeatSkill = new Skill[2];//반복 스킬


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

        //반복연구
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
    //스킬 만렙일때 뺄려고
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
    //무기 뽑았을때 중복안되게 하기 위해서
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

    //1렙스킬 획득시 가진 스킬에 넣고 최대 갯수에 도달하면 뽑을수있는 스킬을 다 뺌
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
                



            //    Debug.Log("테스트 구간 1");
            //    if (testSame)
            //    {
            //        ranSkillList.RemoveAt(i);
            //        i = 0;
            //        testSame = false;
            //    }
            //    for(int j = 0; j < haveSkill.Length; i++)
            //    {
            //        Debug.Log("테스트 구간 2");
            //        if (ranSkillList[i].skillName != haveSkill[j].skillName)
            //        {
            //            Debug.Log("테스트 구간 3");
            //            testSame = true;
                        
                        
            //        }
            //        else
            //        {


            //        }
            //    }
            //}   
        }
    }

    //뽑을수 있는 스킬이 있으면 뽑고 아니면 반복 스킬
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
