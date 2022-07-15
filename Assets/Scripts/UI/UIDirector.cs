using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIDirector : MonoBehaviour
{
    [SerializeField] Slider HPslider;
    [SerializeField] Slider MPslider;
    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] Text player;
    private string hpText;


    //Start is called before the first frame update
    public void Start()
    {
        HPslider.value = 1;
        MPslider.value = 1;
        GetComponent<PlayerStatus>();
        GetComponent<Text>();

    }

    //Update is called once per frame
    void Update()
    {
        HPslider.value = (float)playerStatus.currentHp / (float)  playerStatus.maxHp;
        player.text = playerStatus.currentHp.ToString();

        MPslider.value = (float)playerStatus.currentMp / (float)playerStatus.maxMp;
    }
}
