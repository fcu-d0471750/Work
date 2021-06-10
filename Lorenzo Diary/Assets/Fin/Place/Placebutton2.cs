//墨爾本
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class Placebutton2 : MonoBehaviour {

	//宣告變數=============================================================================================
	public GameObject yesbutton;      //宣告出航按鈕
	public GameObject Placeimage;     //宣告背景
	public GameObject Weapon2;        //宣告地方生產物品圖案
	public GameObject money2;         //宣告地方生產物品圖案
	public Text Placetext = null;     //地名
	public Text Timetext = null;      //地方風險
	public Text Message = null;       //地方說明
	public Text P2 = null;            //出航次數
	public AudioSource ButtonMusic;   //按扭音效
	public static int yesno ;         //是否已經按下按鈕 true:已按下 false: 未按下




	// Use this for initialization
	void Start () {
		yesbutton.SetActive(false);   //隱藏出航按鈕
		Placeimage.SetActive(false);  //隱藏背景
		Placetext.text =  "";         //隱藏地名
		Weapon2.SetActive(false);     //隱藏地方生產物品圖案
		money2.SetActive(false);      //隱藏地方生產物品圖案
		Timetext.text = "";           //隱藏地方風險
		Message.text = "";            //隱藏地方說明
		P2.text = "";                 //隱藏出航次數
		yesno = 0;                    //隱藏資訊
	}

	// Update is called once per frame
	void Update () {
		if(yesno==1)Timetext.text = "些許風險"; //顯示地方風險
		else Timetext.text = "" ;               //隱藏地方風險  
		//鍵盤輸入2
		if(Input.GetKeyDown("2"))push ();
	}
	//====================================================================================================================================

	//按下按鈕*******************************************************************
	public void push()
	{
		//已按下
		if (yesno==1) 
		{
			ButtonMusic.Play();
			yesbutton.SetActive(false);   //隱藏按鈕
			Placeimage.SetActive(false);  //隱藏背景
			//隱藏地方內容
			yesno = 0;                   //false: 未按下
			Placetext.text =  "";        //隱藏地名
			Weapon2.SetActive(false);    //隱藏地方生產物品圖案
			money2.SetActive(false);     //隱藏地方生產物品圖案
			Timetext.text = "";          //隱藏地方風險
			Message.text = "";           //隱藏地方說明
			P2.text = "";                //隱藏出航次數
		} 

		//未按下
		else
		{
			ButtonMusic.Play();
			if(Main.P1>=5)yesbutton.SetActive(true);   //顯示按鈕
			Placeimage.SetActive(true);                //顯示背景
			//顯示地方內容
			yesno = 1;                                 //true: 已按下
			Placetext.text =  "威尼斯";                //顯示地名
			Weapon2.SetActive(true);                   //顯示地方生產物品圖案
			money2.SetActive(true);                    //顯示地方生產物品圖案
			Message.text = "威尼斯是義大利東北部著名的旅遊與工業城市，也是威尼托地區的首府。威尼斯共和國是中世紀和文藝復興時期的主要金融和海運力量，是十字軍東征和勒班陀戰役的集結地，也是從13世紀直到17世紀末的一個非常重要的商業。"; //顯示地方說明
			if(Main.P1>=5)P2.text = "出航次數:" + Main.P2 + "次";
			else if(Main.P1<5)P2.text ="需出航佛羅倫斯5次";   
		}	



	}

}//主程式結束=================================================================================================
