using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class BoatMove6 : MonoBehaviour {

	float   time = 5;                       //文字顯示時間
	float   ax = -202.6f;                         //起始位置
	float   ay = 116.05f;
	int     rand;     				        //產生整數亂數

	// Use this for initializationAllScore.LevelScore/1000
	void Start () {

	}

	// Update is called once per frame
	void Update () {


		//文字條
		this.transform.localPosition = new Vector3 (ax,ay,0.0f);
		if (ax <= -66.7) ax = ax + 0.08f;
		if (ay <= 120.8)   ay = ay + 0.15f;
		//改變文字條
		if (ax >= -66.7 && ay >= -120.8 && time>=0.0) {

			//減少時間
			time = time - Time.deltaTime;
			if (time <= 0) {
				ax = -202.6f;
				ay = 116.05f;
				time = 5;
			}
		}

	}//Updateend
}
