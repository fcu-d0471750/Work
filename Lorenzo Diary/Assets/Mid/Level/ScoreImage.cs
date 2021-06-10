using UnityEngine;
using System.Collections;
using UnityEngine.UI; //使用UI

public class ScoreImage : MonoBehaviour {




	public Image ScoreImage2; 		//分數條比例
	private float Temp,Temp2;       //暫時分數，用於讓分數條有前進的效果 
	public static bool Tempbool = false;    //暫時分數Bool，防止重複改變分數條 true:分數發生改變 false:分數不發生改變

	// Use this for initializationAllScore.LevelScore/1000
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//讓分數條有前進的效果 
		if (Tempbool) {
			if(Temp==0.0f)Temp = AllScore.LevelScore - Temp2; //計算分數差
			if (Temp > 0.0f) {        //增加分數條
				Temp2 = Temp2 + 5.0f;
				Temp = Temp - 5.0f; 
			} else {                  //結束增加分數條
				Temp = 0.0f;
				Tempbool = false;
			}
		}

		//分數條
		ScoreImage2.fillAmount = Temp2/1600;
	}
}
