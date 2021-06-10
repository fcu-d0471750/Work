/*
 * Class : Cabaret Club 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cabaret_Club_Class : MonoBehaviour
{
    //======================================================
    //宣告屬性
    //======================================================

    //string : 老闆姓名
    private string Cabaret_Club_Boss;

    //int : 店鋪階級
    private int Cabaret_Club_Level;

    //uint :　粉絲人數
    private uint Cabaret_Club_FansNumber;

    //StaffLady : 所有小姐，共30位
    private Lady_Class[] StaffLady = new Lady_Class[30];

    //======================================================
    //建構子(無參數)
    //======================================================
    public Cabaret_Club_Class() {
        this.Cabaret_Club_Boss = "真島吾郎";
        this.Cabaret_Club_Level = 0;
        this.Cabaret_Club_FansNumber = 0;

        CreateStaffLady();
               
    }

    //======================================================
    //建構子(有參數)
    //======================================================
    public Cabaret_Club_Class(string Cabaret_Club_Boss , int Cabaret_Club_Level , uint Cabaret_Club_FansNumber , LadyData LD)
    {
        this.Cabaret_Club_Boss = Cabaret_Club_Boss;
        this.Cabaret_Club_Level = Cabaret_Club_Level;
        this.Cabaret_Club_FansNumber = Cabaret_Club_FansNumber;
        CreateStaffLady(LD);
    }


    //======================================================
    //Getter
    //======================================================

    //============
    //Cabaret_Club_Boss
    //============
    public string GetCabaret_Club_Boss()
    {
        return Cabaret_Club_Boss;
    }

    //============
    //abaret_Club_Level
    //============
    public int GetCabaret_Club_Level()
    {
        return Cabaret_Club_Level;
    }

    //============
    //Cabaret_Club_FansNumber
    //============
    public uint GetCabaret_Club_FansNumber()
    {
        return Cabaret_Club_FansNumber;
    }

    //============
    //StaffLady(一位)
    //============

    public Lady_Class GetStaffLady(int id)
    {
        return StaffLady[id];
    }

    //============
    //StaffLady(全部)
    //============

    public Lady_Class[] GetAllStaffLady()
    {
        return StaffLady;
    }

    //======================================================
    //Setter
    //======================================================

    //============
    //Cabaret_Club_Boss
    //============
    public void SetCabaret_Club_Boss(string Cabaret_Club_Boss)
    {
        this.Cabaret_Club_Boss = Cabaret_Club_Boss;
    }

    //============
    //Cabaret_Club_Level
    //============
    public void SetCabaret_Club_Level(int Cabaret_Club_Level)
    {
        this.Cabaret_Club_Level = Cabaret_Club_Level;
    }

    //============
    //Cabaret_Club_FansNumber
    //============
    public void SetCabaret_Club_FansNumber(uint Cabaret_Club_FansNumber)
    {
        this.Cabaret_Club_FansNumber = Cabaret_Club_FansNumber;
    }




    //======================================================
    //外部方法
    //======================================================

    //============
    //取得已解鎖的小姐人數
    //============
    public uint GetStaffLadyisunlocked() {
        //暫存人數
        uint Temp = 0;

        //計算人數
        for (int i = 0; i < StaffLady.Length; i++) if (StaffLady[i].GetisunLock() == true) Temp = Temp + 1;
        
        return Temp;
    }

    //======================================================
    //內部方法
    //======================================================

    //============
    //生成所有小姐
    //============
    private void CreateStaffLady() {
        for (int i = 0; i < StaffLady.Length; i++)
        {
            StaffLady[i] = new Lady_Class();
            StaffLady[i].Setid(i);
        }
    }

    //============
    //生成所有小姐(讀取LadyData)
    //============
    private void CreateStaffLady(LadyData LD)
    {
        for (int i = 0; i < StaffLady.Length; i++)
        {
            StaffLady[i] = new Lady_Class();
            //依照LadyData的資料進行設定
            StaffLady[i] = LadyData.Lady[i];           
        }
    }

}//Cabaret_Club_Class
