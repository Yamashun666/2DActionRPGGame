using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ClearSky
{
    public class StepGenerateMagic : MagicBase
    {
        [SerializeField] GameObject generateStep;
        [SerializeField] Transform GeneratePos = null;
        [SerializeField] SimplePlayerController simple;

        public override void OnCall()
        {
            if (IsValid)
            {
                return;
            }
            if (!simple.isStepGenerate)
            {
                GameObject stepGenerate = Instantiate(generateStep, GeneratePos.position, Quaternion.identity);
                Debug.Log("fuck");
            }
            base.OnCall();
        }
    }
}



