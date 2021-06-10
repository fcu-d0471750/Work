//移動攝影機
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Camera : MonoBehaviour {
	


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow) && gameObject.transform.position.x<=9.199996) gameObject.transform.position += new Vector3(0.5f,0,0);
		if (Input.GetKey (KeyCode.LeftArrow) && gameObject.transform.position.x>=-6.999998) gameObject.transform.position += new Vector3(-0.5f,0,0);

		//戰爭結束動畫(勝利)	 
		if (CreateEnemy.Live<=0.0f && gameObject.transform.position.x <= 9.199996) gameObject.transform.position += new Vector3(0.5f,0,0);   //固定攝影機對準敵方城門
		//戰爭結束動畫(失敗)	 
		if (CreatePeople.Live<=0.0f && gameObject.transform.position.x >=-6.999998) gameObject.transform.position += new Vector3(-0.5f,0,0); //固定攝影機對準我方城門
		//15.99999 9.199996

		//-17.39999 -6.999998
	}


}
