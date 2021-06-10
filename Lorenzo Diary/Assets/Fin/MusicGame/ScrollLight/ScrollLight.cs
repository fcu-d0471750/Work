//音樂振幅動畫
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class ScrollLight : MonoBehaviour {

	//振幅長度0~100
	float Light_Lenght = 0.0f;
	//振幅Image
	public Image Light_Image;
	//振幅變化時間
	float Timer = 0.1f;
	//設定編號
	public int Number;

	// Use this for initialization
	void Start () {
		if (Number == 1 && MusicGame.MusicEnd == false) {
			Light_Lenght = UnityEngine.Random.Range (0.0f, 100.0f) / 100.0f;
		} else if (Number == 2 && MusicGame.MusicEnd == false) {
			Light_Lenght = UnityEngine.Random.Range (0.0f, 50.0f) / 100.0f;
		} else if (Number == 3 && MusicGame.MusicEnd == false) {
			Light_Lenght = UnityEngine.Random.Range (0.0f, 25.0f) / 100.0f;
		} else if (Number == 4 && MusicGame.MusicEnd == false) {
			Light_Lenght = UnityEngine.Random.Range (0.0f, 15.0f) / 100.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Timer -= Time.deltaTime;

		//變換振幅長度========================================================================================================
		if (MusicGame.MusicPause == true) {
			Light_Image.fillAmount = Light_Image.fillAmount;
		}
		else if (Number == 1 && MusicGame.MusicEnd == false) {
			//Light_Lenght = UnityEngine.Random.Range (0.0f, 100.0f) / 100.0f;
			//Light_Image.fillAmount = Light_Lenght;
			Add_Sub_FillAmount(Light_Image,Light_Lenght);
		} else if (Number == 2 && MusicGame.MusicEnd == false) {
			//Light_Lenght = UnityEngine.Random.Range (0.0f, 50.0f) / 100.0f;
			//Light_Image.fillAmount = Light_Lenght;
			Add_Sub_FillAmount(Light_Image,Light_Lenght);
		} else if (Number == 3 && MusicGame.MusicEnd == false) {
			//Light_Lenght = UnityEngine.Random.Range (0.0f, 25.0f) / 100.0f;
			//Light_Image.fillAmount = Light_Lenght;
			Add_Sub_FillAmount(Light_Image,Light_Lenght);
		} else if (Number == 4 && MusicGame.MusicEnd == false) {
			//Light_Lenght = UnityEngine.Random.Range (0.0f, 15.0f) / 100.0f;
			//Light_Image.fillAmount = Light_Lenght;
			Add_Sub_FillAmount(Light_Image,Light_Lenght);
		} else
			Light_Image.fillAmount = 0.0f;

		//設定時間===============================================================================================================
		if (Timer <=0.0f && Number == 1 && MusicGame.MusicEnd == false) {
			Light_Lenght = UnityEngine.Random.Range (0.0f, 100.0f) / 100.0f;
			Timer = 0.1f;
		} else if (Timer <=0.0f && Number == 2 && MusicGame.MusicEnd == false) {
			Light_Lenght = UnityEngine.Random.Range (0.0f, 50.0f) / 100.0f;
			Timer = 0.3f;
		} else if (Timer <=0.0f && Number == 3 && MusicGame.MusicEnd == false) {
			Light_Lenght = UnityEngine.Random.Range (0.0f, 25.0f) / 100.0f;
			Timer = 0.5f;
		} else if (Timer <=0.0f && Number == 4 && MusicGame.MusicEnd == false) {
			Light_Lenght = UnityEngine.Random.Range (0.0f, 15.0f) / 100.0f;
			Timer = 0.8f;
		}

	}


	//副程式:增加或減少Light_Image的fillAmount
	void Add_Sub_FillAmount(Image Light_Image , float Amount){
		if (Amount > Light_Image.fillAmount)
			Light_Image.fillAmount = Light_Image.fillAmount + 0.01f;
		else if (Amount < Light_Image.fillAmount)
			Light_Image.fillAmount = Light_Image.fillAmount - 0.01f;
		else
			Light_Image.fillAmount = Light_Image.fillAmount;
	}
}
