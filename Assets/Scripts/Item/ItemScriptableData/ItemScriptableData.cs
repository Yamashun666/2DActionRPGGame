using System;
using UnityEngine;

public enum ItemTypes
{
    Potion,
    Material,
    Weapon,
    Buff,
    Armor,
    Throw,
}
public class ItemScriptableData : ScriptableObject
{
    public string itemName = default;             // アイテムの名前
    public string itemInfomation = default;       // アイテムの設定、説明文
    public int price = default;                   // 売買する価格。同一の物を使う。売買でレートを調整したい場合は、計算式の方で調整する。
    public int brokenPoint = default;             // アイテムの耐久値。これが0になるとアイテムは壊れる。
    public int useAmount = default;               // 何個アイテムを消費してUse関数を呼ぶか
    public ItemTypes itemType = default;          // アイテムの種類
    public float effectForce = default;           // float型で効果量を調整する便利くん
    public Sprite itemIcon;                       // アイテムアイコン
}
