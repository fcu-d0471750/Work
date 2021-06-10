/*
 * Class : CustomerSeat
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomerSeat_Class : MonoBehaviour
{
    //======================================================
    //宣告屬性
    //======================================================

    //int : id
    private int id;

    //uint : 消費金額 
    private uint InCome;

    //Customer : 顧客
    private Customer_Class Customer;

    //Lady : 小姐 
    private Lady_Class Lady;

    //Sprite : 小姐大頭照
    private Sprite LadyHeadShot;

    //float : 等待時間
    private float WaitTime;

    //float : Game時間
    private float GameTime;

    //float : 獲得營收時間
    private float IncomeTime;

    //==================
    //State
    //==================

    //bool : isGame，位置是否有客人，true:有 false:沒有
    private bool isGame;

    //bool : isGame，位置是否有指派小姐，true:有 false:沒有
    private bool isLady;

    //bool : isExclamation，是否有服務事件，true:有 false:沒有
    private bool isExclamation;

    //bool : isArgue，是否有爭議事件，true:有 false:沒有
    private bool isArgue;

    //bool : isCheckout，是否有結帳事件，true:有 false:沒有
    private bool isCheckout;

    //bool : isFever，是否進入Fever狀態，true:有 false:沒有
    private bool isFever;

    //======================================================
    //建構子(無參數)
    //======================================================
    public CustomerSeat_Class()
    {
        this.id = 0;
        this.InCome = 0;
        this.Customer = null;
        this.Lady = null;
        this.LadyHeadShot = null;

        this.GameTime = 0.0f;
        this.WaitTime = 9.0f;
        this.IncomeTime = 1.0f;

        this.isGame = false;
        this.isLady = false;
        this.isExclamation = false;
        this.isArgue = false;
        this.isCheckout = false;
        this.isFever = false;
    }

    //======================================================
    //建構子(只有id參數)
    //======================================================
    public CustomerSeat_Class(int id)
    {
        this.id = id;
        this.InCome = 0;
        this.Customer = null;
        this.Lady = null;
        this.LadyHeadShot = null;

        this.GameTime = 0.0f;
        this.WaitTime = 0.0f;
        this.IncomeTime = 1.0f;

        this.isGame = false;
        this.isLady = false;
        this.isExclamation = false;
        this.isArgue = false;
        this.isCheckout = false;
        this.isFever = false;
    }

    //======================================================
    //建構子(有參數)
    //======================================================
    public CustomerSeat_Class(int id , uint InCome , Lady_Class Lady , Customer_Class Customer , float GameTime , float WaitTime , float IncomeTime , bool isGame, bool isLady , bool isExclamation , bool isArgue , bool isCheckout , bool isFever ) {
        this.id = id;
        this.InCome = InCome;
        this.Customer = Customer;
        this.Lady = Lady;
        this.LadyHeadShot = Lady.GetHeadshot();

        this.GameTime = GameTime;
        this.WaitTime = WaitTime;
        this.IncomeTime = IncomeTime;

        this.isGame = isGame;
        this.isLady = isLady;
        this.isExclamation = isExclamation;
        this.isArgue = isArgue;
        this.isCheckout = isCheckout;
        this.isFever = isFever;

    }

    //======================================================
    //外部方法
    //======================================================

    //============
    //指定小姐
    //============
    public void SetLadyinSeat(Lady_Class Lady , GameConsole_Class GameConsole)
    {
        //設定Lady資料
        this.Lady = Lady;
        //設定Lady大頭照
        this.LadyHeadShot = Lady.GetHeadshot();
        //表示位置上有Lady
        this.isLady = true;

        //設定Customer的遊玩時間
        this.GameTime = Customer.GetTime();

        //設定CustomerSeat的等待時間
        this.WaitTime = 0.0f;

        //設定Customer的Emotion
        this.Customer.SetEmotion(Lady);
  
        //增加包廂費
        this.InCome = InCome + 10000;
        //增加來客數
        GameConsole.AddComeCustomerCount(1);
    }

    //============
    //小姐交換(Lady : 新的Lady)
    //============
    public void SetLadyinSeatChange(Lady_Class Lady)
    {
        //重新設定Lady資料
        this.Lady = Lady;
           
        //重新設定Customer的Emotion
        this.Customer.SetEmotion(Lady);
    }

    //============
    //客人光臨
    //============
    public void SetCustomerinSeat(Customer_Class Customer)
    {
        //設定Customer資料
        this.Customer = Customer;

        //設定CustomerSeat的等待時間
        this.WaitTime = 9.0f;

        //表示位置上有Customer
        this.isGame = true;
    }

    //============
    //客人離場
    //============
    public void SetCustomerleave()
    {
        this.Customer = null;
        this.Lady = null;
        this.LadyHeadShot = null;

        this.InCome = 0;
        this.GameTime = 0.0f;
        this.WaitTime = 0.0f;
        this.IncomeTime = 1.0f;

        this.isGame = false;
        this.isLady = false;
        this.isExclamation = false;
        this.isArgue = false;
        this.isCheckout = false;
        this.isFever = false;
    }

    //============
    //計算消費金額
    //============
    public void Calincome() {
        //Fever狀態
        if (isFever == true)
        {
            //公式......................
            InCome = InCome + (uint)(Customer.GetEmotion() * (Customer.GetLevel() * 100)) + 20000;
            //重新計算獲得營收時間
            this.IncomeTime = 1.0f;
        }
        //普通狀態
        else
        {
            //公式......................
            InCome = InCome + (uint)(Customer.GetEmotion() * (Customer.GetLevel() * 100) );
            //重新計算獲得營收時間
            this.IncomeTime = 1.0f;
        }
    }

    //============
    //Seat上有客人時，扣除等待時間
    //============
    public void DoGame_SubWaitTime()
    {
        //扣除等待時間
        if (this.WaitTime > 0.0f)
        {
            this.WaitTime = this.WaitTime - Time.deltaTime;    
        }
        //如果等待時間扣到 <= 0.0f，則設為0.0f
        else this.WaitTime = 0.0f;
    }

    //============
    //Seat上有客人和Lady時，扣除遊玩時間、獲得營收時間
    //============
    public void DoGame_SubGameTime()
    {
        //扣除遊玩時間、獲得營收時間
        if (this.GameTime > 0.0f)
        {
            this.GameTime = this.GameTime - Time.deltaTime;
            this.IncomeTime = this.IncomeTime - Time.deltaTime;          
        }
        //如果遊玩時間扣到 <= 0.0f，則設為0.0f
        else this.GameTime = 0.0f;
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
    //InCome
    //============
    public uint GetInCome()
    {
        return InCome;
    }

    //============
    //Customer
    //============
    public Customer_Class GetCustomer()
    {
        return Customer;
    }

    //============
    //Lady
    //============
    public Lady_Class GetLady()
    {
        return Lady;
    }

    //============
    //LadyHeadShot
    //============
    public Sprite GetLadyHeadShot()
    {
        return LadyHeadShot;
    }

    //============
    //WaitTime
    //============
    public float GetWaitTime()
    {
        return WaitTime;
    }

    //============
    //GameTime
    //============
    public float GetGameTime()
    {
        return GameTime;
    }

    //============
    //IncomeTime
    //============
    public float GetIncomeTime()
    {
        return IncomeTime;
    }
    

    //============
    //isGame
    //============
    public bool GetisGame()
    {
        return isGame;
    }

    //============
    //isLady
    //============
    public bool GetisLady()
    {
        return isLady;
    }

    //============
    //isExclamation
    //============
    public bool GetisExclamation()
    {
        return isExclamation;
    }

    //============
    //isArgue
    //============
    public bool GetisArgue()
    {
        return isArgue;
    }

    //============
    //isCheckout
    //============
    public bool GetisCheckout()
    {
        return isCheckout;
    }

    //============
    //isFever
    //============
    public bool GetisFever()
    {
        return isFever;
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
    //InCome
    //============
    public void SetInCome(uint InCome)
    {
        this.InCome = InCome;
    }

    //============
    //Customer
    //============
    public void SetCustomer(Customer_Class Customer)
    {
        this.Customer = Customer;
    }

    //============
    //Lady
    //============
    public void SetLady(Lady_Class Lady)
    {
        this.Lady = Lady;
    }

    //============
    //LadyHeadShot
    //============
    public void SetLadyHeadShot(Sprite LadyHeadShot)
    {
        this.LadyHeadShot = LadyHeadShot;
    }

    //============
    //WaitTime
    //============
    public void SetWaitTime(float WaitTime)
    {
        this.WaitTime = WaitTime;
    }

    //============
    //GameTime
    //============
    public void SetGameTime(float GameTime)
    {
        this.GameTime = GameTime;
    }

    //============
    //IncomeTime
    //============
    public void SetIncomeTime(float IncomeTime)
    {
        this.IncomeTime = IncomeTime;
    }
    
    //============
    //isGame
    //============
    public void SetisGame(bool isGame)
    {
        this.isGame = isGame;
    }

    //============
    //isLady
    //============
    public void SetisLady(bool isLady)
    {
        this.isLady = isLady;
    }

    //============
    //isExclamation
    //============
    public void SetisExclamation(bool isExclamation)
    {
        this.isExclamation = isExclamation;
    }

    //============
    //isArgue
    //============
    public void SetisArgue(bool isArgue)
    {
        this.isArgue = isArgue;
    }

    //============
    //isCheckout
    //============
    public void SetisCheckout(bool isCheckout)
    {
        this.isCheckout = isCheckout;
    }

    //============
    //isFever
    //============
    public void SetisFever(bool isFever)
    {
        this.isFever = isFever;
    }

}//CustomerSeat_Class
