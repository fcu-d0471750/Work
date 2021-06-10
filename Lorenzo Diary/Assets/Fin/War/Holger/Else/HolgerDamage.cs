//我方Holger死亡動畫
using UnityEngine;
using System.Collections;

public class HolgerDamage : MonoBehaviour {

	public float time = 0.0f; //死亡動畫播放時間

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime; //時間增加
		if(time>0.5f)Destroy(gameObject);//消滅動畫
	}
}
