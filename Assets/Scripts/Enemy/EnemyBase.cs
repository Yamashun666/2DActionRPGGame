using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{   //ScriptableObjactを使用したエネミーデータ
    [SerializeField] private EnemyScriptableData _data;
    [SerializeField] public PlayerStatus _player;
    [SerializeField] public EnemyPositionGetter _enemyController;


    
    // Enemyの現在体力
    private float _enemyCurrentHP;
    // Enemyの現在マジックポイント
    private float _enemyMaxHP;
    // EnemyがPlayerを発見しているかどうか
    private bool _isEnemyActive = false;

    // Playerと一定距離になった場合、Playerを発見する処理をする。
    public virtual void OnActive()
    {
        // Playerとの距離
        float rangeY = _player.transform.position.y - _enemyController.transform.position.y;
        float rangeX = _player.transform.position.x - _enemyController.transform.position.x;



        //Playerとの距離が一定以下なら、_isEnemyActiveをtrueにする
       if(rangeX <= _data.rangeX && rangeY <= _data.rangeY)
        {
            _isEnemyActive = true;
        }
    }

    //Playerを発見したら、戦闘開始する処理をする。
    public virtual void OnBattle()
    {
        if (_isEnemyActive)
        {

        }
    }
}
