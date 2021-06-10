using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class BoatMove2 : MonoBehaviour {



	float   time = 5;                       //文字顯示時間
	float   ax = -247f;                         //起始位置
	float   ay = -133.5f;
	int     rand;     				        //產生整數亂數

	// Use this for initializationAllScore.LevelScore/1000
	void Start () {

	}

	// Update is called once per frame
	void Update () {


		//文字條
		this.transform.localPosition = new Vector3 (ax,ay,0.0f);
		if (ax <= -235.1) ax = ax + 0.1f;
		if (ay >= -251.35)   ay = ay - 0.1f;
		//改變文字條
		if (ax >= -235.1 && ay <= -251.35 && time>=0.0) {

			//減少時間
			time = time - Time.deltaTime;
			if (time <= 0) {
				ax = -247f;
				ay =  -133.5f;
				time = 5;
			}
		}

	}//Updateend
}
