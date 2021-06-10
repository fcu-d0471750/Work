/*
 * Class : 問題事件
 * 
 * 事件
 * 小姐用酒杯、客人用酒杯、更換毛巾、菜單、更換菸灰缸
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSituation_Class : MonoBehaviour
{
    //======================================================
    //宣告屬性
    //======================================================

    //問題編號
    private int id;

    //srting : 事件名稱
    private string GameSituationName;

    //srting : 正確選項名稱
    private string CorrectName;

    //srting : 錯誤選項名稱1
    private string MistakeName_1;

    //srting : 錯誤選項名稱2
    private string MistakeName_2;

    //srting : 錯誤選項名稱3
    private string MistakeName_3;

    //srting : 結果敘述
    private string Console;

    //Sprite : 事件圖案
    private Sprite GameSituationSprite;

    //Sprite : 事件完成圖案
    private Sprite GameRewardSprite;

    

    //======================================================
    //建構子(無參數)
    //======================================================
    public GameSituation_Class() {
        this.id = 0;
        this.GameSituationName = "小姐在打暗號";
        this.CorrectName = "小姐用酒杯";
        this.MistakeName_1 = "更換毛巾";
        this.MistakeName_2 = "客人用酒杯";
        this.MistakeName_3 = "菜單";
        this.Console = "";

        this.GameSituationSprite = null;
        this.GameRewardSprite = null;
    }

    //======================================================
    //建構子(有參數)
    //======================================================
    public GameSituation_Class(int id , string GameSituationName , string CorrectName, string MistakeName_1, string MistakeName_2, string MistakeName_3 , Sprite GameSituationSprite)
    {
        this.id = id;
        this.GameSituationName = GameSituationName;
        this.CorrectName = CorrectName;
        this.MistakeName_1 = MistakeName_1;
        this.MistakeName_2 = MistakeName_2;
        this.MistakeName_3 = MistakeName_3;

        this.Console = "";
        this.GameSituationSprite = GameSituationSprite;
        this.GameRewardSprite = null;
    }

    //======================================================
    //外部方法
    //======================================================

    //============
    //正確答案
    //============
    public void DoCorrect(CustomerSeat_Class CustomerSeat)
    {
        //增加CustomerSeat營業額 50000 元
        CustomerSeat.SetInCome(CustomerSeat.GetInCome() + 50000);
        //增加Customer的Emotion 5 點
        CustomerSeat.GetCustomer().AddEmotion(5);

        //恢復Lady Hp，增加量為Lady的HpMax的25%
        CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHp() + (CustomerSeat.GetLady().GetHpMax() * 0.25f));
        //如果Lady恢復的Hp超過HpMax，則將Hp設為HpMax
        if (CustomerSeat.GetLady().GetHp() > CustomerSeat.GetLady().GetHpMax()) CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHpMax());

        //Lady增加單次營業額 50000 元(重複相加)
        //CustomerSeat.GetLady().SetOnceIncome(CustomerSeat.GetLady().GetOnceIncome() + 50000);

        //設定結果敘述
        this.Console = "小姐的體力恢復了。";

        

    }

    //============
    //錯誤答案
    //============
    public void DoMistake(CustomerSeat_Class CustomerSeat)
    {
        //減少Customer的Emotion 5 點
        CustomerSeat.GetCustomer().SubEmotion(5);
        //如果減少Customer的Emotion低於0，則將Emotion設為0
        if (CustomerSeat.GetCustomer().GetEmotion() < 0) CustomerSeat.GetCustomer().SetEmotion(0);

        //減少Lady Hp，減少量為Lady的HpMax的5%
        CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHp() - (CustomerSeat.GetLady().GetHpMax() * 0.05f));
        //如果Lady減少的Hp低於0，則將Hp設為0
        if (CustomerSeat.GetLady().GetHp() < 0 ) CustomerSeat.GetLady().SetHp(0);

        //設定結果敘述
        this.Console = "客人不高興了。";
    }

    //======================================================
    //Getter
    //======================================================

    //============
    //問題編號id
    //============
    public int Getid()
    {
        return this.id;
    }

    //============
    //GameSituationName
    //============
    public string GetGameSituationName()
    {
        return GameSituationName;
    }

    //============
    //CorrectName
    //============
    public string GetCorrectName()
    {
        return CorrectName;
    }

    //============
    //MistakeName_1
    //============
    public string GetMistakeName_1()
    {
        return MistakeName_1;
    }

    //============
    //MistakeName_2
    //============
    public string GetMistakeName_2()
    {
        return MistakeName_2;
    }

    //============
    //MistakeName_3
    //============
    public string GetMistakeName_3()
    {
        return MistakeName_3;
    }

    //============
    //Console
    //============
    public string GetConsole()
    {
        return Console;
    }

    //============
    //GameSituationSprite
    //============
    public Sprite GetGameSituationSprite()
    {
        return GameSituationSprite;
    }

    //============
    //GameRewardSprite
    //============
    public Sprite GetGameRewardSprite()
    {
        return GameRewardSprite;
    }

    //======================================================
    //Setter
    //======================================================

    //============
    //問題編號id
    //============
    public void Setid(int id)
    {
        this.id = id;
    }

    //============
    //GameSituationName
    //============
    public void SetGameSituationName(string GameSituationName)
    {
        this.GameSituationName = GameSituationName;
    }

    //============
    //CorrectName
    //============
    public void SetCorrectName(string CorrectName)
    {
        this.CorrectName = CorrectName;
    }

    //============
    //MistakeName_1
    //============
    public void SetMistakeName_1(string MistakeName)
    {
        this.MistakeName_1 = MistakeName;
    }

    //============
    //MistakeName_2
    //============
    public void SetMistakeName_2(string MistakeName)
    {
        this.MistakeName_2 = MistakeName;
    }

    //============
    //MistakeName_3
    //============
    public void SetMistakeName_3(string MistakeName)
    {
        this.MistakeName_3 = MistakeName;
    }

    //============
    //Console
    //============
    public void SetConsole(string Console)
    {
        this.Console = Console;
    }

    //============
    //GameSituationSprite
    //============
    public void SetGameSituationSprite(Sprite GameSituationSprite)
    {
        this.GameSituationSprite = GameSituationSprite;
    }

    //============
    //GameRewardSprite
    //============
    public void SetGameRewardSprite(Sprite GameRewardSprite)
    {
        this.GameRewardSprite = GameRewardSprite;
    }


}//GameSituation_Class
