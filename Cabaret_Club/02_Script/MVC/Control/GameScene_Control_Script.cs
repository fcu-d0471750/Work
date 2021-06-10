/*
 * GameScene_Control_Script
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene_Control_Script : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //View_Game_Script : View
    public View_Game_Script views;

    //id : Gameinformation_Text的陣列編號
    int id = 0;

    //迴圈用
    private int i, j;

    //======================================================
    //外部方法
    //======================================================

   
    //============
    //遊玩時間(Text)
    //============
    public void SetGameTime_Text(float GameTime)
    {
        views.SetGameTime_Text(GameTime);
    }

    //============
    //(LadySeat)
    //============

    //============
    //LadySeat的HeadShot
    //============
    public void SetLadySeat_HeadShot(LadySeat_Class LadySeat)
    {
        views.SetLadySeat_HeadShot(LadySeat);
    }

    //============
    //LadySeat的HpImage的FillAmount，(LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetLadySeat_Hp_Bar_Image_FillAmount(LadySeat_Class LadySeat)
    {
        views.SetLadySeat_Hp_Bar_Image_FillAmount(LadySeat);
    }

    //============
    //開啟或關閉全部，LadySeatButton_interactable(ButtonState: 開啟或關閉Button ， LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetAllLadySeatButton_interactable(bool ButtonState)
    {
        views.SetAllLadySeatButton_interactable(ButtonState);
    }

    //============
    //開啟或關閉LasySeat有Lady的，LadySeatButton_interactable(ButtonState: 開啟或關閉Button ， LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetLadySeatButton_interactable(LadySeat_Class LadySeat)
    {
        views.SetLadySeatButton_interactable(LadySeat);
    }


    //============
    //小視窗(GameAbility)
    //============
    public void SetGameAbility(Lady_Class Lady)
    {
        //小視窗Lady的HeadShot
        views.SetLady_HeadShot(Lady);
        //一次修改小視窗Lady的Looks
        views.SetLady_Looks(Lady);
        //一次修改小視窗Lady的Color
        views.SetLady_Looks_Color(Lady);
        //一次修改小視窗Lady的Name、Hp、Talk、Party、Love、Skill
        views.SetLady_Ability_Text(Lady.GetName() , Lady.GetHp() , Lady.GetTalk() , Lady.GetParty() , Lady.GetLove() , Lady.GetSkill());
        //一次修改小視窗Lady的Bar_Image
        views.SetLady_Bar_Image_FillAmount(Lady);
    }

    //============
    //清空小視窗(GameAbility)
    //============
    public void SetGameAbility_Clear()
    {
        //清空小視窗Lady的HeadShot
        views.SetLady_HeadShot_Clear();
        //一次清空小視窗Lady的Looks
        views.SetLady_Looks_Clear();
        //一次清空小視窗Lady的Name、Hp、Talk、Party、Love、Skill
        views.SetLady_Ability_Text_Clear();
        //一次清空小視窗Lady的Bar_Image
        views.SetLady_Bar_Image_FillAmount_Clear();
    }


    //============
    //(GameCustomerInformation)
    //============

    //============
    //一次修改GameCustomerInformation
    //============
    public void SetGameCustomerInformation(CustomerSeat_Class CustomerSeat)
    {
        //GameCustomerInformation的Ability
        views.SetGameCustomerInformation_Ability_Text(CustomerSeat.GetCustomer().GetAbility());
        //GameCustomerInformation_的Looks
        views.SetGameCustomerInformation_Looks_Text(CustomerSeat.GetCustomer().GetLooks());
        //GameCustomerInformation_的Looks
        views.SetGameCustomerInformation_Time_Text(CustomerSeat.GetCustomer().GetTime());
    }

    //============
    //一次清空GameCustomerInformation
    //============
    public void SetGameCustomerInformation_Clear()
    {
        //清空GameCustomerInformation的Ability
        views.SetGameCustomerInformation_Ability_Text_Clear();
        //清空GameCustomerInformation_的Looks
        views.SetGameCustomerInformation_Looks_Text_Clear();
        //清空GameCustomerInformation_的Looks
        views.SetGameCustomerInformation_Time_Text_Clear();
    }

    //============
    //(GameEarnMoney)
    //============

    //============
    //一次修改GameEarnMoney
    //============
    public void SetGameEarnMoney_SeatNumber_MoneyRevenue_Text(CustomerSeat_Class CustomerSeat) {
        views.SetGameEarnMoney_SeatNumber_Text(CustomerSeat);
        views.SetGameEarnMoney_MoneyRevenue_Text(CustomerSeat);
    }

    //============
    //一次清空GameEarnMoney的SeatNumber、MoneyRevenue(Text)
    //============
    public void SetGameEarnMoney_SeatNumber_MoneyRevenue_Text_Clear()
    {
        //清空GameEarnMoney的SeatNumber
        views.SetGameEarnMoney_SeatNumber_Text_Clear();
        //清空GameEarnMoney的MoneyRevenue
        views.SetGameEarnMoney_MoneyRevenue_Text_Clear();
    }

    


    //============
    //(GameFever)
    //============

    //============
    //一次修改GameFever，(FeverEnergy : Fever能量 ， isFever : Fever可否使用)
    //============
    public void SetGameFever(float FeverEnergy ,  bool isFever) {
        views.SetGameFever_Wine_Text(FeverEnergy);
        views.SetGameFever_Bar_Image(FeverEnergy);
        views.SetGameFever_Button(isFever);
    }

    //============
    //(GameInformation)
    //============

    //============
    //GameInformation的Text(Text)，(id : Gameinformation_Text的陣列編號)
    //============
    public void SetGameInformation_Text(string Informationstring)
    {
        views.SetGameInformation_Text(id, Informationstring);
        SetGameInformation_id();
    }

    //============
    //Gameinformation_Text的陣列編號(int)
    //============
    private void SetGameInformation_id()
    {
        this.id = this.id + 1;
        //如果id 超過 Gameinformation_Text的陣列長度，則回到0
        if (this.id >= views.Gameinformation_Text.Length) this.id = 0;
    }

    //============
    //(CustomerSeat)
    //============

    //============
    //CustomerSeat上的Lady的大頭照(Sprite)
    //============
    public void SetCustomerSeat_LadyHeadShot(CustomerSeat_Class CustomerSeat) {
        views.SetCustomerSeat_LadyHeadShot(CustomerSeat);
    }

    //============
    //CustomerSeat上的Customer的心情照(Sprite)
    //============
    public void SetCustomerSeat_CustomerHeadShot(CustomerSeat_Class CustomerSeat)
    {
        views.SetCustomerSeat_CustomerHeadShot(CustomerSeat);
    }

    //============
    //CustomerSeat上的暫存Customer的心情照(Sprite)(Emotion: 計算的Emotion, Temp_CustomerSeat_id: 暫存選擇的CustomerSeat的id  Temp_LadySeat_id: 暫存選擇的LadySeat的id isLady: 是否有Lady)
    //============
    public void SetTempCustomerSeat_CustomerHeadShot(int Emotion, int Temp_CustomerSeat_id )
    {
        views.SetTempCustomerSeat_CustomerHeadShot(Emotion , Temp_CustomerSeat_id );
    }

    //============
    //一次修改CustomerSeat上的Customer的喜好Ability、Range、喜好Ability的Outline顏色
    //============
    public void SetCustomerSeat_Ability_Range_Text(CustomerSeat_Class CustomerSeat) {
        //CustomerSeat上的Customer的喜好Ability
        views.SetCustomerSeat_Ability_Text(CustomerSeat);
        //CustomerSeat上的Customer的Range
        views.SetCustomerSeat_Range_Text(CustomerSeat);
        //CustomerSeat上的Customer的喜好Ability的Outline顏色
        views.SetCustomer_Ability_Outline(CustomerSeat);
    }

    //============
    //CustomerSeat的Situation
    //============
    public void SetCustomerSeat_Situation_Text(CustomerSeat_Class CustomerSeat)
    {
        views.SetCustomerSeat_Situation_Text(CustomerSeat);
    }

    //============
    //全部CustomerSeat上的等待Bar_Image(Image)
    //============
    public void SetAllCustomerSeat_WaitTime_Image(CustomerSeat_Class[] CustomerSeat)
    {
        views.SetAllCustomerSeat_WaitTime_Image(CustomerSeat);
    }

    //============
    //CustomerSeat上的等待Bar_Image
    //============
    public void SetCustomerSeat_WaitTime_Image(CustomerSeat_Class CustomerSeat)
    {
        views.SetCustomerSeat_WaitTime_Image(CustomerSeat);
    }

    //============
    //全部CustomerSeat上的遊玩時間的Image
    //============
    public void SetAllCustomerSeat_CostTime_Image(CustomerSeat_Class[] CustomerSeat)
    {
        views.SetAllCustomerSeat_CostTime_Image(CustomerSeat);
    }

    //============
    //CustomerSeat上的遊玩時間的Image
    //============
    public void SetCustomerSeat_CostTime_Image(CustomerSeat_Class CustomerSeat)
    {
        views.SetCustomerSeat_CostTime_Image(CustomerSeat);
    }

   
    //============
    //開啟或關閉全部，Customer_Exclamation Button的interactable(ButtonState: 開啟或關閉Button)
    //============
    public void SetAllCustomer_Exclamation_Button_interactable(bool ButtonState)
    {
        views.SetAllCustomer_Exclamation_Button_interactable(ButtonState);
    }

    //============
    //開啟或關閉CustomerSeat有問題、爭執事件的Button，Customer_Exclamation Button的interactable
    //============
    public void SetCustomer_Exclamation_Button_interactable(CustomerSeat_Class CustomerSeat)
    {
        views.SetCustomer_Exclamation_Button_interactable(CustomerSeat);
    }

    //============
    //開啟或關閉全部，Customer_Checkout_Button的interactable(ButtonState: 開啟或關閉Button)
    //============
    public void SetAllCustomer_Checkout_Button_interactable(bool ButtonState)
    {
        views.SetAllCustomer_Checkout_Button_interactable(ButtonState);
    }

    //============
    //開啟或關閉CustomerSeat有結帳事件的Button，Customer_Checkout_Button的interactable 
    //============
    public void SetCustomer_Checkout_Button_interactable(CustomerSeat_Class CustomerSeat)
    {
        views.SetCustomer_Checkout_Button_interactable(CustomerSeat);
    }

    //============
    //開啟或關閉全部，CustoemrSeat上Lady的Button的interactable(ButtonState: 開啟或關閉Button)
    //============
    public void SetAllCustomerSeatLady_Button_interactable(bool ButtonState)
    {
        views.SetAllCustomerSeatLady_Button_interactable(ButtonState);
    }

    //============
    //開啟或關閉CustoemrSeat上Lady的Button，CustoemrSeat上Lady的Button的interactable 
    //============
    public void SetCustomerSeatLady_Button_interactable(CustomerSeat_Class CustomerSeat)
    {
        views.SetCustomerSeatLady_Button_interactable(CustomerSeat);
    }

    //============
    //開啟或關閉，有Customer的CustoemrSeat上Lady的Button，CustoemrSeat上Lady的Button的interactable 
    //============
    public void SetCustomerSeatLady_Customer_Lady_Button_interactable(CustomerSeat_Class[] CustomerSeat)
    {
        views.SetCustomerSeatLady_Customer_Lady_Button_interactable(CustomerSeat);
    }


    //============
    //(GameSituation)
    //============

    //============
    //問題、爭執、結帳事件的事件圖(Sprite)(Code : 問題事件、爭執事件、結帳事件 ， id : 事件編號)
    //============
    public void SetGameSituation_Code_Sprite(int Code, int id)
    {
        views.SetGameSituation_Code_Sprite(Code, id);
    }

    //============
    //問題、爭執、結帳事件的結果圖(Sprite)(id : 事件結果編號)
    //============
    public void SetGameSituation_CodeAnswer_Sprite(int id)
    {
        views.SetGameSituation_CodeAnswer_Sprite(id);
    }

    //============
    //問題、爭執、結帳事件的題目(Text)
    //============
    public void SetGameSituation_CodeAnswer_Text(GameSituation_Class GameSituation)
    {
        views.SetGameSituation_CodeAnswer_Text(GameSituation);
    }

    //============
    //問題、爭執、結帳事件的選項(Text)
    //============
    public void SetGameSituation_Answer_Text(GameSituation_Class GameSituation)
    {
        views.SetGameSituation_Answer_Text(GameSituation);
    }

    //============
    //問題、爭執、結帳事件的結果(Text)
    //============
    public void SetGameSituation_Award_Text(GameSituation_Class GameSituation)
    {
        views.SetGameSituation_Award_Text(GameSituation);
    }

    //============
    //開啟或關閉全部，問題、爭執、結帳事件的選項的interactable(Button)(ButtonState: 開啟或關閉Button)
    //============
    public void SetGameSituation_Answer_Button_interactable(bool ButtonState)
    {
        views.SetGameSituation_Answer_Button_interactable(ButtonState);
    }

    //============
    //清空CustomerSeat的Range(Text)、喜好Ability(Text)、Situation(Text)、Ability的Outline顏色(Color)
    //============
    public void SetCustomerSeat_Range_Ability_Situation_Clear(CustomerSeat_Class CustomerSeat)
    {
        views.SetCustomerSeat_Range_Ability_Situation_Clear(CustomerSeat);
    }

    //============
    //將問題、爭執、結帳事件的結果圖(Sprite) 和 問題、爭執、結帳事件的結果(Text)清空
    //============
    public void SetGameSituation_Award_CodeAnswer_Clear()
    {
        views.SetGameSituation_Award_CodeAnswer_Clear();
    }


    //============
    //(GameConsole)
    //============

    //============
    //GameConsole的大頭照，(sprite)(LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetGameConsole_HeadShot(LadySeat_Class LadySeat)
    {
        views.SetGameConsole_HeadShot(LadySeat);
    }

    //============
    //GameConsole的來客數(Text)
    //============
    public void SetGameConsole_Customer_Text(uint ComeCustomerCount)
    {
        views.SetGameConsole_Customer_Text(ComeCustomerCount);
    }

    //============
    //GameConsole的包廂收入(Text)
    //============
    public void SetGameConsole_Room_Text(uint RoomInCome)
    {
        views.SetGameConsole_Room_Text(RoomInCome);
    }

    //============
    //GameConsole的餐飲總額(Text)
    //============
    public void SetGameConsole_Food_Text(uint FoodInCome)
    {
        views.SetGameConsole_Food_Text(FoodInCome);
    }

    //============
    //GameConsole的禮品費(Text)
    //============
    public void SetGameConsole_Gift_Text(uint GiftMoney)
    {
        views.SetGameConsole_Gift_Text(GiftMoney);
    }

    //============
    //GameConsole的人事費(Text)
    //============
    public void SetGameConsole_Cost_Text(uint WorkCost)
    {
        views.SetGameConsole_Cost_Text(WorkCost);
    }

    //============
    //GameConsole的粉絲數(Text)
    //============
    public void SetGameConsole_Fans_Text(uint OnceFans)
    {
        views.SetGameConsole_Fans_Text(OnceFans);
    }


    //============
    //GameConsole的獲利(Text)
    //============
    public void SetGameConsole_Sum_Text(uint OnceIncome)
    {
        views.SetGameConsole_Sum_Text(OnceIncome);
    }

    //============
    //GameConsole的StaffIncome(Text)(LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetGameConsole_Sum_Text(LadySeat_Class LadySeat)
    {
        views.SetGameConsole_Sum_Text(LadySeat);
    }

    //============
    //GameConsole的StaffLevelUp(Text)(LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetStaffLevelUp_Text(LadySeat_Class LadySeat)
    {
        views.SetStaffLevelUp_Text(LadySeat);
    }

    //============
    //GameConsole的StaffLevel(Text)(LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetStaffLevel_Text(LadySeat_Class LadySeat)
    {
        views.SetStaffLevel_Text(LadySeat);
    }


    //============
    //一次修改GameConsole(GameConsole: 取得所有GameConsole的資料 LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetAllGameConsole(GameConsole_Class GameConsole, LadySeat_Class LadySeat)
    {
        //更新View，GameConsole的大頭照
        views.SetGameConsole_HeadShot(LadySeat);

        //更新View，GameConsole的來客數(Text)
        views.SetGameConsole_Customer_Text(GameConsole.GetComeCustomerCount());
        //更新View，GameConsole的包廂收入(Text)       
        views.SetGameConsole_Room_Text(GameConsole.GetRoomInCome());

        //更新View，GameConsole的餐飲總額(Text)
        views.SetGameConsole_Food_Text(GameConsole.GetFoodInCome());

        //更新View，GameConsole的禮品費(Text)
        views.SetGameConsole_Gift_Text(GameConsole.GetGiftMoney());


        //更新View，GameConsole的人事費(Text)
        views.SetGameConsole_Cost_Text(GameConsole.GetWorkCost());


        //更新View，GameConsole的粉絲數(Text)
        views.SetGameConsole_Fans_Text(GameConsole.GetOnceFans());

        //更新View，GameConsole的獲利(Text)
        views.SetGameConsole_Sum_Text(GameConsole.GetOnceIncome());



        //更新View，GameConsole的StaffIncome(Text)(LadySeat: 取得所有LadySeat的資料)
        views.SetGameConsole_Sum_Text(LadySeat);

        //更新View，GameConsole的StaffLevelUp(Text)(LadySeat: 取得所有LadySeat的資料)
        views.SetStaffLevelUp_Text(LadySeat);

        //更新View，GameConsole的StaffLevel(Text)(LadySeat: 取得所有LadySeat的資料)
        views.SetStaffLevel_Text(LadySeat);
    }

    //============
    //(Other)
    //============

    //============
    //BackButton的Text(Text)
    //============
    public void SetBackButton_Text(string Backstring)
    {
        views.SetBackButton_Text(Backstring);
    }

    //============
    //開啟或關閉，BackButton的interactable(Button)(ButtonState: 開啟或關閉Button)
    //============
    public void SetBackButton_interactable(bool ButtonState)
    {
        views.SetBackButton_interactable(ButtonState);
    }

    //============
    //BackButton的Text的Color(Text)
    //============
    public void SetBackButton_Text_Color(float Alpha)
    {
        views.SetBackButton_Text_Color(Alpha);
    }

    

    //============
    //(GameObject)
    //============

    //============
    //GameLadiesBase
    //============
    public void SetGameLadiesBasePosition(float x, float y, float z)
    {
        views.SetGameLadiesBasePosition(x / 5.0f , y , z);
    }

    //============
    //GameAbilityBase
    //============
    public void SetGameAbilityBasePosition(float x, float y, float z)
    {
        views.SetGameAbilityBasePosition(x / 5.0f, y, z);
    }

    //============
    //GameCustomerBase
    //============
    public void SetGameCustomerBasePosition(float x, float y, float z)
    {
        views.SetGameCustomerBasePosition(x / 5.0f, y, z);
    }

    //============
    //GameEarnMoneyBase
    //============
    public void SetGameEarnMoneyBasePosition(float x, float y, float z)
    {
        views.SetGameEarnMoneyBasePosition(x / 5.0f, y, z);
    }

    //============
    //GameFeverBase
    //============
    public void SetGameFeverBasePosition(float x, float y, float z)
    {
        views.SetGameFeverBasePosition(x / 5.0f, y, z);
    }

    //============
    //GameCustomerInformationBase
    //============
    public void SetGameCustomerInformationBasePosition(float x, float y, float z)
    {
        views.SetGameCustomerInformationBasePosition(x / 5.0f, y, z);
    }

    //============
    //GameInformationBase
    //============
    public void SetGameInformationBasePosition(float x, float y, float z)
    {
        views.SetGameInformationBasePosition(x / 5.0f, y, z);
    }

    //============
    //GameTimeBase
    //============
    public void SetGameTimeBasePosition(float x, float y, float z)
    {
        views.SetGameTimeBasePosition(x / 5.0f, y, z);
    }

    //============
    //GameSituationBase
    //============
    public void SetGameSituationBasePosition(float x, float y, float z)
    {
        views.SetGameSituationBasePosition(x / 5.0f, y, z);
    }

    //============
    //GameConsoleBase
    //============
    public void SetGameConsoleBasePosition(float x, float y, float z)
    {
        views.SetGameConsoleBasePosition(x / 5.0f, y, z);
    }

    //============
    //GamePauseBase
    //============
    public void SetGamePauseBasePosition(float x, float y, float z)
    {
        views.SetGamePauseBasePosition(x / 5.0f, y, z);
    }

    //============
    //(GameObjectCanVas)
    //============

    //============
    //GameLadiesCanVas
    //============
    public void SetGameLadiesCanVasLocalPosition(float x, float y, float z)
    {
        views.SetGameLadiesCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //GameAbilityCanVas
    //============
    public void SetGameAbilityCanVasLocalPosition(float x, float y, float z)
    {
        views.SetGameAbilityCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //GameCustomerCanVas
    //============
    public void SetGameCustomerCanVasLocalPosition(float x, float y, float z)
    {
        views.SetGameCustomerCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //GameEarnMoneyCanVas
    //============
    public void SetGameEarnMoneyCanVasLocalPosition(float x, float y, float z)
    {
        views.SetGameEarnMoneyCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //GameFeverCanVas
    //============
    public void SetGameFeverCanVasLocalPosition(float x, float y, float z)
    {
        views.SetGameFeverCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //GameCustomerInformationCanVas
    //============
    public void SetGameCustomerInformationCanVasLocalPosition(float x, float y, float z)
    {
        views.SetGameCustomerInformationCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //GameInformationCanVas
    //============
    public void SetGameInformationCanVasLocalPosition(float x, float y, float z)
    {
        views.SetGameInformationCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //GameTimeCanVas
    //============
    public void SetGameTimeCanVasLocalPosition(float x, float y, float z)
    {
        views.SetGameTimeCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //GameSituationCanVas
    //============
    public void SetGameSituationCanVasLocalPosition(float x, float y, float z)
    {
        views.SetGameSituationCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //GameConsoleCanVas
    //============
    public void SetGameConsoleCanVasLocalPosition(float x, float y, float z)
    {
        views.SetGameConsoleCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //GamePauseCanVas
    //============
    public void SetGamePauseCanVasLocalPosition(float x, float y, float z)
    {
        views.SetGamePauseCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改GamesceneLadyies...在內的Position
    //============
    public void SetAllGameBasePosition(float x, float y, float z) {
        views.SetGameLadiesBasePosition(x / 5.0f, y, z);
        views.SetGameAbilityBasePosition(x / 5.0f, y, z);
        views.SetGameCustomerBasePosition(x / 5.0f, y, z);
        views.SetGameEarnMoneyBasePosition(x / 5.0f, y, z);
        views.SetGameFeverBasePosition(x / 5.0f, y, z);
        views.SetGameCustomerInformationBasePosition(x / 5.0f, y, z);
        views.SetGameInformationBasePosition(x / 5.0f, y, z);
        views.SetGameTimeBasePosition(x / 5.0f, y, z);

        views.SetGameLadiesCanVasLocalPosition(x * 10.0f, y, z);
        views.SetGameAbilityCanVasLocalPosition(x * 10.0f, y, z);
        views.SetGameCustomerCanVasLocalPosition(x * 10.0f, y, z);
        views.SetGameEarnMoneyCanVasLocalPosition(x * 10.0f, y, z);
        views.SetGameFeverCanVasLocalPosition(x * 10.0f, y, z);
        views.SetGameCustomerInformationCanVasLocalPosition(x * 10.0f, y, z);
        views.SetGameInformationCanVasLocalPosition(x * 10.0f, y, z);
        views.SetGameTimeCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改GameSituation的Position
    //============
    public void SetAllGameSituationPosition(float x, float y, float z)
    {
        views.SetGameSituationBasePosition(x / 5.0f, y, z);

        views.SetGameSituationCanVasLocalPosition(x * 10.0f, y, z);

        //一次修改GameSituation的AnswerButton的Position
        SetAllGameSituationButtonPosition();
    }

    //============
    //一次修改GameSituation的AnswerButton的Position
    //============
    public void SetAllGameSituationButtonPosition()
    {
        views.SetGameSituation_Answer_Button_Position();
    }


    //============
    //一次修改GameConsole的Position
    //============
    public void SetAllGameConsolePosition(float x, float y, float z)
    {
        views.SetGameConsoleBasePosition(x / 5.0f, y, z);

        views.SetGameConsoleCanVasLocalPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改GamePause的Position
    //============
    public void SetAllGamePausePosition(float x, float y, float z)
    {
        views.SetGamePauseBasePosition(x / 5.0f, y, z);

        views.SetGamePauseCanVasLocalPosition(x * 10.0f, y, z);
    }






}//GameScene_Control_Script
