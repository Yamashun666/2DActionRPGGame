using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogEnemy : EnemyBase
{
    
    private void Update() 
    {
        base.Chase();
        base.Die();
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == target)
        {
            base.MeleeAttack();
            base.MeleeAttackEnd();
        }
    }
}
