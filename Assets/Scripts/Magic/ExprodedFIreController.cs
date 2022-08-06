using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExprodedFIreController : MonoBehaviour
{
    public float deleteTime = 1.0f;
    void Start()
    {
        Invoke("DestroyParticle", deleteTime);
    }

    void DestroyParticle()
    {
        Destroy(gameObject);
    }
}
