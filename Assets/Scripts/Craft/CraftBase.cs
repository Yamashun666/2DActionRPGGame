using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftBase : MonoBehaviour
{
    public PlayerStatus itemList; // 現在取得しているアイテム一覧を参照
    private int itemNum; // 必要なアイテム数
    [SerializeField] GameObject craftUI; //金床側にクラフトメニューをアタッチできるようにする


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("fuck");
            CraftManu();
        }
    }
    //金床がプレイヤーと接触した場合かつ、LeftShiftキーが押された場合、クラフトメニューが開かれる


    private void CraftManu()
    {
        craftUI.gameObject.SetActive(true); //OntriggerEnter2Dしたら、クラフトメニューを表示する。
    }

    private void Craft(ItemBase item)
    {
        itemList.HaveItems.Add(item); // Listにアイテムを追加する
        InventoryUI.Instance.OnListView(itemList.HaveItems); // インベントリを更新する
    }
}
