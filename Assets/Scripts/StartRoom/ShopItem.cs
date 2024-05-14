using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem
{
    public string itemName { get; set; }
    public int itemLevel { get; set; } = 0;
    public int itemMaxLevel { get; set; }
    public int[] price = new int[5];
    public string[] info = new string[5];

}


public class AtkUpItem : ShopItem
{
    public AtkUpItem()
    {
        itemName = "공력력 업";
        itemMaxLevel = 2;
        price[0] = 1000;
        price[1] = 3000;
        info[0] = "모든 공격의 공격력이 1 증가합니다";
        info[1] = "모든 공격의 공격력이 2 증가합니다";
    }
}

public class SpeedUpItem : ShopItem
{
    public SpeedUpItem()
    {
        itemName = "스피드 업";
        itemMaxLevel = 5;
        price[0] = 1000;
        price[1] = 2000;
        price[2] = 3000;
        price[3] = 4000;
        price[4] = 5000;
        info[0] = "이동속도가 10% 증가합니다";
        info[1] = "이동속도가 20% 증가합니다";
        info[2] = "이동속도가 30% 증가합니다";
        info[3] = "이동속도가 40% 증가합니다";
        info[4] = "이동속도가 50% 증가합니다";
    }
}

public class BulletSpeedUpItem : ShopItem
{
    public BulletSpeedUpItem()
    {
        itemName = "탄속 증가";
        itemMaxLevel = 5;
        price[0] = 1000;
        price[1] = 2000;
        price[2] = 3000;
        price[3] = 4000;
        price[4] = 5000;
        info[0] = "탄속이 10% 증가합니다";
        info[1] = "탄속이 20% 증가합니다";
        info[2] = "탄속이 30% 증가합니다";
        info[3] = "탄속이 40% 증가합니다";
        info[4] = "탄속이 50% 증가합니다";
    }
}


public class RateTimeItem : ShopItem
{
    public RateTimeItem()
    {
        itemName = "발사 간격 감소";
        itemMaxLevel = 3;
        price[0] = 2000;
        price[1] = 4000;
        price[2] = 6000;
        info[0] = "발사 간격이 10% 감소합니다";
        info[1] = "발사 간격이 20% 감소합니다";
        info[2] = "발사 간격이 30% 감소합니다";
    }
}


