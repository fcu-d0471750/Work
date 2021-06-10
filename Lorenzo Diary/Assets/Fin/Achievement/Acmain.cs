//成果
using UnityEngine;
using System.Collections;
using System.Threading;  //使用延遲
using  UnityEngine.UI;   //使用UI
public class Acmain : MonoBehaviour {

	//================================================================================================================================
	public GameObject Image1;   //獎章圖示 
	public GameObject Image1out; //灰色獎章圖示

	public GameObject Image2;   //獎章圖示 
	public GameObject Image2out; //灰色獎章圖示

	public GameObject Image3;   //獎章圖示 
	public GameObject Image3out; //灰色獎章圖示

	public GameObject Image4;   //獎章圖示 
	public GameObject Image4out; //灰色獎章圖示

	public GameObject Image5;   //獎章圖示 
	public GameObject Image5out;//灰色獎章圖示

	public GameObject Image6;   //獎章圖示 
	public GameObject Image6out; //灰色獎章圖示

	public GameObject Image7;   //獎章圖示 
	public GameObject Image7out; //灰色獎章圖示

	public GameObject Image8;   //獎章圖示 
	public GameObject Image8out; //灰色獎章圖示

	public GameObject Image9;   //獎章圖示 
	public GameObject Image9out; //灰色獎章圖示

	public GameObject Image10;   //獎章圖示 
	public GameObject Image10out; //灰色獎章圖示

	public GameObject Image11;   //獎章圖示 
	public GameObject Image11out; //灰色獎章圖示

	public GameObject Image12;   //獎章圖示 
	public GameObject Image12out; //灰色獎章圖示

	public GameObject Image13;   //獎章圖示 
	public GameObject Image13out; //灰色獎章圖示

	public GameObject Image14;   //獎章圖示 
	public GameObject Image14out; //灰色獎章圖示

	public GameObject Image15;   //獎章圖示 
	public GameObject Image15out; //灰色獎章圖示

	public GameObject Image16;   //獎章圖示 
	public GameObject Image16out; //灰色獎章圖示

	public GameObject Image17;   //獎章圖示 
	public GameObject Image17out; //灰色獎章圖示

	public GameObject Image18;   //獎章圖示 
	public GameObject Image18out; //灰色獎章圖示

	public GameObject Image19;   //獎章圖示 
	public GameObject Image19out; //灰色獎章圖示

	public GameObject Image20;   //獎章圖示 
	public GameObject Image20out; //灰色獎章圖示

	//等級text***************************************************************************
	public Text peoplettext = null;
	public Text weaponttext = null;
	public Text hospitalttext = null;
	public Text foodttext = null;
	public Text moneyttext = null;

	//資源訊息******************************************************************************
	public Text peoplesumtext = null;  //人員總數
	public Text weaponsumtext = null;  //武器總數
	public Text hospitalsumtext = null;//醫療總數
	public Text foodsumtext = null;    //食物總數
	public Text moneysumtext = null;   //金錢總數

	public AudioSource ButtonMusic;    //按扭音效
	public AudioSource BackMusic;      //返回音效
	public AudioSource sceneMusic;     //背景音效
	public static int[] Get = new int[100];   //是否獲得過獎杯 0:沒獲得 1:已獲得

	public Animation LoadImage;        //載入Image
	public Animation Actext;           //文字動畫

	//淡出
	public GameObject MainFadeout; //主畫面淡出控制
	public GameObject NowChice;    //現在選擇亮點

	float timef;   //時間
	//獎杯text=============================================================================================================================
	public Text text1 = null;
	public Text text2 = null;


	// Use this for initialization
	void Start () {
		

		if(Musicbotton.musicplay) sceneMusic.Play(); 
		else sceneMusic.Pause(); 
		sceneMusic.volume = Musicbotton.MusicVo;
		//讀取=============================================================================
		Get[1] =  PlayerPrefs.GetInt("A1"); //讀入成就記錄(以下相同)
		Get[2] =  PlayerPrefs.GetInt("A2"); //讀入成就記錄(以下相同)
		Get[3] =  PlayerPrefs.GetInt("A3"); //讀入成就記錄(以下相同)
		Get[4] =  PlayerPrefs.GetInt("A4"); //讀入成就記錄(以下相同)
		Get[5] =  PlayerPrefs.GetInt("A5"); //讀入成就記錄(以下相同)
		Get[6] =  PlayerPrefs.GetInt("A6"); //讀入成就記錄(以下相同)
		Get[7] =  PlayerPrefs.GetInt("A7"); //讀入成就記錄(以下相同)
		Get[8] =  PlayerPrefs.GetInt("A8"); //讀入成就記錄(以下相同)
		Get[9] =  PlayerPrefs.GetInt("A9"); //讀入成就記錄(以下相同)
		Get[10] =  PlayerPrefs.GetInt("A10"); //讀入成就記錄(以下相同)
		Get[11] =  PlayerPrefs.GetInt("A11"); //讀入成就記錄(以下相同)
		Get[12] =  PlayerPrefs.GetInt("A12"); //讀入成就記錄(以下相同)
		Get[13] =  PlayerPrefs.GetInt("A13"); //讀入成就記錄(以下相同)
		Get[14] =  PlayerPrefs.GetInt("A14"); //讀入成就記錄(以下相同)
		Get[15] =  PlayerPrefs.GetInt("A15"); //讀入成就記錄(以下相同)
		Get[16] =  PlayerPrefs.GetInt("A16"); //讀入成就記錄(以下相同)
		Get[17] =  PlayerPrefs.GetInt("A17"); //讀入成就記錄(以下相同)
		Get[18] =  PlayerPrefs.GetInt("A18"); //讀入成就記錄(以下相同)
		Get[19] =  PlayerPrefs.GetInt("A19"); //讀入成就記錄(以下相同)
		Get[20] =  PlayerPrefs.GetInt("A20"); //讀入成就記錄(以下相同)



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

		//資源數量訊息
		peoplesumtext.text = "" + Main.peoplesum;    //人員總數
		weaponsumtext.text = "" + Main.weaponsum;    //武器總數
		hospitalsumtext.text= "" + Main.hospitalsum; //醫療總數
		foodsumtext.text = "" + Main.foodsum;        //食物總數
		moneysumtext.text = "" + Main.moneysum;      //金錢總數
		//標題訊息=======================================================================================================================================
		peoplettext.text = "房屋LV." + Main.Apeople;     //房屋等級
		weaponttext.text = "工廠LV." + Main.Aweapon;     //工廠等級
		hospitalttext.text = "醫院LV." + Main.Ahospital; //醫院等級
		foodttext.text = "農田LV." + Main.Afood;         //農田等級
		moneyttext.text = "礦場LV." + Main.Amoney;       //礦場等級



		//======================================================================
		//得到獎杯===================================================================================================
		if (Main.peoplesum >= 100000)Get [1] = 1;
		if (Main.peoplesum >= 1000000)Get [2] = 1;
		if (Main.peoplesum >= 10000000)Get [3] = 1;

		if (Main.weaponsum >= 100000)Get[4] = 1;
		if (Main.weaponsum >= 1000000)Get[5] = 1;
		if (Main.weaponsum >= 10000000)Get[6] = 1; 	

		if (Main.hospitalsum >= 100000)Get[7] = 1;
		if (Main.hospitalsum >= 1000000)Get[8] = 1;
		if (Main.hospitalsum >= 10000000)Get[9] = 1;

		if(Main.foodsum>=100000)Get[10]=1;
		if(Main.foodsum>=1000000)Get[11]=1;
		if(Main.foodsum>=10000000)Get[12]=1;

		if(Main.moneysum>=8888888)Get[13] = 1;
		if(Main.kmsum>=100000)Get[14] = 1;

		if(Main.Apeople==3)Get[15] = 1;
		if(Main.Aweapon==3)Get[16] = 1;
		if(Main.Ahospital==3)Get[17] = 1;
		if(Main.Afood==3)Get[18] = 1;
		if(Main.Amoney==3)Get[19] = 1;

		if (Get [1] == 1 && Get [2] == 1 && Get [3] == 1 && Get [4] == 1 && Get [5] == 1 && Get [6] == 1 && Get [7] == 1 && Get [8] == 1 && Get [9] == 1 && Get [10] == 1 && Get [11] == 1 && Get [12] == 1 && Get [13] == 1 && Get [14] == 1 && Get [15] == 1 && Get [16] == 1 && Get [17] == 1 && Get [18] == 1 && Get [19] == 1)
			Get [20] = 1;

		//顯示獎杯====================================================================================
		if(Get [1]==0)
		{
			Image1out.SetActive(true); //灰色獎章圖示
			Image1.SetActive(false);   //獎章圖示 
		}
		else if(Get [1]==1)
		{
			Image1out.SetActive(false); //灰色獎章圖示
			Image1.SetActive(true);   //獎章圖示 
		}

		if(Get [2]==0)
		{
			Image2out.SetActive(true); //灰色獎章圖示
			Image2.SetActive(false);   //獎章圖示 
		}
		else if(Get [2]==1)
		{
			Image2out.SetActive(false); //灰色獎章圖示
			Image2.SetActive(true);   //獎章圖示 
		}

		if(Get [3]==0)
		{
			Image3out.SetActive(true); //灰色獎章圖示
			Image3.SetActive(false);   //獎章圖示 
		}
		else if(Get [3]==1)
		{
			Image3out.SetActive(false); //灰色獎章圖示
			Image3.SetActive(true);   //獎章圖示 
		}

		if(Get [4]==0)
		{
			Image4out.SetActive(true); //灰色獎章圖示
			Image4.SetActive(false);   //獎章圖示 
		}
		else if(Get [4]==1)
		{
			Image4out.SetActive(false); //灰色獎章圖示
			Image4.SetActive(true);   //獎章圖示 
		}

		if(Get [5]==0)
		{
			Image5out.SetActive(true); //灰色獎章圖示
			Image5.SetActive(false);   //獎章圖示 
		}
		else if(Get [5]==1)
		{
			Image5out.SetActive(false); //灰色獎章圖示
			Image5.SetActive(true);   //獎章圖示 
		}
		//====================================================
		if(Get [6]==0)
		{
			Image6out.SetActive(true); //灰色獎章圖示
			Image6.SetActive(false);   //獎章圖示 
		}
		else if(Get [6]==1)
		{
			Image6out.SetActive(false); //灰色獎章圖示
			Image6.SetActive(true);   //獎章圖示 
		}

		if(Get [7]==0)
		{
			Image7out.SetActive(true); //灰色獎章圖示
			Image7.SetActive(false);   //獎章圖示 
		}
		else if(Get [7]==1)
		{
			Image7out.SetActive(false); //灰色獎章圖示
			Image7.SetActive(true);   //獎章圖示 
		}

		if(Get [8]==0)
		{
			Image8out.SetActive(true); //灰色獎章圖示
			Image8.SetActive(false);   //獎章圖示 
		}
		else if(Get [8]==1)
		{
			Image8out.SetActive(false); //灰色獎章圖示
			Image8.SetActive(true);   //獎章圖示 
		}

		if(Get [9]==0)
		{
			Image9out.SetActive(true); //灰色獎章圖示
			Image9.SetActive(false);   //獎章圖示 
		}
		else if(Get [9]==1)
		{
			Image9out.SetActive(false); //灰色獎章圖示
			Image9.SetActive(true);   //獎章圖示 
		}

		if(Get [10]==0)
		{
			Image10out.SetActive(true); //灰色獎章圖示
			Image10.SetActive(false);   //獎章圖示 
		}
		else if(Get [10]==1)
		{
			Image10out.SetActive(false); //灰色獎章圖示
			Image10.SetActive(true);   //獎章圖示 
		}
		//====================================================
		if(Get [11]==0)
		{
			Image11out.SetActive(true); //灰色獎章圖示
			Image11.SetActive(false);   //獎章圖示 
		}
		else if(Get [11]==1)
		{
			Image11out.SetActive(false); //灰色獎章圖示
			Image11.SetActive(true);   //獎章圖示 
		}

		if(Get [12]==0)
		{
			Image12out.SetActive(true); //灰色獎章圖示
			Image12.SetActive(false);   //獎章圖示 
		}
		else if(Get [12]==1)
		{
			Image12out.SetActive(false); //灰色獎章圖示
			Image12.SetActive(true);   //獎章圖示 
		}

		if(Get [13]==0)
		{
			Image13out.SetActive(true); //灰色獎章圖示
			Image13.SetActive(false);   //獎章圖示 
		}
		else if(Get [13]==1)
		{
			Image13out.SetActive(false); //灰色獎章圖示
			Image13.SetActive(true);   //獎章圖示 
		}

		if(Get [14]==0)
		{
			Image14out.SetActive(true); //灰色獎章圖示
			Image14.SetActive(false);   //獎章圖示 
		}
		else if(Get [14]==1)
		{
			Image14out.SetActive(false); //灰色獎章圖示
			Image14.SetActive(true);   //獎章圖示 
		}

		if(Get [15]==0)
		{
			Image15out.SetActive(true); //灰色獎章圖示
			Image15.SetActive(false);   //獎章圖示 
		}
		else if(Get [15]==1)
		{
			Image15out.SetActive(false); //灰色獎章圖示
			Image15.SetActive(true);   //獎章圖示 
		}
		//====================================================
		if(Get [16]==0)
		{
			Image16out.SetActive(true); //灰色獎章圖示
			Image16.SetActive(false);   //獎章圖示 
		}
		else if(Get [16]==1)
		{
			Image16out.SetActive(false); //灰色獎章圖示
			Image16.SetActive(true);   //獎章圖示 
		}

		if(Get [17]==0)
		{
			Image17out.SetActive(true); //灰色獎章圖示
			Image17.SetActive(false);   //獎章圖示 
		}
		else if(Get [17]==1)
		{
			Image17out.SetActive(false); //灰色獎章圖示
			Image17.SetActive(true);   //獎章圖示 
		}

		if(Get [18]==0)
		{
			Image18out.SetActive(true); //灰色獎章圖示
			Image18.SetActive(false);   //獎章圖示 
		}
		else if(Get [18]==1)
		{
			Image18out.SetActive(false); //灰色獎章圖示
			Image18.SetActive(true);   //獎章圖示 
		}

		if(Get [19]==0)
		{
			Image19out.SetActive(true); //灰色獎章圖示
			Image19.SetActive(false);   //獎章圖示 
		}
		else if(Get [19]==1)
		{
			Image19out.SetActive(false); //灰色獎章圖示
			Image19.SetActive(true);   //獎章圖示 
		}

		if(Get [20]==0)
		{
			Image20out.SetActive(true); //灰色獎章圖示
			Image20.SetActive(false);   //獎章圖示 
		}
		else if(Get [20]==1)
		{
			Image20out.SetActive(false); //灰色獎章圖示
			Image20.SetActive(true);   //獎章圖示 
		}


		//存檔===========================================================================================================
		PlayerPrefs.SetInt("A1", Get[1] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A2", Get[2] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A3", Get[3] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A4", Get[4] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A5", Get[5] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A6", Get[6] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A7", Get[7] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A8", Get[8] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A9", Get[9] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A10", Get[10] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A11", Get[11] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A12", Get[12] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A13", Get[13] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A14", Get[14] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A15", Get[15] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A16", Get[16] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A17", Get[17] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A18", Get[18] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A19", Get[19] );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("A20", Get[20] );
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

	}//Update結束=====================================================================================================

	//返回=============================================================================================================
	public void back()
	{
		BackMusic.Play ();
		MainFadeout.SetActive (true);
		//Application.LoadLevel("Main");
	}


		



	//===================================================================================================================
	//獎杯1
	public void A1()
	{
		ButtonMusic.Play();
		//LoadImage.Play ();
		if(Get[1]==1){
		text1.text = "基本人口";
		text2.text = "人口達到100,000人，一個國家要強大，\n人就要夠多，人一多拳頭就夠硬。";
		}
		else{
			text1.text = "基本******";
			text2.text = "人口達到100,000人，一個****要**大，\n人就要夠多，人************硬。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-358.2f, 223.7f, 0);
	}

	//獎杯2
	public void A2()
	{
		ButtonMusic.Play();
		if (Get [2] == 1) {
			text1.text = "人口擴張的歷史";
			text2.text = "人口突破1,000,000人，人口開始不斷增加\n這歷史性的一刻，會派人寫進專書。";
		} else {
			text1.text = "人口********歷史";
			text2.text = "人口****破1,000,000人，人口****不斷增加\n這******的一刻，會派人******書。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-253.47f, 223.7f, 0);
	}

	//獎杯3
	public void A3()
	{
		ButtonMusic.Play();
		if (Get [3] == 1) {
			text1.text = "人口大調度";
			text2.text = "人口終於10,000,000人，人口已經過剩\n我們需要更多的土地，讓人們有更多地方住。";
		} else {
			text1.text = "****大調度";
			text2.text = "人口終於10,000,000人，人******過剩\n我們需要更多******，讓**************住。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-142.92f, 223.7f, 0);
    }

	//獎杯4
	public void A4()
	{
		ButtonMusic.Play();
		if (Get [4] == 1) {
			text1.text = "我有一支槍!";
			text2.text = "武器數量獲得100,000個，小心一點這可是我花錢收買海關而來的，可別弄壞它。";
		}
		else{
			text1.text = "我有一支****!";
			text2.text = "武器數量獲得100,000個，小心一點********花錢收買******來的，可****壞它。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-36.23f, 223.7f, 0);
	}

	//獎杯5
	public void A5()
	{
		ButtonMusic.Play();
		if (Get [5] == 1) {
			text1.text = "廢棄舊工廠";
			text2.text = "武器數量得到1,000,000個，工廠不斷的加蓋，\n可是我們不需要這麼多工廠，只能把一些工廠丟在一邊積灰塵。";
		} else {
			text1.text = "******工廠";
			text2.text = "武器數量得到1,000,000個，工廠**********，\n可是我們************工廠，只能把一些工廠丟在一邊******。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(77.0f, 223.7f, 0);
	}

	//獎杯6
	public void A6()
	{
		ButtonMusic.Play();
		if (Get [6] == 1) {
			text1.text = "詭兵器";
			text2.text = "武器數量擁有10,000,000個，雖然充滿殺傷力，從眾多失敗的武器中誕生，但不論有怎樣的過去，野獸就是野獸。";
		} else {
			text1.text = "詭****";
			text2.text = "武器數量擁有10,000,000個，雖然充滿******，從眾多失敗************，但不論有******過去，野獸就是野獸。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(182.4f, 223.7f, 0);
	}

	//獎杯7
	public void A7()
	{
		ButtonMusic.Play();
		if (Get [7] == 1) {
			text1.text = "診所";
			text2.text = "藥品數量達到100,000箱，規模比醫院小的醫療機構，通常只設有門診服務和藥房，還有一些診所由慈善機構開辦，有如健康院。";
		} else {
			text1.text = "**所";
			text2.text = "藥品數量達到100,000箱，**************醫療機構，通常只設有********和藥房，還有一些診所由慈善機構****，有如******。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(291.4f, 223.7f, 0);
	}

	//獎杯8
	public void A8()
	{
		ButtonMusic.Play();
		if (Get [8] == 1) {
			text1.text = "醫院";
			text2.text = "藥品數量儲存1,000,000箱，治療和護理病人的機構，也兼做健康檢查、疾病預防等。大部分醫院通常是由政府資助，不以盈利為目的。同時，也存在以盈利為目的的私立醫院。";
		} else {
			text1.text = "**院";
			text2.text = "藥品數量儲存1,000,000箱，治療和********的機構，也兼做********、疾病預防等。大部分************政府資助，****盈利為目的。同時，也存在以********************。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-358.8f, 127.1f, 0);
	}

	//獎杯9
	public void A9()
	{
		ButtonMusic.Play();
		if (Get [9] == 1) {
			text1.text = "象牙塔";
			text2.text = "藥品數量總共10,000,000箱，當我們說一個人住在象牙塔裡時，就是說他不食人間煙火，只活在自己的夢想幻境之中，一切實際。象牙塔一詞現在已經是較負面的貶意用法。";
		} else {
			text1.text = "象****";
			text2.text = "藥品數量總共10,000,000箱，當我們說******住在******裡時，就是說他不食人間煙火，只**********夢想幻境之中，一切實際。**************已經是較負面的貶意用法。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-253.33f, 127.1f, 0);
	}

	//獎杯10
	public void A10()
	{
		ButtonMusic.Play();
		if (Get [10] == 1) {
			text1.text = "我也是要吃飯的";
			text2.text = "食物收成100,000公斤，一個人對於食物進食的渴望，有時可能是因為飢餓所造成。";
		} else {
			text1.text = "******吃飯的";
			text2.text = "食物收成100,000公斤，一個人對於*********渴望，有時可能是因為****所造成。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-143.79f, 127.1f, 0);
	}

	//獎杯11
	public void A11()
	{
		ButtonMusic.Play();
		if (Get [11] == 1) {
			text1.text = "好像有點飽";
			text2.text = "食物收獲1,000,000公斤，能夠藉由進食或是飲用為人類、生物提供營養或愉悅的物質。";
		} else {
			text1.text = "好像*********";
			text2.text = "食物收獲1,000,000公斤，能夠藉由****或是****為人類、生物********或愉悅的物質。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-33.98f, 127.1f, 0);
	}

	//獎杯12
	public void A12()
	{
		ButtonMusic.Play();
		if (Get [12] == 1) {
			text1.text = "吃不下了";
			text2.text = "食物達到10,000,000公斤，現在國家的倉庫都塞滿了上噸的食物，再不想辦法解決，就只能丟掉了。";
		} else {
			text1.text = "吃****了";
			text2.text = "食物達到10,000,000公斤，現在國家的******塞滿了********，再不想辦法解決，就*******了。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(77.23f, 127.1f, 0);
	}

	//獎杯13
	public void A13()
	{
		ButtonMusic.Play();
		if (Get [13] == 1) {
			text1.text = "良善金杯";
			text2.text = "金錢8,888,888，透過金礦的累積，現在終於可以打造一座純金的獎杯了。";
		} else {
			text1.text = "****金杯";
			text2.text = "金錢8,888,888，透********累積，現在*******打造一座********了。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(182.65f, 127.1f, 0);
	}

	//獎杯14
	public void A14()
	{
		ButtonMusic.Play();
		if (Get [14] == 1) {
			text1.text = "起源之船";
			text2.text = "航行總里程100,000公里\n「高樹多悲風，海水揚其波。」\n航海自古以來就是屬於男人的浪漫，萬里獨行，始於船下。";
		} else {
			text1.text = "起源****";
			text2.text = "航行總里程100,000公里\n「高樹****風，**水揚*****。」\n航海自古以來就是屬於*****浪漫，萬里****，******下。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(293.22f, 127.1f, 0);
	}

	//獎杯15
	public void A15()
	{
		ButtonMusic.Play();
		if (Get [15] == 1) {
			text1.text = "Big House";
			text2.text = "房屋等級3，想像當初那樣的破房子，連一點小雨都檔不住，現在都有了厚厚的水泥牆了。";
		} else {
			text1.text = "Big***********";
			text2.text = "房屋等級3，想像當初那樣的******，連一點******檔不住，現在****************牆了。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-361.07f, 29.3f, 0);
	}

	//獎杯16
	public void A16()
	{
		ButtonMusic.Play();
		if (Get [16] == 1) {
			text1.text = "卡斯爾武器工坊";
			text2.text = "武器工廠等級3，藉由不斷的鍛造經驗，現在最大的武器製造商就是卡斯爾。";
		} else {
			text1.text = "******武器工坊";
			text2.text = "武器工廠等級3，藉由不斷*******驗，現在最大的***************卡斯爾。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-250.57f, 29.3f, 0);
	}

	//獎杯17
	public void A17()
	{
		ButtonMusic.Play();
		if (Get [17] == 1) {
			text1.text = "白教堂";
			text2.text = "醫院等級3，隨著醫院的擴建，越來越多人被救活，為了感謝蓋了一座白色教堂。";
		} else {
			text1.text = "白****";
			text2.text = "醫院等級3，隨著**********，越來越多人******，為了感謝****************。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-138.92f, 29.3f, 0);
	}

	//獎杯18
	public void A18()
	{
		ButtonMusic.Play();
		if (Get [18] == 1) {
			text1.text = "美食系";
			text2.text = "農場等級3，食物的種類越來越多，產量也日漸增加，可以製作出越來越多好吃的美食。";
		} else {
			text1.text = "****系";
			text2.text = "農場等級3，食物的************，******日漸增加，可以*******************的美食。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(-30.18f, 29.3f, 0);
	}

	//獎杯19
	public void A19()
	{
		ButtonMusic.Play();
		if (Get [19] == 1) {
			text1.text = "伊茲金杯";
			text2.text = "礦場等級3，礦工為了賺取較多生活費用，在一座座蓋了又塌塌了又蓋的礦區，日以繼夜的工作。";
		} else {
			text1.text = "********";
			text2.text = "礦場等級3，礦工為了****************，在一座座蓋了又塌塌************，日**********作。";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(78.24f, 29.3f, 0);
	}

	//獎杯20
	public void A20()
	{
		ButtonMusic.Play();
		if (Get [20] == 1) {
			text1.text = "蘇美魯金杯";
			text2.text = "得到全部獎杯，每每到夜深人靜之時，總會有人無法入眠，追求著不可能的可能，只有莽夫才會做這樣的事";
		} else {
			text1.text = "**********";
			text2.text = "****************************************";
		}

		Actext.Play ();  //播放文字動畫
		NowChice.transform.localPosition = new Vector3(186.81f, 29.3f, 0);
	}


}
