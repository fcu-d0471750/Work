using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class BoatMove4 : MonoBehaviour {

	float   time = 5;                       //文字顯示時間
	float   ax = 112f;                         //起始位置
	float   ay = -177f;
	int     rand;     				        //產生整數亂數

	// Use this for initializationAllScore.LevelScore/1000
	void Start () {

	}

	// Update is called once per frame
	void Update () {


		//文字條
		this.transform.localPosition = new Vector3 (ax,ay,0.0f);
		if (ax <= 266.7) ax = ax + 0.1f;
		if (ay >= -240.8)   ay = ay - 0.1f;
		//改變文字條
		if (ax >= 266.7 && ay <= -240.8 && time>=0.0) {

			//減少時間
			time = time - Time.deltaTime;
			if (time <= 0) {
				ax = 112f;
				ay =  -177f;
				time = 5;
			}
		}

	}//Updateend
}
