using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPPotionItem : ItemBase
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
        if (status.currentMp >= status.maxMp)
        {
            status.currentMp = status.maxMp;

        }
        Debug.Log($"MPポーション使用。現在MP{status.currentMp}");
    }
}
