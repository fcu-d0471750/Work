using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class musicbotton : MonoBehaviour {

	/*/宣告變數************************************************************
	public GameObject soundonbutton;        //音樂播放按鈕
	public GameObject soundonbuttoff;       //音樂暫停按鈕
	public AudioSource music;               //音樂
	public static bool musicplay = true;    //音樂是否開啟
	int musicing = 1;                       //音樂記錄狀態  */

	// Use this for initialization
	void Start () {
		/*music.loop = true;               //音樂循環播放
		musicplay = true;                //音樂開啟
		soundonbutton.SetActive(true);   //音樂播放按鈕圖示顯示  
		soundonbuttoff.SetActive(false); //音樂暫停按鈕圖示不顯示

		musicing = PlayerPrefs.GetInt("Musicing");//讀入音樂紀錄狀態
		if(musicing == 0) Musicoff();             //音樂暫停
		else Musicon();                           //音樂播放*/

	}

	// Update is called once per frame
	void Update () {

	}

	/*/音樂播放
	public void Musicon()
	{ 
		soundonbutton.SetActive(true);   //音樂播放按鈕圖示顯示  
		soundonbuttoff.SetActive(false); //音樂暫停按鈕圖不顯示
		music.Play();                    //音樂播放
		musicplay = true;                //音樂開啟

		PlayerPrefs.SetInt("Musicing", 1); //記錄音樂狀態(1:開啟)
		PlayerPrefs.Save();                //加上這步驟後，存檔就完成了
	}

	//音樂暫停
	public void Musicoff()
	{
		soundonbutton.SetActive(false);  //音樂播放按鈕圖示不顯示  
		soundonbuttoff.SetActive(true);  //音樂暫停按鈕圖示顯示
		music.Pause();                   //音樂暫停
		musicplay = false;               //音樂關閉
			
		PlayerPrefs.SetInt("Musicing", 0); //記錄音樂狀態(0:關閉)
		PlayerPrefs.Save();                //加上這步驟後，存檔就完成了
	}*/

}
