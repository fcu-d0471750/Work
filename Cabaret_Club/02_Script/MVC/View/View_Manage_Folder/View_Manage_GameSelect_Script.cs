/*
 * View : GameSelectBase、GameSelectBaseCanvas的View
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class View_Manage_GameSelect_Script : MonoBehaviour
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
    //(Sprite)
    //============

    //競爭對手Logo
    public SpriteRenderer GameSelect_Logo_Sprite;


    //============
    //(Text)
    //============

    //競爭對手店鋪名稱
    public Text GameSelectOpposite_Name_Text;
    //競爭對手老闆名稱
    public Text GameSelectOpposite_Boss_Text;
    //競爭對手階級
    public Text GameSelectOpposite_Level_Text;
    //競爭粉絲人數
    public Text GameSelectOpposite_FansNumber_Text;
    //競爭區域粉絲人數
    public Text GameSelectOpposite_AreaFansNumber_Text;
    //競爭對手描述
    public Text GameSelectOpposite_Description_Text;

    //確認訊息
    public Text GameSelectOpposite_StartChoose_Text;
    //確認Button文字
    public Text GameSelectOpposite_Start_Text;
    //取消Button文字
    public Text GameSelectOpposite_Cancel_Text;

    //============
    //(Button)
    //============

    //競爭對手Button
    public Button[] GameSelectOpposite_Button = new Button[5];

    //確認營業Button
    public Button GameSelectOpposite_Start_Button;
    //取消營業Button
    public Button GameSelectOpposite_Cancel_Button;

    //返回Button
    public Button BackButton;

    //======================================================
    //外部方法
    //======================================================

    //============
    //設定競爭對手Logo，(id : 競爭對手id)
    //============
    public void SetGameSelect_Logo_Sprite(int id) {
        GameSelect_Logo_Sprite.sprite = MVU.GetOpposite_Logo_Sprite(id);
    }

    //============
    //清空設定競爭對手Logo
    //============
    public void SetGameSelect_Logo_Sprite_Clear()
    {
        GameSelect_Logo_Sprite.sprite = null;
    }

    //============
    //設定競爭對手店鋪名稱
    //============
    public void SetGameSelectOpposite_Name_Text(string Name) {
        GameSelectOpposite_Name_Text.text = "" + Name;
    }

    //============
    //清空競爭對手店鋪名稱
    //============
    public void SetGameSelectOpposite_Name_Text_Clear()
    {
        GameSelectOpposite_Name_Text.text = "";
    }

    //============
    //設定競爭對手老闆名稱
    //============
    public void SetGameSelectOpposite_Boss_Text(string Boss) {
        GameSelectOpposite_Boss_Text.text = "" + Boss;
    }

    //============
    //清空競爭對手老闆名稱
    //============
    public void SetGameSelectOpposite_Boss_Text_Clear()
    {
        GameSelectOpposite_Boss_Text.text = "";
    }

    //============
    //設定競爭對手階級
    //============
    public void SetGameSelectOpposite_Level_Text(int Level) {
        GameSelectOpposite_Level_Text.text = "" + Level;
    }

    //============
    //清空競爭對手階級
    //============
    public void SetGameSelectOpposite_Level_Text_Clear()
    {
        GameSelectOpposite_Level_Text.text = "";
    }

    //============
    //設定競爭粉絲人數
    //============
    public void SetGameSelectOpposite_FansNumber_Text(uint FansNumber) {
        GameSelectOpposite_FansNumber_Text.text = "" + FansNumber + "名";
    }

    //============
    //清空競爭粉絲人數
    //============
    public void SetGameSelectOpposite_FansNumber_Text_Clear()
    {
        GameSelectOpposite_FansNumber_Text.text = "";
    }

    //============
    //設定競爭區域粉絲人數
    //============
    public void SetGameSelectOpposite_AreaFansNumber_Text(uint AreaFansNumber) {
        GameSelectOpposite_AreaFansNumber_Text.text = "" + AreaFansNumber + "名";
    }

    //============
    //清空競爭區域粉絲人數
    //============
    public void SetGameSelectOpposite_AreaFansNumber_Text_Clear()
    {
        GameSelectOpposite_AreaFansNumber_Text.text = "";
    }

    //============
    //設定競爭對手描述
    //============
    public void SetGameSelectOpposite_Description_Text(string Description) {
        GameSelectOpposite_Description_Text.text = "" + Description;
    }

    //============
    //清空競爭對手描述
    //============
    public void SetGameSelectOpposite_Description_Text_Clear()
    {
        GameSelectOpposite_Description_Text.text = "";
    }

    //============
    //設定確認訊息，(OppositeName : 競爭對手名稱)
    //============
    public void SetGameSelectOpposite_StartChoose_Text(string OppositeName) {
        GameSelectOpposite_StartChoose_Text.text = "確定向" + OppositeName + "的顧客進行營業?";
    }

    //============
    //清空確認訊息
    //============
    public void SetGameSelectOpposite_StartChoose_Text_Clear()
    {
        GameSelectOpposite_StartChoose_Text.text = "";
    }

    //============
    //設定確認Button文字
    //============
    public void SetGameSelectOpposite_Start_Text(string Start) {
        GameSelectOpposite_Start_Text.text = "" + Start;
    }

    //============
    //清空確認Button文字
    //============
    public void SetGameSelectOpposite_Start_Text_Clear()
    {
        GameSelectOpposite_Start_Text.text = "";
    }


    //============
    //設定取消Button文字
    //============
    public void SetGameSelectOpposite_Cancel_Text(string Cancel) {
        GameSelectOpposite_Cancel_Text.text = "" + Cancel;
    }

    //============
    //清空取消Button文字
    //============
    public void SetGameSelectOpposite_Cancel_Text_Clear()
    {
        GameSelectOpposite_Cancel_Text.text = "";
    }

   


    //============
    //開啟或關閉，競爭對手Button的interactable，(id : 第幾個競爭對手 ， ButtonState : Button狀態)
    //============
    public void SetGameSelectOpposite_Button_interactable(int id , bool ButtonState) {
        GameSelectOpposite_Button[id].interactable = ButtonState;
    }

    //============
    //開啟或關閉，確認營業Button的interactable，(ButtonState : Button狀態)
    //============
    public void SetGameSelectOpposite_Start_Button_interactable(bool ButtonState)
    {
        GameSelectOpposite_Start_Button.interactable = ButtonState;
    }

    //============
    //開啟或關閉，取消營業Button的interactable，(ButtonState : Button狀態)
    //============
    public void SetGameSelectOpposite_Cancel_Button_interactable(bool ButtonState)
    {
        GameSelectOpposite_Cancel_Button.interactable = ButtonState;
    }

    //============
    //開啟或關閉，BackButton的interactable，(ButtonState : Button狀態)
    //============
    public void SetBackButton_interactable(bool ButtonState)
    {
        BackButton.interactable = ButtonState;
    }
    

    //============
    //一次修改GameSelectOpposite，(Opposite : 選擇的競爭對手 ， Opposites:全部的競爭對手)
    //============
    public void SetGameSelectOpposite(Opposite_Class Opposite , Opposite_Class[] Opposites)
    {
        //設定競爭對手Logo
        SetGameSelect_Logo_Sprite(Opposite.Getid());
        //設定競爭對手店鋪名稱
        SetGameSelectOpposite_Name_Text(Opposite.GetOpposite_Name());
        //設定競爭對手老闆名稱
        SetGameSelectOpposite_Boss_Text(Opposite.GetOpposite_Boss());
        //設定競爭對手階級
        SetGameSelectOpposite_Level_Text(Opposite.GetOpposite_Level());
        //設定競爭粉絲人數
        SetGameSelectOpposite_FansNumber_Text(Opposite.GetOpposite_FansNumber());
        //設定競爭區域粉絲人數
        SetGameSelectOpposite_AreaFansNumber_Text(Opposite.GetOpposite_AreaFans());
        //設定競爭對手描述
        SetGameSelectOpposite_Description_Text(Opposite.GetOpposite_Description());

        //設定確認訊息
        SetGameSelectOpposite_StartChoose_Text(Opposite.GetOpposite_Name());
        //設定確認Button文字
        SetGameSelectOpposite_Start_Text("#是啊");
        //設定取消Button文字
        SetGameSelectOpposite_Cancel_Text("取消!");

        //關閉選擇的競爭對手的GameSelectOpposite_Button
        SetGameSelectOpposite_Button_interactable(Opposite.Getid() , false);
        //開啟其它已解鎖的競爭對手的GameSelectOpposite_Button
        MVU.SetGameSelectOpposite_Button_interactable(Opposite.Getid() , Opposites , GameSelectOpposite_Button);
        //開啟確認營業Button的interactable
        SetGameSelectOpposite_Start_Button_interactable(true);
        //開啟取消營業Button的interactable
        SetGameSelectOpposite_Cancel_Button_interactable(true);

        //關閉返回Button
        VMS.SetBackButton_interactable(false);
        //BackButton的Text的透明度為0
        VMS.SetBackButton_Text_Color(0.0f);
    }

    //============
    //清空GameSelectOpposite，(Opposite : 競爭對手 ， Opposites:全部的競爭對手)
    //============
    public void SetGameSelectOpposite_Clear(Opposite_Class Opposite , Opposite_Class[] Opposites)
    {
        //設定競爭對手Logo
        SetGameSelect_Logo_Sprite_Clear();
        //設定競爭對手店鋪名稱
        SetGameSelectOpposite_Name_Text_Clear();
        //設定競爭對手老闆名稱
        SetGameSelectOpposite_Boss_Text_Clear();
        //設定競爭對手階級
        SetGameSelectOpposite_Level_Text_Clear();
        //設定競爭粉絲人數
        SetGameSelectOpposite_FansNumber_Text_Clear();
        //設定競爭區域粉絲人數
        SetGameSelectOpposite_AreaFansNumber_Text_Clear();
        //設定競爭對手描述
        SetGameSelectOpposite_Description_Text_Clear();

        //設定確認訊息
        SetGameSelectOpposite_StartChoose_Text_Clear();
        //設定確認Button文字
        SetGameSelectOpposite_Start_Text_Clear();
        //設定取消Button文字
        SetGameSelectOpposite_Cancel_Text_Clear();

        //開啟選擇的競爭對手的GameSelectOpposite_Button
        SetGameSelectOpposite_Button_interactable(Opposite.Getid(), true);
        //開啟其它已解鎖的競爭對手的GameSelectOpposite_Button
        MVU.SetGameSelectOpposite_Button_interactable(Opposite.Getid(), Opposites, GameSelectOpposite_Button);
        //關閉確認營業Button的interactable
        SetGameSelectOpposite_Start_Button_interactable(false);
        //關閉取消營業Button的interactable
        SetGameSelectOpposite_Cancel_Button_interactable(false);

        //開啟返回Button
        VMS.SetBackButton_interactable(true);
        //BackButton的Text的透明度為100
        VMS.SetBackButton_Text_Color(100.0f);

    }


}//View_Manage_GameSelect_Script
