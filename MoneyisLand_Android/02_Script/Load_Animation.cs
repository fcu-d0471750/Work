using UnityEngine;
using System.Collections;

public class Load_Animation : MonoBehaviour {

	//宣告變數===========================================
	//Bool
	//是否播放載入畫面 true:播放 falseL不播放
	public static bool Load_Animation_Bool = false;

	//GameObject
	//載入GameObject
	public GameObject Load_Animation_GameObject;

	// Use this for initialization
	void Start () {
		//一開始沒有載入動畫
		//Load_Animation_GameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		//如果切換場景，播放載入動畫
		if (Load_Animation_Bool == true) {
			Load_Animation_GameObject.SetActive (true);
		}
		//否則不播放載入動畫
		else Load_Animation_GameObject.SetActive(false);
	}
}
