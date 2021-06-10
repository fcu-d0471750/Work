//徵人頁面 UI控制 邏輯運算 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hire : MonoBehaviour {

  //宣告變數============================================================================
	//持有金錢暫存
	ulong OwnMoneyTemp;

	//經理現在選擇編號
	int Now_Select_Manage_Number = 0;
	//警衛現在選擇編號
	int Now_Select_Security_Number = 0;
	//顧問現在選擇編號
	int Now_Select_Consultant_Number = 0;
	//現在頁面編號
	int Now_Number = 1;

	//是否為決定畫面 true:是 fasle:不是
	bool DecisionBool = false;

  //宣告UI==============================================================================
	//GameObject************************************
	//Work畫面
	public GameObject WorkBackGround;
	//Hire畫面
	public GameObject HireBackGround;
	//決定畫面
	public GameObject Decision;
	//經理警衛畫面
	public GameObject EconomyBackGround;
	//顧問畫面
	public GameObject ConsultantBackGround;

	//按鈕************************************
	//經理按鈕
	public Button ManageButton;
	//警衛按鈕
	public Button SecurityButton;
	//顧問按鈕
	public Button ConsultantButton;

	//上一位按鈕
	public Button PreviousButton;
	//下一位按鈕
	public Button NextButton;

	//離開按鈕
	public Button ExitButton;
	//僱用按鈕
	public Button HireButton;

	//Text**************************************
	//頁面
	public Text Title_Text;

	//名稱
	public Text Name_Text;
	//能力Title
	public Text ManageNumber_Title_Text;
	//經營能力
	public Text ManageNumber_Text;
	//經理 警衛薪水
	public Text Manage_Security_Salary_Text;
	//顧問薪水
	public Text Consultant_Salary_Text;
	//經理 警衛僱用薪水
	public Text Manage_Security_HireSalary_Text;
	//顧問僱用薪水
	public Text Consultant_HireSalary_Text;
	//自我介紹
	public Text Introduce_Text;
	//持有金錢
	public Text OwnMoney_Text;

	//顧問支援能力
	public Text AdvantageNumber1_Text;
	public Text AdvantageNumber2_Text;
	public Text AdvantageNumber3_Text;
	public Text AdvantageNumber4_Text;
	public Text AdvantageNumber5_Text;

	//Image*************************************
	//人員圖片
	public Image PeopleImage;
	//雇用圖片
	public Image Hire_Image;
	//未雇用圖片
	public Image UnHire_Image;
	//能力階級圖片
	public Image ManageNumber_Image;

	//宣告動畫============================================================
	//持有金錢變化動畫
	public Animation Own_Money_Change_Animation;

	// Use this for initialization
	void Start () {
		//經理頁面按鈕設為不能用
		ManageButton.interactable = false;
		//警衛頁面按鈕設為能用
		SecurityButton.interactable = true;
		//顧問頁面按鈕設為能用
		ConsultantButton.interactable = true;
		//初始設定為經理
		Set_Now_Number(1);
	}
	// Update is called once per frame
	void Update () {
		//副程式:設定僱用按鈕是否可用
		if(!DecisionBool)Set_Hire_Button();

		//設定Text*****************************************************
		//持有金錢
		MainState.SetText_OwnMoney(OwnMoney_Text);
		//副程式:用人員按鈕設定經理 警衛 顧問Text
		Set_Manage_Security_Consultant_Text();

		//設定圖片*****************************************************
		//副程式:用人員按鈕設定經理 警衛 顧問是否僱用圖片
		Set_Manage_Security_Consultant_Hire_Image();
	}

	//副程式(按鈕):開啟決定畫面
	public void Set_Decision(){
		//播放PayBack音效
		MainState.PayBack_Button_Sounds_Play();

		//顯示決定畫面
		Decision.SetActive(true);
		//經理頁面按鈕設為不能用
		ManageButton.interactable = false;
		//警衛頁面按鈕設為不能用
		SecurityButton.interactable = false;
		//顧問頁面按鈕設為不能用
		ConsultantButton.interactable = false;
		//離開按鈕設為不能用
		ExitButton.interactable = false;
		//僱用按鈕設為不能用
		HireButton.interactable = false;
		//變更狀態為決定畫面
		DecisionBool = true;
		//向上按鈕設為不能用
		PreviousButton.interactable = false;
		//向下按鈕設為不能用
		NextButton.interactable = false;
	}

	//副程式(按鈕):Work頁面
	public void WorkPage(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		//顯示Work畫面
		WorkBackGround.SetActive(true);
		MainState.WorkBool = true;
		//播放WorkPage進入動畫
		AnimationIN.WorkPage_IN_Bool();
		//隱藏HireBackGround畫面
		HireBackGround.SetActive(false);
		MainState.PeopleBool = false;
	}

	//副程式(按鈕):決定畫面僱用
	public void Set_Decision_Accept(){
		//播放Buy音效
		MainState.Buy_Button_Sounds_Play();

		//播放持有金錢變更動畫
		Own_Money_Change_Animation.Play();

		switch (Now_Number) {
		//經理
		case 1:
			//扣除持有金錢
			MainState.SUB_OwnMoney(MainState.Manage[Now_Select_Manage_Number].GetHireSalary() , OwnMoney_Text);
			//設為僱用中
			MainState.Manage[Now_Select_Manage_Number].SetHire(true);
			break;
		//警衛
		case 2:
			//扣除持有金錢
			MainState.SUB_OwnMoney(MainState.Security[Now_Select_Security_Number].GetHireSalary() , OwnMoney_Text);
			//設為僱用中
			MainState.Security[Now_Select_Security_Number].SetHire(true);
			break;
		//顧問
		case 3:
			//扣除持有金錢
			MainState.SUB_OwnMoney(MainState.Consultant[Now_Select_Consultant_Number].GetHireSalary() , OwnMoney_Text);
			//設為僱用中
			MainState.Consultant[Now_Select_Consultant_Number].SetHire(true);
			break;
		}//switch

		//隱藏決定畫面
		Decision.SetActive(false);
		//經理頁面按鈕設為能用
		ManageButton.interactable = true;
		//警衛頁面按鈕設為能用
		SecurityButton.interactable = true;
		//顧問頁面按鈕設為能用
		ConsultantButton.interactable = true;
		//離開按鈕設為能用
		ExitButton.interactable = true;
		//僱用按鈕設為能用
		HireButton.interactable = true;
		//變更狀態為不是決定畫面
		DecisionBool = false;
		//向上按鈕設為能用
		PreviousButton.interactable = true;
		//向下按鈕設為能用
		NextButton.interactable = true;
		//設定頁面按鈕
		Set_Now_Number(Now_Number);
	}

	//副程式(按鈕):決定畫面取消
	public void Set_Decision_Cancel(){
		//播放取消按鈕音效
		MainState.Cancel_Button_Sounds_Play();

		//隱藏決定畫面
		Decision.SetActive(false);
		//經理頁面按鈕設為能用
		ManageButton.interactable = true;
		//警衛頁面按鈕設為能用
		SecurityButton.interactable = true;
		//顧問頁面按鈕設為能用
		ConsultantButton.interactable = true;
		//離開按鈕設為能用
		ExitButton.interactable = true;
		//僱用按鈕設為能用
		HireButton.interactable = true;
		//變更狀態為不是決定畫面
		DecisionBool = false;
		//向上按鈕設為能用
		PreviousButton.interactable = true;
		//向下按鈕設為能用
		NextButton.interactable = true;
		//設定頁面按鈕
		Set_Now_Number(Now_Number);
	}

	//副程式(按鈕):上一位 或 下一位
	public void Set_Manage_Security_Consultant_Number(int UP_Down){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		switch (Now_Number) {
		//1:經理 
		case 1:
			switch(UP_Down){
			//上一位
			case 0:
				//現在是第一位 則 回到最後一位
				if (Now_Select_Manage_Number == 0)
					Now_Select_Manage_Number = MainState.ManageNumber - 1;
				//其它 則 現在選擇編號-1
				else {
					Now_Select_Manage_Number = Now_Select_Manage_Number - 1;
				}
				break;
				//下一位
			case 1:
				//現在是最後一位 則 回到第一位
				if (Now_Select_Manage_Number == MainState.ManageNumber - 1)
					Now_Select_Manage_Number = 0;
				//其它 則 現在選擇編號+1
				else {
					Now_Select_Manage_Number = Now_Select_Manage_Number + 1;
				}
				break;
			}//switch
			break;
			//2:警衛
		case 2:
			switch(UP_Down){
			//上一位
			case 0:
				//現在是第一位 則 回到最後一位
				if (Now_Select_Security_Number == 0)
					Now_Select_Security_Number = MainState.SecurityNumber - 1;
				//其它 則 現在選擇編號-1
				else {
					Now_Select_Security_Number = Now_Select_Security_Number - 1;
				}
				break;
				//下一位
			case 1:
				//現在是最後一位 則 回到第一位
				if (Now_Select_Security_Number == MainState.SecurityNumber - 1)
					Now_Select_Security_Number = 0;
				//其它 則 現在選擇編號+1
				else {
					Now_Select_Security_Number = Now_Select_Security_Number + 1;
				}
				break;
			}//switch
			break;
			//3:顧問
		case 3:
			switch(UP_Down){
			//上一位
			case 0:
				//現在是第一位 則 回到最後一位
				if (Now_Select_Consultant_Number == 0)
					Now_Select_Consultant_Number = MainState.ConsultantNumber - 1;
				//其它 則 現在選擇編號-1
				else {
					Now_Select_Consultant_Number = Now_Select_Consultant_Number - 1;
				}
				break;
				//下一位
			case 1:
				//現在是最後一位 則 回到第一位
				if (Now_Select_Consultant_Number == MainState.ConsultantNumber - 1)
					Now_Select_Consultant_Number = 0;
				//其它 則 現在選擇編號+1
				else {
					Now_Select_Consultant_Number = Now_Select_Consultant_Number + 1;
				}
				break;
			}//switch
			break;
		}//switch

		//副程式:設定僱用按鈕是否可用
		Set_Hire_Button();
	}

	//副程式(按鈕):切換頁面 1:經理 2:警衛 3:顧問
	public void Set_Now_Number(int Number){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

		switch (Number) {
		//1:經理 
		case 1:
			Now_Number = 1;
			Title_Text.text = "經理";
			ManageNumber_Title_Text.text = "經營能力";
			//顯示經理警衛頁面
			EconomyBackGround.SetActive(true);
			//隱藏顧問頁面
			ConsultantBackGround.SetActive(false);
			//經理頁面按鈕設為不能用
			ManageButton.interactable = false;
			//警衛頁面按鈕設為能用
			SecurityButton.interactable = true;
			//顧問頁面按鈕設為能用
			ConsultantButton.interactable = true;
			break;
		//2:警衛
		case 2:
			Now_Number = 2;
			Title_Text.text = "<color=#B5ECFFFF>警衛</color>";
			ManageNumber_Title_Text.text = "處理能力";
			//顯示經理警衛頁面
			EconomyBackGround.SetActive(true);
			//隱藏顧問頁面
			ConsultantBackGround.SetActive(false);
			//經理頁面按鈕設為能用
			ManageButton.interactable = true;
			//警衛頁面按鈕設為不能用
			SecurityButton.interactable = false;
			//顧問頁面按鈕設為能用
			ConsultantButton.interactable = true;
			break;
		//3:顧問
		case 3:
			Now_Number = 3;
			Title_Text.text = "<color=#FF9F9FFF>顧問</color>";
			ManageNumber_Title_Text.text = "能力階級";
			//隱藏經理警衛頁面
			EconomyBackGround.SetActive(false);
			//顯示顧問頁面
			ConsultantBackGround.SetActive(true);
			//經理頁面按鈕設為能用
			ManageButton.interactable = true;
			//警衛頁面按鈕設為能用
			SecurityButton.interactable = true;
			//顧問頁面按鈕設為不能用
			ConsultantButton.interactable = false;
			break;

		}//switch
	}

	//副程式:用人員按鈕設定經理 警衛 顧問Text
	void Set_Manage_Security_Consultant_Text(){
		switch(Now_Number){
		case 1:
		//經理名稱
			Name_Text.text = MainState.Manage [Now_Select_Manage_Number].GetName () + "";

		//經理能力階級
			ManageNumber_Text.text = MainState.Manage [Now_Select_Manage_Number].GetAbility () + "";

		//經理薪水
			MainState.SetText_Pricey (MainState.Manage [Now_Select_Manage_Number].GetSalary (), Manage_Security_Salary_Text);

		//經理僱用薪水
			MainState.SetText_Pricey (MainState.Manage [Now_Select_Manage_Number].GetHireSalary(), Manage_Security_HireSalary_Text);

		//經理自我介紹
			Introduce_Text.text = MainState.Manage [Now_Select_Manage_Number].GetIntroduce () + "";

		//經理圖片
			PeopleImage.sprite = (Sprite)Resources.Load<Sprite> (MainState.Manage_Image_String [Now_Select_Manage_Number]);

		//經理能力階級圖片
			ManageNumber_Image.fillAmount = MainState.Manage [Now_Select_Manage_Number].GetAbility () / 5.0f;
			break;
		
		case 2:
		//警衛名稱
			Name_Text.text = MainState.Security [Now_Select_Security_Number].GetName () + "";

		//警衛能力階級
			ManageNumber_Text.text = MainState.Security [Now_Select_Security_Number].GetAbility () + "";

		//警衛薪水
			MainState.SetText_Pricey (MainState.Security [Now_Select_Security_Number].GetSalary (), Manage_Security_Salary_Text);

		//警衛僱用薪水
			MainState.SetText_Pricey (MainState.Security [Now_Select_Security_Number].GetHireSalary(), Manage_Security_HireSalary_Text);

		//警衛自我介紹
			Introduce_Text.text = MainState.Security [Now_Select_Security_Number].GetIntroduce () + "";

		//警衛圖片
			PeopleImage.sprite = (Sprite)Resources.Load<Sprite> (MainState.Security_Image_String [Now_Select_Security_Number]);

		//警衛能力階級圖片
			ManageNumber_Image.fillAmount = MainState.Security [Now_Select_Security_Number].GetAbility () / 5.0f;
			break;

		case 3:
		//顧問名稱
			Name_Text.text = MainState.Consultant [Now_Select_Consultant_Number].GetName () + "";

		//顧問能力階級
			ManageNumber_Text.text = MainState.Consultant [Now_Select_Consultant_Number].GetAbility () + "";
		//顧問能力階級圖片
			ManageNumber_Image.fillAmount = MainState.Consultant [Now_Select_Consultant_Number].GetAbility () / 5.0f;

		//支援能力
			MainState.Consultant_Advantage (MainState.Consultant [Now_Select_Consultant_Number].GetFoodNumber (), AdvantageNumber1_Text);
			MainState.Consultant_Advantage (MainState.Consultant [Now_Select_Consultant_Number].GetMusicNumber (), AdvantageNumber2_Text);
			MainState.Consultant_Advantage (MainState.Consultant [Now_Select_Consultant_Number].GetTechnologyNumber (), AdvantageNumber3_Text);
			MainState.Consultant_Advantage (MainState.Consultant [Now_Select_Consultant_Number].GetFactoryNumber (), AdvantageNumber4_Text);
			MainState.Consultant_Advantage (MainState.Consultant [Now_Select_Consultant_Number].GetEconomicNumber (), AdvantageNumber5_Text);

		//顧問薪水
			MainState.SetText_Pricey (MainState.Consultant [Now_Select_Consultant_Number].GetSalary (), Consultant_Salary_Text);

		//顧問僱用薪水
			MainState.SetText_Pricey (MainState.Consultant [Now_Select_Consultant_Number].GetHireSalary(), Consultant_HireSalary_Text);

		//顧問自我介紹
			Introduce_Text.text = MainState.Consultant [Now_Select_Consultant_Number].GetIntroduce () + "";

		//顧問圖片
			PeopleImage.sprite = (Sprite)Resources.Load<Sprite> (MainState.Consultant_Image_String [Now_Select_Consultant_Number]);
			break;
		}//switch

	}

	//副程式:用人員按鈕設定經理 警衛 顧問是否僱用圖片
	void Set_Manage_Security_Consultant_Hire_Image(){
		switch (Now_Number) {
		case 1:
		//經理僱用圖片
		//僱用中
			if (MainState.Manage [Now_Select_Manage_Number].GetHire () == true) {
				//顯示僱用圖片
				Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
				//隱藏未僱用圖片
				UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			}
		//未僱用
		else {
				//隱藏僱用圖片
				Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				//顯示未僱用圖片
				UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
			}
			break;
		//警衛僱用圖片
		case 2:
		//僱用中
			if (MainState.Security [Now_Select_Security_Number].GetHire () == true) {
				//顯示僱用圖片
				Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
				//隱藏未僱用圖片
				UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			}
		//未僱用
		else {
				//隱藏僱用圖片
				Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				//顯示未僱用圖片
				UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
			}
			break;
		//顧問僱用圖片
		case 3:
		//僱用中
			if (MainState.Consultant [Now_Select_Consultant_Number].GetHire () == true) {
				//顯示僱用圖片
				Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
				//隱藏未僱用圖片
				UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			}
		//未僱用
		else {
				//隱藏僱用圖片
				Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
				//顯示未僱用圖片
				UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
			}
			break;
		}//switch
	}

	//副程式:設定僱用按鈕是否可用
	void Set_Hire_Button(){
		switch (Now_Number) {
		//經理
		case 1:
			//如果已僱用 或是 持有金錢 < 僱用薪水 則僱用按鈕設為不可用
			if (MainState.Manage [Now_Select_Manage_Number].GetHire () == true || MainState.OwnMoney < MainState.Manage [Now_Select_Manage_Number].GetHireSalary ())
				HireButton.interactable = false;
			else
				HireButton.interactable = true;
			break;
		//警衛
		case 2:
			//如果已僱用 或是 持有金錢 < 僱用薪水 則僱用按鈕設為不可用
			if (MainState.Security [Now_Select_Security_Number].GetHire () == true || MainState.OwnMoney < MainState.Security [Now_Select_Security_Number].GetHireSalary ())
				HireButton.interactable = false;
			else
				HireButton.interactable = true;
			break;
		//顧問
		case 3:
			//如果已僱用 或是 持有金錢 < 僱用薪水 則僱用按鈕設為不可用
			if (MainState.Consultant [Now_Select_Consultant_Number].GetHire () == true || MainState.OwnMoney < MainState.Consultant [Now_Select_Consultant_Number].GetHireSalary ())
				HireButton.interactable = false;
			else
				HireButton.interactable = true;
			break;
		}//switch
	}


}
