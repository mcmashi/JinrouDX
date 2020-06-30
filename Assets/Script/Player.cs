using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region 役職
    enum Chara
    {
        Villager = 1,

        Teller,

        Medium,

        Werewolf,

        Madman
    }
    #endregion
    #region 変数

     Chara chara;

    public int PlayerNumber = 0;

    public bool Person = true;

    public bool Enemy = false;

    public string pname;

    public string wname;

    #endregion




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreatePlayer(int work,int number)
    {
        chara = (Chara)work;

        PlayerNumber = number;

        if(work >= 1 && work <= 3)
        {
            Person = true;
        }else{
            Person = false;
            Enemy = true;
        }

        pname = "Player0" + number;

        switch (chara)
        {
            case Chara.Villager:
                wname = "村人";
                break;

            case Chara.Teller:
                wname = "占い師";
                break;

            case Chara.Medium:
                wname = "霊媒師";
                break;

            case Chara.Werewolf:
                wname = "人狼";
                break;

            case Chara.Madman:
                wname = "狂人";
                break;



        }


    }

    public void NightWork()
    {
        switch(chara)
        {
            case Chara.Villager:

                break;

            case Chara.Teller:

                break;

            case Chara.Medium:

                break;

            case Chara.Werewolf:

                break;

            case Chara.Madman:

                break;

        }


    }


}

