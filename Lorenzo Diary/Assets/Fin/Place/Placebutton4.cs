//舊金山
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class Placebutton4 : MonoBehaviour {

	//宣告變數=============================================================================================
	public GameObject yesbutton;       //宣告出航按鈕
	public GameObject Placeimage;      //宣告背景
	public GameObject money4;          //宣告地方生產物品圖案
	public Text Placetext = null;      //地名
	public Text Timetext = null;       //地方風險
	public Text Message = null;        //地方說明
	public Text P4 = null;             //出航次數 
	public AudioSource ButtonMusic;    //按扭音效
	public static int yesno ;          //是否已經按下按鈕 true:已按下 false: 未按下



	// Use this for initialization
	void Start () {
		yesbutton.SetActive(false);   //隱藏出航按鈕
		Placeimage.SetActive(false);  //隱藏背景
		Placetext.text =  "";         //隱藏地名
		money4.SetActive(false);      //隱藏地方生產物品圖案
		Timetext.text = "";           //隱藏地方風險
		Message.text = "";            //隱藏地方說明
		P4.text = "";                 //隱藏出航次數
		yesno = 0;                    //隱藏資訊
	}

	// Update is called once per frame
	void Update () {
		if(yesno==1)Timetext.text = "非常危險"; //顯示地方風險
		else Timetext.text = "" ;               //隱藏地方風險
		//鍵盤輸入4
		if(Input.GetKeyDown("4"))push ();
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
			money4.SetActive(false);      //隱藏地方生產物品圖案
			Timetext.text = "";           //隱藏地方風險
			Message.text = "";            //隱藏地方說明
			P4.text = "";                 //隱藏出航次數
		} 

		//未按下
		else
		{
			ButtonMusic.Play();
			if(Main.P3>=15)yesbutton.SetActive(true);   //顯示按鈕
			Placeimage.SetActive(true);                //顯示背景
			//顯示地方內容
			yesno = 1;                                 //true: 已按下
			Placetext.text =  "奧托莊園";                //顯示地名
			money4.SetActive(true);                    //顯示地方生產物品圖案
			Message.text = "位於義大利人口最密集和發展程度最高的倫巴第平原上。它是歐洲南方的重要交通要點，歷史相當悠久，以觀光、時尚與建築景觀聞名於世。水利設施這一時期開始出現，導致倫巴第平原出現許多花園。羊毛貿易的發展隨後給予絲綢生產首次推力。正如威尼斯和佛羅倫斯一樣，製造奢侈品也是一種相當重要的產業。幾乎與奧地利的經濟規模一樣大，擁有義大利最高的平均所得。"; //顯示地方說明
			if(Main.P3>=15)P4.text = "出航次數:" + Main.P4 + "次";
			else if(Main.P3<15)P4.text = "需出航沼都15次" ;
		}	



	}

}//主程式結束=================================================================================================
