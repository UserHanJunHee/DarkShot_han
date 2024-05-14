using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float safeItemTime;
    private float maxSafeItemTime = 40f;

    protected string type;

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            if (maxSafeItemTime > safeItemTime)
            {
                safeItemTime += Time.deltaTime;
            }
            else
            {
                DisappearItem();
            }
        }
    }

    public virtual void ActiveItem(Player player)
    {
        
    }

    public virtual void DisappearItem()
    {
        safeItemTime = 0f;
        // ObjectManager.instance.ReturnObject(gameObject, type);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Player")
        {
            ActiveItem(collision.GetComponent<Player>());
        }
    }
}
