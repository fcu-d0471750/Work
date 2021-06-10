//季節時間控制
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間
//===================================================================================================================================

public class Season : MonoBehaviour {

	//宣告變數**************************************************************
	public static int Hour=0;           //小時
	public static int Min=59;           //分鐘
	public static float Sec=55;         //秒
	public Text Timetext = null;        //時間text 
	public GameObject WinterParticle;   //下雪粒子系統
	public GameObject RainParticle;     //下雨粒子系統




	//***************************************************************************************************
	// Use this for initialization***********************************************************************
	void Start () {
		WinterParticle.SetActive (false); //關閉下雪粒子系統
		RainParticle.SetActive (false);   //關閉下雨粒子系統
		//讀取*******************************************************************************************
		Hour =  PlayerPrefs.GetInt("Hour"); //讀入成就記錄(以下相同)
		Min  =  PlayerPrefs.GetInt("Min"); //讀入成就記錄(以下相同)
		Sec  =  PlayerPrefs.GetFloat("Sec"); //讀入成就記錄(以下相同)
	}
	
	// Update is called once per frame***********************************************************************
	void Update () {
		Sec +=Time.deltaTime;   //增加秒數

		//增加分鐘
		if (Sec>=60)     
		{
			Min++;
			Sec = 0;
		}

		//增加小時
		if (Min >= 60) 
		{
			Hour++; 
			Min = 0;
		} 

		Timetext.text = "遊玩時間: " + Hour + ":" + Min + ":" + (int)Sec;   //文字顯示

		//判斷季節*******************************************************************************************
		if (Hour % 4 == 1) {
			RainParticle.SetActive (true);    //開啟下雨粒子系統
			WinterParticle.SetActive (false); //關閉下雪粒子系統
		} else if (Hour % 4 == 2) {
			WinterParticle.SetActive (true);  //開啟下雪粒子系統
            RainParticle.SetActive (false);   //關閉下雨粒子系統
		} else {
			WinterParticle.SetActive (false); //關閉下雪粒子系統
			RainParticle.SetActive (false);   //關閉下雨粒子系統
		}


		//儲存************************************************************************************************
		PlayerPrefs.SetFloat("Sec", Sec );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Min", Min );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Hour", Hour );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
	}
}//主程式結束==========================================================================================================================
