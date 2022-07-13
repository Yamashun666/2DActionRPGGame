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
    // �G�̎��
    public EnemyType type;
    // Player�Ƃ̋������擾���A�s���𕪊򂷂�t���O�ɂȂ鋗��(Y���W)
    public float DistanceY = 1.0f;
    // Player�Ƃ̋������擾���A�s���𕪊򂷂�t���O�ɂȂ鋗��(X���W)
    public float DistanceX = 1.0f;
    // �G�̍ő�̗�
    public int enemyMaxHP;
    // �G�̍ő�}�W�b�N�|�C���g
    public int enemyMaxMP;
    // Player�𔭌����Ă��邩�ǂ���
    public bool isEnemyActive = false;
    // Enemy�̒ǐՃX�s�[�h
    public float moveSpeed = 10.0f;
}
