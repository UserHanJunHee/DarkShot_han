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
        itemName = "���·� ��";
        itemMaxLevel = 2;
        price[0] = 1000;
        price[1] = 3000;
        info[0] = "��� ������ ���ݷ��� 1 �����մϴ�";
        info[1] = "��� ������ ���ݷ��� 2 �����մϴ�";
    }
}

public class SpeedUpItem : ShopItem
{
    public SpeedUpItem()
    {
        itemName = "���ǵ� ��";
        itemMaxLevel = 5;
        price[0] = 1000;
        price[1] = 2000;
        price[2] = 3000;
        price[3] = 4000;
        price[4] = 5000;
        info[0] = "�̵��ӵ��� 10% �����մϴ�";
        info[1] = "�̵��ӵ��� 20% �����մϴ�";
        info[2] = "�̵��ӵ��� 30% �����մϴ�";
        info[3] = "�̵��ӵ��� 40% �����մϴ�";
        info[4] = "�̵��ӵ��� 50% �����մϴ�";
    }
}

public class BulletSpeedUpItem : ShopItem
{
    public BulletSpeedUpItem()
    {
        itemName = "ź�� ����";
        itemMaxLevel = 5;
        price[0] = 1000;
        price[1] = 2000;
        price[2] = 3000;
        price[3] = 4000;
        price[4] = 5000;
        info[0] = "ź���� 10% �����մϴ�";
        info[1] = "ź���� 20% �����մϴ�";
        info[2] = "ź���� 30% �����մϴ�";
        info[3] = "ź���� 40% �����մϴ�";
        info[4] = "ź���� 50% �����մϴ�";
    }
}


public class RateTimeItem : ShopItem
{
    public RateTimeItem()
    {
        itemName = "�߻� ���� ����";
        itemMaxLevel = 3;
        price[0] = 2000;
        price[1] = 4000;
        price[2] = 6000;
        info[0] = "�߻� ������ 10% �����մϴ�";
        info[1] = "�߻� ������ 20% �����մϴ�";
        info[2] = "�߻� ������ 30% �����մϴ�";
    }
}


