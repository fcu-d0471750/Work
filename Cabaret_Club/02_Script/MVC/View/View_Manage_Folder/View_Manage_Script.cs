using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_Manage_Script : MonoBehaviour
{
    //======================================================
    //UI來源
    //======================================================

    public ManageScene_View_UI MSV;

    //======================================================
    //宣告變數
    //======================================================

    //迴圈用
    int i, j;

    //ManageScene_Control_Script : 用於Model_Manage_Script和View_Manage_Begin_Script之間的溝通
    public ManageScene_Control_Script MCS;


    //==================
    //底下的所有View
    //==================

    //View_Manage_Begin_Script : 管理ManageScene底下的BeginBase、BeginBaseCanvas的View
    public View_Manage_Begin_Script V_M_Begin;

    //View_Manage_Prepare_Script : 管理ManageScene底下的PrepareBase、PrepareBaseCanvas的View
    public View_Manage_Prepare_Script V_M_Prepare;

    //View_Manage_Prepare_Script : 管理ManageScene底下的StoreBase、StoreBaseCanvas的View
    public View_Manage_Store_Script V_M_Store;

    //View_Manage_Staff_Script : 管理ManageScene底下的StaffBase、StaffBaseCanvas的View
    public View_Manage_Staff_Script V_M_Staff;

    //View_Manage_PrepareStaff_Script : 管理ManageScene底下的PrepareBase、PrepareBaseCanvas的View
    public View_Manage_PrepareStaff_Script V_M_PrepareStaff;

    //View_Manage_GameSelect_Script : 管理ManageScene底下的GameSelectBase、GameSelectBaseCanvas的View
    public View_Manage_GameSelect_Script V_M_GameSelect;

   

    

    //============
    //Sprite
    //============

    //============
    //Text
    //============

    //============
    //(Other)
    //============

    //BackButton Text
    public Text BackButton_Text;

    //============
    //Image
    //============

    //============
    //(Other)
    //============

    //BackButton 
    public Button BackButton;


    //============
    //GameObject
    //============

    //BeginBase
    public GameObject BeginBase;

    //PrepareBase
    public GameObject PrepareBase;

    //StoreBase
    public GameObject StoreBase;

    //StaffBase
    public GameObject StaffBase;

    //PrepareStaffBase
    public GameObject PrepareStaffBase;

    //GameSelectBase
    public GameObject GameSelectBase;

    //InstructionsBase
    public GameObject InstructionsBase;


    //============
    //(GameObjectCanvas)
    //============

    //BeginCanvas
    public GameObject BeginCanvas;

    //PrepareCanvas
    public GameObject PrepareCanvas;

    //StoreCanvas
    public GameObject StoreCanvas;

    //StaffCanvas
    public GameObject StaffCanvas;

    //PrepareStaffCanvas
    public GameObject PrepareStaffCanvas;

    //GameSelectCanvas
    public GameObject GameSelectCanvas;

    //InstructionsCanvas
    public GameObject InstructionsCanvas;



    //======================================================
    //外部方法
    //======================================================


    //============
    //(GameObject)
    //============

    //============
    //BeginBase
    //============
    public void SetBeginBasePosition(float x, float y, float z)
    {
        BeginBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //PrepareBase
    //============
    public void SetPrepareBasePosition(float x, float y, float z)
    {
        PrepareBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //StoreBase
    //============
    public void SetStoreBasePosition(float x, float y, float z)
    {
        StoreBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //StaffBase
    //============
    public void SetStaffBasePosition(float x, float y, float z)
    {
        StaffBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //PrepareStaffBase
    //============
    public void SetPrepareStaffBasePosition(float x, float y, float z)
    {
        PrepareStaffBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //GameSelectBase
    //============
    public void SetGameSelectBasePosition(float x, float y, float z)
    {
        GameSelectBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //InstructionsBase
    //============
    public void SetInstructionsBasePosition(float x, float y, float z)
    {
        InstructionsBase.transform.position = new Vector3(x, y, z);
    }

    //============
    //(GameObjectCanvas)
    //============

    //============
    //BeginCanvas
    //============
    public void SetBeginCanvasPosition(float x, float y, float z)
    {
        BeginCanvas.transform.position = new Vector3(x, y, z);
    }

    //============
    //PrepareCanvas
    //============
    public void SetPrepareCanvasPosition(float x, float y, float z)
    {
        PrepareCanvas.transform.position = new Vector3(x, y, z);
    }

    //============
    //StoreCanvas
    //============
    public void SetStoreCanvasPosition(float x, float y, float z)
    {
        StoreCanvas.transform.position = new Vector3(x, y, z);
    }

    //============
    //StaffCanvas
    //============
    public void SetStaffCanvasPosition(float x, float y, float z)
    {
        StaffCanvas.transform.position = new Vector3(x, y, z);
    }

    //============
    //PrepareStaffCanvas
    //============
    public void SetPrepareStaffCanvasPosition(float x, float y, float z)
    {
        PrepareStaffCanvas.transform.position = new Vector3(x, y, z);
    }

    //============
    //GameSelectCanvas
    //============
    public void SetGameSelectCanvasPosition(float x, float y, float z)
    {
        GameSelectCanvas.transform.position = new Vector3(x, y, z);
    }

    //============
    //InstructionsCanvas
    //============
    public void SetInstructionsCanvasPosition(float x, float y, float z)
    {
        InstructionsCanvas.transform.position = new Vector3(x, y, z);
    }

    //============
    //一次修改BeginBase...在內的Position
    //============
    public void SetAllManageBasePosition(float x, float y, float z)
    {
        SetBeginBasePosition(x / 5.0f, y, z);
        SetPrepareBasePosition(x / 5.0f, y, z);
        SetStoreBasePosition(x / 5.0f, y, z);
        SetStaffBasePosition(x / 5.0f, y, z);
        SetPrepareStaffBasePosition(x / 5.0f, y, z);
        SetGameSelectBasePosition(x / 5.0f, y, z);
        SetInstructionsBasePosition(x / 5.0f, y, z);

        SetBeginCanvasPosition(x * 10.0f, y, z);
        SetPrepareCanvasPosition(x * 10.0f, y, z);
        SetStoreCanvasPosition(x * 10.0f, y, z);
        SetStaffCanvasPosition(x * 10.0f, y, z);
        SetPrepareStaffCanvasPosition(x * 10.0f, y, z);
        SetGameSelectCanvasPosition(x * 10.0f, y, z);
        SetInstructionsCanvasPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改Begin的Position
    //============
    public void SetAllBeginPosition(float x, float y, float z)
    {
        SetBeginBasePosition(x / 5.0f, y, z);

        SetBeginCanvasPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改Prepare的Position
    //============
    public void SetAllPreparePosition(float x, float y, float z)
    {
        SetPrepareBasePosition(x / 5.0f, y, z);

        SetPrepareCanvasPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改Store的Position
    //============
    public void SetAllStorePosition(float x, float y, float z)
    {
        SetStoreBasePosition(x / 5.0f, y, z);

        SetStoreCanvasPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改Staff的Position
    //============
    public void SetAllStaffPosition(float x, float y, float z)
    {
        SetStaffBasePosition(x / 5.0f, y, z);

        SetStaffCanvasPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改PrepareStaff的Position
    //============
    public void SetAllPrepareStaffPosition(float x, float y, float z)
    {
        SetPrepareStaffBasePosition(x / 5.0f, y, z);

        SetPrepareStaffCanvasPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改GameSelect的Position
    //============
    public void SetAllGameSelectPosition(float x, float y, float z)
    {
        SetGameSelectBasePosition(x / 5.0f, y, z);

        SetGameSelectCanvasPosition(x * 10.0f, y, z);
    }

    //============
    //一次修改Instructions的Position
    //============
    public void SetAllInstructionsPosition(float x, float y, float z)
    {
        SetInstructionsBasePosition(x / 5.0f, y, z);

        SetInstructionsCanvasPosition(x * 10.0f, y, z);
    }

   

    //============
    //(Other)
    //============

    //============
    //BackButton的Text(Text)
    //============
    public void SetBackButton_Text(string Backstring)
    {
        BackButton_Text.text = "" + Backstring;
    }

    //============
    //開啟或關閉，BackButton的interactable(Button)(ButtonState: 開啟或關閉Button)
    //============
    public void SetBackButton_interactable(bool ButtonState)
    {
        BackButton.interactable = ButtonState;
    }

    //============
    //BackButton的Text的Color(Text)
    //============
    public void SetBackButton_Text_Color(float Alpha)
    {
        BackButton_Text.color = MSV.SetTextAlpha(BackButton_Text, Alpha);
    }

}//View_Manage_Script
