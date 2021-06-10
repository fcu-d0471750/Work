/*
 * ManageScene_View_UI : 讓View_Manageg使用的UI涵式庫
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageScene_View_UI : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //迴圈用
    int i, j;

    //======================================================
    //宣告UI
    //======================================================

    //============
    //Sprite
    //============

    //全部Lady的HeadShot
    public Sprite[] LadyHeadShot = new Sprite[30];

    //出勤小姐的階級圖，共4個階級
    public Sprite[] PrepareStaffhierarchy = new Sprite[4];

    //Looks的四種等級對應的Sprite，0:"DCircle"、1:"Circle"、2:"Triangle"、3:"Cross"
    public Sprite[] LooksSprite = new Sprite[4];

    //競爭對手Logo，共5個
    public Sprite[] Opposite_Logo_Sprite = new Sprite[5];

    //============
    //Color
    //============

    //Lady的GameAbility小視窗Looks的顏色，共四種
    public Color[] Lady_Looks_Color = new Color[4];

    //======================================================
    //外部方法
    //======================================================


    //============
    //Text的透明度
    //============
    public Color SetTextAlpha(Text InputText, float Alpha)
    {
        Color TempColor = new Color(InputText.color.r, InputText.color.g, InputText.color.b);

        TempColor.a = Alpha;

        return TempColor;
    }

    //============
    //小姐的階級圖，(hierarchy : 小姐階級)
    //============
    public Sprite GetPrepareStaffhierarchy(int hierarchy)
    {
        switch (hierarchy)
        {
            case 1:
                {
                    return PrepareStaffhierarchy[0];
                }
            case 2:
                {
                    return PrepareStaffhierarchy[1];
                }
            case 3:
                {
                    return PrepareStaffhierarchy[2];
                }
            case 4:
                {
                    return PrepareStaffhierarchy[3];
                }

            default:
                {
                    return PrepareStaffhierarchy[0];
                }


        }//switch
    }

    //============
    //Prepare頁面 : 出勤小姐人數，(PrepareLady : 出勤小姐)
    //============
    public int GetPrepareLadyNumber(Lady_Class[] PrepareLady)
    {
        //暫存人數
        int Temp = 0;

        for (i = 0; i < PrepareLady.Length; i++)
        {
            if (PrepareLady[i].GetisWorked() == true) Temp = Temp + 1;
        }

        return Temp;
    }

    //============
    //Prepare頁面 : 出勤花費，(PrepareLady : 出勤小姐)
    //============
    public uint GetPrepareLadyCost(Lady_Class[] PrepareLady)
    {
        //暫存出勤花費
        uint Temp = 0;

        for (i = 0; i < PrepareLady.Length; i++)
        {
            if (PrepareLady[i].GetisWorked() == true) Temp = Temp + PrepareLady[i].GetCost();
        }

        return Temp;
    }


    //============
    //Store頁面 : 選擇競爭對手(id : 對手編號)
    //============
    public void SetStoreOpposite(int id, Opposite_Class[] Opposite, Button[] StoreState_Opposite_Button)
    {
        //更新View，開啟StoreState_Opposite_Button的interactable
        for (i = 0; i < 5; i++)
        {
            StoreState_Opposite_Button[i].interactable = true;           
        }

        //更新View，關閉選擇的StoreState_Opposite_Button的interactable
        StoreState_Opposite_Button[id].interactable = false;
    }


    //============
    //Staff頁面 : 判斷StaffPage_Button_Previous、StaffPage_Button_Next是要開啟還是關閉(Page : 當前頁數 , StaffPage_Button_Previous : 上一頁Button , StaffPage_Button_Next : 下一頁Button)
    //============
    public void StaffPage_Button_interactable(int Page , Button StaffPage_Button_Previous , Button StaffPage_Button_Next)
    {
        //============
        //StaffPage_Button_Previous
        //============

        //如果Page==0，表示為第1頁，則關閉StaffPage_Button_Previous
        if (Page == 0) StaffPage_Button_Previous.interactable = false;
        //如果Page!=0，表示不為第1頁，則開啟StaffPage_Button_Previous
        else StaffPage_Button_Previous.interactable = true;

        //============
        //StaffPage_Button_Next
        //============

        //如果Page==3，表示為最後1頁，則關閉StaffPage_Button_Next
        if (Page == 3) StaffPage_Button_Next.interactable = false;
        //如果Page!=3，表示不為最後1頁，則開啟StaffPage_Button_Next
        else StaffPage_Button_Next.interactable = true;

    }


    //============
    //Staff頁面 : Looks的四種等級，(Lookstring : 四種等級對應的Sprite)
    //============
    public Sprite GetLooksSprite(string Lookstring)
    {
        if (Lookstring == "DCircle") return LooksSprite[0];
        else if (Lookstring == "Circle") return LooksSprite[1];
        else if (Lookstring == "Triangle") return LooksSprite[2];
        else return LooksSprite[3];
    }


    //============
    //Staff頁面 : Lady的Looks對應的四種顏色，(Lookstring : Lady的Looks的string)
    //============
    public Color GetLady_Looks_Color(string Lookstring)
    {
        if (Lookstring == "DCircle") return Lady_Looks_Color[0];
        else if (Lookstring == "Circle") return Lady_Looks_Color[1];
        else if (Lookstring == "Triangle") return Lady_Looks_Color[2];
        else return Lady_Looks_Color[3];
    }



    //============
    //PrepareStaff頁面 : 合計所有出勤小姐的Cost，(PrepareLady: 全部的出勤小姐)
    //============
    public uint Sum_PrepareStaffLadyAbility_Cost(Lady_Class[] PrepareLady)
    {
        //暫存Hp
        uint Temp = 0;

        for (i = 0; i < 8; i++)
        {
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) Temp = Temp + PrepareLady[i].GetCost();
        }

        return Temp;
    }

    //============
    //PrepareStaff頁面 : 合計所有出勤小姐的Hp，(PrepareLady: 全部的出勤小姐)
    //============
    public float Sum_PrepareStaffLadyAbility_Hp(Lady_Class[] PrepareLady) {
        //暫存Hp
        float Temp = 0.0f;

        for (i = 0; i < 8; i++) {
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) Temp = Temp + PrepareLady[i].GetHp();
        }

        return Temp;
    }

    //============
    //PrepareStaff頁面 : 合計所有出勤小姐的Talk，(PrepareLady: 全部的出勤小姐)
    //============
    public float Sum_PrepareStaffLadyAbility_Talk(Lady_Class[] PrepareLady)
    {
        //暫存Talk
        float Temp = 0.0f;

        for (i = 0; i < 8; i++)
        {
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) Temp = Temp + PrepareLady[i].GetTalk();
        }

        return Temp;
    }

    //============
    //PrepareStaff頁面 : 合計所有出勤小姐的Party，(PrepareLady: 全部的出勤小姐)
    //============
    public float Sum_PrepareStaffLadyAbility_Party(Lady_Class[] PrepareLady)
    {
        //暫存Party
        float Temp = 0.0f;

        for (i = 0; i < 8; i++)
        {
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) Temp = Temp + PrepareLady[i].GetParty();
        }

        return Temp;
    }

    //============
    //PrepareStaff頁面 : 合計所有出勤小姐的Love，(PrepareLady: 全部的出勤小姐)
    //============
    public float Sum_PrepareStaffLadyAbility_Love(Lady_Class[] PrepareLady)
    {
        //暫存Love
        float Temp = 0.0f;

        for (i = 0; i < 8; i++)
        {
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) Temp = Temp + PrepareLady[i].GetLove();
        }

        return Temp;
    }

    //============
    //PrepareStaff頁面 : 合計所有出勤小姐的Skill，(PrepareLady: 全部的出勤小姐)
    //============
    public float Sum_PrepareStaffLadyAbility_Skill(Lady_Class[] PrepareLady)
    {
        //暫存Skill
        float Temp = 0.0f;

        for (i = 0; i < 8; i++)
        {
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) Temp = Temp + PrepareLady[i].GetSkill();
        }

        return Temp;
    }



    //============
    //(GameSelect頁面)
    //============

    //============
    //GameSelect頁面: 取得競爭對手Logo，(id : 競爭對手id)
    //============
    public Sprite GetOpposite_Logo_Sprite(int id) {
        return Opposite_Logo_Sprite[id];
    }

    //============
    //GameSelect頁面: 判斷競爭對手Button是否符合開啟條件，(id : 已選擇的競爭對手id ， Opposite: 競爭對手， GameSelectOpposite_Button : 競爭對手Button)
    //============
    public void SetGameSelectOpposite_Button_interactable(int id , Opposite_Class[] Opposite , Button[] GameSelectOpposite_Button)
    {
        
        for (i = 0; i < GameSelectOpposite_Button.Length; i++) {
            if (i == id) continue;
            //已解鎖
            if (Opposite[i].GetOpposite_isunLocked() == true) GameSelectOpposite_Button[i].interactable = true;
            //未解鎖
            else GameSelectOpposite_Button[i].interactable = false;
        }

    }


}//ManageScene_View_UI
