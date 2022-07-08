using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int maxHp = 100;
    public int maxMp = 100;
    public int money = 0;
    private int currentHp;
    private int currentMp;

    List<ItemBase> HaveItems = new List<ItemBase>();
    // Start is called before the first frame update
    void Start()
    {
        maxHp = currentHp;
        maxMp = currentMp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ItemUse(ItemTypes.Potion);
        }
    }
    void ItemUse(ItemTypes itemtype)
    {
        foreach (var i in HaveItems)
        {
            if(i.itemData.itemType == itemtype)
            {
                i.Use(this);
                
            }
        }
    }
    public void Heal(int healValue)
    {
        currentHp += healValue;
    }

    public void AddItem(ItemBase item)
    {
        HaveItems.Add(item);
    }
}
