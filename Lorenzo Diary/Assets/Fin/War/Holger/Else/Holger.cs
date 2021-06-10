//我方Holger
using UnityEngine;
using System.Collections;

public class Holger : MonoBehaviour {

	public GameObject HolgerPunch; // 宣告一個物件叫HolgerPunch,我方Holger攻擊
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3(0.02f,0,0); //不斷向右移動

	}

	//碰到敵人
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "EHolger" || col.tag == "EHolgerPunch" || col.tag == "EYuko" || col.tag == "EYukoPunch")
		{
			Vector3 pos = gameObject.transform.position + new Vector3 (0, 0, 0); //播放死亡動畫
			Instantiate (HolgerPunch, pos, gameObject.transform.rotation);


			Destroy(gameObject);//消滅物件本身

		}

	}
}
