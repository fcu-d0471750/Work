/*
 * Model:管理ManageScene底下的StaffBase、StaffBaseCanvas
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Manage_Staff_Script : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //Model_Manage_Script : Manage所有的Model統一管理Script
    public Model_Manage_Script MMS;

    //當前頁數
    private int Page = 0;

    //迴圈用
    private int i, j;

    //======================================================
    //外部方法
    //======================================================

    //============
    //取得當前頁數
    //============
    public int GetPage() {
        return Page;
    }

    //============
    //設定當前頁數
    //============
    public void SetPage(int Page)
    {
        this.Page = Page;
    }


    //======================================================
    //外部方法(Button)(PrepareStaff頁面 -> Staff頁面)
    //======================================================

    //============
    //選擇出勤小姐(id : Staff頁面八個在籍小姐欄位，哪一個欄位的在籍小姐)
    //============
    public void SetPrepareStaff(int id) {
        //設定選定的出勤小姐，如果現在狀態為PrepareStaff頁面 -> Staff頁面 且 沒有選擇超過30位在籍小姐 且 選擇的在籍小姐是已解鎖 且 選擇的在籍小姐未出勤
        if (MMS.GetNow_State() == 6 && (id + (Page * 8)) <= 29 && MMS.GetCabaret_Club().GetStaffLady((id + (Page * 8))).GetisunLock() == true && MMS.GetCabaret_Club().GetStaffLady((id + (Page * 8))).GetisWorked() == false)
        {
            //如果PrepareStaff頁面選擇的欄位沒有安排出勤小姐
            if (MMS.GetPrepareLady(MMS.M_M_PrepareStaff.GetPrepareStaff_Number()).GetisWorked() == false)
            {
                //設定選擇的出勤小姐(id : 從Staff頁面選擇的出勤小姐id)
                MMS.SetPrepareLady((id + (Page * 8)));

                //重新回到第1頁
                Page = 0;

                //更新View，回到Prepare頁面
                MMS.SetNow_State(5);
            }
            //如果選擇的欄位有安排出勤小姐
            else
            {
                //將原本在出勤小姐欄位上的小姐設為未出勤
                MMS.GetCabaret_Club().GetStaffLady(MMS.GetPrepareLady(MMS.M_M_PrepareStaff.GetPrepareStaff_Number()).Getid()).SetisWorked(false);

                //設定選擇的出勤小姐(id : 從Staff頁面選擇的出勤小姐id)
                MMS.SetPrepareLady((id + (Page * 8)));

                //重新回到第1頁
                Page = 0;

                //更新View，回到Prepare頁面
                MMS.SetNow_State(5);
            }

        }
       
    }

    //======================================================
    //外部方法(EventTrigger更新View)
    //======================================================

    //============
    //StaffAbility(id : 八個在籍小姐欄位，哪一個欄位的在籍小姐)
    //============
    public void DoStaffAbility_UpdateView(int id)
    {
        //Point進入，更新View，一次修改StaffAbility
        ////由於只有30名在籍小姐，最後一頁的最後2個欄位不會有資料，所以要判斷是否超過，防止超出陣列範圍
        if ((id + (Page * 8) <= 29) && MMS.GetCabaret_Club().GetStaffLady(id + (Page*8)).GetisunLock() == true)
        {
            MMS.MCS.VMS.V_M_Staff.SetStaffLadyAbility(MMS.GetCabaret_Club().GetStaffLady(id + (Page * 8)));
        }
    }

    //============
    //清空StaffAbility
    //============
    public void DoStaffAbility_UpdateView_Clear()
    {
        //Point離開，更新View，清空StaffAbility
        MMS.MCS.VMS.V_M_Staff.SetStaffLadyAbility_Clear();
    }

    //======================================================
    //外部方法(Button)
    //======================================================

    //============
    //(Button)切換上一頁
    //============
    public void SetPreviousPage() {
        //如果Page==0，表示為第1頁，則不減1
        if (Page == 0) Page = 0;
        //如果Page!=0，表示不為第1頁，則減1
        else Page = Page - 1;

        //更新View，開啟或關閉StaffPage_Button_Previous的interactable
        MMS.MCS.VMS.V_M_Staff.SetStaffPage_Button(Page);
        //更新View，一次修改StaffLadies
        MMS.MCS.VMS.V_M_Staff.SetStaffLadies(Page , MMS.GetCabaret_Club().GetAllStaffLady());
        //更新View，清空StaffAbility
        MMS.MCS.VMS.V_M_Staff.SetStaffLadyAbility_Clear();
    }

    //============
    //(Button)切換下一頁
    //============
    public void SetNextPage()
    {
        //如果Page==3，表示為最後1頁，則不加1
        if (Page == 3) Page = 3;
        //如果Page!=3，表示不為最後1頁，則加1
        else Page = Page + 1;

        //更新View，開啟或關閉StaffPage_Button_Next的interactable
        MMS.MCS.VMS.V_M_Staff.SetStaffPage_Button(Page);
        //更新View，一次修改StaffLadies
        MMS.MCS.VMS.V_M_Staff.SetStaffLadies(Page, MMS.GetCabaret_Club().GetAllStaffLady());
        //更新View，清空StaffAbility
        MMS.MCS.VMS.V_M_Staff.SetStaffLadyAbility_Clear();
    }



}//Model_Manage_Staff_Script
