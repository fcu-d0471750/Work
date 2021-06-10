/*
 * View : BeginBase、BeginBaseCanvas的View
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_Manage_Begin_Script : MonoBehaviour
{

    //======================================================
    //UI來源
    //======================================================

    public ManageScene_View_UI MSV;


    //======================================================
    //宣告變數
    //======================================================

    //View_Manage_Script : Manage所有的View統一管理Script
    public View_Manage_Script VMS;

    //======================================================
    //宣告UI(Sprite、Text、Image、Button)
    //======================================================

    //============
    //Sprite
    //============

    //BeginSelect_Arrow_Sprite
    public SpriteRenderer BeginSelect_Arrow_Sprite;

    //============
    //Text
    //============

    //營業消息
    public Text BeginInformation_Game_Text;

    //店鋪快報
    public Text BeginInformation_Store_Text;

    //粉絲人數
    public Text BeginStore_FansNumber_Text;

    //階級
    public Text BeginStore_Level_Text;


    //======================================================
    //外部方法
    //======================================================

    //============
    //設定營業消息(Information : 顯示內容)
    //============
    public void SetBeginInformation_Game_Text(string Information) {
        BeginInformation_Game_Text.text = "" + Information;
    }

    //============
    //設定店鋪快報(Information : 顯示內容)
    //============
    public void SetBeginInformation_Store_Text(string Information)
    {
        BeginInformation_Store_Text.text = "" + Information;
    }

    //============
    //設定粉絲人數(FansNumber : 粉絲人數)
    //============
    public void SetBeginStore_FansNumber_Text(uint FansNumber)
    {
        BeginStore_FansNumber_Text.text = "" + FansNumber + "名";
    }

    //============
    //設定階級(FansNumber : 粉絲人數)
    //============
    public void SetBeginStore_Level_Text(int Level)
    {
        BeginStore_Level_Text.text = "" + Level;
    }

    //============
    //一次修改Begin頁面
    //============
    public void SetBegin(Cabaret_Club_Class Cabaret_Club_) {

        SetBeginStore_FansNumber_Text(Cabaret_Club_.GetCabaret_Club_FansNumber());
        SetBeginStore_Level_Text(Cabaret_Club_.GetCabaret_Club_Level());

    }

}//View_Manage_Begin_Script
