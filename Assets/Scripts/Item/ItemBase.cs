using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public bool isUse = false;
    public ItemScriptableData itemData;
    public int itemAmount;

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

    public virtual void Consumption()
    {

    }

    public virtual void Buff()
    {

    }

    public virtual void Throw()
    {

    }

    public virtual void Broken()
    {

    }

    public virtual void ItemDamage()
    {

    }

    public virtual void Buy()
    {

    }

    public virtual void Sell()
    {

    }

}
