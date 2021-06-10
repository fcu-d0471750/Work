//音樂關卡選項
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class MusicSelect : MonoBehaviour {

	//宣告變數*********************************************************************************************
	public GameObject MusicSelecttoMusicFadeOut; //音樂關卡選項到戰爭的淡出動畫
	public GameObject MusicSelecttoMainFadeOut;  //音樂關卡選項到主畫面的淡出動畫
	public GameObject StartButton;               //開始按鈕
	public GameObject PersonImage1;              //人物圖片1
	public GameObject PersonImage2;              //人物圖片2
	public GameObject PersonImage3;              //人物圖片3
	public GameObject PersonImage4;              //人物圖片4
	public GameObject PersonImage5;              //人物圖片5
	public GameObject BackImage1;                //背景圖片1
	public GameObject BackImage2;                //背景圖片2
	public GameObject BackImage3;                //背景圖片3
	public GameObject BackImage4;                //背景圖片4
	public GameObject BackImage5;                //背景圖片5

	public static int MusicLevel = 0;                      //音樂關卡代號
	public static float[] MusicSave = new float[10];       //每首音樂最高分紀錄


	public AudioSource Song1AudioSource; //音樂1
	public AudioSource Song2AudioSource; //音樂2
	public AudioSource Song3AudioSource; //音樂3
	public AudioSource Song4AudioSource; //音樂4
	public AudioSource Song5AudioSource; //音樂5
	public AudioSource BackMusic;        //返回音效
	public AudioSource ButtonVoice;      //按鈕音效

	public static float MusicGreat;     //音樂所有Great數量
	public static float MusicMaxTime;   //音樂總長度

	public GameObject SongMaxparticle1; //音樂滿分粒子
	public GameObject SongMaxparticle2; //音樂滿分粒子
	public GameObject SongMaxparticle3; //音樂滿分粒子
	public GameObject SongMaxparticle4; //音樂滿分粒子
	public GameObject SongMaxparticle5; //音樂滿分粒子

	public Text MusicDetail;            //音樂細節Text
	public Animation MusicDetailAnimate;//音樂細節動畫

	float timef;

	//訊息顯示*************************************************************************************************
	public Text MusicName;               //音樂名稱
	public Text MusicScoreText;          //音樂最高分數

	// Use this for initialization
	void Start () {
		MusicSelecttoMusicFadeOut.SetActive(false);//隱藏音樂關卡選項到主畫面的淡出動畫
		MusicSelecttoMainFadeOut.SetActive(false); //隱藏音樂關卡選項到主畫面的淡出動畫
		StartButton.SetActive(false);              //隱藏開始按鈕
		PersonImage1.SetActive(false);             //隱藏人物圖片1
		PersonImage2.SetActive(false);             //隱藏人物圖片2
		PersonImage3.SetActive(false);             //隱藏人物圖片3
		PersonImage4.SetActive(false);             //隱藏人物圖片4
		PersonImage5.SetActive(false);             //隱藏人物圖片5
		BackImage1.SetActive(false);               //隱藏背景圖片1
		BackImage2.SetActive(false);               //隱藏背景圖片2

		Song1AudioSource.Pause ();
		Song2AudioSource.Pause ();
		Song3AudioSource.Pause ();
		Song4AudioSource.Pause ();
		Song5AudioSource.Pause ();

		Song1 ();


		//讀入紀錄
		MusicSave[1] = PlayerPrefs.GetFloat("Music1"); //讀入分數記錄(以下相同)
		MusicSave[2] = PlayerPrefs.GetFloat("Music2"); //讀入分數記錄(以下相同)
		MusicSave[3] = PlayerPrefs.GetFloat("Music3"); //讀入分數記錄(以下相同)
		MusicSave[4] = PlayerPrefs.GetFloat("Music4"); //讀入分數記錄(以下相同)
		MusicSave[5] = PlayerPrefs.GetFloat("Music5"); //讀入分數記錄(以下相同)

		Placeyesno.Placetime =  PlayerPrefs.GetInt("Placetime1"); //讀入成就記錄(以下相同)
		Placeyesno2.Placetime =  PlayerPrefs.GetInt("Placetime2"); //讀入成就記錄(以下相同)
		Placeyesno3.Placetime =  PlayerPrefs.GetInt("Placetime3"); //讀入成就記錄(以下相同)
		Placeyesno4.Placetime =  PlayerPrefs.GetInt("Placetime4"); //讀入成就記錄(以下相同)
		Placeyesno5.Placetime =  PlayerPrefs.GetInt("Placetime5"); //讀入成就記錄(以下相同)

		if (MusicSave [1] >= 100.0f) SongMaxparticle1.SetActive (true);
		else SongMaxparticle1.SetActive (false);
		if (MusicSave [2] >= 100.0f) SongMaxparticle2.SetActive (true);
		else SongMaxparticle2.SetActive (false);
		if (MusicSave [3] >= 100.0f) SongMaxparticle3.SetActive (true);
		else SongMaxparticle3.SetActive (false);
		if (MusicSave [4] >= 100.0f) SongMaxparticle4.SetActive (true);
		else SongMaxparticle4.SetActive (false);
		if (MusicSave [5] >= 100.0f) SongMaxparticle5.SetActive (true);
		else SongMaxparticle5.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		//鍵盤輸入(返回)
		if(Input.GetKeyDown("escape"))MusicSelecttoMain();

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

	}//Update結束
		

	//切換動畫********************************************************************************
	//返回到主畫面
	public void MusicSelecttoMain(){
		BackMusic.Play ();
		MusicSelecttoMainFadeOut.SetActive(true);//顯示音樂關卡選項到主畫面的淡出動畫
	}

	//切換到音樂關卡
	public void MusicSelecttoMusic(){
		ButtonVoice.Play ();
		MusicSelecttoMusicFadeOut.SetActive(true);//顯示音樂關卡選項到主畫面的淡出動畫
	}

	//音樂關卡選擇*****************************************************************************
	public void Song1(){
		MusicLevel = 1;         //音樂關卡代號
		MusicMaxTime = 116.0f;  //音樂總長度123
		MusicGreat = 82.0f;     //音樂所有Great數量
		MusicName.text = "在鈴聲中的卡菈";
		MusicScoreText.text = "最高分數: " + MusicSave [1].ToString("0.00") + "分";
		MusicDetail.text = "作曲人: Quincas Moreira 總音符數: 82個"; //音樂細節Text
		MusicDetailAnimate.Play ();               //音樂細節動畫播放
		StartButton.SetActive(true);              //顯示開始按鈕
		Song1AudioSource.UnPause();
		Song2AudioSource.Pause ();
		Song3AudioSource.Pause ();
		Song4AudioSource.Pause ();
		Song5AudioSource.Pause ();
		PersonImage1.SetActive(true);             //顯示人物圖片1
		PersonImage2.SetActive(false);            //隱藏人物圖片2
		PersonImage3.SetActive(false);            //隱藏人物圖片3
		PersonImage4.SetActive(false);            //隱藏人物圖片4
		PersonImage5.SetActive(false);            //隱藏人物圖片5
		BackImage1.SetActive(true);               //顯示背景圖片1
		BackImage2.SetActive(false);              //隱藏背景圖片2
		BackImage3.SetActive(false);              //隱藏背景圖片3
		BackImage4.SetActive(false);              //隱藏背景圖片4
		BackImage5.SetActive(false);              //隱藏背景圖片5
		//ButtonVoice.Play();

	}

	public void Song2(){
		MusicLevel = 2;         //音樂關卡代號
		MusicMaxTime = 115.0f;  //音樂總長度
		MusicGreat = 63.0f;     //音樂所有Great數量
		MusicName.text = "小步舞曲";
		MusicScoreText.text = "最高分數: " + MusicSave [2].ToString("0.00") + "分";
		MusicDetail.text = "作曲人: Johann Sebastian Bach 總音符數: 63個"; //音樂細節Text
		MusicDetailAnimate.Play ();               //音樂細節動畫播放
		StartButton.SetActive(true);              //顯示開始按鈕
		Song1AudioSource.Pause ();
		Song2AudioSource.UnPause();
		Song3AudioSource.Pause ();
		Song4AudioSource.Pause ();
		Song5AudioSource.Pause ();
		PersonImage1.SetActive(false);            //隱藏人物圖片1
		PersonImage2.SetActive(true);             //顯示人物圖片2
		PersonImage3.SetActive(false);            //隱藏人物圖片3
		PersonImage4.SetActive(false);            //隱藏人物圖片4
		PersonImage5.SetActive(false);            //隱藏人物圖片5
		BackImage1.SetActive(false);              //隱藏背景圖片1
		BackImage2.SetActive(true);               //顯示背景圖片2
		BackImage3.SetActive(false);              //隱藏背景圖片3
		BackImage4.SetActive(false);              //隱藏背景圖片4
		BackImage5.SetActive(false);              //隱藏背景圖片5
		//ButtonVoice.Play();

	}

	public void Song3(){
		MusicLevel = 3;         //音樂關卡代號
		MusicMaxTime = 88.0f;  //音樂總長度95
		MusicGreat = 56.0f;     //音樂所有Great數量
		MusicName.text = "耶穌盼望的喜悅";
		MusicScoreText.text = "最高分數: " + MusicSave [3].ToString("0.00") + "分";
		MusicDetail.text = "作曲人: Johann Sebastian Bach 總音符數: 56個"; //音樂細節Text
		MusicDetailAnimate.Play ();               //音樂細節動畫播放
		StartButton.SetActive(true);              //顯示開始按鈕
		Song1AudioSource.Pause ();
		Song2AudioSource.Pause ();
		Song3AudioSource.UnPause();
		Song4AudioSource.Pause ();
		Song5AudioSource.Pause ();
		PersonImage1.SetActive(false);            //隱藏人物圖片1
		PersonImage2.SetActive(false);            //隱藏人物圖片2
		PersonImage3.SetActive(true);             //顯示人物圖片3
		PersonImage4.SetActive(false);            //隱藏人物圖片4
		PersonImage5.SetActive(false);            //隱藏人物圖片5
		BackImage1.SetActive(false);              //隱藏背景圖片1
		BackImage2.SetActive(false);              //隱藏背景圖片2
		BackImage3.SetActive(true);               //顯示背景圖片3
		BackImage4.SetActive(false);              //隱藏背景圖片4
		BackImage5.SetActive(false);              //隱藏背景圖片5
		//ButtonVoice.Play();
	}

	public void Song4(){
		MusicLevel = 4;         //音樂關卡代號
		MusicMaxTime = 118.0f;  //音樂總長度
		MusicGreat = 83.0f;     //音樂所有Great數量
		MusicName.text = "安魂彌撒曲:末日經";
		MusicScoreText.text = "最高分數: " + MusicSave [4].ToString("0.00") + "分";
		MusicDetail.text = "作曲人: Wolfgang Amadeus Mozart 總音符數: 83個"; //音樂細節Text
		MusicDetailAnimate.Play ();               //音樂細節動畫播放
		StartButton.SetActive(true);              //顯示開始按鈕
		Song1AudioSource.Pause ();
		Song2AudioSource.Pause ();
		Song3AudioSource.Pause ();
		Song4AudioSource.UnPause();
		Song5AudioSource.Pause ();
		PersonImage1.SetActive(false);            //隱藏人物圖片1
		PersonImage2.SetActive(false);            //隱藏人物圖片2
		PersonImage3.SetActive(false);            //隱藏人物圖片3
		PersonImage4.SetActive(true);             //顯示人物圖片4
		PersonImage5.SetActive(false);            //隱藏人物圖片5
		BackImage1.SetActive(false);              //隱藏背景圖片1
		BackImage2.SetActive(false);              //隱藏背景圖片2
		BackImage3.SetActive(false);              //隱藏背景圖片3
		BackImage4.SetActive(true);               //顯示背景圖片4
		BackImage5.SetActive(false);              //隱藏背景圖片5
		//ButtonVoice.Play();
	}

	public void Song5(){
		MusicLevel = 5;         //音樂關卡代號
		MusicMaxTime = 104.0f;  //音樂總長度
		MusicGreat = 98.0f;     //音樂所有Great數量
		MusicName.text = "婚禮的邀請函";
		MusicScoreText.text = "最高分數: " + MusicSave [5].ToString("0.00") + "分";
		MusicDetail.text = "作曲人: Jason Farnham 總音符數: 98個"; //音樂細節Text
		MusicDetailAnimate.Play ();               //音樂細節動畫播放
		StartButton.SetActive(true);              //顯示開始按鈕
		Song1AudioSource.Pause ();
		Song2AudioSource.Pause ();
		Song3AudioSource.Pause ();
		Song4AudioSource.Pause ();
		Song5AudioSource.UnPause();
		PersonImage1.SetActive(false);            //隱藏人物圖片1
		PersonImage2.SetActive(false);            //隱藏人物圖片2
		PersonImage3.SetActive(false);            //隱藏人物圖片3
		PersonImage4.SetActive(false);            //隱藏人物圖片4
		PersonImage5.SetActive(true);             //顯示人物圖片5
		BackImage1.SetActive(false);              //隱藏背景圖片1
		BackImage2.SetActive(false);              //隱藏背景圖片2
		BackImage3.SetActive(false);              //隱藏背景圖片3
		BackImage4.SetActive(false);              //隱藏背景圖片4
		BackImage5.SetActive(true);               //顯示背景圖片5
		//ButtonVoice.Play();
	}


}//MusicSelect結束
