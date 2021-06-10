using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class start : MonoBehaviour {

	public GameObject startbutton;       //宣告PlayButton物件
	public GameObject Achievementbutton; //宣告Achievementbutton物件
	public GameObject exitbutton;        //宣告exitButton物件
	public GameObject Storebutton;       //宣告StoreButton物件
	public GameObject MainFadeout;       //宣告MainFadeout物件
	public Text Correctsum = null;       //總答對數
	public Text Mistakesum = null;       //總答錯數
	public AudioSource ButtonMusic;      //按扭音效
	public AudioSource BackMusic;        //返回音效
	public AudioSource music;            //音樂
	float timef;                         //時間

	// Use this for initialization
	void Start () {
		if(Musicbotton.musicplay == true) music.Play();  //如果開始畫面音效被開啟,音樂播放
		else music.Pause();                              //如果開始畫面音效被關閉,音樂暫停
		music.volume = Musicbotton.MusicVo;
		MainFadeout.SetActive (false);
		AllScore.LevelCorrectsum = PlayerPrefs.GetInt("LevelCorrectsum");  //讀入總答對數
		AllScore.LevelMistakesum = PlayerPrefs.GetInt("LevelMistakesum");  //讀入總答錯數
		Correctsum.text = "總答對題數: " + AllScore.LevelCorrectsum;       //顯示總答對數 
		Mistakesum.text = "總答錯題數: " + AllScore.LevelMistakesum;       //顯示總答錯數

		AllScore.S = PlayerPrefs.GetInt("SS");  //讀入評價次數
		AllScore.A = PlayerPrefs.GetInt("AS");  //讀入評價次數
		AllScore.B = PlayerPrefs.GetInt("BS");  //讀入評價次數
		AllScore.C = PlayerPrefs.GetInt("CS");  //讀入評價次數
		AllScore.D = PlayerPrefs.GetInt("DS");  //讀入評價次數
		AllScore.E = PlayerPrefs.GetInt("ES");  //讀入評價次數

		Placeyesno.Placetime =  PlayerPrefs.GetInt("Placetime1"); //讀入成就記錄(以下相同)
		Placeyesno2.Placetime =  PlayerPrefs.GetInt("Placetime2"); //讀入成就記錄(以下相同)
		Placeyesno3.Placetime =  PlayerPrefs.GetInt("Placetime3"); //讀入成就記錄(以下相同)
		Placeyesno4.Placetime =  PlayerPrefs.GetInt("Placetime4"); //讀入成就記錄(以下相同)
		Placeyesno5.Placetime =  PlayerPrefs.GetInt("Placetime5"); //讀入成就記錄(以下相同)


		/*/獎杯
		Award1.Get[1] =  PlayerPrefs.GetInt("Award1Get1"); //讀入成就記錄(以下相同)
		Award1.Get[2] =  PlayerPrefs.GetInt("Award1Get2"); 
		Award1.Get[3] =  PlayerPrefs.GetInt("Award1Get3"); 
		Award1.Get[4] =  PlayerPrefs.GetInt("Award1Get4"); 
		Award1.Get[5] =  PlayerPrefs.GetInt("Award1Get5"); 
		Award1.Get[6] =  PlayerPrefs.GetInt("Award1Get6"); 
		Award1.Get[7] =  PlayerPrefs.GetInt("Award1Get7"); 
		Award1.Get[8] =  PlayerPrefs.GetInt("Award1Get8"); 
		Award1.Get[9] =  PlayerPrefs.GetInt("Award1Get9"); 
		Award1.Get[10] =  PlayerPrefs.GetInt("Award1Get10"); 
		Award1.Get[11] =  PlayerPrefs.GetInt("Award1Get11"); 
		Award1.Get[12] =  PlayerPrefs.GetInt("Award1Get12"); 
		Award1.Get[13] =  PlayerPrefs.GetInt("Award1Get13"); 
		Award1.Get[14] =  PlayerPrefs.GetInt("Award1Get14"); 
		Award1.Get[15] =  PlayerPrefs.GetInt("Award1Get15"); 

		//商店
		Store.pintScore = PlayerPrefs.GetInt("pintScore");
		Store.pintCorrect = PlayerPrefs.GetInt("pintCorrect");
		Store.pintMistake = PlayerPrefs.GetInt("pintMistake");*/
	}

	// Update is called once per frame
	void Update () {
		//鍵盤輸入(返回)
		if(Input.GetKeyDown("escape"))exitgame();


		//如果船已經出航
		timef +=Time.deltaTime;   //記錄時間
		if (timef >= 1) { //如果時間>=1 && Placetime[0]!=0 && 已按下按鈕 
			if(Placeyesno.Placetime!=30 && Placeyesno.Placetime!=0) Placeyesno.Placetime--;
			if(Placeyesno2.Placetime!=60 && Placeyesno2.Placetime!=0) Placeyesno2.Placetime--;
			if(Placeyesno3.Placetime!=80 && Placeyesno3.Placetime!=0) Placeyesno3.Placetime--;
			if(Placeyesno4.Placetime!=100 && Placeyesno4.Placetime!=0) Placeyesno4.Placetime--;
			if(Placeyesno5.Placetime!=120 && Placeyesno5.Placetime!=0) Placeyesno5.Placetime--;
			timef = 0;
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
	}

	//開始按鈕*******************************************************************
	public void startbuttonpush()
	{
		ButtonMusic.Play ();
		Application.LoadLevel("selectscreen");    //切換畫面1
	}

	//成就按鈕*******************************************************************
	public void AchievementButton()
	{
		ButtonMusic.Play ();
		Application.LoadLevel("Record");  //切換畫面成就   	
	}

	//商店按鈕*******************************************************************
	public void StoreButton()
	{
		ButtonMusic.Play ();
		Application.LoadLevel("Store");  //切換商店   	
	}

	//紀錄按鈕******************************************************************************
	public void RecordButton()
	{
		ButtonMusic.Play ();
		Application.LoadLevel("Record");  //切換紀錄   	
	}

	//回到主畫面****************************************************************************
	public void exitgame()
	{
		BackMusic.Play ();
		MainFadeout.SetActive (true);
	}


}
