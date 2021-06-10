//店鋪一覽頁面 UI控制 邏輯運算 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Area : MonoBehaviour {

  //宣告變數====================================================================================================
	//獲得區域數
	int AreaNumber = 0; 
	//店家擁有數
	int StoreNumber = 0;
	//現在選擇區域
	int Manage_Area_Number = 0;
  //宣告UI======================================================================================================
	//GameObject******************************
	//Work頁面
	public GameObject WorkBackGround;
	//Area頁面
	public GameObject AreaBackGround;
	//按鈕************************************
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


	//Text************************************
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

	//店鋪名稱
	public Text[] StoreName = new Text[10];

	//全部區域占有數
	public Text AreaNumber_Text;

	//全部店鋪占有數
	public Text StoreNumber_Text;

	//全部佔有率
	public Text PresentNumber_Text;

	//Image************************************
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

	//店鋪獲得圖片
	public Image[] Get_Image = new Image[10];

	//區域經理圖片
	public Image EconomyPeople_Image;
	//區域警衛圖片
	public Image SecurityPeople_Image;
	//景氣圖片
	public Image NowEconomy_Image;
	//治安圖片
	public Image NowSecurity_Image;

	//區域圖片
	public Image Area_Image;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//設定Text============================================
		//副程式:設定預期利潤Text
		Set_Price_Text();
		//副程式:設定佔有率Text
		Set_Present_Text();
		//副程式:設定店鋪名稱Text
		Set_StoreName_Text();
		//副程式:設定全部區域占有數 店鋪占有數 全部佔有率Text
		Set_ALL_Number_Text();
		//設定圖片============================================
		//副程式:設定佔有率圖片
		Set_Present_Image();
		//副程式:設定區域圖片
		Set_Area_Image ();
		//副程式:設定店鋪已擁有圖片
		Set_Store_Own_Image();
		//副程式:設定區域經理圖片
		Set_Area_Manage_Image ();
		//副程式:設定區域警衛圖片
		Set_Area_Security_Image();
		//副程式:設定景氣圖片
		Set_NowEconomy_Image();
		//副程式:設定治安圖片
		Set_NowSecurity_Image();
	}

	//副程式(按鈕):設定現在選擇區域
	public void Set_Manage_Area_Number(int Area){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		switch (Area) {
		//麵包師傅
		case 0:
			Manage_Area_Number = 0;
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

	//副程式:Work頁面
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
		//隱藏Manage畫面
		AreaBackGround.SetActive(false);
		MainState.AreaBool = false;
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

	//副程式:設定店鋪名稱Text
	void Set_StoreName_Text(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪名稱
			for(int i=0; i<MainState.BreadStoreNumber; i++){
				StoreName [i].text =  MainState.BreadStore[i].GetName() + "";
			}
			break;
			//音樂人
		case 1:
			//店鋪名稱
			for(int i=0; i<MainState.MusicStoreNumber; i++){
				StoreName [i].text =  MainState.MusicStore[i].GetName() + "";
			}
			break;
			//科技新貴
		case 2:
			//店鋪名稱
			for(int i=0; i<MainState.TehcnologyStoreNumber; i++){
				StoreName [i].text =  MainState.TehcnologyStore[i].GetName() + "";
			}
			break;
			//機工
		case 3:
			//店鋪名稱
			for(int i=0; i<MainState.FactoryStoreNumber; i++){
				StoreName [i].text =  MainState.FactoryStore[i].GetName() + "";
			}
			break;
			//銀行家
		case 4:
			//店鋪名稱
			for(int i=0; i<MainState.EconomicStoreNumber; i++){
				StoreName [i].text =  MainState.EconomicStore[i].GetName() + "";
			}
			break;

		}//switch
		
	}

	//副程式:設定全部區域占有數 店鋪占有數 全部佔有率Text
	void Set_ALL_Number_Text(){
		//數字暫存
		int Temp = 0;

		//全部區域占有數
		if(MainState.BreadArea.GetPresent()==100.0f) Temp = Temp + 1 ;
		if(MainState.MusicArea.GetPresent()==100.0f) Temp = Temp + 1 ;
		if(MainState.TehcnologyArea.GetPresent()==100.0f) Temp = Temp + 1 ;
		if(MainState.FactoryArea.GetPresent()==100.0f) Temp = Temp + 1 ;
		if(MainState.EconomicArea.GetPresent()==100.0f) Temp = Temp + 1 ;


		AreaNumber_Text.text = Temp + " / 5";
		//如果擁有全部區域
		if (Temp == 5) AreaNumber_Text.text = "<color=#41907EFF>5 / 5</color>";
		Temp = 0;

		//全部店鋪占有數
		for(int i=0; i<MainState.BreadStoreNumber; i++){
			if (MainState.BreadStore [i].GetOwnBool () == true)
				Temp = Temp + 1;
		}
		for(int i=0; i<MainState.MusicStoreNumber; i++){
			if (MainState.MusicStore [i].GetOwnBool () == true)
				Temp = Temp + 1;
		}
		for(int i=0; i<MainState.TehcnologyStoreNumber; i++){
			if (MainState.TehcnologyStore [i].GetOwnBool () == true)
				Temp = Temp + 1;
		}
		for(int i=0; i<MainState.FactoryStoreNumber; i++){
			if (MainState.FactoryStore [i].GetOwnBool () == true)
				Temp = Temp + 1;
		}
		for(int i=0; i<MainState.EconomicStoreNumber; i++){
			if (MainState.EconomicStore [i].GetOwnBool () == true)
				Temp = Temp + 1;
		}

		StoreNumber_Text.text = Temp + " / 50";
		//如果擁有全部店鋪
		if (Temp == 50) StoreNumber_Text.text = "<color=#41907EFF>50 / 50</color>";
		Temp = 0;

		//全部佔有率
		PresentNumber_Text.text = ((MainState.BreadArea.GetPresent() + MainState.MusicArea.GetPresent() + MainState.TehcnologyArea.GetPresent() + MainState.FactoryArea.GetPresent() + MainState.EconomicArea.GetPresent())/500.0f)*100.0f + " %";
		//如果全部佔有率為100%
		if(((MainState.BreadArea.GetPresent() + MainState.MusicArea.GetPresent() + MainState.TehcnologyArea.GetPresent() + MainState.FactoryArea.GetPresent() + MainState.EconomicArea.GetPresent())/500.0f)*100.0f == 100.0f)
			PresentNumber_Text.text =  "<color=#41907EFF>100 %</color>";
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
				Area_Image.sprite = (Sprite)Resources.Load<Sprite>("Bread_Place");
				break;
				//音樂人
			case 1:
				//區域圖片(讀取在Resources資料夾的圖片)
			Area_Image.sprite = (Sprite)Resources.Load<Sprite>("Music_Place");
				break;
				//科技新貴
			case 2:
				//區域圖片(讀取在Resources資料夾的圖片)
			Area_Image.sprite = (Sprite)Resources.Load<Sprite>("Technology_Place");
				break;
				//機工
			case 3:
				//區域圖片(讀取在Resources資料夾的圖片)
			Area_Image.sprite = (Sprite)Resources.Load<Sprite>("Factory_Place");
				break;
				//銀行家
			case 4:
				//區域圖片(讀取在Resources資料夾的圖片)
			Area_Image.sprite = (Sprite)Resources.Load<Sprite>("Economic_Place");
				break;

			}//switch
		}


	//副程式:設定店鋪已擁有圖片
	void Set_Store_Own_Image(){
		switch (Manage_Area_Number) {
		//麵包師傅
		case 0:
			//店鋪已擁有(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.BreadStoreNumber; i++){
				if (MainState.BreadStore [i].GetOwnBool () == true)
					Get_Image [i].color = new Color (255.0f,255.0f,255.0f,255.0f);
				else
					Get_Image [i].color = new Color (255.0f,255.0f,255.0f,0.0f);
			}
			break;
			//音樂人
		case 1:
			//店鋪已擁有(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.MusicStoreNumber; i++){
				if (MainState.MusicStore [i].GetOwnBool () == true)
					Get_Image [i].color = new Color (255.0f,255.0f,255.0f,255.0f);
				else
					Get_Image [i].color = new Color (255.0f,255.0f,255.0f,0.0f);
			}
			break;
			//科技新貴
		case 2:
			//店鋪已擁有(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.TehcnologyStoreNumber; i++){
				if (MainState.TehcnologyStore [i].GetOwnBool () == true)
					Get_Image [i].color = new Color (255.0f,255.0f,255.0f,255.0f);
				else
					Get_Image [i].color = new Color (255.0f,255.0f,255.0f,0.0f);
			}
			break;
			//機工
		case 3:
			//店鋪已擁有(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.FactoryStoreNumber; i++){
				if (MainState.FactoryStore [i].GetOwnBool () == true)
					Get_Image [i].color = new Color (255.0f,255.0f,255.0f,255.0f);
				else
					Get_Image [i].color = new Color (255.0f,255.0f,255.0f,0.0f);
			}
			break;
			//銀行家
		case 4:
			//店鋪已擁有(讀取在Resources資料夾的圖片)
			for(int i=0; i<MainState.EconomicStoreNumber; i++){
				if (MainState.EconomicStore [i].GetOwnBool () == true)
					Get_Image [i].color = new Color (255.0f,255.0f,255.0f,255.0f);
				else
					Get_Image [i].color = new Color (255.0f,255.0f,255.0f,0.0f);
			}
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


}
