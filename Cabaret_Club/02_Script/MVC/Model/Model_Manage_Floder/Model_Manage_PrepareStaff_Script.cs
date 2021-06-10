/*
 * Model:管理ManageScene底下的PrepareStaffBase、PrepareStaffBaseCanvas
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Manage_PrepareStaff_Script : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //Model_Manage_Script : Manage所有的Model統一管理Script
    public Model_Manage_Script MMS;

    //選擇的欄位
    private int PrepareStaff_Number = 0;

    //迴圈用
    private int i, j;

    //======================================================
    //外部方法
    //======================================================

    //============
    //取得選擇的欄位
    //============
    public int GetPrepareStaff_Number() {
        return PrepareStaff_Number;
    }

    //======================================================
    //外部方法(Button)
    //======================================================

    //============
    //(Button)選擇的欄位
    //============
    public void SetPrepareStaff_Number(int Number) {
        PrepareStaff_Number = Number;
    }

    //======================================================
    //外部方法(EventTrigger更新View)
    //======================================================

    //============
    //更新View，選定的欄位的出勤小姐的PrepareStaffLadyAbility，(id : 選定的欄位)
    //============
    public void DoPrepareStaffLadyAbility_UpdateView(int id)
    {
        //如果選定的欄位有小姐出勤，則更新View
        if (MMS.GetPrepareLady(id).GetisWorked() == true) MMS.MCS.VMS.V_M_PrepareStaff.SetPrepareStaffLadyAbility(MMS.GetPrepareLady(id));
    }

    //============
    //更新View，清空選定的出勤小姐的PrepareStaffLadyAbility
    //============
    public void DoPrepareStaffLadyAbility_UpdateView_Clear()
    {
        MMS.MCS.VMS.V_M_PrepareStaff.SetPrepareStaffLadyAbility_Clear();
    }


    //============
    //取消出勤小姐，(id : 選定的欄位)
    //============
    public void RestPrepareStaff(int id) {
        //該欄位有出勤小姐 且 當按下右鍵，則該欄位的出勤小姐取消出勤
        if (MMS.GetPrepareLady(id).GetisWorked() == true && Input.GetMouseButtonDown(1))
        {
            //取消出勤小姐
            MMS.RestPrepareLady(id);
            //更新View，清空選定的出勤小姐的PrepareStaffLadyAbility
            MMS.MCS.VMS.V_M_PrepareStaff.SetPrepareStaffLadyAbility_Clear();
        }
    }

}//Model_Manage_PrepareStaff_Script
