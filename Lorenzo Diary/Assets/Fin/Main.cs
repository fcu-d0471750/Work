//主畫面
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class Main : MonoBehaviour {

	//*****************************************************************************
	public static int peoplesum;    //人員總數
	public static int weaponsum;    //武器總數
	public static int hospitalsum;  //醫療總數
	public static int foodsum;      //食物總數
	public static int moneysum;     //金錢總數
	public static int kmsum;        //里程總數
	public static int yesorno;      //是否已出航

	//資源訊息******************************************************************************
	public Text peoplesumtext = null;  //人員總數
	public Text weaponsumtext = null;  //武器總數
	public Text hospitalsumtext = null;//醫療總數
	public Text foodsumtext = null;    //食物總數
	public Text moneysumtext = null;   //金錢總數
	public Text kmsumtext = null;      //總出航公里
	public Text yesornotext = null;    //是否出航

	//**************************************************************************************
	public static int Apeople=0;   //房屋等級
	public static int Aweapon;     //武器等級
	public static int Ahospital;   //醫療等級
	public static int Afood;       //食物等級
	public static int Amoney;      //金錢等級

	//等級text***************************************************************************
	public Text peoplettext = null;  //房屋等級
	public Text weaponttext = null;  //武器等級
	public Text hospitalttext = null;//醫療等級
	public Text foodttext = null;    //食物等級
	public Text moneyttext = null;   //金錢等級

	//設定************************************************************************************
	public GameObject setbutton;       //宣告PlayButton物件
	public GameObject sbackbutton;
	public GameObject quitbutton;
	int syesno = 0;
	//宣告變數***********************************************************************************
	public static int Placetime ;  //地方時間
	float timef;                   //時間
	float FadeTime;                //貨物獲取淡出時間
	public static bool FadePlay=false; //貨物獲取淡出動畫是否播放
	public AudioSource ButtonMusic;//按扭音效
	public AudioSource ArcMusic;   //獲得成就音效


	//出航紀錄******************************************************************************************
	public static int P1=0;
	public static int P2=0;
	public static int P3=0;
	public static int P4=0;
	public static int P5=0;

	//成就解鎖動畫******************************************************************************************
	//public Text Actext = null;
	public GameObject AcAppear;  //成就解鎖動畫

	//淡出
	public GameObject AFadeout;  //建造淡出控制
	public GameObject BFadeout;  //商店淡出控制
	public GameObject AcFadeout; //成就淡出控制
	public GameObject StartFadeout; //開始淡出控制
	public GameObject QuFadeout;  //問題淡出控制
	public GameObject WarSelectFadeout;  //戰爭選項淡出控制
	public GameObject MusicSelectFadeout;//音樂選項淡出控制
	public GameObject ObtainAnimate;     
	public GameObject Fade;      //貨物獲取text淡出
	public Text FadeText = null; //貨物獲取text

	//===================================================================================================================================
	// Use this for initialization
	void Start () {
		sbackbutton.SetActive (false);
		quitbutton.SetActive (false);
		AcAppear.SetActive (false);

		//讀入========================================================================================================================
		peoplesum   = PlayerPrefs.GetInt("peoplesum1");  //讀入成就記錄(以下相同)
		weaponsum   = PlayerPrefs.GetInt("weaponsum1");  //讀入成就記錄(以下相同)
		hospitalsum =  PlayerPrefs.GetInt("hospitalsum1");//讀入成就記錄(以下相同)
		foodsum     =  PlayerPrefs.GetInt("foodsum1");    //讀入成就記錄(以下相同)
		moneysum    =  PlayerPrefs.GetInt("moneysum1");   //讀入成就記錄(以下相同)
		kmsum       =  PlayerPrefs.GetInt("kmsum1");      //讀入成就記錄(以下相同)
		yesorno     =  PlayerPrefs.GetInt("YESorNO");     //讀入成就記錄(以下相同)

		Apeople   = PlayerPrefs.GetInt("Apeoplesum");    //讀入成就記錄(以下相同)
		Aweapon   = PlayerPrefs.GetInt("Aweaponsum");    //讀入成就記錄(以下相同)
		Ahospital = PlayerPrefs.GetInt("Ahospitalsum");  //讀入成就記錄(以下相同)
		Afood     = PlayerPrefs.GetInt("Afoodsum");      //讀入成就記錄(以下相同)
		Amoney    = PlayerPrefs.GetInt("Amoneysum");     //讀入成就記錄(以下相同)

		P1 = PlayerPrefs.GetInt("P1"); //讀入成就記錄(以下相同)
		P2 = PlayerPrefs.GetInt("P2"); //讀入成就記錄(以下相同)
		P3 = PlayerPrefs.GetInt("P3"); //讀入成就記錄(以下相同)
		P4 = PlayerPrefs.GetInt("P4"); //讀入成就記錄(以下相同)
		P5 = PlayerPrefs.GetInt("P5"); //讀入成就記錄(以下相同)


		Acmain.Get[1] =  PlayerPrefs.GetInt("A1"); //讀入成就記錄(以下相同)
		Acmain.Get[2] =  PlayerPrefs.GetInt("A2"); //讀入成就記錄(以下相同)
		Acmain.Get[3] =  PlayerPrefs.GetInt("A3"); //讀入成就記錄(以下相同)
		Acmain.Get[4] =  PlayerPrefs.GetInt("A4"); //讀入成就記錄(以下相同)
		Acmain.Get[5] =  PlayerPrefs.GetInt("A5"); //讀入成就記錄(以下相同)
		Acmain.Get[6] =  PlayerPrefs.GetInt("A6"); //讀入成就記錄(以下相同)
		Acmain.Get[7] =  PlayerPrefs.GetInt("A7"); //讀入成就記錄(以下相同)
		Acmain.Get[8] =  PlayerPrefs.GetInt("A8"); //讀入成就記錄(以下相同)
		Acmain.Get[9] =  PlayerPrefs.GetInt("A9"); //讀入成就記錄(以下相同)
		Acmain.Get[10] =  PlayerPrefs.GetInt("A10"); //讀入成就記錄(以下相同)
		Acmain.Get[11] =  PlayerPrefs.GetInt("A11"); //讀入成就記錄(以下相同)
		Acmain.Get[12] =  PlayerPrefs.GetInt("A12"); //讀入成就記錄(以下相同)
		Acmain.Get[13] =  PlayerPrefs.GetInt("A13"); //讀入成就記錄(以下相同)
		Acmain.Get[14] =  PlayerPrefs.GetInt("A14"); //讀入成就記錄(以下相同)
		Acmain.Get[15] =  PlayerPrefs.GetInt("A15"); //讀入成就記錄(以下相同)
		Acmain.Get[16] =  PlayerPrefs.GetInt("A16"); //讀入成就記錄(以下相同)
		Acmain.Get[17] =  PlayerPrefs.GetInt("A17"); //讀入成就記錄(以下相同)
		Acmain.Get[18] =  PlayerPrefs.GetInt("A18"); //讀入成就記錄(以下相同)
		Acmain.Get[19] =  PlayerPrefs.GetInt("A19"); //讀入成就記錄(以下相同)
		Acmain.Get[20] =  PlayerPrefs.GetInt("A20"); //讀入成就記錄(以下相同)

		AFadeout.SetActive (false);
		BFadeout.SetActive (false);
		AcFadeout.SetActive (false);
		StartFadeout.SetActive (false);
		QuFadeout.SetActive (false);
		WarSelectFadeout.SetActive (false);
		MusicSelectFadeout.SetActive (false);
		ObtainAnimate.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//按鍵輸入*****************************************************
		//開啟設定
		if(Input.GetKeyDown("escape"))spush ();

		//切換到建造頁面
		if(Input.GetKeyDown(KeyCode.B))push ();
		
		//切換到商店頁面
		if(Input.GetKeyDown(KeyCode.S))Bpush ();
		
		//切換到成就頁面
		if(Input.GetKeyDown(KeyCode.A))ACpush ();

		//切換到文學頁面
		if(Input.GetKeyDown(KeyCode.L))QuestCpush();
			
		//切換到戰區頁面
		if(Input.GetKeyDown(KeyCode.W)) WarSelectpush();
			
		//切換到音樂廳選項頁面
		if(Input.GetKeyDown(KeyCode.M))MusicSelectpush();
			
		////貨物獲取淡出
		if(FadePlay)FadeTime+=Time.deltaTime; 
		if (FadePlay && FadeTime >= 3.8f) {
			Fade.SetActive (false);
			ObtainAnimate.SetActive (false);
			FadeText.text = "";
			FadePlay = false;
			FadeTime = 0.0f;
		}
		//建造加成****************************************************
		timef +=Time.deltaTime;   //記錄時間
		if (timef >= 1) //如果時間>=1 && Placetime[0]!=0 && 已按下按鈕 
		{
			//酒館
			if(Apeople==1)  peoplesum = peoplesum + 1;
			else if(Apeople==2) peoplesum = peoplesum + 2;
			else if(Apeople==3) peoplesum = peoplesum + 5;
			//鐵匠
			if(Aweapon==1)  weaponsum = weaponsum + 2;
			else if(Aweapon==2) weaponsum = weaponsum + 5;
			else if(Aweapon==3) weaponsum = weaponsum + 8;
			//醫院
			if(Ahospital==1)  hospitalsum = hospitalsum + 2;
			else if(Ahospital==2) hospitalsum = hospitalsum + 3;
			else if(Ahospital==3) hospitalsum = hospitalsum + 5;
			//農田
			if(Afood==1)  foodsum = foodsum + 5;
			else if(Afood==2) foodsum = foodsum + 10;
			else if(Afood==3) foodsum = foodsum + 15;
			//礦場
			if(Amoney==1)  moneysum = moneysum + 3;
			else if(Amoney==2) moneysum = moneysum + 5;
			else if(Amoney==3) moneysum = moneysum + 8;

			timef = 0;

		}	

		//等級=======================================================================================================================================
		peoplettext.text = "房屋LV." + Main.Apeople;
		weaponttext.text = "鐵匠鋪LV." + Main.Aweapon;
		hospitalttext.text = "醫院LV." + Main.Ahospital;
		foodttext.text = "農田LV." + Main.Afood;
		moneyttext.text = "礦場LV." + Main.Amoney;

		//訊息**************************************************************************************
		peoplesumtext.text = "" + peoplesum;
		weaponsumtext.text = "" + weaponsum;
		hospitalsumtext.text = "" + hospitalsum;
		foodsumtext.text = "" + foodsum;
		kmsumtext.text = "總航行里程(km):" + kmsum;
		moneysumtext.text = "" + moneysum;
		if(yesorno==1)yesornotext.text = "出航中";
		else yesornotext.text = "閒置中";

		//訊息顏色控制			
		//peoplesumtext.color += new Color(-0.01f,-0.01f,-0.01f);

		//成就解鎖************************************************************************************************************************************
		if(peoplesum >= 100000 && Acmain.Get[1]!=1) {
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}
		if(peoplesum >= 1000000 && Acmain.Get[2]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}	
		if(peoplesum >= 10000000 && Acmain.Get[3]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}

		//*************
		if(weaponsum >= 100000 && Acmain.Get[4]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}  
		if(weaponsum >= 1000000 && Acmain.Get[5]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		} 
		if(weaponsum >= 10000000 && Acmain.Get[6]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		} 

		//*************
		if(hospitalsum >= 100000 && Acmain.Get[7]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		} 
		if(hospitalsum >= 1000000 && Acmain.Get[8]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}
		if(hospitalsum >= 10000000 && Acmain.Get[9]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}

		//*************
		if(foodsum >= 100000 && Acmain.Get[10]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		} 
		if(foodsum >= 1000000 && Acmain.Get[11]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}
		if(foodsum >= 10000000 && Acmain.Get[12]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}

		//*************
		if(moneysum>=8888888 && Acmain.Get[13]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}
		if(kmsum>=100000 && Acmain.Get[14]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}

		//*************
		if(Apeople==3 && Acmain.Get[15]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}
		if(Aweapon==3 && Acmain.Get[16]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}
		if(Ahospital==3 && Acmain.Get[17]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}
		if(Afood==3 && Acmain.Get[18]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}
		if(Amoney==3 && Acmain.Get[19]!=1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}

		if (Acmain.Get [1] == 1 && Acmain.Get [2] == 1 && Acmain.Get [3] == 1 && Acmain.Get [4] == 1 && Acmain.Get [5] == 1 && Acmain.Get [6] == 1 && Acmain.Get [7] == 1 && Acmain.Get [8] == 1 && Acmain.Get [9] == 1 && Acmain.Get [10] == 1 && Acmain.Get [11] == 1 && Acmain.Get [12] == 1 && Acmain.Get [13] == 1 && Acmain.Get [14] == 1 && Acmain.Get [15] == 1 && Acmain.Get [16] == 1 && Acmain.Get [17] == 1 && Acmain.Get [18] == 1 && Acmain.Get [19] == 1 && Acmain.Get [20] != 1){
			AcAppear.SetActive (true);
			ArcMusic.Play ();
		}
			

		//紀錄========================================================================================================================================
		PlayerPrefs.SetInt("peoplesum1", peoplesum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("weaponsum1", weaponsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("hospitalsum1", hospitalsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("foodsum1", foodsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("moneysum1", moneysum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("kmsum1", kmsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("YESorNO", yesorno );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了

		PlayerPrefs.SetInt("Apeoplesum", Apeople );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Aweaponsum", Aweapon );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Ahospitalsum", Ahospital );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Afoodsum", Afood );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Amoneysum", Amoney );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

		PlayerPrefs.SetInt("P1", P1 );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("P2", P2 );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("P3", P3 );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("P4", P4 );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("P5", P5 );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

		PlayerPrefs.SetInt("A1", Acmain.Get[1] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A2", Acmain.Get[2] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A3", Acmain.Get[3] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A4", Acmain.Get[4] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A5", Acmain.Get[5] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A6", Acmain.Get[6] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A7", Acmain.Get[7] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A8", Acmain.Get[8] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A9", Acmain.Get[9] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A10", Acmain.Get[10] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A11", Acmain.Get[11] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A12", Acmain.Get[12] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A13", Acmain.Get[13] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A14", Acmain.Get[14] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A15", Acmain.Get[15] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A16", Acmain.Get[16] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A17", Acmain.Get[17] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A18", Acmain.Get[18] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A19", Acmain.Get[19] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A20", Acmain.Get[20] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

	}



	//切換場景*******************************************************************
	public void push()//建造
	{
		ButtonMusic.Play ();
		AFadeout.SetActive (true);
		//Application.LoadLevelAsync ("Ascene");

	}

	public void Bpush()//商店
	{
		ButtonMusic.Play ();
		BFadeout.SetActive (true);
		//已按下
		//Application.LoadLevelAsync ("Bscene");

	}

	public void ACpush()//成就
	{
		ButtonMusic.Play ();
		AcFadeout.SetActive (true);
		//已按下
		//Application.LoadLevelAsync ("Acscene");

	}

	public void QuestCpush()//問題
	{
		ButtonMusic.Play ();
		QuFadeout.SetActive (true);
		//已按下
		//Application.LoadLevelAsync ("startscreen");

	}

	public void WarSelectpush()//戰爭選項
	{
		ButtonMusic.Play ();
		WarSelectFadeout.SetActive (true);
		//已按下
		//Application.LoadLevelAsync ("startscreen");

	}

	public void MusicSelectpush()//音樂廳選項
	{
		ButtonMusic.Play ();
		MusicSelectFadeout.SetActive (true);
		//已按下
		//Application.LoadLevelAsync ("startscreen");

	}

	//返回***************************************************************************
	public void back()
	{
		ButtonMusic.Play();

		//已按下
		Application.LoadLevelAsync ("Main");
	}


	//設定功能*********************************************************************************
	public void spush()
	{
		//已按下

		if (syesno == 1) {
			ButtonMusic.Play();
			sbackbutton.SetActive (false);
			quitbutton.SetActive (false);
			//隱藏地方內容
			syesno = 0; //false: 未按下
		
		} 

		//未按下
		else {
			ButtonMusic.Play();
			sbackbutton.SetActive (true);
			quitbutton.SetActive (true);
			//顯示地方內容
			syesno = 1; //true: 已按下
		}
	}

	//主選單
	public void sback()
	{
		ButtonMusic.Play ();
		StartFadeout.SetActive (true);
		//Application.LoadLevelAsync ("START");
	}
	//離開遊戲
	public void quit()
	{
		ButtonMusic.Play ();
		DateTime Now  = DateTime.Now;  //這次遊完時間
		TimeCount.Lasttime [1] = Now.Year;
		TimeCount.Lasttime [2] = Now.Month;
		TimeCount.Lasttime [3] = Now.Day;
		TimeCount.Lasttime [4] = Now.Hour;
		TimeCount.Lasttime [5] = Now.Minute;
		TimeCount.Lasttime [6] = Now.Second;

		PlayerPrefs.SetInt("Lasttime1", TimeCount.Lasttime[1] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Lasttime2", TimeCount.Lasttime[2] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Lasttime3", TimeCount.Lasttime[3] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Lasttime4", TimeCount.Lasttime[4] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Lasttime5", TimeCount.Lasttime[5] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Lasttime6", TimeCount.Lasttime[6] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

		Application.Quit();//離開遊戲 
	}
	



}
