using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{

    [SerializeField]
    GameObject[] itemGameObject;

    [SerializeField]
    private TextMeshProUGUI haveMoneyText;

    [SerializeField]
    private TextMeshProUGUI infoText;

    private void OnEnable()
    {
        HaveMoneyTextUpdate();
    }

    private void Awake()
    {
        ItemInputShop(SaveDataFile.instance.itemList);
    }

    public void HaveMoneyTextUpdate()//여기 외에도 밖에서 업 다운 버튼에 직접 이밴트 넣어줌
    {
        haveMoneyText.text = SaveDataFile.instance.money.ToString();
    }

    public void GameStartButton()
    {
        SceneManager.LoadScene(1);
    }

    private void ItemInputShop(List<ShopItem> itemList)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            itemGameObject[i].GetComponent<ShopItemUI>().GainItem(itemList[i]);
            itemGameObject[i].GetComponent<ShopItemUI>().ItemUIUpdate();
        }

        infoText.text = "";
    }
    public void ShopOkButton()
    {
        SaveDataFile.instance.UpdateStat(
            SaveDataFile.instance.itemList[0].itemLevel,
            (float)SaveDataFile.instance.itemList[1].itemLevel * 0.1f,
            (float)SaveDataFile.instance.itemList[2].itemLevel * 0.1f,
            (float)SaveDataFile.instance.itemList[3].itemLevel * 0.1f
            ); ;
    }
}
