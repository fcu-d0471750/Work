/*
 * Model:管理ManageScene底下的BeginBase、BeginBaseCanvas
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Manage_Begin_Script : MonoBehaviour
{

    //======================================================
    //宣告變數
    //======================================================

    //Model_Manage_Script : Manage所有的Model統一管理Script
    public Model_Manage_Script MMS;

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


}//Model_Manage_Begin_Script
