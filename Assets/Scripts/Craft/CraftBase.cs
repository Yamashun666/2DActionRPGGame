using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftBase : MonoBehaviour
{
    public PlayerStatus itemList; // ���ݎ擾���Ă���A�C�e���ꗗ���Q��
    private int itemNum; // �K�v�ȃA�C�e����
    [SerializeField] GameObject craftUI; //�������ɃN���t�g���j���[���A�^�b�`�ł���悤�ɂ���

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            craftUI.gameObject.SetActive(false);
        }
    }

    //�������v���C���[�ƐڐG�����ꍇ���ALeftShift�L�[�������ꂽ�ꍇ�A�N���t�g���j���[���J�����
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.LeftShift))
        {
            CraftManu();
        }
    }

    //�v���C���[�������𗣂ꂽ��A���j���[������
    private void OnTriggerExit2D(Collider2D collision)
    {
        craftUI.gameObject.SetActive(false);
    }
    //�������v���C���[�ƐڐG�����ꍇ���ALeftShift�L�[�������ꂽ�ꍇ�A�N���t�g���j���[���J�����


    private void CraftManu()
    {
        craftUI.gameObject.SetActive(true); //OntriggerEnter2D������A�N���t�g���j���[��\������B
        if (Input.GetKeyDown(KeyCode.Escape))// Escape�L�[����������A���j���[�����
        {
            craftUI.gameObject.SetActive(false);
        }
    }

    private void Craft(ItemBase item)
    {
        itemList.HaveItems.Add(item); // List�ɃA�C�e����ǉ�����
        InventoryUI.Instance.OnListView(itemList.HaveItems); // �C���x���g�����X�V����
    }
}
