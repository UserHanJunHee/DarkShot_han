using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemUI : MonoBehaviour
{
    ShopItem shopItem;

    [SerializeField]
    private Image[] levelImage;

    [SerializeField]
    private TextMeshProUGUI priceText;

    [SerializeField]
    private TextMeshProUGUI infoText;


    public void GainItem(ShopItem item)
    {
        shopItem = item;
        priceText.text = shopItem.price[shopItem.itemLevel].ToString();
    }

    public void ItemUIUpdate()
    {
        if (shopItem.itemLevel < shopItem.itemMaxLevel)
            priceText.text = shopItem.price[shopItem.itemLevel].ToString();
        else
        {
            priceText.text = "Max";
        }


        for(int i = 0; i < levelImage.Length; i++)
        {
            if(i < shopItem.itemLevel)
            {
                levelImage[i].color = new Color(0, 0, 255);
            }
            else
            {
                levelImage[i].color = new Color(90 / 255f, 90 / 255f, 90 / 255f, 255 / 255f);
            }
        }
    }

    public void UpButton()
    {
        if (shopItem.itemLevel < shopItem.itemMaxLevel)
        {
            if (SaveDataFile.instance.money > shopItem.price[shopItem.itemLevel])
            {
                SaveDataFile.instance.money -= shopItem.price[shopItem.itemLevel];
                // haveMoneyText.text = SaveDataFile.instance.money.ToString();
            }
            else
            {
                infoText.text = "���� �����մϴ�";
                return;
            }
            levelImage[shopItem.itemLevel].color = new Color(0, 0, 255);
            infoText.text = shopItem.info[shopItem.itemLevel];
            shopItem.itemLevel++;

            if(shopItem.itemLevel < shopItem.itemMaxLevel)
                priceText.text = shopItem.price[shopItem.itemLevel].ToString();
            else
            {
                priceText.text = "Max";
            }
        }
        else
        {
            infoText.text = "���� �ְ� �����Դϴ� ȿ���� : "+ shopItem.info[shopItem.itemLevel-1].ToString();
        }

    }


    public void DownButton()
    {
        if (shopItem.itemLevel < 1)
        {
            levelImage[shopItem.itemLevel].color = new Color(90 / 255f, 90 / 255f, 90 / 255f, 255 / 255f);
            infoText.text = "���� ���������Դϴ� ���� ���� ȿ���� "+shopItem.info[shopItem.itemLevel];
        }
        else
        {
            shopItem.itemLevel--;
            SaveDataFile.instance.money += shopItem.price[shopItem.itemLevel];
            levelImage[shopItem.itemLevel].color = new Color(90 / 255f, 90 / 255f, 90 / 255f, 255 / 255f);
            priceText.text = shopItem.price[shopItem.itemLevel].ToString();
            infoText.text = shopItem.info[shopItem.itemLevel];
        }
    }
}
