using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftBase : MonoBehaviour
{
    public PlayerStatus itemList; // ���ݎ擾���Ă���A�C�e���ꗗ���Q��
    private int itemNum; // �K�v�ȃA�C�e����
    [SerializeField] GameObject craftUI; //�������ɃN���t�g���j���[���A�^�b�`�ł���悤�ɂ���


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("fuck");
            CraftManu();
        }
    }
    //�������v���C���[�ƐڐG�����ꍇ���ALeftShift�L�[�������ꂽ�ꍇ�A�N���t�g���j���[���J�����


    private void CraftManu()
    {
        craftUI.gameObject.SetActive(true); //OntriggerEnter2D������A�N���t�g���j���[��\������B
    }

    private void Craft(ItemBase item)
    {
        itemList.HaveItems.Add(item); // List�ɃA�C�e����ǉ�����
        InventoryUI.Instance.OnListView(itemList.HaveItems); // �C���x���g�����X�V����
    }
}
