using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private EnemyScriptableData _data; //ScriptableObjact���g�p�����G�l�~�[�f�[�^
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject target;         // �ǐ՗p��transform.position���󂯎��
    private Rigidbody2D rb;                             // �W�����v����Ƃ��悤��RigidBody���󂯎��
    private SpriteRenderer renderer;                    // Sprite���]�p��SpriteRenderer���擾����
    private PlayerStatus status;                        // Player�ƃ_���[�W������肷�鎞�̃R���|�[�l���g  
    public float enemyCurrentHP = default;              // Enemy�̌��ݑ̗�
    public float enemyCurrentMP = default;              // Enemy�̌��݃}�W�b�N�|�C���g
    public float junpForce = default;                   // Enemy���W�����v����Ƃ��̗�
    public float moveSpeed = default;                   // Enemy���ړ�����Ƃ��̑��x
    public float plusTransLate = default;�@�@�@�@�@�@�@ // �v���X�����Ƀg�����X����ʂ������Ō��߂�i�l���傫���قǒx���Ȃ�j
    public float minusTransLate = default;              // �}�C�i�X�����Ƀg�����X����ʂ������Ō��߂�i�l���傫���قǒx���Ȃ�j
    public bool isJunp = false;                         // �W�����v�����ǂ���
    public bool isValid = false;                        // �s�������ǂ���
    public bool isEnemyActive = false;                  // Enemy��Player�𔭌����Ă��邩�ǂ���
    public bool isStay = false;                         // �ҋ@�����ǂ���

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
    void Stay()
    {
        
    }

    void Junp()
    {
        if (isJunp) // �����W�����v���Ȃ瑁�����^�[�����s���ď������s��Ȃ��B
        {
            return;
        }
        else // ����ȊO�Ȃ�A�W�����v�������J�n���A�W�����v����true������B
        {
            isJunp = true;
            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, junpForce);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJunp = false;
        }
    }

    void Run()
    {

    }

    void Shot()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == target)
        {
            MeleeAttack();
        }
    }

    void MeleeAttack()
    {
        status.currentHp -= _data.attackPower1;
    }

    void Defence()
    {

    }

    void Accelerate()
    {

    }

    void Attack()
    {

    }

    void Chase()
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

    void Die()
    {
        if(enemyCurrentHP <= 0)
        {
            Destroy(gameObject);
            Reward();
        }
    }

    void Reward()
    {

    }

    private void Reset()
    {
        
    }
}
