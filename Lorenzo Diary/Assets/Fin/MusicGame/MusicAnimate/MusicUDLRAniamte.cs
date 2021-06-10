////音樂符號觸發動畫
using UnityEngine;
using System.Collections;

public class MusicUDLRAniamte : MonoBehaviour {

	public GameObject Music;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AniDestory(){
		//Destroy (gameObject); //消滅物件
		Music.SetActive(false);
	}

}
