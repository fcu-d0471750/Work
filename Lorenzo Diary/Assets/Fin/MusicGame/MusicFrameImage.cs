//音樂符號Image
using UnityEngine;
using System.Collections;

public class MusicFrameImage : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3(0,-0.018f,0); //不斷向下移動
	}
}
