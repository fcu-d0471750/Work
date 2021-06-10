//市場
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
public class Bmain : MonoBehaviour {

	//標題text***************************************************************************
	public Text peoplettext = null;
	public Text weaponttext = null;
	public Text hospitalttext = null;
	public Text foodttext = null;
	public Text moneyttext = null;
	//數量text***************************************************************************
	public Text peoplesumtext = null;
	public Text weaponsumtext = null;
	public Text hospitalsumtext = null;
	public Text foodsumtext = null;
	public Text moneysumtext = null;
	//買入text***************************************************************************
	public Text weaponbtext = null;
	public Text hospitalbtext = null;
	public Text foodbtext = null;
	//賣出text***************************************************************************
	public Text weaponstext = null;
	public Text hospitalstext = null;
	public Text foodstext = null;
	public AudioSource ButtonMusic;      //按扭音效

	//買入變數***************************************************************************
	int weaponbuy;                      
	int hospitalbuy;
	int foodbuy;

	//賣出變數***************************************************************************
	int weaponsell;
	int hospitalsell;
	int foodsell;

	//買入動畫*****************************************************************************
	public GameObject WeaponBuyAnimate;   //武器 
	public GameObject HospitalBuyAnimate; //醫療品 
	public GameObject FoodBuyAnimate;     //食物 
	bool AnimatePlay = false;             //動畫是否播放
	//賣出動畫*****************************************************************************
	public GameObject WeaponSellAnimate;   //武器 
	public GameObject HospitalSellAnimate; //醫療品 
	public GameObject FoodSellAnimate;     //食物 
	//金額不足text******************************************************************************
	public Text MoneyNotEnough;

	//音效************************************************************************************
	public AudioSource sceneMusic;          //背景音效
	public AudioSource MoneyNotEnoughMusic; //金額不足提示音
	public AudioSource quitMusic;           //離開按鈕音效
	//宣告變數***********************************************************************************
	public AudioSource BackMusic;    //返回音效
	public static int Placetime ;    //地方時間
	float timef;   //時間
	float timem;   //時間
	float TimeA;   //動畫時間
	int   MaxNumber; //買入或賣出的數量
	public Animation SaveImage;          //儲存中動畫
	//淡出************************************************************************************
	public GameObject MainFadeout;

	//===============================================================================================================================
	// Use this for initialization
	void Start () {
		//預設
		MaxNumber = 100;

		weaponbuy = UnityEngine.Random.Range( 10, 100 );   //產生亂數;
		hospitalbuy = UnityEngine.Random.Range( 15, 100);   //產生亂數;
		foodbuy = UnityEngine.Random.Range( 10, 100 );   //產生亂數;

		weaponsell = UnityEngine.Random.Range( 1, 25 );   //產生亂數;
		hospitalsell = UnityEngine.Random.Range( 5, 15 );   //產生亂數;
		foodsell = UnityEngine.Random.Range( 2, 11 );   //產生亂數;

		WeaponBuyAnimate.SetActive(false);
		HospitalBuyAnimate.SetActive(false);
		FoodBuyAnimate.SetActive(false);

		WeaponSellAnimate.SetActive(false);
		HospitalSellAnimate.SetActive(false);
		FoodSellAnimate.SetActive(false);   

		if(Musicbotton.musicplay) sceneMusic.Play(); 
		else sceneMusic.Pause(); 
		sceneMusic.volume = Musicbotton.MusicVo;

		//讀入************************************************************************************
		Main.peoplesum   =  PlayerPrefs.GetInt("peoplesum1"); //讀入成就記錄(以下相同)
		Main.weaponsum   =  PlayerPrefs.GetInt("weaponsum1"); //讀入成就記錄(以下相同)
		Main.hospitalsum =  PlayerPrefs.GetInt("hospitalsum1"); //讀入成就記錄(以下相同)
		Main.foodsum     =  PlayerPrefs.GetInt("foodsum1"); //讀入成就記錄(以下相同)
		Main.moneysum    =  PlayerPrefs.GetInt("moneysum1"); //讀入成就記錄(以下相同)
		Main.kmsum    =  PlayerPrefs.GetInt("kmsum1"); //讀入成就記錄(以下相同)
		Main.yesorno =  PlayerPrefs.GetInt("YESorNO"); //讀入成就記錄(以下相同)

		Main.Apeople   =PlayerPrefs.GetInt("Apeoplesum"); //讀入成就記錄(以下相同)
		Main.Aweapon   = PlayerPrefs.GetInt("Aweaponsum"); //讀入成就記錄(以下相同)
		Main.Ahospital =PlayerPrefs.GetInt("Ahospitalsum"); //讀入成就記錄(以下相同)
		Main.Afood     = PlayerPrefs.GetInt("Afoodsum"); //讀入成就記錄(以下相同)
		Main.Amoney    = PlayerPrefs.GetInt("Amoneysum"); //讀入成就記錄(以下相同)

		Placeyesno.Placetime =  PlayerPrefs.GetInt("Placetime1"); //讀入成就記錄(以下相同)
		Placeyesno2.Placetime =  PlayerPrefs.GetInt("Placetime2"); //讀入成就記錄(以下相同)
		Placeyesno3.Placetime =  PlayerPrefs.GetInt("Placetime3"); //讀入成就記錄(以下相同)
		Placeyesno4.Placetime =  PlayerPrefs.GetInt("Placetime4"); //讀入成就記錄(以下相同)
		Placeyesno5.Placetime =  PlayerPrefs.GetInt("Placetime5"); //讀入成就記錄(以下相同)

		MainFadeout.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//鍵盤輸入(返回)
		if(Input.GetKeyDown("escape"))back ();

		//如果船已經出航
		timef +=Time.deltaTime;   //記錄時間
		if (timef >= 10) //10秒改變匯率
		{
			weaponbuy = UnityEngine.Random.Range( 10, 100 );   //產生亂數;
			hospitalbuy = UnityEngine.Random.Range( 15, 100);   //產生亂數;
			foodbuy = UnityEngine.Random.Range( 10, 100 );   //產生亂數;

			weaponsell = UnityEngine.Random.Range( 1, 25 );   //產生亂數;
			hospitalsell = UnityEngine.Random.Range( 5, 15 );   //產生亂數;
			foodsell = UnityEngine.Random.Range( 2, 11 );   //產生亂數;


			timef = 0;
		}

		timem +=Time.deltaTime;   //記錄時間
		if(timem >= 1){
			if(Placeyesno.Placetime!=30 && Placeyesno.Placetime!=0) Placeyesno.Placetime--;
			if(Placeyesno2.Placetime!=60 && Placeyesno2.Placetime!=0) Placeyesno2.Placetime--;
			if(Placeyesno3.Placetime!=80 && Placeyesno3.Placetime!=0) Placeyesno3.Placetime--;
			if(Placeyesno4.Placetime!=100 && Placeyesno4.Placetime!=0) Placeyesno4.Placetime--;
			if(Placeyesno5.Placetime!=120 && Placeyesno5.Placetime!=0) Placeyesno5.Placetime--;
			timem = 0;
		}

		//購買動畫==============================================================================================================================
		if(AnimatePlay)TimeA +=Time.deltaTime;   
		if (TimeA >= 0.3f && AnimatePlay) {
			WeaponBuyAnimate.SetActive(false);
			HospitalBuyAnimate.SetActive(false);
			FoodBuyAnimate.SetActive(false);
			WeaponSellAnimate.SetActive(false);
			HospitalSellAnimate.SetActive(false);
			FoodSellAnimate.SetActive(false);   
			AnimatePlay = false;
			TimeA = 0;
		}

		//標題=======================================================================================================================================
		peoplettext.text = "房屋LV." + Main.Apeople;
		weaponttext.text = "鐵匠鋪LV." + Main.Aweapon;
		hospitalttext.text = "醫院LV." + Main.Ahospital;
		foodttext.text = "農田LV." + Main.Afood;
		moneyttext.text = "礦場LV." + Main.Amoney;

		//買入text***************************************************************************
		weaponbtext.text = "武器買入金額 : " + weaponbuy * MaxNumber;
		hospitalbtext.text = "醫療品買入金額 : " + hospitalbuy * MaxNumber;
		foodbtext.text = "食物買入金額 : " + foodbuy * MaxNumber;

		//賣出text***************************************************************************
		weaponstext.text = "武器賣出金額 : " + weaponsell * MaxNumber;
		hospitalstext.text = "醫療品賣出金額 : " + hospitalsell * MaxNumber;
		foodstext.text = "食物賣出金額 : " + foodsell * MaxNumber;


		peoplesumtext.text = ""+Main.peoplesum;
		weaponsumtext.text = ""+Main.weaponsum;
		hospitalsumtext.text = ""+Main.hospitalsum;
		foodsumtext.text = ""+Main.foodsum;
		moneysumtext.text = ""+Main.moneysum;

		//紀錄========================================================================================================================================
		PlayerPrefs.SetInt("peoplesum1", Main.peoplesum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("weaponsum1", Main.weaponsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("hospitalsum1", Main.hospitalsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("foodsum1", Main.foodsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("moneysum1", Main.moneysum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("kmsum1",  Main.kmsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("YESorNO", Main.yesorno );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了

		PlayerPrefs.SetInt("Apeoplesum", Main.Apeople );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Aweaponsum", Main.Aweapon );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Ahospitalsum", Main.Ahospital );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Afoodsum",Main.Afood );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Amoneysum", Main.Amoney );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

		PlayerPrefs.SetInt("Placetime1", Placeyesno.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime2", Placeyesno2.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime3", Placeyesno3.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime4", Placeyesno4.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime5", Placeyesno5.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
	}//Update結束===========================================================================================================

	//返回
	public void back()
	{
		BackMusic.Play ();
		MainFadeout.SetActive (true);
		//Application.LoadLevel("Main");
	}

	//===========================================================================================================================
	//設定買入或賣出的數量:100
	public void SetMaxNumber100(){
		MaxNumber = 100;
		MoneyNotEnough.text = "武器 醫療 食物賣出單位: " + MaxNumber; 
	}

	//設定買入或賣出的數量:1000
	public void SetMaxNumber1000(){
		MaxNumber = 1000;
		MoneyNotEnough.text = "武器 醫療 食物賣出單位: " + MaxNumber; 
	}

	//設定買入或賣出的數量:10000
	public void SetMaxNumber10000(){
		MaxNumber = 10000;
		MoneyNotEnough.text = "武器 醫療 食物賣出單位: " + MaxNumber; 
	}

	//===========================================================================================================================
	//武器買入
	public void weaponb()
	{
		if (Main.moneysum >= (weaponbuy*MaxNumber)) {
			WeaponBuyAnimate.SetActive(true);
			AnimatePlay = true;
			Main.weaponsum = Main.weaponsum + MaxNumber;
			Main.moneysum = Main.moneysum - (weaponbuy*MaxNumber);
			MoneyNotEnough.text = "武器 醫療 食物賣出單位: " + MaxNumber; 
			ButtonMusic.Play ();
			SaveImage.Play ();
		} else {
			MoneyNotEnough.text = "金錢不足"; 
			MoneyNotEnoughMusic.Play ();
		}
			

	}
	//醫療買入
	public void hospitalb()
	{
		if (Main.moneysum >= (hospitalbuy*MaxNumber)) {
			HospitalBuyAnimate.SetActive(true);
			AnimatePlay = true;
			Main.hospitalsum = Main.hospitalsum + MaxNumber;
			Main.moneysum = Main.moneysum - (hospitalbuy*MaxNumber);
			MoneyNotEnough.text = "武器 醫療 食物賣出單位: " + MaxNumber; 
			ButtonMusic.Play ();
			SaveImage.Play ();
		}else {
			MoneyNotEnough.text = "金錢不足"; 
			MoneyNotEnoughMusic.Play ();
		}
	}
	//食物買入
	public void foodb()
	{
		if (Main.moneysum >= (foodbuy*MaxNumber)) {
			FoodBuyAnimate.SetActive(true);
			AnimatePlay = true;
			Main.foodsum = Main.foodsum + MaxNumber;
			Main.moneysum = Main.moneysum - (foodbuy*MaxNumber);
			MoneyNotEnough.text = "武器 醫療 食物賣出單位: " + MaxNumber; 
			ButtonMusic.Play ();
			SaveImage.Play ();
		}else {
			MoneyNotEnough.text = "金錢不足"; 
			MoneyNotEnoughMusic.Play ();
		}
	}

	//===========================================================================================================================
	//武器賣出
	public void weapons()
	{
		if (Main.weaponsum >= MaxNumber) {
			WeaponSellAnimate.SetActive(true);
			AnimatePlay = true;
			Main.weaponsum = Main.weaponsum - MaxNumber;
			Main.moneysum = Main.moneysum + (weaponsell * MaxNumber);
			MoneyNotEnough.text = "武器 醫療 食物賣出單位: " + MaxNumber; 
			ButtonMusic.Play ();
			SaveImage.Play ();
		}else {
			MoneyNotEnough.text = "武器數量不足" + MaxNumber; 
			MoneyNotEnoughMusic.Play ();
		}
	}
	//醫療賣出
	public void hospitals()
	{
		if (Main.hospitalsum >= MaxNumber) {
			HospitalSellAnimate.SetActive(true);
			AnimatePlay = true;
			Main.hospitalsum = Main.hospitalsum - MaxNumber;
			Main.moneysum = Main.moneysum + (hospitalsell * MaxNumber);
			MoneyNotEnough.text = ""; 
			ButtonMusic.Play ();
			SaveImage.Play ();
		}else {
			MoneyNotEnough.text = "醫療品數量不足" + MaxNumber; 
			MoneyNotEnoughMusic.Play ();
		}
	}
	//食物賣出
	public void foods()
	{
		if (Main.foodsum >= MaxNumber) {
			FoodSellAnimate.SetActive(true);   
			AnimatePlay = true;
			Main.foodsum = Main.foodsum - MaxNumber;
			Main.moneysum = Main.moneysum + (foodsell * MaxNumber);
			MoneyNotEnough.text = ""; 
			ButtonMusic.Play ();
			SaveImage.Play ();
		}else {
			MoneyNotEnough.text = "食物數量不足"+ MaxNumber; 
			MoneyNotEnoughMusic.Play ();
		}
	}

}//主程式結束=======================================================================================================================
