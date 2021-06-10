﻿//敵方Holger攻擊
using UnityEngine;
using System.Collections;

public class EHolgerPunch : MonoBehaviour {

	int Live = 3;//生命值
	public GameObject EHolgerDamage; // 宣告一個物件叫HolgerDamage,我方Holger死亡
	public GameObject EHolger; // 宣告一個物件叫Holger,我方Holger
	public bool Enemy=false;  //是否遇到過敵人
	public float EnemyT;      //沒遇到敵人的時間
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Enemy = false;
		if(Live==0){//如果生命值==0
			Vector3 pos = gameObject.transform.position + new Vector3 (0, 0, 0); //播放死亡動畫
			Instantiate (EHolgerDamage, pos, gameObject.transform.rotation);
			Destroy(gameObject);//消滅物件本身
		}

		if(Enemy)EnemyT=0.0f;           //有遇到敵人
		else EnemyT += Time.deltaTime; //沒遇到敵人的時間增加

		if (EnemyT >= 1.0f) {
			Vector3 pos = gameObject.transform.position + new Vector3 (0, 0, 0); //播放移動動畫
			Instantiate (EHolger, pos, gameObject.transform.rotation);
			Destroy(gameObject);//消滅物件本身
		}
		//print (Live);
	}

	//碰到我方
	void OnTriggerEnter2D(Collider2D col)
	{
		Enemy = true; //有遇到敵人
		if (col.tag == "Holger" || col.tag == "HolgerPunch" || col.tag == "Yuko" || col.tag == "YukoPunch" || col.tag == "Yuji") {
			if (Live != 0)
				Live--;
		} 



	}
}
