using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClearSky;

public class HiJunp : MonoBehaviour
{
    public float _upJunpForce = 1f;

    public void HijunpOnCall()
    {
        _upJunpForce = 2f;
        SimplePlayerController.junpCount = 0;
    }

    public void HijunpReset()
    {
        _upJunpForce = 1f;
    }

}
