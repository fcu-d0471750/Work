/*
 * Class : Lady 
 * 繼承Staff_Class
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lady_Class : Staff_Class
{
    //======================================================
    //宣告屬性
    //======================================================

    //======================================================
    //建構子(無參數)
    //======================================================
    public Lady_Class()
    {
        Setid(1);

        SetName("小雪");
        SetHeadshot(null);
        Sethierarchy_Sprite(null);
        Sethierarchy(1);
        SetLevel(1);
        SetCost(10000);
        SetAllIncome(0);
        SetOnceIncome(0);

        SetHp(200.0f);
        SetHpMax(1000.0f);
        SetTalk(1000.0f);
        SetParty(150.0f);
        SetLove(100.0f);
        SetSkill(80.0f);

        SetSexy("DCircle");
        SetBeauty("Circle");
        SetCute("Triangle");
        SetFunny("Cross");

        SetisunLock(true);
        SetisWorked(false);
        SetisLevelUp(false);

        SetDescription("蒼天堀");

       
    }

    //======================================================
    //建構子(有參數)
    //======================================================
    public Lady_Class(int id , string Name, string Description, Sprite Headshot, Sprite hierarchy_Sprite, int hierarchy, int Level, uint Cost, ulong AllIncome, uint OnceIncome, float Hp, float HpMax , float Talk, float Party, float Love, float Skill, string Sexy, string Beauty, string Cute, string Funny , bool isunLock, bool isWorked)
    {
        Setid(id);

        SetName(Name);
        SetHeadshot(Headshot);
        Sethierarchy_Sprite(hierarchy_Sprite);
        Sethierarchy(hierarchy);
        SetLevel(Level);
        SetCost(Cost);
        SetAllIncome(AllIncome);
        SetOnceIncome(OnceIncome);

        SetHp(Hp);
        SetHpMax(HpMax);
        SetTalk(Talk);
        SetParty(Party);
        SetLove(Love);
        SetSkill(Skill);

        SetSexy(Sexy);
        SetBeauty(Beauty);
        SetCute(Cute);
        SetFunny(Funny);

        SetisunLock(isunLock);
        SetisWorked(isWorked);
        SetisLevelUp(false);

        SetDescription(Description);
    }


    //======================================================
    //初始化
    //======================================================
    private void Awake()
    {

    }


    //======================================================
    //外部方法
    //======================================================

    //============
    //小姐出勤時，扣除Hp
    //============
    public void DoGame_SubHp() {
        //扣除Hp
        SetHp(GetHp() - Time.deltaTime);
        //如果Hp扣到 <= 0.0f，則將Hp設為0.0f
        if (GetHp() <= 0.0f) SetHp(0.0f);    
    }

    //============
    //小姐休息時，恢復Hp
    //============
    public void DoGame_AddHp()
    {
        //恢復Hp
        SetHp(GetHp() + Time.deltaTime);
        //如果Hp加到 >= HpMax，則將Hp設為HpMax
        if (GetHp() >= GetHpMax()) SetHp(GetHpMax());
    }

    //============
    //增加小姐經驗值
    //============
    public void AddExperience(uint Exe)
    {     
        SetExperience(GetExperience() + Exe);
    }

    //============
    //檢查小姐升級
    //============
    public void DoLevelUpCheck()
    {
        //如果小姐的經驗值 >= 升級所需的經驗值，則升級
        if (GetExperience() >= GetExperienceMax())
        {
            DoLevelUp();
            SetisLevelUp(true);
        }

    }

    

    //======================================================
    //內部方法
    //======================================================

    //============
    //小姐升級
    //============
    private void DoLevelUp()
    {
        //如果獲得很多經驗值，則一直升級，直到無法升級為止
        do
        {
            //重新計算經驗值
            SetExperience(GetExperience() - GetExperienceMax());

            //重新設定升級所需的經驗值
            SetExperienceMax((uint)(Gethierarchy() * 50000) + (uint)(GetLevel() * 200000));

            //等級提升
            SetLevel(GetLevel() + 1);

            //Hp提升
            SetHp(GetHp() + (Gethierarchy() * 20));
            if (GetHp() > GetHpMax()) SetHp(GetHpMax());
            //Talk提升
            SetTalk(GetTalk() + (Gethierarchy() * 15));
            if (GetTalk() > 9999.0f) SetTalk(9999.0f);
            //Party提升
            SetParty(GetParty() + (Gethierarchy() * 15));
            if (GetParty() > 9999.0f) SetParty(9999.0f);
            //Love提升
            SetLove(GetLove() + (Gethierarchy() * 15));
            if (GetLove() > 9999.0f) SetLove(9999.0f);
            //Skill提升
            SetSkill(GetSkill() + (Gethierarchy() * 15));
            if (GetSkill() > 9999.0f) SetSkill(9999.0f);

        } while (GetExperience() >= GetExperienceMax());

    }

}//Lady_Class
