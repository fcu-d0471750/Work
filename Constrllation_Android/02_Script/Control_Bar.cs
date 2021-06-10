//上方控制條 下方控制條
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Control_Bar : MonoBehaviour {

	//宣告變數**********************************************************
	//int**************************
	//現在狀態
	public static int Now_Page = 0;
	/*
		1:Home_Page
		2:Set_Constellations_Page
		
		3:Constellations_Page
		4:Constellations_Description_Page
		
		5:Classification_Page
		6:Classification_Description_1_Page
		7:Classification_Description_2_Page
		8:Classification_Description_3_Page
		
		9:Palace_Page
		10:Palace_Description_Page
		
		11:Planet_Page
		12:Planet_Description_Page

        13:Quit_Page
	*/

	//bool*************************
	//切換頁面 true:切換畫面 false:不切換畫面
	public static bool Change_Page_Bool = false;


	//宣告UI************************************************************
	//GameObject*******************
	//Home頁面
	public GameObject Home_Page;
	//Set_Constellations頁面
	public GameObject Set_Constellations_Page;

	//Constellations頁面
	public GameObject Constellations_Page;
	//Constellations_Description頁面
	public GameObject Constellations_Description_Page;

	//Classification頁面
	public GameObject Classification_Page;
	//Classification_Description1頁面
	public GameObject Classification_Description_1_Page;
	//Classification_Description2頁面
	public GameObject Classification_Description_2_Page;
	//Classification_Description3頁面
	public GameObject Classification_Description_3_Page;

	//Palace頁面
	public GameObject Palace_Page;
	//Palace_Description頁面
	public GameObject Palace_Description_Page;

	//Planet頁面
	public GameObject Planet_Page;
	//Planet_Description頁面
	public GameObject Planet_Description_Page;


    //Quit頁面
    public GameObject Quit_Page;

    //Button***********************
    //返回按鈕
    public Button Hide_Button;
	//HomePage頁面按鈕
	public Button HomePage_Button;
    //Set_Constellations頁面按鈕
    public Button Set_Constellations_Button;
    //ConstellationsPage頁面按鈕
    public Button ConstellationsPage_Button;
	//ClassificationPage頁面按鈕
	public Button ClassificationPage_Button;
	//PalacePage頁面按鈕
	public Button PalacePage_Button;
	//PlanetPage頁面按鈕
	public Button PlanetPage_Button;
   

    //Text*************************
    //頁面名稱
    public Text TopBar_Text;

	//Image************************
    public static bool  Check_Bool = false;

    //用於Android返回頁面功能
    public Constellations_Page Android_Constellations;
    public Classification_Page Android_Classification;
    public Palace_Page Android_Palace;
    public Planet_Page Android_Planet;

    //============================================
    // Use this for 
    //============================================
    void Start () {
		//初始化完成前不能使用按鈕
		Set_ALL_Page_Button_False ();
	}

    //============================================
    // Update is called once per frame
    //============================================
    void Update () {
        if(Check_Bool == true)
        {
			//初始化
			Change_Page (1);
            
			//DataManage.Use_Data_Bool = false;
            Check_Bool = false; 

        }

        //============================================
        //按下設定誕生年月日按鈕
        //============================================
        if (Change_Page_Bool == true) {
			//Set_Constellations頁面隱藏
			Hide_Page_Button ();
			//防止重複隱藏
			Change_Page_Bool = false;
		}

        //============================================
        //(Android手機使用)按下Android返回鍵
        //============================================
        if (Input.GetKeyDown(KeyCode.Escape)){
            
            //如果是5大主頁面，則跳出離開APP的頁面
            //離開頁面
            if (Now_Page == 1 || Now_Page == 3 || Now_Page == 5 || Now_Page == 9 || Now_Page == 11)
            {
                Quit_Page.SetActive(true);
            }
            //如果是小頁面，則返回主畫面
            else
            {
                //返回頁面
                Hide_Page_Button();
                Android_Constellations.Set_Constellation_Button();
                Android_Classification.Set_Classification_Button();
                Android_Palace.Set_Palace_Button();
                Android_Planet.Set_Planet_Button();
            }
        }//if (Input.GetKeyDown(KeyCode.Escape))

    }//Update () 

    //============================================
    //副程式(按鈕):離開功能
    //============================================
    public void Set_Quit(bool Quit_Stay_Bool)
    {
        //結束程式
        if (Quit_Stay_Bool == true)
        {
            Application.Quit();
        }
        else
        {
            Quit_Page.SetActive(false);
        }
    }

    //============================================
    //副程式(按鈕):返回頁面
    //============================================
    public void Hide_Page_Button(){
		switch (Now_Page) {
		//Set_Constellations頁面
		case 2:{
				//Set_Constellations頁面隱藏
				Set_Constellations_Page.SetActive(false);
				//將Hide_Button按鈕設為不可用
				Hide_Button.interactable = false;
				//現在頁面為: 1
				Change_Page(1);
				break;
			}
		//Constellations_Description頁面
		case 4:{
				//Constellations_Description頁面隱藏
				Constellations_Description_Page.SetActive(false);
				//將Hide_Button按鈕設為不可用
				Hide_Button.interactable = false;
				//現在頁面為: 3
				Change_Page(3);
				break;
			}
		//Classification_Description1頁面
		case 6:{
				//Classification_Description_1_Page頁面隱藏
				Classification_Description_1_Page.SetActive(false);
				//將Hide_Button按鈕設為不可用
				Hide_Button.interactable = false;
				//現在頁面為: 5
				Change_Page(5);
				break;
			}
		//Classification_Description2頁面
		case 7:{
				//Classification_Description_2_Page頁面隱藏
				Classification_Description_2_Page.SetActive(false);
				//將Hide_Button按鈕設為不可用
				Hide_Button.interactable = false;
				//現在頁面為: 5
				Change_Page(5);
				break;
			}
		//Classification_Description3頁面
		case 8:{
				//Classification_Description_3_Page頁面隱藏
				Classification_Description_3_Page.SetActive(false);
				//將Hide_Button按鈕設為不可用
				Hide_Button.interactable = false;
				//現在頁面為: 5
				Change_Page(5);
				break;
			}
		//Palace_Description頁面
		case 10:{
				//Palace_Description_Page頁面隱藏
				Palace_Description_Page.SetActive(false);
				//將Hide_Button按鈕設為不可用
				Hide_Button.interactable = false;
				//現在頁面為: 9
				Change_Page(9);
				break;
			}
		//Planet_Description頁面
		case 12:{
				//Planet_Description_Page頁面隱藏
				Planet_Description_Page.SetActive(false);
				//將Hide_Button按鈕設為不可用
				Hide_Button.interactable = false;
				//現在頁面為: 11
				Change_Page(11);
				break;
			}
		}//switch
	}

    //============================================
    //副程式(按鈕):切換頁面
    //============================================
    public void Change_Page(int Page_Number){
		//將所有頁面設為不可用，下面switch會設定可用
		Set_ALL_Page_False();

		//將所有頁面按鈕設為可用，下面switch會設定不可用
		Set_ALL_Page_Button_True();
        //print("Change Page");
		switch (Page_Number) {
		//Home頁面
		case 1:
			{
				//現在頁面為: 1
				Set_Now_Page (1);
				//顯示HomePage
				Home_Page.SetActive (true);
				//將HomePage按鈕設為不可用
				HomePage_Button.interactable = false;
				//上方頁面名稱改為 我的星座
				TopBar_Text.text = "我的星座";
				break;
			}
		//Set_Constellations_Page頁面
		case 2:
			{
				//現在頁面為: 2
				Set_Now_Page (2);
				//顯示HomePage
				Home_Page.SetActive (true);
				//顯示Set_Constellations_Page
				Set_Constellations_Page.SetActive (true);
				//將Hide_Button按鈕設為可用
				Hide_Button.interactable = true;
				//其它頁面按鈕設為不可用
				HomePage_Button.interactable = false;
				ConstellationsPage_Button.interactable = false;
				ClassificationPage_Button.interactable = false;
				PalacePage_Button.interactable = false;
				PlanetPage_Button.interactable = false;
				//上方頁面名稱改為 我的星座
				TopBar_Text.text = "設定誕生年月日";
				break;
			}
		//Constellations頁面
		case 3:
			{
				//現在頁面為: 3
				Set_Now_Page (3);
				//顯示Constellations_Page
				Constellations_Page.SetActive (true);
				//將ConstellationsPage按鈕設為不可用
				ConstellationsPage_Button.interactable = false;
				//上方頁面名稱改為 星座簡介
				TopBar_Text.text = "星座簡介";
				break;
			}
		//Constellations_Description_Page頁面
		case 4:
			{
				//現在頁面為: 4
				Set_Now_Page (4);
				//顯示Constellations_Page
				Constellations_Page.SetActive (true);
				//顯示Constellations_Description_Page
				Constellations_Description_Page.SetActive (true);
				//將Hide_Button按鈕設為可用
				Hide_Button.interactable = true;
				//其它頁面按鈕設為不可用
				HomePage_Button.interactable = false;
				ConstellationsPage_Button.interactable = false;
				ClassificationPage_Button.interactable = false;
				PalacePage_Button.interactable = false;
				PlanetPage_Button.interactable = false;
				//上方頁面名稱改為 我的星座
				TopBar_Text.text = "星座簡介描述";
			
				break;
			}
		//Classification_Page頁面
		case 5:
			{
				//現在頁面為: 5
				Set_Now_Page (5);
				//顯示Constellations_Page
				Classification_Page.SetActive (true);
				//將ClassificationPage_Button按鈕設為不可用
				ClassificationPage_Button.interactable = false;
				//上方頁面名稱改為 星座分類
				TopBar_Text.text = "星座分類";
				break;
			}
		//Classification_Description_1_Page頁面
		case 6:
			{
				//現在頁面為: 6
				Set_Now_Page (6);
				//顯示Constellations_Page
				Classification_Page.SetActive (true);
				//顯示Classification_Description_1_Page
				Classification_Description_1_Page.SetActive (true);
				//將Hide_Button按鈕設為可用
				Hide_Button.interactable = true;
				//其它頁面按鈕設為不可用
				HomePage_Button.interactable = false;
				ConstellationsPage_Button.interactable = false;
				ClassificationPage_Button.interactable = false;
				PalacePage_Button.interactable = false;
				PlanetPage_Button.interactable = false;
				//上方頁面名稱改為 我的星座
				TopBar_Text.text = "陰陽法";
				break;
			}
		//Classification_Description_2_Page頁面
		case 7:
			{
				//現在頁面為: 7
				Set_Now_Page (7);
				//顯示Constellations_Page
				Classification_Page.SetActive (true);
				//顯示Classification_Description_2_Page
				Classification_Description_2_Page.SetActive (true);
				//將Hide_Button按鈕設為可用
				Hide_Button.interactable = true;
				//其它頁面按鈕設為不可用
				HomePage_Button.interactable = false;
				ConstellationsPage_Button.interactable = false;
				ClassificationPage_Button.interactable = false;
				PalacePage_Button.interactable = false;
				PlanetPage_Button.interactable = false;
				//上方頁面名稱改為 我的星座
				TopBar_Text.text = "三分法";
				break;
			}
		//Classification_Description_3_Page頁面
		case 8:
			{
				//現在頁面為: 8
				Set_Now_Page (8);
				//顯示Constellations_Page
				Classification_Page.SetActive (true);
				//顯示Classification_Description_3_Page
				Classification_Description_3_Page.SetActive (true);
				//將Hide_Button按鈕設為可用
				Hide_Button.interactable = true;
				//其它頁面按鈕設為不可用
				HomePage_Button.interactable = false;
				ConstellationsPage_Button.interactable = false;
				ClassificationPage_Button.interactable = false;
				PalacePage_Button.interactable = false;
				PlanetPage_Button.interactable = false;
				//上方頁面名稱改為 我的星座
				TopBar_Text.text = "四象法";
				break;
			}
		//PalacePage頁面
		case 9:
			{
				//現在頁面為: 9
				Set_Now_Page (9);
				//顯示Palace_Page
				Palace_Page.SetActive (true);
				//將PalacePage_Button按鈕設為不可用
				PalacePage_Button.interactable = false;
				//上方頁面名稱改為 宮位
				TopBar_Text.text = "宮位";
				break;
			}
		//Palace_Description_Page頁面
		case 10:
			{
				//現在頁面為: 10
				Set_Now_Page (10);
				//顯示Palace_Page
				Palace_Page.SetActive (true);
				//顯示Palace_Description_Page
				Palace_Description_Page.SetActive (true);
				//將Hide_Button按鈕設為可用
				Hide_Button.interactable = true;
				//其它頁面按鈕設為不可用
				HomePage_Button.interactable = false;
				ConstellationsPage_Button.interactable = false;
				ClassificationPage_Button.interactable = false;
				PalacePage_Button.interactable = false;
				PlanetPage_Button.interactable = false;
				//上方頁面名稱改為 我的星座
				TopBar_Text.text = "宮位描述";
				break;
			}
		//Planet_Page頁面
		case 11:
			{
				//現在頁面為: 11
				Set_Now_Page (11);
				//顯示Planet_Page
				Planet_Page.SetActive (true);
				//將PalacePage_Button按鈕設為不可用
				PlanetPage_Button.interactable = false;
				//上方頁面名稱改為 太陽行星
				TopBar_Text.text = "太陽行星";
				break;
			}
		//Planet_Description_Page頁面
		case 12:
			{
				//現在頁面為: 12
				Set_Now_Page (12);
				//顯示Planet_Page
				Planet_Page.SetActive (true);
				//顯示Palace_Description_Page
				Planet_Description_Page.SetActive (true);
				//將Hide_Button按鈕設為可用
				Hide_Button.interactable = true;
				//其它頁面按鈕設為不可用
				HomePage_Button.interactable = false;
				ConstellationsPage_Button.interactable = false;
				ClassificationPage_Button.interactable = false;
				PalacePage_Button.interactable = false;
				PlanetPage_Button.interactable = false;
				//上方頁面名稱改為 我的星座
				TopBar_Text.text = "太陽行星描述";
				break;
			}
		}//switch
	}

    //============================================
    //副程式:設定現在頁面編號(這樣其它Script也可以改變頁面編號)
    //============================================
    public static void Set_Now_Page(int Page_Number){
		Now_Page = Page_Number;
	}

    //============================================
    //副程式:將所有頁面設為不可用
    //============================================
    void Set_ALL_Page_False(){
		//Home頁面
		Home_Page.SetActive(false);
		//Set_Constellations頁面
		Set_Constellations_Page.SetActive(false);

		//Constellations頁面
		Constellations_Page.SetActive(false);
		//Constellations_Description頁面
		Constellations_Description_Page.SetActive(false);

		//Classification頁面
		Classification_Page.SetActive(false);
		//Classification_Description1頁面
		Classification_Description_1_Page.SetActive(false);
		//Classification_Description2頁面
		Classification_Description_2_Page.SetActive(false);
		//Classification_Description3頁面
		Classification_Description_3_Page.SetActive(false);

		//Palace頁面
		Palace_Page.SetActive(false);
		//Palace_Description頁面
		Palace_Description_Page.SetActive(false);

		//Planet頁面
		Planet_Page.SetActive(false);
		//Planet_Description頁面
		Planet_Description_Page.SetActive(false);
	}

    //============================================
    //副程式:將所有頁面按鈕設為可用
    //============================================
    void Set_ALL_Page_Button_True(){
		HomePage_Button.interactable = true;
        Set_Constellations_Button.interactable = true;
        ConstellationsPage_Button.interactable = true;
		ClassificationPage_Button.interactable = true;
		PalacePage_Button.interactable = true;
		PlanetPage_Button.interactable = true;
		Hide_Button.interactable = false;
	}

    //============================================
    //副程式:將所有頁面按鈕設為不可用
    //============================================
    void Set_ALL_Page_Button_False(){
		HomePage_Button.interactable = false;
        Set_Constellations_Button.interactable = false;
        ConstellationsPage_Button.interactable = false;
		ClassificationPage_Button.interactable = false;
		PalacePage_Button.interactable = false;
		PlanetPage_Button.interactable = false;
		Hide_Button.interactable = false;
	}


   

}//Control Bar
