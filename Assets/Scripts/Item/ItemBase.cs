using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public ItemScriptableData itemData;
    public InventoryUI itemList;
    public int itemAmount;
    public bool isUse = false;

    public virtual void Use(PlayerStatus status)
    {
        status.Consumption(this);
        Debug.Log("アイテムを使用しました。");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }

    public virtual void Buff()
    {

    }

    public virtual void Throw()
    {

    }

    public virtual void Broken()
    {
        if(itemData.brokenPoint <= 0)
        {
            Destroy(itemList);
        }
    }

    public virtual void ItemDamage()
    {

    }

    public virtual void BuySell()
    {

    }

}
