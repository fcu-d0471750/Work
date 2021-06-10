//人員一覽頁面 UI控制 邏輯運算 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class People : MonoBehaviour {
  
  //宣告變數===============================================================================
	//經理現在選擇編號
	int Now_Select_Manage_Number = 0;
	//警衛現在選擇編號
	int Now_Select_Security_Number = 0;
	//顧問現在選擇編號
	int Now_Select_Consultant_Number = 0;
  //宣告UI=================================================================================
	//GameObject**************************************************
	//Work畫面
	public GameObject WorkBackGround;
	//People畫面
	public GameObject PeopleBackGround;
	//Text*********************************************
	//經理名稱
	public Text ManageName_Text;
	//警衛名稱
	public Text SecurityName_Text;
	//顧問名稱
	public Text ConsultantName_Text;

	//經營能力(經理)
	public Text ManageNumber_Text;
	//經營能力(警衛)
	public Text SecurityNumber_Text;
	//經營能力(顧問)
	public Text ConsultantNumber_Text;

	//薪水(經理)
	public Text ManageSalary_Text;
	//薪水(警衛)
	public Text SecuritySalary_Text;
	//薪水(顧問)
	public Text ConsultantSalary_Text;

	//自我介紹(經理)
	public Text ManageIntroduce_Text;
	//自我介紹(警衛)
	public Text SecurityIntroduce_Text;
	//自我介紹(顧問)
	public Text ConsultantIntroduce_Text;

	//顧問支援能力
	public Text AdvantageNumber1_Text;
	public Text AdvantageNumber2_Text;
	public Text AdvantageNumber3_Text;
	public Text AdvantageNumber4_Text;
	public Text AdvantageNumber5_Text;

	//Image********************************************
	//經理圖片
	public Image Manage_Image;
	//警衛圖片
	public Image Security_Image;
	//顧問圖片
	public Image Consultant_Image;

	//雇用圖片(經理)
	public Image Manage_Hire_Image;
	//未雇用圖片(經理)
	public Image Manage_UnHire_Image;
	//雇用圖片(警衛)
	public Image Security_Hire_Image;
	//未雇用圖片(警衛)
	public Image Security_UnHire_Image;
	//雇用圖片(顧問)
	public Image Consultant_Hire_Image;
	//未雇用圖片(顧問)
	public Image Consultant_UnHire_Image;

	//出勤中圖片(經理)
	public Image Manage_Work_Image;
	//出勤中圖片(警衛)
	public Image Security_Work_Image;

	//經理能力階級圖片
	public Image ManageNumber_Image;
	//警衛能力階級圖片
	public Image SecurityManageNumber_Image;
	//顧問能力階級圖片
	public Image ConsultantManageNumber_Image;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//設定Text=============================================
		//副程式:用人員按鈕設定經理 警衛 顧問Text
		Set_Manage_Security_Consultant_Text();

		//設定圖片=============================================
		//副程式:用人員按鈕設定經理 警衛 出勤圖片
		Set_Manage_Security_Consultant_Work_Image();
		//副程式:用人員按鈕設定經理 警衛 顧問是否僱用圖片
		Set_Manage_Security_Consultant_Hire_Image();
	}

	//副程式:Work頁面
	public void WorkPage(){
		//播放按鈕音效
		MainState.Button_Sounds_Play();
		//顯示Work畫面
		WorkBackGround.SetActive(true);
		MainState.WorkBool = true;
		//播放WorkPage進入動畫
		AnimationIN.WorkPage_IN_Bool();
		//隱藏Manage畫面
		PeopleBackGround.SetActive(false);
		MainState.PeopleBool = false;
	}


	//副程式:設定經理現在選擇編號(int 上一位或下一位)
	public void Set_Now_Select_Manage_Number(int UP_Down){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

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
	}


	//副程式:警衛現在選擇編號(int 上一位或下一位)
	public void Set_Now_Select_Security_Number(int UP_Down){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

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
	}
	//副程式:顧問現在選擇編號(int 上一位或下一位)
	public void Set_Now_Select_Consultant_Number(int UP_Down){
		//播放按鈕音效
		MainState.Button_Sounds_Play();

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
	}

	//副程式:用人員按鈕設定經理 警衛 顧問Text
	void Set_Manage_Security_Consultant_Text(){

		//經理名稱
		ManageName_Text.text = MainState.Manage [Now_Select_Manage_Number].GetName () + "";

		//經理能力階級
		ManageNumber_Text.text = MainState.Manage[Now_Select_Manage_Number].GetAbility() + "";

		//經理薪水
		MainState.SetText_Pricey(MainState.Manage[Now_Select_Manage_Number].GetSalary() , ManageSalary_Text);

		//經理自我介紹
		ManageIntroduce_Text.text = MainState.Manage[Now_Select_Manage_Number].GetIntroduce() + "";

		//經理圖片
		Manage_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Manage_Image_String[Now_Select_Manage_Number]);

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
		Security_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Security_Image_String[Now_Select_Security_Number]);

		//警衛能力階級圖片
		SecurityManageNumber_Image.fillAmount = MainState.Security[Now_Select_Security_Number].GetAbility() / 5.0f;

		//顧問名稱
		ConsultantName_Text.text = MainState.Consultant [Now_Select_Consultant_Number].GetName () + "";

		//顧問能力階級
		ConsultantNumber_Text.text = MainState.Consultant[Now_Select_Consultant_Number].GetAbility() + "";

		//顧問能力階級圖片
		ConsultantManageNumber_Image.fillAmount = MainState.Consultant[Now_Select_Consultant_Number].GetAbility() / 5.0f;

		//顧問自我介紹
		ConsultantIntroduce_Text.text = MainState.Consultant[Now_Select_Consultant_Number].GetIntroduce() + "";

		//支援能力
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetFoodNumber() , AdvantageNumber1_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetMusicNumber() , AdvantageNumber2_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetTechnologyNumber() , AdvantageNumber3_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetFactoryNumber() , AdvantageNumber4_Text);
		MainState.Consultant_Advantage(MainState.Consultant[Now_Select_Consultant_Number].GetEconomicNumber() , AdvantageNumber5_Text);

		//薪水
		MainState.SetText_Pricey(MainState.Consultant[Now_Select_Consultant_Number].GetSalary() , ConsultantSalary_Text);

		//顧問圖片
		Consultant_Image.sprite = (Sprite)Resources.Load<Sprite>(MainState.Consultant_Image_String[Now_Select_Consultant_Number]);

	}

	//副程式:用人員按鈕設定經理 警衛 出勤圖片
	void Set_Manage_Security_Consultant_Work_Image(){
		//經理出勤圖片
		//出勤中
		if (MainState.Manage [Now_Select_Manage_Number].GetWork () == true) {
			//顯示出勤圖片
			Manage_Work_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
		}
		//未出勤
		else {
			//隱藏出勤圖片
			Manage_Work_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		}

		//警衛出勤圖片
		//出勤中
		if (MainState.Security [Now_Select_Security_Number].GetWork () == true) {
			//顯示出勤圖片
			Security_Work_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
		}
		//未出勤
		else {
			//隱藏出勤圖片
			Security_Work_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		}
	}

	//副程式:用人員按鈕設定經理 警衛 顧問是否僱用圖片
	void Set_Manage_Security_Consultant_Hire_Image(){
		//經理僱用圖片
		//僱用中
		if (MainState.Manage [Now_Select_Manage_Number].GetHire () == true) {
			//顯示僱用圖片
			Manage_Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
			//隱藏未僱用圖片
			Manage_UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		}
		//未僱用
		else {
			//隱藏僱用圖片
			Manage_Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			//顯示未僱用圖片
			Manage_UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
		}

		//警衛僱用圖片
		//僱用中
		if (MainState.Security [Now_Select_Security_Number].GetHire () == true) {
			//顯示僱用圖片
			Security_Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
			//隱藏未僱用圖片
			Security_UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		}
		//未僱用
		else {
			//隱藏僱用圖片
			Security_Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			//顯示未僱用圖片
			Security_UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
		}

		//顧問僱用圖片
		//僱用中
		if (MainState.Consultant [Now_Select_Consultant_Number].GetHire () == true) {
			//顯示僱用圖片
			Consultant_Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
			//隱藏未僱用圖片
			Consultant_UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
		}
		//未僱用
		else {
			//隱藏僱用圖片
			Consultant_Hire_Image.color = new Color (255.0f, 255.0f, 255.0f, 0.0f);
			//顯示未僱用圖片
			Consultant_UnHire_Image.color = new Color (255.0f, 255.0f, 255.0f, 255.0f);
		}
	}



}
