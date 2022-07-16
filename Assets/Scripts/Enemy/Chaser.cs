using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private EnemyScriptableData _data; //ScriptableObjactを使用したエネミーデータ
    [SerializeField] private GameObject target;         // 追跡用のplayer.transform.positionを受け取る
    [SerializeField] private PlayerStatus status;       // 衝突したときにプレイヤーのHPを減らす為の変数
    SpriteRenderer renderer = default;
    public int   attackPower = default;
    public float plusTransLate = default;　　　　　　　　  // プラス方向にトランスする量をここで決める（値が大きいほど遅くなる）
    public float minusTransLate = default;                 // マイナス方向にトランスする量をここで決める（値が大きいほど遅くなる）

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (this.transform.position.x >= target.transform.position.x)
        {
            transform.Translate((target.transform.position.x - this.transform.position.x) / minusTransLate, 0, 0);
            renderer.flipX = false;
        }
        else if (this.transform.position.x <= target.transform.position.x)
        {
            transform.Translate(((target.transform.position.x - this.transform.position.x ) / plusTransLate) * 1, 0, 0);
            renderer.flipX = true;
            //Debug.Log(this.transform.position.x);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == target)
        {
            status.currentHp -= attackPower;
        }
    }
}
