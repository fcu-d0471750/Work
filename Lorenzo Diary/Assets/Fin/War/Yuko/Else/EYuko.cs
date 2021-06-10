//敵方Yuko
using UnityEngine;
using System.Collections;

public class EYuko : MonoBehaviour {

	public GameObject EYukoPunch; // 宣告一個物件叫EHolgerPunch,敵方Holger攻擊

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3(-0.02f,0,0); //不斷向左移動
	}

	//碰到我方
	void OnTriggerEnter2D(Collider2D col)
	{
		if ( col.tag == "Holger" || col.tag == "HolgerPunch" || col.tag == "Yuko" || col.tag == "YukoPunch" || col.tag == "Yuji")
		{
			Vector3 pos = gameObject.transform.position + new Vector3 (0, 0, 0); //播放攻擊動畫
			Instantiate (EYukoPunch, pos, gameObject.transform.rotation);
			Destroy(gameObject);//消滅物件本身

		}

	}
}
