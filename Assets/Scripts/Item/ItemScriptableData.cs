using System.Collections;
using System.Collections.Generic;
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
[CreateAssetMenu(menuName = "MyScriptable/Create ItemData")]
public class ItemScriptableData : ScriptableObject
{
    public string itemName = default;             // アイテムの名前
    public string itemFlavourText = default;      //アイテムの設定など、フレーバーテキスト
    public int price = default;                   //売買する価格。同一の物を使う。売買でレートを調整したい場合は、計算式の方で調整する。
    public int brokenPoint = default;             //アイテムの耐久値。これが0になるとアイテムは壊れる。
    public int throwDamage = default;             //投擲ダメージが衝突したときに与えるダメージ
    public int useAmount = default;               // 何個アイテムを消費してUse関数を呼ぶか
    public ItemTypes itemType = default;          // アイテムの種類
    public int effectForceIntType = default;      // int型で効果量を調整できる便利くん
    public float effectForceFloatType = default;  //float型で効果量を調整する便利くん


}
