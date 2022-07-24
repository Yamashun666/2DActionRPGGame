using System;
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
public class ItemScriptableData : ScriptableObject
{
    public string itemName = default;             // �A�C�e���̖��O
    public string itemInfomation = default;       // �A�C�e���̐ݒ�A������
    public int price = default;                   // �������鉿�i�B����̕����g���B�����Ń��[�g�𒲐��������ꍇ�́A�v�Z���̕��Œ�������B
    public int brokenPoint = default;             // �A�C�e���̑ϋv�l�B���ꂪ0�ɂȂ�ƃA�C�e���͉���B
    public int useAmount = default;               // ���A�C�e���������Use�֐����ĂԂ�
    public ItemTypes itemType = default;          // �A�C�e���̎��
    public float effectForce = default;           // float�^�Ō��ʗʂ𒲐�����֗�����
    public Sprite itemIcon;                       // �A�C�e���A�C�R��
}
