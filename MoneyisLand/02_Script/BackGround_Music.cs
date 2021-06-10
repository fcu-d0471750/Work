//背景音樂控制腳本
using UnityEngine;
using System.Collections;

public class BackGround_Music : MonoBehaviour {

	//背景音樂指定播放時間
	float Timer = 0.0f;
	//背景音樂編號
	int Number = 0;
	//背景音樂
	public AudioSource[] Music = new AudioSource[8];

	// Use this for initialization
	void Start () {
		//副程式:隨機挑選音樂
		ChooseMusic();
	
	}
	
	// Update is called once per frame
	void Update () {
		//計算播放時間
		Timer = Timer -Time.deltaTime;
		//如果歌曲播放結束，重新挑選音樂
		if (Timer <= 0.0f) ChooseMusic ();
	}

	//副程式:隨機挑選音樂
	void ChooseMusic(){
		//隨機選取背景音樂(0 ~ 7)
		Number = UnityEngine.Random.Range(0, 8);
		//設定被挑選音樂的長度
		Timer = Music[Number].clip.length;
		//播放被挑選的音樂
		Music[Number].Play();
	}


}
