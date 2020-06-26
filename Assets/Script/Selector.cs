using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    #region オブジェクト
    public Dropdown PlayerNum;//プレイヤー人数

    public Dropdown Villager;//村人
    public Dropdown Teller;//占い師
    public Dropdown Medium;//霊媒師
    public Dropdown Werewolf;//人狼
    public Dropdown Madman;//狂人

    public GameObject SelectPanel;

    #endregion

    #region 変数

    private bool SettingComplete = false;

    private int PlayerALLNum = 0;
    private int PersonNum = 0;

        private int Vl;
        private int Te;
        private int Me;
        private int We;
        private int Ma;


    #endregion

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SettingComplete) return;
        PlayerALLNum = PlayerNum.value + 3;

        PersonNum = Villager.value + Teller.value + Medium.value + Madman.value;

        Vl = Villager.value;
        Te = Teller.value;
        Me = Medium.value;
        We = Werewolf.value;
        Ma = Madman.value;


    }

    public void GameStart()
    {

        if (PersonNum <= Werewolf.value) return;

        if (Werewolf.value == 0) return;

        if (PlayerALLNum != PersonNum + Werewolf.value) return;



        SelectPanel.SetActive(false);
        SettingComplete = true;
    }

    public bool GameState()
    {
        return SettingComplete;
    }

    public int VL()
    {
        return Vl; 
    }

    public int TE()
    {
        return Te;
    }

    public int ME()
    {
        return Me;
    }

    public int WE()
    {
        return We;
    }

    public int MA()
    {
        return Ma;
    }

    public int PlayerNUM()
    {
        return PlayerALLNum;

    }



}

