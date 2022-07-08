using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionItem : ItemBase
{
    public override void Use(PlayerStatus status)
    {
        base.Use(status);
        PotionData data = itemData as PotionData;
        status.Heal(data.healValue);
        Debug.Log($"HP‚ğ{data.healValue}‰ñ•œ‚µ‚Ü‚µ‚½B");
    }
}
