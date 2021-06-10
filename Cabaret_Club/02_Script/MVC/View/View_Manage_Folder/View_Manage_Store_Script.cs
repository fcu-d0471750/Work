/*
 * View : StoreBase、StoreBaseCanvas的View
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_Manage_Store_Script : MonoBehaviour
{
    //======================================================
    //UI來源
    //======================================================

    public ManageScene_View_UI MVU;

    //======================================================
    //宣告變數
    //======================================================

    //View_Manage_Script : Manage所有的View統一管理Script
    public View_Manage_Script VMS;

    //迴圈用
    private int i, j;

    //======================================================
    //宣告UI(Sprite、Text、Image、Button)
    //======================================================

    //============
    //Sprite
    //============

    //============
    //(StoreState)
    //============

    //============
    //Text
    //============

    //============
    //(StoreState)
    //============
    
    //老闆姓名
    public Text StoreState_Boss_Text;

    //店鋪階級
    public Text StoreState_Level_Text;

    //粉絲人數
    public Text StoreState_FansNumber_Text;

    //小姐人數
    public Text StoreState_Staff_Text;

    //============
    //(StoreState_Opposite)
    //============

    //競爭對手店鋪名稱
    public Text StoreState_Opposite_Name_Text;

    //競爭對手老闆姓名
    public Text StoreState_Opposite_Boss_Text;

    //競爭對手店鋪階級
    public Text StoreState_Opposite_Level_Text;

    //競爭對手粉絲人數
    public Text StoreState_Opposite_FansNumber_Text;

    //競爭對手區域粉絲人數
    public Text StoreOpposite_AreaFans_Text;

    //競爭對手資訊
    public Text StoreState_Opposite_Description_Text;

    //============
    //Image
    //============


    //============
    //Button
    //============

    //競爭對手，共5間
    public Button[] StoreState_Opposite_Button = new Button[5];


    //======================================================
    //外部方法
    //======================================================

    //============
    //(Store頁面 : StoreState)
    //============

    //============
    //StoreState的老闆姓名(Text)
    //============
    public void SetStoreState_Boss_Text(string Boss)
    {
        StoreState_Boss_Text.text = "" + Boss;
    }

    //============
    //StoreState的店鋪階級(Text)
    //============
    public void SetStoreState_Level_Text(int Level)
    {
        StoreState_Level_Text.text = "" + Level;
    }

    //============
    //StoreState的粉絲人數(Text)
    //============
    public void SetStoreState_FansNumber_Text(uint FansNumber)
    {
        StoreState_FansNumber_Text.text = "" + FansNumber + "名";
    }

    //============
    //StoreState的小姐人數(Text)
    //============
    public void SetStoreState_Staff_Text(uint Staff)
    {
        StoreState_Staff_Text.text = "" + Staff + "/30名" ;
    }

    //============
    //一次修改StoreState(Text)
    //============
    public void SetStoreState_Text(Cabaret_Club_Class Cabaret_Club_)
    {
        SetStoreState_Boss_Text(Cabaret_Club_.GetCabaret_Club_Boss());
        SetStoreState_Level_Text(Cabaret_Club_.GetCabaret_Club_Level());
        SetStoreState_FansNumber_Text(Cabaret_Club_.GetCabaret_Club_FansNumber());
        SetStoreState_Staff_Text(Cabaret_Club_.GetStaffLadyisunlocked());
    }


    //============
    //(Store頁面 : StoreState_Opposite)
    //============

    //============
    //StoreState_Opposite的競爭對手店鋪名稱(Text)
    //============
    public void SetStoreState_Opposite_Name_Text(string Name)
    {
        StoreState_Opposite_Name_Text.text = "" + Name;
    }

    //============
    //StoreState_Opposite的競爭對手老闆姓名(Text)
    //============
    public void SetStoreState_Opposite_Boss_Text(string Boss)
    {
        StoreState_Opposite_Boss_Text.text = "" + Boss;
    }

    //============
    //StoreState_Opposite的競爭對手店鋪階級(Text)
    //============
    public void SetStoreState_Opposite_Level_Text(int Level)
    {
        StoreState_Opposite_Level_Text.text = "" + Level;
    }

    //============
    //StoreState_Opposite的競爭對手粉絲人數(Text)
    //============
    public void SetStoreState_Opposite_FansNumber_Text(uint FansNumber)
    {
        StoreState_Opposite_FansNumber_Text.text = "" + FansNumber + "名";
    }

    //============
    //StoreState_Opposite的區域粉絲人數(Text)
    //============
    public void SetStoreOpposite_AreaFans_Text(uint AreaFans)
    {
        StoreOpposite_AreaFans_Text.text = "" + AreaFans + "名";
    }

    //============
    //StoreState_Opposite的競爭對手資訊(Text)
    //============
    public void SetStoreState_Opposite_Description_Text(string Description)
    {
        StoreState_Opposite_Description_Text.text = "" + Description;
    }


    //============
    //一次修改StoreState_Opposite(Text)
    //============
    public void SetStoreState_Opposite_Text(Opposite_Class Opposite)
    {
        SetStoreState_Opposite_Name_Text(Opposite.GetOpposite_Name());
        SetStoreState_Opposite_Boss_Text(Opposite.GetOpposite_Boss());
        SetStoreState_Opposite_Level_Text(Opposite.GetOpposite_Level());
        SetStoreState_Opposite_FansNumber_Text(Opposite.GetOpposite_FansNumber());
        SetStoreOpposite_AreaFans_Text(Opposite.GetOpposite_AreaFans());
        SetStoreState_Opposite_Description_Text(Opposite.GetOpposite_Description());
    }


    //============
    //開啟或關閉，StoreState_Opposite_Button(Button)(id : 第幾個區域 , StoreState_Opposite_Button : 競爭對手Button)
    //============
    public void SetStoreState_Opposite_Button_interactable(int id , Opposite_Class[] Opposite)
    {
        
        MVU.SetStoreOpposite(id , Opposite , StoreState_Opposite_Button);

        //更新View，一次修改StoreState_Opposite
        SetStoreState_Opposite_Text(Opposite[id]);
    }

}//View_Manage_Store_Script
