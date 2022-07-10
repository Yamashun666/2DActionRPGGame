using ClearSky;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpMagic : MonoBehaviour
{
    public float _upSpeedVec = 1f;

    public void OnCall()
    {
        _upSpeedVec = 2f;
        Invoke(nameof(Reset), 3.5f);
    }
    private void Reset()
    {
        _upSpeedVec = 1f;
    }
    
}
