using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIDirector : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] Text playerHP;
    private string hpText;


    //Start is called before the first frame update
    public void Start()
    {
        slider.value = 1;
        GetComponent<PlayerStatus>();
        GetComponent<Text>();

    }

    //Update is called once per frame
    void Update()
    {
        slider.value = (float)playerStatus.currentHp / (float)  playerStatus.maxHp;
        playerHP.text = playerStatus.currentHp.ToString();
    }
}
