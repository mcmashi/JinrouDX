using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GManager : MonoBehaviour {
    #region ステート
    enum State
    {
        FirstCheck = 1,

        Secondque,

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

    public GameObject prefabP;

    private GameObject[] Player = new GameObject[7];

    public GameObject CheckPanel;

    public Text firsttext;


    #endregion

    #region 変数

    State game;


    private int[] chara = new int[6];

    private int checkcount = 1;

    private bool fcheck = false;



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

            case State.Secondque:
                secondque();
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

        int playernumber = 0;

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
                    playernumber++;
                    GameObject InstanceP = (GameObject)Instantiate(prefabP, new Vector3(0,0,0), Quaternion.identity);
                    Player player = InstanceP.GetComponent<Player>();
                    player.CreatePlayer(who,playernumber);

            Player[i+1] = InstanceP;
                    




        }

        CheckPanel.SetActive(true);
        game = State.Secondque;


    }

    private int DecideRandom()
    {
        int n;
        n = Random.Range(0, 6);


        return n;

    }

    private void secondque()
    {
        int count = checkcount;
        count = Mathf.Min(count, selectorscript.PlayerNUM());

        Player player = Player[count].GetComponent<Player>();


        if(!fcheck)
        {

            firsttext.text = "あたなは　" + player.pname + "ですか？";


        }else{
            firsttext.text = "あたなは　" + player.wname + "です。";

        }



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

    public void DisplayChara()
    {

        if (fcheck)
        {
            fcheck = false;

            checkcount++;

            if (checkcount > selectorscript.PlayerNUM())
            {
                CheckPanel.SetActive(false);
                game = State.Night;
            }

        }
        else
        {
            fcheck = true;

        }


    }

}

