/*
 * Model:管理ManageScene，底下所有的Model
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Model_Manage_Script : MonoBehaviour
{

    //======================================================
    //宣告變數
    //======================================================

    //ManageScene_Control_Script : 用於Model_Manage_Script和View_Manage_Begin_Script之間的溝通
    public ManageScene_Control_Script MCS;

    //LadyData : 在籍小姐資料
    public LadyData LD = new LadyData();

    //OppositeData : 在籍小姐資料
    public OppositeData OD = new OppositeData();

    //Cabaret_Club_Class : Cabaret_Club基本資料
    private Cabaret_Club_Class Cabaret_Club_ = new Cabaret_Club_Class();

    //PrepareLady : 出勤小姐，共8個欄位
    private Lady_Class[] PrepareLady = new Lady_Class[8];

    //PrepareLadyNumber : 出勤小姐人數
    private int PrepareLadyNumber = 0;

    //SaveGame_Class : 存檔
    private GameSave gamesave = new GameSave();

    //Opposite : 競爭對手，共5位
    private Opposite_Class[] Opposite = new Opposite_Class[5];

   

    //==================
    //底下的所有Model
    //==================

    //Model_Manage_Begin_Script : 管理ManageScene底下的BeginBase、BeginBaseCanvas
    public Model_Manage_Begin_Script M_M_Begin;

    //Model_Manage_Prepare_Script : 管理ManageScene底下的PrepareBase、PrepareBaseCanvas
    public Model_Manage_Prepare_Script M_M_Prepare;

    //Model_Manage_Store_Script : 管理ManageScene底下的StoreBase、StoreBaseCanvas
    public Model_Manage_Store_Script M_M_Store;

    //Model_Manage_Staff_Script : 管理ManageScene底下的StaffBase、StaffBaseCanvas
    public Model_Manage_Staff_Script M_M_Staff;

    //Model_Manage_PrepareStaff_Script : 管理ManageScene底下的PrepareStaffBase、PrepareStaffBaseCanvas
    public Model_Manage_PrepareStaff_Script M_M_PrepareStaff;

    //Model_Manage_GameSelect_Script : 管理ManageScene底下的GameSelectBase、GameSelectBaseCanvas
    public Model_Manage_GameSelect_Script M_M_GameSelect;


    //==================
    //迴圈用
    //==================
    private int i, j;

    //==================
    //State
    //==================

    //int : 現在狀態，預設1表示總體頁面
    private int Now_State = 1;

    
    private void Start()
    {      
        //更新View，一次修改一次修改BeginBase...在內所有頁面到畫面外
        MCS.VMS.SetAllManageBasePosition(100.0f, 0.0f, 0.0f);
        //更新View，一次修改總體頁面到畫面中
        MCS.VMS.SetAllBeginPosition(0.0f, 0.0f, 0.0f);



        //新建PrepareLady
        CreatePrepareLady();
        //新建Opposite
        CreateOpposite();
        //新建Cabaret_Club_
        Cabaret_Club_ = new Cabaret_Club_Class("真島吾郎", 0, 0, LD);

        //讀檔
        gamesave.DoLoad_ManageScene(Cabaret_Club_, PrepareLady, Opposite);

        //計算出勤小姐人數
        for (i = 0; i < PrepareLady.Length; i++) if (PrepareLady[i].GetisWorked() == true) PrepareLadyNumber = PrepareLadyNumber + 1;


        //(Begin頁面)更新View，一次修改Begin
        MCS.VMS.V_M_Begin.SetBegin(Cabaret_Club_);

        //(Prepare頁面)更新View，一次修改PrepareStaff
        MCS.VMS.V_M_Prepare.SetPrepareStaff(PrepareLady);
        //(Prepare頁面)更新View，一次修改PrepareNumber、PrepareCost
        MCS.VMS.V_M_Prepare.SetPrepareAbility_PrepareNumber_PrepareCost_Text(PrepareLady);

        //(Store頁面)更新View，一次修改StoreState
        MCS.VMS.V_M_Store.SetStoreState_Text(Cabaret_Club_);
        //(Store頁面)更新View，一次修改Store的StoreState_Opposite
        MCS.VMS.V_M_Store.SetStoreState_Opposite_Button_interactable(0, Opposite);

        //(Staff頁面)更新View，一次修改StaffLady的所有項目
        MCS.VMS.V_M_Staff.SetStaffLadies(0 , Cabaret_Club_.GetAllStaffLady());
        //(Staff頁面)更新View，一次修改Staff的StaffPage_Button
        MCS.VMS.V_M_Staff.SetStaffPage_Button(0);

        //(PrepareStaff頁面)更新View，一次修改PreStaff
        MCS.VMS.V_M_PrepareStaff.SetPrepareStaff(PrepareLadyNumber , PrepareLady);

        //(GameSelect頁面)更新View，清空GameSelectOpposite
        MCS.VMS.V_M_GameSelect.SetGameSelectOpposite_Clear(Opposite[0] , Opposite);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))  gamesave.DoSave_ManageScene(Cabaret_Club_ , PrepareLady , Opposite , M_M_GameSelect.GetOppositeNumber());
        //if (Input.GetKeyDown(KeyCode.L)) gamesave.DoLoad_ManageScene(Cabaret_Club_, PrepareLady, Opposite);
        
    }


    //======================================================
    //生成方法
    //======================================================

    //==================
    //生成PrepareLady
    //==================
    private void CreatePrepareLady()
    {    
        for (i = 0; i < PrepareLady.Length; i++)
        {
            PrepareLady[i] = new Lady_Class();
        }        
    }

    //==================
    //生成Opposite
    //==================
    private void CreateOpposite()
    {
        for (i = 0; i < Opposite.Length; i++)
        {
            Opposite[i] = new Opposite_Class();
            Opposite[i] = OD.Opposite[i];
        }       
    }


    //======================================================
    //外部方法
    //======================================================

    //==================
    //設定現在狀態編號(id : 狀態編號)
    //==================
    public void SetNow_State(int id) {
        Now_State = id;
       
        //切換狀態後，設定BackButton
        SetNowBackButton();

        //切換狀態後，更新View的Position
        SetNowPosition();
    }

    //==================
    //取得現在狀態編號
    //==================
    public int GetNow_State()
    {
        return Now_State;
    }

    //==================
    //取得Cabaret_Club基本資料
    //==================
    public Cabaret_Club_Class GetCabaret_Club()
    {
        return Cabaret_Club_;
    }
    

    //==================
    //取得出勤小姐(id : 第幾位出勤小姐)
    //==================
    public Lady_Class GetPrepareLady(int id) {    
        return PrepareLady[id];
    }

    //==================
    //設定選擇的出勤小姐(id : 從Staff頁面選擇的出勤小姐id)
    //==================
    public void SetPrepareLady(int id)
    {        

        //將被選擇的小姐，設為出勤中
        Cabaret_Club_.GetStaffLady(id).SetisWorked(true);

        //設定出勤小姐
        PrepareLady[M_M_PrepareStaff.GetPrepareStaff_Number()] = Cabaret_Club_.GetStaffLady(id); ;

        //出勤小姐人數加1，最多8人
        if(PrepareLadyNumber < 8) PrepareLadyNumber = PrepareLadyNumber + 1;




        //(Staff頁面)更新View，一次修改StaffLady的所有項目
        MCS.VMS.V_M_Staff.SetStaffLadies(0, Cabaret_Club_.GetAllStaffLady());
        //(Staff頁面)更新View，一次修改Staff的StaffPage_Button
        MCS.VMS.V_M_Staff.SetStaffPage_Button(0);

        //(PrepareStaff頁面)更新View，一次修改PreStaff
        MCS.VMS.V_M_PrepareStaff.SetPrepareStaff(PrepareLadyNumber, PrepareLady);

        //(Prepare頁面)更新View，一次修改PrepareStaff
        MCS.VMS.V_M_Prepare.SetPrepareStaff(PrepareLady);
        //(Prepare頁面)更新View，一次修改PrepareNumber、PrepareCost
        MCS.VMS.V_M_Prepare.SetPrepareAbility_PrepareNumber_PrepareCost_Text(PrepareLady);


    }

    //==================
    //取消出勤小姐(Number : 第幾個欄位)
    //==================
    public void RestPrepareLady(int Number)
    {

        //將被選擇取消的欄位的小姐，設為未出勤
        Cabaret_Club_.GetStaffLady(PrepareLady[Number].Getid()).SetisWorked(false);

        //清空選擇取消的欄位
        PrepareLady[Number] = new Lady_Class();

        //出勤小姐人數減1
        PrepareLadyNumber = PrepareLadyNumber - 1;

        //(Staff頁面)更新View，一次修改StaffLady的所有項目
        MCS.VMS.V_M_Staff.SetStaffLadies(0, Cabaret_Club_.GetAllStaffLady());
        //(Staff頁面)更新View，一次修改Staff的StaffPage_Button
        MCS.VMS.V_M_Staff.SetStaffPage_Button(0);

        //(PrepareStaff頁面)更新View，一次修改PreStaff
        MCS.VMS.V_M_PrepareStaff.SetPrepareStaff(PrepareLadyNumber, PrepareLady);

        //(Prepare頁面)更新View，一次修改PrepareStaff
        MCS.VMS.V_M_Prepare.SetPrepareStaff(PrepareLady);
        //(Prepare頁面)更新View，一次修改PrepareNumber、PrepareCost
        MCS.VMS.V_M_Prepare.SetPrepareAbility_PrepareNumber_PrepareCost_Text(PrepareLady);
    }

    //==================
    //取得出勤小姐人數
    //==================
    public int GetPrepareLadyNumber()
    {
        return PrepareLadyNumber;
    }
  

    //==================
    //取得競爭對手中某一位資料(id : 第幾位競爭對手
    //==================
    public Opposite_Class GetOpposite(int id)
    {
        return Opposite[id];
    }

    //==================
    //取得全部競爭對手的資料
    //==================
    public Opposite_Class[] GetAllOpposite()
    {
        return Opposite;
    }

    //==================
    //開始營業，(給Model_Manage_GameSelect_Script使用，這樣就不需傳Cabaret_Club_, PrepareLady....等資料)
    //==================
    public void SetStart() {
        gamesave.DoSave_ManageScene(Cabaret_Club_, PrepareLady, Opposite, M_M_GameSelect.GetOppositeNumber());
    }

    //======================================================
    //內部方法
    //======================================================

    //============
    //切換狀態後，更新View的Position
    //============
    private void SetNowPosition()
    {

        //更新View，一次修改一次修改BeginBase...在內所有頁面到畫面外
        MCS.VMS.SetAllManageBasePosition(100.0f, 0.0f, 0.0f);
        
        //依照現在狀態，決定顯示頁面
        switch (Now_State)
        {
            case 1:
                {
                    //更新View，一次修改總體頁面到畫面中
                    MCS.VMS.SetAllBeginPosition(0.0f, 0.0f, 0.0f);
                    break;
                }

            case 2:
                {             
                    //更新View，一次修改準備頁面到畫面中
                    MCS.VMS.SetAllPreparePosition(0.0f, 0.0f, 0.0f);                  
                    break;
                }

            case 3:
                {
                    //更新View，一次修改店鋪狀況頁面到畫面中
                    MCS.VMS.SetAllStorePosition(0.0f, 0.0f, 0.0f);
                    break;
                }

            case 4:
            case 6:
                {
                    //更新View，一次修改在籍小姐頁面到畫面中
                    MCS.VMS.SetAllStaffPosition(0.0f, 0.0f, 0.0f);
                    break;
                }

            case 5:
            case 7:        
                {
                    //更新View，一次修改安排出勤小姐頁面到畫面中
                    MCS.VMS.SetAllPrepareStaffPosition(0.0f, 0.0f, 0.0f);
                    break;
                }

            case 8:
                {
                    //更新View，一次修改選擇區域頁面到畫面中
                    MCS.VMS.SetAllGameSelectPosition(0.0f, 0.0f, 0.0f);
                    break;
                }

            case 9:
                {
                    //更新View，一次修改說明頁面到畫面中
                    MCS.VMS.SetAllInstructionsPosition(0.0f, 0.0f, 0.0f);
                    break;
                }

        }//switch
    }

    //============
    //切換狀態後，設定BackButton
    //============
    private void SetNowBackButton()
    {
        //除了總體頁面，其它都是開啟BackButton
        if (Now_State == 1)
        {
            //關閉BackButton
            MCS.VMS.SetBackButton_interactable(false);
            //BackButton的Text的透明度為0
            MCS.VMS.SetBackButton_Text_Color(0.0f);
        }
        else
        {
            //開啟BackButton
            MCS.VMS.SetBackButton_interactable(true);
            //BackButton的Text的透明度為100
            MCS.VMS.SetBackButton_Text_Color(100.0f);
        }

    }

    //======================================================
    //Button方法
    //======================================================


    //============
    //(Button)返回
    //============
    public void Back_Now_State()
    {
        //依照現在狀態，決定返回編號
        switch (Now_State) {
            //開店準備、選擇區域、說明 返回到 總體頁面
            case 2:
            case 8:
            case 9:
                {
                    //回到 總體頁面
                    Now_State = 1;
                    //關閉BackButton
                    MCS.VMS.SetBackButton_interactable(false);
                    //BackButton的Text的透明度為0
                    MCS.VMS.SetBackButton_Text_Color(0.0f);
                    break;
                }
            //店鋪狀況、在籍小姐、安排出勤小姐 返回到 開店準備
            case 3:
            case 4:
            case 5:
                {
                    //回到 開店準備
                    Now_State = 2;
                    break;
                }
            //安排出勤小姐->在籍小姐、安排選則完成 返回到 安排出勤小姐
            case 6:
            case 7:
                {
                    //回到 安排出勤小姐
                    Now_State = 5;
                    break;
                }
            //預設
            default:
                {
                    //回到 總體頁面
                    Now_State = 1;
                    //關閉BackButton
                    MCS.VMS.SetBackButton_interactable(false);
                    //BackButton的Text的透明度為0
                    MCS.VMS.SetBackButton_Text_Color(0.0f);
                    break;
                }

                
        }//switch

        //將Staff頁面的當前頁數，設回第1頁
        M_M_Staff.SetPage(0);
        //(Staff頁面)更新View，一次修改StaffLady的所有項目
        MCS.VMS.V_M_Staff.SetStaffLadies(0, Cabaret_Club_.GetAllStaffLady());
        //(Staff頁面)更新View，一次修改Staff的StaffPage_Button
        MCS.VMS.V_M_Staff.SetStaffPage_Button(0);

        //切換狀態後，更新View的Position
        SetNowPosition();
    }

}//Model_Manage_Script
