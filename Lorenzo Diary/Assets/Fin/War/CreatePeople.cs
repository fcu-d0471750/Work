//城門創立我方
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class CreatePeople : MonoBehaviour {

	//宣告變數===================================================================
	public GameObject Holger;  // 宣告一個物件叫Holger
	public GameObject Yuko;    // 宣告一個物件叫Yuko
	public GameObject Yuji;    // 宣告一個物件叫Yuji
	public GameObject Archer1; // 宣告一個物件叫Archer1
	public GameObject Archer2; // 宣告一個物件叫Archer2
	public GameObject Archer3; // 宣告一個物件叫Archer3
	public GameObject Cindy;   // 宣告一個物件叫Cindy
	public GameObject Misaki;  // 宣告一個物件叫Misaki
	public GameObject Toko;    // 宣告一個物件叫Toko
	//派遣士兵*****************************************************
	public Button Holgerbutton;  // 宣告一個按鈕叫Holger
	public Button Yukobutton;    // 宣告一個按鈕叫Yuko
	public Button Yujibutton;    // 宣告一個按鈕叫Yuji
	public Button Archer1button; // 宣告一個按鈕叫Archer1
	public Button Archer2button; // 宣告一個按鈕叫Archer2
	public Button Archer3button; // 宣告一個按鈕叫Archer3
	public Button Cindybutton;   // 宣告一個按鈕叫Cindy
	public Button Misakibutton;  // 宣告一個按鈕叫Misaki
	public Button Tokobutton;    // 宣告一個按鈕叫Toko
	//角色音效***********************************************************
	public AudioSource BackMusic; //背景音效
	public AudioSource GOMusicM1; //男出擊音效1
	public AudioSource GOMusicM2; //男出擊音效2
	public AudioSource GOMusicM3; //男出擊音效3
	public AudioSource GOMusicM4; //男出擊音效4
	public AudioSource GOMusicM5; //男出擊音效5
	public AudioSource GOMusicF1; //女出擊音效1
	public AudioSource GOMusicF2; //女出擊音效2
	public AudioSource GOMusicF3; //女出擊音效3
	public AudioSource GOMusicF4; //女出擊音效4
	public AudioSource ButtonMusic; //按鍵音效

	//介面***********************************************************
	float time;
	public float Energy=0.0f;      //能量
	public Image EnergyBar;        //能量條
	public Text EnergyText;        //能量Text 
	public Text DoorText;          //DoorText 
	public static int Live=10;     //城門生命值
	public GameObject Rain;        //雨天效果
	public GameObject BackGround1; //場景1
	public GameObject BackGround2; //場景2
	public GameObject BackGround3; //場景3
	public GameObject SoliderPart; //士兵生成粒子效果
	float  Energy_Outline_Time = 0.0f;  	   //能量條外框變化時間
	bool   Energy_Outline_Bool = true;		   //能量條外框變化是否變化 true:變化 false:不變化	
	public Outline   Energy_Outline;           //能量條外框

	//士兵生成等待*******************************************************
	public Image WaitBarHolger;  //Holger生成等待條
	float  Holgerwaittime=0.0f;  //Holger生成等待時間
	bool   Holgerwait=true;      //Holger是否等待 true:可生成 false:等待
	public Image WaitBarYuko;    //Yuko生成等待條
	float  Yukowaittime=0.0f;    //Yuko生成等待時間
	bool   Yukowait=true;        //Yuko是否等待 true:可生成 false:等待
	public Image WaitBarYuji;    //Yuji生成等待條
	float  Yujiwaittime=0.0f;    //Yuji生成等待時間
	bool   Yujiwait=true;        //Yuji是否等待 true:可生成 false:等待
	public Image WaitBarArcher1; //Archer1生成等待條
	float  Archer1waittime=0.0f; //Archer1生成等待時間
	bool   Archer1wait=true;     //Archer1是否等待 true:可生成 false:等待
	public Image WaitBarArcher2; //Archer2生成等待條
	float  Archer2waittime=0.0f; //Archer2生成等待時間
	bool   Archer2wait=true;     //Archer2是否等待 true:可生成 false:等待
	public Image WaitBarArcher3; //Archer3生成等待條
	float  Archer3waittime=0.0f; //Archer3生成等待時間
	bool   Archer3wait=true;     //Archer3是否等待 true:可生成 false:等待
	public Image WaitBarCindy;   //Cindy生成等待條
	float  Cindywaittime=0.0f;   //Cindy生成等待時間
	bool   Cindywait=true;       //Cindy是否等待 true:可生成 false:等待
	public Image WaitBarMisaki;  //Misaki生成等待條
	float  Misakiwaittime=0.0f;  //Misaki生成等待時間
	bool   Misakiwait=true;      //Misaki是否等待 true:可生成 false:等待
	public Image WaitBarToko;    //Toko生成等待條
	float  Tokowaittime=0.0f;    //Toko生成等待時間
	bool   Tokowait=true;        //Toko是否等待 true:可生成 false:等待

	//戰爭開始變數*********************************************
	public GameObject WarStarButton;     //戰爭開始button
	public GameObject BeginAnimateP;     //戰爭開始動畫Port
	public GameObject BeginAnimateV;     //戰爭開始動畫Viseu
	public GameObject BeginAnimateB;     //戰爭開始動畫Beja
	public Text       BeginTextP;        //戰爭開始動畫TextPort
	public Text       BeginTextV;        //戰爭開始動畫TextViseu
	public Text       BeginTextB;        //戰爭開始動畫TextBeja 
	public static bool WarStart = false; //戰爭是否開始 true:開始 false:未開始
	public static bool WarPause = false; //戰爭暫停  true:暫停 false:未暫停
	public GameObject  WarPauseButton;   //戰爭中途結束Button
	public GameObject WarPersonImage;    //戰爭人圖
	public Animation  WarConversationAni;//戰爭對話框動畫
	public Text       WarConversationText;//戰爭對話框
	float  WarConversationtime;           //戰爭對話框時間   
	int    DoorMaxLive;                   //城門最大生命值(用於技能:修補城門)
	float  infiniteAddTime = 0.0f;        //無限關卡年份增加時間
	int    infiniteYear = 1;              //無限關卡年份
	public Text       infiniteText;       //無限關卡年份Text
	//戰爭結束變數*********************************************
	public GameObject WarWinBack; //戰爭勝利結算板
	public GameObject WarLoseBack;//戰爭失敗結算板
	public GameObject WarWinButton;//戰爭WinButton
	public GameObject WarLoseButton;//戰爭LoseButton
	public GameObject FadeOut;   //淡出
	public Text WarBackText1;    //WarBackText1
	public Text WarBackText2;    //WarBackText2
	public Text WarLoseBackText1;//WarLoseBackText1
	public Text WarLoseBackText2;//WarLoseBackText2
	public AudioSource WinMusic; //勝利音樂
	public AudioSource LoseMusic;//失敗音樂
	public AudioSource InfiniteMusic; //無限關卡音樂

	int  weapon;                 //獲得或失去的資源數量
	int  hospital;               //獲得或失去的資源數量
	int  food;                   //獲得或失去的資源數量
	int  money;                  //獲得或失去的資源數量
	public static bool WarisOver = false;   //戰爭是否結束 true:結束 false:沒結束
	float timef;                 //船出航倒數時間
	public static float timeEnd = 3.0f;        //戰爭結束倒數時間
	public Animation    EndAnimationP;         //戰爭結束動畫(失敗)
	public Animation    EndAnimationE;         //戰爭結束動畫(勝利)
	public AudioSource  EndMusic;              //戰爭結束音效
	float ObtainTimeEnd;                       //獲得資源倒數時間
	public Animation Conversation;             //戰爭結束人物框 
	public Text ConsersationText;              //戰爭結束人物對話框
	public Animation SaveImage;                //儲存中動畫


	// Use this for initialization
	void Start () {
		//初始化
		Energy=50.0f;
		WarWinBack.SetActive(false);
		WarLoseBack.SetActive(false);
		WarWinButton.SetActive(false);
		WarLoseButton.SetActive(false);
		BeginAnimateP.SetActive (false);
		BeginAnimateV.SetActive (false);
		BeginAnimateB.SetActive (false);
		FadeOut.SetActive(false);
		WarPauseButton.SetActive(false);
		Rain.SetActive(false);
		EndMusic.enabled = false;
		EndAnimationE.Stop ();
		EndAnimationP.Stop ();
		timef = 0.0f;
		timeEnd = 3.0f;
		ObtainTimeEnd = 0.0f;
		WarConversationtime = 0.0f;
		WarisOver = false; 
		WarPause = false;
		WinMusic.Play ();
		LoseMusic.Play ();
		InfiniteMusic.Play ();
		WinMusic.Pause ();
		LoseMusic.Pause ();
		InfiniteMusic.Pause ();
		DoorText.text = "" + Live;
		DoorMaxLive = Live;
		infiniteAddTime = 0.0f;
		infiniteYear = 0;

		//設立場景
		BackGround1.SetActive(false);
		BackGround2.SetActive(false);
		BackGround3.SetActive(false);
		if(WarSelect.infiniteStart)BackGround3.SetActive(true);
		else if(WarSelect.WarLevel>=1 && WarSelect.WarLevel<=4) BackGround1.SetActive(true);
		else if(WarSelect.WarLevel>=5 && WarSelect.WarLevel<=8)BackGround2.SetActive(true);
		else  BackGround3.SetActive(true);

		//控制音樂
		if (Musicbotton.musicplay)BackMusic.Play ();
		else BackMusic.Pause ();
		BackMusic.volume = Musicbotton.MusicVo;

		Holgerbutton.interactable = false;
		Yukobutton.interactable = false;
		Yujibutton.interactable = false;
		Archer1button.interactable = false;
		Archer2button.interactable = false;
		Archer3button.interactable = false;
		Cindybutton.interactable = false;
		Misakibutton.interactable = false;
		Tokobutton.interactable = false;

		Main.weaponsum   =  PlayerPrefs.GetInt("weaponsum1");   //讀入成就記錄(以下相同)
		Main.hospitalsum =  PlayerPrefs.GetInt("hospitalsum1"); //讀入成就記錄(以下相同)
		Main.foodsum     =  PlayerPrefs.GetInt("foodsum1");     //讀入成就記錄(以下相同)
		Main.moneysum    =  PlayerPrefs.GetInt("moneysum1");    //讀入成就記錄(以下相同)

		Placeyesno.Placetime =  PlayerPrefs.GetInt("Placetime1");  //讀入成就記錄(以下相同)
		Placeyesno2.Placetime =  PlayerPrefs.GetInt("Placetime2"); //讀入成就記錄(以下相同)
		Placeyesno3.Placetime =  PlayerPrefs.GetInt("Placetime3"); //讀入成就記錄(以下相同)
		Placeyesno4.Placetime =  PlayerPrefs.GetInt("Placetime4"); //讀入成就記錄(以下相同)
		Placeyesno5.Placetime =  PlayerPrefs.GetInt("Placetime5"); //讀入成就記錄(以下相同)

	}
	
	// Update is called once per frame
	void Update () {
		//如果船已經出航******************************************************************************************************************
		timef +=Time.deltaTime;   //記錄時間
		if (timef >= 1) { //如果時間>=1 && Placetime[0]!=0 && 已按下按鈕 
			if(Placeyesno.Placetime!=30 && Placeyesno.Placetime!=0) Placeyesno.Placetime--;
			if(Placeyesno2.Placetime!=60 && Placeyesno2.Placetime!=0) Placeyesno2.Placetime--;
			if(Placeyesno3.Placetime!=80 && Placeyesno3.Placetime!=0) Placeyesno3.Placetime--;
			if(Placeyesno4.Placetime!=100 && Placeyesno4.Placetime!=0) Placeyesno4.Placetime--;
			if(Placeyesno5.Placetime!=120 && Placeyesno5.Placetime!=0) Placeyesno5.Placetime--;
			timef = 0;
		}

	  //戰爭暫停*************************************************************************************************
		if(Input.GetKeyDown("escape") && WarStart && !WarisOver){
			if (WarPause) {
				WarPause = false;
				WarPauseButton.SetActive (false);
			} else {
				WarPause = true;
				WarPauseButton.SetActive(true);
			}
		} 


		//生成人物(鍵盤)
		if(Input.GetKeyDown(KeyCode.Alpha1) && WarStart && !WarisOver && Holgerwait && !WarPause) CR_Holger ();
		if(Input.GetKeyDown(KeyCode.Alpha2) && WarStart && !WarisOver && Yukowait && !WarPause) CR_Yuko ();
		if(Input.GetKeyDown(KeyCode.Alpha3) && WarStart && !WarisOver && Yujiwait && !WarPause && Main.Apeople>=1) CR_Yuji ();
		if(Input.GetKeyDown(KeyCode.Alpha4) && WarStart && !WarisOver && Archer1wait && !WarPause && Main.Aweapon>=1) CR_Archer1 ();
		if(Input.GetKeyDown(KeyCode.Alpha5) && WarStart && !WarisOver && Archer2wait && !WarPause && Main.Aweapon>=2) CR_Archer2 ();
		if(Input.GetKeyDown(KeyCode.Alpha6) && WarStart && !WarisOver && Archer3wait && !WarPause && Main.Aweapon>=3) CR_Archer3 ();
		if(Input.GetKeyDown(KeyCode.Alpha7) && WarStart && !WarisOver && Cindywait && !WarPause && Main.Apeople>=2) CR_Cindy ();
		if(Input.GetKeyDown(KeyCode.Alpha8) && WarStart && !WarisOver && Misakiwait && !WarPause && Main.Apeople>=3) CR_Misaki ();
		if(Input.GetKeyDown(KeyCode.Alpha9) && WarStart && !WarisOver && Tokowait && !WarPause && Main.Apeople>=3 && Main.Aweapon>=3) CR_Toko ();
		
	  //戰爭開始*************************************************************************************************
	  if(WarStart){
		WarStarButton.SetActive(false); //隱藏開始按鈕
		

		time += Time.deltaTime;         //能量增加
		//戰爭結束動畫(勝利)	 
		if(CreateEnemy.Live<=0 && !WarisOver && time>=0.1f && timeEnd>=0.0f){ 
			timeEnd = timeEnd - 0.1f;
			EndMusic.enabled = true;
			EndAnimationE.Play ();
			BackMusic.Pause ();
		}             
		//戰爭結束動畫(失敗)	 
		else if(CreatePeople.Live<=0 && !WarisOver && time>=0.1f && timeEnd>=0.0f) { 
			timeEnd = timeEnd - 0.1f; 
			EndMusic.enabled = true;
			EndAnimationP.Play ();
			BackMusic.Pause ();
		}        

		//無限關卡*************************************************************************************************************
			if (WarSelect.infiniteStart) {
				infiniteAddTime += Time.deltaTime;  //時間增加
				infiniteText.text = "已經過 " + CreateEnemy.infiniteStartLevel + " 年";
				if (infiniteAddTime >= 35.0f) {
					CreateEnemy.infiniteStartLevel = CreateEnemy.infiniteStartLevel + 1;
					WarSelect.WarLevel = WarSelect.WarLevel + 1;
					if (WarSelect.WarLevel >= 20)
						WarSelect.WarLevel = 20;
					infiniteAddTime = 0.0f;
				}
			}
		//戰爭對話框*************************************************************************************************************
			WarConversationtime += Time.deltaTime;         //時間增加
			if (WarConversationtime >= 10.0f) {
				WarConversation ();
				WarConversationAni.Play ();
				WarConversationtime = 0.0f;
			}
		//能量條******************************************************************************************************************
		if(time>=0.2f && Energy<500 && !WarPause && !WarisOver){Energy++; time=0.0f; }
		EnergyBar.fillAmount = Energy/500.0f;       //進度圖變化
		EnergyText.text = "" + (int)Energy + "/500";

			Energy_Outline_Time += Time.deltaTime;         //時間增加
			if (Energy_Outline_Time >= 5.0f) {
				Energy_Outline_Time = 0.0f;
				Energy_Outline_Bool = !Energy_Outline_Bool;
			}
			if (Energy_Outline_Bool==true) {
				//print ("A::::");
				Energy_Outline.effectColor =  new Color32 (255, 132, 0, (byte)(Energy_Outline_Time*51.0f));
			} else {
				//print ("B::::");
				Energy_Outline.effectColor =  new Color32 (255, 132, 0, (byte)(255-(Energy_Outline_Time*51.0f)));

			}

		//回復能量條技能釋放********************************************************************************************************
			if(Skill.AddEnergyAction){
				if (Energy < 400.0f)          //如果現在能量 < 400，則 現在能量 = 現在能量 + (100 + (10*(鐵匠鋪現在等級 + 礦場現在等級)) )
					Energy = Energy + (100.0f + (10.0f * ( Main.Aweapon + Main.Amoney ) ));
				else                          //如果現在能量 >= 400，則 現在能量 = 500
					Energy = 500.0f;          
				
					Skill.AddEnergyAction = false;
				Skill.AddEnergyParticalAction = true;
		} 
        
		//城門******************************************************************************************************************
		if(Live>0)DoorText.text = "" + Live ;       //城門生命值
		else DoorText.text = "敗";

		//修補城門技能釋放********************************************************************************************************
			if(Skill.AddDoorAction){
				if ( Live < (DoorMaxLive-5) )  //如果城門現在生命 < 城門生命最大值-5，則 城門現在生命 = 城門現在生命 + 5
					Live = Live + 5;
				else                           //如果城門現在生命 >= 城門生命最大值-5，則 城門現在生命 = 城門生命最大值
					Live = DoorMaxLive;          

				Skill.AddDoorAction = false;
				Skill.AddDoorParticalAction = true;
			} 


		//生成等待******************************************************************************************************************
		if(!Holgerwait && !WarPause) Holgerwaittime += Time.deltaTime; //生成等待時間增加
		if(!Holgerwait && Holgerwaittime>=1.0f){
			Holgerwait = true;
			Holgerwaittime = 0.0f;
		} 
		WaitBarHolger.fillAmount = Holgerwaittime/1.0f;    //等待條變化
		
		if(!Yukowait && !WarPause) Yukowaittime += Time.deltaTime; //生成等待時間增加
		if(!Yukowait && Yukowaittime>=1.2f){
			Yukowait = true;
			Yukowaittime = 0.0f;
		} 
		WaitBarYuko.fillAmount = Yukowaittime/1.2f;    //等待條變化

		if(!Yujiwait && !WarPause && Main.Apeople>=1) Yujiwaittime += Time.deltaTime; //生成等待時間增加
		if(!Yujiwait && Yujiwaittime>=1.5f && Main.Apeople>=1){
			Yujiwait = true;
			Yujiwaittime = 0.0f;
		} 
		WaitBarYuji.fillAmount = Yujiwaittime/1.5f;    //等待條變化

		if(!Archer1wait && !WarPause && Main.Aweapon>=1) Archer1waittime += Time.deltaTime; //生成等待時間增加
		if(!Archer1wait && Archer1waittime>=2.0f && Main.Aweapon>=1){
			Archer1wait = true;
			Archer1waittime = 0.0f;
		} 
		WaitBarArcher1.fillAmount = Archer1waittime/2.0f;    //等待條變化


		if(!Archer2wait && !WarPause && Main.Aweapon>=2) Archer2waittime += Time.deltaTime; //生成等待時間增加
		if(!Archer2wait && Archer2waittime>=1.0f && Main.Aweapon>=2){
			Archer2wait = true;
			Archer2waittime = 0.0f;
		} 
		WaitBarArcher2.fillAmount = Archer2waittime/1.0f;    //等待條變化


		if(!Archer3wait && !WarPause && Main.Aweapon>=3) Archer3waittime += Time.deltaTime; //生成等待時間增加
		if(!Archer3wait && Archer3waittime>=3.0f && Main.Aweapon>=3){
			Archer3wait = true;
			Archer3waittime = 0.0f;
		} 
		WaitBarArcher3.fillAmount = Archer3waittime/3.0f;    //等待條變化
		
		if(!Cindywait && !WarPause && Main.Apeople>=2) Cindywaittime += Time.deltaTime; //生成等待時間增加
		if(!Cindywait && Cindywaittime>=3.5f && Main.Apeople>=2){
			Cindywait = true;
			Cindywaittime = 0.0f;
		} 
		WaitBarCindy.fillAmount = Cindywaittime/3.5f;    //等待條變化

		if(!Misakiwait && !WarPause && Main.Apeople>=3) Misakiwaittime += Time.deltaTime; //生成等待時間增加
		if(!Misakiwait && Misakiwaittime>=4.5f && Main.Apeople>=3){
			Misakiwait = true;
			Misakiwaittime = 0.0f;
		} 
		WaitBarMisaki.fillAmount = Misakiwaittime/4.5f;    //等待條變化

		if(!Tokowait && !WarPause && Main.Apeople>=3 && Main.Aweapon>=3) Tokowaittime += Time.deltaTime; //生成等待時間增加
		if(!Tokowait && Tokowaittime>=5.0f && Main.Apeople>=3 && Main.Aweapon>=3){
			Tokowait = true;
			Tokowaittime = 0.0f;
		} 
		WaitBarToko.fillAmount = Tokowaittime/5.0f;    //等待條變化


		//判斷是否可出擊******************************************************************************************************************
		if (Energy >= 3 && Holgerwait && !WarPause)Holgerbutton.interactable = true;
		else Holgerbutton.interactable = false;

		if (Energy >= 5 && Yukowait && !WarPause)Yukobutton.interactable = true;
		else Yukobutton.interactable = false;
		
		if (Energy >= 8 && Yujiwait && !WarPause && Main.Apeople>=1)Yujibutton.interactable = true;
		else Yujibutton.interactable = false;

		if (Energy >= 12 && Archer1wait && !WarPause && Main.Aweapon>=1)Archer1button.interactable = true;
		else Archer1button.interactable = false;

		if (Energy >= 10 && Archer2wait && !WarPause && Main.Aweapon>=2)Archer2button.interactable = true;
		else Archer2button.interactable = false;

		if (Energy >= 20 && Archer3wait && !WarPause && Main.Aweapon>=3)Archer3button.interactable = true;
		else Archer3button.interactable = false;

		if (Energy >= 25 && Cindywait && !WarPause && Main.Apeople>=2)Cindybutton.interactable = true;
		else Cindybutton.interactable = false;

		if (Energy >= 30 && Misakiwait && !WarPause && Main.Apeople>=3)Misakibutton.interactable = true;
		else Misakibutton.interactable = false;

		if (Energy >= 35 && Tokowait && !WarPause && Main.Apeople>=3 && Main.Aweapon>=3)Tokobutton.interactable = true;
		else Tokobutton.interactable = false;



		//戰爭結束(勝利)******************************************************************************************************************
		if(CreateEnemy.Live<=0 && !WarisOver && timeEnd<=0.0f){
		
		
		ObtainTimeEnd += Time.deltaTime;
		if(ObtainTimeEnd<4.0f){
		 WinMusic.UnPause ();
		 WarWinBack.SetActive(true);
		 WarPersonImage.SetActive(false);
		 weapon = UnityEngine.Random.Range (100, 1001 * WarSelect.WarLevel);   //產生亂數(100~1000)
		 hospital = UnityEngine.Random.Range (100, 1001 * WarSelect.WarLevel); //產生亂數(100~1000)
		 food = UnityEngine.Random.Range (100, 1001 * WarSelect.WarLevel);     //產生亂數(100~1000)
		 money = UnityEngine.Random.Range (100, 1001 * WarSelect.WarLevel);    //產生亂數(100~1000)
		}
		else if(ObtainTimeEnd>=4.0f){
		 Main.weaponsum = Main.weaponsum + weapon;       //得到資源
		 Main.hospitalsum = Main.hospitalsum + hospital; //得到資源
		 Main.foodsum = Main.foodsum + food;             //得到資源
		 Main.moneysum = Main.moneysum + money;          //得到資源
		 WarisOver = true;
		 WarWinButton.SetActive(true);
		 ConversationText (true);
		 Conversation.Play ();
		 SaveImage.Play ();
		}
		
		 WarBackText1.text = "戰爭勝利!!!";
		 WarBackText2.text = "獲得 ⊕武器   X " + weapon +"\n     ⊕醫療   X "+ hospital +"\n     ⊕食物   X "+ food +"\n     ⊕金錢   X " + money;//印出訊息
		 BackMusic.Pause ();
	     
		 
        //通關
		if(WarSelect.WarLevel == 1)     WarSelect.PortPass[1] = 1;
		else if(WarSelect.WarLevel == 2)WarSelect.PortPass[2] = 1;
		else if(WarSelect.WarLevel == 3)WarSelect.PortPass[3] = 1;
		else if(WarSelect.WarLevel == 4)WarSelect.PortPass[4] = 1;	
	    
		if(WarSelect.WarLevel == 5)     WarSelect.ViseuPass[1] = 1;
		else if(WarSelect.WarLevel == 6)WarSelect.ViseuPass[2] = 1;
		else if(WarSelect.WarLevel == 7)WarSelect.ViseuPass[3] = 1;
		else if(WarSelect.WarLevel == 8)WarSelect.ViseuPass[4] = 1;

		if(WarSelect.WarLevel == 9)     WarSelect.BejaPass[1] = 1;
		else if(WarSelect.WarLevel == 10)WarSelect.BejaPass[2] = 1;
		else if(WarSelect.WarLevel == 11)WarSelect.BejaPass[3] = 1;
		else if(WarSelect.WarLevel == 12)WarSelect.BejaPass[4] = 1;

		//儲存紀錄
		PlayerPrefs.SetInt("PortPass1", WarSelect.PortPass[1] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("PortPass2", WarSelect.PortPass[2] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("PortPass3", WarSelect.PortPass[3] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("PortPass4", WarSelect.PortPass[4] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

		PlayerPrefs.SetInt("ViseuPass1", WarSelect.ViseuPass[1] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("ViseuPass2", WarSelect.ViseuPass[2] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("ViseuPass3", WarSelect.ViseuPass[3] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("ViseuPass4", WarSelect.ViseuPass[4] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

		PlayerPrefs.SetInt("BejaPass1", WarSelect.BejaPass[1] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("BejaPass2", WarSelect.BejaPass[2] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("BejaPass3", WarSelect.BejaPass[3] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("BejaPass4", WarSelect.BejaPass[4] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

		}

		//(失敗)******************************************************************************************************************
		else if(Live<=0 && !WarisOver && timeEnd<=0.0f){

				if (WarSelect.infiniteStart) {
					WarLoseBackText1.text = "<size=65>戰爭輪迴尚未結束!!!</size>";
					WarLoseBackText2.text = "獲得 ⊕武器   X " + weapon + "\n     ⊕醫療   X " + hospital + "\n     ⊕食物   X " + food + "\n     ⊕金錢   X " + money;  //印出訊息
					BackMusic.Pause ();

				} else {
					WarLoseBackText1.text = "戰爭失敗!!!";
					WarLoseBackText2.text = "獲得 ⊕武器   X " + weapon + "\n     ⊕醫療   X " + hospital + "\n     ⊕食物   X " + food + "\n     ⊕金錢   X " + money;  //印出訊息
					BackMusic.Pause ();

				}


			ObtainTimeEnd += Time.deltaTime;
			if(ObtainTimeEnd<4.0f){	 
			
			 WarLoseBack.SetActive(true);
			 WarPersonImage.SetActive(false);
			if (WarSelect.infiniteStart) {
					InfiniteMusic.UnPause ();
					weapon = UnityEngine.Random.Range (1*CreateEnemy.infiniteStartLevel, 201*CreateEnemy.infiniteStartLevel);   //產生亂數(1~200)
					hospital = UnityEngine.Random.Range (1*CreateEnemy.infiniteStartLevel, 201*CreateEnemy.infiniteStartLevel); //產生亂數(1~200)
					food = UnityEngine.Random.Range (1*CreateEnemy.infiniteStartLevel, 201*CreateEnemy.infiniteStartLevel);     //產生亂數(1~200)
					money = UnityEngine.Random.Range (1*CreateEnemy.infiniteStartLevel, 201*CreateEnemy.infiniteStartLevel);    //產生亂數(1~200)
			}
			else{
				  LoseMusic.UnPause ();
			      weapon = UnityEngine.Random.Range (1, 201);   //產生亂數(1~200)
			      hospital = UnityEngine.Random.Range (1, 201); //產生亂數(1~200)
			      food = UnityEngine.Random.Range (1, 201);     //產生亂數(1~200)
			      money = UnityEngine.Random.Range (1, 201);    //產生亂數(1~200)
				}
			}
			else if(ObtainTimeEnd>=4.0f){
			 Main.weaponsum = Main.weaponsum + weapon;       //失去資源
			 Main.hospitalsum = Main.hospitalsum + hospital; //失去資源
			 Main.foodsum = Main.foodsum + food;             //失去資源
			 Main.moneysum = Main.moneysum + money;          //失去資源
			 WarisOver = true;
			 WarSelect.infiniteStart = false;
			 CreateEnemy.infiniteStartLevel = 1;
			 WarLoseButton.SetActive(true);
			 ConversationText (false);
			 Conversation.Play ();
			 SaveImage.Play ();
			}
					
			
		}

	}//戰爭開始

		if (WarisOver) Energy = 0.0f;


		//紀錄
		PlayerPrefs.SetInt("weaponsum1", Main.weaponsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("hospitalsum1", Main.hospitalsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("foodsum1",Main.foodsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("moneysum1", Main.moneysum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

		if(CreateEnemy.infiniteStartLevel > WarSelect.InfinitePass){
			PlayerPrefs.SetInt("InfinitePass", CreateEnemy.infiniteStartLevel );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
			WarSelect.InfinitePass = PlayerPrefs.GetInt("InfinitePass"); //讀入成就記錄(以下相同)

		}

		PlayerPrefs.SetInt("Placetime1", Placeyesno.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime2", Placeyesno2.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime3", Placeyesno3.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime4", Placeyesno4.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime5", Placeyesno5.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

		

	}//Update結束

	//碰到城門
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "EHolger" || col.tag == "EYuko" || col.tag == "EYuji" || col.tag == "EArcher1"  || col.tag == "EArcher2" || col.tag == "EArcher3" || col.tag == "ECindy" || col.tag == "EMisaki"|| col.tag == "EToko")
		{
			Destroy(col.gameObject);
			Live--; //城門減少生命值
		}


	}


	/*GetKey和GetKeyDown的差別
	  GetKey是按著可連發
	  GetKeyDown是按下去一次只算一次*/

	//創立Holger(男)=======================================================================
	public void CR_Holger(){
		GOMusicM1.Play ();
		Vector3 pos = gameObject.transform.position + new Vector3(1.0f,-0.2f,0); //生成位置
		Instantiate(Holger,pos,gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
		//Instantiate(E,pos,gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
		Energy = Energy - 3;
		Holgerwait = false;  //等待生成
		Instantiate (SoliderPart, pos, gameObject.transform.rotation); //士兵生成粒子
	} 

	//創立Yuko(女)=======================================================================
	public void CR_Yuko(){
		GOMusicF1.Play ();
		Vector3 pos = gameObject.transform.position + new Vector3(1.0f,-0.2f,0);//生成位置
		Instantiate(Yuko,pos,gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
		Energy = Energy - 5;
		Yukowait = false;  //等待生成
		Instantiate (SoliderPart, pos, gameObject.transform.rotation); //士兵生成粒子
	} 

	//創立Yuji(男)=======================================================================
	public void CR_Yuji(){
		GOMusicM2.Play ();
		Vector3 pos = gameObject.transform.position + new Vector3(1.0f,-0.2f,0);//生成位置
		Instantiate(Yuji,pos,gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
		Energy = Energy - 8;
		Yujiwait = false;
		Instantiate (SoliderPart, pos, gameObject.transform.rotation); //士兵生成粒子
	} 

	//創立Archer1(男)=======================================================================
	public void CR_Archer1(){
		GOMusicM3.Play ();
		Vector3 pos = gameObject.transform.position + new Vector3(1.0f,0.0f,0);//生成位置
		Instantiate(Archer1,pos,gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
		Energy = Energy - 12;
		Archer1wait = false;
		Instantiate (SoliderPart, pos, gameObject.transform.rotation); //士兵生成粒子
	} 

	//創立Archer2(男)=======================================================================
	public void CR_Archer2(){
		GOMusicM4.Play ();
		Vector3 pos = gameObject.transform.position + new Vector3(1.0f,-0.05f,0);//生成位置
		Instantiate(Archer2,pos,gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
		Energy = Energy - 10;
		Archer2wait = false;
		Instantiate (SoliderPart, pos, gameObject.transform.rotation); //士兵生成粒子
	} 

	//創立Archer3(男)=======================================================================
	public void CR_Archer3(){
		GOMusicM5.Play ();
		Vector3 pos = gameObject.transform.position + new Vector3(1.0f,0.18f,0);//生成位置
		Instantiate(Archer3,pos,gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
		Energy = Energy - 20;
		Archer3wait = false;
		Instantiate (SoliderPart, pos, gameObject.transform.rotation); //士兵生成粒子
	} 

	//創立Cindy(女)=======================================================================
	public void CR_Cindy(){
		GOMusicF2.Play ();
		Vector3 pos = gameObject.transform.position + new Vector3(1.0f,-0.2f,0);//生成位置
		Instantiate(Cindy,pos,gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
		Energy = Energy - 25;
		Cindywait = false;
		Instantiate (SoliderPart, pos, gameObject.transform.rotation); //士兵生成粒子
	}

	//創立Misaki(女)=======================================================================
	public void CR_Misaki(){
		GOMusicF3.Play ();
		Vector3 pos = gameObject.transform.position + new Vector3(1.0f,-0.2f,0);//生成位置
		Instantiate(Misaki,pos,gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
		Energy = Energy - 30;
		Misakiwait = false;
		Instantiate (SoliderPart, pos, gameObject.transform.rotation); //士兵生成粒子
	}

	//創立Toko(女)=======================================================================
	public void CR_Toko(){
		GOMusicF4.Play ();
		Vector3 pos = gameObject.transform.position + new Vector3(1.0f,-0.2f,0);//生成位置
		Instantiate(Toko,pos,gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
		Energy = Energy - 35;
		Tokowait = false;
		Instantiate (SoliderPart, pos, gameObject.transform.rotation); //士兵生成粒子
	}

	//戰爭開始============================================================================
	public void War(){
		WarStart = true;
		if (WarSelect.infiniteStart) {
			BeginAnimateB.SetActive (true);
			BeginTextB.text = "戰爭輪迴";
		}
		else if (WarSelect.WarLevel <= 4) {
			BeginAnimateP.SetActive (true);
			if (WarSelect.WarLevel == 1)BeginTextP.text = "第一次北方戰爭\n1563 - 1570";
			else if (WarSelect.WarLevel == 2)BeginTextP.text = "法國宗教戰爭\n1562年- 1598";
			else if (WarSelect.WarLevel == 3)BeginTextP.text = "瑞典解放戰爭\n1521 - 1523";
			else if (WarSelect.WarLevel == 4)BeginTextP.text = "三十年戰爭\n1618 - 1648";
		} else if (WarSelect.WarLevel >= 5 && WarSelect.WarLevel <= 8) {
			BeginAnimateV.SetActive (true);
			if (WarSelect.WarLevel == 5)BeginTextV.text = "札克雷暴動\n1358，5 - 1358，6";
			else if (WarSelect.WarLevel == 6)BeginTextV.text = "貝爾格勒之圍\n1456，7，4 – 1456，7，22";
			else if (WarSelect.WarLevel == 7)BeginTextV.text = "玫瑰戰爭\n1455 - 1485";
			else if (WarSelect.WarLevel == 8)BeginTextV.text = "百年戰爭1337 - 1453";
		} else if (WarSelect.WarLevel >= 9) {
			BeginAnimateB.SetActive (true);
			if (WarSelect.WarLevel == 9)BeginTextB.text = "維也納之戰\n1683，9，12";
			else if (WarSelect.WarLevel == 10)BeginTextB.text = "義大利戰爭\n1494 - 1559";
			else if (WarSelect.WarLevel == 11)BeginTextB.text = "費拉拉戰爭\n1482 - 1484";
			else if (WarSelect.WarLevel == 12)BeginTextB.text = "倫巴第同盟1167 - 1250";
		}
	}

	//戰爭對話框=================================================================================
	public void WarConversation(){
		int rand;
	    
		rand = UnityEngine.Random.Range (1, 17);

		if (rand == 1)
			WarConversationText.text = "注意我方士兵的血量!!!";
		else if (rand == 2)
			WarConversationText.text = "士氣開始動搖了?";
		else if (rand == 3)
			WarConversationText.text = "敵人似乎開始撤退了?";
		else if (rand == 4)
			WarConversationText.text = "看時機發動戰術。";
		else if (rand == 5)
			WarConversationText.text = "城門快被攻破了!!!";
		else if (rand == 6)
			WarConversationText.text = "敵人似乎開始發生變化。";
		else if (rand == 7)
			WarConversationText.text = "敵人城門快要攻破了!!!";
		else if (rand == 8)
			WarConversationText.text = "盡快打敗敵人。";
		else if (rand == 9)
			WarConversationText.text = "隨時注意士氣的剩餘量!!!";
		else if (rand == 10)
			WarConversationText.text = "勝利就在眼前了!!!";
		else if (rand == 11)
			WarConversationText.text = "釋放戰術回復士氣。";
		else if (rand == 12)
			WarConversationText.text = "敵人似乎要發動戰術?";
		else if (rand == 13)
			WarConversationText.text = "我方現在正握有優勢。";
		else if (rand == 14)
			WarConversationText.text = "敵方現在正處於優勢。";
		else if (rand == 15)
			WarConversationText.text = "敵方現在正處於劣勢。";
		else if (rand == 16)
			WarConversationText.text = "隨時了解戰場情況。";
		else
			WarConversationText.text = "看時機發動戰術。";
	}

	//戰爭結束對話框=============================================================================
	public void ConversationText( Boolean War){
		int rand;
		rand = UnityEngine.Random.Range (1, 11);

		//戰爭勝利
		if (War) {
			if (rand == 1)
				ConsersationText.text = "太好了，擊潰敵人了!!!";
			else if (rand == 2)
				ConsersationText.text = "下次要再更快擊潰敵人!!!";
			else if (rand == 3)
				ConsersationText.text = "暫時能休息一陣子了。";
			else if (rand == 4)
				ConsersationText.text = "獲得了一些物資，你要怎麼使用?";
			else if (rand == 5)
				ConsersationText.text = "人民能夠安定過生活了。";
			else if (rand == 6)
				ConsersationText.text = "人民能夠安定過生活了。";
			else if (rand == 7)
				ConsersationText.text = "這是勝利得來不易。";
			else if (rand == 8)
				ConsersationText.text = "又向統一義大利邁進一步!!!";
			else if (rand == 9)
				ConsersationText.text = "敵人暫時不會有太大的動作了。";
			else if (rand == 10)
				ConsersationText.text = "這次勝利讓敵人元氣大傷。";
			else
				ConsersationText.text = "勝利是我們的!!!";
		} 
		//戰爭失敗
		else {
			if (rand == 1)
				ConsersationText.text = "這次敵人好強!!!";
			else if (rand == 2)
				ConsersationText.text = "輸家!!!";
			else if (rand == 3)
				ConsersationText.text = "這次失敗造成了很大的損失。";
			else if (rand == 4)
				ConsersationText.text = "要在重新思考作戰方針?";
			else if (rand == 5)
				ConsersationText.text = "需要在加強士兵的能力!!!";
			else if (rand == 6)
				ConsersationText.text = "人民不能夠安定過生活了......";
			else if (rand == 7)
				ConsersationText.text = "這是失敗導致了人民死亡。";
			else if (rand == 8)
				ConsersationText.text = "統一義大利的夢想又更遠了!!!";
			else if (rand == 9)
				ConsersationText.text = "敵人可能再次進攻。";
			else if (rand == 10)
				ConsersationText.text = "這次失敗讓我方元氣大傷。";
			else
				ConsersationText.text = "下次一定會成功拿下城池......";
		}


	}

	//戰爭結束=============================================================================
	public void Back(){
		ButtonMusic.Play ();
		FadeOut.SetActive(true);
	} 

	//戰爭繼續=============================================================================
	public void WarContinue(){
		WarPause = false;
		WarPauseButton.SetActive (false);
	}


}//主程式結束=====================================================================================================================
