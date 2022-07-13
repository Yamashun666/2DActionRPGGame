using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Humanoid,
    Slime,
    Beast,
    Bird,
}

[CreateAssetMenu(fileName ="EnemyData" , menuName = "MyScriptable/Create EnemyData" , order = 1)]

public class EnemyScriptableData : ScriptableObject
{
    // 敵の種類
    public EnemyType type;
    // Playerとの距離を取得し、行動を分岐するフラグになる距離(Y座標)
    public float DistanceY = 1.0f;
    // Playerとの距離を取得し、行動を分岐するフラグになる距離(X座標)
    public float DistanceX = 1.0f;
    // 敵の最大体力
    public int enemyMaxHP;
    // 敵の最大マジックポイント
    public int enemyMaxMP;
    // Playerを発見しているかどうか
    public bool isEnemyActive = false;
    // Enemyの追跡スピード
    public float moveSpeed = 10.0f;
}
