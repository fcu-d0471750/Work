//置產頁面 UI控制 邏輯運算 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyStore : MonoBehaviour {

  //宣告變數=====================================================================
	//現在選擇區域
	int Manage_Area_Number = 0;
	//現在選擇店鋪編號
	int Now_Select_Number = 0;
	//是否為決定畫面 true:是 fasle:不是
	bool DecisionBool = false;
  //宣告UI=====================================================================
	//GameObject************************************
	//Work畫面
	public GameObject WorkBackGround;
	//BuyStore畫面
	public GameObject BuyStoreBackGround;
	//決定畫面
	public GameObject Decision;

	//按鈕*******************************
	//麵包師傅按鈕
	public Button Bread_Button;
	//音樂人按鈕
	public Button Music_Button;
	//科技新貴按鈕
	public Button Technology_Button;
	//機工按鈕
	public Button Factory_Button;
	//銀行家按鈕
	public Button Bank_Button;

	//離開按鈕
	public Button ExitButton;
	//置產按鈕
	public Button ManageButton;

	//上一位按鈕
	public Button PreviousButton;
	//下一位按鈕
	public Button NextButton;


	//Text********************************
	//持有金錢
	public Text OwnMoney_Text;

	//區域佔有率(麵包師傅)
	public Text Bread_Present_Text;
	//區域佔有率(音樂人)
	public Text Music_Present_Text;
	//區域佔有率(科技新貴)
	public Text Tehcnology_Present_Text;
	//區域佔有率(機工)
	public Text Factory_Present_Text;
	//區域佔有率(銀行家)
	public Text Economic_Present_Text;

	//預期利潤(麵包師傅)
	public Text Bread_Predict_Text;
	//預期利潤(音樂人)
	public Text Music_Predict_Text;
	//預期利潤(科技新貴)
	public Text Tehcnology_Predict_Text;
	//預期利潤(機工)
	public Text Factory_Predict_Text;
	//預期利潤(銀行家)
	public Text Economic_Predict_Text;

	//全部店鋪占有數(麵包師傅)
	public Text Bread_StoreNumber_Text;
	//全部店鋪占有數(音樂人)
	public Text Music_StoreNumber_Text;
	//全部店鋪占有數(科技新貴)
	public Text Tehcnology_StoreNumber_Text;
	//全部店鋪占有數(機工)
	public Text Factory_StoreNumber_Text;
	//全部店鋪占有數(銀行家)
	public Text Economic_StoreNumber_Text;

	//店鋪名稱
	public Text[] StoreName_Text = new Text[10];
	//置產店鋪名稱
	public Text BuyStoreName_Text;
	//置產店鋪利潤
	public Text Store_Predict_Text;
	//店鋪置產價格
	public Text Store_Price_Text;

	//Image*******************************
	//區域佔有率圖片(麵包師傅)
	public Image Bread_Present_Image;
	//區域佔有率圖片(音樂人)
	public Image Music_Present_Image;
	//區域佔有率圖片(科技新貴)
	public Image Tehcnology_Present_Image;
	//區域佔有率圖片(機工)
	public Image Factory_Present_Image;
	//區域佔有率圖片(銀行家)
	public Image Economic_Present_Image;
	 
	//店鋪圖片
	public Image Store_Image;
	//店鋪分類圖片
	public Image ClassImage;
	//擁有店鋪圖片
	public Image OwnImage;
	//未擁有店鋪圖片
	public Image UnOwnImage;

	//區域圖片
	public Image Area_Image;

	//現在選擇圖片
	public Image[] SelectStore_Image = new Image[10];

	//宣告動畫============================================================
	//持有金錢變化動畫
	public Animation Own_Money_Change_Animation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//副程式:設定置產按鈕是否可用
		if(!DecisionBool)Set_ManageButton_Button();
		//設定Text*****************************************************
		//持有金錢
		MainState.SetText_OwnMoney(OwnMoney_Text);
		//佔有率
		Set_Present_Text ();
		//預期利潤
		Set_Price_Text ();
		//副程式:設定店鋪數Text
		Set_StoreNumber_Text();
		//副程式:設定店鋪名稱Text
		Set_StoreName_Text();
		//副程式:設定置產店鋪名稱Text
		Set_BuyStoreName_Text();

		//設定圖片********************************************************
		//副程式:設定佔有率圖片
		Set_Present_Image();
		//副程式:設定區域圖片
		Set_Area_Image();
		//副程式:設定店鋪分類圖片
		Set_Store_Class_Image();
		//副程式:設定店鋪圖片
		Set_Store_Image();
		//副程式:設定店鋪是否擁有圖片
		Set_Store_Own_Image();
		//副程式:設定現在選擇店鋪圖片
		Set_SelectStore_Image();
	}


	//副程式(按鈕):決定畫面僱用
	public void Set_Decision_Accept(){
		//播放Buy音效
		MainState.Buy_Button_Sounds_Play();

		//播放持有金錢變更動畫
		Own_Money_Change_Animation.Play();

		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//如果本來沒有任何一間店
			if(MainState.BreadArea.GetStoreNumber()==0) MainState.BreadArea.SetManage(true);
			//扣除持有金錢
			MainState.SUB_OwnMoney(MainState.BreadStore[Now_Select_Number].GetBuyPrice() , OwnMoney_Text);
			//設為已購買
			MainState.BreadStore[Now_Select_Number].SetOwnBool(true);
			//增加店鋪數
			MainState.BreadArea.SetStoreNumber(MainState.BreadArea.GetStoreNumber() + 1);
			//設麵包師傅按鈕為不可用
			Bread_Button.interactable = false;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//音樂人
		case 1:
			//如果本來沒有任何一間店
			if(MainState.MusicArea.GetStoreNumber()==0) MainState.MusicArea.SetManage(true);
			//扣除持有金錢
			MainState.SUB_OwnMoney(MainState.MusicStore[Now_Select_Number].GetBuyPrice() , OwnMoney_Text);
			//設為已購買
			MainState.MusicStore[Now_Select_Number].SetOwnBool(true);
			//增加店鋪數
			MainState.MusicArea.SetStoreNumber(MainState.MusicArea.GetStoreNumber() + 1);
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為不可用
			Music_Button.interactable = false;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//科技新貴
		case 2:
			//如果本來沒有任何一間店
			if(MainState.TehcnologyArea.GetStoreNumber()==0) MainState.TehcnologyArea.SetManage(true);
			//扣除持有金錢
			MainState.SUB_OwnMoney(MainState.TehcnologyStore[Now_Select_Number].GetBuyPrice() , OwnMoney_Text);
			//設為已購買
			MainState.TehcnologyStore[Now_Select_Number].SetOwnBool(true);
			//增加店鋪數
			MainState.TehcnologyArea.SetStoreNumber(MainState.TehcnologyArea.GetStoreNumber() + 1);
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為不可用
			Technology_Button.interactable = false;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//機工
		case 3:
			//如果本來沒有任何一間店
			if(MainState.FactoryArea.GetStoreNumber()==0) MainState.FactoryArea.SetManage(true);
			//扣除持有金錢
			MainState.SUB_OwnMoney(MainState.FactoryStore[Now_Select_Number].GetBuyPrice() , OwnMoney_Text);
			//設為已購買
			MainState.FactoryStore[Now_Select_Number].SetOwnBool(true);
			//增加店鋪數
			MainState.FactoryArea.SetStoreNumber(MainState.FactoryArea.GetStoreNumber() + 1);
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為不可用
			Factory_Button.interactable = false;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//銀行家
		case 4:
			//如果本來沒有任何一間店
			if(MainState.EconomicArea.GetStoreNumber()==0) MainState.EconomicArea.SetManage(true);
			//扣除持有金錢
			MainState.SUB_OwnMoney(MainState.EconomicStore[Now_Select_Number].GetBuyPrice() , OwnMoney_Text);
			//設為已購買
			MainState.EconomicStore[Now_Select_Number].SetOwnBool(true);
			//增加店鋪數
			MainState.EconomicArea.SetStoreNumber(MainState.EconomicArea.GetStoreNumber() + 1);
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為不可用
			Bank_Button.interactable = false;
			break;

		}//switch

		//隱藏決定畫面
		Decision.SetActive(false);
		//離開按鈕設為能用
		ExitButton.interactable = true;
		//置產按鈕設為能用
		ManageButton.interactable = true;
		//變更狀態為不是決定畫面
		DecisionBool = false;
		//向上按鈕設為能用
		PreviousButton.interactable = true;
		//向下按鈕設為能用
		NextButton.interactable = true;
	}

	//副程式(按鈕):Work頁面
	public void WorkPage(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//切回麵包師傅區域，這樣下次回來就會回到麵包師傅區域頁面
		Manage_Area_Number = 0;
		Set_Manage_Area_Number (0);

		//顯示Work畫面
		WorkBackGround.SetActive(true);
		MainState.WorkBool = true;
		//播放WorkPage進入動畫
		AnimationIN.WorkPage_IN_Bool();
		//隱藏HireBackGround畫面
		BuyStoreBackGround.SetActive(false);
		MainState.BuyStoreBool = false;
	}

	//副程式(按鈕):開啟決定畫面
	public void Set_Decision(){
		//播放PayBack音效
		MainState.PayBack_Button_Sounds_Play();

		//顯示決定畫面
		Decision.SetActive(true);
		//麵包師傅按鈕設為不能用
		Bread_Button.interactable = false;
		//音樂人按鈕設為不能用
		Music_Button.interactable = false;
		//科技新貴按鈕設為不能用
		Technology_Button.interactable = false;
		//機工按鈕設為不能用
		Factory_Button.interactable = false;
		//銀行家按鈕設為不能用
		Bank_Button.interactable = false;
		//離開按鈕設為不能用
		ExitButton.interactable = false;
		//置產按鈕設為不能用
		ManageButton.interactable = false;
		//變更狀態為決定畫面
		DecisionBool = true;
		//向上按鈕設為不能用
		PreviousButton.interactable = false;
		//向下按鈕設為不能用
		NextButton.interactable = false;
	}

	//副程式(按鈕):決定畫面取消
	public void Set_Decision_Cancel(){
		//播放取消按鈕音效
		MainState.Cancel_Button_Sounds_Play();

		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//設麵包師傅按鈕為不可用
			Bread_Button.interactable = false;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//音樂人
		case 1:
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為不可用
			Music_Button.interactable = false;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//科技新貴
		case 2:
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為不可用
			Technology_Button.interactable = false;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//機工
		case 3:
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為不可用
			Factory_Button.interactable = false;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//銀行家
		case 4:
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為不可用
			Bank_Button.interactable = false;
			break;

		}//switch

		//隱藏決定畫面
		Decision.SetActive(false);
		//離開按鈕設為能用
		ExitButton.interactable = true;
		//置產按鈕設為能用
		ManageButton.interactable = true;
		//變更狀態為不是決定畫面
		DecisionBool = false;
		//向上按鈕設為能用
		PreviousButton.interactable = true;
		//向下按鈕設為能用
		NextButton.interactable = true;
	}


	//副程式(按鈕):上一間 或是 下一間
	public void Set_SelectStore_Number(int UP_Down){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		switch(UP_Down){
		//上一位
		case 0:
			//現在是第一間 則 回到最後一間
			if (Now_Select_Number == 0)
				Now_Select_Number = 9;
			//其它 則 現在選擇編號-1
			else {
				Now_Select_Number = Now_Select_Number - 1;
			}
			break;
			//下一位
		case 1:
			//現在是最後一間 則 回到第一間
			if (Now_Select_Number == 9)
				Now_Select_Number = 0;
			//其它 則 現在選擇編號+1
			else {
				Now_Select_Number = Now_Select_Number + 1;
			}
			break;
		}//switch
	}

	//副程式(按鈕):設定現在選擇區域
	public void Set_Manage_Area_Number(int Area){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		switch (Area) {
		//麵包師傅
		case 0:
			Manage_Area_Number = 0;
			//現在選擇店鋪編號
			Now_Select_Number = 0;
			//設麵包師傅按鈕為不可用
			Bread_Button.interactable = false;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//音樂人
		case 1:
			Manage_Area_Number = 1;
			//現在選擇店鋪編號
			Now_Select_Number = 0;
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為不可用
			Music_Button.interactable = false;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//科技新貴
		case 2:
			Manage_Area_Number = 2;
			//現在選擇店鋪編號
			Now_Select_Number = 0;
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為不可用
			Technology_Button.interactable = false;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//機工
		case 3:
			Manage_Area_Number = 3;
			//現在選擇店鋪編號
			Now_Select_Number = 0;
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為不可用
			Factory_Button.interactable = false;
			//銀行家按鈕為可用
			Bank_Button.interactable = true;
			break;
			//銀行家
		case 4:
			Manage_Area_Number = 4;
			//現在選擇店鋪編號
			Now_Select_Number = 0;
			//設麵包師傅按鈕為可用
			Bread_Button.interactable = true;
			//音樂人按鈕為可用
			Music_Button.interactable = true;
			//科技新貴按鈕為可用
			Technology_Button.interactable = true;
			//機工按鈕為可用
			Factory_Button.interactable = true;
			//銀行家按鈕為不可用
			Bank_Button.interactable = false;
			break;
		}//switch
	}

	//副程式:設定置產按鈕是否可用
	void Set_ManageButton_Button(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//如果已置產 或是 持有金錢 < 置產價格 則置產按鈕設為不可用
			if (MainState.BreadStore [Now_Select_Number].GetOwnBool() == true || MainState.OwnMoney < MainState.BreadStore [Now_Select_Number].GetBuyPrice ())
				ManageButton.interactable = false;
			else
				ManageButton.interactable = true;
			break;
			//音樂人
		case 1:
			//如果已置產 或是 持有金錢 < 置產價格 則置產按鈕設為不可用
			if (MainState.MusicStore [Now_Select_Number].GetOwnBool() == true || MainState.OwnMoney < MainState.MusicStore [Now_Select_Number].GetBuyPrice ())
				ManageButton.interactable = false;
			else
				ManageButton.interactable = true;
			break;
			//科技新貴
		case 2:
			//如果已置產 或是 持有金錢 < 置產價格 則置產按鈕設為不可用
			if (MainState.TehcnologyStore [Now_Select_Number].GetOwnBool() == true || MainState.OwnMoney < MainState.TehcnologyStore [Now_Select_Number].GetBuyPrice ())
				ManageButton.interactable = false;
			else
				ManageButton.interactable = true;
			break;
			//機工
		case 3:
			//如果已置產 或是 持有金錢 < 置產價格 則置產按鈕設為不可用
			if (MainState.FactoryStore [Now_Select_Number].GetOwnBool() == true || MainState.OwnMoney < MainState.FactoryStore [Now_Select_Number].GetBuyPrice ())
				ManageButton.interactable = false;
			else
				ManageButton.interactable = true;
			break;
			//銀行家
		case 4:
			//如果已置產 或是 持有金錢 < 置產價格 則置產按鈕設為不可用
			if (MainState.EconomicStore [Now_Select_Number].GetOwnBool() == true || MainState.OwnMoney < MainState.EconomicStore [Now_Select_Number].GetBuyPrice ())
				ManageButton.interactable = false;
			else
				ManageButton.interactable = true;
			break;

		}//switch
			
	}


	//副程式:設定預期利潤Text
	void Set_Price_Text(){
		uint PriceTemp = 0;

		//預期利潤(麵包師傅)
		for (int i = 0; i < MainState.BreadStoreNumber; i++) {
			if (MainState.BreadStore [i].GetOwnBool())
				PriceTemp = PriceTemp + (MainState.BreadStore[i].GetPrice()*(uint)MainState.BreadStore[i].GetLevel());
		}
		MainState.SetText_Pricey (PriceTemp,Bread_Predict_Text);
		PriceTemp = 0;
		//預期利潤(音樂人)
		for (int i = 0; i < MainState.MusicStoreNumber; i++) {
			if (MainState.MusicStore [i].GetOwnBool())
				PriceTemp = PriceTemp + (MainState.MusicStore[i].GetPrice()*(uint)MainState.MusicStore[i].GetLevel());
		}
		MainState.SetText_Pricey (PriceTemp,Music_Predict_Text);
		PriceTemp = 0;
		//預期利潤(科技新貴)
		for (int i = 0; i < MainState.TehcnologyStoreNumber; i++) {
			if (MainState.TehcnologyStore [i].GetOwnBool())
				PriceTemp = PriceTemp + (MainState.TehcnologyStore[i].GetPrice()*(uint)MainState.TehcnologyStore[i].GetLevel());
		}
		MainState.SetText_Pricey (PriceTemp,Tehcnology_Predict_Text);
		PriceTemp = 0;
		//預期利潤(機工)
		for (int i = 0; i < MainState.FactoryStoreNumber; i++) {
			if (MainState.FactoryStore [i].GetOwnBool())
				PriceTemp = PriceTemp + (MainState.FactoryStore[i].GetPrice()*(uint)MainState.FactoryStore[i].GetLevel());
		}
		MainState.SetText_Pricey (PriceTemp,Factory_Predict_Text);
		PriceTemp = 0;
		//預期利潤(銀行家)
		for (int i = 0; i < MainState.EconomicStoreNumber; i++) {
			if (MainState.EconomicStore [i].GetOwnBool())
				PriceTemp = PriceTemp + (MainState.EconomicStore[i].GetPrice()*(uint)MainState.EconomicStore[i].GetLevel());
		}
		MainState.SetText_Pricey (PriceTemp,Economic_Predict_Text);
		PriceTemp = 0;

	}

	//副程式:設定佔有率Text
	void Set_Present_Text(){
		float PresentTemp = 0.0f;

		//區域佔有率(麵包師傅)
		for (int i = 0; i < MainState.BreadStoreNumber; i++) {
			if (MainState.BreadStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Bread_Present_Text.text = (PresentTemp/MainState.BreadStoreNumber)*100.0f + "%";
		PresentTemp = 0.0f;
		//區域佔有率(音樂人)
		for (int i = 0; i < MainState.MusicStoreNumber; i++) {
			if (MainState.MusicStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Music_Present_Text.text = (PresentTemp/MainState.MusicStoreNumber)*100.0f + "%";
		PresentTemp = 0.0f;
		//區域佔有率(科技新貴)
		for (int i = 0; i < MainState.TehcnologyStoreNumber; i++) {
			if (MainState.TehcnologyStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Tehcnology_Present_Text.text = (PresentTemp/MainState.TehcnologyStoreNumber)*100.0f + "%";
		PresentTemp = 0.0f;
		//區域佔有率(機工)
		for (int i = 0; i < MainState.FactoryStoreNumber; i++) {
			if (MainState.FactoryStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Factory_Present_Text.text = (PresentTemp/MainState.FactoryStoreNumber)*100.0f + "%";
		PresentTemp = 0.0f;
		//區域佔有率(銀行家)
		for (int i = 0; i < MainState.EconomicStoreNumber; i++) {
			if (MainState.EconomicStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Economic_Present_Text.text = (PresentTemp/MainState.EconomicStoreNumber)*100.0f + "%";
		PresentTemp = 0.0f;
	}

	//副程式:設定店鋪數Text
	void Set_StoreNumber_Text(){
		//店鋪數
		int StoreTemp = 0;

		//麵包師傅
			for (int i = 0; i < MainState.BreadStoreNumber; i++) {
				if (MainState.BreadStore [i].GetOwnBool()) {
					StoreTemp = StoreTemp + 1;
				}
			}
			Bread_StoreNumber_Text.text = StoreTemp + " / " + MainState.BreadStoreNumber + "";
			StoreTemp = 0;
			//音樂人
			for (int i = 0; i < MainState.MusicStoreNumber; i++) {
				if (MainState.MusicStore [i].GetOwnBool()) {
					StoreTemp = StoreTemp + 1;
				}
			}
			Music_StoreNumber_Text.text = StoreTemp + " / " + MainState.MusicStoreNumber + "";
			StoreTemp = 0;
			//科技新貴
			for (int i = 0; i < MainState.TehcnologyStoreNumber; i++) {
				if (MainState.TehcnologyStore [i].GetOwnBool()) {
					StoreTemp = StoreTemp + 1;
				}
			}
			Tehcnology_StoreNumber_Text.text = StoreTemp + " / " + MainState.TehcnologyStoreNumber + "";
			StoreTemp = 0;
			//機工
			for (int i = 0; i < MainState.FactoryStoreNumber; i++) {
				if (MainState.FactoryStore [i].GetOwnBool()) {
					StoreTemp = StoreTemp + 1;
				}
			}
			Factory_StoreNumber_Text.text = StoreTemp + " / " + MainState.FactoryStoreNumber + "";
			StoreTemp = 0;
			//銀行家
			for (int i = 0; i < MainState.EconomicStoreNumber; i++) {
				if (MainState.EconomicStore [i].GetOwnBool()) {
					StoreTemp = StoreTemp + 1;
				}
			}
			Economic_StoreNumber_Text.text = StoreTemp + " / " + MainState.EconomicStoreNumber + "";
			StoreTemp = 0;
	}

	//副程式:設定店鋪名稱Text
	void Set_StoreName_Text(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪名稱
			for(int i=0; i<MainState.BreadStoreNumber; i++){
				StoreName_Text [i].text =  MainState.BreadStore[i].GetName() + "";
			}
			break;
			//音樂人
		case 1:
			//店鋪名稱
			for(int i=0; i<MainState.MusicStoreNumber; i++){
				StoreName_Text [i].text =  MainState.MusicStore[i].GetName() + "";
			}
			break;
			//科技新貴
		case 2:
			//店鋪名稱
			for(int i=0; i<MainState.TehcnologyStoreNumber; i++){
				StoreName_Text [i].text =  MainState.TehcnologyStore[i].GetName() + "";
			}
			break;
			//機工
		case 3:
			//店鋪名稱
			for(int i=0; i<MainState.FactoryStoreNumber; i++){
				StoreName_Text [i].text =  MainState.FactoryStore[i].GetName() + "";
			}
			break;
			//銀行家
		case 4:
			//店鋪名稱
			for(int i=0; i<MainState.EconomicStoreNumber; i++){
				StoreName_Text [i].text =  MainState.EconomicStore[i].GetName() + "";
			}
			break;

		}//switch

	}

	//副程式:設定置產店鋪名稱 預期利潤 置產價格Text
	void Set_BuyStoreName_Text(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//置產店鋪名稱
			BuyStoreName_Text.text =  MainState.BreadStore[Now_Select_Number].GetName() + "";
			//預期利潤 
			MainState.SetText_Pricey(MainState.BreadStore[Now_Select_Number].GetPrice() , Store_Predict_Text);
			//置產價格
			MainState.SetText_Pricey(MainState.BreadStore[Now_Select_Number].GetBuyPrice() , Store_Price_Text);
			break;
			//音樂人
		case 1:
			//置產店鋪名稱
			BuyStoreName_Text.text =  MainState.MusicStore[Now_Select_Number].GetName() + "";
			//預期利潤 
			MainState.SetText_Pricey(MainState.MusicStore[Now_Select_Number].GetPrice() , Store_Predict_Text);
			//置產價格
			MainState.SetText_Pricey(MainState.MusicStore[Now_Select_Number].GetBuyPrice() , Store_Price_Text);
			break;
			//科技新貴
		case 2:
			//置產店鋪名稱
			BuyStoreName_Text.text =  MainState.TehcnologyStore[Now_Select_Number].GetName() + "";
			//預期利潤 
			MainState.SetText_Pricey(MainState.TehcnologyStore[Now_Select_Number].GetPrice() , Store_Predict_Text);
			//置產價格
			MainState.SetText_Pricey(MainState.TehcnologyStore[Now_Select_Number].GetBuyPrice() , Store_Price_Text);
			break;
			//機工
		case 3:
			//置產店鋪名稱
			BuyStoreName_Text.text =  MainState.FactoryStore[Now_Select_Number].GetName() + "";
			//預期利潤 
			MainState.SetText_Pricey(MainState.FactoryStore[Now_Select_Number].GetPrice() , Store_Predict_Text);
			//置產價格
			MainState.SetText_Pricey(MainState.FactoryStore[Now_Select_Number].GetBuyPrice() , Store_Price_Text);
			break;
			//銀行家
		case 4:
			//置產店鋪名稱
			BuyStoreName_Text.text =  MainState.EconomicStore[Now_Select_Number].GetName() + "";
			//預期利潤 
			MainState.SetText_Pricey(MainState.EconomicStore[Now_Select_Number].GetPrice() , Store_Predict_Text);
			//置產價格
			MainState.SetText_Pricey(MainState.EconomicStore[Now_Select_Number].GetBuyPrice() , Store_Price_Text);
			break;

		}//switch

	}

	//副程式:設定佔有率圖片
	void Set_Present_Image(){
		float PresentTemp = 0.0f;

		//區域佔有率(麵包師傅)
		for (int i = 0; i < MainState.BreadStoreNumber; i++) {
			if (MainState.BreadStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Bread_Present_Image.fillAmount = (PresentTemp / MainState.BreadStoreNumber);
		PresentTemp = 0.0f;
		//區域佔有率(音樂人)
		for (int i = 0; i < MainState.MusicStoreNumber; i++) {
			if (MainState.MusicStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Music_Present_Image.fillAmount = (PresentTemp / MainState.MusicStoreNumber);
		PresentTemp = 0.0f;
		//區域佔有率(科技新貴)
		for (int i = 0; i < MainState.TehcnologyStoreNumber; i++) {
			if (MainState.TehcnologyStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Tehcnology_Present_Image.fillAmount = (PresentTemp / MainState.TehcnologyStoreNumber);
		PresentTemp = 0.0f;
		//區域佔有率(機工)
		for (int i = 0; i < MainState.FactoryStoreNumber; i++) {
			if (MainState.FactoryStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Factory_Present_Image.fillAmount = (PresentTemp / MainState.FactoryStoreNumber);
		PresentTemp = 0.0f;
		//區域佔有率(銀行家)
		for (int i = 0; i < MainState.EconomicStoreNumber; i++) {
			if (MainState.EconomicStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Economic_Present_Image.fillAmount = (PresentTemp / MainState.EconomicStoreNumber);
		PresentTemp = 0.0f;
	}

	//副程式:設定區域圖片
	void Set_Area_Image(){
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

	//副程式:設定店鋪分類圖片
	void Set_Store_Class_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪分類圖片(讀取在Resources資料夾的圖片)
				//1:烹飪  
			if(MainState.BreadStore[Now_Select_Number].GetClassification()==1)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("food");
				//2:音樂
			else if(MainState.BreadStore[Now_Select_Number].GetClassification()==2)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("music-player");
				//3:科技 
			else if(MainState.BreadStore[Now_Select_Number].GetClassification()==3)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("smartphone-call");
				//4:機工 
			else if(MainState.BreadStore[Now_Select_Number].GetClassification()==4)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("screwdriver-and-wrench-crossed");
				//5:金融
			else if(MainState.BreadStore[Now_Select_Number].GetClassification()==5)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("bank-building");

			break;
			//音樂人
		case 1:
			//店鋪分類圖片(讀取在Resources資料夾的圖片)
				//1:烹飪  
			if(MainState.MusicStore[Now_Select_Number].GetClassification()==1)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("food");
				//2:音樂
			else if(MainState.MusicStore[Now_Select_Number].GetClassification()==2)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("music-player");
				//3:科技 
			else if(MainState.MusicStore[Now_Select_Number].GetClassification()==3)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("smartphone-call");
				//4:機工 
			else if(MainState.MusicStore[Now_Select_Number].GetClassification()==4)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("screwdriver-and-wrench-crossed");
				//5:金融
			else if(MainState.MusicStore[Now_Select_Number].GetClassification()==5)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("bank-building");
			break;
			//科技新貴
		case 2:
			//店鋪分類圖片(讀取在Resources資料夾的圖片)
				//1:烹飪  
			if(MainState.TehcnologyStore[Now_Select_Number].GetClassification()==1)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("food");
				//2:音樂
			else if(MainState.TehcnologyStore[Now_Select_Number].GetClassification()==2)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("music-player");
				//3:科技 
			else if(MainState.TehcnologyStore[Now_Select_Number].GetClassification()==3)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("smartphone-call");
				//4:機工 
			else if(MainState.TehcnologyStore[Now_Select_Number].GetClassification()==4)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("screwdriver-and-wrench-crossed");
				//5:金融
			else if(MainState.TehcnologyStore[Now_Select_Number].GetClassification()==5)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("bank-building");
			break;
			//機工
		case 3:
			//店鋪分類圖片(讀取在Resources資料夾的圖片)
				//1:烹飪  
			if(MainState.FactoryStore[Now_Select_Number].GetClassification()==1)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("food");
				//2:音樂
			else if(MainState.FactoryStore[Now_Select_Number].GetClassification()==2)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("music-player");
				//3:科技 
			else if(MainState.FactoryStore[Now_Select_Number].GetClassification()==3)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("smartphone-call");
				//4:機工 
			else if(MainState.FactoryStore[Now_Select_Number].GetClassification()==4)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("screwdriver-and-wrench-crossed");
				//5:金融
			else if(MainState.FactoryStore[Now_Select_Number].GetClassification()==5)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("bank-building");
			break;
			//銀行家
		case 4:
			//店鋪分類圖片(讀取在Resources資料夾的圖片)
				//1:烹飪  
			if(MainState.EconomicStore[Now_Select_Number].GetClassification()==1)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("food");
				//2:音樂
			else if(MainState.EconomicStore[Now_Select_Number].GetClassification()==2)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("music-player");
				//3:科技 
			else if(MainState.EconomicStore[Now_Select_Number].GetClassification()==3)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("smartphone-call");
				//4:機工 
			else if(MainState.EconomicStore[Now_Select_Number].GetClassification()==4)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("screwdriver-and-wrench-crossed");
				//5:金融
			else if(MainState.EconomicStore[Now_Select_Number].GetClassification()==5)ClassImage.sprite = (Sprite)Resources.Load<Sprite>("bank-building");
			break;

		}//switch

	}

	//副程式:設定店鋪圖片
	void Set_Store_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪圖片(讀取在Resources資料夾的圖片)
			Store_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.BreadStoreImage_String[Now_Select_Number]);
			break;
			//音樂人
		case 1:
			//店鋪圖片(讀取在Resources資料夾的圖片)
				Store_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.MusicStoreImage_String[Now_Select_Number]);
			break;
			//科技新貴
		case 2:
			//店鋪圖片(讀取在Resources資料夾的圖片)
				Store_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.TehcnologyStoreImage_String[Now_Select_Number]);
			break;
			//機工
		case 3:
			//店鋪圖片(讀取在Resources資料夾的圖片)
				Store_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.FactoryStoreImage_String[Now_Select_Number]);
			break;
			//銀行家
		case 4:
			//店鋪圖片(讀取在Resources資料夾的圖片)
				Store_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.EconomicStoreImage_String[Now_Select_Number]);
			break;

		}//switch

	}

	//副程式:設定店鋪是否擁有圖片
	void Set_Store_Own_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪是否擁有圖片(讀取在Resources資料夾的圖片)
				//擁有
			if (MainState.BreadStore [Now_Select_Number].GetOwnBool() == true) {
					OwnImage.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
					UnOwnImage.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} 
				//未擁有
				else {
					OwnImage.color = new Color(255.0f,255.0f,255.0f,0.0f);
					UnOwnImage.color = new Color(255.0f,255.0f,255.0f,255.0f);
				}
			break;
			//音樂人
		case 1:
			//店鋪是否擁有圖片(讀取在Resources資料夾的圖片)
				//擁有
				if (MainState.MusicStore [Now_Select_Number].GetOwnBool() == true) {
					OwnImage.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
					UnOwnImage .color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} 
				//未擁有
				else {
					OwnImage .color = new Color(255.0f,255.0f,255.0f,0.0f);
					UnOwnImage.color = new Color(255.0f,255.0f,255.0f,255.0f);
				}
			break;
			//科技新貴
		case 2:
			//店鋪是否擁有圖片(讀取在Resources資料夾的圖片)
				//擁有
				if (MainState.TehcnologyStore [Now_Select_Number].GetOwnBool() == true) {
					OwnImage .color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
					UnOwnImage.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} 
				//未擁有
				else {
					OwnImage.color = new Color(255.0f,255.0f,255.0f,0.0f);
					UnOwnImage.color = new Color(255.0f,255.0f,255.0f,255.0f);
				}
			break;
			//機工
		case 3:
			//店鋪是否擁有圖片(讀取在Resources資料夾的圖片)
				//擁有
				if (MainState.FactoryStore [Now_Select_Number].GetOwnBool() == true) {
					OwnImage .color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
					UnOwnImage .color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} 
				//未擁有
				else {
					OwnImage .color = new Color(255.0f,255.0f,255.0f,0.0f);
					UnOwnImage.color = new Color(255.0f,255.0f,255.0f,255.0f);
				}
			break;
			//銀行家
		case 4:
			//店鋪是否擁有圖片(讀取在Resources資料夾的圖片)
				//擁有
				if (MainState.EconomicStore [Now_Select_Number].GetOwnBool() == true) {
					OwnImage .color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
					UnOwnImage .color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				} 
				//未擁有
				else {
					OwnImage .color = new Color(255.0f,255.0f,255.0f,0.0f);
					UnOwnImage.color = new Color(255.0f,255.0f,255.0f,255.0f);
				}
			break;

		}//switch

	}

	//副程式:設定現在選擇店鋪圖片
	void Set_SelectStore_Image(){
		for (int i = 0; i < 10; i++) {
			//顯示現在選擇店鋪的背景
			if (Now_Select_Number == i)
				SelectStore_Image [i].color = new Color (255.0f,255.0f,255.0f,255.0f);
			//隱藏不是現在選擇店鋪的背景
			else 
				SelectStore_Image [i].color = new Color (255.0f,255.0f,255.0f,0.0f);
		}
	}


}
