using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public Image _image;
    private Button _button;

    public Button GetButton
    {
        get { return _button; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
    }
}
