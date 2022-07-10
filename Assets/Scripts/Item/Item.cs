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
    public string itemName;
    public int buyPrice;
    public ItemTypes itemType;
    
}
