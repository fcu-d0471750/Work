//全部動畫控制
using UnityEngine;
using System.Collections;

public class AnimationIN : MonoBehaviour {
	//宣告變數===================================================================
	//Work頁面進入動畫是否播放 true:播放 fasle:未播放
	public static bool WorkPage_IN = false;
	//宣告動畫===================================================================
	//WorkPage進入動畫
	public Animation Work_IN;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//播放WorkPage進入動畫
		if (WorkPage_IN) {
			Work_IN.Play ();
			WorkPage_IN = false;
		}
	}

	//副程式:開啟WorkPage進入動畫
	public static void WorkPage_IN_Bool(){
		WorkPage_IN = true;
	}



}
