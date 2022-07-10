using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : ItemBase
{
    
    [SerializeField]

    private void Start()
    {
        GetComponent<PlayerStatus>();
    }
    public override void Use(PlayerStatus status)
    {
        base.Use(status);
        PotionData data = itemData as PotionData;
        status.Heal(data.healValue);
        if (status.currentHp >= status.maxHp)
        {
            status.currentHp = status.maxHp;

        }
        Debug.Log($"ポーション使用。現在HP{status.currentHp}");
    }
}
