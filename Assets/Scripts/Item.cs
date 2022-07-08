using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyScriptable/Create ItemData")]
public class Item : ScriptableObject
{
    public string itemName;
    public int buyPrice;
}
