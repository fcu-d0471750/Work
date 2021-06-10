//地方內容
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class Placeyesno8 : MonoBehaviour {

	public GameObject yesbutton;         //確定按鈕
	public GameObject obtainbutton;      //獲取按鈕
	//public GameObject exitbutton;        //宣告exitButton物件
	//public GameObject Storebutton;       //宣告StoreButton物件


	//public Text Mistakesum = null;       //總答錯數
	public AudioSource ButtonMusic;      //按扭音效
	bool yes = false;                    //確定

	//物資內容***************************************************************
	int people;
	int weapon;
	int hospital;
	int food;
	int money;

	//宣告變數***********************************************************************************
	public static int Placetime ;    //地方時間
	float timef;   //時間



	// Use this for initialization
	void Start () {
		Placetime = 80;
		obtainbutton.SetActive(false);

		//讀檔
		//Placetime  =  PlayerPrefs.GetInt("Placetime8"); //讀入成就記錄(以下相同)

		if(Placetime!=80) yes = true;  //如果Placetime!=20表示已經按下確定所以yes = true
	}

	// Update is called once per frame
	void Update () {
		timef +=Time.deltaTime;   //記錄時間
		if (timef >= 1 && Placetime!=0 && yes) //如果時間>=1 && Placetime[0]!=0 && 已按下按鈕 
		{
			Placetime--;
			timef = 0;
		}	


		print (Placetime );

		//如果地方時間==0
		if (Placetime == 0) obtainbutton.SetActive(true); //顯示獲取按鈕

		//
		//記錄*****************************************************************************************
		//PlayerPrefs.SetInt("Placetime8", Placetime );
		//PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

	}



	//確定按鈕*******************************************************************
	public void yesButton()
	{
		ButtonMusic.Play();
		if(Main.yesorno == 0)
		{
			yes = true;                   //如果未出航
			Main.yesorno = 1 ;
			yesbutton.SetActive(false);
		}	

	}


	//收穫按鈕*******************************************************************
	public void obtainButton()
	{
		ButtonMusic.Play();
		yes = false;
		if(Placebutton.yesno==1)yesbutton.SetActive(true);
		else yesbutton.SetActive(false);
		obtainbutton.SetActive(false);
		Placetime  = 80;
		Main.yesorno = 0 ;

		people = UnityEngine.Random.Range( 0, 55 );   //產生亂數
		weapon = UnityEngine.Random.Range( 0, 55 );   //產生亂數
		hospital = UnityEngine.Random.Range( 0, 55 ); //產生亂數
		food = UnityEngine.Random.Range( 0, 55 );     //產生亂數
		money = UnityEngine.Random.Range( 0, 55 );    //產生亂數

		Main.peoplesum = Main.peoplesum + people;        //人員總數
		Main.weaponsum = Main.weaponsum + weapon;        //武器總數
		Main.hospitalsum = Main.hospitalsum + hospital;  //醫療總數
		Main.foodsum = Main.foodsum + food;              //食物總數
		Main.moneysum = Main.moneysum + money;           //金錢總數
		Main.kmsum = Main.kmsum + Placetime;             //里程總數 
	}


}
