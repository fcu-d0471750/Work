//Work頁面 UI控制 邏輯運算 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Work : MonoBehaviour {
  

  //宣告變數==============================================================================
	//回收_景氣
	float Economy;
	//回收_佔有率獎勵
	uint Present;
	//回收_總計
	uint PaySum;

	//經營決定_經理薪水
	uint ManageSalary;
	//經營決定_警衛薪水
	uint SecuritySalary;
	//經營決定_總計
	uint ManagePaySum;
	//經營決定_區域
	int ManageAreaNumber = 0;

	//是否為決定畫面 true:是 fasle:不是
	bool DecisionBool = false;
  //宣告UI================================================================================
	//GameObject************************************
	//Work畫面
	public GameObject WorkBackGround;
	//Manage畫面
	public GameObject ManageBackGround;
	//Area畫面
	public GameObject AreaBackGround;
	//People畫面
	public GameObject PeopleBackGround;
	//Hire畫面
	public GameObject HireBackGround;
	//BuyStore畫面
	public GameObject BuyStoreBackGround;
	//PayBack畫面
	public GameObject PayBackBackGround;
	//ManageDecision畫面
	public GameObject ManageDecisionBackGround;
	//存檔決定畫面
	public GameObject Save_Decision;
	//讀檔決定畫面
	public GameObject Write_Decision;

	//按鈕===============================
	//經營按鈕(麵包師傅)
	public Button Bread_Button;
	//經營按鈕(音樂人)
	public Button Music_Button;
	//經營按鈕(科技新貴)
	public Button Tehcnology_Button;
	//經營按鈕(機工)
	public Button Factory_Button;
	//經營按鈕(銀行家)
	public Button Economic_Button;
	//置產按鈕
	public Button BuyStore_Button;
	//徵人按鈕
	public Button Hire_Button;
	//店鋪一覽按鈕
	public Button Store_Button;
	//人員一覽按鈕
	public Button Employee_Button;

	//麵包師傅區域經營按鈕
	public Button Bread_Manage_Button;
	//音樂人區域經營按鈕
	public Button Music_Manage_Button;
	//科技新貴區域經營按鈕
	public Button Tehcnology_Manage_Button;
	//機工區域經營按鈕
	public Button Factory_Manage_Button;
	//銀行家區域經營按鈕
	public Button Economic_Manage_Button;

	//回收按鈕
	//public Button PayBack_Button;

	//開始經營按鈕(確定)
	public Button ManageDecision_Accept_Button;
	//開始經營按鈕(取消)
	//public Button ManageDecision_cancel_Button;

	//存檔按鈕
	public Button Save_Button;
	//讀檔按鈕
	public Button Write_Button;

	//Text================================
	//持有金錢
	public Text OwnMoneyText;

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

	//區域回收長條圖Text(麵包師傅)
	public Text Bread_Bar_Text;
	//區域回收長條圖Text(音樂人)
	public Text Music_Bar_Text;
	//區域回收長條圖Text(科技新貴)
	public Text Tehcnology_Bar_Text;
	//區域回收長條圖Text(機工)
	public Text Factory_Bar_Text;
	//區域回收長條圖Text(銀行家)
	public Text Economic_Bar_Text;

	//回收_區域名稱
	public Text AreaName_Text;
	//回收_預期利潤
	public Text Predict_Text;
	//回收_景氣
	public Text Economy_Text;
	//回收_佔有率獎勵
	public Text OccupancyPresent_Text;
	//回收_總計
	public Text PaySum_Text;

	//經營決定_經理薪水
	public Text ManageSalary_Text;
	//經營決定_警衛薪水
	public Text SecuritySalary_Text;
	//經營決定_總計
	public Text ManagePaySum_Text;

	//Image===============================
	/*//區域圖片(麵包師傅)
	public Image Bread_Image;
	//區域圖片(音樂人)
	public Image Music_Image;
	//區域圖片(科技新貴)
	public Image Tehcnology_Image;
	//區域圖片(機工)
	public Image Factory_Image;
	//區域圖片(銀行家)
	public Image Economic_Image;*/

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

	//區域回收長條圖(麵包師傅)
	public Image Bread_Bar_Image;
	//區域回收長條圖(音樂人)
	public Image Music_Bar_Image;
	//區域回收長條圖(科技新貴)
	public Image Tehcnology_Bar_Image;
	//區域回收長條圖(機工)
	public Image Factory_Bar_Image;
	//區域回收長條圖(銀行家)
	public Image Economic_Bar_Image;

	//回收_景氣圖片
	public Image NowEconomy_Image;


	//經營決定_經理圖片
	public Image Manage_Image;
	//經營決定_警衛圖片
	public Image Security_Image;

	//宣告動畫============================================================
	//持有金錢變化動畫
	public Animation Own_Money_Change_Animation;


	// Use this for initialization
	void Start () {
	    //初始畫面設定************************************************
		//隱藏Manage畫面
		ManageBackGround.SetActive(false);
		//隱藏Area畫面
		AreaBackGround.SetActive(false);
		//隱藏People畫面
		PeopleBackGround.SetActive(false);
		//隱藏Hire畫面
		HireBackGround.SetActive(false);
		//隱藏BuyStore畫面
		BuyStoreBackGround.SetActive(false);
		//顯示Work畫面
		WorkBackGround.SetActive(true);



	}
	
	// Update is called once per frame
	void Update () {

		//設定Text*****************************************************
		//持有金錢
		MainState.SetText_OwnMoney(OwnMoneyText);
		//佔有率
		Set_Present_Text ();
		//預期利潤
		Set_Price_Text ();
		//經營長條圖Text
		if(!DecisionBool)Set_Bar_Text();

		//設定圖片*****************************************************
		//佔有率
		Set_Present_Image();
		//經營長條圖，回收時間會不斷變化
		Set_Bar_Image();

		//開啟讀檔按鈕
		if(MainState.Saved==1) Write_Button.interactable = true;
		else Write_Button.interactable = false;

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
		//設定佔有率
		MainState.BreadArea.SetPresent((PresentTemp/MainState.BreadStoreNumber)*100.0f);
		PresentTemp = 0.0f;
		//區域佔有率(音樂人)
		for (int i = 0; i < MainState.MusicStoreNumber; i++) {
			if (MainState.MusicStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Music_Present_Text.text = (PresentTemp/MainState.MusicStoreNumber)*100.0f + "%";
		//設定佔有率
		MainState.MusicArea.SetPresent((PresentTemp/MainState.MusicStoreNumber)*100.0f);
		PresentTemp = 0.0f;
		//區域佔有率(科技新貴)
		for (int i = 0; i < MainState.TehcnologyStoreNumber; i++) {
			if (MainState.TehcnologyStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Tehcnology_Present_Text.text = (PresentTemp/MainState.TehcnologyStoreNumber)*100.0f + "%";
		//設定佔有率
		MainState.TehcnologyArea.SetPresent((PresentTemp/MainState.TehcnologyStoreNumber)*100.0f);
		PresentTemp = 0.0f;
		//區域佔有率(機工)
		for (int i = 0; i < MainState.FactoryStoreNumber; i++) {
			if (MainState.FactoryStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Factory_Present_Text.text = (PresentTemp/MainState.FactoryStoreNumber)*100.0f + "%";
		//設定佔有率
		MainState.FactoryArea.SetPresent((PresentTemp/MainState.FactoryStoreNumber)*100.0f);
		PresentTemp = 0.0f;
		//區域佔有率(銀行家)
		for (int i = 0; i < MainState.EconomicStoreNumber; i++) {
			if (MainState.EconomicStore [i].GetOwnBool())
				PresentTemp = PresentTemp + 1.0f;
		}
		Economic_Present_Text.text = (PresentTemp/MainState.EconomicStoreNumber)*100.0f + "%";
		//設定佔有率
		MainState.EconomicArea.SetPresent((PresentTemp/MainState.EconomicStoreNumber)*100.0f);
		PresentTemp = 0.0f;
	}

	//副程式:設定經營長條圖Text
	void Set_Bar_Text(){
		//(麵包師傅區域)
		//可經營狀態 && 如果至少擁有1間店
		if (MainState.BreadArea.GetManage () && MainState.BreadArea.GetStoreNumber () >= 1) {
			Bread_Bar_Text.text = "可開始經營";
			Bread_Button.interactable = true;
		}
		//不可經營狀態 && 沒擁有1間店
		else if (!MainState.BreadArea.GetManage () && MainState.BreadArea.GetStoreNumber () == 0) {
			Bread_Bar_Text.text = "不可經營";
			Bread_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店
		else if (!MainState.BreadArea.GetManage () && MainState.BreadArea.GetStoreNumber () >= 1 && MainState.BreadArea.GetManageTime () < 100.0f) {
			Bread_Bar_Text.text = "經營中";
			Bread_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店 && 回收時間==100(可回收)
		else if (!MainState.BreadArea.GetManage () && MainState.BreadArea.GetStoreNumber () >= 1 && MainState.BreadArea.GetManageTime () >= 100.0f) {
			Bread_Bar_Text.text = "可回收資金";
			Bread_Button.interactable = false;
		}

		//(音樂人區域)
		//可經營狀態 && 如果至少擁有1間店
		if (MainState.MusicArea.GetManage () && MainState.MusicArea.GetStoreNumber () >= 1) {
			Music_Bar_Text.text = "可開始經營";
			Music_Button.interactable = true;
		}
		//不可經營狀態 && 沒擁有1間店
		else if (!MainState.MusicArea.GetManage () && MainState.MusicArea.GetStoreNumber () == 0) {
			Music_Bar_Text.text = "不可經營";
			Music_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店
		else if (!MainState.MusicArea.GetManage () && MainState.MusicArea.GetStoreNumber () >= 1 && MainState.MusicArea.GetManageTime () < 100.0f) {
			Music_Bar_Text.text = "經營中";
			Music_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店 && 回收時間==100(可回收)
		else if (!MainState.MusicArea.GetManage () && MainState.MusicArea.GetStoreNumber () >= 1 && MainState.MusicArea.GetManageTime () >= 100.0f) {
			Music_Bar_Text.text = "可回收資金";
			Music_Button.interactable = false;
		}

		//(科技新貴傅區域)
		//可經營狀態 && 如果至少擁有1間店
		if (MainState.TehcnologyArea.GetManage () && MainState.TehcnologyArea.GetStoreNumber () >= 1) {
			Tehcnology_Bar_Text.text = "可開始經營";
			Tehcnology_Button.interactable = true;
		}
		//不可經營狀態 && 沒擁有1間店
		else if (!MainState.TehcnologyArea.GetManage () && MainState.TehcnologyArea.GetStoreNumber () == 0) {
			Tehcnology_Bar_Text.text = "不可經營";
			Tehcnology_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店
		else if (!MainState.TehcnologyArea.GetManage () && MainState.TehcnologyArea.GetStoreNumber () >= 1 && MainState.TehcnologyArea.GetManageTime () < 100.0f) {
			Tehcnology_Bar_Text.text = "經營中";
			Tehcnology_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店 && 回收時間==100(可回收)
		else if (!MainState.TehcnologyArea.GetManage () && MainState.TehcnologyArea.GetStoreNumber () >= 1 && MainState.TehcnologyArea.GetManageTime () >= 100.0f) {
			Tehcnology_Bar_Text.text = "可回收資金";
			Tehcnology_Button.interactable = false;
		}

		//(機工區域)
		//可經營狀態 && 如果至少擁有1間店
		if (MainState.FactoryArea.GetManage () && MainState.FactoryArea.GetStoreNumber () >= 1) {
			Factory_Bar_Text.text = "可開始經營";
			Factory_Button.interactable = true;
		}
		//不可經營狀態 && 沒擁有1間店
		else if (!MainState.FactoryArea.GetManage () && MainState.FactoryArea.GetStoreNumber () == 0) {
			Factory_Bar_Text.text = "不可經營";
			Factory_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店
		else if (!MainState.FactoryArea.GetManage () && MainState.FactoryArea.GetStoreNumber () >= 1 && MainState.FactoryArea.GetManageTime () < 100.0f) {
			Factory_Bar_Text.text = "經營中";
			Factory_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店 && 回收時間==100(可回收)
		else if (!MainState.FactoryArea.GetManage () && MainState.FactoryArea.GetStoreNumber () >= 1 && MainState.FactoryArea.GetManageTime () >= 100.0f) {
			Factory_Bar_Text.text = "可回收資金";
			Factory_Button.interactable = false;
		}

		//(銀行家區域)
		//可經營狀態 && 如果至少擁有1間店
		if (MainState.EconomicArea.GetManage () && MainState.EconomicArea.GetStoreNumber () >= 1) {
			Economic_Bar_Text.text = "可開始經營";
			Economic_Button.interactable = true;
		}
		//不可經營狀態 && 沒擁有1間店
		else if (!MainState.EconomicArea.GetManage () && MainState.EconomicArea.GetStoreNumber () == 0) {
			Economic_Bar_Text.text = "不可經營";
			Economic_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店
		else if (!MainState.EconomicArea.GetManage () && MainState.EconomicArea.GetStoreNumber () >= 1 && MainState.EconomicArea.GetManageTime () < 100.0f) {
			Economic_Bar_Text.text = "經營中";
			Economic_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店 && 回收時間==100(可回收)
		else if (!MainState.EconomicArea.GetManage () && MainState.EconomicArea.GetStoreNumber () >= 1 && MainState.EconomicArea.GetManageTime () >= 100.0f) {
			Economic_Bar_Text.text = "可回收資金";
			Economic_Button.interactable = false;
		}

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

	//副程式:設定經營長條圖Image
	void Set_Bar_Image(){
		//(麵包師傅區域)
		//可經營狀態 && 如果至少擁有1間店
		if (MainState.BreadArea.GetManage () && MainState.BreadArea.GetStoreNumber () >= 1) {
			Bread_Bar_Image.fillAmount = 0.0f;
			if(!DecisionBool)Bread_Manage_Button.interactable = true;
		}
		//不可經營狀態 && 沒擁有1間店
		else if (!MainState.BreadArea.GetManage () && MainState.BreadArea.GetStoreNumber () == 0) {
			Bread_Bar_Image.fillAmount = 0.0f;
			if(!DecisionBool)Bread_Manage_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店
		else if (!MainState.BreadArea.GetManage () && MainState.BreadArea.GetStoreNumber () >= 1 && MainState.BreadArea.GetManageTime () < 100.0f) {
			Bread_Bar_Image.fillAmount = MainState.BreadArea.GetManageTime () / 100.0f;
			if(!DecisionBool)Bread_Manage_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店 && 回收時間==100(可回收)
		else if (!MainState.BreadArea.GetManage () && MainState.BreadArea.GetStoreNumber () >= 1 && MainState.BreadArea.GetManageTime () >= 100.0f) {
			Bread_Bar_Image.fillAmount = 1.0f;
			if(!DecisionBool)Bread_Manage_Button.interactable = true;
		}

		//(音樂人區域)
		//可經營狀態 && 如果至少擁有1間店
		if (MainState.MusicArea.GetManage () && MainState.MusicArea.GetStoreNumber () >= 1) {
			Music_Bar_Image.fillAmount = 0.0f;
			if(!DecisionBool)Music_Manage_Button.interactable = true;
		}
		//不可經營狀態 && 沒擁有1間店
		else if (!MainState.MusicArea.GetManage () && MainState.MusicArea.GetStoreNumber () == 0) {
			Music_Bar_Image.fillAmount = 0.0f;
			if(!DecisionBool)Music_Manage_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店
		else if (!MainState.MusicArea.GetManage () && MainState.MusicArea.GetStoreNumber () >= 1 && MainState.MusicArea.GetManageTime () < 100.0f) {
			Music_Bar_Image.fillAmount = MainState.MusicArea.GetManageTime () / 100.0f;
			if(!DecisionBool)Music_Manage_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店 && 回收時間==100(可回收)
		else if (!MainState.MusicArea.GetManage () && MainState.MusicArea.GetStoreNumber () >= 1 && MainState.MusicArea.GetManageTime () >= 100.0f) {
			Music_Bar_Image.fillAmount = 1.0f;
			if(!DecisionBool)Music_Manage_Button.interactable = true;
		}

		//(科技新貴傅區域)
		//可經營狀態 && 如果至少擁有1間店
		if (MainState.TehcnologyArea.GetManage () && MainState.TehcnologyArea.GetStoreNumber () >= 1) {
			Tehcnology_Bar_Image.fillAmount = 0.0f;
			if(!DecisionBool)Tehcnology_Manage_Button.interactable = true;
		}
		//不可經營狀態 && 沒擁有1間店
		else if (!MainState.TehcnologyArea.GetManage () && MainState.TehcnologyArea.GetStoreNumber () == 0) {
			Tehcnology_Bar_Image.fillAmount = 0.0f;
			if(!DecisionBool)Tehcnology_Manage_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店
		else if (!MainState.TehcnologyArea.GetManage () && MainState.TehcnologyArea.GetStoreNumber () >= 1 && MainState.TehcnologyArea.GetManageTime () < 100.0f) {
			Tehcnology_Bar_Image.fillAmount = MainState.TehcnologyArea.GetManageTime () / 100.0f;
			if(!DecisionBool)Tehcnology_Manage_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店 && 回收時間==100(可回收)
		else if (!MainState.TehcnologyArea.GetManage () && MainState.TehcnologyArea.GetStoreNumber () >= 1 && MainState.TehcnologyArea.GetManageTime () >= 100.0f) {
			Tehcnology_Bar_Image.fillAmount = 1.0f;
			if(!DecisionBool)Tehcnology_Manage_Button.interactable = true;
		}

		//(機工區域)
		//可經營狀態 && 如果至少擁有1間店
		if (MainState.FactoryArea.GetManage () && MainState.FactoryArea.GetStoreNumber () >= 1) {
			Factory_Bar_Image.fillAmount = 0.0f;
			if(!DecisionBool)Factory_Manage_Button.interactable = true;
		}
		//不可經營狀態 && 沒擁有1間店
		else if (!MainState.FactoryArea.GetManage () && MainState.FactoryArea.GetStoreNumber () == 0) {
			Factory_Bar_Image.fillAmount = 0.0f;
			if(!DecisionBool)Factory_Manage_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店
		else if (!MainState.FactoryArea.GetManage () && MainState.FactoryArea.GetStoreNumber () >= 1 && MainState.FactoryArea.GetManageTime () < 100.0f) {
			Factory_Bar_Image.fillAmount = MainState.FactoryArea.GetManageTime () / 100.0f;
			if(!DecisionBool)Factory_Manage_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店 && 回收時間==100(可回收)
		else if (!MainState.FactoryArea.GetManage () && MainState.FactoryArea.GetStoreNumber () >= 1 && MainState.FactoryArea.GetManageTime () >= 100.0f) {
			Factory_Bar_Image.fillAmount = 1.0f;
			if(!DecisionBool)Factory_Manage_Button.interactable = true;
		}

		//(銀行家區域)
		//可經營狀態 && 如果至少擁有1間店
		if (MainState.EconomicArea.GetManage () && MainState.EconomicArea.GetStoreNumber () >= 1) {
			Economic_Bar_Image.fillAmount = 0.0f;
			if(!DecisionBool)Economic_Manage_Button.interactable = true;
		}
		//不可經營狀態 && 沒擁有1間店
		else if (!MainState.EconomicArea.GetManage () && MainState.EconomicArea.GetStoreNumber () == 0) {
			Economic_Bar_Image.fillAmount = 0.0f;
			if(!DecisionBool)Economic_Manage_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店
		else if (!MainState.EconomicArea.GetManage () && MainState.EconomicArea.GetStoreNumber () >= 1 && MainState.EconomicArea.GetManageTime () < 100.0f) {
			Economic_Bar_Image.fillAmount = MainState.EconomicArea.GetManageTime () / 100.0f;
			if(!DecisionBool)Economic_Manage_Button.interactable = false;
		}
		//不可經營狀態 && 至少擁有1間店 && 回收時間==100(可回收)
		else if (!MainState.EconomicArea.GetManage () && MainState.EconomicArea.GetStoreNumber () >= 1 && MainState.EconomicArea.GetManageTime () >= 100.0f) {
			Economic_Bar_Image.fillAmount = 1.0f;
			if(!DecisionBool)Economic_Manage_Button.interactable = true;
		}

	}
		

	//副程式:Manage頁面
	public void ManagePage(int Area){
		//播放按鈕音效
		MainState.Button_Sounds_Play();
		//隱藏Work畫面
		WorkBackGround.SetActive(false);
		MainState.WorkBool = false;
		//顯示Manage畫面
		ManageBackGround.SetActive(true);
		MainState.ManageBool = true;
		//隱藏Area畫面
		AreaBackGround.SetActive(false);
		MainState.AreaBool = false;
		//隱藏People畫面
		PeopleBackGround.SetActive(false);
		MainState.PeopleBool = false;
		//隱藏Hire畫面
		HireBackGround.SetActive(false);
		MainState.HireBool = false;
		//隱藏BuyStore畫面
		BuyStoreBackGround.SetActive(false);
		MainState.BuyStoreBool = false;

		//設定經營哪個區域
		Manage.Manage_Area_Number = Area;
	}
	//副程式:Area頁面
	public void AreaPage(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//隱藏Work畫面
		WorkBackGround.SetActive(false);
		MainState.WorkBool = false;
		//隱藏Manage畫面
		ManageBackGround.SetActive(false);
		MainState.ManageBool = false;
		//顯示Area畫面
		AreaBackGround.SetActive(true);
		MainState.AreaBool = true;
		//隱藏People畫面
		PeopleBackGround.SetActive(false);
		MainState.PeopleBool = false;
		//隱藏Hire畫面
		HireBackGround.SetActive(false);
		MainState.HireBool = false;
		//隱藏BuyStore畫面
		BuyStoreBackGround.SetActive(false);
		MainState.BuyStoreBool = false;
	}
	//副程式:People頁面
	public void PeoplePage(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//隱藏Work畫面
		WorkBackGround.SetActive(false);
		MainState.WorkBool = false;
		//隱藏Manage畫面
		ManageBackGround.SetActive(false);
		MainState.ManageBool = false;
		//隱藏Area畫面
		AreaBackGround.SetActive(false);
		MainState.AreaBool = false;
		//顯示People畫面
		PeopleBackGround.SetActive(true);
		MainState.PeopleBool = true;
		//隱藏Hire畫面
		HireBackGround.SetActive(false);
		MainState.HireBool = false;
		//隱藏BuyStore畫面
		BuyStoreBackGround.SetActive(false);
		MainState.BuyStoreBool = false;
	}
	//副程式:Hire頁面
	public void HirePage(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//隱藏Work畫面
		WorkBackGround.SetActive(false);
		MainState.WorkBool = false;
		//隱藏Manage畫面
		ManageBackGround.SetActive(false);
		MainState.ManageBool = false;
		//隱藏Area畫面
		AreaBackGround.SetActive(false);
		MainState.AreaBool = false;
		//隱藏People畫面
		PeopleBackGround.SetActive(false);
		MainState.PeopleBool = false;
		//顯示Hire畫面
		HireBackGround.SetActive(true);
		MainState.HireBool = true;
		//隱藏BuyStore畫面
		BuyStoreBackGround.SetActive(false);
		MainState.BuyStoreBool = false;
	}
	//副程式:BuyStore頁面
	public void BuyStorePage(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//隱藏Work畫面
		WorkBackGround.SetActive(false);
		MainState.WorkBool = false;
		//隱藏Manage畫面
		ManageBackGround.SetActive(false);
		MainState.ManageBool = false;
		//隱藏Area畫面
		AreaBackGround.SetActive(false);
		MainState.AreaBool = false;
		//隱藏People畫面
		PeopleBackGround.SetActive(false);
		MainState.PeopleBool = false;
		//隱藏Hire畫面
		HireBackGround.SetActive(false);
		MainState.HireBool = false;
		//顯示BuyStore畫面
		BuyStoreBackGround.SetActive(true);
		MainState.BuyStoreBool = true;
	}

	//副程式(按鈕):存檔按鈕
	public void Set_Save_Button(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//存檔按鈕設為不可用
		Save_Button.interactable = false;
		//讀檔按鈕設為不可用
		Write_Button.interactable = false;
		//顯示存檔決定畫面
		Save_Decision.SetActive(true);

		//經營按鈕設為不可用(麵包師傅)
		Bread_Button.interactable = false;
		//經營按鈕設為不可用(音樂人)
		Music_Button.interactable = false;
		//經營按鈕設為不可用(科技新貴)
		Tehcnology_Button.interactable = false;
		//經營按鈕設為不可用(機工)
		Factory_Button.interactable = false;
		//經營按鈕設為不可用(銀行家)
		Economic_Button.interactable = false;
		//置產按鈕設為不可用
		BuyStore_Button.interactable = false;
		//徵人按鈕設為不可用
		Hire_Button.interactable = false;
		//店鋪一覽按鈕設為不可用
		Store_Button.interactable = false;
		//人員一覽按鈕設為不可用
		Employee_Button.interactable = false;

		//麵包師傅區域經營按鈕設為不可用
		Bread_Manage_Button.interactable = false;
		//音樂人區域經營按鈕設為不可用
		Music_Manage_Button.interactable = false;
		//科技新貴區域經營按鈕設為不可用
		Tehcnology_Manage_Button.interactable = false;
		//機工區域經營按鈕設為不可用
		Factory_Manage_Button.interactable = false;
		//銀行家區域經營按鈕設為不可用
		Economic_Manage_Button.interactable = false;


		//變更狀態為決定畫面
		DecisionBool = true;
	}

	//副程式(按鈕):存檔決定和取消按鈕
	public void Sava_Accept_Canacel_Decision(int Number){
		switch (Number) {
		//決定
		case 0:
			MainState.Save_ALL ();
			//播放按鈕音效
			MainState.Button_Sounds_Play();
			break;
		//取消
		case 1:
			//播放取消按鈕音效
			MainState.Cancel_Button_Sounds_Play();
			break;
		}//switch

		//隱藏存檔決定畫面
		Save_Decision.SetActive(false);
		//經營按鈕設為可用(麵包師傅)
		Bread_Button.interactable = true;
		//經營按鈕設為可用(音樂人)
		Music_Button.interactable = true;
		//經營按鈕設為可用(科技新貴)
		Tehcnology_Button.interactable = true;
		//經營按鈕設為可用(機工)
		Factory_Button.interactable = true;
		//經營按鈕設為可用(銀行家)
		Economic_Button.interactable = true;
		//置產按鈕設為可用
		BuyStore_Button.interactable = true;
		//徵人按鈕設為可用
		Hire_Button.interactable = true;
		//店鋪一覽按鈕設為可用
		Store_Button.interactable = true;
		//人員一覽按鈕設為可用
		Employee_Button.interactable = true;

		//麵包師傅區域經營按鈕設為可用
		Bread_Manage_Button.interactable = true;
		//音樂人區域經營按鈕設為可用
		Music_Manage_Button.interactable = true;
		//科技新貴區域經營按鈕設為可用
		Tehcnology_Manage_Button.interactable = true;
		//機工區域經營按鈕設為可用
		Factory_Manage_Button.interactable = true;
		//銀行家區域經營按鈕設為可用
		Economic_Manage_Button.interactable = true;

		//存檔按鈕設為可用
		Save_Button.interactable = true;
		//讀檔按鈕設為可用
		Write_Button.interactable = true;

		//變更狀態為不是決定畫面
		DecisionBool = false;
	}

	//副程式(按鈕):讀檔按鈕
	public void Set_Write_Button(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//存檔按鈕設為不可用
		Save_Button.interactable = false;
		//讀檔按鈕設為不可用
		Write_Button.interactable = false;
		//顯示讀檔決定畫面
		Write_Decision.SetActive(true);

		//經營按鈕設為不可用(麵包師傅)
		Bread_Button.interactable = false;
		//經營按鈕設為不可用(音樂人)
		Music_Button.interactable = false;
		//經營按鈕設為不可用(科技新貴)
		Tehcnology_Button.interactable = false;
		//經營按鈕設為不可用(機工)
		Factory_Button.interactable = false;
		//經營按鈕設為不可用(銀行家)
		Economic_Button.interactable = false;
		//置產按鈕設為不可用
		BuyStore_Button.interactable = false;
		//徵人按鈕設為不可用
		Hire_Button.interactable = false;
		//店鋪一覽按鈕設為不可用
		Store_Button.interactable = false;
		//人員一覽按鈕設為不可用
		Employee_Button.interactable = false;

		//麵包師傅區域經營按鈕設為不可用
		Bread_Manage_Button.interactable = false;
		//音樂人區域經營按鈕設為不可用
		Music_Manage_Button.interactable = false;
		//科技新貴區域經營按鈕設為不可用
		Tehcnology_Manage_Button.interactable = false;
		//機工區域經營按鈕設為不可用
		Factory_Manage_Button.interactable = false;
		//銀行家區域經營按鈕設為不可用
		Economic_Manage_Button.interactable = false;


		//變更狀態為決定畫面
		DecisionBool = true;
	}

	//副程式(按鈕):讀檔決定和取消按鈕
	public void Write_Accept_Canacel_Decision(int Number){
		switch (Number) {
		//決定
		case 0:
			MainState.Write_ALL ();
			//播放按鈕音效
			MainState.Button_Sounds_Play();
			break;
			//取消
		case 1:
			//播放取消按鈕音效
			MainState.Cancel_Button_Sounds_Play();
			break;
		}//switch

		//隱藏讀檔決定畫面
		Write_Decision.SetActive(false);
		//經營按鈕設為可用(麵包師傅)
		Bread_Button.interactable = true;
		//經營按鈕設為可用(音樂人)
		Music_Button.interactable = true;
		//經營按鈕設為可用(科技新貴)
		Tehcnology_Button.interactable = true;
		//經營按鈕設為可用(機工)
		Factory_Button.interactable = true;
		//經營按鈕設為可用(銀行家)
		Economic_Button.interactable = true;
		//置產按鈕設為可用
		BuyStore_Button.interactable = true;
		//徵人按鈕設為可用
		Hire_Button.interactable = true;
		//店鋪一覽按鈕設為可用
		Store_Button.interactable = true;
		//人員一覽按鈕設為可用
		Employee_Button.interactable = true;

		//麵包師傅區域經營按鈕設為可用
		Bread_Manage_Button.interactable = true;
		//音樂人區域經營按鈕設為可用
		Music_Manage_Button.interactable = true;
		//科技新貴區域經營按鈕設為可用
		Tehcnology_Manage_Button.interactable = true;
		//機工區域經營按鈕設為可用
		Factory_Manage_Button.interactable = true;
		//銀行家區域經營按鈕設為可用
		Economic_Manage_Button.interactable = true;

		//存檔按鈕設為可用
		Save_Button.interactable = true;
		//讀檔按鈕設為可用
		Write_Button.interactable = true;

		//變更狀態為不是決定畫面
		DecisionBool = false;
	}

    //副程式(按鈕):存檔按鈕
    public void Set_Quit_Button() {
        MainState.Quit_Game();
    }


	//副程式:PayBack頁面
	public void PayBackPage(int Area){
		//預期利潤暫存
		uint PriceTemp = 0;
		//景氣獎勵暫存
		uint EconomyTemp = 0;
		//佔有率獎勵
		uint OccupancyTemp = 0;

		//經理薪水
		uint ManageSalaryTemp = 0;
		//警衛薪水
		uint SecuritySalaryTemp = 0;

		//播放PayBack音效
		MainState.PayBack_Button_Sounds_Play();

		switch (Area) {
		//麵包師傅
		case 0:
			//不可經營狀態
			if (!MainState.BreadArea.GetManage ()) {
				//區域名稱
				AreaName_Text.text = "<color=#D3BEA3FF>麵包師傅區域</color>";
				//預期利潤
				for (int i = 0; i < MainState.BreadStoreNumber; i++) {
					if (MainState.BreadStore [i].GetOwnBool ())
						PriceTemp = PriceTemp + (MainState.BreadStore [i].GetPrice ()*(uint)MainState.BreadStore[i].GetLevel());
				}
				MainState.SetText_Pricey (PriceTemp, Predict_Text);
				//景氣
				Set_NowEconomy_Image(Area);
				Economy_Text.text = MainState.BreadArea.GetEconomyBack ().ToString ("0") + "%";
				//景氣獎勵 = 預期利潤 * (景氣/100.0f)
				EconomyTemp = (uint)((float)PriceTemp * (MainState.BreadArea.GetEconomyBack () / 1000.0f));
				//佔有率獎勵
				OccupancyTemp = (uint)((float)PriceTemp * (MainState.BreadArea.GetPresent () / 1000.0f));
				MainState.SetText_Pricey (OccupancyTemp, OccupancyPresent_Text);
				//總計
				PaySum = PriceTemp + EconomyTemp + OccupancyTemp;
				MainState.SetText_Pricey (PaySum, PaySum_Text); 

				//設定狀態
				MainState.BreadArea.SetManage(true);
				MainState.BreadArea.SetManageTime (0.0f);

				//將已擁有的店鋪設為可投資
				for(int i=0; i<MainState.BreadStoreNumber; i++){
					if (MainState.BreadStore [i].GetOwnBool () == true) MainState.BreadStore [i].SetInvestBool (false);
				}

				//設定新的景氣
				for(int i=0; i<MainState.ManageNumber; i++){
					if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace () == 0) {
						MainState.Bread_NowEconomy = (byte)UnityEngine.Random.Range (8 * MainState.Manage [i].GetAbility (), 30 * MainState.Manage [i].GetAbility ());
						MainState.BreadArea.SetEconomyBack (MainState.Bread_NowEconomy);
					} else {
						MainState.Bread_NowEconomy = (byte)UnityEngine.Random.Range (0, 70);
						MainState.BreadArea.SetEconomyBack (MainState.Bread_NowEconomy);
					}
				}

				//設定新的治安
				for(int i=0; i<MainState.SecurityNumber; i++){
					if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace () == 0) {
						MainState.Bread_NowSecurity = (byte)UnityEngine.Random.Range (8 * MainState.Security [i].GetAbility (), 20 * MainState.Security [i].GetAbility ());
						MainState.BreadArea.SetSecurityBack (MainState.Bread_NowSecurity);
					} else {
						MainState.Bread_NowSecurity = (byte)UnityEngine.Random.Range (0, 70);
						MainState.BreadArea.SetSecurityBack (MainState.Bread_NowSecurity);
					}
				}

				//顯示PayBack
				PayBackBackGround.SetActive (true);
			}
			//可經營狀態
			else{
			  //經理圖片(讀取在Resources資料夾的圖片)
				for(int i=0; i<MainState.ManageNumber; i++){
					//有經理出勤
					if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 0) {
						Manage_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[i]);
						break;
					}
					//沒有經理出勤
					else {
						Manage_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
					}
				}

			 //警衛圖片ManagePaySum_Text
				//區域警衛圖片(讀取在Resources資料夾的圖片)
				for(int i=0; i<MainState.SecurityNumber; i++){
					//有警衛出勤
					if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace () == 0) {
						Security_Image.sprite = (Sprite)Resources.Load<Sprite> (MainState.Security_Image_String [i]);
						break;
					}
					//沒有警衛出勤
					else {
						Security_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
					}
				}

			  //經理薪水
				for(int i=0; i<=9; i++){
					//出勤中 且 出勤地點為0(麵包師傅)
					if(MainState.Manage[i].GetWork()==true && MainState.Manage[i].GetWorkPlace()==0){
						ManageSalaryTemp = MainState.Manage [i].GetSalary ();
						break;
					}
				}
				MainState.SetText_Pricey (ManageSalaryTemp, ManageSalary_Text); 
			  //警衛薪水
				for(int i=0; i<=9; i++){
					//出勤中 且 出勤地點為0(麵包師傅)
					if(MainState.Security[i].GetWork()==true && MainState.Security[i].GetWorkPlace()==0){
						SecuritySalaryTemp = MainState.Security [i].GetSalary ();
						break;
					}
				}
				MainState.SetText_Pricey (SecuritySalaryTemp, SecuritySalary_Text); 

				//總計
				ManagePaySum = ManageSalaryTemp + SecuritySalaryTemp;
				MainState.SetText_Pricey (ManagePaySum, ManagePaySum_Text); 

				//設定經營區域
				ManageAreaNumber = 0;

				//設定經營按鈕是否可用(持有金錢是否大於經營費用)
				if(ManagePaySum > MainState.OwnMoney) ManageDecision_Accept_Button.interactable = false;
				else ManageDecision_Accept_Button.interactable = true;

				//顯示ManageDecision
				ManageDecisionBackGround.SetActive (true);
			}
			  
			break;

		//音樂人
		case 1:
			//不可經營狀態
			if (!MainState.MusicArea.GetManage ()) {
				//區域名稱
				AreaName_Text.text = "<color=#E4F3E0FF>音樂人區域</color>";
				//預期利潤
				for (int i = 0; i < MainState.MusicStoreNumber; i++) {
					if (MainState.MusicStore [i].GetOwnBool ())
						PriceTemp = PriceTemp + (MainState.MusicStore [i].GetPrice ()*(uint)MainState.MusicStore[i].GetLevel());
				}
				MainState.SetText_Pricey (PriceTemp, Predict_Text);
				//景氣
				Set_NowEconomy_Image(Area);
				Economy_Text.text = MainState.MusicArea.GetEconomyBack ().ToString ("0") + "%";
				//景氣獎勵 = 預期利潤 * (景氣/100.0f)
				EconomyTemp = (uint)((float)PriceTemp * (MainState.MusicArea.GetEconomyBack () / 1000.0f));
				//佔有率獎勵
				OccupancyTemp = (uint)((float)PriceTemp * (MainState.MusicArea.GetPresent () / 1000.0f));
				MainState.SetText_Pricey (OccupancyTemp, OccupancyPresent_Text);
				//總計
				PaySum = PriceTemp + EconomyTemp + OccupancyTemp;
				MainState.SetText_Pricey (PaySum, PaySum_Text); 

				//設定狀態
				MainState.MusicArea.SetManage(true);
				MainState.MusicArea.SetManageTime (0.0f);

				//將已擁有的店鋪設為可投資
				for(int i=0; i<MainState.MusicStoreNumber; i++){
					if (MainState.MusicStore [i].GetOwnBool () == true) MainState.MusicStore [i].SetInvestBool (false);
				}

				//設定新的景氣
				for(int i=0; i<MainState.ManageNumber; i++){
					if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace () == 1) {
						MainState.Music_NowEconomy = (byte)UnityEngine.Random.Range (8 * MainState.Manage [i].GetAbility (), 30 * MainState.Manage [i].GetAbility ());
						MainState.MusicArea.SetEconomyBack (MainState.Music_NowEconomy);
					} else {
						MainState.Music_NowEconomy = (byte)UnityEngine.Random.Range (0, 70);
						MainState.MusicArea.SetEconomyBack (MainState.Music_NowEconomy);
					}
				}

				//設定新的治安
				for(int i=0; i<MainState.SecurityNumber; i++){
					if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace () == 1) {
						MainState.Music_NowSecurity = (byte)UnityEngine.Random.Range (8 * MainState.Security [i].GetAbility (), 20 * MainState.Security [i].GetAbility ());
						MainState.MusicArea.SetSecurityBack (MainState.Music_NowSecurity);
					} else {
						MainState.Music_NowSecurity = (byte)UnityEngine.Random.Range (0, 70);
						MainState.MusicArea.SetSecurityBack (MainState.Music_NowSecurity);
					}
				}

				//顯示PayBack
				PayBackBackGround.SetActive (true);
			}
			//可經營狀態
			else{
				//經理圖片(讀取在Resources資料夾的圖片)
				for(int i=0; i<MainState.ManageNumber; i++){
					//有經理出勤
					if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 1) {
						Manage_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[i]);
						break;
					}
					//沒有經理出勤
					else {
						Manage_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
					}
				}
					
				//區域警衛圖片(讀取在Resources資料夾的圖片)
				for(int i=0; i<MainState.SecurityNumber; i++){
					//有警衛出勤
					if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace () == 1) {
						Security_Image.sprite = (Sprite)Resources.Load<Sprite> (MainState.Security_Image_String [i]);
						break;
					}
					//沒有警衛出勤
					else {
						Security_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
					}
				}
				//經理薪水
				for(int i=0; i<=9; i++){
					//出勤中 且 出勤地點為0(音樂人)
					if(MainState.Manage[i].GetWork()==true && MainState.Manage[i].GetWorkPlace()==1){
						ManageSalaryTemp = MainState.Manage [i].GetSalary ();
						break;
					}
				}
				MainState.SetText_Pricey (ManageSalaryTemp, ManageSalary_Text); 
				//警衛薪水
				for(int i=0; i<=9; i++){
					//出勤中 且 出勤地點為0(音樂人)
					if(MainState.Security[i].GetWork()==true && MainState.Security[i].GetWorkPlace()==1){
						SecuritySalaryTemp = MainState.Security [i].GetSalary ();
						break;
					}
				}
				MainState.SetText_Pricey (SecuritySalaryTemp, SecuritySalary_Text); 

				//總計
				ManagePaySum = ManageSalaryTemp + SecuritySalaryTemp;
				MainState.SetText_Pricey (ManagePaySum, ManagePaySum_Text); 

				//設定經營區域
				ManageAreaNumber = 1;

				//設定經營按鈕是否可用(持有金錢是否大於經營費用)
				if(ManagePaySum > MainState.OwnMoney) ManageDecision_Accept_Button.interactable = false;
				else ManageDecision_Accept_Button.interactable = true;

				//顯示ManageDecision
				ManageDecisionBackGround.SetActive (true);
			}

			break;

		//科技新貴
		case 2:
			//不可經營狀態
			if (!MainState.TehcnologyArea.GetManage ()) {
				//區域名稱
				AreaName_Text.text = "<color=#B9D6FFFF>科技新貴區域</color>";
				//預期利潤
				for (int i = 0; i < MainState.TehcnologyStoreNumber; i++) {
					if (MainState.TehcnologyStore [i].GetOwnBool ())
						PriceTemp = PriceTemp + (MainState.TehcnologyStore [i].GetPrice ()*(uint)MainState.TehcnologyStore[i].GetLevel());
				}
				MainState.SetText_Pricey (PriceTemp, Predict_Text);
				//景氣
				Set_NowEconomy_Image(Area);
				Economy_Text.text = MainState.TehcnologyArea.GetEconomyBack ().ToString ("0") + "%";
				//景氣獎勵 = 預期利潤 * (景氣/100.0f)
				EconomyTemp = (uint)((float)PriceTemp * (MainState.TehcnologyArea.GetEconomyBack () / 1000.0f));
				//佔有率獎勵
				OccupancyTemp = (uint)((float)PriceTemp * (MainState.TehcnologyArea.GetPresent () / 1000.0f));
				MainState.SetText_Pricey (OccupancyTemp, OccupancyPresent_Text);
				//總計
				PaySum = PriceTemp + EconomyTemp + OccupancyTemp;
				MainState.SetText_Pricey (PaySum, PaySum_Text); 

				//設定狀態
				MainState.TehcnologyArea.SetManage(true);
				MainState.TehcnologyArea.SetManageTime (0.0f);

				//將已擁有的店鋪設為可投資
				for(int i=0; i<MainState.TehcnologyStoreNumber; i++){
					if (MainState.TehcnologyStore [i].GetOwnBool () == true) MainState.TehcnologyStore [i].SetInvestBool (false);
				}

				//設定新的景氣
				for(int i=0; i<MainState.ManageNumber; i++){
					if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace () == 2) {
						MainState.Tehcnology_NowEconomy = (byte)UnityEngine.Random.Range (8 * MainState.Manage [i].GetAbility (), 30 * MainState.Manage [i].GetAbility ());
						MainState.TehcnologyArea.SetEconomyBack (MainState.Tehcnology_NowEconomy);
					} else {
						MainState.Tehcnology_NowEconomy = (byte)UnityEngine.Random.Range (0, 70);
						MainState.TehcnologyArea.SetEconomyBack (MainState.Tehcnology_NowEconomy);
					}
				}

				//設定新的治安
				for(int i=0; i<MainState.SecurityNumber; i++){
					if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace () == 2) {
						MainState.Tehcnology_NowSecurity = (byte)UnityEngine.Random.Range (8 * MainState.Security [i].GetAbility (), 20 * MainState.Security [i].GetAbility ());
						MainState.TehcnologyArea.SetSecurityBack (MainState.Tehcnology_NowSecurity);
					} else {
						MainState.Tehcnology_NowSecurity = (byte)UnityEngine.Random.Range (0, 70);
						MainState.TehcnologyArea.SetSecurityBack (MainState.Tehcnology_NowSecurity);
					}
				}

				//顯示PayBack
				PayBackBackGround.SetActive (true);
			}
			//可經營狀態
			else{
				//經理圖片(讀取在Resources資料夾的圖片)
				for(int i=0; i<MainState.ManageNumber; i++){
					//有經理出勤
					if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 2) {
						Manage_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[i]);
						break;
					}
					//沒有經理出勤
					else {
						Manage_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
					}
				}

				//警衛圖片ManagePaySum_Text
				//區域警衛圖片(讀取在Resources資料夾的圖片)
				for(int i=0; i<MainState.SecurityNumber; i++){
					//有警衛出勤
					if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace () == 2) {
						Security_Image.sprite = (Sprite)Resources.Load<Sprite> (MainState.Security_Image_String [i]);
						break;
					}
					//沒有警衛出勤
					else {
						Security_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
					}
				}
				//經理薪水
				for(int i=0; i<=9; i++){
					//出勤中 且 出勤地點為0(科技新貴)
					if(MainState.Manage[i].GetWork()==true && MainState.Manage[i].GetWorkPlace()==2){
						ManageSalaryTemp = MainState.Manage [i].GetSalary ();
						break;
					}
				}
				MainState.SetText_Pricey (ManageSalaryTemp, ManageSalary_Text); 
				//警衛薪水
				for(int i=0; i<=9; i++){
					//出勤中 且 出勤地點為0(科技新貴)
					if(MainState.Security[i].GetWork()==true && MainState.Security[i].GetWorkPlace()==2){
						SecuritySalaryTemp = MainState.Security [i].GetSalary ();
						break;
					}
				}
				MainState.SetText_Pricey (SecuritySalaryTemp, SecuritySalary_Text); 

				//總計
				ManagePaySum = ManageSalaryTemp + SecuritySalaryTemp;
				MainState.SetText_Pricey (ManagePaySum, ManagePaySum_Text); 

				//設定經營區域
				ManageAreaNumber = 2;

				//設定經營按鈕是否可用(持有金錢是否大於經營費用)
				if(ManagePaySum > MainState.OwnMoney) ManageDecision_Accept_Button.interactable = false;
				else ManageDecision_Accept_Button.interactable = true;

				//顯示ManageDecision
				ManageDecisionBackGround.SetActive (true);
			}

			break;

		//機工
		case 3:
			//不可經營狀態
			if (!MainState.FactoryArea.GetManage ()) {
				//區域名稱
				AreaName_Text.text = "<color=#FF9B9BFF>機工區域</color>";
				//預期利潤
				for (int i = 0; i < MainState.FactoryStoreNumber; i++) {
					if (MainState.FactoryStore [i].GetOwnBool ())
						PriceTemp = PriceTemp + (MainState.FactoryStore [i].GetPrice ()*(uint)MainState.FactoryStore[i].GetLevel());
				}
				MainState.SetText_Pricey (PriceTemp, Predict_Text);
				//景氣
				Set_NowEconomy_Image(Area);
				Economy_Text.text = MainState.FactoryArea.GetEconomyBack ().ToString ("0") + "%";
				//景氣獎勵 = 預期利潤 * (景氣/100.0f)
				EconomyTemp = (uint)((float)PriceTemp * (MainState.FactoryArea.GetEconomyBack () / 1000.0f));
				//佔有率獎勵
				OccupancyTemp = (uint)((float)PriceTemp * (MainState.FactoryArea.GetPresent () / 1000.0f));
				MainState.SetText_Pricey (OccupancyTemp, OccupancyPresent_Text);
				//總計
				PaySum = PriceTemp + EconomyTemp + OccupancyTemp;
				MainState.SetText_Pricey (PaySum, PaySum_Text); 

				//設定狀態
				MainState.FactoryArea.SetManage(true);
				MainState.FactoryArea.SetManageTime (0.0f);

				//將已擁有的店鋪設為可投資
				for(int i=0; i<MainState.FactoryStoreNumber; i++){
					if (MainState.FactoryStore [i].GetOwnBool () == true) MainState.FactoryStore [i].SetInvestBool (false);
				}

				//設定新的景氣
				for(int i=0; i<MainState.ManageNumber; i++){
					if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace () == 3) {
						MainState.Factory_NowEconomy = (byte)UnityEngine.Random.Range (8 * MainState.Manage [i].GetAbility (), 30 * MainState.Manage [i].GetAbility ());
						MainState.FactoryArea.SetEconomyBack (MainState.Factory_NowEconomy);
					} else {
						MainState.Factory_NowEconomy = (byte)UnityEngine.Random.Range (0, 70);
						MainState.FactoryArea.SetEconomyBack (MainState.Factory_NowEconomy);
					}
				}

				//設定新的治安
				for(int i=0; i<MainState.SecurityNumber; i++){
					if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace () == 3) {
						MainState.Factory_NowSecurity = (byte)UnityEngine.Random.Range (8 * MainState.Security [i].GetAbility (), 20 * MainState.Security [i].GetAbility ());
						MainState.FactoryArea.SetSecurityBack (MainState.Factory_NowSecurity);
					} else {
						MainState.Factory_NowSecurity = (byte)UnityEngine.Random.Range (0, 70);
						MainState.FactoryArea.SetSecurityBack (MainState.Factory_NowSecurity);
					}
				}

				//顯示PayBack
				PayBackBackGround.SetActive (true);
			}
			//可經營狀態
			else{
				//經理圖片(讀取在Resources資料夾的圖片)
				for(int i=0; i<MainState.ManageNumber; i++){
					//有經理出勤
					if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 3) {
						Manage_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[i]);
						break;
					}
					//沒有經理出勤
					else {
						Manage_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
					}
				}

				//警衛圖片ManagePaySum_Text
				//區域警衛圖片(讀取在Resources資料夾的圖片)
				for(int i=0; i<MainState.SecurityNumber; i++){
					//有警衛出勤
					if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace () == 3) {
						Security_Image.sprite = (Sprite)Resources.Load<Sprite> (MainState.Security_Image_String [i]);
						break;
					}
					//沒有警衛出勤
					else {
						Security_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
					}
				}
				//經理薪水
				for(int i=0; i<=9; i++){
					//出勤中 且 出勤地點為0(機工)
					if(MainState.Manage[i].GetWork()==true && MainState.Manage[i].GetWorkPlace()==3){
						ManageSalaryTemp = MainState.Manage [i].GetSalary ();
						break;
					}
				}
				MainState.SetText_Pricey (ManageSalaryTemp, ManageSalary_Text); 
				//警衛薪水
				for(int i=0; i<=9; i++){
					//出勤中 且 出勤地點為0(機工)
					if(MainState.Security[i].GetWork()==true && MainState.Security[i].GetWorkPlace()==3){
						SecuritySalaryTemp = MainState.Security [i].GetSalary ();
						break;
					}
				}
				MainState.SetText_Pricey (SecuritySalaryTemp, SecuritySalary_Text); 

				//總計
				ManagePaySum = ManageSalaryTemp + SecuritySalaryTemp;
				MainState.SetText_Pricey (ManagePaySum, ManagePaySum_Text); 

				//設定經營區域
				ManageAreaNumber = 3;

				//設定經營按鈕是否可用(持有金錢是否大於經營費用)
				if(ManagePaySum > MainState.OwnMoney) ManageDecision_Accept_Button.interactable = false;
				else ManageDecision_Accept_Button.interactable = true;


				//顯示ManageDecision
				ManageDecisionBackGround.SetActive (true);
			}

			break;

		//銀行家
		case 4:
			//不可經營狀態
			if (!MainState.EconomicArea.GetManage ()) {
				//區域名稱
				AreaName_Text.text = "<color=#FFAAE4FF>銀行家區域</color>";
				//預期利潤
				for (int i = 0; i < MainState.EconomicStoreNumber; i++) {
					if (MainState.EconomicStore [i].GetOwnBool ())
						PriceTemp = PriceTemp + (MainState.EconomicStore [i].GetPrice ()*(uint)MainState.EconomicStore[i].GetLevel());
				}
				MainState.SetText_Pricey (PriceTemp, Predict_Text);
				//景氣
				Set_NowEconomy_Image(Area);
				Economy_Text.text = MainState.EconomicArea.GetEconomyBack ().ToString ("0") + "%";
				//景氣獎勵 = 預期利潤 * (景氣/100.0f)
				EconomyTemp = (uint)((float)PriceTemp * (MainState.EconomicArea.GetEconomyBack () / 1000.0f));
				//佔有率獎勵
				OccupancyTemp = (uint)((float)PriceTemp * (MainState.EconomicArea.GetPresent () / 1000.0f));
				MainState.SetText_Pricey (OccupancyTemp, OccupancyPresent_Text);
				//總計
				PaySum = PriceTemp + EconomyTemp + OccupancyTemp;
				MainState.SetText_Pricey (PaySum, PaySum_Text); 

				//設定狀態
				MainState.EconomicArea.SetManage(true);
				MainState.EconomicArea.SetManageTime (0.0f);

				//將已擁有的店鋪設為可投資
				for(int i=0; i<MainState.EconomicStoreNumber; i++){
					if (MainState.EconomicStore [i].GetOwnBool () == true) MainState.EconomicStore [i].SetInvestBool (false);
				}

				//設定新的景氣
				for(int i=0; i<MainState.ManageNumber; i++){
					if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace () == 4) {
						MainState.Economic_NowEconomy = (byte)UnityEngine.Random.Range (8 * MainState.Manage [i].GetAbility (), 30 * MainState.Manage [i].GetAbility ());
						MainState.EconomicArea.SetEconomyBack (MainState.Economic_NowEconomy);
					} else {
						MainState.Economic_NowEconomy = (byte)UnityEngine.Random.Range (0, 70);
						MainState.EconomicArea.SetEconomyBack (MainState.Economic_NowEconomy);
					}
				}

				//設定新的治安
				for(int i=0; i<MainState.SecurityNumber; i++){
					if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace () == 4) {
						MainState.Economic_NowSecurity = (byte)UnityEngine.Random.Range (8 * MainState.Security [i].GetAbility (), 20 * MainState.Security [i].GetAbility ());
						MainState.EconomicArea.SetSecurityBack (MainState.Economic_NowSecurity);
					} else {
						MainState.Economic_NowSecurity = (byte)UnityEngine.Random.Range (0, 70);
						MainState.EconomicArea.SetSecurityBack (MainState.Economic_NowSecurity);
					}
				}


				//顯示PayBack
				PayBackBackGround.SetActive (true);
			}
			//可經營狀態
			else{
				//經理圖片(讀取在Resources資料夾的圖片)
				for(int i=0; i<MainState.ManageNumber; i++){
					//有經理出勤
					if (MainState.Manage [i].GetWork () == true && MainState.Manage [i].GetWorkPlace() == 4) {
						Manage_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[i]);
						break;
					}
					//沒有經理出勤
					else {
						Manage_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
					}
				}

				//警衛圖片ManagePaySum_Text
				//區域警衛圖片(讀取在Resources資料夾的圖片)
				for(int i=0; i<MainState.SecurityNumber; i++){
					//有警衛出勤
					if (MainState.Security [i].GetWork () == true && MainState.Security [i].GetWorkPlace () == 4) {
						Security_Image.sprite = (Sprite)Resources.Load<Sprite> (MainState.Security_Image_String [i]);
						break;
					}
					//沒有警衛出勤
					else {
						Security_Image.sprite = (Sprite)Resources.Load<Sprite> ("NO_Employee");
					}
				}
				//經理薪水
				for(int i=0; i<=9; i++){
					//出勤中 且 出勤地點為0(銀行家)
					if(MainState.Manage[i].GetWork()==true && MainState.Manage[i].GetWorkPlace()==4){
						ManageSalaryTemp = MainState.Manage [i].GetSalary ();
						break;
					}
				}
				MainState.SetText_Pricey (ManageSalaryTemp, ManageSalary_Text); 
				//警衛薪水
				for(int i=0; i<=9; i++){
					//出勤中 且 出勤地點為0(銀行家)
					if(MainState.Security[i].GetWork()==true && MainState.Security[i].GetWorkPlace()==4){
						SecuritySalaryTemp = MainState.Security [i].GetSalary ();
						break;
					}
				}
				MainState.SetText_Pricey (SecuritySalaryTemp, SecuritySalary_Text); 

				//總計
				ManagePaySum = ManageSalaryTemp + SecuritySalaryTemp;
				MainState.SetText_Pricey (ManagePaySum, ManagePaySum_Text); 

				//設定經營區域
				ManageAreaNumber = 4;

				//設定經營按鈕是否可用(持有金錢是否大於經營費用)
				if(ManagePaySum > MainState.OwnMoney) ManageDecision_Accept_Button.interactable = false;
				else ManageDecision_Accept_Button.interactable = true;

				//顯示ManageDecision
				ManageDecisionBackGround.SetActive (true);
			}

			break;


		}//switch



		//經營按鈕設為不可用(麵包師傅)
		Bread_Button.interactable = false;
		//經營按鈕設為不可用(音樂人)
		Music_Button.interactable = false;
		//經營按鈕設為不可用(科技新貴)
		Tehcnology_Button.interactable = false;
		//經營按鈕設為不可用(機工)
		Factory_Button.interactable = false;
		//經營按鈕設為不可用(銀行家)
		Economic_Button.interactable = false;
		//置產按鈕設為不可用
		BuyStore_Button.interactable = false;
		//徵人按鈕設為不可用
		Hire_Button.interactable = false;
		//店鋪一覽按鈕設為不可用
		Store_Button.interactable = false;
		//人員一覽按鈕設為不可用
		Employee_Button.interactable = false;

		//麵包師傅區域經營按鈕設為不可用
		Bread_Manage_Button.interactable = false;
		//音樂人區域經營按鈕設為不可用
		Music_Manage_Button.interactable = false;
		//科技新貴區域經營按鈕設為不可用
		Tehcnology_Manage_Button.interactable = false;
		//機工區域經營按鈕設為不可用
		Factory_Manage_Button.interactable = false;
		//銀行家區域經營按鈕設為不可用
		Economic_Manage_Button.interactable = false;

		//存檔按鈕設為不可用
		Save_Button.interactable = false;
		//讀檔按鈕設為不可用
		Write_Button.interactable = false;

		//變更狀態為決定畫面
		DecisionBool = true;

	}


	//副程式:PayBack的回收功能
	public void PayBack(){
		//播放獲得金錢音效
		MainState.GetMoney_Button_Sounds_Play();

		//增加持有金錢
		MainState.ADD_OwnMoney (PaySum,OwnMoneyText);
		//隱藏PayBack
		PayBackBackGround.SetActive (false);

		//播放持有金錢變更動畫
		Own_Money_Change_Animation.Play();

		//經營按鈕設為可用(麵包師傅)
		Bread_Button.interactable = true;
		//經營按鈕設為可用(音樂人)
		Music_Button.interactable = true;
		//經營按鈕設為可用(科技新貴)
		Tehcnology_Button.interactable = true;
		//經營按鈕設為可用(機工)
		Factory_Button.interactable = true;
		//經營按鈕設為可用(銀行家)
		Economic_Button.interactable = true;
		//置產按鈕設為可用
		BuyStore_Button.interactable = true;
		//徵人按鈕設為可用
		Hire_Button.interactable = true;
		//店鋪一覽按鈕設為可用
		Store_Button.interactable = true;
		//人員一覽按鈕設為可用
		Employee_Button.interactable = true;

		//麵包師傅區域經營按鈕設為可用
		Bread_Manage_Button.interactable = true;
		//音樂人區域經營按鈕設為可用
		Music_Manage_Button.interactable = true;
		//科技新貴區域經營按鈕設為可用
		Tehcnology_Manage_Button.interactable = true;
		//機工區域經營按鈕設為可用
		Factory_Manage_Button.interactable = true;
		//銀行家區域經營按鈕設為可用
		Economic_Manage_Button.interactable = true;

		//存檔按鈕設為可用
		Save_Button.interactable = true;
		//讀檔按鈕設為可用
		Write_Button.interactable = true;

		//變更狀態為不是決定畫面
		DecisionBool = false;

	}

	//副程式:ManageDecision的決定功能
	public void ManageDecision_Accept(){
		//播放Buy音效
		MainState.Buy_Button_Sounds_Play();

		//扣除持有金錢
		MainState.SUB_OwnMoney (ManagePaySum,OwnMoneyText);

		//播放持有金錢變更動畫
		Own_Money_Change_Animation.Play();

		//設定經營區域狀態
		switch (ManageAreaNumber){
		 //麵包師傅
		 case 0:
			MainState.BreadArea.SetManage (false);
			MainState.BreadArea.SetManageTime (0.0f);
			break;
		//音樂人
		case 1:
			MainState.MusicArea.SetManage (false);
			MainState.MusicArea.SetManageTime (0.0f);
			break;
		//科技新貴
		case 2:
			MainState.TehcnologyArea.SetManage (false);
			MainState.TehcnologyArea.SetManageTime (0.0f);
			break;
		//機工
		case 3:
			MainState.FactoryArea.SetManage (false);
			MainState.FactoryArea.SetManageTime (0.0f);
			break;
		//銀行家
		case 4:
			MainState.EconomicArea.SetManage (false);
			MainState.EconomicArea.SetManageTime (0.0f);
			break;
		}//switch

		//經營按鈕設為可用(麵包師傅)
		Bread_Button.interactable = true;
		//經營按鈕設為可用(音樂人)
		Music_Button.interactable = true;
		//經營按鈕設為可用(科技新貴)
		Tehcnology_Button.interactable = true;
		//經營按鈕設為可用(機工)
		Factory_Button.interactable = true;
		//經營按鈕設為可用(銀行家)
		Economic_Button.interactable = true;
		//置產按鈕設為可用
		BuyStore_Button.interactable = true;
		//徵人按鈕設為可用
		Hire_Button.interactable = true;
		//店鋪一覽按鈕設為可用
		Store_Button.interactable = true;
		//人員一覽按鈕設為可用
		Employee_Button.interactable = true;

		//麵包師傅區域經營按鈕設為可用
		Bread_Manage_Button.interactable = true;
		//音樂人區域經營按鈕設為可用
		Music_Manage_Button.interactable = true;
		//科技新貴區域經營按鈕設為可用
		Tehcnology_Manage_Button.interactable = true;
		//機工區域經營按鈕設為可用
		Factory_Manage_Button.interactable = true;
		//銀行家區域經營按鈕設為可用
		Economic_Manage_Button.interactable = true;

		//存檔按鈕設為可用
		Save_Button.interactable = true;
		//讀檔按鈕設為可用
		Write_Button.interactable = true;

		//變更狀態為不是決定畫面
		DecisionBool = false;

		//隱藏ManageDecisionBackGround
		ManageDecisionBackGround.SetActive (false);
	}

	//副程式:ManageDecision的取消功能
	public void ManageDecision_Cancel(){
		//播放取消按鈕音效
		MainState.Cancel_Button_Sounds_Play();

		//隱藏ManageDecisionBackGround
		ManageDecisionBackGround.SetActive (false);

		//經營按鈕設為可用(麵包師傅)
		Bread_Button.interactable = true;
		//經營按鈕設為可用(音樂人)
		Music_Button.interactable = true;
		//經營按鈕設為可用(科技新貴)
		Tehcnology_Button.interactable = true;
		//經營按鈕設為可用(機工)
		Factory_Button.interactable = true;
		//經營按鈕設為可用(銀行家)
		Economic_Button.interactable = true;
		//置產按鈕設為可用
		BuyStore_Button.interactable = true;
		//徵人按鈕設為可用
		Hire_Button.interactable = true;
		//店鋪一覽按鈕設為可用
		Store_Button.interactable = true;
		//人員一覽按鈕設為可用
		Employee_Button.interactable = true;

		//麵包師傅區域經營按鈕設為可用
		Bread_Manage_Button.interactable = true;
		//音樂人區域經營按鈕設為可用
		Music_Manage_Button.interactable = true;
		//科技新貴區域經營按鈕設為可用
		Tehcnology_Manage_Button.interactable = true;
		//機工區域經營按鈕設為可用
		Factory_Manage_Button.interactable = true;
		//銀行家區域經營按鈕設為可用
		Economic_Manage_Button.interactable = true;

		//存檔按鈕設為可用
		Save_Button.interactable = true;
		//讀檔按鈕設為可用
		Write_Button.interactable = true;

		//變更狀態為不是決定畫面
		DecisionBool = false;
	}

	//副程式:設定景氣圖片
	void Set_NowEconomy_Image(int Area){
		switch (Area) {
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
}
