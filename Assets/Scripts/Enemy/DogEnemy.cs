using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogEnemy : EnemyBase
{
    private void Update() // �G�l�~�[��HP���O�ȉ��ɂȂ����ꍇ�A�G�l�~�[������
    {
        if(enemyCurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }  
}
