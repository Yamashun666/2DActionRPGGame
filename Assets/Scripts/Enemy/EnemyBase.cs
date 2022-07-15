using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private EnemyScriptableData _data; //ScriptableObjactを使用したエネミーデータ
    [SerializeField] private GameObject player;
    public float enemyCurrentHP = default;              // Enemyの現在体力
    public float enemyCurrentMP = default;              // Enemyの現在マジックポイント
    public bool _isEnemyActive = false;                // EnemyがPlayerを発見しているかどうか

    void Start()
    {
        enemyCurrentHP = _data.enemyMaxHP;
        enemyCurrentMP = _data.enemyMaxMP;

    }

    public virtual void OnActive()                      // Playerと一定距離になった場合、Playerを発見する処理をする。
    {
        //    if (_data.DistanceX <= player.transform.position.x - this.transform.position.x)
        //    {
        //        _isEnemyActive = true;
        //    }
        //    else if (_data.DistanceX >= player.transform.position.x - this.transform.position.x)
        //    {
        //        _isEnemyActive = false;
        //    }
    }

//public virtual void OnBattle()                      //Playerを発見したら、戦闘開始する処理をする。
//{
//    if (_isEnemyActive)
//    {
//        Destroy(gameObject);
//        Debug.Log("aho");
//    }
//}

private void Die()
    {       
        
    }
}
