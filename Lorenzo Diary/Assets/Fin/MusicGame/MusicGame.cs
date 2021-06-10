//音樂條
using UnityEngine;
using System.Collections;
using UnityEngine.UI; //使用UI

public class MusicGame : MonoBehaviour {

	//基本變數
	public static int Directionstate;  //MusicBar 現在狀態 1:上 2:下 3:左 4:右
	float time=0.0f;                   //用於計算deltaTime
	public static int Combo;           //Combo數    
	public Text Combotext;    	       //Combo訊息
	public Animation CombotextAnimate; //Combo訊息動畫
	public Text Pricetext;   		   //評價訊息
	public Animation PricetextAnimate; //Price訊息動畫
	public Text CompleteText; 		   //完美程度訊息
	public Animation MusicBarPart;     //音符消除動畫
	public  GameObject  MusicUPAnimate;    //音樂符號:上 觸發動畫
	public  GameObject  MusicDownAnimate;  //音樂符號:下 觸發動畫
	public  GameObject  MusicLeftAnimate;  //音樂符號:左 觸發動畫
	public  GameObject  MusicRightAnimate; //音樂符號:右 觸發動畫
	public  GameObject  BackAnimate;       //返回音樂選擇淡出動畫
	public AudioSource  ButtonMusic;       //按鍵音效
	public AudioSource  MusicFrameAudiSource; //音符消除音效
	public Image ScoreIma;                 //進度圖
	public Image TimeScoreIma;             //時間進度圖
	public Image MusicEndBack;             //音樂結束背景
	float    Timetemp;
	public Animation ComboAnimate;         //玩家到達一定Combo數的動畫
	public Text      ComboAnimateText;
	bool  ComboAnimatePlay;                //是否播放過ComboAnimate true:播放過 false;未播放
	public Animation SaveImage;            //儲存中動畫
	public static bool MissBool = false;   //是否MISS true:發生MISS fasle:未發生MISS
	public Text  ScoreText;                //分數Text
	public Animation ScoretextAnimate;     //Score訊息動畫

	//關卡
	public GameObject  Music1; //音樂關卡1
	public GameObject  Music2; //音樂關卡2
	public GameObject  Music3; //音樂關卡3
	public GameObject  Music4; //音樂關卡4
	public GameObject  Music5; //音樂關卡5

	public AudioSource MusicAudi1; //音樂1      
	public AudioSource MusicAudi2; //音樂2      
	public AudioSource MusicAudi3; //音樂3      
	public AudioSource MusicAudi4; //音樂4      
	public AudioSource MusicAudi5; //音樂5      

	public AudioSource DestoryMusicUp;
	public AudioSource DestoryMusicDown;
	public AudioSource DestoryMusicLeft;
	public AudioSource DestoryMusicRight;

	//評價變數
	float GreatCount;
	public Text Greattext;
	int GoodCount;
	public Text Goodtext;
	int BadCount;
	public Text Badtext;
	public static int MissCount;
	public Text Misstext;
	float Completetext; 


	//背景
	public Text NameText;           //音樂名稱訊息
	int GreatMax;                   //Great最大數量
	float Musictime=0.0f;           //倒數音樂總時間
	float timef;                    //用於計算deltaTime

	//暫停
	public static bool MusicPause = false; //音樂暫停 true:暫停 false:未暫停
	public static bool  MusicEnd = false;                //音樂結束 true;結束 false:未結束
	public GameObject  MusicPauseButton;   //音樂中途暫停Button

	//結算分數
	public GameObject SumBackGround;//結算畫面
	public Text MusicBackText1;
	int People;
	int Money;
	bool Finish = false;   //遊戲是否結束 true:已結束 false:未結束
	float TimeEnd;         //獲得資源倒數時間
	public Animation MusicConversationAnimation;    //音樂結束人物框 
	public Text      MusicConsersationText;         //音樂結束人物對話框

	//===================================================================================================================
	// Use this for initialization
	void Start () {
		//恢復初始值**********************************************************
		Combo = 0;
		GreatCount = 0;
		GoodCount = 0;
		BadCount = 0;
		MissCount = 0;
		Musictime = 0.0f;
		MusicEnd = false;
		MusicPause = false;
		ComboAnimatePlay = false;
		Timetemp = MusicSelect.MusicMaxTime;

		Music1.SetActive (false);           //關卡關閉
		Music2.SetActive (false);           //關卡關閉
		Music3.SetActive (false);           //關卡關閉
		Music4.SetActive (false);           //關卡關閉
		Music5.SetActive (false);           //關卡關閉
		BackAnimate.SetActive (false);      //返回音樂選擇淡出動畫關閉
		SumBackGround.SetActive (false);    //結算畫面關閉
		MusicPauseButton.SetActive (false); //隱藏音樂中途暫停Button



		//顯示音樂資訊*******************************************************
		if (MusicSelect.MusicLevel == 1) {
			Music1.SetActive (true);              //關卡開啟
			NameText.text = "在鈴聲中的卡菈"; //音樂名稱
			MusicAudi1.Play();            //音樂播放
		} else if (MusicSelect.MusicLevel == 2) {
			Music2.SetActive (true);              //關卡開啟
			NameText.text = "小步舞曲";          //音樂名稱
			MusicAudi2.enabled = true;            //音樂播放
		} else if (MusicSelect.MusicLevel == 3) {
			Music3.SetActive (true);                 //關卡開啟
			NameText.text = "耶穌盼望的喜悅"; //音樂名稱
			MusicAudi3.enabled = true;               //音樂播放
		} else if (MusicSelect.MusicLevel == 4) { 
			Music4.SetActive (true);              //關卡開啟
			NameText.text = "安魂彌撒曲:末日經";     //音樂名稱
			MusicAudi4.enabled = true;            //音樂播放
		} else if (MusicSelect.MusicLevel == 5) {
			Music5.SetActive (true);              //關卡開啟
			NameText.text = "婚禮的邀請函";              //音樂名稱
			MusicAudi5.enabled = true;            //音樂播放
		}



		MusicUPAnimate.SetActive(false);     //隱藏動畫 音樂符號:上 
		MusicDownAnimate.SetActive(false);   //隱藏動畫 音樂符號:下 
		MusicLeftAnimate.SetActive(false);   //隱藏動畫 音樂符號:左 
		MusicRightAnimate.SetActive(false);  //隱藏動畫 音樂符號:右 

		Main.peoplesum =  PlayerPrefs.GetInt("peoplesum1"); //讀入成就記錄(以下相同)
		Main.moneysum  =  PlayerPrefs.GetInt("moneysum1");  //讀入成就記錄(以下相同)

		Placeyesno.Placetime =  PlayerPrefs.GetInt("Placetime1"); //讀入成就記錄(以下相同)
		Placeyesno2.Placetime =  PlayerPrefs.GetInt("Placetime2"); //讀入成就記錄(以下相同)
		Placeyesno3.Placetime =  PlayerPrefs.GetInt("Placetime3"); //讀入成就記錄(以下相同)
		Placeyesno4.Placetime =  PlayerPrefs.GetInt("Placetime4"); //讀入成就記錄(以下相同)
		Placeyesno5.Placetime =  PlayerPrefs.GetInt("Placetime5"); //讀入成就記錄(以下相同)

	}
	
	// Update is called once per frame
	void Update () {
		
		//音樂暫停*************************************************************************************************
		if(Input.GetKeyDown("escape") && !MusicEnd){
			if (MusicPause) {
				MusicPause = false;
				MusicPauseButton.SetActive (false);
			} else {
				MusicPause = true;
				MusicPauseButton.SetActive(true);
			}
		} 
			
		//如果船已經出航*****************************************************************
		timef +=Time.deltaTime;   //記錄時間
		if (timef >= 1) { //如果時間>=1 && Placetime[0]!=0 && 已按下按鈕 
			if(Placeyesno.Placetime!=30 && Placeyesno.Placetime!=0) Placeyesno.Placetime--;
			if(Placeyesno2.Placetime!=60 && Placeyesno2.Placetime!=0) Placeyesno2.Placetime--;
			if(Placeyesno3.Placetime!=80 && Placeyesno3.Placetime!=0) Placeyesno3.Placetime--;
			if(Placeyesno4.Placetime!=100 && Placeyesno4.Placetime!=0) Placeyesno4.Placetime--;
			if(Placeyesno5.Placetime!=120 && Placeyesno5.Placetime!=0) Placeyesno5.Placetime--;
			timef = 0;
		}

		if(!MusicPause){  //如果音樂暫停沒有啟用================================================================================

        //播放音樂**************************************************************************
			MusicAudi1.UnPause();
			MusicAudi2.UnPause();
			MusicAudi3.UnPause();
			MusicAudi4.UnPause();
			MusicAudi5.UnPause();
			//print ("s");
		//使用者輸入上下左右****************************************************************
		if (Input.GetKey ("up")||Input.GetKey (KeyCode.S)){
			Directionstate = 1;
		}

		else if (Input.GetKey ("down")||Input.GetKey (KeyCode.W)){
			Directionstate = 2;
		}

		else if (Input.GetKey ("left")||Input.GetKey (KeyCode.A)){
			Directionstate = 3;
		}

		else if (Input.GetKey ("right")||Input.GetKey (KeyCode.D)){
			Directionstate = 4;
		}
		else if (Input.GetKey(KeyCode.Space)){
			Directionstate = 5;
		}
		time += Time.deltaTime; //時間增加
		if(time>=0.25f){Directionstate = 0;
			time = 0.0f;

		}

		//印出基本訊息****************************************************************
		Combotext.text = Combo + "\nFeeling";
		Greattext.text = "Great " + (int)GreatCount;
		Goodtext.text =  "Good " + GoodCount;
		Badtext.text =   "Bad "  + BadCount;
		Misstext.text = "Miss " + MissCount;

		Completetext = (GreatCount / MusicSelect.MusicGreat) * 100;
		CompleteText.text =  Completetext.ToString("0.00")+ "%";
		ScoreIma.fillAmount = GreatCount/MusicSelect.MusicGreat;   //進度圖變化
		TimeScoreIma.fillAmount = MusicSelect.MusicMaxTime / Timetemp;
		//發生MISS
		if (MissBool) {
			Pricetext.color = new Color (255f, 255f, 255f);
			Pricetext.text = "MISS";
			PricetextAnimate.Play ();
			MissBool = false;
		}

		//結算畫面********************************************************************
		Musictime = Musictime + Time.deltaTime;    //計算1秒
        
		if (Musictime > 1.0f) {
			MusicSelect.MusicMaxTime = MusicSelect.MusicMaxTime - 1.0f;  //每過1秒,音樂總時間-1秒
			if (MusicSelect.MusicMaxTime < 0) {                          //如果音樂總時間 < 0 ，則遊戲結束設為true
				Finish = true;
				MusicSelect.MusicMaxTime = 10000000000.0f;               //防止玩家閒置太久
			}
			Musictime = 0.0f;                                            //重新計算0
		}

		//玩家到達一定Combo數的動畫******************************************************
			if (!ComboAnimatePlay && (Combo % 5) == 0 && Combo != 0) {
				ComboAnimateText.text = "" + Combo;
				ComboAnimate.Play ();
				ComboAnimatePlay = true;   //防止ComboAinmate一直播放
			} else {
				ComboAnimatePlay = false;
			}

		if (Finish) {
			SumBackGround.SetActive (true);   //結算畫面顯示
			MusicPauseButton.SetActive(false);//隱藏音樂暫停button
			MusicEnd = true;                  //音樂結束
			MusicEndBack.color = new Color(1,1,1,MusicEndBack.color.a + 0.01f);

			TimeEnd += Time.deltaTime;
			if(TimeEnd<3.0f){
			 People = UnityEngine.Random.Range (1, ((int)GreatCount+GoodCount)*20);    
			 Money  = UnityEngine.Random.Range (1, ((int)GreatCount+GoodCount)*20);   
			}
			else if(TimeEnd>=3.0f) {
			Main.peoplesum = Main.peoplesum + People;      //得到資源
			Main.moneysum  = Main.moneysum + Money;        //得到資源
			Finish = false;
			MusicConversation();
			MusicConversationAnimation.Play ();
			SaveImage.Play ();
			}
			MusicBackText1.text = "⊕獲得 人口   X " + People +"\n⊕獲得 金錢   X " + Money;//印出訊息


			//紀錄
			PlayerPrefs.SetInt("peoplesum1", Main.peoplesum );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
			PlayerPrefs.SetInt("moneysum1", Main.moneysum );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		

			//紀錄最高分
			if (((GreatCount) * 100) /  MusicSelect.MusicGreat > MusicSelect.MusicSave [1]) {
				MusicSelect.MusicSave [1] = ((GreatCount) * 100) /  MusicSelect.MusicGreat;
				PlayerPrefs.SetFloat("Music1", MusicSelect.MusicSave [1] );
				PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
			}
			else if ((GreatCount / MusicSelect.MusicGreat) * 100 > MusicSelect.MusicSave [2]) {
				MusicSelect.MusicSave [2] = ( GreatCount / MusicSelect.MusicGreat ) * 100;
				PlayerPrefs.SetFloat("Music2", MusicSelect.MusicSave [2] );
				PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
			}
			else if ((GreatCount / MusicSelect.MusicGreat) * 100 > MusicSelect.MusicSave [3]) {
				MusicSelect.MusicSave [3] = (GreatCount / MusicSelect.MusicGreat ) * 100;
				PlayerPrefs.SetFloat("Music3", MusicSelect.MusicSave [3] );
				PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
			}
			else if ((GreatCount / MusicSelect.MusicGreat) * 100 > MusicSelect.MusicSave [4]) {
				MusicSelect.MusicSave [4] = ( GreatCount / MusicSelect.MusicGreat ) * 100;
				PlayerPrefs.SetFloat("Music4", MusicSelect.MusicSave [4] );
				PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
			}
			else if ((GreatCount / MusicSelect.MusicGreat) * 100 > MusicSelect.MusicSave [5]) {
				MusicSelect.MusicSave [5] = ( GreatCount / MusicSelect.MusicGreat ) * 100;
				PlayerPrefs.SetFloat("Music5", MusicSelect.MusicSave [5] );
				PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
			}
				
		 }

		}
		else{//音樂暫停
			//print("a");
			MusicAudi1.Pause ();
			MusicAudi2.Pause ();
			MusicAudi3.Pause ();
			MusicAudi4.Pause ();
			MusicAudi5.Pause ();
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

	//返回音樂選擇畫面
	public void Back(){
		ButtonMusic.Play ();
		BackAnimate.SetActive (true);   //返回音樂選擇淡出動畫關閉
		//Application.LoadLevelAsync ("MusicSelect");
	}

	//音樂繼續
	public void MusicContinue(){
		MusicPause = false;
		MusicPauseButton.SetActive (false);
	}

	//音樂結束對話框
	public void MusicConversation(){
		int rand;

		rand = UnityEngine.Random.Range (1, 11);

		//音樂結束
		if (rand == 1)
			MusicConsersationText.text = "真是一場好的音樂會!!!";
		else if (rand == 2)
			MusicConsersationText.text = "漂亮的演奏!!!";
		else if (rand == 3)
			MusicConsersationText.text = "節奏要再抓準一點。";
		else if (rand == 4)
			MusicConsersationText.text = "要再多練習幾次。";
		else if (rand == 5)
			MusicConsersationText.text = "注意每個音符的位置!!!";
		else if (rand == 6)
			MusicConsersationText.text = "聽眾們聽的入神了......";
		else if (rand == 7)
			MusicConsersationText.text = "是不是缺乏練習?";
		else if (rand == 8)
			MusicConsersationText.text = "教宗等待著表演。";
		else if (rand == 9)
			MusicConsersationText.text = "記住這次的表現。";
		else if (rand == 10)
			MusicConsersationText.text = "多練習其它的曲子......";
		else
			MusicConsersationText.text = "有進步的空間......";
		
	}

	//Bar碰到音樂符號===================================================================================================================
	void OnTriggerStay2D(Collider2D Col)
	{
		Transform testTra ;
		Transform parentTra;

		/*if (Combo == 0) {
			Pricetext.color = new Color (255f, 255f, 255f);
			Pricetext.text = "MISS";
			PricetextAnimate.Play ();
		}*/

		//上**********************************************************
		if (Col.tag == "MusicUP" && Directionstate == 1) {
			Combo++;
			CombotextAnimate.Play ();
			PricetextAnimate.Play ();
			DestoryMusicUp.Play ();
			MusicBarPart.Play ();
			MusicUPAnimate.SetActive(true);
			if (Col.transform.localPosition.y <= (-387.29) && Col.transform.localPosition.y >= (-387.389)) {
				GreatCount++;
				//Pricetext.color = new Color (200.0f, 255.0f, 186.0f);
				Pricetext.text = "<color=#C8FFBA>GREAT</color>";
			} else if ((Col.transform.localPosition.y <= (-387.24) && Col.transform.localPosition.y >= (-387.289)) || (Col.transform.localPosition.y <= (-387.39) && Col.transform.localPosition.y >= (-387.439))) {
				GoodCount++;
				//Pricetext.color = new Color (186.0f, 249.0f, 255.0f);
				Pricetext.text = "<color=#BAF9FF>GOOD</color>";
			} else if ((Col.transform.localPosition.y <= (-387.20) && Col.transform.localPosition.y >= (-387.239)) || (Col.transform.localPosition.y <= (-387.44) && Col.transform.localPosition.y >= (-387.489))) {
				BadCount++;
				//Pricetext.color = new Color (255.0f, 118.0f, 132.0f);
				Pricetext.text = "<color=#FF7684>BAD</color>";
			} 
			ScoreText.text = "" + (GreatCount*10367 + GoodCount*5794 + BadCount*3973);
			ScoretextAnimate.Play ();
		}
		//下**********************************************************
		else if(Col.tag == "MusicDown" && Directionstate == 2){
			Combo++;
			CombotextAnimate.Play ();
			PricetextAnimate.Play ();
			DestoryMusicDown.Play ();
			MusicBarPart.Play ();
			MusicDownAnimate.SetActive(true);
			if (Col.transform.localPosition.y <= (-387.29) && Col.transform.localPosition.y >= (-387.389)) {
				GreatCount++;
				//Pricetext.color = new Color (200.0f, 255.0f, 186.0f);
				Pricetext.text = "<color=#C8FFBA>GREAT</color>";
			} else if ((Col.transform.localPosition.y <= (-387.24) && Col.transform.localPosition.y >= (-387.289)) || (Col.transform.localPosition.y <= (-387.39) && Col.transform.localPosition.y >= (-387.439))) {
				GoodCount++;
				//Pricetext.color = new Color (186.0f, 249.0f, 255.0f);
				Pricetext.text = "<color=#BAF9FF>GOOD</color>";
			} else if ((Col.transform.localPosition.y <= (-387.20) && Col.transform.localPosition.y >= (-387.239)) || (Col.transform.localPosition.y <= (-387.44) && Col.transform.localPosition.y >= (-387.489))) {
				BadCount++;
				//Pricetext.color = new Color (255.0f, 118.0f, 132.0f);
				Pricetext.text = "<color=#FF7684>BAD</color>";
			}
			ScoreText.text = "" + (GreatCount*10367 + GoodCount*5794 + BadCount*3973);
			ScoretextAnimate.Play ();
		}
		//左**********************************************************
		else if(Col.tag == "MusicLeft" && Directionstate == 3){
			Combo++;
			CombotextAnimate.Play ();
			PricetextAnimate.Play ();
			DestoryMusicLeft.Play ();
			MusicBarPart.Play ();
			MusicLeftAnimate.SetActive(true);
			if (Col.transform.localPosition.y <= (-387.29) && Col.transform.localPosition.y >= (-387.389)) {
				GreatCount++;
				//Pricetext.color = new Color (200.0f, 255.0f, 186.0f);
				Pricetext.text = "<color=#C8FFBA>GREAT</color>";
			} else if ((Col.transform.localPosition.y <= (-387.24) && Col.transform.localPosition.y >= (-387.289)) || (Col.transform.localPosition.y <= (-387.39) && Col.transform.localPosition.y >= (-387.439))) {
				GoodCount++;
				//Pricetext.color = new Color (186.0f, 249.0f, 255.0f);
				Pricetext.text = "<color=#BAF9FF>GOOD</color>";
			} else if ((Col.transform.localPosition.y <= (-387.20) && Col.transform.localPosition.y >= (-387.239)) || (Col.transform.localPosition.y <= (-387.44) && Col.transform.localPosition.y >= (-387.489))) {
				BadCount++;
				//Pricetext.color = new Color (255.0f, 118.0f, 132.0f);
				Pricetext.text = "<color=#FF7684>BAD</color>";
			}
			ScoreText.text = "" + (GreatCount*10367 + GoodCount*5794 + BadCount*3973);
			ScoretextAnimate.Play ();
		}
		//右**********************************************************
		else if(Col.tag == "MusicRight" && Directionstate == 4){
			Combo++;
			CombotextAnimate.Play ();
			PricetextAnimate.Play ();
			DestoryMusicRight.Play ();
			MusicBarPart.Play ();
			MusicRightAnimate.SetActive(true);
			if (Col.transform.localPosition.y <= (-387.29) && Col.transform.localPosition.y >= (-387.389)) {
				GreatCount++;
				//Pricetext.color = new Color (200.0f, 255.0f, 186.0f);
				Pricetext.text = "<color=#C8FFBA>GREAT</color>";
			} else if ((Col.transform.localPosition.y <= (-387.24) && Col.transform.localPosition.y >= (-387.289)) || (Col.transform.localPosition.y <= (-387.39) && Col.transform.localPosition.y >= (-387.439))) {
				GoodCount++;
				//Pricetext.color = new Color (186.0f, 249.0f, 255.0f);
				Pricetext.text = "<color=#BAF9FF>GOOD</color>";
			} else if ((Col.transform.localPosition.y <= (-387.20) && Col.transform.localPosition.y >= (-387.239)) || (Col.transform.localPosition.y <= (-387.44) && Col.transform.localPosition.y >= (-387.489))) {
				BadCount++;
				//Pricetext.color = new Color (255.0f, 118.0f, 132.0f);
				Pricetext.text = "<color=#FF7684>BAD</color>";
			}
			ScoreText.text = "" + (GreatCount*10367 + GoodCount*5794 + BadCount*3973);
			ScoretextAnimate.Play ();
		}

		//中間**********************************************************
		else if(Col.tag == "MusicSpace" && Directionstate == 5){
			//Combo++;
			CombotextAnimate.Play ();
			PricetextAnimate.Play ();
			//DestoryMusicRight.Play ();
			MusicBarPart.Play ();
			//MusicRightAnimate.SetActive(true);
			Pricetext.text = "<color=#000000>Get</color>";
			int rand = UnityEngine.Random.Range (500, 2000); 
			ScoreText.text = "" + (GreatCount*10367 + GoodCount*5794 + BadCount*3973 + rand);
			ScoretextAnimate.Play ();
		}
			
	} 

}//結束=======-511.935 -387.34 0.7 5==============================================================================================
