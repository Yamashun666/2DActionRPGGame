using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemDataBase", menuName = "MyScriptable/CreateItemDataBase")]
public class ItemList : ScriptableObject
{
    public List <ItemScriptableData> items = new List<ItemScriptableData>();
}
