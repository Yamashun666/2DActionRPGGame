using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Potion,
    Weapon,
    Buff,
    Material
}
[CreateAssetMenu(menuName = "MyScriptable/Create ItemData")]
public class Item : ScriptableObject
{
    public string itemName = default;
    public int buyPrice = default;
    public ItemTypes itemType = default;
    public int effectForceIntType = default;
    public float effectForceFloatType = default;


}
