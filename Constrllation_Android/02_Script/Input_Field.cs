//使用者輸入 誕生年月日
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Input_Field : MonoBehaviour {

    //============================================
    //宣告變數***************************************************
    //============================================
    //bool==============================================
    //是否輸入年 true:有 fasle:沒有
    bool Year_Input_Bool = false;
	//是否輸入月 true:有 fasle:沒有
	bool Month_Input_Bool = false;
	//是否輸入日 true:有 fasle:沒有
	bool Day_Input_Bool = false;
	//告知Home_Page要修改資訊 true:修改資訊 false:不修改資訊
	public static bool Input_Home_Page = false;

	//數字============================================
	//輸入年(預設:1900)
	public static int Year = 1900;
	//輸入月(預設:01)
	public static int Month = 1;
	//輸入日(預設:01)
	public static int Day = 1;
	//輸入日的最大值
	int Day_Max = 0;
	//暫存年，用於計算日的最大值並防止修改到原本的年
	int Year_Temp = 0;
	//暫存月，用於計算日的最大值並防止修改到原本的月
	int Month_Temp = 0;
	//暫存日，並防止修改到原本的日
	int Day_Temp = 0;


    //============================================
    //宣告UI***************************************************
    //============================================
    //GameObject====================================
    //確認按鈕
    public GameObject Accept_Button;
	//input_Field====================================
	//月份
	public InputField Month_Input_Field;
	//日期
	public InputField Day_Input_Field;

    //Button========================================


    //============================================
    // Use this for initialization
    //============================================
    void Start () {
		//月份InputField設為不可用
		Month_Input_Field.interactable = false;
		//日期InputField設為不可用
		Day_Input_Field.interactable = false;


	}

    //============================================
    // Update is called once per frame
    //============================================
    void Update () {
		//if(Year_Input_Bool && Month_Input_Bool && Day_Input_Bool)print (Year_Temp + " " + Month_Temp + " " + Day_Temp);

		//如果輸入年月日都正確
		if(Year_Input_Bool && Month_Input_Bool && Day_Input_Bool)Accept_Button.SetActive(true);
		//如果輸入年月日不正確
		else Accept_Button.SetActive(false);
	}

    //============================================
    //副程式:將Input_Fiels的值放入變數
    //============================================
    public void Input_Setting(){
		//輸入年
		Year = Year_Temp;
		//輸入月
		Month = Month_Temp;
		//輸入日
		Day = Day_Temp;

		//告知Home_Page需要修改訊息
		Input_Home_Page = true;
		//告知按下設定誕生年月日按鈕
		Control_Bar.Change_Page_Bool = true;

		//存檔
		DataManage.Born_Save(Year , Month , Day);
	}


    //============================================
    //副程式:判斷是否有填入年月日
    //============================================
    public void Year_Value_Input(Text Year_Input_Text){
		//將Text轉成string的string
		string Input_To_String = Year_Input_Text.text.ToString();
		//暫存數字防止修改原本的年月日
		int Temp = 0;

		//如果輸入長度為4
		if (Input_To_String.Length == 4) {
			//轉成int
			Temp = Text_To_Int(Year_Input_Text);
			 
			//判斷是否在範圍內(1900 ~ 3000)
			if (Temp >= 1900 && Temp <= 3000) {
				//設定有輸入年
				Year_Input_Bool = true;
				//暫存年份，轉成int
				Year_Temp = Text_To_Int (Year_Input_Text);
				//開啟月份Input_Field
				Month_Input_Field.interactable = true;
				//如果已輸入日期後修改年份
				if(Year_Input_Bool==true)Check_Day_after_Input();
			} 
			//超過範圍
			else {
				Temp = 0;
				Year_Input_Bool = false;
			}

		} 
		//如果不為4
		else {
			Year_Input_Bool = false;
		}
	}

    //============================================
    //副程式:判斷是否有填入月
    //============================================
    public void Month_Value_Input(Text Month_Input_Text){
		//將Text轉成string的string
		string Input_To_String = Month_Input_Text.text.ToString();
		//暫存數字防止修改原本的年月日
		int Temp = 0;

		//如果輸入長度為2
		if (Input_To_String.Length == 2) {
			//轉成int
			Temp = Text_To_Int (Month_Input_Text);

			//判斷是否在範圍內(01 ~ 12)
			if (Temp >= 1 && Temp <= 12) {
				//設定有輸入月
				Month_Input_Bool = true;
				//暫存月份，轉成int
				Month_Temp = Text_To_Int (Month_Input_Text);
				//開啟日期Input_Field
				Day_Input_Field.interactable = true;
				//如果已輸入日期後修改月份
				if(Month_Input_Bool==true)Check_Day_after_Input();
			
			} 
			//超過範圍
			else {
				Temp = 0;
				Month_Input_Bool = false;
			}
		}
		//如果不為2
		else {
			Month_Input_Bool = false;
		}
	}

    //============================================
    //副程式:判斷是否有填入日
    //============================================
    public void Day_Value_Input(Text Day_Input_Text){
		//將Text轉成string的string
		string Input_To_String = Day_Input_Text.text.ToString();
		//暫存數字防止修改原本的年月日
		int Temp = 0;

		//如果輸入長度為2
		if (Input_To_String.Length == 2) {
			//轉成int
			Temp = Text_To_Int(Day_Input_Text);
			//設定日期最大值
			Day_Decide();

			//判斷是否在範圍內
			if (Temp >= 1 && Temp <= Day_Max) {
				//設定有輸入日
				Day_Input_Bool = true;
				//轉成int
				Day_Temp = Text_To_Int (Day_Input_Text);
			}
			//超過範圍
			else {
				//轉成int
				Day_Temp = Text_To_Int (Day_Input_Text);
				Temp = 0;
				Day_Input_Bool = false;
			}
		} 
		//如果不為2
		else {
			Day_Input_Bool = false;
		}
	}

    //============================================
    //副程式:轉換Text為int
    //============================================
    int Text_To_Int(Text Input_Text){
		//將Text轉成string的string
		string Input_To_String;
		//將string轉成Int的Int
		int    String_To_Int;

		//將Input_Text轉成string
		Input_To_String = Input_Text.text.ToString();
		//將Input_To_String轉成int
		String_To_Int = int.Parse(Input_To_String);

		return String_To_Int;

	}

    //============================================
    //副程式:日判斷是28天 29天 30天 31天
    //============================================
    void Day_Decide(){
		//閏年
		if ((Year_Temp % 4 == 0 && Year_Temp % 100!= 0 ) || (Year_Temp % 400 == 0)){
			//29天
			if(Month_Temp==2) Day_Max = 29;
			//30天
			else if(Month_Temp==4 || Month_Temp==6 || Month_Temp==9 || Month_Temp==11) Day_Max = 30;
			//31天
			else Day_Max = 31;
		} 
		//平年
		else {
			//28天
			if(Month_Temp==2) Day_Max = 28;
			//30天
			else if(Month_Temp==4 || Month_Temp==6 || Month_Temp==9 || Month_Temp==11) Day_Max = 30;
			//31天
			else Day_Max = 31;
		}
	}

    //============================================
    //副程式:當輸入日期後，可能改變年或月，須判斷輸入的日期是否要修改
    //============================================
    void Check_Day_after_Input(){
		//重新計算日期最大值
		Day_Decide ();

		//如果已輸入日期 在 新的日期最大值範圍內
		if(Day_Temp >= 1 && Day_Temp <= Day_Max) Day_Input_Bool = true;
		//如果已輸入日期 不在 新的日期最大值範圍內
		else Day_Input_Bool = false;
	}

}
