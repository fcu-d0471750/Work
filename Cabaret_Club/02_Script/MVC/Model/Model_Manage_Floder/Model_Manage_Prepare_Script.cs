/*
 * Model:管理ManageScene底下的PrepareBase、PrepareBaseCanvas
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Manage_Prepare_Script : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //Model_Manage_Script : Manage所有的Model統一管理Script
    public Model_Manage_Script MMS;
   

    //======================================================
    //外部方法(EventTrigger更新View)
    //======================================================

    //============
    //PrepareAbility(id : LadySeat的id)
    //============
    public void DoPrepareAbility_UpdateView(int id)
    {
        //Point進入，更新View，小視窗(PrepareAbility)
        if (MMS.GetPrepareLady(id).GetisWorked() == true)
        {
            //一次修改PreparAbility的Hp、Talk、Party、Love、Skill的Text
            MMS.MCS.VMS.V_M_Prepare.SetPrepareAbility_Text(MMS.GetPrepareLady(id));
            //一次修改PreparAbility的Bar_Image的Text(PrepareLady : 出勤小姐)
            MMS.MCS.VMS.V_M_Prepare.SetPrepareAbility_Bar_Image_FillAmount(MMS.GetPrepareLady(id));
        }
    }

    //============
    //清空PrepareAbility
    //============
    public void DoPrepareAbility_UpdateView_Clear()
    {
        //Point離開，更新View，清空PreparAbility的Hp、Talk、Party、Love、Skill的Text
        MMS.MCS.VMS.V_M_Prepare.SetPrepareAbility_Text_Clear();
        ///Point離開，更新View，清空PreparAbility的Bar_Image的Text
        MMS.MCS.VMS.V_M_Prepare.SetPrepareAbility_Bar_Image_FillAmount_Clear();
    }

    //======================================================
    //內部方法
    //======================================================

    //======================================================
    //Button方法
    //======================================================

    //============
    //(Button)設定狀態編號(id : 狀態編號)
    //============
    public void SetMMS_Now_State(int id)
    {
        MMS.SetNow_State(id);
    }


}//Model_Manage_Prepare_Script
