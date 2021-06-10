using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class Placebutton7 : MonoBehaviour {

	public GameObject yesbutton;       //宣告PlayButton物件
	public GameObject Placeimage;      //宣告Placeimage物件
	public GameObject exitbutton;        //宣告exitButton物件
	public GameObject Storebutton;       //宣告StoreButton物件
	public Text Placetext = null;        //地方內容
	public Text Obtaintext = null;       //地方獲取內容
	public Text Timetext = null;         //地方時間
	public Text Message = null;          //船已出航
	public AudioSource ButtonMusic;      //按扭音效
	public static int yesno ;                  //是否已經按下按鈕 true:已按下 false: 未按下

	//物資內容


	// Use this for initialization
	void Start () {
		yesbutton.SetActive(false);   //隱藏按鈕
		Placeimage.SetActive(false);  //隱藏背景
		Placetext.text =  "";   //隱藏
		Obtaintext.text = "";   //隱藏
		Timetext.text = "";
		Message.text = "";
		yesno = 0;
	}

	// Update is called once per frame
	void Update () {
		if(yesno==1)Timetext.text = "" + Placeyesno7.Placetime;
		else Timetext.text = "" ;
		if(Main.yesorno == 1 && yesno==1) Message.text = "船已出航";
		else Message.text = "";
	}

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
			yesno = 0; //false: 未按下
			Placetext.text =  "";   //隱藏
			Obtaintext.text = "";   //隱藏
			Timetext.text = "";
			Message.text = "";
		} 

		//未按下
		else
		{
			ButtonMusic.Play();
			yesbutton.SetActive(true);   //顯示按鈕
			Placeimage.SetActive(true);  //顯示背景
			//顯示地方內容
			yesno = 1; //true: 已按下
			Placetext.text =  "麥卡貝"; //顯示
			Obtaintext.text = ""; //顯示


		}	



	}

	//成就按鈕*******************************************************************
	public void AchievementButton()
	{

	}

	//確定按鈕*******************************************************************
	public void yesButton()
	{

	}


	//取消按鈕(結束程式)*******************************************************************
	public void noButton()
	{

	}


}
