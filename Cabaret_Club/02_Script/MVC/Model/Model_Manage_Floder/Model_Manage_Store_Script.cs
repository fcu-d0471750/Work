/*
 * Model:管理ManageScene底下的StoreBase、StoreBaseCanvas
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Manage_Store_Script : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //Model_Manage_Script : Manage所有的Model統一管理Script
    public Model_Manage_Script MMS;

    //迴圈用
    private int i, j;

    //======================================================
    //外部方法
    //======================================================



    //======================================================
    //外部方法(Button)
    //======================================================

    //============
    //(Button)選擇競爭對手(id : 競爭對手編號)
    //============
    public void SetStoreOpposite(int id) {
        //更新View，一次修改Store的StoreState_Opposite
        MMS.MCS.VMS.V_M_Store.SetStoreState_Opposite_Button_interactable(id , MMS.GetAllOpposite());
    }

}//Model_Manage_Store_Script
