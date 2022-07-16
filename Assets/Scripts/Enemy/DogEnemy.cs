using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogEnemy : EnemyBase
{
    private void Update() // エネミーのHPが０以下になった場合、エネミーを消す
    {
        if(enemyCurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }  
}
