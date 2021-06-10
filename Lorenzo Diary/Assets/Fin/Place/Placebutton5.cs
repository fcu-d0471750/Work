//巴西
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class Placebutton5 : MonoBehaviour {

	//宣告變數=============================================================================================
	public GameObject yesbutton;       //宣告出航按鈕
	public GameObject Placeimage;      //宣告背景
	public GameObject food5;           //宣告地方生產物品圖案
	public Text Placetext = null;      //地名
	public Text Obtaintext = null;     //地方獲取內容
	public Text Timetext = null;       //地方風險
	public Text Message = null;        //地方說明
	public Text P5 = null;             //出航次數
	public AudioSource ButtonMusic;    //按扭音效
	public static int yesno ;          //是否已經按下按鈕 true:已按下 false: 未按下




	// Use this for initialization
	void Start () {
		yesbutton.SetActive(false);   //隱藏出航按鈕
		Placeimage.SetActive(false);  //隱藏背景
		Placetext.text =  "";         //隱藏地名
		food5.SetActive(false);       //隱藏地方生產物品圖案
		Timetext.text = "";           //隱藏地方風險
		Message.text = "";            //隱藏地方說明
		P5.text = "";                 //隱藏出航次數
		yesno = 0;                    //隱藏資訊
	}

	// Update is called once per frame
	void Update () {
		if(yesno==1)Timetext.text = "極度危險"; //顯示地方風險
		else Timetext.text = "" ;               //隱藏地方風險
		//鍵盤輸入5
		if(Input.GetKeyDown("5"))push ();

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
			food5.SetActive(false);       //隱藏地方生產物品圖案
			Timetext.text = "";           //隱藏地方風險
			Message.text = "";            //隱藏地方說明
			P5.text = "";                 //隱藏出航次數
		} 

		//未按下
		else
		{
			ButtonMusic.Play();
			if(Main.P4>=20)yesbutton.SetActive(true);   //顯示按鈕
			Placeimage.SetActive(true);                //顯示背景
			//顯示地方內容
			yesno = 1;                                 //true: 已按下
			Placetext.text =  "羅馬城";                  //顯示地名
			food5.SetActive(true);                     //顯示地方生產物品圖案
			Message.text = "羅馬帝國的經濟中，最重要的是農業。羅馬帝國糧食作物主要是小麥，小麥在帝國各地都有種植，尤以東方各省為勝。羅馬的經濟作物主要有橄欖和葡萄，地中海地區是葡萄和橄欖的主要種植地，葡萄的種植範圍向北有所擴張，橄欖的種植在西班牙為最多。羅馬每年都要從東方的行省輸入大量糧食、酒和油，東方行省也是羅馬稅收的重要來源。"; //顯示地方說明
			if(Main.P4>=20)P5.text = "出航次數:" + Main.P5 + "次";
			else if(Main.P4<20)P5.text = "需出航奧托莊園20次" ;

		}	



	}


}//主程式結束=================================================================================================
