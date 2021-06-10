//經營頁面 UI控制 邏輯運算 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manage : MonoBehaviour {

	//宣告變數==============================================================================
	//區域編號
	public static int Manage_Area_Number = 0; 
	//選擇投資店鋪編號
	int Invest_Store_Number = 0;

	//經理現在選擇編號
	int Now_Select_Manage_Number = 0;
	//警衛現在選擇編號
	int Now_Select_Security_Number = 0;
	//顧問現在選擇編號
	int Now_Select_Consultant_Number = 0;

	//已僱用經理最大編號
	int Now_Max_Manage_Number = 0;
	//已僱用警衛最大編號
	int Now_Max_Security_Number = 0;
	//已僱用顧問最大編號
	int Now_Max_Consultant_Number = 0;

	//是否為決定畫面 true:是 fasle:不是
	bool DecisionBool = false;

	//是否進入店鋪經驗動畫 true:進入動畫 false:未進入動畫
	bool LevelEx_Bool = false;
	//店鋪經驗值暫存
	float LevelEx_Temp;
	//動畫時間
	float LevelEx_Temp_Time = 2.0f;
	//宣告UI================================================================================
	//Scroll*******************************************************
	public Scrollbar scrollbar;
	//GameObject**************************************************
	//Work畫面
	public GameObject WorkBackGround;
	//Manage畫面
	public GameObject ManageBackGround;
	//顧問選擇畫面
	public GameObject ManageStore;
	//決定畫面
	public GameObject Decision;
	//店鋪畫面
	public GameObject StoreBackGround;
	//人員畫面
	public GameObject ManagePeopleBackGround;
	//區域背景圖片
	public GameObject OnePlace;
	public GameObject TwoPlace;
	public GameObject ThreePlace;
	public GameObject FourPlace;
	public GameObject FivePlace;
	//按鈕==========================================================
	public Button LeftButton;

	//店鋪頁面按鈕*************************************************
	//店鋪按鈕
	public Button StoreButton;
	//店舖經營按鈕
	public Button[] ManageButton = new Button[10];
	//店舖投資按鈕
	public Button ManageInvestionButton;
	//店舖取消投資按鈕
	public Button ManageCancelButton;
	//上一位按鈕
	public Button PreviousButton;
	//下一位按鈕
	public Button NextButton;

	//人員頁面按鈕*************************************************
	//人員按鈕
	public Button PeopleButton;
	//經理出勤按鈕
	public Button Manage_Work_Button;
	//經理卸任按鈕
	public Button Manage_UnWork_Button;
	//警衛出勤按鈕
	public Button Security_Work_Button;
	//警衛卸任按鈕
	public Button Security_UnWork_Button;

	//Text==========================================================
	//持有金錢
	public Text OwnMoney_Text;

	//區域名稱
	public Text AreaName_Text;
	//佔有率
	public Text OccupancyPresent_Text;
	//店鋪數
	public Text StoreNumber_Text;
	//預期利潤
	public Text Predict_Text;

	//店鋪***************************************************
	//店鋪名稱
	public Text[] StoreName_Text = new Text[10];
	//店鋪預期利潤
	public Text[] StorePredict_Text = new Text[10];
	//店鋪等級
	public Text[] StoreLevel_Text = new Text[10];

	//顧問名稱
	public Text ConsultantName_Text;
	//顧問支援能力
	public Text AdvantageNumber1_Text;
	public Text AdvantageNumber2_Text;
	public Text AdvantageNumber3_Text;
	public Text AdvantageNumber4_Text;
	public Text AdvantageNumber5_Text;
	//顧問支援能力
	public Text ConsultantAdvantage_Text;
	//顧問薪水
	public Text ConsultantSalary_Text;

	//人員***************************************************
	//經理名稱
	public Text ManageName_Text;
	//經理能力階級
	public Text ManageNumber_Text;
	//經理薪水
	public Text ManageSalary_Text;
	//經理自我介紹
	public Text ManageIntroduce_Text;

	//警衛名稱
	public Text SecurityName_Text;
	//警衛能力階級
	public Text SecurityNumber_Text;
	//警衛薪水
	public Text SecuritySalary_Text;
	//警衛自我介紹
	public Text SecurityIntroduce_Text;

	//Image==========================================================
	//區域圖片
	public Image Area_Image;
	//區域佔有率圖片
	public Image Present_Image;



	//店鋪***************************************************
	//店鋪圖片
	public Image[] Store_Image = new Image[10];
	//店鋪分類圖片
	public Image[] ClassImage = new Image[10];
	//店鋪是否投資圖片
	public Image[] InvestImage = new Image[10];
	//擁有店鋪圖片
	public Image[] OwnImage = new Image[10];
	//未擁有店鋪圖片
	public Image[] UnOwnImage = new Image[10];
	//店舖等級長條圖
	public Image[] LevelBarImage = new Image[10];


	//人員***************************************************
	//經理圖片
	public Image ManageImage;
	//經理能力階級圖片
	public Image ManageNumber_Image;
	//經理出勤圖片
	public Image ManageWork_Image;

	//警衛圖片
	public Image SecurityImage;
	//警衛能力階級圖片
	public Image SecurityManageNumber_Image;
	//警衛出勤圖片
	public Image SecurityWork_Image;

	//顧問圖片
	public Image ConsultantImage;
	//顧問能力階級圖片
	public Image ConsultantManageNumber_Image;


	//區域經理圖片
	public Image EconomyPeople_Image;
	//區域警衛圖片
	public Image SecurityPeople_Image;
	//景氣圖片
	public Image NowEconomy_Image;
	//治安圖片
	public Image NowSecurity_Image;

	//宣告動畫============================================================
	//店鋪預期利潤上升動畫
	public Animation[] Predict_UP_Animation = new Animation[10];
	//區域總預期利潤上升動畫
	public Animation Area_Predict_UP_Animation;
	//店鋪等級上升動畫
	public Animation[] Level_UP_Animation = new Animation[10];
	//指派經理 警衛動畫
	public Animation[] Now_Manage_Security_Animation = new Animation[2];
	//持有金錢變化動畫
	public Animation Own_Money_Change_Animation;
	//顧問選擇動畫
	public Animation ConsultantBackGround_Animation;

	

	// Use this for initialization
	void Start () {
		//將店鋪按鈕設為不可用
		StoreButton.interactable = false;
		//人員按鈕設為可用
		PeopleButton.interactable = true; 
	}

	// Update is called once per frame
	void Update () {

		//設定按鈕=========================================================
		//進入畫面設定已擁有的店鋪的經營按鈕為可用或不可用
		Set_First_ManageButton();

		//設定Text==========================================================
		//持有金錢
		MainState.SetText_OwnMoney(OwnMoney_Text);
		//區域名稱
		Set_AreaName_Text(AreaName_Text);
		//佔有率
		Set_OccupancyPresent_Text (OccupancyPresent_Text);
		//店鋪數
		Set_StoreNumber_Text(StoreNumber_Text);
		//預期利潤
		Set_Price_Text(Predict_Text);
		//店鋪名稱
		Set_StoreName_Text(StoreName_Text);
		//店鋪預期利潤
		Set_StorePredict_Text(StorePredict_Text);
		//店鋪等級
		Set_StoreLevel_Text(StoreLevel_Text);
		//找出已雇用經理 警衛 顧問最大編號 
		Find_Max_Employee_Number();
		//設定支援能力顏色
		if(Decision) AdvantageNumber_Color();

		//設定圖片==========================================================
		//設定區域背景圖片
		Set_PlaceBackGround_Image();
		//副程式:設定區域圖片
		Set_Place_Image();
		//副程式:設定佔有率圖片
		Set_Present_Image();
		//副程式:設定區域經理圖片
		Set_Area_Manage_Image ();
		//副程式:設定區域警衛圖片
		Set_Area_Security_Image();
		//副程式:設定店鋪分類圖片
		Set_Store_Class_Image();
		//副程式:設定店鋪圖片
		Set_Store_Image();
		//副程式:設定店鋪投資圖片
		Set_Store_Invest_Image();
		//副程式:設定店鋪是否擁有圖片
		Set_Store_Own_Image();
		//副程式:設定店鋪等級經驗圖片
		Set_Store_LevelEX_Image();
		//副程式:設定出勤中圖片和出勤按鈕
		Set_Work_Image_Button();
		//副程式:設定景氣圖片
		Set_NowEconomy_Image();
		//副程式:設定治安圖片
		Set_NowSecurity_Image();

		//店鋪經驗動畫=====================================================
		if(LevelEx_Bool) LevelEx_ADD(Invest_Store_Number);

		//Android_ScrollBar();

	}


	//副程式:設定區域名稱Text
	void Set_AreaName_Text(Text AreaName_Text){
		switch(Manage_Area_Number){
		//麵包師傅
		case 0:
			AreaName_Text.text = "<color=#F1C080FF>麵包師傅區域</color>";
			break;
			//音樂人
		case 1:
			AreaName_Text.text = "<color=#E4F3E0FF>音樂人區域</color>";
			break;
			//科技新貴
		case 2:
			AreaName_Text.text = "<color=#7FB4FFFF>科技新貴區域</color>";
			break;
			//機工
		case 3:
			AreaName_Text.text = "<color=#FF9090FF>機工區域</color>";
			break;
			//銀行家
		case 4:
			AreaName_Text.text = "<color=#FFAAE4FF>銀行家區域</color>";
			break;
		}//switch
	}
	//副程式:設定占有率Text
	void Set_OccupancyPresent_Text(Text OccupancyPresent_Text){
		switch(Manage_Area_Number){
		//麵包師傅
		case 0:
			OccupancyPresent_Text.text = MainState.BreadArea.GetPresent() + "%";
			break;
			//音樂人
		case 1:
			OccupancyPresent_Text.text = MainState.MusicArea.GetPresent() + "%";
			break;
			//科技新貴
		case 2:
			OccupancyPresent_Text.text = MainState.TehcnologyArea.GetPresent() + "%";
			break;
			//機工
		case 3:
			OccupancyPresent_Text.text = MainState.FactoryArea.GetPresent() + "%";
			break;
			//銀行家
		case 4:
			OccupancyPresent_Text.text = MainState.EconomicArea.GetPresent() + "%";
			break;
		}//switch
	}
	//副程式:設定店鋪數Text
	void Set_StoreNumber_Text(Text StoreNumber_Text){
		//店鋪數
		int StoreTemp = 0;

		switch(Manage_Area_Number){
		//麵包師傅
		case 0:
			for (int i = 0; i < MainState.BreadStoreNumber; i++) {
				if (MainState.BreadStore [i].GetOwnBool()) {
					StoreTemp = StoreTemp + 1;
				}
			}
			StoreNumber_Text.text = StoreTemp + " / " + MainState.BreadStoreNumber + "間";
			break;
			//音樂人
		case 1:
			for (int i = 0; i < MainState.MusicStoreNumber; i++) {
				if (MainState.MusicStore [i].GetOwnBool()) {
					StoreTemp = StoreTemp + 1;
				}
			}
			StoreNumber_Text.text = StoreTemp + " / " + MainState.MusicStoreNumber + "間";
			break;
			//科技新貴
		case 2:
			for (int i = 0; i < MainState.TehcnologyStoreNumber; i++) {
				if (MainState.TehcnologyStore [i].GetOwnBool()) {
					StoreTemp = StoreTemp + 1;
				}
			}
			StoreNumber_Text.text = StoreTemp + " / " + MainState.TehcnologyStoreNumber + "間";
			break;
			//機工
		case 3:
			for (int i = 0; i < MainState.FactoryStoreNumber; i++) {
				if (MainState.FactoryStore [i].GetOwnBool()) {
					StoreTemp = StoreTemp + 1;
				}
			}
			StoreNumber_Text.text = StoreTemp + " / " + MainState.FactoryStoreNumber + "間";
			break;
			//銀行家
		case 4:
			for (int i = 0; i < MainState.EconomicStoreNumber; i++) {
				if (MainState.EconomicStore [i].GetOwnBool()) {
					StoreTemp = StoreTemp + 1;
				}
			}
			StoreNumber_Text.text = StoreTemp + " / " + MainState.EconomicStoreNumber + "間";
			break;
		}//switch
	}

	//副程式:設定預期利潤Text
	void Set_Price_Text(Text Predict_Text){
		uint PriceTemp = 0;

		switch(Manage_Area_Number){
		//預期利潤(麵包師傅)
		case 0:
			for (int i = 0; i < MainState.BreadStoreNumber; i++) {
				if (MainState.BreadStore [i].GetOwnBool ())
					PriceTemp = PriceTemp + MainState.BreadStore [i].GetPrice ()*(uint)MainState.BreadStore[i].GetLevel();
			}
			MainState.SetText_Pricey (PriceTemp, Predict_Text);
			PriceTemp = 0;
			break;
			//預期利潤(音樂人)
		case 1:
			for (int i = 0; i < MainState.MusicStoreNumber; i++) {
				if (MainState.MusicStore [i].GetOwnBool())
					PriceTemp = PriceTemp + MainState.MusicStore[i].GetPrice()*(uint)MainState.MusicStore[i].GetLevel();
			}
			MainState.SetText_Pricey (PriceTemp,Predict_Text);
			PriceTemp = 0;
			break;
			//預期利潤(科技新貴)
		case 2:
			for (int i = 0; i < MainState.TehcnologyStoreNumber; i++) {
				if (MainState.TehcnologyStore [i].GetOwnBool ())
					PriceTemp = PriceTemp + MainState.TehcnologyStore [i].GetPrice ()*(uint)MainState.TehcnologyStore[i].GetLevel();
			}
			MainState.SetText_Pricey (PriceTemp, Predict_Text);
			PriceTemp = 0;
			break;
			//預期利潤(機工)
		case 3:
			for (int i = 0; i < MainState.FactoryStoreNumber; i++) {
				if (MainState.FactoryStore [i].GetOwnBool ())
					PriceTemp = PriceTemp + MainState.FactoryStore [i].GetPrice ()*(uint)MainState.FactoryStore[i].GetLevel();
			}
			MainState.SetText_Pricey (PriceTemp, Predict_Text);
			PriceTemp = 0;
			break;
			//預期利潤(銀行家)
		case 4:
			for (int i = 0; i < MainState.EconomicStoreNumber; i++) {
				if (MainState.EconomicStore [i].GetOwnBool())
					PriceTemp = PriceTemp + MainState.EconomicStore[i].GetPrice()*(uint)MainState.EconomicStore[i].GetLevel();
			}
			MainState.SetText_Pricey (PriceTemp,Predict_Text);
			PriceTemp = 0;
			break;
		}//switch

	}

	//副程式:設定店鋪名稱Text
	void Set_StoreName_Text(Text[] StoreName_Text){

		switch(Manage_Area_Number){
		//預期利潤(麵包師傅)
		case 0:
			for (int i = 0; i < MainState.BreadStoreNumber; i++) {
				StoreName_Text[i].text = MainState.BreadStore[i].GetName();
			}
			break;
			//預期利潤(音樂人)
		case 1:
			for (int i = 0; i < MainState.MusicStoreNumber; i++) {
				StoreName_Text[i].text = MainState.MusicStore[i].GetName();
			}
			break;
			//預期利潤(科技新貴)
		case 2:
			for (int i = 0; i < MainState.TehcnologyStoreNumber; i++) {
				StoreName_Text[i].text = MainState.TehcnologyStore[i].GetName();
			}
			break;
			//預期利潤(機工)
		case 3:
			for (int i = 0; i < MainState.FactoryStoreNumber; i++) {
				StoreName_Text[i].text = MainState.FactoryStore[i].GetName();
			}
			break;
			//預期利潤(銀行家)
		case 4:
			for (int i = 0; i < MainState.EconomicStoreNumber; i++) {
				StoreName_Text[i].text = MainState.EconomicStore[i].GetName();
			}
			break;
		}//switch

	}

	//副程式:設定店鋪預期利潤Text
	void Set_StorePredict_Text(Text[] StorePredict_Text){

		switch(Manage_Area_Number){
		//預期利潤(麵包師傅)
		case 0:
			for (int i = 0; i < MainState.BreadStoreNumber; i++) {
				//預期利潤 = 店鋪最低預期利潤 * 店鋪等級
				MainState.SetText_Pricey (MainState.BreadStore[i].GetPrice()*(uint)MainState.BreadStore[i].GetLevel(), StorePredict_Text[i]);
			}
			break;
			//預期利潤(音樂人)
		case 1:
			for (int i = 0; i < MainState.MusicStoreNumber; i++) {
				//預期利潤 = 店鋪最低預期利潤 * 店鋪等級
				MainState.SetText_Pricey (MainState.MusicStore[i].GetPrice()*(uint)MainState.MusicStore[i].GetLevel(), StorePredict_Text[i]);
			}
			break;
			//預期利潤(科技新貴)
		case 2:
			for (int i = 0; i < MainState.TehcnologyStoreNumber; i++){
				//預期利潤 = 店鋪最低預期利潤 * 店鋪等級
				MainState.SetText_Pricey (MainState.TehcnologyStore[i].GetPrice()*(uint)MainState.TehcnologyStore[i].GetLevel(), StorePredict_Text[i]);
			}
			break;
			//預期利潤(機工)
		case 3:
			for (int i = 0; i < MainState.FactoryStoreNumber; i++){
				//預期利潤 = 店鋪最低預期利潤 * 店鋪等級
				MainState.SetText_Pricey (MainState.FactoryStore[i].GetPrice()*(uint)MainState.FactoryStore[i].GetLevel(), StorePredict_Text[i]);
			}
			break;
			//預期利潤(銀行家)
		case 4:
			for (int i = 0; i < MainState.EconomicStoreNumber; i++){
				//預期利潤 = 店鋪最低預期利潤 * 店鋪等級
				MainState.SetText_Pricey (MainState.EconomicStore[i].GetPrice()*(uint)MainState.EconomicStore[i].GetLevel(), StorePredict_Text[i]);
			}
			break;
		}//switch

	}

	//副程式:設定店鋪等級Text
	void Set_StoreLevel_Text(Text[] StoreLevel_Text){

		switch(Manage_Area_Number){
		//預期利潤(麵包師傅)
		case 0:
			for (int i = 0; i < MainState.BreadStoreNumber; i++) {
				StoreLevel_Text [i].text = MainState.BreadStore [i].GetLevel () + "";
			}
			break;
			//預期利潤(音樂人)
		case 1:
			for (int i = 0; i < MainState.MusicStoreNumber; i++) {
				StoreLevel_Text [i].text = MainState.MusicStore [i].GetLevel () + "";
			}
			break;
			//預期利潤(科技新貴)
		case 2:
			for (int i = 0; i < MainState.TehcnologyStoreNumber; i++){
				StoreLevel_Text [i].text = MainState.TehcnologyStore [i].GetLevel () + "";
			}
			break;
			//預期利潤(機工)
		case 3:
			for (int i = 0; i < MainState.FactoryStoreNumber; i++){
				StoreLevel_Text [i].text = MainState.FactoryStore [i].GetLevel () + "";
			}
			break;
			//預期利潤(銀行家)
		case 4:
			for (int i = 0; i < MainState.EconomicStoreNumber; i++){
				StoreLevel_Text [i].text = MainState.EconomicStore [i].GetLevel () + "";
			}
			break;
		}//switch

	}

	//副程式:用人員按鈕設定經理 警衛Text
	public void Set_Manage_Security_Text(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//經理名稱
		ManageName_Text.text = MainState.Manage [Now_Select_Manage_Number].GetName () + "";

		//經理能力階級
		ManageNumber_Text.text = MainState.Manage[Now_Select_Manage_Number].GetAbility() + "";

		//經理薪水
		MainState.SetText_Pricey(MainState.Manage[Now_Select_Manage_Number].GetSalary() , ManageSalary_Text);

		//經理自我介紹
		ManageIntroduce_Text.text = MainState.Manage[Now_Select_Manage_Number].GetIntroduce() + "";

		//經理圖片
		ManageImage.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[Now_Select_Manage_Number]);

		//經理能力階級圖片
		ManageNumber_Image.fillAmount = MainState.Manage[Now_Select_Manage_Number].GetAbility() / 5.0f;

		//警衛名稱
		SecurityName_Text.text = MainState.Security [Now_Select_Security_Number].GetName () + "";

		//警衛能力階級
		SecurityNumber_Text.text = MainState.Security[Now_Select_Security_Number].GetAbility() + "";

		//警衛薪水
		MainState.SetText_Pricey(MainState.Security[Now_Select_Security_Number].GetSalary() , SecuritySalary_Text);

		//警衛自我介紹
		SecurityIntroduce_Text.text = MainState.Security[Now_Select_Security_Number].GetIntroduce() + "";

		//警衛圖片
		SecurityImage.sprite = (Sprite)Resources.Load<Sprite>(MainState.Security_Image_String[Now_Select_Security_Number]);

		//警衛能力階級圖片
		SecurityManageNumber_Image.fillAmount = MainState.Security[Now_Select_Security_Number].GetAbility() / 5.0f;

		//隱藏店鋪畫面
		StoreBackGround.SetActive(false);
		//隱藏選擇顧問畫面
		ManageStore.SetActive(false);
		//顯示人員畫面
		ManagePeopleBackGround.SetActive(true);
		//將店鋪按鈕設為可用
		StoreButton.interactable = true;
		//人員按鈕設為不可用
		PeopleButton.interactable = false;

	}

	//副程式:顯示店鋪畫面
	public void Show_ManageStore(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//隱藏人員畫面
		ManagePeopleBackGround.SetActive(false);
		//隱藏選擇顧問畫面
		ManageStore.SetActive(false);
		//顯示店鋪畫面
		StoreBackGround.SetActive (true);
		//將店鋪按鈕設為不可用
		StoreButton.interactable = false;
		//人員按鈕設為可用
		PeopleButton.interactable = true;
	}

	//副程式:顯示決定顧問畫面
	public void Show_Accept_Decision(){
		//播放PayBack音效
		MainState.PayBack_Button_Sounds_Play();

		//顯示決定顧問畫面
		Decision.SetActive (true);
		//上一位按鈕設為不可用
		PreviousButton.interactable = false;
		//下一位按鈕設為不可用
		NextButton.interactable = false;
		//確定投資按鈕為不可用
		ManageInvestionButton.interactable = false;
		//取消投資按鈕為不可用
		ManageCancelButton.interactable = false;
		//scrollBar設為不可用
		scrollbar.interactable = false;
		//是決定畫面
		DecisionBool = true;
	}

	//副程式:顯示取消選擇顧問畫面
	public void Show_Cancel_ManageStore(){
		//播放PayBack音效
		MainState.PayBack_Button_Sounds_Play();

		//隱藏選擇顧問畫面
		ManageStore.SetActive(false);

		//離開按鈕設為可用
		LeftButton.interactable = true;
		//店鋪按鈕設為不可用
		StoreButton.interactable = false;
		//人員按鈕設為可用
		PeopleButton.interactable = true;
		//scrollBar設為可用
		scrollbar.interactable = true;
		//不是決定畫面
		DecisionBool = false;

		//將已擁有店鋪的經營按鈕設為可用
		for(int i=0; i<10; i++){
			switch (Manage_Area_Number) {
			//麵包師傅
			case 0:
				if(MainState.BreadStore[i].GetOwnBool()==true ) ManageButton [i].interactable = true;
				break;
				//音樂人
			case 1:
				if(MainState.MusicStore[i].GetOwnBool()==true ) ManageButton [i].interactable = true;
				break;
				//科技新貴
			case 2:
				if(MainState.TehcnologyStore[i].GetOwnBool()==true ) ManageButton [i].interactable = true;
				break;
				//機工
			case 3:
				if(MainState.FactoryStore[i].GetOwnBool()==true ) ManageButton [i].interactable = true;
				break;
				//銀行家
			case 4:
				if(MainState.EconomicStore[i].GetOwnBool()==true ) ManageButton [i].interactable = true;
				break;

			}//switch
		}//for

	}

	//副程式:決定投資
	public void Invest_Decision(){
		//播放持有金錢變更動畫
		Own_Money_Change_Animation.Play();

		//將已擁有店鋪的經營按鈕設為可用====================================================================
		for(int i=0; i<10; i++){
			switch (Manage_Area_Number) {
			//麵包師傅
			case 0:
				if(MainState.BreadStore[i].GetOwnBool()==true) ManageButton [i].interactable = true;
				break;
				//音樂人
			case 1:
				if(MainState.MusicStore[i].GetOwnBool()==true) ManageButton [i].interactable = true;
				break;
				//科技新貴
			case 2:
				if(MainState.TehcnologyStore[i].GetOwnBool()==true) ManageButton [i].interactable = true;
				break;
				//機工
			case 3:
				if(MainState.FactoryStore[i].GetOwnBool()==true) ManageButton [i].interactable = true;
				break;
				//銀行家
			case 4:
				if(MainState.EconomicStore[i].GetOwnBool()==true) ManageButton [i].interactable = true;
				break;

			}//switch
		}//for

		//進行投資======================================================================================
		switch (Manage_Area_Number) {

		//麵包師傅
		case 0:
			//增加店鋪經驗==============
			//店鋪分類1:烹飪 2:音樂 3:科技 4:機工 5:金融
			if(MainState.BreadStore[Invest_Store_Number].GetClassification()==1){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:烹飪的階級)*30.0f)) / 現在店舖等級
				//MainState.BreadStore [Invest_Store_Number].SetLevelEx ( MainState.BreadStore[Invest_Store_Number].GetLevelEx() + ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility() + MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber())*30.0f) /  MainState.BreadStore [Invest_Store_Number].GetLevel ());
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber())*30.0f) /  MainState.BreadStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}
			else if(MainState.BreadStore[Invest_Store_Number].GetClassification()==2){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:音樂的階級)*30.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetMusicNumber())*30.0f)  /  MainState.BreadStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}
			else if(MainState.BreadStore[Invest_Store_Number].GetClassification()==3){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:科技的階級)*30.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetTechnologyNumber())*30.0f)  /  MainState.BreadStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	
			else if(MainState.BreadStore[Invest_Store_Number].GetClassification()==4){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:機工的階級)*30.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetFactoryNumber())*30.0f)  /  MainState.BreadStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	
			else if(MainState.BreadStore[Invest_Store_Number].GetClassification()==5){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:金融的階級)*30.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetEconomicNumber())*30.0f)  /  MainState.BreadStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	

			break;
			//音樂人
		case 1:
			//增加店鋪經驗==============
			//店鋪分類1:烹飪 2:音樂 3:科技 4:機工 5:金融
			if(MainState.MusicStore[Invest_Store_Number].GetClassification()==1){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:烹飪的階級)*25.0f)) / 現在店舖等級
				//MainState.MusicStore [Invest_Store_Number].SetLevelEx ( MainState.MusicStore[Invest_Store_Number].GetLevelEx() + ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility() + MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber())*25.0f) /  MainState.MusicStore [Invest_Store_Number].GetLevel ());
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant [Now_Select_Consultant_Number].GetAbility ()*2 + MainState.Consultant [Now_Select_Consultant_Number].GetFoodNumber ()) * 25.0f) / MainState.MusicStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}
			else if(MainState.MusicStore[Invest_Store_Number].GetClassification()==2){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:音樂的階級)*25.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetMusicNumber())*25.0f)  /  MainState.MusicStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}
			else if(MainState.MusicStore[Invest_Store_Number].GetClassification()==3){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:科技的階級)*25.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetTechnologyNumber())*25.0f)  /  MainState.MusicStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	
			else if(MainState.MusicStore[Invest_Store_Number].GetClassification()==4){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:機工的階級)*25.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetFactoryNumber())*25.0f)  /  MainState.MusicStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	
			else if(MainState.MusicStore[Invest_Store_Number].GetClassification()==5){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:金融的階級)*25.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetEconomicNumber())*25.0f)  /  MainState.MusicStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	

			break;
			//科技新貴
		case 2:
			//增加店鋪經驗==============
			//店鋪分類1:烹飪 2:音樂 3:科技 4:機工 5:金融
			if(MainState.TehcnologyStore[Invest_Store_Number].GetClassification()==1){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:烹飪的階級)*20.0f)) / 現在店舖等級
				//MainState.TehcnologyStore [Invest_Store_Number].SetLevelEx ( MainState.TehcnologyStore[Invest_Store_Number].GetLevelEx() + ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility() + MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber())*20.0f) /  MainState.TehcnologyStore [Invest_Store_Number].GetLevel ());
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber())*20.0f) /  MainState.TehcnologyStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}
			else if(MainState.TehcnologyStore[Invest_Store_Number].GetClassification()==2){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:音樂的階級)*20.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetMusicNumber())*20.0f)  /  MainState.TehcnologyStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}
			else if(MainState.TehcnologyStore[Invest_Store_Number].GetClassification()==3){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:科技的階級)*20.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetTechnologyNumber())*20.0f)  /  MainState.TehcnologyStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	
			else if(MainState.TehcnologyStore[Invest_Store_Number].GetClassification()==4){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:機工的階級)*20.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetFactoryNumber())*20.0f)  /  MainState.TehcnologyStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	
			else if(MainState.TehcnologyStore[Invest_Store_Number].GetClassification()==5){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:金融的階級)*20.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetEconomicNumber())*20.0f)  /  MainState.TehcnologyStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	

			break;
			//機工
		case 3:
			//增加店鋪經驗==============
			//店鋪分類1:烹飪 2:音樂 3:科技 4:機工 5:金融
			if(MainState.FactoryStore[Invest_Store_Number].GetClassification()==1){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:烹飪的階級)*17.0f)) / 現在店舖等級
				//MainState.FactoryStore [Invest_Store_Number].SetLevelEx ( MainState.FactoryStore[Invest_Store_Number].GetLevelEx() + ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility() + MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber())*17.0f) /  MainState.FactoryStore [Invest_Store_Number].GetLevel ());
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber())*17.0f) /  MainState.FactoryStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}
			else if(MainState.FactoryStore[Invest_Store_Number].GetClassification()==2){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:音樂的階級)*17.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetMusicNumber())*17.0f)  /  MainState.FactoryStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}
			else if(MainState.FactoryStore[Invest_Store_Number].GetClassification()==3){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:科技的階級)*17.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetTechnologyNumber())*17.0f)  /  MainState.FactoryStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	
			else if(MainState.FactoryStore[Invest_Store_Number].GetClassification()==4){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:機工的階級)*17.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetFactoryNumber())*17.0f)  /  MainState.FactoryStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	
			else if(MainState.FactoryStore[Invest_Store_Number].GetClassification()==5){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:金融的階級)*17.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetEconomicNumber())*17.0f)  /  MainState.FactoryStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	

			break;
			//銀行家
		case 4:
			//增加店鋪經驗==============
			//店鋪分類1:烹飪 2:音樂 3:科技 4:機工 5:金融
			if(MainState.EconomicStore[Invest_Store_Number].GetClassification()==1){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:烹飪的階級)*14.0f)) / 現在店舖等級
				//MainState.EconomicStore [Invest_Store_Number].SetLevelEx ( MainState.EconomicStore[Invest_Store_Number].GetLevelEx() + ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility() + MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber())*14.0f) /  MainState.EconomicStore [Invest_Store_Number].GetLevel ());
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber())*14.0f) /  MainState.EconomicStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}
			else if(MainState.EconomicStore[Invest_Store_Number].GetClassification()==2){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:音樂的階級)*14.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetMusicNumber())*14.0f)  /  MainState.EconomicStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}
			else if(MainState.EconomicStore[Invest_Store_Number].GetClassification()==3){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:科技的階級)*14.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetTechnologyNumber())*14.0f)  /  MainState.EconomicStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	
			else if(MainState.EconomicStore[Invest_Store_Number].GetClassification()==4){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:機工的階級)*14.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetFactoryNumber())*14.0f)  /  MainState.EconomicStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	
			else if(MainState.EconomicStore[Invest_Store_Number].GetClassification()==5){
				//店鋪經驗 = 原本店鋪經驗 + (((顧問能力階級 + 顧問支援能力:金融的階級)*14.0f)) / 現在店舖等級
				LevelEx_Bool = true;
				LevelEx_Temp = ((MainState.Consultant[Now_Select_Consultant_Number].GetAbility()*2 + MainState.Consultant[Now_Select_Consultant_Number].GetEconomicNumber())*14.0f)  /  MainState.EconomicStore [Invest_Store_Number].GetLevel ();
				LevelEx_ADD(Invest_Store_Number);
			}	

			break;

		}//switch

		//播放經驗值提升音效
		MainState.LevelEx_Button_Sounds_Play();

		//扣除持有金錢
		MainState.SUB_OwnMoney(MainState.Consultant[Now_Select_Consultant_Number].GetSalary() , OwnMoney_Text);

	}
	//副程式:隱藏決定畫面
	public void Show_Cancel_Decision(){
		//播放PayBack音效
		MainState.PayBack_Button_Sounds_Play();

		//隱藏決定顧問畫面
		Decision.SetActive(false);
		//上一位按鈕設為可用
		PreviousButton.interactable = true;
		//下一位按鈕設為可用
		NextButton.interactable = true;
		//確定投資按鈕為可用
		ManageInvestionButton.interactable = true;
		//取消投資按鈕為可用
		ManageCancelButton.interactable = true;
		//scrollBar設為不可用
		scrollbar.interactable = false;
		//是決定畫面
		DecisionBool = true;
	}

	//副程式:用經營按鈕設定顧問Text
	public void Set_Manage_Consultant_Text(int StoreNumber){
		//顯示顧問選擇
		ManageStore.SetActive(true);

		//播放PayBack音效
		MainState.PayBack_Button_Sounds_Play();

		//播放顧問選擇動畫
		ConsultantBackGround_Animation.Play();

		//設定投資店鋪編號
		Invest_Store_Number = StoreNumber;

		//顧問名稱
		ConsultantName_Text.text = MainState.Consultant [Now_Select_Consultant_Number].GetName () + "";

		//顧問能力階級
		ConsultantAdvantage_Text.text = MainState.Consultant[Now_Select_Consultant_Number].GetAbility() + "";
		//顧問能力階級圖片
		ConsultantManageNumber_Image.fillAmount = MainState.Consultant[Now_Select_Consultant_Number].GetAbility() / 5.0f;

		//支援能力
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber() , AdvantageNumber1_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetMusicNumber() , AdvantageNumber2_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetTechnologyNumber() , AdvantageNumber3_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetFactoryNumber() , AdvantageNumber4_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetEconomicNumber() , AdvantageNumber5_Text);

		//薪水
		MainState.SetText_Pricey(MainState.Consultant[Now_Select_Consultant_Number].GetSalary() , ConsultantSalary_Text);

		//離開按鈕設為不可用
		LeftButton.interactable = false;
		//店鋪按鈕設為不可用
		StoreButton.interactable = false;
		//人員按鈕設為不可用
		PeopleButton.interactable = false;
		//scrollBar設為不可用
		scrollbar.interactable = false;
		//是決定畫面
		DecisionBool = true;

		//判斷持有金錢有沒有大於顧問薪水，有則投資按鈕為可用 沒有則投資按鈕為不可用
		if(MainState.OwnMoney >= MainState.Consultant[Now_Select_Consultant_Number].GetSalary()) ManageInvestionButton.interactable = true;
		else ManageInvestionButton.interactable = false;

		//將經營按鈕都設為不可用
		for(int i=0; i<10; i++){
			ManageButton [i].interactable = false;
		}

		//顧問圖片
		ConsultantImage.sprite = (Sprite)Resources.Load<Sprite>(MainState.Consultant_Image_String[Now_Select_Consultant_Number]);

	}

	//副程式(上一位按鈕):設定經理Text
	public void Set_Previous_Manage_Text(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//如果是不是已雇用最小編號
		if (Now_Select_Manage_Number != 0) {
			//找出已雇用的經理編號
			for (int i = Now_Select_Manage_Number - 1; i >= 0; i--) {
				if (MainState.Manage [i].GetHire ()) {
					Now_Select_Manage_Number = i;
					break;
				}
			}
		}
		//如果是已雇用最小編號，回到已雇用最大編號經理
		else{
			Now_Select_Manage_Number = Now_Max_Manage_Number;
		}

		//經理名稱
		ManageName_Text.text = MainState.Manage [Now_Select_Manage_Number].GetName () + "";

		//經理能力階級
		ManageNumber_Text.text = MainState.Manage[Now_Select_Manage_Number].GetAbility() + "";

		//經理
		MainState.SetText_Pricey(MainState.Manage[Now_Select_Manage_Number].GetSalary() , ManageSalary_Text);

		//經理圖片
		ManageImage.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[Now_Select_Manage_Number]);

		//經理能力階級圖片
		ManageNumber_Image.fillAmount = MainState.Manage[Now_Select_Manage_Number].GetAbility() / 5.0f;

		//經理自我介紹
		ManageIntroduce_Text.text = MainState.Manage[Now_Select_Manage_Number].GetIntroduce() + "";

	}

	//副程式(上一位按鈕):設定警衛Text
	public void Set_Previous_Security_Text(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//如果是不是已雇用最小編號
		if (Now_Select_Security_Number != 0) {
			//找出已雇用的警衛編號
			for (int i = Now_Select_Security_Number - 1; i >= 0; i--) {
				if (MainState.Security [i].GetHire ()) {
					Now_Select_Security_Number = i;
					break;
				}
			}
		}
		//如果是已雇用最小編號，回到已雇用最大編號警衛
		else{
			Now_Select_Security_Number = Now_Max_Security_Number;
		}

		//警衛名稱
		SecurityName_Text.text = MainState.Security[Now_Select_Security_Number].GetName () + "";

		//警衛能力階級
		SecurityNumber_Text.text = MainState.Security[Now_Select_Security_Number].GetAbility() + "";

		//警衛
		MainState.SetText_Pricey(MainState.Security[Now_Select_Security_Number].GetSalary() , SecuritySalary_Text);

		//警衛圖片
		SecurityImage.sprite = (Sprite)Resources.Load<Sprite>(MainState.Security_Image_String[Now_Select_Security_Number]);

		//警衛能力階級圖片
		SecurityManageNumber_Image.fillAmount = MainState.Security[Now_Select_Security_Number].GetAbility() / 5.0f;

		//警衛自我介紹
		SecurityIntroduce_Text.text = MainState.Security[Now_Select_Security_Number].GetIntroduce() + "";

	}

	//副程式(上一位按鈕):設定顧問Text
	public void Set_Previous_Consultant_Text(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//如果是不是已雇用最小編號
		if (Now_Select_Consultant_Number != 0) {
			//找出已雇用的顧問編號
			for (int i = Now_Select_Consultant_Number - 1; i >= 0; i--) {
				if (MainState.Consultant [i].GetHire ()) {
					Now_Select_Consultant_Number = i;
					break;
				}
			}
		}
		//如果是已雇用最小編號，回到已雇用最大編號顧問
		else{
			Now_Select_Consultant_Number = Now_Max_Consultant_Number;
		}

		//顧問名稱
		ConsultantName_Text.text = MainState.Consultant [Now_Select_Consultant_Number].GetName () + "";

		//顧問能力階級
		ConsultantAdvantage_Text.text = MainState.Consultant[Now_Select_Consultant_Number].GetAbility() + "";
		//顧問能力階級圖片
		ConsultantManageNumber_Image.fillAmount = MainState.Consultant[Now_Select_Consultant_Number].GetAbility() / 5.0f;

		//支援能力
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber() , AdvantageNumber1_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetMusicNumber() , AdvantageNumber2_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetTechnologyNumber() , AdvantageNumber3_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetFactoryNumber() , AdvantageNumber4_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetEconomicNumber() , AdvantageNumber5_Text);

		//支援能力顏色
		AdvantageNumber_Color();

		//薪水
		MainState.SetText_Pricey(MainState.Consultant[Now_Select_Consultant_Number].GetSalary() , ConsultantSalary_Text);

		//判斷持有金錢有沒有大於顧問薪水，有則投資按鈕為可用 沒有則投資按鈕為不可用
		if(MainState.OwnMoney >= MainState.Consultant[Now_Select_Consultant_Number].GetSalary()) ManageInvestionButton.interactable = true;
		else ManageInvestionButton.interactable = false;

		//顧問圖片
		ConsultantImage.sprite = (Sprite)Resources.Load<Sprite>(MainState.Consultant_Image_String[Now_Select_Consultant_Number]);

	}

	//副程式(下一位按鈕):設定經理Text
	public void Set_Next_Manage_Text(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//如果是不是已雇用最大編號
		if (Now_Select_Manage_Number != Now_Max_Manage_Number) {
			//找出已雇用的經理編號
			for (int i = Now_Select_Manage_Number + 1; i < MainState.ManageNumber; i++) {
				if (MainState.Manage [i].GetHire ()) {
					Now_Select_Manage_Number = i;
					break;
				}
			}
		}
		//如果是已雇用最大編號，回到第1位經理
		else{
			Now_Select_Manage_Number = 0;
		}

		//經理名稱
		ManageName_Text.text = MainState.Manage [Now_Select_Manage_Number].GetName () + "";

		//經理能力階級
		ManageNumber_Text.text = MainState.Manage[Now_Select_Manage_Number].GetAbility() + "";

		//經理薪水
		MainState.SetText_Pricey(MainState.Manage[Now_Select_Manage_Number].GetSalary() , ManageSalary_Text);

		//經理圖片
		ManageImage.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[Now_Select_Manage_Number]);

		//經理能力階級圖片
		ManageNumber_Image.fillAmount = MainState.Manage[Now_Select_Manage_Number].GetAbility() / 5.0f;

		//經理自我介紹
		ManageIntroduce_Text.text = MainState.Manage[Now_Select_Manage_Number].GetIntroduce() + "";

	}

	//副程式(下一位按鈕):設定警衛Text
	public void Set_Next_Security_Text(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//如果是不是已雇用最大編號
		if (Now_Select_Security_Number != Now_Max_Security_Number) {
			//找出已雇用的警衛編號
			for (int i = Now_Select_Security_Number + 1; i < MainState.SecurityNumber; i++) {
				if (MainState.Security [i].GetHire ()) {
					Now_Select_Security_Number = i;
					break;
				}
			}
		}
		//如果是已雇用最大編號，回到第1位警衛
		else{
			Now_Select_Security_Number = 0;
		}

		//警衛名稱
		SecurityName_Text.text = MainState.Security [Now_Select_Security_Number].GetName () + "";

		//警衛能力階級
		SecurityNumber_Text.text = MainState.Security[Now_Select_Security_Number].GetAbility() + "";

		//警衛薪水
		MainState.SetText_Pricey(MainState.Security[Now_Select_Security_Number].GetSalary() , SecuritySalary_Text);

		//警衛圖片
		SecurityImage.sprite = (Sprite)Resources.Load<Sprite>(MainState.Security_Image_String[Now_Select_Security_Number]);

		//警衛能力階級圖片
		SecurityManageNumber_Image.fillAmount = MainState.Security[Now_Select_Security_Number].GetAbility() / 5.0f;

		//警衛自我介紹
		SecurityIntroduce_Text.text = MainState.Security[Now_Select_Security_Number].GetIntroduce() + "";

	}


	//副程式(下一位按鈕):設定顧問
	public void Set_Next_Consultant_Text(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//如果是不是已雇用最大編號
		if (Now_Select_Consultant_Number != Now_Max_Consultant_Number) {
			//找出已雇用的顧問編號
			for (int i = Now_Select_Consultant_Number + 1; i < MainState.ConsultantNumber; i++) {
				if (MainState.Consultant [i].GetHire ()) {
					Now_Select_Consultant_Number = i;
					break;
				}
			}
		}
		//如果是已雇用最大編號，回到第1位顧問
		else{
			Now_Select_Consultant_Number = 0;
		}

		//顧問名稱
		ConsultantName_Text.text = MainState.Consultant [Now_Select_Consultant_Number].GetName () + "";

		//顧問能力階級
		ConsultantAdvantage_Text.text = MainState.Consultant[Now_Select_Consultant_Number].GetAbility() + "";
		//顧問能力階級圖片
		ConsultantManageNumber_Image.fillAmount = MainState.Consultant[Now_Select_Consultant_Number].GetAbility() / 5.0f;

		//支援能力
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber() , AdvantageNumber1_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetMusicNumber() , AdvantageNumber2_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetTechnologyNumber() , AdvantageNumber3_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetFactoryNumber() , AdvantageNumber4_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetEconomicNumber() , AdvantageNumber5_Text);

		//支援能力顏色
		AdvantageNumber_Color();

		//薪水
		MainState.SetText_Pricey(MainState.Consultant[Now_Select_Consultant_Number].GetSalary() , ConsultantSalary_Text);

		//判斷持有金錢有沒有大於顧問薪水，有則投資按鈕為可用 沒有則投資按鈕為不可用
		if(MainState.OwnMoney >= MainState.Consultant[Now_Select_Consultant_Number].GetSalary()) ManageInvestionButton.interactable = true;
		else ManageInvestionButton.interactable = false;

		//顧問圖片
		ConsultantImage.sprite = (Sprite)Resources.Load<Sprite>(MainState.Consultant_Image_String[Now_Select_Consultant_Number]);

	}

	//副程式:找出已雇用經理 警衛 顧問最大編號 
	void Find_Max_Employee_Number(){

		//從最小編號到最大編號搜尋一遍，只要是已僱用員工則修改編號
		//********************************************************
		for (int i = 0; i < MainState.ManageNumber; i++) {
			if (MainState.Manage [i].GetHire ())
				Now_Max_Manage_Number = i;
		}

		for (int i = 0; i < MainState.SecurityNumber; i++) {
			if (MainState.Security [i].GetHire ())
				Now_Max_Security_Number = i;
		}

		for (int i = 0; i < MainState.ConsultantNumber; i++) {
			if (MainState.Consultant [i].GetHire ())
				Now_Max_Consultant_Number = i;
		}

	}

	//副程式:進入畫面設定已擁有的店鋪的經營按鈕為可用或不可用
	void Set_First_ManageButton(){

		//將未擁有店鋪 或 已投資店鋪的經營按鈕設為不可用
		for(int i=0; i<10; i++){
			switch (Manage_Area_Number) {
			//麵包師傅
			case 0:
				if(MainState.BreadStore[i].GetOwnBool()==false || MainState.BreadStore[i].GetInvestBool()==true || MainState.BreadArea.GetManage()==false || DecisionBool == true || MainState.BreadStore[i].GetLevel() == 10) ManageButton [i].interactable = false;
				else ManageButton [i].interactable = true;
				break;
				//音樂人
			case 1:
				if(MainState.MusicStore[i].GetOwnBool()==false || MainState.MusicStore[i].GetInvestBool()==true || MainState.MusicArea.GetManage()==false || DecisionBool == true || MainState.MusicStore[i].GetLevel() == 10) ManageButton [i].interactable = false;
				else ManageButton [i].interactable = true;
				break;
				//科技新貴
			case 2:
				if(MainState.TehcnologyStore[i].GetOwnBool()==false || MainState.TehcnologyStore[i].GetInvestBool()==true || MainState.TehcnologyArea.GetManage()==false || DecisionBool == true || MainState.TehcnologyStore[i].GetLevel() == 10) ManageButton [i].interactable = false;
				else ManageButton [i].interactable = true;
				break;
				//機工
			case 3:
				if(MainState.FactoryStore[i].GetOwnBool()==false || MainState.FactoryStore[i].GetInvestBool()==true || MainState.FactoryArea.GetManage()==false || DecisionBool == true || MainState.FactoryStore[i].GetLevel() == 10) ManageButton [i].interactable = false;
				else ManageButton [i].interactable = true;
				break;
				//銀行家
			case 4:
				if(MainState.EconomicStore[i].GetOwnBool()==false || MainState.EconomicStore[i].GetInvestBool()==true || MainState.EconomicArea.GetManage()==false || DecisionBool == true || MainState.EconomicStore[i].GetLevel() == 10) ManageButton [i].interactable = false;
				else ManageButton [i].interactable = true;
				break;

			}//switch
		}//for
	}


	//副程式:設定區域背景圖片
	void Set_PlaceBackGround_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			OnePlace.SetActive (true);
			TwoPlace.SetActive (false);
			ThreePlace.SetActive (false);
			FourPlace.SetActive (false);
			FivePlace.SetActive (false);
			break;
			//音樂人
		case 1:
			OnePlace.SetActive (false);
			TwoPlace.SetActive (true);
			ThreePlace.SetActive (false);
			FourPlace.SetActive (false);
			FivePlace.SetActive (false);
			break;
			//科技新貴
		case 2:
			OnePlace.SetActive (false);
			TwoPlace.SetActive (false);
			ThreePlace.SetActive (true);
			FourPlace.SetActive (false);
			FivePlace.SetActive (false);
			break;
			//機工
		case 3:
			OnePlace.SetActive (false);
			TwoPlace.SetActive (false);
			ThreePlace.SetActive (false);
			FourPlace.SetActive (true);
			FivePlace.SetActive (false);
			break;
			//銀行家
		case 4:
			OnePlace.SetActive (false);
			TwoPlace.SetActive (false);
			ThreePlace.SetActive (false);
			FourPlace.SetActive (false);
			FivePlace.SetActive (true);
			break;

		}//switch

	}

	//副程式:設定區域圖片
	void Set_Place_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//區域圖片(讀取在Resources資料夾的圖片)
			Area_Image.sprite = (Sprite)Resources.Load<Sprite>("Bread_InSide");
			break;
			//音樂人
		case 1:
			//區域圖片(讀取在Resources資料夾的圖片)
			Area_Image.sprite = (Sprite)Resources.Load<Sprite>("Music_InSide");
			break;
			//科技新貴
		case 2:
			//區域圖片(讀取在Resources資料夾的圖片)
			Area_Image.sprite = (Sprite)Resources.Load<Sprite>("Technology_InSide");
			break;
			//機工
		case 3:
			//區域圖片(讀取在Resources資料夾的圖片)
			Area_Image.sprite = (Sprite)Resources.Load<Sprite>("Factory_InSide");
			break;
			//銀行家
		case 4:
			//區域圖片(讀取在Resources資料夾的圖片)
			Area_Image.sprite = (Sprite)Resources.Load<Sprite>("Economic_InSide");
			break;

		}//switch
	}

	//副程式:設定佔有率圖片
	void Set_Present_Image(){
		float PresentTemp = 0.0f;

		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//區域佔有率(麵包師傅)
			for (int i = 0; i < MainState.BreadStoreNumber; i++) {
				if (MainState.BreadStore [i].GetOwnBool())
					PresentTemp = PresentTemp + 1.0f;
			}
			Present_Image.fillAmount = (PresentTemp / MainState.BreadStoreNumber);
			PresentTemp = 0.0f;
			break;
			//音樂人
		case 1:
			//區域佔有率(音樂人)
			for (int i = 0; i < MainState.MusicStoreNumber; i++) {
				if (MainState.MusicStore [i].GetOwnBool())
					PresentTemp = PresentTemp + 1.0f;
			}
			Present_Image.fillAmount = (PresentTemp / MainState.MusicStoreNumber);
			PresentTemp = 0.0f;
			break;
			//科技新貴
		case 2:
			//區域佔有率(科技新貴)
			for (int i = 0; i < MainState.TehcnologyStoreNumber; i++) {
				if (MainState.TehcnologyStore [i].GetOwnBool())
					PresentTemp = PresentTemp + 1.0f;
			}
			Present_Image.fillAmount = (PresentTemp / MainState.TehcnologyStoreNumber);
			PresentTemp = 0.0f;
			break;
			//機工
		case 3:
			//區域佔有率(機工)
			for (int i = 0; i < MainState.FactoryStoreNumber; i++) {
				if (MainState.FactoryStore [i].GetOwnBool())
					PresentTemp = PresentTemp + 1.0f;
			}
			Present_Image.fillAmount = (PresentTemp / MainState.FactoryStoreNumber);
			PresentTemp = 0.0f;
			break;
			//銀行家
		case 4:
			//區域佔有率(銀行家)
			for (int i = 0; i < MainState.EconomicStoreNumber; i++) {
				if (MainState.EconomicStore [i].GetOwnBool())
					PresentTemp = PresentTemp + 1.0f;
			}
			Present_Image.fillAmount = (PresentTemp / MainState.EconomicStoreNumber);
			PresentTemp = 0.0f;
			break;

		}//switch

	}


	//副程式:設定區域經理圖片
	void Set_Area_Manage_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//區域經理圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.ManageNumber; i++){
				//有經理出勤
				if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 0) {
					EconomyPeople_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[i]);
					break;
				}
				//沒有經理出勤
				else {
					EconomyPeople_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
				}
			}
			break;
			//音樂人
		case 1:
			//區域經理圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.ManageNumber; i++){
				//有經理出勤
				if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 1) {
					EconomyPeople_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[i]);
					break;
				}
				//沒有經理出勤
				else {
					EconomyPeople_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
				}
			}
			break;
			//科技新貴
		case 2:
			//區域經理圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.ManageNumber; i++){
				//有經理出勤
				if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 2) {
					EconomyPeople_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[i]);
					break;
				}
				//沒有經理出勤
				else {
					EconomyPeople_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
				}
			}
			break;
			//機工
		case 3:
			//區域經理圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.ManageNumber; i++){
				//有經理出勤
				if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 3) {
					EconomyPeople_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[i]);
					break;
				}
				//沒有經理出勤
				else {
					EconomyPeople_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
				}
			}
			break;
			//銀行家
		case 4:
			//區域經理圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.ManageNumber; i++){
				//有經理出勤
				if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 4) {
					EconomyPeople_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[i]);
					break;
				}
				//沒有經理出勤
				else {
					EconomyPeople_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
				}
			}
			break;

		}//switch
	}

	//副程式:設定區域警衛圖片
	void Set_Area_Security_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//區域警衛圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.SecurityNumber; i++){
				//有警衛出勤
				if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace () == 0) {
					SecurityPeople_Image.sprite = (Sprite)Resources.Load<Sprite> (MainState.Security_Image_String [i]);
					break;
				}
				//沒有警衛出勤
				else {
					SecurityPeople_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
				}
			}
			break;
			//音樂人
		case 1:
			//區域警衛圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.SecurityNumber; i++){
				//有警衛出勤
				if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace() == 1) {
					SecurityPeople_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Security_Image_String[i]);
					break;
				}
				//沒有警衛出勤
				else {
					SecurityPeople_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
				}
			}
			break;
			//科技新貴
		case 2:
			//區域警衛圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.SecurityNumber; i++){
				//有警衛出勤
				if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace() == 2) {
					SecurityPeople_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Security_Image_String[i]);
					break;
				}else {
					SecurityPeople_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
				}
			}
			break;
			//機工
		case 3:
			//區域警衛圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.SecurityNumber; i++){
				//有警衛出勤
				if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace() == 3) {
					SecurityPeople_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Security_Image_String[i]);
					break;
				}
				//沒有警衛出勤
				else {
					SecurityPeople_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
				}
			}
			break;
			//銀行家
		case 4:
			//區域警衛圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.SecurityNumber; i++){
				//有警衛出勤
				if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace() == 4) {
					SecurityPeople_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Security_Image_String[i]);
					break;
				}
				//沒有警衛出勤
				else {
					SecurityPeople_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
				}
			}
			break;

		}//switch
	}

	//副程式:設定店鋪分類圖片
	void Set_Store_Class_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪分類圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.BreadStoreNumber; i++){
				//1:烹飪  
				if(MainState.BreadStore[i].GetClassification()==1)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("food");
				//2:音樂
				else if(MainState.BreadStore[i].GetClassification()==2)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("music-player");
				//3:科技 
				else if(MainState.BreadStore[i].GetClassification()==3)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("smartphone-call");
				//4:機工 
				else if(MainState.BreadStore[i].GetClassification()==4)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("screwdriver-and-wrench-crossed");
				//5:金融
				else if(MainState.BreadStore[i].GetClassification()==5)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("bank-building");
			}
			break;
			//音樂人
		case 1:
			//店鋪分類圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.MusicStoreNumber; i++){
				//1:烹飪  
				if(MainState.MusicStore[i].GetClassification()==1)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("food");
				//2:音樂
				else if(MainState.MusicStore[i].GetClassification()==2)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("music-player");
				//3:科技 
				else if(MainState.MusicStore[i].GetClassification()==3)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("smartphone-call");
				//4:機工 
				else if(MainState.MusicStore[i].GetClassification()==4)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("screwdriver-and-wrench-crossed");
				//5:金融
				else if(MainState.MusicStore[i].GetClassification()==5)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("bank-building");
			}
			break;
			//科技新貴
		case 2:
			//店鋪分類圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.TehcnologyStoreNumber; i++){
				//1:烹飪  
				if(MainState.TehcnologyStore[i].GetClassification()==1)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("food");
				//2:音樂
				else if(MainState.TehcnologyStore[i].GetClassification()==2)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("music-player");
				//3:科技 
				else if(MainState.TehcnologyStore[i].GetClassification()==3)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("smartphone-call");
				//4:機工 
				else if(MainState.TehcnologyStore[i].GetClassification()==4)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("screwdriver-and-wrench-crossed");
				//5:金融
				else if(MainState.TehcnologyStore[i].GetClassification()==5)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("bank-building");
			}
			break;
			//機工
		case 3:
			//店鋪分類圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.FactoryStoreNumber; i++){
				//1:烹飪  
				if(MainState.FactoryStore[i].GetClassification()==1)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("food");
				//2:音樂
				else if(MainState.FactoryStore[i].GetClassification()==2)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("music-player");
				//3:科技 
				else if(MainState.FactoryStore[i].GetClassification()==3)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("smartphone-call");
				//4:機工 
				else if(MainState.FactoryStore[i].GetClassification()==4)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("screwdriver-and-wrench-crossed");
				//5:金融
				else if(MainState.FactoryStore[i].GetClassification()==5)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("bank-building");
			}
			break;
			//銀行家
		case 4:
			//店鋪分類圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.EconomicStoreNumber; i++){
				//1:烹飪  
				if(MainState.EconomicStore[i].GetClassification()==1)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("food");
				//2:音樂
				else if(MainState.EconomicStore[i].GetClassification()==2)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("music-player");
				//3:科技 
				else if(MainState.EconomicStore[i].GetClassification()==3)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("smartphone-call");
				//4:機工 
				else if(MainState.EconomicStore[i].GetClassification()==4)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("screwdriver-and-wrench-crossed");
				//5:金融
				else if(MainState.EconomicStore[i].GetClassification()==5)ClassImage[i].sprite = (Sprite)Resources.Load<Sprite>("bank-building");
			}
			break;

		}//switch

	}

	//副程式:設定店鋪圖片
	void Set_Store_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.BreadStoreNumber; i++){
				Store_Image[i].sprite = (Sprite)Resources.Load<Sprite>(MainState.BreadStoreImage_String[i]);
			}
			break;
			//音樂人
		case 1:
			//店鋪圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.MusicStoreNumber; i++){
				Store_Image[i].sprite = (Sprite)Resources.Load<Sprite>(MainState.MusicStoreImage_String[i]);
			}
			break;
			//科技新貴
		case 2:
			//店鋪圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.TehcnologyStoreNumber; i++){
				Store_Image[i].sprite = (Sprite)Resources.Load<Sprite>(MainState.TehcnologyStoreImage_String[i]);
			}
			break;
			//機工
		case 3:
			//店鋪圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.FactoryStoreNumber; i++){
				Store_Image[i].sprite = (Sprite)Resources.Load<Sprite>(MainState.FactoryStoreImage_String[i]);
			}
			break;
			//銀行家
		case 4:
			//店鋪圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.EconomicStoreNumber; i++){
				Store_Image[i].sprite = (Sprite)Resources.Load<Sprite>(MainState.EconomicStoreImage_String[i]);
			}
			break;

		}//switch

	}

	//副程式:設定店鋪投資圖片
	void Set_Store_Invest_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪投資圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.BreadStoreNumber; i++){
				//已投資
				if (MainState.BreadStore [i].GetInvestBool () == true)
					InvestImage [i].color = new Color(255.0f,255.0f,255.0f,255.0f);
				//未投資
				else
					InvestImage [i].color = new Color(255.0f,255.0f,255.0f,0.0f);
			}
			break;
			//音樂人
		case 1:
			//店鋪投資圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.MusicStoreNumber; i++){
				//已投資
				if (MainState.MusicStore [i].GetInvestBool () == true)
					InvestImage [i].color = new Color(255.0f,255.0f,255.0f,255.0f);
				//未投資
				else
					InvestImage [i].color = new Color(255.0f,255.0f,255.0f,0.0f);
			}
			break;
			//科技新貴
		case 2:
			//店鋪投資圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.TehcnologyStoreNumber; i++){
				//已投資
				if (MainState.TehcnologyStore [i].GetInvestBool () == true)
					InvestImage [i].color = new Color(255.0f,255.0f,255.0f,255.0f);
				//未投資
				else
					InvestImage [i].color = new Color(255.0f,255.0f,255.0f,0.0f);
			}
			break;
			//機工
		case 3:
			//店鋪投資圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.FactoryStoreNumber; i++){
				//已投資
				if (MainState.FactoryStore [i].GetInvestBool () == true)
					InvestImage [i].color = new Color(255.0f,255.0f,255.0f,255.0f);
				//未投資
				else
					InvestImage [i].color = new Color(255.0f,255.0f,255.0f,0.0f);
			}
			break;
			//銀行家
		case 4:
			//店鋪投資圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.EconomicStoreNumber; i++){
				//已投資
				if (MainState.EconomicStore [i].GetInvestBool () == true)
					InvestImage [i].color = new Color(255.0f,255.0f,255.0f,255.0f);
				//未投資
				else
					InvestImage [i].color = new Color(255.0f,255.0f,255.0f,0.0f);
			}
			break;

		}//switch

	}

	//副程式:設定店鋪是否擁有圖片
	void Set_Store_Own_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪是否擁有圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.BreadStoreNumber; i++){
				//擁有
				if (MainState.BreadStore [i].GetOwnBool() == true) {
					OwnImage [i].color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
					UnOwnImage [i].color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} 
				//未擁有
				else {
					OwnImage [i].color = new Color(255.0f,255.0f,255.0f,0.0f);
					UnOwnImage[i].color = new Color(255.0f,255.0f,255.0f,255.0f);
				}
			}
			break;
			//音樂人
		case 1:
			//店鋪是否擁有圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.MusicStoreNumber; i++){
				//擁有
				if (MainState.MusicStore [i].GetOwnBool() == true) {
					OwnImage [i].color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
					UnOwnImage [i].color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} 
				//未擁有
				else {
					OwnImage [i].color = new Color(255.0f,255.0f,255.0f,0.0f);
					UnOwnImage[i].color = new Color(255.0f,255.0f,255.0f,255.0f);
				}
			}
			break;
			//科技新貴
		case 2:
			//店鋪是否擁有圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.TehcnologyStoreNumber; i++){
				//擁有
				if (MainState.TehcnologyStore [i].GetOwnBool() == true) {
					OwnImage [i].color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
					UnOwnImage [i].color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} 
				//未擁有
				else {
					OwnImage [i].color = new Color(255.0f,255.0f,255.0f,0.0f);
					UnOwnImage[i].color = new Color(255.0f,255.0f,255.0f,255.0f);
				}
			}
			break;
			//機工
		case 3:
			//店鋪是否擁有圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.FactoryStoreNumber; i++){
				//擁有
				if (MainState.FactoryStore [i].GetOwnBool() == true) {
					OwnImage [i].color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
					UnOwnImage [i].color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} 
				//未擁有
				else {
					OwnImage [i].color = new Color(255.0f,255.0f,255.0f,0.0f);
					UnOwnImage[i].color = new Color(255.0f,255.0f,255.0f,255.0f);
				}
			}
			break;
			//銀行家
		case 4:
			//店鋪是否擁有圖片(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.EconomicStoreNumber; i++){
				//擁有
				if (MainState.EconomicStore [i].GetOwnBool() == true) {
					OwnImage [i].color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
					UnOwnImage [i].color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} 
				//未擁有
				else {
					OwnImage [i].color = new Color(255.0f,255.0f,255.0f,0.0f);
					UnOwnImage[i].color = new Color(255.0f,255.0f,255.0f,255.0f);
				}
			}
			break;

		}//switch

	}

	//副程式:設定店鋪等級經驗圖片
	void Set_Store_LevelEX_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪等級
			for(int i=0; i<MainState.BreadStoreNumber; i++){
				LevelBarImage [i].fillAmount = MainState.BreadStore [i].GetLevelEx() / 100.0f;
			}
			break;
			//音樂人
		case 1:
			//店鋪等級
			for(int i=0; i<MainState.MusicStoreNumber; i++){
				LevelBarImage [i].fillAmount = MainState.MusicStore [i].GetLevelEx() / 100.0f;
			}
			break;
			//科技新貴
		case 2:
			//店鋪等級
			for(int i=0; i<MainState.TehcnologyStoreNumber; i++){
				LevelBarImage [i].fillAmount = MainState.TehcnologyStore [i].GetLevelEx() / 100.0f;
			}
			break;
			//機工
		case 3:
			//店鋪等級
			for(int i=0; i<MainState.FactoryStoreNumber; i++){
				LevelBarImage [i].fillAmount = MainState.FactoryStore [i].GetLevelEx() / 100.0f;
			}
			break;
			//銀行家
		case 4:
			//店鋪等級
			for(int i=0; i<MainState.EconomicStoreNumber; i++){
				LevelBarImage [i].fillAmount = MainState.EconomicStore [i].GetLevelEx() / 100.0f;
			}
			break;

		}//switch

	}

	//副程式:設定出勤中圖片和出勤按鈕
	void Set_Work_Image_Button(){
		//經理出勤圖片
		//出勤中
		if (MainState.Manage [Now_Select_Manage_Number].GetWork () == true) {
			//顯示出勤圖片
			ManageWork_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
			//出勤按鈕設為不可用
			Manage_Work_Button.interactable = false;
			//卸任按鈕設為可用
			Manage_UnWork_Button.interactable = true;
		}
		//未出勤
		else {
			//隱藏出勤圖片
			ManageWork_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			//出勤按鈕設為可用
			Manage_Work_Button.interactable = true;
			//卸任按鈕設為不可用
			Manage_UnWork_Button.interactable = false;
		}

		//警衛出勤圖片
		//出勤中
		if (MainState.Security [Now_Select_Security_Number].GetWork () == true) {
			//顯示出勤圖片
			SecurityWork_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
			//出勤按鈕設為不可用
			Security_Work_Button.interactable = false;
			//卸任按鈕設為可用
			Security_UnWork_Button.interactable = true;
		}
		//未出勤
		else {
			//隱藏出勤圖片
			SecurityWork_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			//出勤按鈕設為可用
			Security_Work_Button.interactable = true;
			//卸任按鈕設為不可用
			Security_UnWork_Button.interactable = false;
		}

	}

	//副程式:經理出勤按鈕
	public void Set_Manage_Work_Button(){
		//播放PayBack音效
		MainState.PayBack_Button_Sounds_Play();
		//播放經理出勤動畫
		Now_Manage_Security_Animation [0].Play ();

		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//原本區域經理設為未出勤
			for(int i=0; i<MainState.ManageNumber; i++){
				if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 0) {
					MainState.Manage [i].SetWork (false);
					break;
				}
			}

			//新區域經理設為出勤
			MainState.Manage [Now_Select_Manage_Number].SetWork (true);
			MainState.Manage [Now_Select_Manage_Number].SetWorkPlace (0);

			break;
			//音樂人
		case 1:
			//原本區域經理設為未出勤
			for(int i=0; i<MainState.ManageNumber; i++){
				if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 1) {
					MainState.Manage [i].SetWork (false);
					break;
				}
			}

			//新區域經理設為出勤
			MainState.Manage [Now_Select_Manage_Number].SetWork (true);
			MainState.Manage [Now_Select_Manage_Number].SetWorkPlace (1);
			break;
			//科技新貴
		case 2:
			//原本區域經理設為未出勤
			for(int i=0; i<MainState.ManageNumber; i++){
				if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 2) {
					MainState.Manage [i].SetWork (false);
					break;
				}
			}

			//新區域經理設為出勤
			MainState.Manage [Now_Select_Manage_Number].SetWork (true);
			MainState.Manage [Now_Select_Manage_Number].SetWorkPlace (2);
			break;
			//機工
		case 3:
			//原本區域經理設為未出勤
			for(int i=0; i<MainState.ManageNumber; i++){
				if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 3) {
					MainState.Manage [i].SetWork (false);
					break;
				}
			}

			//新區域經理設為出勤
			MainState.Manage [Now_Select_Manage_Number].SetWork (true);
			MainState.Manage [Now_Select_Manage_Number].SetWorkPlace (3);
			break;
			//銀行家
		case 4:
			//原本區域經理設為未出勤
			for(int i=0; i<MainState.ManageNumber; i++){
				if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 4) {
					MainState.Manage [i].SetWork (false);
					break;
				}
			}

			//新區域經理設為出勤
			MainState.Manage [Now_Select_Manage_Number].SetWork (true);
			MainState.Manage [Now_Select_Manage_Number].SetWorkPlace (4);
			break;

		}//switch

	} 

	//副程式:警衛出勤按鈕
	public void Set_Security_Work_Button(){
		//播放PayBack音效
		MainState.PayBack_Button_Sounds_Play();
		//播放警衛出勤動畫
		Now_Manage_Security_Animation [1].Play ();

		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//原本區域警衛設為未出勤
			for(int i=0; i<MainState.SecurityNumber; i++){
				if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace() == 0) {
					MainState.Security [i].SetWork (false);
					break;
				}
			}

			//新區域警衛設為出勤
			MainState.Security [Now_Select_Security_Number].SetWork (true);
			MainState.Security [Now_Select_Security_Number].SetWorkPlace (0);

			break;
			//音樂人
		case 1:
			//原本區域警衛設為未出勤
			for(int i=0; i<MainState.SecurityNumber; i++){
				if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace() == 1) {
					MainState.Security [i].SetWork (false);
					break;
				}
			}

			//新區域警衛設為出勤
			MainState.Security [Now_Select_Security_Number].SetWork (true);
			MainState.Security [Now_Select_Security_Number].SetWorkPlace (1);
			break;
			//科技新貴
		case 2:
			//原本區域警衛設為未出勤
			for(int i=0; i<MainState.SecurityNumber; i++){
				if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace() == 2) {
					MainState.Security [i].SetWork (false);
					break;
				}
			}

			//新區域警衛設為出勤
			MainState.Security [Now_Select_Security_Number].SetWork (true);
			MainState.Security [Now_Select_Security_Number].SetWorkPlace (2);
			break;
			//機工
		case 3:
			//原本區域警衛設為未出勤
			for(int i=0; i<MainState.SecurityNumber; i++){
				if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace() == 3) {
					MainState.Security [i].SetWork (false);
					break;
				}
			}

			//新區域警衛設為出勤
			MainState.Security [Now_Select_Security_Number].SetWork (true);
			MainState.Security [Now_Select_Security_Number].SetWorkPlace (3);
			break;
			//銀行家
		case 4:
			//原本區域警衛設為未出勤
			for(int i=0; i<MainState.SecurityNumber; i++){
				if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace() == 4) {
					MainState.Security [i].SetWork (false);
					break;
				}
			}

			//新區域警衛設為出勤
			MainState.Security [Now_Select_Security_Number].SetWork (true);
			MainState.Security [Now_Select_Security_Number].SetWorkPlace (4);
			break;

		}//switch

	} 

	//副程式:經理卸任按鈕
	public void Set_Manage_UnWork_Button(){
		//播放PayBack音效
		MainState.PayBack_Button_Sounds_Play();

		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//原本區域經理設為未出勤
			MainState.Manage [Now_Select_Manage_Number].SetWork (false);
			break;
			//音樂人
		case 1:
			//原本區域經理設為未出勤
			MainState.Manage [Now_Select_Manage_Number].SetWork (false);
			break;
			//科技新貴
		case 2:
			//原本區域經理設為未出勤
			MainState.Manage [Now_Select_Manage_Number].SetWork (false);
			break;
			//機工
		case 3:
			//原本區域經理設為未出勤
			MainState.Manage [Now_Select_Manage_Number].SetWork (false);
			break;
			//銀行家
		case 4:
			//原本區域經理設為未出勤
			MainState.Manage [Now_Select_Manage_Number].SetWork (false);
			break;

		}//switch

	} 

	//副程式:警衛卸任按鈕
	public void Set_Security_UnWork_Button(){
		//播放PayBack音效
		MainState.PayBack_Button_Sounds_Play();

		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//原本區域警衛設為未出勤
			MainState.Security [Now_Select_Security_Number].SetWork (false);
			break;
			//音樂人
		case 1:
			//原本區域警衛設為未出勤
			MainState.Security [Now_Select_Security_Number].SetWork (false);
			break;
			//科技新貴
		case 2:
			//原本區域警衛設為未出勤
			MainState.Security [Now_Select_Security_Number].SetWork (false);
			break;
			//機工
		case 3:
			//原本區域警衛設為未出勤
			MainState.Security [Now_Select_Security_Number].SetWork (false);
			break;
			//銀行家
		case 4:
			//原本區域警衛設為未出勤
			MainState.Security [Now_Select_Security_Number].SetWork (false);
			break;

		}//switch

	} 


	//副程式:設定景氣圖片
	void Set_NowEconomy_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//景氣 >= 70 
			if (MainState.Bread_NowEconomy >= 70)  NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("UP");
			//景氣40~69
			else if (MainState.Bread_NowEconomy < 70 && MainState.Bread_NowEconomy >= 40)  NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("Mid");
			//景氣<=39
			else NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("Down");
			break;
			//音樂人
		case 1:
			//景氣 >= 70 
			if (MainState.Music_NowEconomy >= 70)  NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("UP");
			//景氣40~69
			else if (MainState.Music_NowEconomy < 70 && MainState.Music_NowEconomy >= 40)  NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("Mid");
			//景氣<=39
			else NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("Down");
			break;
			//科技新貴
		case 2:
			//景氣 >= 70 
			if (MainState.Tehcnology_NowEconomy >= 70)  NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("UP");
			//景氣40~69
			else if (MainState.Tehcnology_NowEconomy < 70 && MainState.Tehcnology_NowEconomy >= 40)  NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("Mid");
			//景氣<=39
			else NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("Down");
			break;
			//機工
		case 3:
			//景氣 >= 70 
			if (MainState.Factory_NowEconomy >= 70)  NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("UP");
			//景氣40~69
			else if (MainState.Factory_NowEconomy < 70 && MainState.Factory_NowEconomy >= 40)  NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("Mid");
			//景氣<=39
			else NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("Down");
			break;
			//銀行家
		case 4:
			//景氣 >= 70 
			if (MainState.Economic_NowEconomy >= 70)  NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("UP");
			//景氣40~69
			else if (MainState.Economic_NowEconomy < 70 && MainState.Economic_NowEconomy >= 40)  NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("Mid");
			//景氣<=39
			else NowEconomy_Image.sprite = (Sprite)Resources.Load<Sprite>("Down");
			break;

		}//switch

	}

	//副程式:設定治安圖片
	void Set_NowSecurity_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//治安 >= 70 
			if (MainState.Bread_NowSecurity >= 70)  NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("UP");
			//治安40~69
			else if (MainState.Bread_NowSecurity < 70 && MainState.Bread_NowSecurity >= 40)  NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("Mid");
			//治安<=39
			else NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("Down");
			break;
			//音樂人
		case 1:
			//治安 >= 70 
			if (MainState.Music_NowSecurity >= 70)  NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("UP");
			//治安40~69
			else if (MainState.Music_NowSecurity < 70 && MainState.Music_NowSecurity >= 40)  NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("Mid");
			//治安<=39
			else NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("Down");
			break;
			//科技新貴
		case 2:
			//治安 >= 70 
			if (MainState.Tehcnology_NowSecurity >= 70)  NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("UP");
			//治安40~69
			else if (MainState.Tehcnology_NowSecurity < 70 && MainState.Tehcnology_NowSecurity >= 40)  NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("Mid");
			//治安<=39
			else NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("Down");
			break;
			//機工
		case 3:
			//治安 >= 70 
			if (MainState.Factory_NowSecurity >= 70)  NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("UP");
			//治安40~69
			else if (MainState.Factory_NowSecurity < 70 && MainState.Factory_NowSecurity >= 40)  NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("Mid");
			//治安<=39
			else NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("Down");
			break;
			//銀行家
		case 4:
			//治安 >= 70 
			if (MainState.Economic_NowSecurity >= 70)  NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("UP");
			//治安40~69
			else if (MainState.Economic_NowSecurity < 70 && MainState.Economic_NowSecurity >= 40)  NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("Mid");
			//治安<=39
			else NowSecurity_Image.sprite = (Sprite)Resources.Load<Sprite>("Down");
			break;

		}//switch

	}

	//副程式:Work頁面
	public void WorkPage(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//切回店鋪，這樣下次回來就會回到店鋪頁面
		Show_ManageStore();
		//顯示Work畫面
		WorkBackGround.SetActive(true);
		MainState.WorkBool = true;
		//播放WorkPage進入動畫
		AnimationIN.WorkPage_IN_Bool();
		//隱藏Manage畫面
		ManageBackGround.SetActive(false);
		MainState.ManageBool = false;
	}

	//副程式:店鋪經驗增加動畫
	void LevelEx_ADD(int Invest_Store_Number){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪經驗
			if (MainState.BreadStore [Invest_Store_Number].GetLevel() != 10) {
				MainState.BreadStore [Invest_Store_Number].SetLevelEx (MainState.BreadStore [Invest_Store_Number].GetLevelEx () + 1.0f);
				LevelEx_Temp = LevelEx_Temp - 1.0f;
			}

			//店鋪經驗足以升級==============
			if (MainState.BreadStore [Invest_Store_Number].GetLevelEx () >= 100.0f) {
				//播放等級提升音效
				MainState.LevelUP_Button_Sounds_Play ();
				//播放升級動畫
				Level_UP_Animation[Invest_Store_Number].Play();
				//播放店鋪預期利潤提升動畫
				Predict_UP_Animation[Invest_Store_Number].Play();
				//播放區域總預期利潤上升動畫
				Area_Predict_UP_Animation.Play();

				//店鋪等級 < 9
				if (MainState.BreadStore [Invest_Store_Number].GetLevel () < 9) {
					MainState.BreadStore [Invest_Store_Number].SetLevel (MainState.BreadStore [Invest_Store_Number].GetLevel () + 1);
					//計算多餘的店鋪經驗
					MainState.BreadStore [Invest_Store_Number].SetLevelEx (MainState.BreadStore [Invest_Store_Number].GetLevelEx () - 100.0f);
				}
				//店鋪等級 == 9
				else {
					MainState.BreadStore [Invest_Store_Number].SetLevel (10);
					//店鋪經驗設為0
					MainState.BreadStore [Invest_Store_Number].SetLevelEx (0.0f);
					//防止不能使用按鈕
					LevelEx_Temp = 0.0f;
				}

			}
			//設定店鋪已投資
			MainState.BreadStore [Invest_Store_Number].SetInvestBool (true);

			//隱藏選擇顧問畫面
			ManageStore.SetActive(false);
			//隱藏決定顧問畫面
			Decision.SetActive(false);

			break;
			//音樂家
		case 1:
			//店鋪經驗
			if (MainState.MusicStore [Invest_Store_Number].GetLevel () != 10) {
				MainState.MusicStore [Invest_Store_Number].SetLevelEx (MainState.MusicStore [Invest_Store_Number].GetLevelEx () + 1.0f);
				LevelEx_Temp = LevelEx_Temp - 1.0f;
			}
			//店鋪經驗足以升級==============
			if(MainState.MusicStore[Invest_Store_Number].GetLevelEx()>=100.0f){
				//播放等級提升音效
				MainState.LevelUP_Button_Sounds_Play();
				//播放升級動畫
				Level_UP_Animation[Invest_Store_Number].Play();
				//播放店鋪預期利潤提升動畫
				Predict_UP_Animation[Invest_Store_Number].Play();
				//播放區域總預期利潤上升動畫
				Area_Predict_UP_Animation.Play();

				//店鋪等級 < 9
				if (MainState.MusicStore [Invest_Store_Number].GetLevel () < 9) {
					MainState.MusicStore [Invest_Store_Number].SetLevel (MainState.MusicStore [Invest_Store_Number].GetLevel () + 1);
					//計算多餘的店鋪經驗
					MainState.MusicStore [Invest_Store_Number].SetLevelEx (MainState.MusicStore [Invest_Store_Number].GetLevelEx () - 100.0f);
				}
				//店鋪等級 == 9
				else {
					MainState.MusicStore [Invest_Store_Number].SetLevel (10);
					//店鋪經驗設為0
					MainState.MusicStore [Invest_Store_Number].SetLevelEx (0.0f);
					//防止不能使用按鈕
					LevelEx_Temp = 0.0f;
				}

			}
			//設定店鋪已投資
			MainState.MusicStore [Invest_Store_Number].SetInvestBool(true);

			//隱藏選擇顧問畫面
			ManageStore.SetActive(false);
			//隱藏決定顧問畫面
			Decision.SetActive(false);
			break;
			//科技新貴
		case 2:
			//店鋪經驗
			if (MainState.TehcnologyStore [Invest_Store_Number].GetLevel () != 10) {
				MainState.TehcnologyStore [Invest_Store_Number].SetLevelEx (MainState.TehcnologyStore [Invest_Store_Number].GetLevelEx () + 1.0f);
				LevelEx_Temp = LevelEx_Temp - 1.0f;
			}

			//店鋪經驗足以升級==============
			if(MainState.TehcnologyStore[Invest_Store_Number].GetLevelEx()>=100.0f){
				//播放等級提升音效
				MainState.LevelUP_Button_Sounds_Play();
				//播放升級動畫
				Level_UP_Animation[Invest_Store_Number].Play();
				//播放店鋪預期利潤提升動畫
				Predict_UP_Animation[Invest_Store_Number].Play();
				//播放區域總預期利潤上升動畫
				Area_Predict_UP_Animation.Play();

				//店鋪等級 < 9
				if (MainState.TehcnologyStore [Invest_Store_Number].GetLevel () < 9) {
					MainState.TehcnologyStore [Invest_Store_Number].SetLevel (MainState.TehcnologyStore [Invest_Store_Number].GetLevel () + 1);
					//計算多餘的店鋪經驗
					MainState.TehcnologyStore [Invest_Store_Number].SetLevelEx (MainState.TehcnologyStore [Invest_Store_Number].GetLevelEx () - 100.0f);
				}
				//店鋪等級 == 9
				else {
					MainState.TehcnologyStore [Invest_Store_Number].SetLevel (10);
					//店鋪經驗設為0
					MainState.TehcnologyStore [Invest_Store_Number].SetLevelEx (0.0f);
					//防止不能使用按鈕
					LevelEx_Temp = 0.0f;
				}

			}
			//設定店鋪已投資
			MainState.TehcnologyStore [Invest_Store_Number].SetInvestBool(true);
			//隱藏選擇顧問畫面
			ManageStore.SetActive(false);
			//隱藏決定顧問畫面
			Decision.SetActive(false);
			break;
			//機工
		case 3:
			//店鋪經驗
			if (MainState.FactoryStore [Invest_Store_Number].GetLevel () != 10) {
				MainState.FactoryStore [Invest_Store_Number].SetLevelEx (MainState.FactoryStore [Invest_Store_Number].GetLevelEx () + 1.0f);
				LevelEx_Temp = LevelEx_Temp - 1.0f;
			}
			//店鋪經驗足以升級==============
			if(MainState.FactoryStore[Invest_Store_Number].GetLevelEx()>=100.0f){
				//播放等級提升音效
				MainState.LevelUP_Button_Sounds_Play();
				//播放升級動畫
				Level_UP_Animation[Invest_Store_Number].Play();
				//播放店鋪預期利潤提升動畫
				Predict_UP_Animation[Invest_Store_Number].Play();
				//播放區域總預期利潤上升動畫
				Area_Predict_UP_Animation.Play();

				//店鋪等級 < 9
				if (MainState.FactoryStore [Invest_Store_Number].GetLevel () < 9) {
					MainState.FactoryStore [Invest_Store_Number].SetLevel (MainState.FactoryStore [Invest_Store_Number].GetLevel () + 1);
					//計算多餘的店鋪經驗
					MainState.FactoryStore [Invest_Store_Number].SetLevelEx (MainState.FactoryStore [Invest_Store_Number].GetLevelEx () - 100.0f);
				}
				//店鋪等級 == 9
				else {
					MainState.FactoryStore [Invest_Store_Number].SetLevel (10);
					//店鋪經驗設為0
					MainState.FactoryStore [Invest_Store_Number].SetLevelEx (0.0f);
					//防止不能使用按鈕
					LevelEx_Temp = 0.0f;
				}

			}
			//設定店鋪已投資
			MainState.FactoryStore [Invest_Store_Number].SetInvestBool(true);
			//隱藏選擇顧問畫面
			ManageStore.SetActive(false);
			//隱藏決定顧問畫面
			Decision.SetActive(false);
			break;
			//銀行家
		case 4:
			//店鋪經驗
			if (MainState.EconomicStore [Invest_Store_Number].GetLevel () != 10) {
				MainState.EconomicStore [Invest_Store_Number].SetLevelEx (MainState.EconomicStore [Invest_Store_Number].GetLevelEx () + 1.0f);
				LevelEx_Temp = LevelEx_Temp - 1.0f;
			}
			//店鋪經驗足以升級==============
			if(MainState.EconomicStore[Invest_Store_Number].GetLevelEx()>=100.0f){
				//播放等級提升音效
				MainState.LevelUP_Button_Sounds_Play();
				//播放升級動畫
				Level_UP_Animation[Invest_Store_Number].Play();
				//播放店鋪預期利潤提升動畫
				Predict_UP_Animation[Invest_Store_Number].Play();
				//播放區域總預期利潤上升動畫
				Area_Predict_UP_Animation.Play();

				//店鋪等級 < 9
				if (MainState.EconomicStore [Invest_Store_Number].GetLevel () < 9) {
					MainState.EconomicStore [Invest_Store_Number].SetLevel (MainState.EconomicStore [Invest_Store_Number].GetLevel () + 1);
					//計算多餘的店鋪經驗
					MainState.EconomicStore [Invest_Store_Number].SetLevelEx (MainState.EconomicStore [Invest_Store_Number].GetLevelEx () - 100.0f);
				}
				//店鋪等級 == 9
				else {
					MainState.EconomicStore [Invest_Store_Number].SetLevel (10);
					//店鋪經驗設為0
					MainState.EconomicStore [Invest_Store_Number].SetLevelEx (0.0f);
					//防止不能使用按鈕
					LevelEx_Temp = 0.0f;
				}

			}
			//設定店鋪已投資
			MainState.EconomicStore [Invest_Store_Number].SetInvestBool(true);
			//隱藏選擇顧問畫面
			ManageStore.SetActive(false);
			//隱藏決定顧問畫面
			Decision.SetActive(false);
			break;

		}//switch

		//動畫結束=============================================================================
		if (LevelEx_Temp <= 0.0f) {
			LevelEx_Bool = false;
			//不是決定畫面
			DecisionBool = false;
			//離開按鈕設為可用
			LeftButton.interactable = true;
			//店鋪按鈕設為不可用
			StoreButton.interactable = false;
			//人員按鈕設為可用
			PeopleButton.interactable = true;
			//上一位按鈕設為可用
			PreviousButton.interactable = true;
			//下一位按鈕設為可用
			NextButton.interactable = true;
			//確定投資按鈕為可用
			ManageInvestionButton.interactable = true;
			//取消投資按鈕為可用
			ManageCancelButton.interactable = true;
			//scrollBar設為可用
			scrollbar.interactable = true;
		}


	}

	//副程式:設定支援能力顏色(1:烹飪 2:音樂 3:科技 4:機工 5:金融)
	void  AdvantageNumber_Color(){
		switch(Manage_Area_Number){
		case 0:
			//1:烹飪
			if (MainState.BreadStore [Invest_Store_Number].GetClassification () == 1) {
				AdvantageNumber1_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//2:音樂
			else if (MainState.BreadStore [Invest_Store_Number].GetClassification () == 2) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//3:科技
			else if (MainState.BreadStore [Invest_Store_Number].GetClassification () == 3) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//4:機工
			else if (MainState.BreadStore [Invest_Store_Number].GetClassification () == 4) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//5:金融
			else if (MainState.BreadStore [Invest_Store_Number].GetClassification () == 5) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			}
			break;

		case 1:
			//1:烹飪
			if (MainState.MusicStore [Invest_Store_Number].GetClassification () == 1) {
				AdvantageNumber1_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//2:音樂
			else if (MainState.MusicStore [Invest_Store_Number].GetClassification () == 2) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//3:科技
			else if (MainState.MusicStore [Invest_Store_Number].GetClassification () == 3) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//4:機工
			else if (MainState.MusicStore [Invest_Store_Number].GetClassification () == 4) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//5:金融
			else if (MainState.MusicStore [Invest_Store_Number].GetClassification () == 5) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			}
			break;

		case 2:
			//1:烹飪
			if (MainState.TehcnologyStore [Invest_Store_Number].GetClassification () == 1) {
				AdvantageNumber1_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//2:音樂
			else if (MainState.TehcnologyStore [Invest_Store_Number].GetClassification () == 2) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//3:科技
			else if (MainState.TehcnologyStore [Invest_Store_Number].GetClassification () == 3) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//4:機工
			else if (MainState.TehcnologyStore [Invest_Store_Number].GetClassification () == 4) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//5:金融
			else if (MainState.TehcnologyStore [Invest_Store_Number].GetClassification () == 5) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			}
			break;

		case 3:
			//1:烹飪
			if (MainState.FactoryStore [Invest_Store_Number].GetClassification () == 1) {
				AdvantageNumber1_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//2:音樂
			else if (MainState.FactoryStore [Invest_Store_Number].GetClassification () == 2) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//3:科技
			else if (MainState.FactoryStore [Invest_Store_Number].GetClassification () == 3) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//4:機工
			else if (MainState.FactoryStore [Invest_Store_Number].GetClassification () == 4) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//5:金融
			else if (MainState.FactoryStore [Invest_Store_Number].GetClassification () == 5) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			}
			break;

		case 4:
			//1:烹飪
			if (MainState.EconomicStore [Invest_Store_Number].GetClassification () == 1) {
				AdvantageNumber1_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//2:音樂
			else if (MainState.EconomicStore [Invest_Store_Number].GetClassification () == 2) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//3:科技
			else if (MainState.EconomicStore [Invest_Store_Number].GetClassification () == 3) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//4:機工
			else if (MainState.EconomicStore [Invest_Store_Number].GetClassification () == 4) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			} 
			//5:金融
			else if (MainState.EconomicStore [Invest_Store_Number].GetClassification () == 5) {
				AdvantageNumber1_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber2_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber3_Text.color = new Color (0.0f, 0.0f, 0.0f);
				AdvantageNumber4_Text.color = new Color (255.0f, 0.0f, 0.0f);
				AdvantageNumber5_Text.color = new Color (0.0f, 0.0f, 0.0f);
			}
			break;

		}//switch
	}



	/*//副程式:滑動ScrollBar
	void Android_ScrollBar(){
		//手指向上滑動 
		if (Input.GetAxis ("Mouse Y") > 0.0f) {
			S.value = S.value + 0.05f;
			print ("a");
		}
		//手指向下滑動 
		else if (Input.GetAxis ("Mouse Y") < 0.0f) { -610.5 1121 -50 -1171
			S.value = S.value - 0.05f;
			print ("b");
		}
		//print (Input.GetAxis("Mouse Y"));
		//S.value = S.value - Input.GetAxis ("Mouse Y");
		//紀錄手指觸碰位置
		//Vector2 m_screenPos = new Vector2 ();
		//紀錄觸碰位置
		//m_screenPos = Input.touches[0].position;
		if(Input.touchCount==1 )
		{  
			if(Input.touches[0].phase==TouchPhase.Moved){
				//手指向上滑動 
				if (Input.GetAxis ("Mouse Y") > 0.0f) {
					S.value = S.value + 0.05f;
					//print ("a");
				}
				//手指向下滑動 
				else if (Input.GetAxis ("Mouse Y") < 0.0f) {
					S.value = S.value - 0.05f;
					//print ("b");
				}
			}
		}
	}*/

}
