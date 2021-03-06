//馬德里
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class Placebutton3 : MonoBehaviour {

	//宣告變數=============================================================================================
	public GameObject yesbutton;       //宣告出航按鈕
	public GameObject Placeimage;      //宣告背景
	public GameObject people3;         //宣告地方生產物品圖案
	public Text Placetext = null;      //地名
	public Text Timetext = null;       //地方風險
	public Text Message = null;        //地方說明
	public Text P3 = null;             //出航次數
	public AudioSource ButtonMusic;    //按扭音效
	public static int yesno ;          //是否已經按下按鈕 true:已按下 false: 未按下




	// Use this for initialization
	void Start () {
		yesbutton.SetActive(false);   //隱藏出航按鈕
		Placeimage.SetActive(false);  //隱藏背景
		Placetext.text =  "";         //隱藏地名
		people3.SetActive(false);     //隱藏地方生產物品圖案
		Timetext.text = "";           //隱藏地方風險
		Message.text = "";            //隱藏地方說明
		P3.text = "";                 //隱藏出航次數
		yesno = 0;                    //隱藏資訊

	}

	// Update is called once per frame
	void Update () {
		if(yesno==1)Timetext.text = "高風險"; //顯示地方風險
		else Timetext.text = "" ;             //隱藏地方風險
		//鍵盤輸入3
		if(Input.GetKeyDown("3"))push ();

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
			people3.SetActive(false);     //隱藏地方生產物品圖案
			Timetext.text = "";           //隱藏地方風險
			Message.text = "";            //隱藏地方說明
			P3.text = "";                 //隱藏出航次數
		} 

		//未按下
		else
		{
			ButtonMusic.Play();
			if(Main.P2>=10)yesbutton.SetActive(true);   //顯示按鈕
			Placeimage.SetActive(true);                //顯示背景
			//顯示地方內容
			yesno = 1;                                 //true: 已按下
			Placetext.text =  "沼都";                //顯示地名
			people3.SetActive(true);                   //顯示地方生產物品圖案
			Message.text = "沼都的建築最突出的形式是從中世紀、文藝復興到巴洛克時期。沼都歷史中心是建築上多產的代表，沼都是天主教總教區的所在地，羅馬天主教信仰對於當地居民具有相當的重要性，市內擁有數以百計的教堂，沼都的一個顯著特徵是其擁有448座古老的教堂，使之成為世界上最羅馬天主教化的城市之一。"; //顯示地方說明
			if(Main.P2>=10)P3.text = "出航次數:" + Main.P3 + "次";
			else if(Main.P2<10)P3.text = "需出航威尼斯10次" ;
		}	



	}


}//主程式結束=================================================================================================
