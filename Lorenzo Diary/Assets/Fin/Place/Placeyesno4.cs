//舊金山地方內容
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class Placeyesno4 : MonoBehaviour {
	
	//宣告變數***********************************************************************************
	public static int Placetime ;    //地方時間
	float timef;   //時間
	public GameObject yesbutton;         //確定按鈕
	public GameObject obtainbutton;      //獲取按鈕
	public GameObject Fadeout;           //淡出動畫
	public GameObject ObtaintextAnimate; //收獲訊息動畫
	public AudioSource ButtonMusic;      //按扭音效
	public AudioSource ObtainMusic;      //收穫音效
	bool yes = false;                    //確定
	public Animation SaveImage;          //儲存中動畫
	//物資內容***************************************************************
	int people;
	int weapon;
	int hospital;
	int food;
	int money;

	//進度圖*****************************************************************
	public GameObject ScoreImaA;        //進度圖出現 
	public Image ScoreIma;              //進度圖

	//獲取物品text********************************************************************************
	public Text Obtaintext = null;      //獲取物品text 


	//===========================================================================================================================
	//===========================================================================================================================
	// Use this for initialization
	void Start () {
		Placetime = 100;                //地方時間
		obtainbutton.SetActive(false);  //收獲按鈕隱藏
		Fadeout.SetActive(false);       //淡出畫面隱藏
		ObtaintextAnimate.SetActive(false);       //淡出畫面隱藏

		//進度圖
		ScoreImaA.SetActive(false);     //進度圖隱藏

		//讀檔
		Placetime  =  PlayerPrefs.GetInt("Placetime4"); //讀入成就記錄(以下相同)

		if(Placetime!=100) yes = true;  //如果Placetime!=20表示已經按下確定所以yes = true
	}//Start====================================================================================================================
		
	// Update is called once per frame===========================================================================================
	void Update () {
		timef +=Time.deltaTime;   //記錄時間
		if (timef >= 1 && Placetime!=0 && yes) //如果時間>=1 && Placetime[0]!=0 && 已按下按鈕 ,地方時間減少 
		{
			Placetime--;
			timef = 0;
		}	
			
		//如果地方時間==0
		if (Placetime == 0) obtainbutton.SetActive(true); //顯示獲取按鈕
		if(Main.yesorno == 1 )yesbutton.SetActive(false); //如果船已出航,出航按鈕隱藏

		//進度圖
		if(Main.yesorno==1 && Placetime!=100) ScoreImaA.SetActive(true);    //進度圖顯示
		else  ScoreImaA.SetActive(false);                 //進度圖隱藏
		ScoreIma.fillAmount = (100.0f-Placetime)/100;     //進度圖變化

		//記錄*****************************************************************************************
		PlayerPrefs.SetInt("Placetime4", Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

	}//Update結束===========================================================================================



	//確定按鈕===========================================================================================
	public void yesButton()
	{
		ButtonMusic.Play();
		if(Main.yesorno == 0)
		{
			yes = true;                   //如果未出航
			Main.yesorno = 1 ;
			yesbutton.SetActive(false);
		}	
		Fadeout.SetActive(false);       //淡出畫面隱藏
		Obtaintext.text = " ";          //獲得訊息消失
		SaveImage.Play();               //儲存中動畫
	}


	//收穫按鈕===========================================================================================
	public void obtainButton()
	{
		ButtonMusic.Play();
		yes = false;
		if(Placebutton.yesno==1)yesbutton.SetActive(true);
		else yesbutton.SetActive(false);
		obtainbutton.SetActive(false);
		Placetime  = 100;
		Main.yesorno = 0 ;
		Main.FadePlay = true;
		int pass = UnityEngine.Random.Range (1, 11); //成功機率60% 

		//成功
		if (pass >= 5) {
			people = UnityEngine.Random.Range (40, 100);   //產生亂數
			weapon = UnityEngine.Random.Range (50, 250);   //產生亂數
			hospital = UnityEngine.Random.Range (100, 200); //產生亂數
			food = UnityEngine.Random.Range (100, 300);     //產生亂數
			money = UnityEngine.Random.Range (800, 1200);    //產生亂數

			Obtaintext.text = 
				  "⊕人口增加   " + people + " 人\n"
				+ "⊕武器增加   " + weapon + " 把\n"
				+ "⊕醫療品增加 " + hospital + " 箱\n"
				+ "⊕食物增加   " + food + " 公斤\n"
				+ "⊕金錢增加   " + money + " 法\n";
		}

		//失敗
		else{
			people = UnityEngine.Random.Range (20, 50);   //產生亂數
			weapon = UnityEngine.Random.Range (25, 125);   //產生亂數
			hospital = UnityEngine.Random.Range (50, 100); //產生亂數
			food = UnityEngine.Random.Range (50, 150);     //產生亂數
			money = UnityEngine.Random.Range (400, 600);    //產生亂數

			if(pass==1)Obtaintext.text = "因為觸礁船丟失部分貨物";
			else if(pass==2)Obtaintext.text = "因為颱風而喪失貨物";
			else if(pass==3)Obtaintext.text = "海關扣留大部分貨物";
			else if(pass==4)Obtaintext.text = "船員因私心搶走\n大部分貨物";
			else Obtaintext.text = "因為颱風而喪失貨物";

		}

		Main.peoplesum = Main.peoplesum + people;        //人員總數
		Main.weaponsum = Main.weaponsum + weapon;        //武器總數
		Main.hospitalsum = Main.hospitalsum + hospital;  //醫療總數
		Main.foodsum = Main.foodsum + food;              //食物總數
		Main.moneysum = Main.moneysum + money;           //金錢總數
		Main.kmsum = Main.kmsum + Placetime;             //里程總數 
		Main.P4++;                                       //出航記錄  

		Fadeout.SetActive(true);           //淡出畫面播放
		ObtaintextAnimate.SetActive(true); //淡出畫面播放
		ObtainMusic.Play();
		SaveImage.Play();                  //儲存中動畫
	}


}//主程式結束===========================================================================================
