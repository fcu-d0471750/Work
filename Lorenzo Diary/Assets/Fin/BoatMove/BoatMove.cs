using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class BoatMove : MonoBehaviour {


	public GameObject starttext; //文字條
	float   time = 5;                       //文字顯示時間
	float   ax = -72.1f;                         //起始位置
	float   ay = 112.3f;
	int     rand;     				        //產生整數亂數

	// Use this for initializationAllScore.LevelScore/1000
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {


		//文字條
		this.transform.localPosition = new Vector3 (ax,ay,0.0f);
		if (ax >= -216.6) ax = ax - 0.1f;
		if (ay >= 81.3)   ay = ay - 0.1f;
		//改變文字條
		if (ax <= -216.6 && ay <= 81.3 && time>=0.0) {

			//減少時間
			time = time - Time.deltaTime;
			if (time <= 0) {
				ax = -72.1f;
				ay =  112.3f;
				time = 5;
			}
		}

	}//Updateend
}
