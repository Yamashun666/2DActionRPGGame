using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClearSky;

public class TestData : MonoBehaviour
{ 
    public ItemScriptableData itemData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SimplePlayerController simple = collision.GetComponent<SimplePlayerController>();
            MagicBase magic = simple.HiJumpMagic;

            if (simple.HiJumpMagic.ValidReset)
            {
                Destroy(gameObject);
                simple.HiJumpMagic.UsingValidReset();
            }

        }
    }
}
