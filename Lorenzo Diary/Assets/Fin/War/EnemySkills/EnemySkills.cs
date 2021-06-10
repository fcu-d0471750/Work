//敵人戰爭名稱
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間


public class EnemySkills : MonoBehaviour {

	//宣告變數**********************************************************************************
	//共用  
	public AudioSource ActionMusic; //技能釋放音效 


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
	float  AddLiveParticaltime;        //補血粒子播放時間 
	bool   AddLiveParticalAction;      //補血粒子狀態  true:釋放 false:消失 
	float  LiveTime;                   //補血持續時間


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
	float  AddBombParticaltime;        //爆炸傷害粒子播放時間 
	public static bool   AddBombParticalAction;      //爆炸傷害粒子狀態  true:釋放 false:消失
	float BombTime;                                  //爆炸傷害持續時間


	// Use this for initialization
	void Start () {
		//補血初始化*****************************************************************************
		AddLiveAction = false;
		AddLiveWait = false;
		AddLiveCD = 0.0f;
		AddLiveButton.interactable = true;
		AddLivePartical.SetActive(false);
		AddLiveParticaltime = 0.0f;
		AddLiveParticalAction = false;
		LiveTime = 0.0f;

		//爆炸傷害初始化************************************************************************
		AddBombAction = false;
		AddBombWait = false;
		AddBombCD = 0.0f;
		AddBombButton.interactable = true;
		AddBombPartical.SetActive(false);
		AddBombParticaltime = 0.0f;
		AddBombParticalAction = false;
		BombTime = 0.0f;


	}
	
	// Update is called once per frame
	void Update () {
		//補血*****************************************************************************************************************************************************
		if(!AddLiveWait && !CreatePeople.WarPause && CreatePeople.WarStart) AddLiveCD += Time.deltaTime;
		if (!AddLiveWait && AddLiveCD >= 20.0f ) {
			AddLiveWait = true;
			AddLiveButton.interactable = true;
			AddLiveCD = 0.0f;
		}	
		AddLiveBar.fillAmount = AddLiveCD / 5.0f;

		if (AddLiveCD == 0.0f && AddLiveWait && !CreatePeople.WarPause && CreatePeople.WarStart && !CreatePeople.WarisOver)AddLiveButton.interactable = true;
		else AddLiveButton.interactable = false;

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
		//補血釋放
		if(WarSelect.WarLevel>=5 && CreatePeople.WarStart && AddLiveWait) AddLive();

		//補血結束********************************************************************************************************************************************************

		//爆炸傷害*****************************************************************************************************************
		if(!AddBombWait && !CreatePeople.WarPause ) AddBombCD += Time.deltaTime;
		if (!AddBombWait && AddBombCD >= 50.0f ) {
			AddBombWait = true;
			AddBombButton.interactable = true;
			AddBombCD = 0.0f;
		}	
		AddBombBar.fillAmount = AddBombCD / 5.0f;

		if (AddBombCD == 0.0f && AddBombWait && !CreatePeople.WarPause && CreatePeople.WarStart && !CreatePeople.WarisOver)AddBombButton.interactable = true;
		else AddBombButton.interactable = false;

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

		//補血釋放
		if(WarSelect.WarLevel>=5 && CreatePeople.WarStart && AddBombWait) AddBomb();
		//爆炸傷害結束*****************************************************************************************************************

	
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


	//副程式:爆炸傷害***************************************************************************************
	public void AddBomb(){
		AddBombAction = true;
		AddBombWait = false;
		AddBombButton.interactable = false;
		AddBombChacter.Play ();
		BombPanel.Play ();
		ActionMusic.Play ();
	}


}
