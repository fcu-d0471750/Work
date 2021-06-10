using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class LiveBar : MonoBehaviour {
	public GameObject Holger;  // 宣告一個物件叫Holger
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = Holger.transform.position; //不斷向右移動
	}
}
