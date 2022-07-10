using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int maxHp = 100;
    public int maxMp = 100;
    public int money = 0;
    public int currentHp;
    public int currentMp;

    [SerializeField] MagicBase healMagic;

    List<ItemBase> HaveItems = new List<ItemBase>();
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
        currentMp = maxMp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ItemUse(ItemTypes.Potion);

        }
        HealMagic();
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

    public void HealMagic()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if(currentHp < maxHp)
            {
                healMagic.OnCall();
                currentHp += (int)healMagic.effectPower;
                if(currentHp >= maxHp)
                {
                    currentHp = maxHp;
                    
                }
                Debug.Log($"åªç›HP{currentHp}");
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
