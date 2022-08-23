using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftBase : MonoBehaviour
{
    public PlayerStatus itemList; // 現在取得しているアイテム一覧を参照
    private int itemNum; // 必要なアイテム数
    [SerializeField] GameObject craftUI; //金床側にクラフトメニューをアタッチできるようにする

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            craftUI.gameObject.SetActive(false);
        }
    }

    //金床がプレイヤーと接触した場合かつ、LeftShiftキーが押された場合、クラフトメニューが開かれる
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.LeftShift))
        {
            CraftManu();
        }
    }

    //プレイヤーが金床を離れたら、メニューを消す
    private void OnTriggerExit2D(Collider2D collision)
    {
        craftUI.gameObject.SetActive(false);
    }
    //金床がプレイヤーと接触した場合かつ、LeftShiftキーが押された場合、クラフトメニューが開かれる


    private void CraftManu()
    {
        craftUI.gameObject.SetActive(true); //OntriggerEnter2Dしたら、クラフトメニューを表示する。
        if (Input.GetKeyDown(KeyCode.Escape))// Escapeキーを押したら、メニューを閉じる
        {
            craftUI.gameObject.SetActive(false);
        }
    }

    private void Craft(ItemBase item)
    {
        itemList.HaveItems.Add(item); // Listにアイテムを追加する
        InventoryUI.Instance.OnListView(itemList.HaveItems); // インベントリを更新する
    }
}
