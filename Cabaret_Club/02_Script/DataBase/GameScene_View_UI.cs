/*
 * GameScene_View_UI : 讓View_Game_Script的UI的涵式庫
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene_View_UI : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //迴圈用
    int i,j;

    //======================================================
    //宣告UI
    //======================================================

    //============
    //Sprite
    //============

    //全部Lady的HeadShot
    public Sprite[] LadyHeadShot = new Sprite[30];

    //Looks的四種等級對應的Sprite，0:"DCircle"、1:"Circle"、2:"Triangle"、3:"Cross"
    public Sprite[] LooksSprite = new Sprite[4];

    //問題事件圖
    public Sprite[] GameSituation_Code_Sprite = new Sprite[5];

    //爭執事件圖
    public Sprite[] GameArgue_Code_Sprite = new Sprite[1];

    //結帳事件圖
    public Sprite[] GameCalculation_Code_Sprite = new Sprite[1];

    //事件結果圖，共兩個，圈和叉
    public Sprite[] GameSituation_CodeAnswer_Sprite = new Sprite[2];

    //Customer的Emotion
    public Sprite[] Custoemr_Emotion_Sprite = new Sprite[5];

    //Customer的等待照
    public Sprite Custoemr_Wait_Sprite;

    //============
    //Color
    //============

    //Lady的GameAbility小視窗Looks的顏色，共四種
    public Color[] Lady_Looks_Color = new Color[4];

    //Customer的喜好Ability的Outline顏色，共五種(Talk、Party、Love、Skill、空白)
    public Color[] Customer_Ability_Outline_Color = new Color[5];

    //Customer的等級顏色，共五種(大富豪、富豪、一般、貧窮、空白)
    public Color[] Customer_Level_Color = new Color[5];

    //GameSituation Award的Outline顏色
    public Color GameSituation_Award_Outline_Color;

    



    //======================================================
    //外部方法
    //======================================================


    //============
    //Looks的四種等級，(Lookstring : 四種等級對應的Sprite)
    //============
    public Sprite GetLooksSprite(string Lookstring)
    {
        if (Lookstring == "DCircle") return LooksSprite[0];
        else if (Lookstring == "Circle") return LooksSprite[1];
        else if (Lookstring == "Triangle") return LooksSprite[2];
        else return LooksSprite[3];
    }

    //============
    //Customer的Ability對應的Information，(CustomerAbilitystring : Customer的Ability)
    //============
    public string GetCustomer_AbilityInformation(string CustomerAbilitystring)
    {
        if (CustomerAbilitystring == "Talk") return "談吐優雅的小姐";
        else if (CustomerAbilitystring == "Party") return "較會帶氣氛的小姐";
        else if (CustomerAbilitystring == "Love") return "擁有戀愛感覺的小姐";
        else return "技巧較好的小姐";
    }

    //============
    //Customer的Looks對應的Information，(CustomerLookstring : Customer的Looks)
    //============
    public string GetCustomer_LooksInformation(string CustomerLookstring)
    {
        if (CustomerLookstring == "Sexy") return "外表性感的小姐";
        else if (CustomerLookstring == "Beauty") return "外表漂亮的小姐";
        else if (CustomerLookstring == "Cute") return "外表可愛的小姐";
        else return "外表有趣的小姐";
    }

    //============
    //Customer的Time對應的Information，(CustomerTimestring : Customer的Time)
    //============
    public string GetCustomer_TimeInformation(float CustomerTime)
    {
        if (CustomerTime >= 60.0f) return "長套餐";
        else if (CustomerTime < 60.0f && CustomerTime >= 30.0f) return "一般時間";
        else return "短套餐";
    }

    //============
    //Customer的Emotion對應的五種等級，(Emotion : Customer的Emotion)
    //============
    public Sprite GetCustoemr_Emotion_Sprite(float Emotion)
    {
        if (Emotion <= 100.0f && Emotion >= 80.0f) return Custoemr_Emotion_Sprite[0];
        else if (Emotion < 80.0f && Emotion >= 60.0f) return Custoemr_Emotion_Sprite[1];
        else if (Emotion < 60.0f && Emotion >= 40.0f) return Custoemr_Emotion_Sprite[2];
        else if (Emotion < 40.0f && Emotion >= 20.0f) return Custoemr_Emotion_Sprite[3];
        else return Custoemr_Emotion_Sprite[4];
    }

    //============
    //Lady的Looks對應的四種顏色，(Lookstring : Lady的Looks的string)
    //============
    public Color GetLady_Looks_Color(string Lookstring)
    {
        if (Lookstring == "DCircle") return Lady_Looks_Color[0];
        else if (Lookstring == "Circle") return Lady_Looks_Color[1];
        else if (Lookstring == "Triangle") return Lady_Looks_Color[2];
        else return Lady_Looks_Color[3];
    }

    //============
    //Customer的喜好Ability對應的五種Outline顏色，(CustomerAbilitystring : Customer的Ability)
    //============
    public Color GetCustomer_Ability_Outline_Color(string CustomerAbilitystring)
    {
        if (CustomerAbilitystring == "Talk") return Customer_Ability_Outline_Color[0];
        else if (CustomerAbilitystring == "Party") return Customer_Ability_Outline_Color[1];
        else if (CustomerAbilitystring == "Love") return Customer_Ability_Outline_Color[2];
        else if (CustomerAbilitystring == "Skill") return Customer_Ability_Outline_Color[3];
        else return Customer_Ability_Outline_Color[4];
    }

    //============
    //Customer的Level對應的四種string，(1:貧窮 2: 一般 3:富豪 4:大富豪)，(CustomerLevel : Customer的等級)
    //============
    public string GetCustomer_Level_string(int CustomerLevel)
    {
        switch (CustomerLevel)
        {
            case 1:
                return "貧窮";
                break;

            case 2:
                return "一般";
                break;

            case 3:
                return "富豪";
                break;

            case 4:
                return "大富豪";
                break;

            default:
                return " ";
                break;
        }//switch

    }

    //============
    //Customer的Level對應的四種顏色，(1:貧窮 2: 一般 3:富豪 4:大富豪 default:空白)，(CustomerLevel : Customer的等級)
    //============
    public Color GetCustomer_Level_Color(int CustomerLevel)
    {
        switch (CustomerLevel)
        {
            case 1:
                return Customer_Level_Color[0];
                break;

            case 2:
                return Customer_Level_Color[1];
                break;

            case 3:
                return Customer_Level_Color[2];
                break;

            case 4:
                return Customer_Level_Color[3];
                break;

            default:
                return Customer_Level_Color[4];
                break;
        }//switch

    }

    //============
    //CustomerSeat的Situation代表string
    //============
    public string GetCustomerSeat_Situation_string(CustomerSeat_Class CustomerSeat)
    {
        //如果發生問題事件
        if (CustomerSeat.GetisExclamation() == true) return "小姐需要幫助!";
        //如果發生爭執事件
        else if (CustomerSeat.GetisArgue() == true) return "發生爭執!";
        //如果發生結帳事件
        else if (CustomerSeat.GetisCheckout() == true) return "客人結帳";
        //沒事件
        else return " ";
    }


    //============
    //問題事件圖對應的事件圖，(id : 問題事件編號)
    //============
    public Sprite GetGameSituation_Code_Sprite(int id)
    {
        //如果id < GameSituation_Code_Sprite.Length，則回傳對應陣列編號的GameSituation_Code_Sprite
        if (id < GameSituation_Code_Sprite.Length) return GameSituation_Code_Sprite[id];
        //防止id超出陣列長度
        else return GameSituation_Code_Sprite[0];
    }

    //============
    //爭執事件圖對應的事件圖，(id : 爭執事件編號)
    //============
    public Sprite GetGameArgue_Code_Sprite(int id)
    {
        //如果id < GetGameArgue_Code_Sprite.Length，則回傳對應陣列編號的GameArgue_Code_Sprite
        if (id < GameArgue_Code_Sprite.Length) return GameArgue_Code_Sprite[id];
        //防止id超出陣列長度
        else return GameArgue_Code_Sprite[0];
    }

    //============
    //結帳事件圖對應的事件圖，(id : 結帳事件編號)
    //============
    public Sprite GetGameCalculation_Code_Sprite(int id)
    {
        //如果id < GameCalculation_Code_Sprite.Length，則回傳對應陣列編號的GameCalculation_Code_Sprite
        if (id < GameCalculation_Code_Sprite.Length) return GameCalculation_Code_Sprite[id];
        //防止id超出陣列長度
        else return GameCalculation_Code_Sprite[0];
    }

    //============
    //事件對應的結果圖，(id : 事件結果圖編號)
    //============
    public Sprite GetGameSituation_CodeAnswer_Sprite(int id)
    {
        //如果id < GameSituation_CodeAnswer_Sprite.Length，則回傳對應陣列編號的GameSituation_CodeAnswer_Sprite
        if (id < GameSituation_CodeAnswer_Sprite.Length) return GameSituation_CodeAnswer_Sprite[id];
        //防止id超出陣列長度
        else return GameSituation_CodeAnswer_Sprite[0];
    }


    //============
    //Text的透明度
    //============
    public Color SetTextAlpha(Text InputText , float Alpha)
    {
        Color TempColor = new Color(InputText.color.r , InputText.color.g , InputText.color.b );

        TempColor.a = Alpha;

        return TempColor;
    }

    //============
    //轉換GameEarnMoney的MoneyRevenue(ex 123456 -> 123,456)(uint : 4,294,967,295  First_Step,Second_Step,Third_Step,Four_Step)
    //============
    public string SetGameEarnMoney_MoneyRevenue(uint Income)
    {
        //暫存Income
        uint Income_Temp;
        //轉換結果
        string Income_string = "";

        //第1位string
        string First_string = "";
        //第2位string
        string Second_string = "";
        //第3位string
        string Third_string = "";
        //第4位string
        string Four_string = "";

        //第1位
        int First_Step;
        //第2位
        int Second_Step;
        //第3位
        int Third_Step;
        //第4位
        int Four_Step;

        //設定Income_Temp
        Income_Temp = Income;


        //============
        //第1位
        //============
        First_Step = (int)(Income_Temp / 1000000000);
        First_string = "" + First_Step ;
        
        //============
        //第2位
        //============
        Income_Temp = Income_Temp - (uint)(First_Step * 1000000000);
        Second_Step = (int)(Income_Temp / 1000000);
        Second_string = "" + Second_Step ;

        //============
        //第3位
        //============
        Income_Temp = Income_Temp - (uint)(Second_Step * 1000000);
        Third_Step = (int)(Income_Temp / 1000);
        Third_string = "" + Third_Step ;

        //============
        //第4位
        //============
        Income_Temp = Income_Temp - (uint)(Third_Step * 1000);
        Four_Step = (int)(Income_Temp);
        Four_string = "" + Four_Step ;


        //============
        //第1位轉換
        //============
        if (First_Step > 0) First_string = First_string + ",";
        else First_string = "";

        //============
        //第2位轉換
        //============.
        //如果為3位數
        if (Second_Step >= 100) Second_string = Second_string + ",";
        //如果為2位數
        else if (Second_Step >= 10 && Second_Step < 100)
        {
            //如果前一位不為0
            if (First_Step > 0) Second_string = "0" + Second_string + ",";
            //如果前一位為0
            else Second_string = Second_string + ",";
        }
        //如果為個位數
        else if (Second_Step > 0 && Second_Step < 10) {
            //如果前一位不為0
            if (First_Step > 0) Second_string = "00" + Second_string + ",";
            //如果前一位為0
            else Second_string = Second_string + ",";
        }
        //如果為0但前一位 > 0
        else if (Second_Step == 0 && First_Step > 0) Second_string = "000,";
        //如果為0前一位為0
        else Second_string = "";

        //============
        //第3位轉換
        //============
        //如果為3位數
        if (Third_Step >= 100) Third_string = Third_string + ",";
        //如果為2位數
        else if (Third_Step >= 10 && Third_Step < 100)
        {
            //如果前一位不為0
            if (Second_Step > 0) Third_string = "0" + Third_string + ",";
            //如果前一位為0
            else Third_string = Third_string + ",";
        }
        //如果為個位數
        else if (Third_Step > 0 && Third_Step < 10) {
            //如果前一位不為0
            if (Second_Step > 0)  Third_string = "00" + Third_string + ",";
            //如果前一位為0
            else Third_string = Third_string + ",";
        }
        //如果為0但前一位 > 0
        else if (Third_Step == 0 && Second_Step > 0) Third_string = "000,";
        //如果為0且前一位為0
        else Third_string = "";

        //============
        //第4位轉換
        //============
        //如果為3位數
        if (Four_Step >= 100) Four_string = Four_string + "";
        //如果為2位數
        else if (Four_Step >= 10 && Four_Step < 100) {
            //如果前一位不為0
            if (Third_Step > 0)  Four_string = "0" + Four_string + "";
            //如果前一位為0
            else Four_string =  Four_string + "";
        }
        //如果為個位數
        else if (Four_Step > 0 && Four_Step < 10)
        {
            //如果前一位不為0
            if (Third_Step > 0) Four_string = "00" + Four_string + ",";
            //如果前一位為0
            else Four_string = Four_string + ",";
        }
        //如果為0但前一位 > 0
        else if (Four_Step == 0 && Third_Step > 0) Four_string = "000";
        //如果為0且前一位為0
        else Four_string = "";

        //============
        //轉換總合
        //============
        Income_string = "" + First_string +  Second_string +  Third_string +  Four_string;


        return Income_string;

    }

}//GameScene_View_UI
