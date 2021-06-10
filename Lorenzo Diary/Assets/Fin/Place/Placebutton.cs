//台灣
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class Placebutton : MonoBehaviour {

	//宣告變數=============================================================================================
	public GameObject yesbutton;         //宣告出航按鈕
	public GameObject Placeimage;        //宣告背景
	public GameObject Hospital1;         //宣告地方生產物品圖案
	public GameObject Food1;             //宣告地方生產物品圖案
	public Text Placetext = null;        //地名
	public Text Timetext = null;         //地方風險
	public Text Message = null;          //地方說明
	public Text P1 = null;               //出航次數
	public AudioSource ButtonMusic;      //按扭音效
	public static int yesno ;            //是否已經按下按鈕 true:已按下 false: 未按下




	// Use this for initialization
	void Start () {
		yesbutton.SetActive(false);   //隱藏出航按鈕
		Placeimage.SetActive(false);  //隱藏背景
		Placetext.text =  "";         //隱藏地名
		Hospital1.SetActive(false);   //隱藏地方生產物品圖案
		Food1.SetActive(false);       //隱藏地方生產物品圖案
		Timetext.text = "";           //隱藏地方風險
		Message.text = "";            //隱藏地方說明
		P1.text = "";                 //隱藏出航次數
		yesno = 0;                    //隱藏資訊
	}

	// Update is called once per frame
	void Update () {
		if(yesno==1)Timetext.text = "低風險"; //顯示地方風險
		else Timetext.text = "" ;             //隱藏地方風險
		//鍵盤輸入1
		if(Input.GetKeyDown("1"))push ();
		
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
			yesno = 0;                    //false: 未按下
			Placetext.text =  "";         //隱藏地名
			Hospital1.SetActive(false);   //隱藏地方生產物品圖案
			Food1.SetActive(false);       //隱藏地方生產物品圖案
			Timetext.text = "";           //隱藏地方風險
			Message.text = "";            //隱藏地方說明
			P1.text = "";                 //隱藏出航次數
		} 

		//未按下
		else
		{
			ButtonMusic.Play();
			yesbutton.SetActive(true);   //顯示按鈕
			Placeimage.SetActive(true);  //顯示背景
			//顯示地方內容
			yesno = 1;                   //true: 已按下
			Placetext.text =  "佛羅倫斯";    //顯示地名
			Hospital1.SetActive(true);   //顯示地方生產物品圖案
			Food1.SetActive(true);       //顯示地方生產物品圖案
			Message.text = "佛羅倫斯曾經長期處於羅倫佐家族控制之下，是歐洲中世紀重要的文化、商業和金融中心，並曾一度是義大利統一後的首都。麥第奇家族的財富、勢力和影響源於經商、從事羊毛加工和在毛紡同業公會中的活動。然而真正使麥第奇發達起來的是金融業務。麥第奇家族以此為基礎，逐步走上了佛羅倫斯。"; //顯示地方說明
			P1.text = "出航次數:" + Main.P1 + "次";
		}	



	}




}//主程式結束=================================================================================================
