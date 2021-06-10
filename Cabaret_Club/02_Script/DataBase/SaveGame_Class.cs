/*
 * Class: 儲存資料的格式
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveGame_Class : MonoBehaviour
{
    //======================================================
    //宣告變數(要儲存的資料，後面為初始值)
    //======================================================

    //============
    //Cabaret_Club_Class
    //============

    //店鋪名稱
    public string Cabaret_Club_Boss = "Cabaret_Club_Boss";
    //店鋪等級
    public int Cabaret_Club_Level;
    //店鋪粉絲人數
    public uint Cabaret_Club_FansNumber;

    //============
    //Cabaret_Club_Class - StaffLady
    //============

    //在籍小姐等級
    public int[] Cabaret_Club_StaffLady_Level = new int[30];
    //在籍小姐總營業額
    public ulong[] Cabaret_Club_StaffLady_AllIncome = new ulong[30];
    //在籍小姐單次最高營業額
    public uint[] Cabaret_Club_StaffLady_OnceIncome = new uint[30];
    //在籍小姐現有經驗值
    public uint[] Cabaret_Club_StaffLady_Experience = new uint[30];
    //在籍小姐升級所需經驗值
    public uint[] Cabaret_Club_StaffLady_ExperienceMax = new uint[30];
    //在籍小姐Hp
    public float[] Cabaret_Club_StaffLady_Hp = new float[30];
    //在籍小姐Talk
    public float[] Cabaret_Club_StaffLady_Talk = new float[30];
    //在籍小姐Party
    public float[] Cabaret_Club_StaffLady_Party = new float[30];
    //在籍小姐Love
    public float[] Cabaret_Club_StaffLady_Love = new float[30];
    //在籍小姐Skill
    public float[] Cabaret_Club_StaffLady_Skill = new float[30];
    //在籍小姐是否解鎖
    public bool[] Cabaret_Club_StaffLady_isunLock = new bool[30];
    //在籍小姐是否出勤中
    public bool[] Cabaret_Club_StaffLady_isWorked = new bool[30];


    //============
    //PrepareLady
    //============

    //出勤小姐id
    public int[] PrepareLady_id = new int[8];


    //============
    //Opposite
    //============

    //競爭對手區域id
    public int Opposite_Number = 0;
    //競爭對手區域粉絲人數
    public uint[] Opposite_AreaFans = new uint[5];
    //競爭對手是否解鎖
    public bool[] Opposite_isunLocked = new bool[5];

    //============
    //ulong : 持有金額
    //============
    public ulong AllIncome = 0;

    //============
    //是否為第1次存檔，true:第1次 false:非第1次
    //============
    public bool FirstSave = true;

    /*//============
    //Cabaret_Club_Class
    //============
    public string Cabaret_Club_Boss_String = "Cabaret_Club_Boss";

    public string Cabaret_Club_Level_String = "Cabaret_Club_Level";

    public string Cabaret_Club_FansNumber_String = "Cabaret_Club_FansNumber";


    //============
    //Cabaret_Club_Class - StaffLady
    //============

    public string[] Cabaret_Club_StaffLady_Level_String = new string[30];

    public string[] Cabaret_Club_StaffLady_AllIncome_String = new string[30];

    public string[] Cabaret_Club_StaffLady_OnceIncome_String = new string[30];

    public string[] Cabaret_Club_StaffLady_isunLock_String = new string[30];

    public string[] Cabaret_Club_StaffLady_isWorked_String = new string[30];

    //============
    //PrepareLady
    //============
    
    //(只要id不為0~29代表該欄位沒有安排出勤小姐)
    public string[] PrepareLady_id_String = new string[8];


    //============
    //Opposite
    //============
    public string[] Opposite_AreaFans_String = new string[8];

    public string[] Opposite_isunLocked_String = new string[8];


    //============
    //迴圈用
    //============
    private int i, j;

    //======================================================
    //建構子(無參數)
    //======================================================
    public SaveGame_Class() {
        for (i = 0; i < 30; i++) {
            Cabaret_Club_StaffLady_Level_String[i] = "Cabaret_Club_StaffLady_Level_String_" + i;
            Cabaret_Club_StaffLady_AllIncome_String[i] = "Cabaret_Club_StaffLady_AllIncome_String_" + i;
            Cabaret_Club_StaffLady_OnceIncome_String[i] = "Cabaret_Club_StaffLady_OnceIncome_String_" + i;
            Cabaret_Club_StaffLady_isunLock_String[i] = "Cabaret_Club_StaffLady_isunLock_String_" + i;
            Cabaret_Club_StaffLady_isWorked_String[i] = "Cabaret_Club_StaffLady_isWorked_String_" + i;
        }

        for (i = 0; i < 8; i++) {
            PrepareLady_id_String[i] = "PrepareLady_id_String_" + i;
        }

        for (i = 0; i < 8; i++)
        {
            Opposite_AreaFans_String[i] = "Opposite_AreaFans_String_" + i;
            Opposite_isunLocked_String[i] = "Opposite_isunLocked_String_" + i;
        }

    }

    //======================================================
    //Getter
    //======================================================

    //======================================================
    //Getter
    //======================================================

    //============
    //Cabaret_Club_Class
    //============
    public string GetCabaret_Club_Boss_String()
    {
        return Cabaret_Club_Boss_String;
    }

    //============
    //Cabaret_Club_Level_String
    //============
    public string GetCabaret_Club_Level_String()
    {
        return Cabaret_Club_Level_String;
    }

    //============
    //Cabaret_Club_FansNumber_String
    //============
    public string GetCabaret_Club_FansNumber_String()
    {
        return Cabaret_Club_FansNumber_String;
    }


    //============
    //Cabaret_Club_StaffLady_Level_String(index : 第幾個Cabaret_Club_StaffLady_Level_String)
    //============
    public string GetCabaret_Club_StaffLady_Level_String(int index)
    {
        return Cabaret_Club_StaffLady_Level_String[index];
    }

    //============
    //Cabaret_Club_StaffLady_AllIncome_String(index : 第幾個Cabaret_Club_StaffLady_AllIncome_String)
    //============
    public string GetCabaret_Club_StaffLady_AllIncome_String(int index)
    {
        return Cabaret_Club_StaffLady_AllIncome_String[index];
    }

    //============
    //Cabaret_Club_StaffLady_OnceIncome_String(index : 第幾個Cabaret_Club_StaffLady_OnceIncome_String)
    //============
    public string GetCabaret_Club_StaffLady_OnceIncome_String(int index)
    {
        return Cabaret_Club_StaffLady_OnceIncome_String[index];
    }

    //============
    //Cabaret_Club_StaffLady_isunLock_String(index : 第幾個Cabaret_Club_StaffLady_isunLock_String)
    //============
    public string GetCabaret_Club_StaffLady_isunLock_String(int index)
    {
        return Cabaret_Club_StaffLady_isunLock_String[index];
    }

    //============
    //Cabaret_Club_StaffLady_isWorked_String(index : 第幾個Cabaret_Club_StaffLady_isWorked_String)
    //============
    public string GetCabaret_Club_StaffLady_isWorked_String(int index)
    {
        return Cabaret_Club_StaffLady_isWorked_String[index];
    }

    //============
    //PrepareLady_id_String(index : 第幾個PrepareLady_id_String)
    //============
    public string GetPrepareLady_id_String(int index)
    {
        return PrepareLady_id_String[index];
    }

    //============
    //Opposite_AreaFans_String(index : 第幾個Opposite_AreaFans_String)
    //============
    public string GetOpposite_AreaFans_String(int index)
    {
        return Opposite_AreaFans_String[index];
    }

    //============
    //Opposite_isunLocked_String(index : 第幾個Opposite_isunLocked_String)
    //============
    public string GetOpposite_isunLocked_String(int index)
    {
        return Opposite_isunLocked_String[index];
    }
    */




    /*
    //======================================================
    //宣告變數(要儲存的資料，後面為初始值)
    //======================================================

    //Cabaret_Club_Class : Cabaret_Club基本資料
    public Cabaret_Club_Class Cabaret_Club_ = new Cabaret_Club_Class();

    //Lady_Class : 從ManageScene安排的出勤小姐，最多8名
    public Lady_Class[] PrepareLady = new Lady_Class[8];

    //Opposite_Class : 競爭對手，共5名
    public Opposite_Class[] Opposite = new Opposite_Class[5];

    //ulong : 持有金額
    public ulong AllIncome = 0;
    

    //======================================================
    //Getter
    //======================================================

    //============
    //Cabaret_Club_Class
    //============
    public Cabaret_Club_Class GetCabaret_Club()
    {       
        return Cabaret_Club_;
    }

    //============
    //PrepareLady，(id : 哪個欄位的出勤小姐)
    //============
    public Lady_Class GetPrepareLady(int id)
    {
        return PrepareLady[id];
    }

    //============
    //全部PrepareLady
    //============
    public Lady_Class[] GetAllPrepareLady()
    {
        return PrepareLady;
    }

    //============
    //Opposite，(id : 哪個競爭對手)
    //============
    public Opposite_Class GetOpposite(int id)
    {
        return Opposite[id];
    }

    //============
    //全部Opposite
    //============
    public Opposite_Class[] GetAllOpposite()
    {
        return Opposite;
    }

    //============
    //AllIncome
    //============
    public ulong GetAllIncome()
    {
        return AllIncome;
    }

    //======================================================
    //Setter
    //======================================================

    //============
    //Cabaret_Club_
    //============
    public void SetCabaret_Club_(Cabaret_Club_Class Cabaret_Club_)
    {
        this.Cabaret_Club_ = Cabaret_Club_;
    }

    //============
    //PrepareLady，(id : 哪個欄位的出勤小姐)
    //============
    public void SetPrepareLady(int id, Lady_Class PrepareLady)
    {
        this.PrepareLady[id] = PrepareLady;
    }

    //============
    //Opposite，(id : 哪個競爭對手)
    //============
    public void SetOpposite(int id, Opposite_Class Opposite)
    {
        this.Opposite[id] = Opposite;
    }

    //============
    //AllIncome
    //============
    public void SetAllIncome(ulong AllIncome)
    {
        this.AllIncome = AllIncome;
    }
    */
}//SaveGame_Class