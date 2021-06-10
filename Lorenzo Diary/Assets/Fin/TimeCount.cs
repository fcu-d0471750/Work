//計算上次遊完時間和這次遊完時間的差距
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class TimeCount : MonoBehaviour {

	//宣告變數*********************************************************************
	public static int TimeSub = 0; //兩次時間差
	public int LastSum = 0; //紀錄秒數
	public int NowSum  = 0; //紀錄秒數

	DateTime Now  = DateTime.Now;  //這次遊完時間

	public static int[] Lasttime = new int [7];  //年 月 日 時 分 秒


	// Use this for initialization
	void Start () {
		//讀入記錄
		Lasttime[1] = PlayerPrefs.GetInt("Lasttime1"); //讀入記錄(以下相同)
		Lasttime[2] = PlayerPrefs.GetInt("Lasttime2"); //讀入記錄(以下相同)
		Lasttime[3] = PlayerPrefs.GetInt("Lasttime3"); //讀入記錄(以下相同)
		Lasttime[4] = PlayerPrefs.GetInt("Lasttime4"); //讀入記錄(以下相同)
		Lasttime[5] = PlayerPrefs.GetInt("Lasttime5"); //讀入記錄(以下相同)
		Lasttime[6] = PlayerPrefs.GetInt("Lasttime6"); //讀入記錄(以下相同)

		//print (Mathf.Abs(Now.Hour - Lasttime[4]) );
		//print (Mathf.Abs(Now.Minute - Lasttime[5]) );
		//print (Mathf.Abs(Now.Second - Lasttime[6] ));
		//年 
		NowSum = NowSum + Now.Year * 31536000;
		LastSum = LastSum + Lasttime[1] * 31536000;
		//月
		NowSum = NowSum + Now.Month * 2592000;
		LastSum = LastSum + Lasttime[2] * 2592000;
		//日
		NowSum = NowSum + Now.Day * 86400;
		LastSum = LastSum + Lasttime[3] * 86400;
		//時
		NowSum = NowSum + Now.Hour * 3600;
		LastSum = LastSum + Lasttime[4] * 3600;
		//分
		NowSum = NowSum + Now.Minute * 60;
		LastSum = LastSum + Lasttime[5] * 60;
		//秒
		NowSum = NowSum + Now.Second;
		LastSum = LastSum + Lasttime[6];
		//計算時間差
		TimeSub = Mathf.Abs(NowSum - LastSum);
		//print (TimeSub);

		Lasttime [1] = Now.Year;
		Lasttime [2] = Now.Month;
		Lasttime [3] = Now.Day;
		Lasttime [4] = Now.Hour;
		Lasttime [5] = Now.Minute;
		Lasttime [6] = Now.Second;

		PlayerPrefs.SetInt("Lasttime1", Lasttime[1] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Lasttime2", Lasttime[2] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Lasttime3", Lasttime[3] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Lasttime4", Lasttime[4] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Lasttime5", Lasttime[5] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Lasttime6", Lasttime[6] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
