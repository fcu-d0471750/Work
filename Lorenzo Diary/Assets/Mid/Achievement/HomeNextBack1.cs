using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI


public class HomeNextBack1 : MonoBehaviour {

	public Button HomeButton;   //按鈕元件HomeButton
	public Button NextButton;   //按鈕元件NextButton
	public AudioSource ButtonMusic;            //按扭音效

//===========================================================================


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//主選單
	public void Home()
	{
		ButtonMusic.Play ();
		Application.LoadLevel("startscreen");  //切換主選單  
	}
    


	//下一頁
	public void Next()
	{
		ButtonMusic.Play ();
		Application.LoadLevel("Achievement2");  //切換下一畫面成就   	
	}


}
