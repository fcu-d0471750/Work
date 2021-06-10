/*
 * class: Staff 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff_Class : MonoBehaviour
{
    //======================================================
    //宣告屬性
    //======================================================

    //int : id
    private int id;

    //string : Name
    private string Name;

    //string : Description
    private string Description;

    //Sprite:頭像
    private Sprite Headshot;

    //Sprite:階級
    private Sprite hierarchy_Sprite;

    //int:階級
    private int hierarchy;

    //int:等級
    private int Level;

    //uint(0 ~ 4,294,967,295) : 薪水
    private uint Cost;

    //ulong(0 ~ 18,446,744,073,709,551,615) : 總營業額
    private ulong AllIncome;

    //uint(0 ~ 4,294,967,295) : 單次營業額
    private uint OnceIncome;

    //uint : 經驗值
    private uint Experience;

    //uint : 升級所需經驗值
    private uint ExperienceMax;

    
    //==================
    //Abilitys
    //==================

    //float : Hp
    private float Hp;

    //float : HpMax
    private float HpMax;

    //float : Talk
    private float Talk;

    //float : Party
    private float Party;

    //float : Love
    private float Love;

    //float : Skill
    private float Skill;

    //==================
    //Looks
    //==================

    //string : Sexy
    private string Sexy;

    //string : Beauty
    private string Beauty;

    //string : Cute
    private string Cute;

    //string : Funny
    private string Funny;

    //==================
    //State
    //==================

    //是否解鎖，true:解鎖 false:未解鎖
    private bool isunLock;

    //是否出勤中，true:出勤中 false:未出勤
    private bool isWorked;

    //bool : 是否升級，true:有升級 false:沒有升級
    private bool isLevelUp;

    //======================================================
    //建構子(無參數)
    //======================================================
    public Staff_Class() {
        this.id = 1;

        this.Name = "小雪";
        this.Headshot = null;
        this.hierarchy_Sprite = null;
        this.hierarchy = 1;
        this.Level = 1;
        this.Cost = 10000;
        this.AllIncome = 0;
        this.OnceIncome = 0;

        this.Experience = 0;
        this.ExperienceMax = 10000;

        this.Hp = 500.0f;
        this.HpMax = 1000.0f;
        this.Talk = 200.0f;
        this.Party = 150.0f;
        this.Love = 100.0f;
        this.Skill = 80.0f;

        this.Sexy = "DCircle";
        this.Beauty = "Circle";
        this.Cute = "Triangle";
        this.Funny = "Cross";

        this.isunLock = true;
        this.isWorked = false;
        this.isLevelUp = false;

        this.Description = "蒼天堀";
    }

    //======================================================
    //建構子(有參數)
    //======================================================
    public Staff_Class(int id , string Name , string Description, Sprite Headshot , Sprite hierarchy_Sprite , int hierarchy , int Level , uint Cost , ulong AllIncome , uint OnceIncome , float Hp , float HpMax, float Talk, float Party , float Love , float Skill , string Sexy , string Beauty , string Cute , string Funny , bool isunLock , bool isWorked)
    {
        this.id = id;

        this.Name = Name;
        this.Headshot = Headshot;
        this.hierarchy_Sprite = hierarchy_Sprite;
        this.hierarchy = hierarchy;
        this.Level = Level;
        this.Cost = Cost;
        this.AllIncome = AllIncome;
        this.OnceIncome = OnceIncome;

        this.Experience = 0;
        this.ExperienceMax = 10000;

        this.Hp = Hp;
        this.HpMax = HpMax;
        this.Talk = Talk;
        this.Party = Party;
        this.Love = Love;
        this.Skill = Skill;

        this.Sexy = Sexy;
        this.Beauty = Beauty;
        this.Cute = Cute;
        this.Funny = Funny;

        this.isunLock = isunLock;
        this.isWorked = isWorked;
        this.isLevelUp = false;

        this.Description = Description;
    }

    //======================================================
    //Getter
    //======================================================

    //============
    //id
    //============
    public int Getid()
    {
        return id;
    }

    //============
    //Name
    //============
    public string GetName() {
        return Name;
    }

    //============
    //Description
    //============
    public string GetDescription()
    {
        return Description;
    }

    //============
    //Headshot
    //============
    public Sprite GetHeadshot(){
        return Headshot;
    }

    //============
    //hierarchy_Sprite
    //============
    public Sprite Gethierarchy_Sprite()
    {
        return hierarchy_Sprite;
    }

    //============
    //hierarchy
    //============
    public int Gethierarchy()
    {
        return hierarchy;
    }

    //============
    //Level
    //============
    public int GetLevel()
    {
        return Level;
    }

    //============
    //Cost
    //============
    public uint GetCost()
    {
        return Cost;
    }

    //============
    //AllIncome
    //============
    public ulong GetAllIncome()
    {
        return AllIncome;
    }

    //============
    //OnceIncome
    //============
    public uint GetOnceIncome()
    {
        return OnceIncome;
    }

    //============
    //Experience
    //============
    public uint GetExperience()
    {
        return Experience;
    }

    //============
    //Experience
    //============
    public uint GetExperienceMax()
    {
        return ExperienceMax;
    }


    //============
    //Hp
    //============
    public float GetHp()
    {
        return Hp;
    }

    //============
    //HpMax
    //============
    public float GetHpMax()
    {
        return HpMax;
    }

    //============
    //Talk
    //============
    public float GetTalk()
    {
        return Talk;
    }

    //============
    //Party
    //============
    public float GetParty()
    {
        return Party;
    }

    //============
    //Love
    //============
    public float GetLove()
    {
        return Love;
    }

    //============
    //Skill
    //============
    public float GetSkill()
    {
        return Skill;
    }

    //============
    //Sexy
    //============
    public string GetSexy()
    {
        return Sexy;
    }

    //============
    //Beauty
    //============
    public string GetBeauty()
    {
        return Beauty;
    }

    //============
    //Cute
    //============
    public string GetCute()
    {
        return Cute;
    }

    //============
    //Funny
    //============
    public string GetFunny()
    {
        return Funny;
    }


    //============
    //isunLock
    //============
    public bool GetisunLock()
    {
        return isunLock;
    }

    //============
    //isWorked
    //============
    public bool GetisWorked()
    {
        return isWorked;
    }

    //============
    //isLevelUp
    //============
    public bool GetisLevelUp()
    {
        return isLevelUp;
    }

   

    //======================================================
    //Setter
    //======================================================

    //============
    //id
    //============
    public void Setid(int id)
    {
        this.id = id;
    }

    //============
    //Name
    //============
    public void SetName(string Name)
    {
        this.Name = Name;
    }

    //============
    //Description
    //============
    public void SetDescription(string Description)
    {
        this.Description = Description;
    }

    //============
    //Headshot
    //============
    public void SetHeadshot(Sprite Headshot)
    {
        this.Headshot = Headshot;
    }

    //============
    //hierarchy_Sprite
    //============
    public void Sethierarchy_Sprite(Sprite hierarchy_Sprite)
    {
        this.hierarchy_Sprite = hierarchy_Sprite;
    }

    //============
    //hierarchy
    //============
    public void Sethierarchy(int hierarchy)
    {
        this.hierarchy = hierarchy;
    }

    //============
    //Level
    //============
    public void SetLevel(int Level)
    {
        this.Level = Level;
    }

    //============
    //Cost
    //============
    public void SetCost(uint Cost)
    {
        this.Cost = Cost;
    }

    //============
    //AllIncome
    //============
    public void SetAllIncome(ulong AllIncome)
    {
        this.AllIncome = AllIncome;
    }

    //============
    //OnceIncome
    //============
    public void SetOnceIncome(uint OnceIncome)
    {
        this.OnceIncome = OnceIncome;
    }

    //============
    //Experience
    //============
    public void SetExperience(uint Experience)
    {
        this.Experience = Experience;
    }

    //============
    //ExperienceMax
    //============
    public void SetExperienceMax(uint ExperienceMax)
    {
        this.ExperienceMax = ExperienceMax;
    }
   

    //============
    //Hp
    //============
    public void SetHp(float Hp)
    {
        this.Hp = Hp;
    }

    //============
    //HpMax
    //============
    public void SetHpMax(float HpMax)
    {
        this.HpMax = HpMax;
    }

    //============
    //Talk
    //============
    public void SetTalk(float Talk)
    {
        this.Talk = Talk;
    }

    //============
    //Party
    //============
    public void SetParty(float Party)
    {
        this.Party = Party;
    }

    //============
    //Love
    //============
    public void SetLove(float Love)
    {
        this.Love = Love;
    }

    //============
    //Skill
    //============
    public void SetSkill(float Skill)
    {
        this.Skill = Skill;
    }

    //============
    //Sexy
    //============
    public void SetSexy(string Sexy)
    {
        this.Sexy = Sexy;
    }

    //============
    //Beauty
    //============
    public void SetBeauty(string Beauty)
    {
        this.Beauty = Beauty;
    }

    //============
    //Cute
    //============
    public void SetCute(string Cute)
    {
        this.Cute = Cute;
    }

    //============
    //Funny
    //============
    public void SetFunny(string Funny)
    {
        this.Funny = Funny;
    }


    //============
    //isunLock
    //============
    public void SetisunLock(bool isunLock)
    {
        this.isunLock = isunLock;
    }

    //============
    //isWorked
    //============
    public void SetisWorked(bool isWorked)
    {
        this.isWorked = isWorked;
    }

    //============
    //isLevelUp
    //============
    public void SetisLevelUp(bool isLevelUp)
    {
        this.isLevelUp = isLevelUp;
    }

    

}//Staff_Class
