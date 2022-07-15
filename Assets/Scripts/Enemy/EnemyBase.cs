using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private EnemyScriptableData _data; //ScriptableObjact���g�p�����G�l�~�[�f�[�^
    [SerializeField] private GameObject player;
    public float enemyCurrentHP = default;              // Enemy�̌��ݑ̗�
    public float enemyCurrentMP = default;              // Enemy�̌��݃}�W�b�N�|�C���g
    public bool _isEnemyActive = false;                // Enemy��Player�𔭌����Ă��邩�ǂ���

    void Start()
    {
        enemyCurrentHP = _data.enemyMaxHP;
        enemyCurrentMP = _data.enemyMaxMP;

    }

    public virtual void OnActive()                      // Player�ƈ�苗���ɂȂ����ꍇ�APlayer�𔭌����鏈��������B
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

//public virtual void OnBattle()                      //Player�𔭌�������A�퓬�J�n���鏈��������B
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
