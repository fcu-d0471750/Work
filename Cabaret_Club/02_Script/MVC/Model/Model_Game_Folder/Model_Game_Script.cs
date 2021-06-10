/*
 * Model:管理GameScene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Model_Game_Script : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //GameScene_Control_Script : 用於Model_Game_Script和View_Game_Script之間的溝通
    public GameScene_Control_Script control;

    //用於讀取存在View_Game_Script底下的GVU的Lady大頭照，用於測試用
    public View_Game_Script VGS;

    //GameConsole_Class : 結算
    private GameConsole_Class GameConsole = new GameConsole_Class();

    //SaveGame_Class : 存檔
    private GameSave gamesave = new GameSave();

    //LadySeat : 出勤小姐
    private LadySeat_Class Ladyseat;

    //Customer_Script : 生成客人
    private Customer_Script AllCustomer = new Customer_Script();

    //CustomerSeat : 客人座位，共6個
    private CustomerSeat_Class[] CustomerSeat = new CustomerSeat_Class[6];

    //gameSituation_script : 生成問題、爭執、結帳事件
    private GameSituation_Script gameSituation_script = new GameSituation_Script();

    //GameSituation : 問題事件
    private GameSituation_Class GameSituation = new GameSituation_Class();

    //GameArgue : 爭執事件
    private GameArgue_Class GameArgue = new GameArgue_Class();

    //GameCalculation : 結帳事件
    private GameCalculation_Class GameCalculation = new GameCalculation_Class();

    //Fever_Script : Fever
    private Fever_Script Fever = new Fever_Script();

    //GamePause_Script : 遊戲暫停
    private GamePause_Script GamePause = new GamePause_Script();

    //int : 現在選擇的CustomerSeat的id，預設-1表示沒有選擇
    private int Now_CustomerSeat_id = -1;

    //int : 現在選擇的LadySeat的id，預設-1表示沒有選擇
    private int Now_LadySeat_id = -1;

    //int : 暫存選擇的CustomerSeat的id，預設-1表示沒有選擇，用於選擇小姐時計算Customer的Emotion
    private int Temp_CustomerSeat_id = -1;

    //int : 暫存選擇的LadySeat的id，預設-1表示沒有選擇，用於選擇小姐時計算Customer的Emotion
    private int Temp_LadySeat_id = -1;


    //迴圈用
    private int i, j;

    //==================
    //Time
    //==================

    //float : 遊玩時間
    private float GameTime = 30.0f;

    //flaot : 生成顧客時間;
    private float CreateCustomerTime = 5.0f;

    //==================
    //State
    //==================

    //int : 現在狀態，預設10表示遊玩狀態
    private int Now_State = 10;

   

    // Awake is called before Start
    void Awake()
    {
        //==================
        //新建客人座位
        //==================
        CustomerSeat[0] = new CustomerSeat_Class(0);
        CustomerSeat[1] = new CustomerSeat_Class(1);
        CustomerSeat[2] = new CustomerSeat_Class(2);
        CustomerSeat[3] = new CustomerSeat_Class(3);
        CustomerSeat[4] = new CustomerSeat_Class(4);
        CustomerSeat[5] = new CustomerSeat_Class(5);

        //==================
        //新建客人
        //==================
        Customer_Class customer = new Customer_Class();

        //==================
        //新建Lady
        //==================
        Lady_Class[] Lady = new Lady_Class[8];
        Lady[0] = new Lady_Class();
        Lady[1] = new Lady_Class();
        Lady[2] = new Lady_Class();
        Lady[3] = new Lady_Class();
        Lady[4] = new Lady_Class();
        Lady[5] = new Lady_Class();
        Lady[6] = new Lady_Class();
        Lady[7] = new Lady_Class();

        //==================
        //讀檔
        //==================
        gamesave.DoLoad_GameScene(Lady );

        //==================
        //新建Ladyseat
        //==================
        Ladyseat = new LadySeat_Class(Lady);
    
        //更新View，LadySeat
        control.SetLadySeat_HeadShot(Ladyseat);
        //更新View，LadySeat的HpImage的FillAmount
        control.SetLadySeat_Hp_Bar_Image_FillAmount(Ladyseat);
       
    }

    // Update is called once per frame
    void Update()
    {

        switch (Now_State)
        {
            //======================================================
            //遊玩狀態 Now_State = 10
            //======================================================
            case 10:


                //============
                //計算遊玩時間
                //============   
                CalGameTime();

                //============
                //生成Customer
                //============
                CalCustomer();

                //============
                //計算CustomerSeat的等待時間
                //============
                CalCustomerSeatWaitTime();

                //============
                //生成問題、爭執事件
                //============
                CalGameSituationTime();

                //============
                //生成結帳事件
                //============
                CreateGameCalculation();

                //============
                //計算Fever
                //============            
                CalFever();

                //============
                //遊戲暫停
                //============ 
                if (Input.GetKey("escape")) DoPauseOpen();
             
                break;
            //======================================================
            //選擇小姐狀態 Now_State = 11
            //======================================================
            case 11:
                break;
            //======================================================
            //小姐選擇完成狀態 Now_State = 12
            //======================================================
            case 12:
                {
                    //如果CustomerSeat上沒有Lady
                    if (CustomerSeat[Now_CustomerSeat_id].GetisLady() == false)
                    {

                        CustomerSeatSetLady();
                    }
                    //如果CustomerSeat上有Lady
                    else
                    {
                        CustomerSeatChangeLady();
                    }

                    //恢復成遊玩狀態
                    Now_State = 10;
                     
                    break;
                }
            //======================================================
            //暫停狀態 Now_State = 16
            //======================================================
            case 16:
                break;

            //======================================================
            //結算狀態 Now_State = 17
            //======================================================
            case 17:
                break;

            //======================================================
            //default
            //======================================================
            default:
                break;

        }//swithch

       
    }//Update




    //======================================================
    //內部方法(新建物件)
    //======================================================

    //======================================================
    //內部方法
    //======================================================

    //============
    //計算生成問題、爭執事件
    //============
    private void CalGameSituationTime() {

        //計算事件生成時間
        if (gameSituation_script.GetisCreate() == false) gameSituation_script.SetCalTime(gameSituation_script.GetCalTime() + Time.deltaTime);

        //如果超過事件生成時間，可以生成事件
        if (gameSituation_script.GetCalTime() >= gameSituation_script.GetCreateTime())
        {
            //可以產生事件
            gameSituation_script.SetisCreate(true);
            //計算生成時間歸0
            gameSituation_script.SetCalTime(0.0f);
            //生成問題、爭執事件
            CreateGameSituation();
        }//if

    }

    //============
    //生成問題、爭執事件
    //============
    private void CreateGameSituation() {

        //發生事件的CustomerSeat的id
        int id = -1;
        //事件編號
        int Number = 0;
        //重新找CustomerSeat的次數，最多6次，防止無限迴圈
        int Search = 6;

        //隨機選出有客人且有Lady的CustomerSeat，發生事件
        while (id == -1 && Search > 0)
        {
            //隨機選擇編號(範圍含最小值，不含最大值)
            id = Random.Range(0, CustomerSeat.Length);

            //如果沒有結帳 且 沒有任何事件產生 且 CustomerSeat上有客人和Lady 且 客人Emotion<=20，則CustomerSeat產生爭執事件
            if (CustomerSeat[id].GetisCheckout() == false && (CustomerSeat[id].GetisExclamation() == false && CustomerSeat[id].GetisArgue() == false) && (CustomerSeat[id].GetisGame() == true && CustomerSeat[id].GetisLady() == true) && CustomerSeat[id].GetCustomer().GetEmotion() <= 20)
            {
                //發生爭執
                CustomerSeat[id].SetisArgue(true);

                //隨機挑選爭執事件
                Number = Random.Range(0, gameSituation_script.GetAllGameArgue().Length);
                //設定爭執事件
                GameArgue = gameSituation_script.GetGameArgue(Number);


                //可以再生成問題、爭執事件
                gameSituation_script.SetisCreate(false);

                //更新View，設定問題、爭執、結帳事件的事件圖(Code : 問題事件、爭執事件、結帳事件 ， id : 事件編號)
                control.SetGameSituation_Code_Sprite(1, Number);
                //更新View，設定爭執事件的題目(Text)
                control.SetGameSituation_CodeAnswer_Text(GameArgue);
                //更新View，設定爭執事件的選項(Text)
                control.SetGameSituation_Answer_Text(GameArgue);


                //更新View，設定CustomerSeat的Situation為發生爭執事件
                control.SetCustomerSeat_Situation_Text(CustomerSeat[id]);
                //更新View，開啟爭執事件Button
                control.SetCustomer_Exclamation_Button_interactable(CustomerSeat[id]);
                //更新View，關閉上Lady的Button的interactable 
                control.SetCustomerSeatLady_Button_interactable(CustomerSeat[id]);
                //更新View，設訂GameInformation的Text為(號桌發生爭執)
                control.SetGameInformation_Text((id + 1) + "號桌發生爭執。");

            }//if
            //如果沒有結帳 且 沒有任何事件產生 且 CustomerSeat上有客人和Lady且客人Emotion > 20，則CustomerSeat產生問題事件
            else if (CustomerSeat[id].GetisCheckout() == false && (CustomerSeat[id].GetisExclamation() == false && CustomerSeat[id].GetisArgue() == false) && CustomerSeat[id].GetisGame() == true && CustomerSeat[id].GetisLady() == true)
            {
                //發生問題事件
                CustomerSeat[id].SetisExclamation(true);

                //隨機挑選問題事件
                Number = Random.Range(0, gameSituation_script.GetAllGameSituation().Length);
                //設定問題事件
                GameSituation = gameSituation_script.GetGameSituation(Number);


                //可以再生成問題、爭執事件
                gameSituation_script.SetisCreate(false);

                //更新View，設定問題、爭執、結帳事件的事件圖(Code : 問題事件、爭執事件、結帳事件 ， id : 事件編號)
                control.SetGameSituation_Code_Sprite(0, Number);
                //更新View，設定問題事件的題目(Text)
                control.SetGameSituation_CodeAnswer_Text(GameSituation);
                //更新View，設定問題事件的選項(Text)
                control.SetGameSituation_Answer_Text(GameSituation);

                //更新View，設定CustomerSeat的Situation為發生問題事件
                control.SetCustomerSeat_Situation_Text(CustomerSeat[id]);
                //更新View，開啟問題事件Button
                control.SetCustomer_Exclamation_Button_interactable(CustomerSeat[id]);
                //更新View，關閉上Lady的Button的interactable 
                control.SetCustomerSeatLady_Button_interactable(CustomerSeat[id]);
                //更新View，設訂GameInformation的Text為(號桌需要幫忙)
                control.SetGameInformation_Text((id + 1) + "號桌需要幫忙。");

            }// else if
            //如果都沒有，表示不符合產生事件的條件，重新找出id
            else {
                //重新恢復成-1，表示重新尋找
                id = -1;
                //減少1次搜尋次數
                Search = Search - 1;

            }//else

        }//while

        //可以再生成問題、爭執事件
        gameSituation_script.SetisCreate(false);

    }


    //============
    //生成結帳事件
    //============
    private void CreateGameCalculation()
    {
        //事件編號
        int Number = 0;

        //檢查是否有CustomerSeat要結帳
        for (i = 0; i < CustomerSeat.Length; i++) {
            //如果CustomerSeat有客人 且 有Lady，則開始扣除遊玩時間，直到遊玩時間歸0
            if (CustomerSeat[i].GetisGame() == true && CustomerSeat[i].GetisLady() == true && CustomerSeat[i].GetGameTime() > 0.0f)
            {
                //開始扣除遊玩時間、獲得營收時間，直到遊玩時間歸0             
                CustomerSeat[i].DoGame_SubGameTime();

                //如果獲得營收時間 <= 0.0f，則增加營收
                if (CustomerSeat[i].GetIncomeTime() <= 0.0f) CustomerSeat[i].Calincome();

                //扣除Lady的Hp
                CustomerSeat[i].GetLady().DoGame_SubHp();

            }//if 

            //如果遊玩時間歸0，則代表可以進行結帳
            else if (CustomerSeat[i].GetisGame() == true && CustomerSeat[i].GetisLady() == true && CustomerSeat[i] .GetisCheckout() == false && CustomerSeat[i].GetGameTime() <= 0.0f)
            {
                //產生結帳事件
                CustomerSeat[i].SetisCheckout(true);
                //隨機挑選結帳事件
                Number = Random.Range(0, gameSituation_script.GetAllGameCalculation().Length);
                //設定結帳事件
                GameCalculation = gameSituation_script.GetGameCalculation(Number);

                //設定不產生問題事件
                CustomerSeat[i].SetisExclamation(false);
                //設定不產生爭執事件
                CustomerSeat[i].SetisArgue(false);

                //更新View，設定問題、爭執、結帳事件的事件圖(Code : 問題事件、爭執事件、結帳事件 ， id : 事件編號)
                control.SetGameSituation_Code_Sprite(2, Number);


                //更新View，設定CustomerSeat的Situation為發生結帳事件
                control.SetCustomerSeat_Situation_Text(CustomerSeat[i]);
                //更新View，開啟結帳事件Button
                control.SetCustomer_Checkout_Button_interactable(CustomerSeat[i]);
                //更新View，關閉問題、爭執事件Button
                control.SetCustomer_Exclamation_Button_interactable(CustomerSeat[i]);
                //更新View，關閉上Lady的Button的interactable 
                control.SetCustomerSeatLady_Button_interactable(CustomerSeat[i]);
                //更新View，設訂GameInformation的Text為(號桌可以結帳了)
                control.SetGameInformation_Text((i + 1) + "號桌可以結帳了。");

            }//else if 
        }//for 

        //更新View，設定結帳事件的題目(Text)
        control.SetGameSituation_CodeAnswer_Text(GameCalculation);
        //更新View，設定結帳事件的選項(Text)
        control.SetGameSituation_Answer_Text(GameCalculation);

        //更新View，扣除CustoemrSeat的遊玩時間Time
        control.SetAllCustomerSeat_CostTime_Image(CustomerSeat);

    }

    //============
    //計算生成Customer時間
    //============
    private void CalCustomer()
    {
        //如果未到生成Customer的時間，則繼續扣除CreateCustomerTime
        if (CreateCustomerTime > 0.0f) CreateCustomerTime = CreateCustomerTime - Time.deltaTime;
        //如果到達Customer生成時間，則依條件生成Customer
        else CreateCustomer();
    }

    //============
    //生成Customer
    //============
    private void CreateCustomer() {

        //找出哪一個CustomerSeat沒有客人
        for (i = 0; i < CustomerSeat.Length; i++) {
            //如果有找到CustomerSeat沒有客人，則生成Customer
            if (CustomerSeat[i].GetisGame() == false) {
                //CustomerSeat設定生成的Customer
                CustomerSeat[i].SetCustomerinSeat(AllCustomer.CreateCustomer());

                //更新View，CustomerSeat的等待照
                control.SetCustomerSeat_CustomerHeadShot(CustomerSeat[i]);
                //更新View，修改CustoemrSeat的喜好Ability、Range、喜好Ability的Outline顏色
                control.SetCustomerSeat_Ability_Range_Text(CustomerSeat[i]);
                //更新View，開啟上Lady的Button的interactable 
                control.SetCustomerSeatLady_Button_interactable(CustomerSeat[i]);
                //更新View，設訂GameInformation的Text為(幾號桌有客人)
                control.SetGameInformation_Text((i+1) + "號桌有客人。");

                //跳離迴圈，不用再找哪一個CustomerSeat沒有客人
                break;
            }
        }//for

        //不論有沒有生成Customer，都重新計算CreateCustomerTime
        CreateCustomerTime = 5.0f;
    }

    //============
    //計算CustomerSeat等待時間
    //============
    private void CalCustomerSeatWaitTime() {
        //找出哪一個CustomerSeat有客人
        for (i = 0; i < CustomerSeat.Length; i++)
        {
            //如果有找到CustomerSeat有客人但沒有Lady，則開始扣除等待時間
            if (CustomerSeat[i].GetisGame() == true && CustomerSeat[i].GetisLady() == false && CustomerSeat[i].GetWaitTime() > 0.0f)
            {
                //CustomerSeat開始扣除等待時間
                CustomerSeat[i].DoGame_SubWaitTime();

                //更新View，扣除CustoemrSeat的等待時間
                control.SetCustomerSeat_WaitTime_Image(CustomerSeat[i]);

                //如果超過等待時間沒有安排Lady則Customer離開
                if (CustomerSeat[i].GetWaitTime() <= 0.0f) {
                    //設定Customer離開
                    CustomerSeat[i].SetCustomerleave();

                    //更新View，關閉上Lady的Button的interactable 
                    control.SetCustomerSeatLady_Button_interactable(CustomerSeat[i]);

                    //更新View，清空CustomerSeat的Range(Text)、喜好Ability(Text)、Situation(Text)、Ability的Outline顏色(Color)
                    control.SetCustomerSeat_Range_Ability_Situation_Clear(CustomerSeat[i]);
                    //更新View，CustomerSeat的心情照為空白
                    control.SetCustomerSeat_CustomerHeadShot(CustomerSeat[i]);
                    //更新View，設訂GameInformation的Text為(幾號桌有客人)
                    control.SetGameInformation_Text((i + 1) + "號桌的客人離開了。");
                }
            }


        }//for
    }


    //============
    //計算Fever
    //============
    private void CalFever()
    {
        //增加FeverEnergy
        Fever.AddFeverEnergy();

        //如果使用Fever，計算Fever剩餘使用時間
        if (Fever.GetisuseFever() == true) Fever.SubFeverTime();

        //更新View，一次修改GameFever
        control.SetGameFever(Fever.GetFeverEnergy(), Fever.GetisFever());
    }

    //============
    //計算遊玩剩餘時間
    //============
    private void CalGameTime()
    {
        //計算遊玩剩餘時間
        GameTime = GameTime - Time.deltaTime;

        //Ladyseat上的Lady恢復Hp
        Ladyseat.CalLadySeatHp();

        //更新View，遊玩時間  
        control.SetGameTime_Text(GameTime);


        //如果遊玩剩餘時間為0，則進入結算狀態
        if (GameTime <= 0.0f)
        {
            //進入結算狀態
            Now_State = 17;
            //GameTime設為0.0f
            GameTime = 0.0f;

            //進行結算
            GameConsole.DoConsole(CustomerSeat, Ladyseat);

            //更新View，遊戲結算
            DoGameConsole_UpdateView();
        }
    }



    //============
    //如果CustomerSeat上沒有Lady
    //============
    private void CustomerSeatSetLady() {
        //設定Lady到CustomerSeat
        CustomerSeat[Now_CustomerSeat_id].SetLadyinSeat(Ladyseat.SetLadyToCustomerSeat(Now_LadySeat_id), GameConsole);

        //更新View，LadySeat的HeadShot
        control.SetLadySeat_HeadShot(Ladyseat);
        //更新View，CustomerSeat上的Lady的大頭照
        control.SetCustomerSeat_LadyHeadShot(CustomerSeat[Now_CustomerSeat_id]);
        //更新View，LadySeat的HpImage的FillAmount
        control.SetLadySeat_Hp_Bar_Image_FillAmount(Ladyseat);
        //更新View，一次修改小視窗(GameAbility)
        control.SetGameAbility(CustomerSeat[Now_CustomerSeat_id].GetLady());
        //更新View，CustomerSeat上的等待Bar_Image
        control.SetCustomerSeat_WaitTime_Image(CustomerSeat[Now_CustomerSeat_id]);
        //更新View，CustomerSeat的心情照
        control.SetCustomerSeat_CustomerHeadShot(CustomerSeat[Now_CustomerSeat_id]);


    }

    //============
    //如果CustomerSeat上有Lady
    //============
    private void CustomerSeatChangeLady()
    {
        //設定Lady交換
        CustomerSeat[Now_CustomerSeat_id].SetLadyinSeatChange(Ladyseat.SetLadyChangeCustomerSeat(Now_LadySeat_id, CustomerSeat[Now_CustomerSeat_id].GetLady()));

        //更新View，LadySeat的HeadShot
        control.SetLadySeat_HeadShot(Ladyseat);
        //更新View，CustomerSeat上的Lady的大頭照
        control.SetCustomerSeat_LadyHeadShot(CustomerSeat[Now_CustomerSeat_id]);
        //更新View，LadySeat的HpImage的FillAmount
        control.SetLadySeat_Hp_Bar_Image_FillAmount(Ladyseat);
        //更新View，一次修改小視窗(GameAbility)
        control.SetGameAbility(CustomerSeat[Now_CustomerSeat_id].GetLady());
        //更新View，CustomerSeat的心情照
        control.SetCustomerSeat_CustomerHeadShot(CustomerSeat[Now_CustomerSeat_id]);

    }

    //============
    //
    //============

    //======================================================
    //內部方法(更新View)
    //======================================================

    //============
    //事件選項(更新View)(id : CustomerSeat的id)
    //============
    private void DoSituationChoose_UpdateView(int id) {
        //更新View，一次修改SetAllGameBasePosition到畫面中
        control.SetAllGameBasePosition(0.0f, 0.0f, 0.0f);
        //更新View，一次修改GameSituation的Position到畫面外
        control.SetAllGameSituationPosition(100.0f, 0.0f, 0.0f);

        //更新View，LadySeat的HeadShot
        control.SetLadySeat_HeadShot(Ladyseat);
        //更新View，CustomerSeat上的Lady的大頭照
        control.SetCustomerSeat_LadyHeadShot(CustomerSeat[id]);
        //更新View，LadySeat的HpImage的FillAmount
        control.SetLadySeat_Hp_Bar_Image_FillAmount(Ladyseat);
        //更新View，CustomerSeat的心情照
        control.SetCustomerSeat_CustomerHeadShot(CustomerSeat[id]);
        //更新View，關閉CustoemrSeat上Lady的Button
        control.SetCustomerSeatLady_Button_interactable(CustomerSeat[id]);
        //更新View，關閉CustomerSeat有問題、爭執事件的Button
        control.SetCustomer_Exclamation_Button_interactable(CustomerSeat[id]);
        //更新View，關閉CustomerSeat有結帳事件的Button
        control.SetCustomer_Checkout_Button_interactable(CustomerSeat[id]);

        //更新View，清空CustomerSeat的Situation(Text)
        control.SetCustomerSeat_Situation_Text(CustomerSeat[id]);

        //更新View，清空問題、爭執、結帳事件的結果圖 和 問題、爭執、結帳事件的結果 
        control.SetGameSituation_Award_CodeAnswer_Clear();
    }

    //============
    //遊戲結算(更新View)
    //============
    private void DoGameConsole_UpdateView()
    {
        //更新View，一次修改GameConsole的Position到畫面中
        control.SetAllGameConsolePosition(0.0f, 0.0f, 0.0f);
        //更新View，一次修改SetAllGameBasePosition到畫面外
        control.SetAllGameBasePosition(100.0f, 0.0f, 0.0f);

        //更新View，一次修改GameConsole
        control.SetAllGameConsole(GameConsole, Ladyseat);

    }

    //============
    //遊戲暫停(更新View)
    //============
    private void DoPauseOpen() {
        //更新View，一次修改SetAllGamePausePosition到畫面中
        control.SetAllGamePausePosition(0.0f, 0.0f, 0.0f);
        //更新View，一次修改GameBase的Position到畫面外
        control.SetAllGameBasePosition(100.0f, 0.0f, 0.0f);

        //進入暫停狀態
        Now_State = 16;
    }


    //======================================================
    //外部方法(EventTrigger更新View)
    //======================================================

    //============
    //遊戲小視窗(放於LadySeat，更新View)(id : LadySeat的id)
    //============
    public void DoGameAbility_LadySeat_UpdateView(int id)
    {
        //Point進入，更新View，小視窗(GameAbility)
        if (Ladyseat.GetisLadySeat(id) == false) control.SetGameAbility(Ladyseat.GetLady(id));
        
    }

    //============
    //清空遊戲小視窗(放於LadySeat，更新View)
    //============
    public void DoGameAbility_LadySeat_UpdateView_Clear()
    {
        //Point離開，更新View，清空小視窗(GameAbility)
        control.SetGameAbility_Clear();
    }

    //============
    //CustomerSeat的遊戲小視窗、GameCustomerInformation、GameEarnMoney(放於CustomerSeat，更新View)(id : CustomerSeat的id)
    //============
    public void DoCustomerInformation_GameEarnMoney_CustomerSeat_UpdateView(int id)
    {
        //如果CustoemrSeat有Custoemr，Point進入，更新View，更新GameCustomerInformation、GameEarnMoney
        if (CustomerSeat[id].GetisGame() == true) {

            //一次修改GameCustomerInformation
            control.SetGameCustomerInformation(CustomerSeat[id]);

            //如果CustoemrSeat有Lady，Point進入，更新View，更新小視窗(GameAbility)
            if (CustomerSeat[id].GetisLady() == true)
            {
                //一次修改SetGameAbility
                control.SetGameAbility(CustomerSeat[id].GetLady());
            }
        }

        //一次修改GameEarnMoney
        control.SetGameEarnMoney_SeatNumber_MoneyRevenue_Text(CustomerSeat[id]);
    }


    //============
    //清空CustomerSeat的遊戲小視窗、GameCustomerInformation、GameEarnMoney(放於CustomerSeat，更新View)
    //============
    public void DoCustomerInformation_GameEarnMoney_CustomerSeat_UpdateView_Clear()
    {
        //如果是遊玩狀態，防止選擇小姐狀態時，不知道Customer的Information，一次清空GameCustomerInformation
        if (Now_State == 10) control.SetGameCustomerInformation_Clear();
        //如果是遊玩狀態，防止選擇小姐狀態時，不知道Customer的Information，一次清空GameEarnMoney的SeatNumber、MoneyRevenue
        if (Now_State == 10) control.SetGameEarnMoney_SeatNumber_MoneyRevenue_Text_Clear();
        //Point離開，更新View，清空小視窗(GameAbility)
        control.SetGameAbility_Clear();
    }

    //============
    //CustomerSeat的心情圖(放於CustomerSeat，更新View)(id : LadySeat的id)
    //============
    public void DoCustomerEmotion_CustomerSeat_UpdateView(int id)
    {
        //選擇小姐狀態執行
        if ( Now_State == 11)
        {

            //暫存計算的Emotion
            int EmotionTemp = 0;
            //暫存指定的CustomerSeat的Customer
            Customer_Class Temp_Customer = new Customer_Class();
            //設定Temp_Customer
            Temp_Customer = CustomerSeat[Temp_CustomerSeat_id].GetCustomer();

            //設定暫存選擇的LadySeat的id
            SetTemp_LadySeat_id(id);

            //如果Ladyseat上有Lady，則計算Emotion
            if (Ladyseat.GetisLadySeat(Temp_LadySeat_id) == false)
            {
                //計算的Emotion
                Temp_Customer.SetEmotion(Ladyseat.GetLady(Temp_LadySeat_id));
                //設定Emotion
                EmotionTemp = Temp_Customer.GetEmotion();

                //更新View，CustomerSeat的暫存心情照
                control.SetTempCustomerSeat_CustomerHeadShot(EmotionTemp, Temp_CustomerSeat_id);
            }

            
        }
    }

    //============
    //恢復CustomerSeat的心情圖(放於LadySeat，更新View)
    //============
    public void DoCustomerEmotion_CustomerSeat_UpdateView_Clear(int id) {

        if (Now_State == 11)
        {
            //如果CustomerSeat有Lady，則重新計算CustomerSeat的Custoemr的Emotion
            if (CustomerSeat[Temp_CustomerSeat_id].GetisLady() == true) CustomerSeat[Temp_CustomerSeat_id].GetCustomer().SetEmotion(CustomerSeat[Temp_CustomerSeat_id].GetLady());
            //更新View，CustomerSeat的心情照
            control.SetCustomerSeat_CustomerHeadShot(CustomerSeat[Temp_CustomerSeat_id]);         
            //Point離開，更新View，清空小視窗(GameAbility)
            control.SetGameAbility_Clear();
        }
    }

   


    //======================================================
    //外部方法
    //======================================================

    //============
    //設定暫存選擇的CustomerSeat的id
    //============
    public void SetTemp_CustomerSeat_id(int id) {
        //遊玩狀態執行
        if(Now_State == 10)Temp_CustomerSeat_id = id;
    }

    //============
    //設定暫存選擇的LadySeat的id，(在DoCustomerEmotion_CustomerSeat_UpdateView使用，防止超出陣列範圍)
    //============
    private void SetTemp_LadySeat_id(int id)
    {
        Temp_LadySeat_id = id;
    }

   

    //============
    //通知Control要修改View
    //============
    public void ModelGame_ControlToView()
    {
        //control.Model_View(Ladyseat.GetLady(0));
    }

    //======================================================
    //Button方法
    //======================================================

    //============
    //(Button)進入選擇小姐狀態(id : 設定是哪一個CustomerSeat)
    //============
    public void SetseatCustom(int id)
    {
        //儲存座位id
        Now_CustomerSeat_id = id;

        //更新View，關閉全部CustoemrSeat上Lady的Button的interactable
        control.SetAllCustomerSeatLady_Button_interactable(false);
        //更新View，開啟或關閉LasySeat有Lady的Button
        control.SetLadySeatButton_interactable(Ladyseat);


        //更新View，開啟BackButton的interactable
        control.SetBackButton_interactable(true);
        //更新View，BackButton的Text的Color的Alpha為1
        control.SetBackButton_Text_Color(1.0f);



        //進入選擇小姐狀態
        Now_State = 11;
    }

    //============
    //(Button)進入小姐選擇完成狀態(id : 設定是哪一個Lady)
    //============
    public void SetseatLady(int id)
    {
        //儲存Lady id
        Now_LadySeat_id = id;

        //更新View，開啟有Customer的CustoemrSeat上Lady的Button
        control.SetCustomerSeatLady_Customer_Lady_Button_interactable(CustomerSeat);
        //更新View，關閉全部LadySeatButton
        control.SetAllLadySeatButton_interactable(false);
        //更新View，一次修改小視窗(GameAbility)
        control.SetGameAbility(Ladyseat.GetLady(Now_LadySeat_id));

        //更新View，關閉BackButton的interactable
        control.SetBackButton_interactable(false);
        //更新View，BackButton的Text的Color的Alpha為0
        control.SetBackButton_Text_Color(0.0f);

        //進入選擇小姐完成狀態
        Now_State = 12;
    }

    //============
    //(Button)取消小姐選擇狀態
    //============
    public void Cancel()
    {

        //更新View，開啟有Customer的CustoemrSeat上Lady的Button
        control.SetCustomerSeatLady_Customer_Lady_Button_interactable(CustomerSeat);
        //更新View，關閉全部LadySeatButton
        control.SetAllLadySeatButton_interactable(false);

        //更新View，關閉BackButton的interactable
        control.SetBackButton_interactable(false);
        //更新View，BackButton的Text的Color的Alpha為0
        control.SetBackButton_Text_Color(0.0f);
        
        //更新View，CustomerSeat的心情照
        control.SetCustomerSeat_CustomerHeadShot(CustomerSeat[Now_CustomerSeat_id]);

        //恢復成遊玩狀態
        Now_State = 10;
    }

    //============
    //(Button)使用Fever
    //============
    public void DoFever()
    {       
        Fever.DoFever(CustomerSeat);         
    }

    //============
    //(Button)遊戲暫停
    //============
    public void DoPause(int id)
    {
        //如果為遊戲繼續
        if (id == 1)
        {
            //更新View，一次修改GameBase的Position到畫面中
            control.SetAllGameBasePosition(0.0f, 0.0f, 0.0f);
            //更新View，一次修改SetAllGamePausePosition到畫面外
            control.SetAllGamePausePosition(100.0f, 0.0f, 0.0f);
            

            //恢復遊玩狀態
            Now_State = GamePause.DoGameContinue();

        }
        //離開遊戲
        else GamePause.DoGameExit();
    }

    //======================================================
    //事件生成方法
    //======================================================

    //============
    //(Button)開啟事件(id : CustomerSeat的id)
    //============
    public void OpenGameSitulation(int id)
    {
        //現在選擇的CustomerSeat的id
        Now_CustomerSeat_id = id;



        //如果是問題事件
        if (CustomerSeat[id].GetisExclamation() == true)
        {
            //進入問題事件狀態
            Now_State = 13;

            //更新View，問題事件的事件圖(Sprite)
            control.SetGameSituation_Code_Sprite(0 , GameSituation.Getid());
            //更新View，設定問題事件的題目(Text)
            control.SetGameSituation_CodeAnswer_Text(GameSituation);
            //更新View，設定問題事件的選項(Text)
            control.SetGameSituation_Answer_Text(GameSituation);
        }
        //如果是爭執事件
        else if (CustomerSeat[id].GetisArgue() == true)
        {
            //進入爭執事件狀態
            Now_State = 14;

            //更新View，爭執事件的事件圖(Sprite)
            control.SetGameSituation_Code_Sprite(1, GameArgue.Getid());
            //更新View，設定爭執事件的題目(Text)
            control.SetGameSituation_CodeAnswer_Text(GameArgue);
            //更新View，設定爭執事件的選項(Text)
            control.SetGameSituation_Answer_Text(GameArgue);
        }
        else if (CustomerSeat[id].GetisCheckout() == true)
        {
            //進入結帳事件狀態
            Now_State = 15;

            //更新View，結帳事件的事件圖(Sprite)
            control.SetGameSituation_Code_Sprite(2, GameCalculation.Getid());
            //更新View，設定結帳事件的題目(Text)
            control.SetGameSituation_CodeAnswer_Text(GameCalculation);
            //更新View，設定結帳事件的選項(Text)
            control.SetGameSituation_Answer_Text(GameCalculation);
        }

        //更新View，一次修改SetAllGameBasePosition到畫面外
        control.SetAllGameBasePosition(100.0f, 0.0f, 0.0f);
        //更新View，一次修改GameSituation的Position到畫面中
        control.SetAllGameSituationPosition(0.0f, 0.0f, 0.0f);

    }

    //============
    //(Button)事件選項_1(id : CustomerSeat的id)
    //============
    public void DoSituationChoose_one(int id) {

        //設id = 現在選擇的CustomerSeat的id
        id = Now_CustomerSeat_id;
        //如果是問題事件
        if (CustomerSeat[id].GetisExclamation() == true)
        {
            //問題事件正確選項
            GameSituation.DoCorrect(CustomerSeat[id]);

            //設置沒有問題事件
            CustomerSeat[id].SetisExclamation(false);

            //更新View，問題事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(0);
            //更新View，問題事件的結果(Text)
            control.SetGameSituation_Award_Text(GameSituation);

        }
        //如果是爭執事件
        else if (CustomerSeat[id].GetisArgue() == true)
        {
            //責罵小姐
            GameArgue.DoArgue(CustomerSeat[id]);

            //設置沒有爭執事件
            CustomerSeat[id].SetisArgue(false);

            //更新View，爭執事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(1);
            //更新View，爭執事件的結果(Text)
            control.SetGameSituation_Award_Text(GameArgue);

        }
        //如果是結帳事件
        else if (CustomerSeat[id].GetisCheckout() == true)
        {
            //增加單次總營業額
            GameConsole.AddOnceIncome(CustomerSeat[id].GetInCome());

            //增加禮品費
            GameConsole.AddGiftMoney(10000);

            //增加粉絲
            GameConsole.AddOnceFans(400);

            //送上拌手禮
            GameCalculation.DoGift(CustomerSeat[id], Ladyseat);

            //設置沒有結帳事件
            CustomerSeat[id].SetisCheckout(false);

            //更新View，結帳事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(0);
            //更新View，結帳事件的結果(Text)
            control.SetGameSituation_Award_Text(GameCalculation);
    
            //更新View，清空CustomerSeat的Range(Text)、喜好Ability(Text)、Situation(Text)、Ability的Outline顏色(Color)
            control.SetCustomerSeat_Range_Ability_Situation_Clear(CustomerSeat[id]);

        }

        //進入遊玩狀態
        Now_State = 10;

        //更新View，事件選項
        DoSituationChoose_UpdateView(id);

    }

    //============
    //(Button)事件選項_2(id : CustomerSeat的id)
    //============
    public void DoSituationChoose_two(int id)
    {
        //設id = 現在選擇的CustomerSeat的id
        id = Now_CustomerSeat_id;

        //如果是問題事件
        if (CustomerSeat[id].GetisExclamation() == true)
        {
            //問題事件錯誤選項
            GameSituation.DoMistake(CustomerSeat[id]);

            //設置沒有問題事件
            CustomerSeat[id].SetisExclamation(false);

            //更新View，問題事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(1);
            //更新View，問題事件的結果(Text)
            control.SetGameSituation_Award_Text(GameSituation);
        }
        //如果是爭執事件
        else if (CustomerSeat[id].GetisArgue() == true)
        {
            //袒護小姐
            GameArgue.DoProtect(CustomerSeat[id]);

            //設置沒有爭執事件
            CustomerSeat[id].SetisArgue(false);

            //更新View，爭執事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(0);
            //更新View，爭執事件的結果(Text)
            control.SetGameSituation_Award_Text(GameArgue);

        }
        //如果是結帳事件
        else if (CustomerSeat[id].GetisCheckout() == true)
        {
            //增加單次總營業額
            GameConsole.AddOnceIncome(CustomerSeat[id].GetInCome());

            //增加粉絲
            GameConsole.AddOnceFans(250);

            //有禮貌送客
            GameCalculation.DoOut(CustomerSeat[id], Ladyseat);

            //設置沒有結帳事件
            CustomerSeat[id].SetisCheckout(false);

            //更新View，結帳事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(0);
            //更新View，結帳事件的結果(Text)
            control.SetGameSituation_Award_Text(GameCalculation);

            //更新View，清空CustomerSeat的Range(Text)、喜好Ability(Text)、Situation(Text)、Ability的Outline顏色(Color)
            control.SetCustomerSeat_Range_Ability_Situation_Clear(CustomerSeat[id]);

        }

        //進入遊玩狀態
        Now_State = 10;

        //更新View，事件選項
        DoSituationChoose_UpdateView(id);
    }

    //============
    //(Button)事件選項_3(id : CustomerSeat的id)
    //============
    public void DoSituationChoose_three(int id)
    {
        //設id = 現在選擇的CustomerSeat的id
        id = Now_CustomerSeat_id;

        //如果是問題事件
        if (CustomerSeat[id].GetisExclamation() == true)
        {
            //問題事件錯誤選項
            GameSituation.DoMistake(CustomerSeat[id]);

            //設置沒有問題事件
            CustomerSeat[id].SetisExclamation(false);

            //更新View，問題事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(1);
            //更新View，問題事件的結果(Text)
            control.SetGameSituation_Award_Text(GameSituation);
        }
        //如果是爭執事件
        else if (CustomerSeat[id].GetisArgue() == true)
        {
            //增加禮品費
            GameConsole.AddGiftMoney(10000);

            //送上道歉禮品
            GameArgue.DoApologize(CustomerSeat[id]);         

            //設置沒有爭執事件
            CustomerSeat[id].SetisArgue(false);

            //更新View，爭執事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(0);
            //更新View，爭執事件的結果(Text)
            control.SetGameSituation_Award_Text(GameArgue);

        }
        //如果是結帳事件
        else if (CustomerSeat[id].GetisCheckout() == true)
        {
            //增加單次總營業額
            GameConsole.AddOnceIncome(CustomerSeat[id].GetInCome());

            //增加粉絲
            GameConsole.AddOnceFans(80);

            //誇獎小姐
            GameCalculation.DoPraise(CustomerSeat[id], Ladyseat);
           
            //設置沒有結帳事件
            CustomerSeat[id].SetisCheckout(false);

            //更新View，結帳事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(0);
            //更新View，結帳事件的結果(Text)
            control.SetGameSituation_Award_Text(GameCalculation);

            //更新View，清空CustomerSeat的Range(Text)、喜好Ability(Text)、Situation(Text)、Ability的Outline顏色(Color)
            control.SetCustomerSeat_Range_Ability_Situation_Clear(CustomerSeat[id]);

        }


        //進入遊玩狀態
        Now_State = 10;

        //更新View，事件選項
        DoSituationChoose_UpdateView(id);
    }

    //============
    //(Button)事件選項_4(id : CustomerSeat的id)
    //============
    public void DoSituationChoose_four(int id)
    {
        //設id = 現在選擇的CustomerSeat的id
        id = Now_CustomerSeat_id;

        //如果是問題事件
        if (CustomerSeat[id].GetisExclamation() == true)
        {
            //問題事件錯誤選項
            GameSituation.DoMistake(CustomerSeat[id]);

            //設置沒有問題事件
            CustomerSeat[id].SetisExclamation(false);

            //更新View，問題事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(1);
            //更新View，問題事件的結果(Text)
            control.SetGameSituation_Award_Text(GameSituation);
        }
        //如果是爭執事件
        else if (CustomerSeat[id].GetisArgue() == true)
        {
            //增加單次總營業額
            GameConsole.AddOnceIncome(CustomerSeat[id].GetInCome());

            //增加粉絲
            GameConsole.AddOnceFans(30);

            //送客
            GameArgue.DoOut(CustomerSeat[id] , Ladyseat);
         
            //設置沒有爭執事件
            CustomerSeat[id].SetisArgue(false);

            //更新View，爭執事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(0);
            //更新View，爭執事件的結果(Text)
            control.SetGameSituation_Award_Text(GameArgue);

            //更新View，清空CustomerSeat的Range(Text)、喜好Ability(Text)、Situation(Text)、Ability的Outline顏色(Color)
            control.SetCustomerSeat_Range_Ability_Situation_Clear(CustomerSeat[id]);

        }
        //如果是結帳事件
        else if (CustomerSeat[id].GetisCheckout() == true)
        {
            //增加單次總營業額
            GameConsole.AddOnceIncome(CustomerSeat[id].GetInCome());         

            //增加禮品費
            GameConsole.AddGiftMoney(10000);

            //增加粉絲
            GameConsole.AddOnceFans(100);          

            //給予小姐獎勵
            GameCalculation.DoPrize(CustomerSeat[id] , Ladyseat);
          
            //設置沒有結帳事件
            CustomerSeat[id].SetisCheckout(false);

            //更新View，結帳事件的結果圖(Sprite)(id : 事件結果圖編號)
            control.SetGameSituation_CodeAnswer_Sprite(0);
            //更新View，結帳事件的結果(Text)
            control.SetGameSituation_Award_Text(GameCalculation);

            //更新View，清空CustomerSeat的Range(Text)、喜好Ability(Text)、Situation(Text)、Ability的Outline顏色(Color)
            control.SetCustomerSeat_Range_Ability_Situation_Clear(CustomerSeat[id]);          
        }

        //進入遊玩狀態
        Now_State = 10;

        //更新View，事件選項
        DoSituationChoose_UpdateView(id);
    }




    //============
    //(Button)(GameConsole_Back_Button)營業結束
    //============
    public void GameConsole_Back() {
   
        //存檔
        gamesave.DoSave_GameScene(Ladyseat , GameConsole , Ladyseat.GetLadyMax());

        //切換回ManageScene
        SceneManager.LoadScene("ManageScene");
    }

}//Model_Game_Script