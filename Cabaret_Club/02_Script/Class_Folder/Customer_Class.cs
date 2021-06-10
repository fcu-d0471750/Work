/*
 * Class : Customer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Customer_Class : MonoBehaviour
{
    //======================================================
    //宣告屬性
    //======================================================

    //int : Level
    private int Level;

    //int : Emotion
    private int Emotion;

    //string : 喜好Ability
    private string Ability;

    //string : 喜好Looks
    private string Looks;

    //float : 遊玩時間
    private float Time;

   



    //======================================================
    //建構子(無參數)
    //======================================================
    public Customer_Class()
    {
        this.Level = 1;

        this.Emotion = 100;

        this.Ability = "Talk";

        this.Looks = "Sexy";

        this.Time = 40.0f;
    }

    //======================================================
    //建構子(有參數)
    //======================================================
    public Customer_Class(int Level , int Emotion , string Ability , string Looks , float Time)
    {
        this.Level = Level;

        this.Emotion = Emotion;

        this.Ability = Ability;

        this.Looks = Looks;

        this.Time = Time;
    }

    //======================================================
    //外部方法
    //======================================================

    //============
    //增加Emotion(int)
    //============
    public void AddEmotion(int Emotion)
    {
        this.Emotion = this.Emotion + Emotion;
        //如果超過100，則設為100
        if (this.Emotion > 100) this.Emotion = 100;
        //如果低於0，則設為0
        if (this.Emotion < 0) this.Emotion = 0;
    }

    //============
    //減少Emotion(int)
    //============
    public void SubEmotion(int Emotion)
    {
        this.Emotion = this.Emotion - Emotion;
        //如果超過100，則設為100
        if (this.Emotion > 100) this.Emotion = 100;
        //如果低於0，則設為0
        if (this.Emotion < 0) this.Emotion = 0;
    }

    //============
    //設定Emotion(Lady)
    //============
    public void SetEmotion(Lady_Class Lady) {

        //暫存計算的Emotion，公式為(CalAbility() + CalLooks() + CalLadyhierarchy() + CalLadyHp) / (1 + ( (Level-1) * 0.5) )
        int EmotionTemp;

        //暫存計算的Ability
        int AbilityTemp;

        //暫存計算的Looks
        int LooksTemp;

        //暫存計算的hierarchy
        int hierarchyTemp;

        //暫存計算的Hp
        int HpTemp;

        //計算
        AbilityTemp = CalAbility(Lady);
        LooksTemp = CalLooks(Lady);
        hierarchyTemp = CalLadyhierarchy(Lady);
        HpTemp = CalLadyHp(Lady);

        //總合
        EmotionTemp = (int)( (float)(AbilityTemp + LooksTemp + hierarchyTemp + HpTemp) / (1 + ((Level - 1) * 0.5)) );
        //如果超過100，則設為100
        if (EmotionTemp > 100) EmotionTemp = 100;
        //如果低於0，則設為0
        if (EmotionTemp < 0) EmotionTemp = 0;

        //設定Emotion
        this.Emotion = EmotionTemp;

    }

    //======================================================
    //內部方法
    //======================================================

    //============
    //計算Ability
    //============
    private int CalAbility(Lady_Class Lady) {
        //Customer喜好Talk
        if (this.Ability == "Talk")
        {
            return (int)(Lady.GetTalk() / 80.0f);
        }
        //Customer喜好Party
        else if (this.Ability == "Party")
        {
            return (int)(Lady.GetParty() / 80.0f);
        }
        //Customer喜好Love
        else if (this.Ability == "Love")
        {
            return (int)(Lady.GetLove() / 80.0f);
        }
        //Customer喜好Skill
        else if (this.Ability == "Skill")
        {
            return (int)(Lady.GetSkill() / 80.0f);
        }

        //預設回傳30
        return 30;
    }

    //============
    //計算Looks
    //============
    private int CalLooks(Lady_Class Lady)
    {
        if (Looks == "Sexy")
        {
            if (Lady.GetSexy() == "DCircle") return 30;
            else if (Lady.GetSexy() == "Circle") return 20;
            else if (Lady.GetSexy() == "Triangle") return 15;
            else return 10;
        }

        else if (Looks == "Beauty")
        {
            if (Lady.GetBeauty() == "DCircle") return 30;
            else if (Lady.GetBeauty() == "Circle") return 20;
            else if (Lady.GetBeauty() == "Triangle") return 15;
            else return 10;
        }

        else if (Looks == "Cute")
        {
            if (Lady.GetCute() == "DCircle") return 30;
            else if (Lady.GetCute() == "Circle") return 20;
            else if (Lady.GetCute() == "Triangle") return 15;
            else return 10;
        }

        else
        {
            if (Lady.GetFunny() == "DCircle") return 30;
            else if (Lady.GetFunny() == "Circle") return 20;
            else if (Lady.GetFunny() == "Triangle") return 15;
            else return 10;
        }

        //預設回傳30
        return 30;
    }

    //============
    //計算Lady的hierarchy
    //============
    public int CalLadyhierarchy(Lady_Class Lady) {

        //如果Lady的hierarchy為白金
        if (Lady.Gethierarchy() == 4) return 40;
        //如果Lady的hierarchy為金
        else if (Lady.Gethierarchy() == 3) return 30;
        //如果Lady的hierarchy為銀
        else if (Lady.Gethierarchy() == 2) return 20;
        //如果Lady的hierarchy為銅
        else return 10;

        //預設回傳40
        return 40;
    }

    //============
    //計算Lady的Hp
    //============
    public int CalLadyHp(Lady_Class Lady)
    {  
        //回傳Lady的Hp / 100
        return (int)(Lady.GetHp() / 100.0f);
    }

    //======================================================
    //Getter
    //======================================================

    //============
    //Level
    //============
    public int GetLevel()
    {
        return Level;
    }

    //============
    //Emotion
    //============
    public int GetEmotion()
    {
        return Emotion;
    }

    //============
    //Ability
    //============
    public string GetAbility()
    {
        return Ability;
    }


    //============
    //Looks
    //============
    public string GetLooks()
    {
        return Looks;
    }

    //============
    //Time
    //============
    public float GetTime()
    {
        return Time;
    }

    //======================================================
    //Setter
    //======================================================

    //============
    //Level
    //============
    public void SetLevel(int Level)
    {
        this.Level = Level;
    }

    //============
    //Emotion
    //============
    public void SetEmotion(int Emotion)
    {
        this.Emotion = Emotion;
    }

    //============
    //Ability
    //============
    public void SetAbility(string Ability)
    {
        this.Ability = Ability;
    }

    //============
    //Looks
    //============
    public void SetLooks(string Looks)
    {
        this.Looks = Looks;
    }

    //============
    //Time
    //============
    public void SetTime(float Time)
    {
        this.Time = Time;
    }

}//Customer_Class
