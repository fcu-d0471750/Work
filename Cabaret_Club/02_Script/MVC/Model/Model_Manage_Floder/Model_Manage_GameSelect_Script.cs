/*
 * Model:管理ManageScene底下的GameSelectBase、GameSelectBaseCanvas
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Manage_GameSelect_Script : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //Model_Manage_Script : Manage所有的Model統一管理Script
    public Model_Manage_Script MMS;

    //當前選擇的競爭對手
    private int OppositeNumber = 0;

    //迴圈用
    private int i, j;




    //======================================================
    //外部方法
    //======================================================

    //============
    //取得選擇的競爭對手
    //============
    public int GetOppositeNumber()
    {
        return OppositeNumber;
    }


    //======================================================
    //外部方法(Button)
    //======================================================

    //============
    //(Button)選擇競爭對手，(id : 競爭對手id)
    //============
    public void SetOpposite(int id) {

        //設定選擇的競爭對手
        OppositeNumber = id;

        //更新View
        MMS.MCS.VMS.V_M_GameSelect.SetGameSelectOpposite(MMS.GetOpposite(id) , MMS.GetAllOpposite());
    }

    //============
    //(Button)確定競爭對手
    //============
    public void SetStart()
    {
        MMS.SetStart();
    }

    //============
    //(Button)取消競爭對手
    //============
    public void SetCancel()
    {
        MMS.MCS.VMS.V_M_GameSelect.SetGameSelectOpposite_Clear(MMS.GetOpposite(OppositeNumber) , MMS.GetAllOpposite());
    }

}//Model_Manage_GameSelect_Script
