using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class selectlevel : MonoBehaviour {

	//宣告變數******************************************************************************************
	public  Button selectlevelbutton1;           //難度:學生
	public  Button selectlevelbutton2;           //難度:新鮮人
	public  Button selectlevelbutton3;           //難度:職場
	public  Button selectlevelbutton4;           //難度:高階
	public  Text Correctsum = null;              //總答對數
	public  Text Mistakesum = null;              //總答錯數
	public  Text selectlevelbutton2text;         //文字:累計答對50題
	public  Text selectlevelbutton3text;         //文字:累計答對200題
	public  Text selectlevelbutton4text;         //文字:累計答對500題
	public  static int select = 0;               //難度用來判斷玩家選擇難度  
	public  static int[] playing = new int[400]; //關卡是否出現過(預設為0) 0:未出現 , 1:已出現
	public  AudioSource music;                   //音樂
	public  AudioSource ButtonMusic;              //按扭音效
	public  AudioSource BackButtonMusic;              //按扭音效
	public Button HomeButton;                    //按鈕元件HomeButton
	float timef;                                 //時間

	// Use this for initialization*****************************************************************************
	void Start() {

		if(Musicbotton.musicplay == true) music.Play();  //如果開始畫面音效被開啟,音樂播放
		else music.Pause();                              //如果開始畫面音效被關閉,音樂暫停
		music.volume = Musicbotton.MusicVo;
		AllScore.LevelScore = 0;   //關卡選擇畫面啟動,遊戲分數設為初始值0
		AllScore.LevelCorrect = 0; //關卡選擇畫面啟動,遊戲答對題數設為初始值0
		AllScore.LevelMistake = 0; //關卡選擇畫面啟動,遊戲錯誤題數設為初始值0

		Correctsum.text = "總答對題數: " + AllScore.LevelCorrectsum;
		Mistakesum.text = "總答錯題數: " + AllScore.LevelMistakesum;

		//關卡開啟條件==============================================================================
		if(AllScore.LevelCorrectsum>=50) 
		{
			selectlevelbutton2.interactable = true;
			selectlevelbutton2text.text = " ";
		}
		else 
		{
			selectlevelbutton2.interactable = false;
			selectlevelbutton2text.text = "累計答對50題";
		}

		if(AllScore.LevelCorrectsum>=200) 
		{
			selectlevelbutton3.interactable = true;
			selectlevelbutton3text.text = " ";
		}
		else 
		{
			selectlevelbutton3.interactable = false;
			selectlevelbutton3text.text = "累計答對200題";
		}

		if(AllScore.LevelCorrectsum>=500) 
		{
			selectlevelbutton4.interactable = true;
			selectlevelbutton4text.text = " ";
		}
		else 
		{
			selectlevelbutton4.interactable = false;
			selectlevelbutton4text.text = "累計答對500題";
		}
		//===================================================================================================

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
		Award1.Get[15] =  PlayerPrefs.GetInt("Award1Get15"); */
		Placeyesno.Placetime =  PlayerPrefs.GetInt("Placetime1"); //讀入成就記錄(以下相同)
		Placeyesno2.Placetime =  PlayerPrefs.GetInt("Placetime2"); //讀入成就記錄(以下相同)
		Placeyesno3.Placetime =  PlayerPrefs.GetInt("Placetime3"); //讀入成就記錄(以下相同)
		Placeyesno4.Placetime =  PlayerPrefs.GetInt("Placetime4"); //讀入成就記錄(以下相同)
		Placeyesno5.Placetime =  PlayerPrefs.GetInt("Placetime5"); //讀入成就記錄(以下相同)

	}

	// Update is called once per frame******************************************************************
	void Update () {
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

	//難度:學生******************************************************************************
	public void level1_1()
	{
		ButtonMusic.Play ();

		//難度用來判斷玩家選擇難度  
		select = 1;  
		//切到遊戲畫面
		//int randlevel = Random.Range(2, 102); //產生2~101之間的整數亂數
		//playing[randlevel] = 1;              //表示關卡已出現過  
		Application.LoadLevel("Level1_1");    //切換遊戲畫面
	}

	//難度:新鮮人********************************************************************************
	public void level2()
	{
		ButtonMusic.Play ();

		//難度用來判斷玩家選擇難度  
		select = 2;
		//切到遊戲畫面
		//int randlevel = Random.Range(2, 182); //產生2~181之間的整數亂數
		//playing[randlevel] = 1;              //表示關卡已出現過  
		Application.LoadLevel("Level1_1");    //切換遊戲畫面
	}

	//難度:職場**************************************************************************************
	public void level3()
	{
		ButtonMusic.Play ();

		//難度用來判斷玩家選擇難度  
		select = 3;
		//切到遊戲畫面
		//int randlevel = Random.Range(2, 252); //產生2~251之間的整數亂數
		//playing[randlevel] = 1;              //表示關卡已出現過  
		Application.LoadLevel("Level1_1");    //切換遊戲畫面
	}

	//難度:高階************************************************************************************
	public void level4()
	{
		ButtonMusic.Play ();

		//難度用來判斷玩家選擇難度  
		select = 4;
		//切到遊戲畫面
		//int randlevel = Random.Range(2, 302); //產生2~301之間的整數亂數
		//playing[randlevel] = 1;              //表示關卡已出現過  
		Application.LoadLevel("Level1_1");    //切換遊戲畫面
	}

	//主選單
	public void Home()
	{
		BackButtonMusic.Play ();
		Application.LoadLevel("startscreen");  //切換主選單  
	}


}
