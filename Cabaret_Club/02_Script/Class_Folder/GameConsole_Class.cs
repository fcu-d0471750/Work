/*
 * GameConsole，結算
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConsole_Class : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //單次營業總額
    private uint OnceIncome = 0;

    //來客數
    private uint ComeCustomerCount = 0;

    //包廂收入
    private uint RoomInCome = 0;

    //餐飲總額
    private uint FoodInCome = 0;

    //禮品費
    private uint GiftMoney = 0;

    //人事費
    private uint WorkCost = 0;

    //單次粉絲數
    private uint OnceFans = 0;


    //======================================================
    //建構子(無參數)
    //======================================================
    public GameConsole_Class()
    {
        this.OnceIncome = 0;
        this.ComeCustomerCount = 0;
        this.RoomInCome = 0;
        this.FoodInCome = 0;
        this.GiftMoney = 0;
        this.WorkCost = 0;
        this.OnceFans = 0;
    }

    //======================================================
    //外部方法
    //======================================================

    //============
    //計算單次總營業額(LadtSeat : 取得人事費)
    //============
    public void DoConsole(CustomerSeat_Class[] CustomerSeat , LadySeat_Class LadtSeat)
    {
        
        //將所有CustomerSeat的Customer進行結帳
        DoAllOut(CustomerSeat , LadtSeat);

        //計算單次總營業額
        DoOnceIncome(LadtSeat);

        //計算小姐能力
        DoLadyConsole(LadtSeat);


        //print(OnceIncome + " " + RoomInCome + " " + FoodInCome + " " + GiftMoney + " " + WorkCost +" "+ OnceFans);
    }

    

    //============
    //增加單次總營業額
    //============
    public void AddOnceIncome(uint Money)
    {
        this.OnceIncome = this.OnceIncome + Money;
    }

    //============
    //增加來客數
    //============
    public void AddComeCustomerCount(uint Count)
    {
        this.ComeCustomerCount = this.ComeCustomerCount + Count;
    }

    //============
    //增加禮品費
    //============
    public void AddGiftMoney(uint Money)
    {
        this.GiftMoney = this.GiftMoney + Money;
    }

    //============
    //增加單次粉絲數
    //============
    public void AddOnceFans(uint Fans)
    {
        this.OnceFans = this.OnceFans + Fans;
    }

    //======================================================
    //內部方法
    //======================================================

    //============
    //計算人事費
    //============
    private void CalWorkCost(LadySeat_Class LadySeat) {

        //計算所有出勤小姐的人事費總合
        for (int i = 0; i < LadySeat.GetLadyMax(); i++) {
            WorkCost = WorkCost + LadySeat.GetLady(i).GetCost();
        }//for

    }

    //============
    //計算單次總營業額(LadtSeat : 取得人事費)
    //============
    private void DoOnceIncome(LadySeat_Class LadtSeat)
    {
        //計算包廂收入
        RoomInCome = ComeCustomerCount * 10000;

        //計算餐飲總額
        FoodInCome = OnceIncome - RoomInCome;

        //計算人事費
        CalWorkCost(LadtSeat);

        

        //結算(總額 = 單次總營業額 -禮品費 - 人事費)，如果總額為正的 則 正常計算並扣除禮物費、人事費
        if (OnceIncome > (GiftMoney + WorkCost)) OnceIncome = OnceIncome - GiftMoney - WorkCost;
        //如果總額為負的，則設為0元，防止溢位
        else OnceIncome = 0;
    }

    //============
    //計算小姐能力
    //============
    private void DoLadyConsole(LadySeat_Class LadySeat)
    {
        //計算每一名出勤小姐的獲取經驗值
        for (int i = 0; i < LadySeat.GetLadyMax(); i++)
        {
            //增加經驗值
            LadySeat.GetLady(i).AddExperience(LadySeat.GetLady(i).GetOnceIncome() / 10);
            //檢查可否升級
            LadySeat.GetLady(i).DoLevelUpCheck();

            
        }//for

    }


    
    //============
    //將所有CustomerSeat的Customer進行結帳
    //============
    private void DoAllOut(CustomerSeat_Class[] CustomerSeat , LadySeat_Class LadySeat)
    {
        for (int i = 0; i < CustomerSeat.Length; i++)
        {
            
            if (CustomerSeat[i].GetisLady() == true)
            {
                //增加單次總營業額
                AddOnceIncome(CustomerSeat[i].GetInCome());

                //Lady增加單次營業額
                CustomerSeat[i].GetLady().SetOnceIncome(CustomerSeat[i].GetLady().GetOnceIncome() + CustomerSeat[i].GetInCome());
                
                //Lady回到LadySeat
                LadySeat.SetLadyBack(CustomerSeat[i].GetLady());
                
            }
           
            //讓客人離開
            CustomerSeat[i].SetCustomerleave();
        }
   
    }

    //======================================================
    //Getter
    //======================================================

    //============
    //OnceIncome
    //============
    public uint GetOnceIncome()
    {
        return OnceIncome;
    }

    //============
    //ComeCustomerCount
    //============
    public uint GetComeCustomerCount()
    {
        return ComeCustomerCount;
    }

    //============
    //RoomInCome
    //============
    public uint GetRoomInCome()
    {
        return RoomInCome;
    }

    //============
    //FoodInCome
    //============
    public uint GetFoodInCome()
    {
        return FoodInCome;
    }

    //============
    //GiftMoney
    //============
    public uint GetGiftMoney()
    {
        return GiftMoney;
    }

    //============
    //WorkCost
    //============
    public uint GetWorkCost()
    {
        return WorkCost;
    }

    //============
    //OnceFans
    //============
    public uint GetOnceFans()
    {
        return OnceFans;
    }

    //======================================================
    //Setter
    //======================================================

    //============
    //OnceIncome
    //============
    public void SetOnceIncome(uint OnceIncome)
    {
        this.OnceIncome = OnceIncome;
    }

    //============
    //ComeCustomerCount
    //============
    public void SetComeCustomerCount(uint ComeCustomerCount)
    {
        this.ComeCustomerCount = ComeCustomerCount;
    }

    //============
    //RoomInCome
    //============
    public void SetRoomInCome(uint RoomInCome)
    {
        this.RoomInCome = RoomInCome;
    }

    //============
    //FoodInCome
    //============
    public void SetFoodInCome(uint FoodInCome)
    {
        this.FoodInCome = FoodInCome;
    }

    //============
    //GiftMoney
    //============
    public void SetGiftMoney(uint GiftMoney)
    {
        this.GiftMoney = GiftMoney;
    }

    //============
    //WorkCost
    //============
    public void SetWorkCost(uint WorkCost)
    {
        this.WorkCost = WorkCost;
    }

    //============
    //OnceFans
    //============
    public void SeOnceFans(uint OnceFans)
    {
        this.OnceFans = OnceFans;
    }



}//GameConsole_Class
