using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

[RequireComponent(typeof(AudioSource))]//必須要有AudioSource，任何加上此腳本的物件將自動加入AudioSource
public class MusicMovie : MonoBehaviour {

	public  MovieTexture movTexture;//影片
	private AudioSource AS_mov;//影片音軌
	//public  GameObject M;  //音樂符號:右 觸發動畫

	void Start()
	{
		GetComponent<RawImage>().texture = movTexture;
		AS_mov = GetComponent<AudioSource>();
		AS_mov.clip = movTexture.audioClip;//這個MovieTexture的音軌
		movTexture.Play();
		//movTexture.loop = true;  //重複播放
		//AS_mov.Play();

	}


	void Update()
	{
		//如果音樂暫停
		if(MusicGame.MusicPause) movTexture.Pause(); //暫停影片
		else movTexture.Play();                      //繼續播放影片
	}

	IEnumerator LoadScene()
	{
		yield return new WaitForSeconds(10.2f);//括號內填入影片時間
		//movTexture.Play();
		//UnityEngine.SceneManagement.SceneManager.LoadScene("Main");//載入場景
	}
}
