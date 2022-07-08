using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{
    public Item itemData;

    public virtual void Use(PlayerStatus status)
    {
        Debug.Log("アイテムを使用しました。");
    }
}
