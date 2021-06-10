/*
 * View : GameScene的View
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class View_Game_Script : MonoBehaviour
{
    //======================================================
    //UI來源
    //======================================================

    public GameScene_View_UI GVU;
    
    //======================================================
    //宣告UI(Sprite、Text、Image、Button)
    //======================================================

    //============
    //Sprite
    //============

    //LadySeat的大頭照
    public SpriteRenderer[] LadySeat_HeadShot = new SpriteRenderer[8];

    //Lady小視窗的大頭照
    public SpriteRenderer Lady_HeadShot;

    //Lady的Looks_Sexy
    public SpriteRenderer Lady_Looks_Sexy;

    //Lady的Looks_Beauty
    public SpriteRenderer Lady_Looks_Beauty;

    //Lady的Looks_Cute
    public SpriteRenderer Lady_Looks_Cute;

    //Lady的Looks_Funny
    public SpriteRenderer Lady_Looks_Funny;

    //CustomerSeat的Lady大頭照
    public SpriteRenderer[] CustomerSeat_LadyHeadShot = new SpriteRenderer[6];

    //CustomerSeat的Customer心情照
    public SpriteRenderer[] CustomerSeat_CustomerHeadShot = new SpriteRenderer[6];

    //問題、爭執、結帳事件的事件圖
    public SpriteRenderer GameSituation_Code_Sprite;

    //問題、爭執、結帳事件的結果圖
    public SpriteRenderer GameSituation_CodeAnswer_Sprite;

    //GameConsole的大頭照
    public SpriteRenderer[] GameConsole_HeadShot = new SpriteRenderer[8];

    //============
    //Text
    //============

    //遊玩時間(180 / 60 +":"+ 180 % 60)
    public Text GameTime_Text;

    //============
    //(Game)
    //============

    //CustomerSeat的喜好Ability
    public Text[] CustomerSeat_Ability_Text = new Text[6];

    //CustomerSeat的Range
    public Text[] CustomerSeat_Range_Text = new Text[6];

    //CustomerSeat的Situation_Text
    public Text[] CustomerSeat_Situation_Text = new Text[6];

    //Lady的Name
    public Text LadyName_Text;

    //Lady的Hp
    public Text LadyHp_Text;

    //Lady的Talk
    public Text LadyTalk_Text;

    //Lady的Party
    public Text LadyParty_Text;

    //Lady的Love
    public Text LadyLove_Text;

    //Lady的Skill
    public Text LadySkill_Text;

    //GameCustomerInformation的Ability
    public Text CustomerInformation_Ability_Text;

    //GameCustomerInformation的Looks
    public Text GameCustomerInformation_Looks_Text;

    //GameCustomerInformation的Time
    public Text GameCustomerInformation_Time_Text;

    //GameEarnMoney的SeatNumber
    public Text GameEarnMoney_SeatNumber_Text;

    //GameEarnMoney的MoneyRevenue
    public Text GameEarnMoney_MoneyRevenue_Text;

    //Gameinformation
    public Text[] Gameinformation_Text = new Text[3];

    //GameFever
    public Text GameFever_Text;

    //============
    //(GameSituation)
    //============

    //GameSituation的Title
    public Text GameSituation_Title_Text;

    //GameSituation的Answer
    public Text[] GameSituation_Answer_Text = new Text[4];

    //GameSituation的Award
    public Text GameSituation_Award_Text;

    //============
    //(GameConsole)
    //============

    //GameConsole的來客數
    public Text GameConsole_Customer_Text;

    //GameConsole的包廂收入
    public Text GameConsole_Room_Text;

    //GameConsole的餐飲總額
    public Text GameConsole_Food_Text;

    //GameConsole的禮品費
    public Text GameConsole_Gift_Text;

    //GameConsole的人事費
    public Text GameConsole_Cost_Text;

    //GameConsole的粉絲數
    public Text GameConsole_Fans_Text;

    //GameConsole的獲利
    public Text GameConsole_Sum_Text;

    //StaffIncome
    public Text[] StaffIncome_Text = new Text[8];

    //StaffLevelUp
    public Text[] StaffLevelUp_Text = new Text[8];

    //StaffLevel
    public Text[] StaffLevel_Text = new Text[8];

    //============
    //(GamePause)
    //============

    //繼續遊戲Text
    public Text GamePause_Continue_Text;

    //離開遊戲Text
    public Text GamePause_Exit_Text;

    //============
    //(Other)
    //============

    //BackButton Text
    public Text BackButton_Text;

    //GameConsole Back Text
    public Text GameConsole_Back_Text;


    //============
    //Image
    //============

    //============
    //(Game)
    //============

    //LadySeat的Hp
    public Image[] LadySeat_Hp_Image = new Image[8];

    //CustomerSeat的WaitTime
    public Image[] CustomerSeat_WaitTime_Image = new Image[6];

    //CustomerSeat的CostTime
    public Image[] CustomerSeat_CostTime_Image = new Image[6];

    //Lady的Hp
    public Image LadyHp_Bar_Image;

    //Lady的Talk
    public Image LadyTalk_Bar_Image;

    //Lady的Party
    public Image LadyParty_Bar_Image;

    //Lady的Love
    public Image LadyLove_Bar_Image;

    //Lady的Skill
    public Image LadySkill_Bar_Image;

    //GameFever
    public Image GameFever_Bar_Image;


    //============
    //Button
    //============

    //============
    //(Game)
    //============

    //LadySeat的Button
    public Button[] LadySeatSelect_Button = new Button[8];

    //CustoemrSeat上Lady的Button
    public Button[] CustomerSeatLady_Button = new Button[6];

    //問題、爭執Button
    public Button[] Customer_Exclamation_Button = new Button[6];

    //結帳Button
    public Button[] Customer_Checkout_Button = new Button[6];

    //GameFever
    public Button GameFever_Button;

    //============
    //(GameSituation)
    //============
    //問題、爭執事件回答Button
    public Button[] GameSituation_Answer_Button = new Button[4];

    //============
    //(GamePause)
    //============

    //繼續遊戲Button
    public Button GamePause_Continue_Button;

    //離開遊戲Button
    public Button GamePause_Exit_Button;


    //============
    //GameObject
    //============

    //GameLadiesBase
    public GameObject GameLadiesBase;

    //GameAbilityBase
    public GameObject GameAbilityBase;

    //GameCustomerBase
    public GameObject GameCustomerBase;

    //GameEarnMoneyBase
    public GameObject GameEarnMoneyBase;

    //GameFeverBase
    public GameObject GameFeverBase;

    //GameCustomerInformationBase
    public GameObject GameCustomerInformationBase;

    //GameInformationBase
    public GameObject GameInformationBase;

    //GameTimeBase
    public GameObject GameTimeBase;

    //GameSituationBase
    public GameObject GameSituationBase;

    //GameConsoleBase
    public GameObject GameConsoleBase;

    //GamePauseBase
    public GameObject GamePauseBase;

    //============
    //(GameObjectCanvas)
    //============

    //GameLadiesCanVas
    public GameObject GameLadiesCanVas;

    //GameAbilityCanVas
    public GameObject GameAbilityCanVas;

    //GameCustomerCanVas
    public GameObject GameCustomerCanVas;

    //GameEarnMoneyCanVas
    public GameObject GameEarnMoneyCanVas;

    //GameFeverCanVas
    public GameObject GameFeverCanVas;

    //GameCustomerInformationCanVas
    public GameObject GameCustomerInformationCanVas;

    //GameInformationCanVas
    public GameObject GameInformationCanVas;

    //GameTimeCanVas
    public GameObject GameTimeCanVas;

    //GameSituationCanVas
    public GameObject GameSituationCanVas;

    //GameSituationButtonPositionCanVas
    public GameObject[] GameSituationButtonPositionCanVas = new GameObject[4];

    //GameConsoleCanVas
    public GameObject GameConsoleCanVas;

    //GamePauseCanVas
    public GameObject GamePauseCanVas;


    //============
    //(Other)
    //============

    //BackButton 
    public Button BackButton;

    //GameConsole Back 
    public Button GameConsole_Back_Button;

    //Customer的喜好Ability的Outline
    public Outline[] Customer_Ability_Outline = new Outline[6];

    //GameSituation Award的Outline
    public Outline GameSituation_Award_Text_Outline;


    //======================================================
    //宣告變數
    //======================================================

    //迴圈用
    public int i,j;


    //======================================================
    //外部方法
    //======================================================

    //============
    //遊玩時間(Text)
    //============
    public void SetGameTime_Text(float GameTime)
    {
        GameTime_Text.text = (int)(GameTime / 60) + " : " + (int)(GameTime % 60);      
    }
    

    //============
    //(LadySeat)
    //============

    //============
    //LadySeat的HeadShot，(LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetLadySeat_HeadShot(LadySeat_Class LadySeat)
    {
        for (i = 0; i < LadySeat_HeadShot.Length; i++)
        {
            if (LadySeat.GetisLadySeat(i) == false) LadySeat_HeadShot[i].sprite = GVU.LadyHeadShot[LadySeat.GetLady(i).Getid()];
            else LadySeat_HeadShot[i].sprite = null;
        }
    }

    //============
    //LadySeat的HpImage的FillAmount，(LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetLadySeat_Hp_Bar_Image_FillAmount(LadySeat_Class LadySeat)
    {
        for (i = 0; i < LadySeat_Hp_Image.Length; i++)
        {
            if (LadySeat.GetisLadySeat(i) == false) LadySeat_Hp_Image[i].fillAmount = LadySeat.GetLady(i).GetHp() / LadySeat.GetLady(i).GetHpMax();
            else LadySeat_Hp_Image[i].fillAmount = 0.0f;
        }
    }

    //============
    //開啟或關閉全部，LadySeatButton_interactable(ButtonState: 開啟或關閉Button ， LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetAllLadySeatButton_interactable(bool ButtonState) {
        for (i = 0; i < LadySeatSelect_Button.Length; i++) {
            LadySeatSelect_Button[i].interactable = ButtonState;
        }
    }

    //============
    //開啟或關閉LasySeat有Lady的，LadySeatButton_interactable(ButtonState: 開啟或關閉Button ， LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetLadySeatButton_interactable(LadySeat_Class LadySeat)
    {
        for (i = 0; i < LadySeatSelect_Button.Length; i++)
        {
            if (LadySeat.GetisLadySeat(i) == false) LadySeatSelect_Button[i].interactable = true;
            else LadySeatSelect_Button[i].interactable = false;
        }
    }


    //============
    //小視窗(GameAbility)
    //============

    //============
    //小視窗Lady的HeadShot
    //============
    public void SetLady_HeadShot(Lady_Class Lady) {
        Lady_HeadShot.sprite = GVU.LadyHeadShot[Lady.Getid()];
    }

    //============
    //清空小視窗Lady的HeadShot
    //============
    public void SetLady_HeadShot_Clear()
    {
        Lady_HeadShot.sprite = null;
    }

    //============
    //小視窗Lady的Looks(Sexy)
    //============
    public void SetLady_Looks_Sexy(Lady_Class Lady) {
        Lady_Looks_Sexy.sprite = GVU.GetLooksSprite(Lady.GetSexy());     
    }

    //============
    //清空小視窗Lady的Looks(Sexy)
    //============
    public void SetLady_Looks_Sexy_Clear()
    {
        Lady_Looks_Sexy.sprite = null;
    }

    //============
    //小視窗Lady的Looks(Beauty)
    //============
    public void SetLady_Looks_Beauty(Lady_Class Lady)
    {
        Lady_Looks_Beauty.sprite = GVU.GetLooksSprite(Lady.GetBeauty());
    }

    //============
    //清空小視窗Lady的Looks(Beauty)
    //============
    public void SetLady_Looks_Beauty_Clear()
    {
        Lady_Looks_Beauty.sprite = null;
    }

    //============
    //小視窗Lady的Looks(Cute)
    //============
    public void SetLady_Looks_Cute(Lady_Class Lady)
    {
        Lady_Looks_Cute.sprite = GVU.GetLooksSprite(Lady.GetCute());
    }

    //============
    //清空小視窗Lady的Looks(Cute)
    //============
    public void SetLady_Looks_Cute_Clear()
    {
        Lady_Looks_Cute.sprite = null;
    }

    //============
    //小視窗Lady的Looks(Funny)
    //============
    public void SetLady_Looks_Funny(Lady_Class Lady)
    {
        Lady_Looks_Funny.sprite = GVU.GetLooksSprite(Lady.GetFunny());
    }

    //============
    //清空小視窗Lady的Looks(Funny)
    //============
    public void SetLady_Looks_Funny_Clear()
    {
        Lady_Looks_Funny.sprite = null;
    }

    //============
    //一次修改小視窗Lady的Looks
    //============
    public void SetLady_Looks(Lady_Class Lady)
    {
        SetLady_Looks_Sexy(Lady);
        SetLady_Looks_Beauty(Lady);
        SetLady_Looks_Cute(Lady);
        SetLady_Looks_Funny(Lady);
    }

    //============
    //一次清空小視窗Lady的Looks
    //============
    public void SetLady_Looks_Clear()
    {
        SetLady_Looks_Sexy_Clear();
        SetLady_Looks_Beauty_Clear();
        SetLady_Looks_Cute_Clear();
        SetLady_Looks_Funny_Clear();
    }

    //============
    //小視窗Lady的Name(Text)
    //============
    public void SetLadyName_Text(string Name) {
        LadyName_Text.text = "" + Name;
    }

    //============
    //清空小視窗Lady的Name(Text)
    //============
    public void SetLadyName_Text_Clear()
    {
        LadyName_Text.text = " ";
    }

    //============
    //小視窗Lady的Hp(Text)
    //============
    public void SetLadyHp_Text(float Hp)
    {
        LadyHp_Text.text = "" + (int)Hp;
    }

    //============
    //清空小視窗Lady的Hp(Text)
    //============
    public void SetLadyHp_Text_Clear()
    {
        LadyHp_Text.text = " ";
    }

    //============
    //小視窗Lady的Talk(Text)
    //============
    public void SetLadyTalk_Text(float Talk)
    {
        LadyTalk_Text.text = "" + (int)Talk;
    }

    //============
    //清空小視窗Lady的Talk(Text)
    //============
    public void SetLadyTalk_Text_Clear()
    {
        LadyTalk_Text.text = " ";
    }

    //============
    //小視窗Lady的Party(Text)
    //============
    public void SetLadyParty_Text(float Party)
    {
        LadyParty_Text.text = "" + (int)Party;
    }

    //============
    //清空小視窗Lady的Party(Text)
    //============
    public void SetLadyParty_Text_Clear()
    {
        LadyParty_Text.text = " ";
    }

    //============
    //小視窗Lady的Love(Text)
    //============
    public void SetLadyLove_Text(float Love)
    {
        LadyLove_Text.text = "" + (int)Love;
    }

    //============
    //清空小視窗Lady的Love(Text)
    //============
    public void SetLadyLove_Text_Clear()
    {
        LadyLove_Text.text = " ";
    }

    //============
    //小視窗Lady的Skill(Text)
    //============
    public void SetLadySkill_Text(float Skill)
    {
        LadySkill_Text.text = "" + (int)Skill;
    }

    //============
    //清空小視窗Lady的Skill(Text)
    //============
    public void SetLadySkill_Text_Clear()
    {
        LadySkill_Text.text = " ";
    }

    //============
    //一次修改小視窗Lady的Name、Hp、Talk、Party、Love、Skill
    //============
    public void SetLady_Ability_Text(string Name , float Hp , float Talk , float Party , float Love , float Skill)
    {
        SetLadyName_Text(Name);
        SetLadyHp_Text(Hp);
        SetLadyTalk_Text(Talk);
        SetLadyParty_Text(Party);
        SetLadyLove_Text(Love);
        SetLadySkill_Text(Skill);
    }

    //============
    //一次清空小視窗Lady的Name、Hp、Talk、Party、Love、Skill
    //============
    public void SetLady_Ability_Text_Clear()
    {
        SetLadyName_Text_Clear();
        SetLadyHp_Text_Clear();
        SetLadyTalk_Text_Clear();
        SetLadyParty_Text_Clear();
        SetLadyLove_Text_Clear();
        SetLadySkill_Text_Clear();
    }

    //============
    //小視窗Lady的Hp的Bar_Image(Image)
    //============
    public void SetLadyHp_Bar_Image_FillAmount(Lady_Class Lady)
    {
        LadyHp_Bar_Image.fillAmount = Lady.GetHp() / Lady.GetHpMax();
    }

    //============
    //清空小視窗Lady的Hp的Bar_Image(Image)
    //============
    public void SetLadyHp_Bar_Image_FillAmount_Clear()
    {
        LadyHp_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //小視窗Lady的Talk的Bar_Image(Image)
    //============
    public void SetLadyTalk_Bar_Image_FillAmount(Lady_Class Lady)
    {
        LadyTalk_Bar_Image.fillAmount = Lady.GetTalk() / 9999.0f;
    }

    //============
    //清空小視窗Lady的Talk的Bar_Image(Image)
    //============
    public void SetLadyTalk_Bar_Image_FillAmount_Clear()
    {
        LadyTalk_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //小視窗Lady的Party的Bar_Image(Image)
    //============
    public void SetLadyParty_Bar_Image_FillAmount(Lady_Class Lady)
    {
        LadyParty_Bar_Image.fillAmount = Lady.GetParty() / 9999.0f;
    }

    //============
    //清空小視窗Lady的Party的Bar_Image(Image)
    //============
    public void SetLadyParty_Bar_Image_FillAmount_Clear()
    {
        LadyParty_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //小視窗Lady的Love的Bar_Image(Image)
    //============
    public void SetLadyLove_Bar_Image_FillAmount(Lady_Class Lady)
    {
        LadyLove_Bar_Image.fillAmount = Lady.GetLove() / 9999.0f;
    }

    //============
    //清空小視窗Lady的Love的Bar_Image(Image)
    //============
    public void SetLadyLove_Bar_Image_FillAmount_Clear()
    {
        LadyLove_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //小視窗Lady的Skill的Bar_Image(Image)
    //============
    public void SetLadySkill_Bar_Image_FillAmount(Lady_Class Lady)
    {
        LadySkill_Bar_Image.fillAmount = Lady.GetSkill() / 9999.0f;
    }

    //============
    //清空小視窗Lady的Skill的Bar_Image(Image)
    //============
    public void SetLadySkill_Bar_Image_FillAmount_Clear()
    {
        LadySkill_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //一次修改小視窗Lady的Bar_Image
    //============
    public void SetLady_Bar_Image_FillAmount(Lady_Class Lady)
    {
        SetLadyHp_Bar_Image_FillAmount(Lady);
        SetLadyTalk_Bar_Image_FillAmount(Lady);
        SetLadyParty_Bar_Image_FillAmount(Lady);
        SetLadyLove_Bar_Image_FillAmount(Lady);
        SetLadySkill_Bar_Image_FillAmount(Lady);
    }

    //============
    //一次清空小視窗Lady的Bar_Image
    //============
    public void SetLady_Bar_Image_FillAmount_Clear()
    {
        SetLadyHp_Bar_Image_FillAmount_Clear();
        SetLadyTalk_Bar_Image_FillAmount_Clear();
        SetLadyParty_Bar_Image_FillAmount_Clear();
        SetLadyLove_Bar_Image_FillAmount_Clear();
        SetLadySkill_Bar_Image_FillAmount_Clear();
    }


    //============
    //小視窗Lady的Looks的Color(Sexy)
    //============
    public void SetLady_Looks_Sexy_Color(Lady_Class Lady)
    {
        Lady_Looks_Sexy.color = GVU.GetLady_Looks_Color(Lady.GetSexy());
    }

    //============
    //小視窗Lady的Looks的Color(Beauty)
    //============
    public void SetLady_Looks_Beauty_Color(Lady_Class Lady)
    {
        Lady_Looks_Beauty.color = GVU.GetLady_Looks_Color(Lady.GetBeauty());
    }

    //============
    //小視窗Lady的Looks的Color(Cute)
    //============
    public void SetLady_Looks_Cute_Color(Lady_Class Lady)
    {
        Lady_Looks_Cute.color = GVU.GetLady_Looks_Color(Lady.GetCute());
    }

    //============
    //小視窗Lady的Looks的Color(Funny)
    //============
    public void SetLady_Looks_Funny_Color(Lady_Class Lady)
    {
        Lady_Looks_Funny.color = GVU.GetLady_Looks_Color(Lady.GetFunny());
    }

    //============
    //一次修改小視窗Lady的Color
    //============
    public void SetLady_Looks_Color(Lady_Class Lady)
    {
        SetLady_Looks_Sexy_Color(Lady);
        SetLady_Looks_Beauty_Color(Lady);
        SetLady_Looks_Cute_Color(Lady);
        SetLady_Looks_Funny_Color(Lady);
    }

    //============
    //(GameCustomerInformation)
    //============

    //============
    //GameCustomerInformation的Ability(Text)
    //============
    public void SetGameCustomerInformation_Ability_Text(string CustomerAbility) {
        CustomerInformation_Ability_Text.text = "" + GVU.GetCustomer_AbilityInformation(CustomerAbility);
    }

    //============
    //GameCustomerInformation_的Looks(Text)
    //============
    public void SetGameCustomerInformation_Looks_Text(string CustomerLooks)
    {
        GameCustomerInformation_Looks_Text.text = "" + GVU.GetCustomer_LooksInformation(CustomerLooks);
    }

    //============
    //GameCustomerInformation_的Looks(Text)
    //============
    public void SetGameCustomerInformation_Time_Text(float CustomerTime)
    {
        GameCustomerInformation_Time_Text.text = "" + GVU.GetCustomer_TimeInformation(CustomerTime);
    }


    //============
    //清空GameCustomerInformation的Ability(Text)
    //============
    public void SetGameCustomerInformation_Ability_Text_Clear()
    {
        CustomerInformation_Ability_Text.text = " " ;
    }

    //============
    //清空GameCustomerInformation_的Looks(Text)
    //============
    public void SetGameCustomerInformation_Looks_Text_Clear()
    {
        GameCustomerInformation_Looks_Text.text = " " ;
    }

    //============
    //清空GameCustomerInformation_的Looks(Text)
    //============
    public void SetGameCustomerInformation_Time_Text_Clear()
    {
        GameCustomerInformation_Time_Text.text = " " ;
    }



    //============
    //(GameEarnMoney)
    //============

    //============
    //GameEarnMoney的SeatNumber(Text)
    //============
    public void SetGameEarnMoney_SeatNumber_Text(CustomerSeat_Class CustomerSeat) {
        GameEarnMoney_SeatNumber_Text.text = "" + (CustomerSeat.Getid() + 1) + " 號桌 消費金額";      
    }

    //============
    //GameEarnMoney的MoneyRevenue(Text)
    //============
    public void SetGameEarnMoney_MoneyRevenue_Text(CustomerSeat_Class CustomerSeat)
    {       
        GameEarnMoney_MoneyRevenue_Text.text = "" + GVU.SetGameEarnMoney_MoneyRevenue(CustomerSeat.GetInCome()) + " 元";       
    }

    //============
    //清空GameEarnMoney的SeatNumber(Text)
    //============
    public void SetGameEarnMoney_SeatNumber_Text_Clear()
    {
        GameEarnMoney_SeatNumber_Text.text = " 號桌 消費金額";
    }

    //============
    //清空GameEarnMoney的MoneyRevenue(Text)
    //============
    public void SetGameEarnMoney_MoneyRevenue_Text_Clear()
    {
        GameEarnMoney_MoneyRevenue_Text.text =  " 元";
    }



    //============
    //(GameFever)
    //============

    //============
    //GameFever的Energy的數值(Text)
    //============
    public void SetGameFever_Wine_Text(float FeverEnergy) {
        GameFever_Text.text = "" + (int)FeverEnergy + "%";
    }

    //============
    //GameFever的Energy的Bar_Image(Image)
    //============
    public void SetGameFever_Bar_Image(float FeverEnergy)
    {
        GameFever_Bar_Image.fillAmount = FeverEnergy / 100.0f;
    }

    //============
    //GameFever的Energy的Button是否可使用(Button)
    //============
    public void SetGameFever_Button(bool isFever)
    {
        GameFever_Button.interactable = isFever;
    }

    //============
    //(GameInformation)
    //============

    //============
    //GameInformation的Text(Text)，(id : Gameinformation_Text的陣列編號)
    //============
    public void SetGameInformation_Text(int id , string Informationstring)
    {
        Gameinformation_Text[id].text = "" + Informationstring;    
    }

    //============
    //(GameCustomerSeat)
    //============

    //============
    //CustomerSeat上的Lady的大頭照(Sprite)
    //============
    public void SetCustomerSeat_LadyHeadShot(CustomerSeat_Class CustomerSeat)
    {
        if (CustomerSeat.GetisLady() == true) CustomerSeat_LadyHeadShot[CustomerSeat.Getid()].sprite = GVU.LadyHeadShot[CustomerSeat.GetLady().Getid()];
        else CustomerSeat_LadyHeadShot[CustomerSeat.Getid()].sprite = null;
    }

    //============
    //CustomerSeat上的Customer的心情照(Sprite)
    //============
    public void SetCustomerSeat_CustomerHeadShot(CustomerSeat_Class CustomerSeat)
    {
        //如果CustomerSeat有客人 且 有Lady 則設為心情照
        if (CustomerSeat.GetisGame() == true && CustomerSeat.GetisLady() == true) CustomerSeat_CustomerHeadShot[CustomerSeat.Getid()].sprite = GVU.GetCustoemr_Emotion_Sprite(CustomerSeat.GetCustomer().GetEmotion());
        //如果CustomerSeat有客人 且 沒有Lady 則設為等待照
        else if (CustomerSeat.GetisGame() == true && CustomerSeat.GetisLady() == false) CustomerSeat_CustomerHeadShot[CustomerSeat.Getid()].sprite = GVU.Custoemr_Wait_Sprite;
        //如果CustomerSeat沒有客人 且 沒有Lady 則設為空白
        else CustomerSeat_CustomerHeadShot[CustomerSeat.Getid()].sprite = null;

    }

    //============
    //CustomerSeat上的暫存Customer的心情照(Sprite)(Emotion: 計算的Emotion, Temp_CustomerSeat_id: 暫存選擇的CustomerSeat的id  Temp_LadySeat_id: 暫存選擇的LadySeat的id isLady: 是否有Lady)
    //============
    public void SetTempCustomerSeat_CustomerHeadShot(int Emotion , int Temp_CustomerSeat_id )
    {
        //CustomerSeat有Lady
         CustomerSeat_CustomerHeadShot[Temp_CustomerSeat_id].sprite = GVU.GetCustoemr_Emotion_Sprite(Emotion);
        //CustomerSeat沒有Lady
        //CustomerSeat_CustomerHeadShot[Temp_CustomerSeat_id].sprite = GVU.Custoemr_Wait_Sprite;

    }

    //============
    //CustomerSeat上的Customer的喜好Ability(Text)
    //============
    public void SetCustomerSeat_Ability_Text(CustomerSeat_Class CustomerSeat)
    {
        CustomerSeat_Ability_Text[CustomerSeat.Getid()].text = "• " + CustomerSeat.GetCustomer().GetAbility() + " •";
    }

    //============
    //CustomerSeat上的Customer的Range(Text)
    //============
    public void SetCustomerSeat_Range_Text(CustomerSeat_Class CustomerSeat)
    {
        CustomerSeat_Range_Text[CustomerSeat.Getid()].text = "" + GVU.GetCustomer_Level_string(CustomerSeat.GetCustomer().GetLevel());
        CustomerSeat_Range_Text[CustomerSeat.Getid()].color = GVU.GetCustomer_Level_Color(CustomerSeat.GetCustomer().GetLevel());
    }

    //============
    //CustomerSeat上的Customer的喜好Ability的Outline顏色(Color)
    //============
    public void SetCustomer_Ability_Outline(CustomerSeat_Class CustomerSeat)
    {
        Customer_Ability_Outline[CustomerSeat.Getid()].effectColor = GVU.GetCustomer_Ability_Outline_Color(CustomerSeat.GetCustomer().GetAbility());
    }

    //============
    //CustomerSeat的Situation(Text)
    //============
    public void SetCustomerSeat_Situation_Text(CustomerSeat_Class CustomerSeat)
    {
        CustomerSeat_Situation_Text[CustomerSeat.Getid()].text = "" + GVU.GetCustomerSeat_Situation_string(CustomerSeat);
    }

    //============
    //清空CustomerSeat的Range(Text)、喜好Ability(Text)、Situation(Text)、Ability的Outline顏色(Color)
    //============
    public void SetCustomerSeat_Range_Ability_Situation_Clear(CustomerSeat_Class CustomerSeat)
    {
        CustomerSeat_Range_Text[CustomerSeat.Getid()].text = " " ;
        CustomerSeat_Range_Text[CustomerSeat.Getid()].color = GVU.GetCustomer_Level_Color(0);
        CustomerSeat_Ability_Text[CustomerSeat.Getid()].text = " ";
        Customer_Ability_Outline[CustomerSeat.Getid()].effectColor = GVU.GetCustomer_Ability_Outline_Color("");
        CustomerSeat_Situation_Text[CustomerSeat.Getid()].text = " ";
    }

    //============
    //全部CustomerSeat上的等待Bar_Image(Image)
    //============
    public void SetAllCustomerSeat_WaitTime_Image(CustomerSeat_Class[] CustomerSeat)
    {
        for (i = 0; i < CustomerSeat.Length; i++)  CustomerSeat_WaitTime_Image[CustomerSeat[i].Getid()].fillAmount = CustomerSeat[i].GetWaitTime() / 9.0f;
    }

    //============
    //CustomerSeat上的等待Bar_Image(Image)
    //============
    public void SetCustomerSeat_WaitTime_Image(CustomerSeat_Class CustomerSeat)
    {
        CustomerSeat_WaitTime_Image[CustomerSeat.Getid()].fillAmount = CustomerSeat.GetWaitTime() / 9.0f;
    }


    //============
    //全部CustomerSeat上的遊玩時間的Image
    //============
    public void SetAllCustomerSeat_CostTime_Image(CustomerSeat_Class[] CustomerSeat)
    {
        for (i = 0; i < CustomerSeat.Length; i++) CustomerSeat_CostTime_Image[CustomerSeat[i].Getid()].fillAmount = CustomerSeat[i].GetGameTime() / 60.0f;
    }

    //============
    //CustomerSeat上的遊玩時間的Image(Image)
    //============
    public void SetCustomerSeat_CostTime_Image(CustomerSeat_Class CustomerSeat)
    {
        CustomerSeat_CostTime_Image[CustomerSeat.Getid()].fillAmount = CustomerSeat.GetGameTime() / 60.0f;
    }


    //============
    //開啟或關閉全部，Customer_Exclamation Button的interactable(ButtonState: 開啟或關閉Button)
    //============
    public void SetAllCustomer_Exclamation_Button_interactable(bool ButtonState)
    {
        for (i = 0; i < Customer_Exclamation_Button.Length; i++)
        {
            Customer_Exclamation_Button[i].interactable = ButtonState;
        }
    }

    //============
    //開啟或關閉CustomerSeat有問題、爭執事件的，Customer_Exclamation Button的interactable
    //============
    public void SetCustomer_Exclamation_Button_interactable(CustomerSeat_Class CustomerSeat)
    {       
         if (CustomerSeat.GetisExclamation() == true || CustomerSeat.GetisArgue() == true) Customer_Exclamation_Button[CustomerSeat.Getid()].interactable = true;
         else Customer_Exclamation_Button[CustomerSeat.Getid()].interactable = false;       
    }

    //============
    //開啟或關閉全部，Customer_Checkout_Button的interactable(ButtonState: 開啟或關閉Button)
    //============
    public void SetAllCustomer_Checkout_Button_interactable(bool ButtonState)
    {
        for (i = 0; i < Customer_Checkout_Button.Length; i++)
        {
            Customer_Checkout_Button[i].interactable = ButtonState;
        }
    }

    //============
    //開啟或關閉CustomerSeat有結帳事件的，Customer_Checkout_Button的interactable 
    //============
    public void SetCustomer_Checkout_Button_interactable(CustomerSeat_Class CustomerSeat)
    {
        if (CustomerSeat.GetisCheckout() == true) Customer_Checkout_Button[CustomerSeat.Getid()].interactable = true;
        else Customer_Checkout_Button[CustomerSeat.Getid()].interactable = false;
    }

    //============
    //開啟或關閉全部，CustoemrSeat上Lady的Button的interactable(ButtonState: 開啟或關閉Button)
    //============
    public void SetAllCustomerSeatLady_Button_interactable(bool ButtonState)
    {
        for (i = 0; i < CustomerSeatLady_Button.Length; i++)
        {
            CustomerSeatLady_Button[i].interactable = ButtonState;
        }
    }

    //============
    //開啟或關閉CustoemrSeat上Lady的Button，CustoemrSeat上Lady的Button的interactable，在有Customer 且 沒有問題、爭執、結帳事件
    //============
    public void SetCustomerSeatLady_Button_interactable(CustomerSeat_Class CustomerSeat)
    {
        if (CustomerSeat.GetisGame() == true && (CustomerSeat.GetisExclamation() == false && CustomerSeat.GetisArgue() == false && CustomerSeat.GetisCheckout() == false)) CustomerSeatLady_Button[CustomerSeat.Getid()].interactable = true;
        else CustomerSeatLady_Button[CustomerSeat.Getid()].interactable = false;
    }

    //============
    //開啟或關閉，有Customer的CustoemrSeat上Lady的Button，CustoemrSeat上Lady的Button的interactable 
    //============
    public void SetCustomerSeatLady_Customer_Lady_Button_interactable(CustomerSeat_Class[] CustomerSeat)
    {
        for (i = 0; i < CustomerSeat.Length; i++)
        {
            if (CustomerSeat[i].GetisGame() == true && (CustomerSeat[i].GetisExclamation() == false && CustomerSeat[i].GetisArgue() == false && CustomerSeat[i].GetisCheckout() == false)) CustomerSeatLady_Button[CustomerSeat[i].Getid()].interactable = true;
            else CustomerSeatLady_Button[CustomerSeat[i].Getid()].interactable = false;
        }
    }

    //============
    //(GameSituation)
    //============

    //============
    //問題、爭執、結帳事件的事件圖(Sprite)(Code : 問題事件、爭執事件、結帳事件 ， id : 事件編號)
    //============
    public void SetGameSituation_Code_Sprite(int Code , int id)
    {
        //問題事件
        if (Code == 0) GameSituation_Code_Sprite.sprite = GVU.GetGameSituation_Code_Sprite(id);
        //爭執事件
        else if (Code == 1) GameSituation_Code_Sprite.sprite = GVU.GetGameArgue_Code_Sprite(id);
        //結帳事件
        else GameSituation_Code_Sprite.sprite = GVU.GetGameCalculation_Code_Sprite(id);
    }

    //============
    //問題、爭執、結帳事件的結果圖(Sprite)(id : 事件結果圖編號)
    //============
    public void SetGameSituation_CodeAnswer_Sprite(int id)
    {
        GameSituation_CodeAnswer_Sprite.sprite = GVU.GetGameSituation_CodeAnswer_Sprite(id);
    }

    //============
    //問題、爭執、結帳事件的題目(Text)
    //============
    public void SetGameSituation_CodeAnswer_Text(GameSituation_Class GameSituation)
    {
        GameSituation_Title_Text.text = "" + GameSituation.GetGameSituationName();
    }

    //============
    //問題、爭執、結帳事件的選項(Text)
    //============
    public void SetGameSituation_Answer_Text(GameSituation_Class GameSituation)
    {
        GameSituation_Answer_Text[0].text = "" + GameSituation.GetCorrectName();
        GameSituation_Answer_Text[1].text = "" + GameSituation.GetMistakeName_1();
        GameSituation_Answer_Text[2].text = "" + GameSituation.GetMistakeName_2();
        GameSituation_Answer_Text[3].text = "" + GameSituation.GetMistakeName_3();
    }

    //============
    //問題、爭執、結帳事件的結果(Text)
    //============
    public void SetGameSituation_Award_Text(GameSituation_Class GameSituation)
    {
        GameSituation_Award_Text.text = "" + GameSituation.GetConsole();
    }

    //============
    //開啟或關閉全部，問題、爭執、結帳事件的選項的interactable(Button)(ButtonState: 開啟或關閉Button)
    //============
    public void SetGameSituation_Answer_Button_interactable(bool ButtonState)
    {
        for (i = 0; i < GameSituation_Answer_Button.Length; i++)
        {
            GameSituation_Answer_Button[i].interactable = ButtonState;
        }
    }

    //============
    //將問題、爭執、結帳事件的結果圖(Sprite) 和 問題、爭執、結帳事件的結果(Text)清空
    //============
    public void SetGameSituation_Award_CodeAnswer_Clear()
    {
        GameSituation_Award_Text.text = " " ;
        GameSituation_CodeAnswer_Sprite.sprite = null;
    }

    //============
    //改變問題、爭執、結帳事件的選項的Position(Button)
    //============
    public void SetGameSituation_Answer_Button_Position()
    {
        int Random_Temp = 0;

        //隨機選一個問題、爭執、結帳事件的選項的Position
        Random_Temp = Random.RandomRange(0,4);

       

        //設定Position
        switch (Random_Temp) {
            case 0:
                {
                    GameSituation_Answer_Button[0].transform.position = GameSituationButtonPositionCanVas[0].transform.position;
                    GameSituation_Answer_Button[1].transform.position = GameSituationButtonPositionCanVas[1].transform.position;
                    GameSituation_Answer_Button[2].transform.position = GameSituationButtonPositionCanVas[2].transform.position;
                    GameSituation_Answer_Button[3].transform.position = GameSituationButtonPositionCanVas[3].transform.position;
                    break;
                }
            case 1:
                {
                    GameSituation_Answer_Button[0].transform.position = GameSituationButtonPositionCanVas[1].transform.position;
                    GameSituation_Answer_Button[1].transform.position = GameSituationButtonPositionCanVas[2].transform.position;
                    GameSituation_Answer_Button[2].transform.position = GameSituationButtonPositionCanVas[3].transform.position;
                    GameSituation_Answer_Button[3].transform.position = GameSituationButtonPositionCanVas[0].transform.position;
                    break;
                }
            case 2:
                {
                    GameSituation_Answer_Button[0].transform.position = GameSituationButtonPositionCanVas[2].transform.position;
                    GameSituation_Answer_Button[1].transform.position = GameSituationButtonPositionCanVas[3].transform.position;
                    GameSituation_Answer_Button[2].transform.position = GameSituationButtonPositionCanVas[0].transform.position;
                    GameSituation_Answer_Button[3].transform.position = GameSituationButtonPositionCanVas[1].transform.position;
                    break;
                }
            case 3:
                {
                    GameSituation_Answer_Button[0].transform.position = GameSituationButtonPositionCanVas[3].transform.position;
                    GameSituation_Answer_Button[1].transform.position = GameSituationButtonPositionCanVas[0].transform.position;
                    GameSituation_Answer_Button[2].transform.position = GameSituationButtonPositionCanVas[1].transform.position;
                    GameSituation_Answer_Button[3].transform.position = GameSituationButtonPositionCanVas[2].transform.position;
                    break;
                }


        }//switch
        
    }

    //============
    //(GameConsole)
    //============

    //============
    //GameConsole的大頭照，(sprite)(LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetGameConsole_HeadShot(LadySeat_Class LadySeat) {
        for (i = 0; i < GameConsole_HeadShot.Length; i++) {
            if (LadySeat.GetisLadySeat(i) == false) GameConsole_HeadShot[i].sprite = GVU.LadyHeadShot[LadySeat.GetLady(i).Getid()];
            else GameConsole_HeadShot[i].sprite = null;
        }
    }

    //============
    //GameConsole的來客數(Text)
    //============
    public void SetGameConsole_Customer_Text(uint ComeCustomerCount)
    {
        GameConsole_Customer_Text.text = "" + ComeCustomerCount;
    }

    //============
    //GameConsole的包廂收入(Text)
    //============
    public void SetGameConsole_Room_Text(uint RoomInCome)
    {
        GameConsole_Room_Text.text = "" + RoomInCome;
    }

    //============
    //GameConsole的餐飲總額(Text)
    //============
    public void SetGameConsole_Food_Text(uint FoodInCome)
    {
        GameConsole_Food_Text.text = "" + FoodInCome;
    }

    //============
    //GameConsole的禮品費(Text)
    //============
    public void SetGameConsole_Gift_Text(uint GiftMoney)
    {
        GameConsole_Gift_Text.text = "" + GiftMoney;
    }

    //============
    //GameConsole的人事費(Text)
    //============
    public void SetGameConsole_Cost_Text(uint WorkCost)
    {
        GameConsole_Cost_Text.text = "" + WorkCost;
    }

    //============
    //GameConsole的粉絲數(Text)
    //============
    public void SetGameConsole_Fans_Text(uint OnceFans)
    {
        GameConsole_Fans_Text.text = "" + OnceFans;
    }

   
    //============
    //GameConsole的獲利(Text)
    //============
    public void SetGameConsole_Sum_Text(uint OnceIncome)
    {
        GameConsole_Sum_Text.text = "" + OnceIncome;
    }

    //============
    //GameConsole的StaffIncome(Text)(LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetGameConsole_Sum_Text(LadySeat_Class LadySeat)
    {
        for (i = 0; i < LadySeat.GetLadyMax(); i++) {
            StaffIncome_Text[i].text = "" + LadySeat.GetLady(i).GetOnceIncome() + "元";
        }
    }

    //============
    //GameConsole的StaffLevelUp(Text)(LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetStaffLevelUp_Text(LadySeat_Class LadySeat)
    {
        for (i = 0; i < LadySeat.GetLadyMax(); i++)
        {
            //如果有升級
            if(LadySeat.GetLady(i).GetisLevelUp() == true )StaffLevelUp_Text[i].text = "Level UP!";
            else StaffLevelUp_Text[i].text = " ";
        }
    }

    //============
    //GameConsole的StaffLevel(Text)(LadySeat: 取得所有LadySeat的資料)
    //============
    public void SetStaffLevel_Text(LadySeat_Class LadySeat)
    {
        for (i = 0; i < LadySeat.GetLadyMax(); i++)
        {
            StaffLevel_Text[i].text = "" + LadySeat.GetLady(i).GetLevel();
        }
    }

    //============
    //GameConsole的GameConsole_Back_Text(Text)
    //============
    public void SetGameConsole_Back_Text(string Backstring)
    {
        GameConsole_Back_Text.text = "" + Backstring;
    }
    

    //============
    //開啟或關閉，GameConsole_Back_Button的interactable(Button)(ButtonState: 開啟或關閉Button)
    //============
    public void SetGameConsole_Back_Button_interactable(bool ButtonState)
    {
        GameConsole_Back_Button.interactable = ButtonState;
    }

   

    //============
    //(GamePause)
    //============

    //============
    //GamePause的GamePause_Continue_Text(Text)
    //============
    public void SetGamePause_Continue_Text(string Continuestring)
    {
        GamePause_Continue_Text.text = "" + Continuestring;
    }

    //============
    //GamePause的GamePause_Exit_Text(Text)
    //============
    public void SetGamePause_Exit_Text(string Exitstring)
    {
        GamePause_Exit_Text.text = "" + Exitstring;
    }

    //============
    //開啟或關閉，GamePause_Continue_Button的interactable(Button)(ButtonState: 開啟或關閉Button)
    //============
    public void SetGamePause_Continue_Button_interactable(bool ButtonState)
    {
        GamePause_Continue_Button.interactable = ButtonState;
    }

    //============
    //開啟或關閉，GamePause_Exit_Button的interactable(Button)(ButtonState: 開啟或關閉Button)
    //============
    public void SetGamePause_Exit_Button_interactable(bool ButtonState)
    {
        GamePause_Exit_Button.interactable = ButtonState;
    }

    //============
    //(Other)
    //============

    //============
    //BackButton的Text(Text)
    //============
    public void SetBackButton_Text(string Backstring)
    {
        BackButton_Text.text = "" + Backstring;
    }

    //============
    //開啟或關閉，BackButton的interactable(Button)(ButtonState: 開啟或關閉Button)
    //============
    public void SetBackButton_interactable(bool ButtonState)
    {
        BackButton.interactable = ButtonState;
    }

    //============
    //BackButton的Text的Color(Text)
    //============
    public void SetBackButton_Text_Color(float Alpha)
    {
        BackButton_Text.color = GVU.SetTextAlpha(BackButton_Text , Alpha);
    }

    //============
    //(GameObject)
    //============

    //============
    //GameLadiesBase
    //============
    public void SetGameLadiesBasePosition(float x , float y , float z)
    {
        GameLadiesBase.transform.position = new Vector3(x, y, z);    
    }

    //============
    //GameAbilityBase
    //============
    public void SetGameAbilityBasePosition(float x, float y, float z)
    {
        GameAbilityBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //GameCustomerBase
    //============
    public void SetGameCustomerBasePosition(float x, float y, float z)
    {
        GameCustomerBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //GameEarnMoneyBase
    //============
    public void SetGameEarnMoneyBasePosition(float x, float y, float z)
    {
        GameEarnMoneyBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //GameFeverBase
    //============
    public void SetGameFeverBasePosition(float x, float y, float z)
    {
        GameFeverBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //GameCustomerInformationBase
    //============
    public void SetGameCustomerInformationBasePosition(float x, float y, float z)
    {
        GameCustomerInformationBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //GameInformationBase
    //============
    public void SetGameInformationBasePosition(float x, float y, float z)
    {
        GameInformationBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //GameTimeBase
    //============
    public void SetGameTimeBasePosition(float x, float y, float z)
    {
        GameTimeBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //GameSituationBase
    //============
    public void SetGameSituationBasePosition(float x, float y, float z)
    {
        GameSituationBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //GameConsoleBase
    //============
    public void SetGameConsoleBasePosition(float x, float y, float z)
    {
        GameConsoleBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //GamePauseBase
    //============
    public void SetGamePauseBasePosition(float x, float y, float z)
    {
        GamePauseBase.transform.position = new Vector3(x, y, z);
    }


    //============
    //(GameObjectCanvas)
    //============


    //============
    //GameLadiesCanVas
    //============
    public void SetGameLadiesCanVasLocalPosition(float x, float y, float z)
    {
        GameLadiesCanVas.transform.localPosition = new Vector3(x, y, z);
    }

    //============
    //GameAbilityCanVas
    //============
    public void SetGameAbilityCanVasLocalPosition(float x, float y, float z)
    {
        GameAbilityCanVas.transform.localPosition = new Vector3(x, y, z);
    }

    //============
    //GameCustomerCanVas
    //============
    public void SetGameCustomerCanVasLocalPosition(float x, float y, float z)
    {
        GameCustomerCanVas.transform.localPosition = new Vector3(x, y, z);
    }

    //============
    //GameEarnMoneyCanVas
    //============
    public void SetGameEarnMoneyCanVasLocalPosition(float x, float y, float z)
    {
        GameEarnMoneyCanVas.transform.localPosition = new Vector3(x, y, z);
    }

    //============
    //GameFeverCanVas
    //============
    public void SetGameFeverCanVasLocalPosition(float x, float y, float z)
    {
        GameFeverCanVas.transform.localPosition = new Vector3(x, y, z);
    }

    //============
    //GameCustomerInformationCanVas
    //============
    public void SetGameCustomerInformationCanVasLocalPosition(float x, float y, float z)
    {
        GameCustomerInformationCanVas.transform.localPosition = new Vector3(x, y, z);
    }

    //============
    //GameInformationCanVas
    //============
    public void SetGameInformationCanVasLocalPosition(float x, float y, float z)
    {
        GameInformationCanVas.transform.localPosition = new Vector3(x, y, z);
    }

    //============
    //GameTimeCanVas
    //============
    public void SetGameTimeCanVasLocalPosition(float x, float y, float z)
    {
        GameTimeCanVas.transform.localPosition = new Vector3(x, y, z);
    }

    //============
    //GameSituationCanVas
    //============
    public void SetGameSituationCanVasLocalPosition(float x, float y, float z)
    {
        GameSituationCanVas.transform.localPosition = new Vector3(x, y, z);
    }

    //============
    //GameConsoleCanVas
    //============
    public void SetGameConsoleCanVasLocalPosition(float x, float y, float z)
    {
        GameConsoleCanVas.transform.localPosition = new Vector3(x, y, z);
    }

    //============
    //GamePauseCanVas
    //============
    public void SetGamePauseCanVasLocalPosition(float x, float y, float z)
    {
        GamePauseCanVas.transform.localPosition = new Vector3(x, y, z);
    }

   

    


}//View_Game_Script
