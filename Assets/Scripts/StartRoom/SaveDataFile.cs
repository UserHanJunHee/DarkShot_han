using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataFile : MonoBehaviour
{

    public static SaveDataFile instance;
    public int money { get; set; } = 100000;

    public List<ShopItem> itemList = new List<ShopItem>();

    public int atkSave = 0;
    public float speedSave = 0f;
    public float bulletSpeedSave = 0f;
    public float rateTimeSave = 0f;


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

        DontDestroyOnLoad(gameObject);

        ShopItem atkUpItem = new AtkUpItem();
        ShopItem speedUoitem = new SpeedUpItem();
        ShopItem bulletSpeedUpItem = new BulletSpeedUpItem();
        ShopItem rateTimeItem = new RateTimeItem();


        itemList.Add(atkUpItem);
        itemList.Add(speedUoitem);
        itemList.Add(bulletSpeedUpItem);
        itemList.Add(rateTimeItem);
    }

    public void UpdateStat(int atk, float speed, float bulletspeed, float rateTime)
    {
        atkSave = atk;
        speedSave = speed;
        bulletSpeedSave = bulletspeed;
        rateTimeSave = rateTime;
    }

    public void GainMoney(int money)
    {
        this.money += money;
    }


    public void GameStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
