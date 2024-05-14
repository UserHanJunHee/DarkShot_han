using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPItem : Item
{
    public int exp { get; set; }
    [SerializeField]
    private string inputType = "";

    public EXPItem()
    {
        type = inputType;
    }

    public void SetExp(int exp)
    {
        this.exp = exp; 
    }

    public override void ActiveItem(Player player)
    {
        player.GetEXPItem(exp);
        DisappearItem();
    }

    public override void DisappearItem()
    {
        base.DisappearItem();
        ObjectManager.instance.ReturnObject(gameObject, type);
    }

}
