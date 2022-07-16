using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private EnemyScriptableData _data; //ScriptableObjact���g�p�����G�l�~�[�f�[�^
    [SerializeField] private GameObject target;         // �ǐ՗p��player.transform.position���󂯎��
    [SerializeField] private PlayerStatus status;       // �Փ˂����Ƃ��Ƀv���C���[��HP�����炷�ׂ̕ϐ�
    SpriteRenderer renderer = default;
    public int   attackPower = default;
    public float plusTransLate = default;�@�@�@�@�@�@�@�@  // �v���X�����Ƀg�����X����ʂ������Ō��߂�i�l���傫���قǒx���Ȃ�j
    public float minusTransLate = default;                 // �}�C�i�X�����Ƀg�����X����ʂ������Ō��߂�i�l���傫���قǒx���Ȃ�j

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
