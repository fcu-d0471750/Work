/*
 * Class : 競爭對手
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opposite_Class : MonoBehaviour
{
    //======================================================
    //宣告屬性
    //======================================================

    //int : id
    private int id;

    //string : 競爭對手店鋪名稱
    private string Opposite_Name;

    //string : 競爭對手老闆姓名
    private string Opposite_Boss;

    //int : 競爭對手店鋪階級
    private int Opposite_Level;

    //uint : 競爭對手粉絲人數
    private uint Opposite_FansNumber;

    //uint : 競爭對手區域粉絲人數
    private uint Opposite_AreaFans;

    //string : 競爭對手資訊
    private string Opposite_Description;

    //bool : 是否解鎖，true:解鎖 false:未解鎖
    private bool Opposite_isunLocked;

    //======================================================
    //建構子(無參數)
    //======================================================
    public Opposite_Class()
    {
        this.id = 0;
        this.Opposite_Name = "亞丁尼飯店";
        this.Opposite_Boss = "木也";
        this.Opposite_Level = 0;
        this.Opposite_FansNumber = 1000;
        this.Opposite_AreaFans = 0;
        this.Opposite_Description = "提供安全、舒適，讓使用者得到短期的休息或睡眠空間之商業機構。";
        this.Opposite_isunLocked = false;
    }

    //======================================================
    //建構子(有參數)
    //======================================================
    public Opposite_Class(int id , string Opposite_Name , string Opposite_Boss , int Opposite_Level , uint Opposite_FansNumber , uint Opposite_AreaFans , string Opposite_Description , bool Opposite_isunLocked)
    {
        this.id = id;
        this.Opposite_Name = Opposite_Name;
        this.Opposite_Boss = Opposite_Boss;
        this.Opposite_Level = Opposite_Level;
        this.Opposite_FansNumber = Opposite_FansNumber;
        this.Opposite_AreaFans = Opposite_AreaFans;
        this.Opposite_Description = Opposite_Description;
        this.Opposite_isunLocked = Opposite_isunLocked;
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
    //Opposite_Name
    //============
    public string GetOpposite_Name()
    {
        return Opposite_Name;
    }

    //============
    //Opposite_Boss
    //============
    public string GetOpposite_Boss()
    {
        return Opposite_Boss;
    }

    //============
    //Opposite_Level
    //============
    public int GetOpposite_Level()
    {
        return Opposite_Level;
    }

    //============
    //Opposite_FansNumber
    //============
    public uint GetOpposite_FansNumber()
    {
        return Opposite_FansNumber;
    }

    //============
    //Opposite_AreaFans
    //============
    public uint GetOpposite_AreaFans()
    {
        return Opposite_AreaFans;
    }

    //============
    //Opposite_Description
    //============
    public string GetOpposite_Description()
    {
        return Opposite_Description;
    }

    //============
    //Opposite_isunLocked
    //============
    public bool GetOpposite_isunLocked()
    {
        return Opposite_isunLocked;
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
    //Opposite_Name
    //============
    public void SetOpposite_Name(string Opposite_Name)
    {
        this.Opposite_Name = Opposite_Name;
    }

    //============
    //Opposite_Boss
    //============
    public void SetOpposite_Boss(string Opposite_Boss)
    {
        this.Opposite_Boss = Opposite_Boss;
    }

    //============
    //Opposite_Level
    //============
    public void SetOpposite_Level(int Opposite_Level)
    {
        this.Opposite_Level = Opposite_Level;
    }

    //============
    //Opposite_FansNumber
    //============
    public void SetOpposite_FansNumber(uint Opposite_FansNumber)
    {
        this.Opposite_FansNumber = Opposite_FansNumber;
    }

    //============
    //Opposite_AreaFans
    //============
    public void SetOpposite_AreaFans(uint Opposite_AreaFans)
    {
        this.Opposite_AreaFans = Opposite_AreaFans;
    }

    //============
    //Opposite_Description
    //============
    public void SetOpposite_Description(string Opposite_Description)
    {
        this.Opposite_Description = Opposite_Description;
    }

    //============
    //Opposite_isunLocked
    //============
    public void SetOpposite_isunLocked(bool Opposite_isunLocked)
    {
        this.Opposite_isunLocked = Opposite_isunLocked;
    }

}//Opposite_Class
