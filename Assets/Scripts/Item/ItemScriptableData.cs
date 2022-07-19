using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Potion,
    Material,
    Weapon,
    Buff,
    Armor,
    Throw,
}
[CreateAssetMenu(menuName = "MyScriptable/Create ItemData")]
public class ItemScriptableData : ScriptableObject
{
    public string itemName = default;             // �A�C�e���̖��O
    public string itemFlavourText = default;      //�A�C�e���̐ݒ�ȂǁA�t���[�o�[�e�L�X�g
    public int price = default;                   //�������鉿�i�B����̕����g���B�����Ń��[�g�𒲐��������ꍇ�́A�v�Z���̕��Œ�������B
    public int brokenPoint = default;             //�A�C�e���̑ϋv�l�B���ꂪ0�ɂȂ�ƃA�C�e���͉���B
    public int throwDamage = default;             //�����_���[�W���Փ˂����Ƃ��ɗ^����_���[�W
    public int useAmount = default;               // ���A�C�e���������Use�֐����ĂԂ�
    public ItemTypes itemType = default;          // �A�C�e���̎��
    public int effectForceIntType = default;      // int�^�Ō��ʗʂ𒲐��ł���֗�����
    public float effectForceFloatType = default;  //float�^�Ō��ʗʂ𒲐�����֗�����


}
