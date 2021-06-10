/*
 * Class : 爭執事件，繼承GameSituation_Class
 * 
 * 爭執
 * 責罵小姐、袒護小姐、送上道歉禮品、送客
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArgue_Class : GameSituation_Class
{
    //======================================================
    //建構子(無參數)
    //======================================================
    public GameArgue_Class()
    {
        Setid(0);
        SetGameSituationName("發生爭執問題");
        SetCorrectName("責罵小姐");
        SetMistakeName_1("袒護小姐");
        SetMistakeName_2("送上道歉禮品");
        SetMistakeName_3("送客");
        SetConsole("");

        SetGameSituationSprite(null);
        SetGameRewardSprite(null);
    }

    //======================================================
    //建構子(有參數)
    //======================================================
    public GameArgue_Class(int id , string GameSituationName, string CorrectName, string MistakeName_1, string MistakeName_2, string MistakeName_3, Sprite GameSituationSprite)
    {
        Setid(id);
        SetGameSituationName(GameSituationName);
        SetCorrectName(CorrectName);
        SetMistakeName_1(MistakeName_1);
        SetMistakeName_2(MistakeName_2);
        SetMistakeName_3(MistakeName_3);
        SetConsole("");

        SetGameSituationSprite(GameSituationSprite);
        SetGameRewardSprite(null);
    }

    //======================================================
    //外部方法
    //======================================================

    //============
    //責罵小姐
    //============
    public void DoArgue(CustomerSeat_Class CustomerSeat)
    {
        //減少Customer的Emotion 5 點
        CustomerSeat.GetCustomer().SubEmotion(5);
        //如果減少Customer的Emotion低於0，則將Emotion設為0
        if (CustomerSeat.GetCustomer().GetEmotion() < 0) CustomerSeat.GetCustomer().SetEmotion(0);

        //減少Lady Hp，減少量為Lady的HpMax的10%
        CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHp() - (CustomerSeat.GetLady().GetHpMax() * 0.1f));
        //如果Lady減少的Hp低於0，則將Hp設為0
        if (CustomerSeat.GetLady().GetHp() < 0) CustomerSeat.GetLady().SetHp(0);

        //設定結果敘述
        SetConsole("小姐疲累了。");
    }

    //============
    //袒護小姐
    //============
    public void DoProtect(CustomerSeat_Class CustomerSeat)
    {
        //減少Customer的Emotion 10 點
        CustomerSeat.GetCustomer().SubEmotion(10);
        //如果減少Customer的Emotion低於0，則將Emotion設為0
        if (CustomerSeat.GetCustomer().GetEmotion() < 0) CustomerSeat.GetCustomer().SetEmotion(0);

        //減少Lady Hp，減少量為Lady的HpMax的10%
        CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHp() - (CustomerSeat.GetLady().GetHpMax() * 0.1f));
        //如果Lady減少的Hp低於0，則將Hp設為0
        if (CustomerSeat.GetLady().GetHp() < 0) CustomerSeat.GetLady().SetHp(0);

        //設定結果敘述
        SetConsole("客人更不高興了。");
    }

    //============
    //送上道歉禮品
    //============
    public void DoApologize(CustomerSeat_Class CustomerSeat)
    {
        //增加Customer的Emotion 5 點
        CustomerSeat.GetCustomer().AddEmotion(5);
        
        //減少Lady Hp，減少量為Lady的HpMax的10%
        CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHp() - (CustomerSeat.GetLady().GetHpMax() * 0.1f));
        //如果Lady減少的Hp低於0，則將Hp設為0
        if (CustomerSeat.GetLady().GetHp() < 0) CustomerSeat.GetLady().SetHp(0);

        //設定結果敘述
        SetConsole("安撫客人了。");
    }

    //============
    //送客
    //============
    public void DoOut(CustomerSeat_Class CustomerSeat , LadySeat_Class LadySeat)
    {

        //Lady增加單次營業額
        CustomerSeat.GetLady().SetOnceIncome(CustomerSeat.GetLady().GetOnceIncome() + CustomerSeat.GetInCome());

        //Lady回到LadySeat
        LadySeat.SetLadyBack(CustomerSeat.GetLady());

        //讓客人離開
        CustomerSeat.SetCustomerleave();

        //設定結果敘述
        SetConsole("客人離開了。");
    }


}//GameArgue_Class
