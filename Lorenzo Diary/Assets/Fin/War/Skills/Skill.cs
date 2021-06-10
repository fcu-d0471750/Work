//戰爭技能
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class Skill : MonoBehaviour {

	//宣告變數**********************************************************************************
	  //共用  
	  public AudioSource ActionMusic;    //技能釋放音效 

	  //補血
	  public static  bool AddLiveAction; //補血釋放 true:釋放 fasle:未釋放
	  bool AddLiveWait;                  //補血技能是否可開啟 true:可開啟 false:冷卻中
	  float AddLiveCD;                   //補血技能冷卻時間 
	  public Button AddLiveButton;       //補血Button
	  public Image AddLiveBar;           //補血冷卻條
	  public AudioSource AddLiveMusic;   //補血技能釋放音效
	  public Animation AddLiveChacter;   //補血大頭照
	  public Animation AddPanel;         //補血畫面
	  public GameObject AddLivePartical; //補血粒子 
	  public Text LiveCD;                //CD時間Text
	  float  AddLiveParticaltime;        //補血粒子播放時間 
	  bool   AddLiveParticalAction;      //補血粒子狀態  true:釋放 false:消失 
	  float  LiveTime;                   //補血持續時間

	  //回復能量條
	  public static  bool AddEnergyAction; //回復能量條釋放 true:釋放 fasle:未釋放
	  bool AddEnergyWait;                  //回復能量條技能是否可開啟 true:可開啟 false:冷卻中
	  float AddEnergyCD;                   //回復能量條技能冷卻時間 
	  public Button AddEnergyButton;       //回復能量條Button
	  public Image AddEnergyBar;           //回復能量條冷卻條
	  public AudioSource AddEnergyMusic;   //回復能量條技能釋放音效
	  public Animation AddEnergyChacter;   //回復能量條大頭照
	  public Animation EnergyPanel;        //回復能量條補血畫面
	  public GameObject AddEnergyPartical; //回復能量粒子 
	  public Text EnergyCD;                //CD時間Text
	  float  AddEnergyParticaltime;        //回復能量粒子播放時間 
	  public static bool   AddEnergyParticalAction;      //回復能量粒子狀態  true:釋放 false:消失 

	  //爆炸傷害
	  public static  bool AddBombAction; //爆炸傷害釋放 true:釋放 fasle:未釋放
	  bool AddBombWait;                  //爆炸傷害技能是否可開啟 true:可開啟 false:冷卻中
	  float AddBombCD;                   //爆炸傷害技能冷卻時間 
	  public Button AddBombButton;       //爆炸傷害Button
	  public Image AddBombBar;           //爆炸傷害冷卻條
	  public AudioSource AddBombMusic;   //爆炸傷害技能釋放音效
	  public Animation AddBombChacter;   //爆炸傷害大頭照
	  public Animation BombPanel;        //爆炸傷害補血畫面
	  public GameObject AddBombPartical; //爆炸傷害粒子 
	  public Text BombCD;                //CD時間Text
	  float  AddBombParticaltime;        //爆炸傷害粒子播放時間 
	  public static bool   AddBombParticalAction;      //爆炸傷害粒子狀態  true:釋放 false:消失
	  float BombTime;                                  //爆炸傷害持續時間
	  //public GameObject BombPart; 					   //爆炸粒子 

	  //修補城門
	  public static  bool AddDoorAction; //修補城門釋放 true:釋放 fasle:未釋放
	  bool AddDoorWait;                  //修補城門技能是否可開啟 true:可開啟 false:冷卻中
	  float AddDoorCD;                   //修補城門技能冷卻時間 
	  public Button AddDoorButton;       //修補城門Button
	  public Image AddDoorBar;           //修補城門冷卻條
	  public AudioSource AddDoorMusic;   //修補城門技能釋放音效
	  public Animation AddDoorChacter;   //修補城門大頭照
	  public Animation DoorPanel;        //修補城門畫面
	  public GameObject AddDoorPartical; //修補城門粒子 
	  public Text DoorCD;                //CD時間Text
	  float  AddDoorParticaltime;        //修補城門粒子播放時間 
	  public static bool   AddDoorParticalAction;     //修補城門粒子狀態  true:釋放 false:消失





	// Use this for initialization
	void Start () {
	   //補血初始化*****************************************************************************
		AddLiveAction = false;
		AddLiveWait = true;
		AddLiveCD = 0.0f;
		AddLiveButton.interactable = true;
		AddLivePartical.SetActive(false);
		AddLiveParticaltime = 0.0f;
		AddLiveParticalAction = false;
		LiveTime = 0.0f;

	   //回復能量條初始化************************************************************************
		AddEnergyAction = false;
		AddEnergyWait = true;
		AddEnergyCD = 0.0f;
		AddEnergyButton.interactable = true;
		AddEnergyPartical.SetActive(false);
		AddEnergyParticaltime = 0.0f;
		AddEnergyParticalAction = false;

		//爆炸傷害初始化************************************************************************
		AddBombAction = false;
		AddBombWait = true;
		AddBombCD = 0.0f;
		AddBombButton.interactable = true;
		AddBombPartical.SetActive(false);
		AddBombParticaltime = 0.0f;
		AddBombParticalAction = false;
		BombTime = 0.0f;

		//修補城門初始化************************************************************************
		AddDoorAction = false;
		AddDoorWait = true;
		AddDoorCD = 0.0f;
		AddDoorButton.interactable = true;
		AddDoorPartical.SetActive(false);
		AddDoorParticaltime = 0.0f;
		AddDoorParticalAction = false;

	}

	// Update is called once per frame
	void Update () {
	   //技能釋放(鍵盤)
		if(Input.GetKeyDown(KeyCode.Q) && AddLiveWait && CreatePeople.WarStart && !CreatePeople.WarisOver && !CreatePeople.WarPause) AddLive();
		if (Input.GetKeyDown (KeyCode.W) && AddEnergyWait && CreatePeople.WarStart && !CreatePeople.WarisOver && !CreatePeople.WarPause)AddEnergy ();
		if(Input.GetKeyDown(KeyCode.R) && AddBombWait && CreatePeople.WarStart && !CreatePeople.WarisOver && !CreatePeople.WarPause) AddBomb();
		if(Input.GetKeyDown(KeyCode.E) && AddDoorWait && CreatePeople.WarStart && !CreatePeople.WarisOver && !CreatePeople.WarPause) AddDoor();
	
	   //補血*****************************************************************************************************************************************************
		if(!AddLiveWait && !CreatePeople.WarPause ) AddLiveCD += Time.deltaTime;
		if (!AddLiveWait && AddLiveCD >= 5.0f ) { //冷卻時間
			AddLiveWait = true;
			AddLiveButton.interactable = true;
			AddLiveCD = 0.0f;
		}	
		AddLiveBar.fillAmount = AddLiveCD / 5.0f;

		if (AddLiveCD == 0.0f && AddLiveWait && !CreatePeople.WarPause && CreatePeople.WarStart && !CreatePeople.WarisOver) {
			AddLiveButton.interactable = true;
			LiveCD.text = " ";
		} else {
			AddLiveButton.interactable = false;
			LiveCD.text = "" + (5.0f - AddLiveCD).ToString("0.0");
		}
		//補血粒子
		if (AddLiveAction) {
			AddLiveParticalAction = true; 
			LiveTime += Time.deltaTime;
			if (LiveTime > 0.03f) {
				AddLiveAction = false;
				LiveTime = 0.0f;
			}
		}

		if (AddLiveParticalAction && AddLiveParticaltime <= 2.0f) {
			AddLiveParticaltime += Time.deltaTime;
			AddLivePartical.SetActive(true);
		} else {
			AddLiveAction = false;
			AddLiveParticalAction = false;
			AddLiveParticaltime = 0.0f;
			AddLivePartical.SetActive(false);
		}
		//補血結束********************************************************************************************************************************************************

	   //回復能量條*******************************************************************************************************************************************************
		if(!AddEnergyWait && !CreatePeople.WarPause ) AddEnergyCD += Time.deltaTime;
		if (!AddEnergyWait && AddEnergyCD >= 15.0f ) { //冷卻時間
			AddEnergyWait = true;
			AddEnergyButton.interactable = true;
			AddEnergyCD = 0.0f;
		}	
		AddEnergyBar.fillAmount = AddEnergyCD / 15.0f;

		if (AddEnergyCD == 0.0f && AddEnergyWait && !CreatePeople.WarPause && CreatePeople.WarStart && !CreatePeople.WarisOver) {
			AddEnergyButton.interactable = true;
			EnergyCD.text = " ";
		} else {
			AddEnergyButton.interactable = false;
			EnergyCD.text = "" + (15.0f - AddEnergyCD).ToString ("0.0");
		}
		//回復能量粒子
		if (AddEnergyAction)  AddEnergyParticalAction = true; 
		

		if (AddEnergyParticalAction && AddEnergyParticaltime <= 2.0f) {
			AddEnergyParticaltime += Time.deltaTime;
			AddEnergyPartical.SetActive(true);
		} else {
			AddEnergyAction = false;
			AddEnergyParticalAction = false;
			AddEnergyParticaltime = 0.0f;
			AddEnergyPartical.SetActive(false);
		}
		//回復能量條結束********************************************************************************************************************************************************

		//爆炸傷害*****************************************************************************************************************
		if(!AddBombWait && !CreatePeople.WarPause ) AddBombCD += Time.deltaTime;
		if (!AddBombWait && AddBombCD >= 5.0f ) { //冷卻時間
			AddBombWait = true;
			AddBombButton.interactable = true;
			AddBombCD = 0.0f;
		}	
		AddBombBar.fillAmount = AddBombCD / 5.0f;

		if (AddBombCD == 0.0f && AddBombWait && !CreatePeople.WarPause && CreatePeople.WarStart && !CreatePeople.WarisOver) {
			AddBombButton.interactable = true;
			BombCD.text = " ";
		} else {
			AddBombButton.interactable = false;
			BombCD.text = "" + (5.0f - AddBombCD).ToString ("0.0");
		}
		//爆炸傷害粒子
		if (AddBombAction) {
			AddBombParticalAction = true; 
			BombTime += Time.deltaTime;
			if (BombTime > 0.03f) {
				AddBombAction = false;
				BombTime = 0.0f;
			}
		}

		if (AddBombParticalAction && AddBombParticaltime <= 2.0f) {
			AddBombParticaltime += Time.deltaTime;
			AddBombPartical.SetActive(true);
		} else {
			AddBombAction = false;
			AddBombParticalAction = false;
			AddBombParticaltime = 0.0f;
			AddBombPartical.SetActive(false);
		}
		//爆炸傷害結束*****************************************************************************************************************

		//修補城門***********************************************************************************************************************************************
		if(!AddDoorWait && !CreatePeople.WarPause ) AddDoorCD += Time.deltaTime;
		if (!AddDoorWait && AddDoorCD >= 30.0f ) {  //冷卻時間
			AddDoorWait = true;
			AddDoorButton.interactable = true;
			AddDoorCD = 0.0f;
		}	
		AddDoorBar.fillAmount = AddDoorCD / 30.0f;

		if (AddDoorCD == 0.0f && AddDoorWait && !CreatePeople.WarPause && CreatePeople.WarStart && !CreatePeople.WarisOver) {
			AddDoorButton.interactable = true;
			DoorCD.text = " ";
		} else {
			AddDoorButton.interactable = false;
			DoorCD.text = "" + (30.0f - AddDoorCD).ToString ("0.0");
		}
		//修補城門粒子
		if (AddDoorAction) AddDoorParticalAction = true; 
	
		if (AddDoorParticalAction && AddDoorParticaltime <= 2.0f) {
			AddDoorParticaltime += Time.deltaTime;
			AddDoorPartical.SetActive(true);
		} else {
			AddDoorAction = false;
			AddDoorParticalAction = false;
			AddDoorParticaltime = 0.0f;
			AddDoorPartical.SetActive(false);
		}
		//修補城門結束***********************************************************************************************************************************************

	}//Update結束*****************************************************************************************************************************************************

	//副程式:補血***************************************************************************************
	public void AddLive(){
		AddLiveAction = true;
		AddLiveWait = false;
		AddLiveButton.interactable = false;
		AddLiveChacter.Play ();
		AddPanel.Play ();
		ActionMusic.Play ();
	}

	//副程式:回復能量條***************************************************************************************
	public void AddEnergy(){
		AddEnergyAction = true;
		AddEnergyWait = false;
		AddEnergyButton.interactable = false;
		AddEnergyChacter.Play ();
		EnergyPanel.Play ();
		ActionMusic.Play ();
	}

	//副程式:爆炸傷害***************************************************************************************
	public void AddBomb(){
		AddBombAction = true;
		AddBombWait = false;
		AddBombButton.interactable = false;
		AddBombChacter.Play ();
		BombPanel.Play ();
		ActionMusic.Play ();
	}

	//副程式:修補城門***************************************************************************************
	public void AddDoor(){
		AddDoorAction = true;
		AddDoorWait = false;
		AddDoorButton.interactable = false;
		AddDoorChacter.Play ();
		DoorPanel.Play ();
		ActionMusic.Play ();
	}


}
