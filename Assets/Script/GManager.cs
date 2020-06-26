using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour {
    #region ステート
    enum State
    {
        FirstCheck = 1,

        Night,

        Morning,

        DayCheck,

        End

    }
    #endregion

    #region ステート
    enum Chara
    {
        Villager = 1,

        Teller,

        Medium,

        Werewolf,

        Madman
    }
    #endregion



    #region オブジェクト

    public GameObject Selector;

    private Selector selectorscript;

    #endregion

    #region 変数

    State game;


    private int[] chara = new int[6];



    #endregion

    // Use this for initialization
    void Start()
    {
        selectorscript = Selector.GetComponent<Selector>();

        game = State.FirstCheck;
    }

    // Update is called once per frame
    void Update()
    {

        if (!selectorscript.GameState()) return;

        switch (game)
        {
            case State.FirstCheck:
                firstcheck();

                break;

            case State.Night:
                night();

                break;

            case State.Morning:
                morning();

                break;

            case State.DayCheck:
                daycheck();

                break;

            case State.End:
                end();

                break;



        }
    }


    private void firstcheck()
    {
        chara[(int)Chara.Villager] = selectorscript.VL();
        chara[(int)Chara.Teller] = selectorscript.TE();
        chara[(int)Chara.Medium] = selectorscript.ME();
        chara[(int)Chara.Werewolf] = selectorscript.WE();
        chara[(int)Chara.Madman] = selectorscript.MA();


        for (int i = 0; i < selectorscript.PlayerNUM(); i++)
        {

            int who;

            who = DecideRandom();

            while (chara[who] == 0)
            {

                who = DecideRandom();

            }

            chara[who]--;

            //インスタンス作成処理



        }

        game = State.Night;


    }

    private int DecideRandom()
    {
        int n;
        n = Random.Range(1, 5);


        return n;

    }

    private void night()
    {

    }

    private void morning()
    {

    }

    private void daycheck()
    {

    }

    private void end()
    {

    }

}

