//建造
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class Amain : MonoBehaviour {

	//文字訊息******************************************************************************
	public Text people = null;
	public Text weapon = null;
	public Text hospital = null;
	public Text foods = null;
	public Text money = null;
	public Text kmtext = null;


	//內容text***************************************************************************
	public Text peopletext = null;
	public Text weapontext = null;
	public Text hospitaltext = null;
	public Text foodtext = null;
	public Text moneytext = null;
	//要求text*****************************************************************************
	public Text peoplertext = null;
	public Text weaponrtext = null;
	public Text hospitalrtext = null;
	public Text foodrtext = null;
	public Text moneyrtext = null;
	//等級text***************************************************************************
	public Text peoplettext = null;
	public Text weaponttext = null;
	public Text hospitalttext = null;
	public Text foodttext = null;
	public Text moneyttext = null;
	//效率text***************************************************************************
	public Text peoplestext = null;
	public Text weaponstext = null;
	public Text hospitalstext = null;
	public Text foodstext = null;
	public Text moneystext = null;
	//升級按鈕************************************************************************************
	public GameObject peoplebutton;      //宣告PlayButton物件
	public GameObject weaponbutton;      //宣告PlayButton物件
	public GameObject hospitalbutton;    //宣告PlayButton物件
	public GameObject foodbutton;        //宣告PlayButton物件
	public GameObject moneybutton;       //宣告PlayButton物件
	public AudioSource ButtonMusic;      //按扭音效
	public AudioSource sceneMusic;       //按扭音效
	public AudioSource BackMusic;        //返回音效
	public Animation   BulidSeccess;     //建造成功動畫

	float timef;   //時間

	//淡出
	public GameObject MainFadeout; //主畫面淡出控制
	public Animation SaveImage;          //儲存中動畫

	// Use this for initialization
	void Start () {
		if(Musicbotton.musicplay) sceneMusic.Play(); 
		else sceneMusic.Pause(); 
		sceneMusic.volume = Musicbotton.MusicVo;

		//讀入========================================================================================================================
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
		if (timef >= 1) { //如果時間>=1 && Placetime[0]!=0 && 已按下按鈕 
			if(Placeyesno.Placetime!=30 && Placeyesno.Placetime!=0) Placeyesno.Placetime--;
			if(Placeyesno2.Placetime!=60 && Placeyesno2.Placetime!=0) Placeyesno2.Placetime--;
			if(Placeyesno3.Placetime!=80 && Placeyesno3.Placetime!=0) Placeyesno3.Placetime--;
			if(Placeyesno4.Placetime!=100 && Placeyesno4.Placetime!=0) Placeyesno4.Placetime--;
			if(Placeyesno5.Placetime!=120 && Placeyesno5.Placetime!=0) Placeyesno5.Placetime--;
			timef = 0;
		}
		//訊息=============================================================================================================================
		//酒館
		if(Main.Apeople==0)peopletext.text = "房屋LV. 1" +  "  人口數量提升每秒1人";
		else if(Main.Apeople==1)peopletext.text = "房屋LV. 2"  + "  人口數量提升每秒2人";
		else if(Main.Apeople==2)peopletext.text = "房屋LV. 3"  + "  人口數量提升每秒5人";
		else peopletext.text = "房屋已達最大值"  ;
		//鐵匠
		if(Main.Aweapon==0)weapontext.text = "鐵匠鋪LV. 1" + "  武器數量提升每秒2把";
		else if(Main.Aweapon==1)weapontext.text = "鐵匠鋪LV. 2" + "  武器數量提升每秒5把";
		else if(Main.Aweapon==2)weapontext.text = "鐵匠鋪LV. 3" + "  武器數量提升每秒8把";
		else weapontext.text = "鐵匠鋪已達最大值";
		//醫院
		if(Main.Ahospital==0)hospitaltext.text = "醫院LV. 1" +   "  醫療補給提升每秒2箱";
		else if(Main.Ahospital==1)hospitaltext.text = "醫院LV. 2" + "  醫療補給提升每秒3箱";
		else if(Main.Ahospital==2)hospitaltext.text = "醫院LV. 3" + "  醫療補給提升每秒5箱";
		else hospitaltext.text = "醫院已達最大值";
		//農田
		if(Main.Afood==0)foodtext.text = "農田LV. 1" + "  食物產量提升每秒5公斤";
		else if(Main.Afood==1)foodtext.text = "農田LV. 2" + "  食物產量提升每秒10公斤";
		else if(Main.Afood==2)foodtext.text = "農田LV. 3" + "  食物產量提升每秒15公斤";
		else foodtext.text = "農田已達最大值";
		//礦場
		if(Main.Amoney==0)moneytext.text = "礦場LV. 1" + "  金錢獲得提升每秒3塊";
		else if(Main.Amoney==1)moneytext.text = "礦場LV. 2" + "  金錢獲得提升每秒5塊";
		else if(Main.Amoney==2)moneytext.text = "礦場LV. 3" + "  金錢獲得提升每秒8塊";
		else moneytext.text = "礦場已達最大值";

		//要求=============================================================================================================================
		//酒館
		if(Main.Apeople==0)peoplertext.text ="2000\n\n\n\n\n\n50000\n\n100000";
		else if(Main.Apeople==1)peoplertext.text =  "5000\n\n\n\n\n\n100000\n\n200000";
		else if(Main.Apeople==2)peoplertext.text =  "10000\n\n\n\n\n\n300000\n\n500000";
		else peoplertext.text =" ";
		//鐵匠
		if(Main.Aweapon==0)weaponrtext.text ="3000\n\n5000\n\n\n\n50000\n\n100000";
		else if(Main.Aweapon==1)weaponrtext.text ="5000\n\n10000\n\n\n\n80000\n\n300000";
		else if(Main.Aweapon==2)weaponrtext.text ="10000\n\n50000\n\n\n\n100000\n\n500000";
		else weaponrtext.text =" ";
		//醫院
		if(Main.Ahospital==0)hospitalrtext.text ="1000\n\n\n\n20000\n\n10000\n\n150000";
		else if(Main.Ahospital==1)hospitalrtext.text ="5000\n\n\n\n100000\n\n30000\n\n200000";
		else if(Main.Ahospital==2)hospitalrtext.text ="20000\n\n\n\n200000\n\n70000\n\n400000";
		else hospitalrtext.text=" ";
		//農田
		if(Main.Afood==0)foodrtext.text ="5000\n\n\n\n8888\n\n50000\n\n180000";
		else if(Main.Afood==1)foodrtext.text ="50000\n\n\n\n88888\n\n111111\n\n300000";
		else if(Main.Afood==2)foodrtext.text ="100000\n\n\n\n888888\n\n222222\n\n660000";
		else foodrtext.text =" ";
		//礦場
		if(Main.Amoney==0)moneyrtext.text ="2000\n\n2000\n\n20000\n\n50000\n\n100000";
		else if(Main.Amoney==1)moneyrtext.text ="10000\n\n8000\n\n33000\n\n155000\n\n1000000";
		else if(Main.Amoney==2)moneyrtext.text ="80000\n\n10000\n\n50000\n\n500000\n\n2000000";
		else moneyrtext.text = " ";
			
		//按鈕=====================================================================================================================================
		//酒館
		if (Main.Apeople == 0 && Main.peoplesum >= 2000 && Main.foodsum>=50000 && Main.moneysum>=100000)peoplebutton.SetActive (true);
		else if(Main.Apeople == 1 && Main.peoplesum >= 5000 && Main.foodsum>=100000 && Main.moneysum>=200000)peoplebutton.SetActive (true);
		else if(Main.Apeople == 2 && Main.peoplesum >= 10000 && Main.foodsum>=300000 && Main.moneysum>=500000)peoplebutton.SetActive (true);
		else peoplebutton.SetActive (false);
		//鐵匠
		if (Main.Aweapon== 0 && Main.peoplesum >= 3000 && Main.weaponsum>=5000 && Main.foodsum>=50000 && Main.moneysum>=100000)weaponbutton.SetActive (true);
		else if(Main.Aweapon == 1 && Main.peoplesum >= 5000 && Main.weaponsum>=10000 && Main.foodsum>=80000 && Main.moneysum>=300000)weaponbutton.SetActive (true);
		else if(Main.Aweapon == 2 && Main.peoplesum >= 10000 && Main.weaponsum>=50000 && Main.foodsum>=100000 && Main.moneysum>=500000)weaponbutton.SetActive (true);
		else weaponbutton.SetActive (false);
		//醫院
		if (Main.Ahospital == 0 && Main.peoplesum >= 2000 && Main.hospitalsum>=20000 && Main.foodsum>=10000 && Main.moneysum>=150000)hospitalbutton.SetActive (true);
		else if(Main.Ahospital == 1 && Main.peoplesum >= 5000 && Main.hospitalsum>=100000 && Main.foodsum>=30000 && Main.moneysum>=200000)hospitalbutton.SetActive (true);
		else if(Main.Ahospital == 2 && Main.peoplesum >= 20000 && Main.hospitalsum>=200000 && Main.foodsum>=70000 && Main.moneysum>=400000)hospitalbutton.SetActive (true);
		else hospitalbutton.SetActive (false);
		//農田
		if (Main.Afood == 0 && Main.peoplesum >= 5000 && Main.hospitalsum>=8888 && Main.foodsum>=50000 && Main.moneysum>=180000)foodbutton.SetActive (true);
		else if(Main.Afood == 1 && Main.peoplesum >= 50000 && Main.hospitalsum>=88888 && Main.foodsum>=111111 && Main.moneysum>=300000)foodbutton.SetActive (true);
		else if(Main.Afood == 2 && Main.peoplesum >= 100000 && Main.hospitalsum>=888888 && Main.foodsum>=222222 && Main.moneysum>=660000)foodbutton.SetActive (true);
		else foodbutton.SetActive (false);
		//礦場
		if (Main.Amoney == 0 && Main.peoplesum >= 2000 && Main.weaponsum>=2000 && Main.hospitalsum>=20000 && Main.foodsum>=50000 && Main.moneysum>=100000)moneybutton.SetActive (true);
		else if(Main.Amoney == 1 && Main.peoplesum >= 10000 && Main.weaponsum>=8000 && Main.hospitalsum>=33000 && Main.foodsum>=155000 && Main.moneysum>=1000000)moneybutton.SetActive (true);
		else if(Main.Amoney == 2 && Main.peoplesum >= 80000 && Main.weaponsum>=10000 && Main.hospitalsum>=50000 && Main.foodsum>=500000 && Main.moneysum>=2000000)moneybutton.SetActive (true);
		else moneybutton.SetActive (false);

		//標題=======================================================================================================================================
		peoplettext.text = "房屋LV." + Main.Apeople;
		weaponttext.text = "鐵匠鋪LV." + Main.Aweapon;
		hospitalttext.text = "醫院LV." + Main.Ahospital;
		foodttext.text = "農田LV." + Main.Afood;
		moneyttext.text = "礦場LV." + Main.Amoney;

		//效率=========================================================================================================================================
		//酒館
		if(Main.Apeople==0)peoplestext.text = "人口每秒增加 0 人";
		else if(Main.Apeople==1)peoplestext.text = "人口每秒增加 1 人";
		else if(Main.Apeople==2)peoplestext.text = "人口每秒增加 2 人";
		else if(Main.Apeople==3)peoplestext.text = "人口每秒增加 5 人";
		else peoplestext.text = "人口每秒增加 5 人";

		if(Main.Aweapon==0)weaponstext.text = "武器每秒增加 0 把";
		else if(Main.Aweapon==1)weaponstext.text = "武器每秒增加 2 把";
		else if(Main.Aweapon==2)weaponstext.text = "武器每秒增加 5 把";
		else if(Main.Aweapon==3)weaponstext.text = "武器每秒增加 8 把";	
		else weaponstext.text = "武器每秒增加 8 把";	

		if(Main.Ahospital==0)hospitalstext.text = "醫療每秒增加 0 箱";
		else if(Main.Ahospital==1)hospitalstext.text = "醫療每秒增加 2 箱";
		else if(Main.Ahospital==2)hospitalstext.text = "醫療每秒增加 3 箱";
		else if(Main.Ahospital==3)hospitalstext.text = "醫療每秒增加 5 箱";
		else hospitalstext.text = "醫療每秒增加 5 箱";

		if(Main.Afood==0)foodstext.text = "食物每秒增加 0 公斤";
		else if(Main.Afood==1)foodstext.text ="食物每秒增加 5 公斤";
		else if(Main.Afood==2)foodstext.text ="食物每秒增加 10 公斤";
		else if(Main.Afood==3)foodstext.text ="食物每秒增加 15 公斤";
		else foodstext.text ="食物每秒增加 15 公斤";
			
		if(Main.Amoney==0)moneystext.text = "金錢每秒增加 0 塊";
		else if(Main.Amoney==1)moneystext.text = "金錢每秒增加 3 塊";
		else if(Main.Amoney==2)moneystext.text = "金錢每秒增加 5 塊";
		else if(Main.Amoney==3)moneystext.text = "金錢每秒增加 8 塊";
		else moneystext.text = "金錢每秒增加 8 塊";
		//內容===================================================================================================================
		people.text = "" + Main.peoplesum;
		weapon.text = "" +  Main.weaponsum;
		hospital.text = "" +  Main.hospitalsum;
		foods.text = "" +  Main.foodsum;
		kmtext.text = "總航行里程(km): " + Main.kmsum;
		money.text = "" +  Main.moneysum;

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
		PlayerPrefs.SetInt("YESorNO",  Main.yesorno );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了

		PlayerPrefs.SetInt("Apeoplesum", Main.Apeople );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Aweaponsum", Main.Aweapon );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Ahospitalsum", Main.Ahospital );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Afoodsum", Main.Afood );
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
	}//Update結束

	//按下按鈕*******************************************************************
	public void push()
	{
		ButtonMusic.Play();
		//已按下
		Application.LoadLevelAsync ("Ascene");

	}

	public void Bpush()
	{
		ButtonMusic.Play();
		//已按下
		Application.LoadLevelAsync ("Bscene");

	}

	public void ACpush()
	{
		ButtonMusic.Play();
		//已按下
		Application.LoadLevelAsync ("Acscene");

	}

	//返回***************************************************************************
	public void back()
	{
		BackMusic.Play ();
		MainFadeout.SetActive (true);
		//已按下
		//Application.LoadLevelAsync ("Main");
	}

	//主功能********************************************************************************
	//酒館===========================================
	public void People()
	{
		BulidSeccess.Play ();
		if (Main.Apeople == 0) {
			Main.peoplesum = Main.peoplesum - 2000;
			Main.foodsum = Main.foodsum - 50000;
			Main.moneysum = Main.moneysum - 100000;
		} else if (Main.Apeople == 1) {
			Main.peoplesum = Main.peoplesum - 5000;
			Main.foodsum = Main.foodsum - 100000;
			Main.moneysum = Main.moneysum - 200000;
		} else if (Main.Apeople == 2) {
			Main.peoplesum = Main.peoplesum - 10000;
			Main.foodsum = Main.foodsum - 300000;
			Main.moneysum = Main.moneysum - 500000;
		}	
		Main.Apeople++;
	}
		
	//鐵匠===========================================
	public void Weapon()
	{
		BulidSeccess.Play ();
		if (Main.Aweapon == 0) {
			Main.peoplesum = Main.peoplesum - 3000;
			Main.weaponsum = Main.weaponsum - 5000;
			Main.foodsum = Main.foodsum - 50000;
			Main.moneysum = Main.moneysum - 100000;
		} else if (Main.Aweapon == 1) {
			Main.peoplesum = Main.peoplesum - 5000;
			Main.weaponsum = Main.weaponsum - 10000;
			Main.foodsum = Main.foodsum - 80000;
			Main.moneysum = Main.moneysum - 300000;
			
		} else if (Main.Aweapon == 2) {
			Main.peoplesum = Main.peoplesum - 10000;
			Main.weaponsum = Main.weaponsum - 50000;
			Main.foodsum = Main.foodsum - 100000;
			Main.moneysum = Main.moneysum - 500000;
		}
		Main.Aweapon++;
		SaveImage.Play ();
	}



	//醫院===========================================
	public void Hospital()
	{
		BulidSeccess.Play ();
		if (Main.Ahospital == 0) {
			Main.peoplesum = Main.peoplesum - 1000;
			Main.hospitalsum = Main.hospitalsum - 20000;
			Main.foodsum = Main.foodsum - 10000;
			Main.moneysum = Main.moneysum - 150000;
		} else if (Main.Ahospital == 1) {
			Main.peoplesum = Main.peoplesum - 5000;
			Main.hospitalsum = Main.hospitalsum - 100000;
			Main.foodsum = Main.foodsum - 30000;
			Main.moneysum = Main.moneysum - 200000;

		} else if (Main.Ahospital == 2) {
			Main.peoplesum = Main.peoplesum - 20000;
			Main.hospitalsum = Main.hospitalsum - 200000;
			Main.foodsum = Main.foodsum - 70000;
			Main.moneysum = Main.moneysum - 400000;
		}
		Main.Ahospital++;
		SaveImage.Play ();
	}



	//食物===========================================
	public void Food()
	{
		BulidSeccess.Play ();
		if (Main.Afood == 0) {
			Main.peoplesum = Main.peoplesum - 5000;
			Main.hospitalsum = Main.hospitalsum - 8888;
			Main.foodsum = Main.foodsum - 50000;
			Main.moneysum = Main.moneysum - 180000;
		} else if (Main.Afood == 1) {
			Main.peoplesum = Main.peoplesum - 50000;
			Main.hospitalsum = Main.hospitalsum - 88888;
			Main.foodsum = Main.foodsum - 111111;
			Main.moneysum = Main.moneysum - 3000000;

		} else if (Main.Afood == 2) {
			Main.peoplesum = Main.peoplesum - 100000;
			Main.hospitalsum = Main.hospitalsum - 888888;
			Main.foodsum = Main.foodsum - 222222;
			Main.moneysum = Main.moneysum - 660000;
		}
		Main.Afood++;
		SaveImage.Play ();
	}


	//礦場===========================================
	public void Money()
	{
		BulidSeccess.Play ();
		if (Main.Amoney == 0) {
			Main.peoplesum = Main.peoplesum - 2000;
			Main.weaponsum = Main.weaponsum - 2000;
			Main.hospitalsum = Main.hospitalsum - 20000;
			Main.foodsum = Main.foodsum - 50000;
			Main.moneysum = Main.moneysum - 100000;
		} else if (Main.Amoney == 1) {
			Main.peoplesum = Main.peoplesum - 10000;
			Main.weaponsum = Main.weaponsum - 8000;
			Main.hospitalsum = Main.hospitalsum - 33000;
			Main.foodsum = Main.foodsum - 155000;
			Main.moneysum = Main.moneysum - 1000000;

		} else if (Main.Amoney == 2) {
			Main.peoplesum = Main.peoplesum - 80000;
			Main.weaponsum = Main.weaponsum - 10000;
			Main.hospitalsum = Main.hospitalsum - 50000;
			Main.foodsum = Main.foodsum - 500000;
			Main.moneysum = Main.moneysum - 2000000;
		}
		Main.Amoney++;
		SaveImage.Play ();
	}




}
