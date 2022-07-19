using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private EnemyScriptableData _data; //ScriptableObjactを使用したエネミーデータ
    [SerializeField] private GameObject player;
    [SerializeField] public GameObject target;          // 追跡用のtransform.positionを受け取る
    [SerializeField] PlayerStatus status;               // Playerとダメージをやり取りする時のコンポーネント  
    private Rigidbody2D rb;                             // ジャンプするときようにRigidBodyを受け取る
    private SpriteRenderer renderer;                    // Sprite反転用にSpriteRendererを取得する
    public float enemyCurrentHP = default;              // Enemyの現在体力
    public float enemyCurrentMP = default;              // Enemyの現在マジックポイント
    public float junpForce = default;                   // Enemyがジャンプするときの力
    public float moveSpeed = default;                   // Enemyが移動するときの速度
    public float plusTransLate = default;　　　　　　　 // プラス方向にトランスする量をここで決める（値が大きいほど遅くなる）
    public float minusTransLate = default;              // マイナス方向にトランスする量をここで決める（値が大きいほど遅くなる）
    public bool isJunp = false;                         // ジャンプ中かどうか
    public bool isMeleeAttack = false;                  // 攻撃中かどうか
    public bool isValid = false;                        // 行動中かどうか
    public bool isEnemyActive = false;                  // EnemyがPlayerを発見しているかどうか
    public bool isStay = false;                         // 待機中かどうか

    void Start()
    {
        enemyCurrentHP = _data.enemyMaxHP;
        enemyCurrentMP = _data.enemyMaxMP;
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }


    public virtual void Oncall()
    {

    }
    public virtual void Stay()
    {
        
    }

    public virtual void Junp()
    {
        if (isJunp) // もしジャンプ中なら早期リターンを行って処理を行わない。
        {
            return;
        }
        else // それ以外なら、ジャンプ処理を開始し、ジャンプ中にtrueを入れる。
        {
            isJunp = true;
            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, junpForce);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJunp = false;
        }
    }

    public virtual void Run()
    {

    }

    public virtual void Shot()
    {

    }

    

    public virtual void MeleeAttack()
    {
        if (isMeleeAttack)
        {
            return;
        }

        else
        {
            Debug.Log("fuck");
            status.currentHp -= _data.attackPower1;
            isMeleeAttack = true;
        }
    }

    public virtual void MeleeAttackEnd()
    {
        isMeleeAttack = false;
    }

    public virtual void Defence()
    {

    }

    public virtual void Accelerate()
    {

    }

    public virtual void Attack()
    {

    }

    public virtual void Chase()
    {
        if (this.transform.position.x >= target.transform.position.x)
        {
            transform.Translate((target.transform.position.x - this.transform.position.x) / minusTransLate, 0, 0);
            renderer.flipX = false;
        }
        else if (this.transform.position.x <= target.transform.position.x)
        {
            transform.Translate(((target.transform.position.x - this.transform.position.x) / plusTransLate) * 1, 0, 0);
            renderer.flipX = true;
            //Debug.Log(this.transform.position.x);
        }
    }

    public virtual void Die()
    {
        if(enemyCurrentHP <= 0)
        {
            Destroy(gameObject);
            Reward();
        }
    }

    private void Reward()
    {

    }

    private void Reset()
    {
        
    }
}
