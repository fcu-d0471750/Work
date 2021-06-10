using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class Award3 : MonoBehaviour {

	public GameObject Image1;   //獎章圖示 
	public GameObject Image1out; //灰色獎章圖示

	public GameObject Image2;   //獎章圖示 
	public GameObject Image2out; //灰色獎章圖示

	public GameObject Image3;   //獎章圖示 
	public GameObject Image3out; //灰色獎章圖示

	public GameObject Image4;   //獎章圖示 
	public GameObject Image4out; //灰色獎章圖示

	public GameObject Image5;   //獎章圖示 
	public GameObject Image5out; //灰色獎章圖示

	public  AudioSource music;                 //音樂
//====================================================

	// Use this for initialization
	void Start () {

		//音樂
		if(Musicbotton.musicplay == true) music.Play();  //如果開始畫面音效被開啟,音樂播放
		else music.Pause();                              //如果開始畫面音效被關閉,音樂暫停

		//**************************************************
		if (AllScore.LevelMistakesum >= 1000)  //達到目標
		{
			Image1.SetActive (true);
			Image1out.SetActive (false);
		} 
		else                               //沒達到目標  
		{
			Image1.SetActive (false);
			Image1out.SetActive (true);
		}	
		//**************************************************
		if (AllScore.LevelMistakesum >= 3000)  //達到目標
		{
			Image2.SetActive (true);
			Image2out.SetActive (false);
		} 
		else                               //沒達到目標  
		{
			Image2.SetActive (false);
			Image2out.SetActive (true);
		}
		//**************************************************
		if (AllScore.LevelMistakesum >= 5000)  //達到目標
		{
			Image3.SetActive (true);
			Image3out.SetActive (false);
		} 
		else                               //沒達到目標  
		{
			Image3.SetActive (false);
			Image3out.SetActive (true);
		}
		//**************************************************
		if (AllScore.LevelMistakesum >= 9999)  //達到目標
		{
			Image4.SetActive (true);
			Image4out.SetActive (false);
		} 
		else                               //沒達到目標  
		{
			Image4.SetActive (false);
			Image4out.SetActive (true);
		}
		//**************************************************
		if (AllScore.LevelCorrectsum >=9999 && AllScore.LevelMistakesum >= 9999)  //達到目標
		{
			Image5.SetActive (true);
			Image5out.SetActive (false);
		} 
		else                               //沒達到目標  
		{
			Image5.SetActive (false);
			Image5out.SetActive (true);
		}

	}//START結束
	
	// Update is called once per frame
	void Update () {
	
	}
}
