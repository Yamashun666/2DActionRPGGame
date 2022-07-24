using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemBase item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // プレイヤーがアイテムオブジェクトに接触したら、アイテムを取得する処理
        {
            PlayerStatus player = collision.GetComponent<PlayerStatus>();
            var i = Instantiate(item, collision.gameObject.transform);
            player.AddItem(i);
            Destroy(gameObject);
        }
    }
}
