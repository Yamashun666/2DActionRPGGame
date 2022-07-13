using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMagic : MagicBase
{
    [SerializeField] FireController fire;
    [SerializeField] Transform fireBarrel;
    public override void OnCall()
    {
        
        if (IsValid)
        {
            return;
        }
        FireController controller = Instantiate(fire, fireBarrel.position, Quaternion.identity);
        controller.FireGenerate(effectPower);
        base.OnCall();

    }
}

