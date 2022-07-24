using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemBase item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // �v���C���[���A�C�e���I�u�W�F�N�g�ɐڐG������A�A�C�e�����擾���鏈��
        {
            PlayerStatus player = collision.GetComponent<PlayerStatus>();
            var i = Instantiate(item, collision.gameObject.transform);
            player.AddItem(i);
            Destroy(gameObject);
        }
    }
}
