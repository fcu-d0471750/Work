using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
public class BoatMove8 : MonoBehaviour {

	float   time = 5;                       //文字顯示時間
	float   ax = 265.0f;                         //起始位置
	float   ay = -238.0f;
	int     rand;     				        //產生整數亂數

	// Use this for initializationAllScore.LevelScore/1000
	void Start () {

	}

	// Update is called once per frame
	void Update () {


		//文字條
		this.transform.localPosition = new Vector3 (ax,ay,0.0f);
		if (ax >= 116.9) ax = ax - 0.1f;
		if (ay <= -155.7)   ay = ay + 0.05f;
		//改變文字條
		if (ax <= 116.9 && ay >= -155.7 && time>=0.0) {

			//減少時間
			time = time - Time.deltaTime;
			if (time <= 0) {
				ax = 265.0f;
				ay = -238.0f;
				time = 5;
			}
		}

	}//Updateend
}
