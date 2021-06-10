//我方Yuko
using UnityEngine;
using System.Collections;

public class Yuko : MonoBehaviour {
	
	public GameObject YukoPunch; // 宣告一個物件叫YukoPunch,我方Yuko攻擊
	public bool Run_Punch=false;    //是否遇到過敵人 true:遇到 false:沒遇到
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		Run_Punch = false;
		gameObject.transform.position += new Vector3(0.02f,0,0); //不斷向右移動

	}

	//碰到敵人
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "EHolger" || col.tag == "EHolgerPunch" || col.tag == "EYuko" || col.tag == "EYukoPunch")
		{
			Vector3 pos = gameObject.transform.position + new Vector3 (0, 0, 0); //播放死亡動畫
			Instantiate (YukoPunch, pos, gameObject.transform.rotation);
			//Run_Punch = true;
			Destroy(gameObject);//消滅物件本身

		}

	}
}
