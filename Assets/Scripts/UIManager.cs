using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    
    //경험치패널
    [SerializeField]
    private Image expGageFill;
    [SerializeField]
    private TextMeshProUGUI expText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private TextMeshProUGUI lvText;


    //플레이어 체력바
    [SerializeField]
    private Image playerHpGage;


    //레벨업패널
    public GameObject lvUpPannel;
    [SerializeField]
    private TextMeshProUGUI[] skillNameText;

    [SerializeField]
    private TextMeshProUGUI selectNameText;
    [SerializeField]
    private TextMeshProUGUI skilInfoText;

    int choiceSkillNum;

    //리트라이
    [SerializeField]
    private GameObject retryPannel;

    //타이머
    private float secTimer = 0;
    private int minTimer = 0;

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
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }


    public void PlayerHpGage(float hp, float maxHp)
    {
        playerHpGage.fillAmount = hp / maxHp;
    }

    //public void PlayerHpGageRotate(float i)
    //{
    //    playerHpGage.transform.localScale = new Vector3(i, transform.localScale.y, transform.localScale.z);
    //}

    public void ExpUp(float exp, float maxexp)
    {
        expText.text = exp + "/ " + maxexp;
        expGageFill.fillAmount = exp / maxexp;
    }

    public void LvUp(int lv)
    {
        lvText.text =  "Lv:"+lv;
    }

    public void Timer()
    {
        if (minTimer >= 20)
            return;
        else
        {
            secTimer += Time.deltaTime;
            if (secTimer > 59)
            {
                secTimer = 0;
                minTimer++;
                SpawnToMinTimer();


            }
        }
        timerText.text = string.Format(minTimer.ToString("00") + ":" +"{0:N0}", secTimer.ToString("00"));
    }

    private void SpawnToMinTimer()
    {
        if(minTimer == 1)
        {
            SpawnManager.instance.StartRanageSpawn();
        }
        if(minTimer == 2)
        {
            SpawnManager.instance.SpawnBoss();
        }
    }


    public void LevelUpPanelOn()
    {
        SkillManager.instance.LvUpRandomSkill();
        selectNameText.text = "";
        skilInfoText.text = "";
        for (int i = 0; i < skillNameText.Length; i++)
        {
            skillNameText[i].text = SkillManager.instance.selectSkillList[i].skillName;
        }
        lvUpPannel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LevelUpPanelOff()
    {
        choiceSkillNum = -1;
        lvUpPannel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LevelUpSkillSelectInfoButton(int i)//외부에서 버튼 이밴트로 줌
    {
        selectNameText.text = SkillManager.instance.selectSkillList[i].skillName;
        skilInfoText.text = SkillManager.instance.selectSkillList[i].SkillInfo();

        choiceSkillNum = i;
    }

    public void LevelUpCoplete()//외부 이밴트 확정 버튼
    {
        if(choiceSkillNum != -1)
        {
            SkillManager.instance.selectSkillList[choiceSkillNum].SkillEffect();
            SkillManager.instance.SelectSkillListClear();
            LevelUpPanelOff();
        }
    }

    public void RetryPannelOn()
    {
        retryPannel.SetActive(true);
    }
}
