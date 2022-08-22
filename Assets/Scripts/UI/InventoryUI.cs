using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public int inventoryNum = default; //���{�^����\���ł��邩
    public InventoryButton buttonPrefab = default; //�����Ƀ{�^����Prafab���A�^�b�`����
    public Transform buttonParent = default;
    private List<InventoryButton> buttonList = new List<InventoryButton>();
    public static InventoryUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUp() //inventoryNum�̐������A�{�^���𐶐�����
    {
        for (int i = 0; i < inventoryNum; i++)
        {
            var b = Instantiate(buttonPrefab, buttonParent);
            buttonList.Add(b);
        }
        gameObject.SetActive(false);
    }

    public void OnListView(List<ItemBase> list) //�X�v���C�g��\��
    {
        foreach (var l in buttonList)
        {
            l._image.sprite = null;
        }
        for (int i = 0; i < list.Count; i++)
        {
            buttonList[i]._image.sprite = list[i].itemData.itemIcon;
        }
    }
}
