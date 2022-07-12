using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{   //ScriptableObjact���g�p�����G�l�~�[�f�[�^
    [SerializeField] private EnemyScriptableData _data;
    [SerializeField] public PlayerStatus _player;
    [SerializeField] public EnemyPositionGetter _enemyController;


    
    // Enemy�̌��ݑ̗�
    private float _enemyCurrentHP;
    // Enemy�̌��݃}�W�b�N�|�C���g
    private float _enemyMaxHP;
    // Enemy��Player�𔭌����Ă��邩�ǂ���
    private bool _isEnemyActive = false;

    // Player�ƈ�苗���ɂȂ����ꍇ�APlayer�𔭌����鏈��������B
    public virtual void OnActive()
    {
        // Player�Ƃ̋���
        float rangeY = _player.transform.position.y - _enemyController.transform.position.y;
        float rangeX = _player.transform.position.x - _enemyController.transform.position.x;



        //Player�Ƃ̋��������ȉ��Ȃ�A_isEnemyActive��true�ɂ���
       if(rangeX <= _data.rangeX && rangeY <= _data.rangeY)
        {
            _isEnemyActive = true;
        }
    }

    //Player�𔭌�������A�퓬�J�n���鏈��������B
    public virtual void OnBattle()
    {
        if (_isEnemyActive)
        {

        }
    }
}
