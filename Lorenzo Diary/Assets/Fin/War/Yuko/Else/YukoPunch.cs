//我方Yuko攻擊
using UnityEngine;
using System.Collections;

public class YukoPunch : MonoBehaviour {

	int Live = 5;//生命值
	public GameObject YukoDamage; // 宣告一個物件叫YukoDamage,我方Yuko死亡
	public GameObject Yuko; // 宣告一個物件叫Yuko,我方Yuko
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
			Instantiate (YukoDamage, pos, gameObject.transform.rotation);
			Destroy(gameObject);//消滅物件本身
		}

		if(Enemy)EnemyT=0.0f;           //有遇到敵人
		else EnemyT += Time.deltaTime; //沒遇到敵人的時間增加

		if (EnemyT >= 1.0f) {
			Vector3 pos = gameObject.transform.position + new Vector3 (0, 0, 0); //播放移動動畫
			Instantiate (Yuko, pos, gameObject.transform.rotation);
			Destroy(gameObject);//消滅物件本身
		}
		//print (Live);
	}

	//碰到敵人
	void OnTriggerEnter2D(Collider2D col)
	{
		Enemy = true; //有遇到敵人
		if (col.tag == "EHolger" || col.tag == "EHolgerPunch" || col.tag == "EYuko" || col.tag == "EYukoPunch") {
			if (Live != 0)
				Live--;
		} 



	}
}
