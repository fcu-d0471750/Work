using UnityEngine;
using System.Collections;

public class Arrow2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3(0.01f,0,0); //不斷向右移動
	}
}
