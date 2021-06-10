//Home頁面
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Home_Page : MonoBehaviour {

    //============================================
    //宣告變數**********************************************************
    //============================================
    //bool********************
    //初始設定 true:進行設定 false:不進行設定
    public static bool initial_bool = true;

    //============================================
    //宣告UI************************************************************
    //============================================

    //Button***********************
    //設定日期按鈕
    public Button Set_Constellation_Button;

	//Text*************************
	//星座名稱
	public Text Constellation_Name_Text;
	//誕生日期
	public Text Month_Day_Text;
	//分類1:陰陽法
	public Text Class1_Text;
	//分類2:三分法
	public Text Class2_Text;
	//分類3:四象法
	public Text Class3_Text;
	//黃道十二宮
	public Text Zodiac_Text;
	//太陽行星
	public Text Plane_Text;
	//節氣
	public Text SolarTerms_Text;
	//守護神
	public Text God_Text;
	//宮位
	public Text Palace_Text;
	//優點
	public Text Advantage_Text;
	//缺點
	public Text Disadvantage_Text;
	//個人特質
	public Text Personality_Text;

    //============================================
    //Image************************
    //============================================
    //星座圖案
    public Image Constellation_Image;
	//星座符號
	public Image Constellation_Symbol_Image;

    public Text MessText;

    public static int aaa = 1;
    public static int bbb = 5;

    //============================================
    // Use this for initialization
    //============================================
    void Start () {
		
	}

    //============================================
    // Update is called once per frame
    //============================================
    void Update () {
		if (DataManage.Use_Data_Bool == true && initial_bool == true) {
			//進行Text初始設定
			Set_Home_Description ();
			//進行Image初始設定
			Set_Home_Image ();
			//不再進行初始設定
			initial_bool = false;
            //Control_Bar.Check_Bool = true;
            
        }

		//修改Home_Page訊息
		if(Input_Field.Input_Home_Page == true){
			//進行Text設定
			Set_Home_Description ();
			//進行Image設定
			Set_Home_Image ();
			Input_Field.Input_Home_Page = false;
		}

        /*MessText.text = "DataManage.Use_Data_Bool: " + DataManage.Use_Data_Bool + "\n" + "initial_bool: " + initial_bool + "\n" + "Input_Field.Input_Home_Page: " + Input_Field.Input_Home_Page + "\n"
            + "\n" + "Input_Field.Year Input_Field.Mon Input_Field.Day: " + Input_Field.Year + Input_Field.Month + Input_Field.Day + "\n" + "FireBase_Script.FireBase_Read_Bool: " + FireBase_Script.FireBase_Read_Bool +"\n"
            + "DataManage.UseTIme: " + DataManage.Use_Time +" " + DataManage .Use_Data_Bool+ "\n" + "aaa: " + aaa + "\n" + Time.deltaTime;
            */
    }

    //============================================
    //副程式:給Set_Home_Description使用於設定Text
    //============================================
    void Set_Home_Description_Text(string Constellation_Name_Text , int Year , int Month , int Day , string Class1_Text , string Class2_Text , string Class3_Text , string Zodiac_Text , string Planet_Text , string SolarTerms_Text , string God_Text , string Palace_Text , string Advantage_Text , string Disadvantage_Text , string Personality_Text){
		//星座名稱
		this.Constellation_Name_Text.text = "" + Constellation_Name_Text;
		//誕生日期
		this.Month_Day_Text.text = Year + "年" + Month + "月" + Day + "日";
		//分類1:陰陽法
		this.Class1_Text.text = "" + Class1_Text;
		//分類2:三分法
		this.Class2_Text.text = "" + Class2_Text;
		//分類3:四象法
		this.Class3_Text.text = "" + Class3_Text;
		//黃道十二宮
		this.Zodiac_Text.text = "第" + Zodiac_Text + "宮";
		//太陽行星
		this.Plane_Text.text = "" + Planet_Text;
		//節氣
		this.SolarTerms_Text.text = "" + SolarTerms_Text;
		//守護神
		this.God_Text.text = "" + God_Text;
		//宮位
		this.Palace_Text.text = "" + Palace_Text ;
		//優點
		this.Advantage_Text.text = "" + Advantage_Text;
		//缺點
		this.Disadvantage_Text.text = "" + Disadvantage_Text;
		//個人特質
		this.Personality_Text.text = "" + Personality_Text;
	}

    //============================================
    //副程式:設定我的星座Text
    //============================================
    void Set_Home_Description(){
		//牡羊座
		if ( (Input_Field.Month == 3 && Input_Field.Day >= 21) || (Input_Field.Month == 4 && Input_Field.Day <= 20) ) {
			int Number = 0;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
		//金牛座
		else if ( (Input_Field.Month == 4 && Input_Field.Day >= 21) || (Input_Field.Month == 5 && Input_Field.Day <= 21) ) {
			int Number = 1;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
		//雙子座
		else if ( (Input_Field.Month == 5 && Input_Field.Day >= 22) || (Input_Field.Month == 6 && Input_Field.Day <= 21) ) {
			int Number = 2;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
		//巨蟹座
		else if ( (Input_Field.Month == 6 && Input_Field.Day >= 22) || (Input_Field.Month == 7 && Input_Field.Day <= 23) ) {
			int Number = 3;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
		//獅子座
		else if ( (Input_Field.Month == 7 && Input_Field.Day >= 24) || (Input_Field.Month == 8 && Input_Field.Day <= 23) ) {
			int Number = 4;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
		//處女座
		else if ( (Input_Field.Month == 8 && Input_Field.Day >= 24) || (Input_Field.Month == 9 && Input_Field.Day <= 23) ) {
			int Number = 5;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//天秤座
		else if ( (Input_Field.Month == 9 && Input_Field.Day >= 24) || (Input_Field.Month == 10 && Input_Field.Day <= 23) ) {
			int Number = 6;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//天蠍座
		else if ( (Input_Field.Month == 10 && Input_Field.Day >= 24) || (Input_Field.Month == 11 && Input_Field.Day <= 22) ) {
			int Number = 7;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//射手座
		else if ( (Input_Field.Month == 11 && Input_Field.Day >= 23) || (Input_Field.Month == 12 && Input_Field.Day <= 22) ) {
			int Number = 8;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//魔羯座
		else if ( (Input_Field.Month == 12 && Input_Field.Day >= 23) || (Input_Field.Month == 1 && Input_Field.Day <= 20) ) {
			int Number = 9;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//水瓶座
		else if ( (Input_Field.Month == 1 && Input_Field.Day >= 21) || (Input_Field.Month == 2 && Input_Field.Day <= 19) ) {
			int Number = 10;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//雙魚座
		else if ( (Input_Field.Month == 2 && Input_Field.Day <= 20) || (Input_Field.Month == 3 && Input_Field.Day <= 20) ) {
			int Number = 11;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//預設為牡羊座
		else{
			int Number = 0;
			Set_Home_Description_Text (DataManage.Constellation[Number].Getter_Name() , Input_Field.Year , Input_Field.Month , Input_Field.Day , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
	}

    //============================================
    //副程式:設定我的星座Image
    //============================================
    void Set_Home_Image(){
		//牡羊座
		if ((Input_Field.Month == 3 && Input_Field.Day >= 21) || (Input_Field.Month == 4 && Input_Field.Day <= 20)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("aries");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("aries_Symbol");
		}
		//金牛座
		else if ((Input_Field.Month == 4 && Input_Field.Day >= 21) || (Input_Field.Month == 5 && Input_Field.Day <= 21)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("taurus");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("taurus_Symbol");
		}
		//雙子座
		else if ((Input_Field.Month == 5 && Input_Field.Day >= 22) || (Input_Field.Month == 6 && Input_Field.Day <= 21)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("gemini");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("gemini_Symbol");
		}
		//巨蟹座
		else if ((Input_Field.Month == 6 && Input_Field.Day >= 22) || (Input_Field.Month == 7 && Input_Field.Day <= 23)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("cancer");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("cancer_Symbol");
		}
		//獅子座
		else if ((Input_Field.Month == 7 && Input_Field.Day >= 24) || (Input_Field.Month == 8 && Input_Field.Day <= 23)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("leo");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("leo_Symbol");
		}
		//處女座
		else if ((Input_Field.Month == 8 && Input_Field.Day >= 24) || (Input_Field.Month == 9 && Input_Field.Day <= 23)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("virgo");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("virgo_Symbol");
		}
		//天秤座
		else if ((Input_Field.Month == 9 && Input_Field.Day >= 24) || (Input_Field.Month == 10 && Input_Field.Day <= 23)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("libra");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("libra_Symbol");
		}
		//天蠍座
		else if ((Input_Field.Month == 10 && Input_Field.Day >= 24) || (Input_Field.Month == 11 && Input_Field.Day <= 22)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("scorpio");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("scorpion_Symbol");
		}
		//射手座
		else if ((Input_Field.Month == 11 && Input_Field.Day >= 23) || (Input_Field.Month == 12 && Input_Field.Day <= 22)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("sagittarius");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("sagittarius_Symbol");
		}
		//魔羯座
		else if ((Input_Field.Month == 12 && Input_Field.Day >= 23) || (Input_Field.Month == 1 && Input_Field.Day <= 20)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("capricorn");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("capricorn_Symbol");
		}
		//水瓶座
		else if ((Input_Field.Month == 1 && Input_Field.Day >= 21) || (Input_Field.Month == 2 && Input_Field.Day <= 19)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("aquarius");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("aquarius_Symbol");
		}
		//雙魚座
		else if ((Input_Field.Month == 2 && Input_Field.Day >= 20) || (Input_Field.Month == 3 && Input_Field.Day <= 20)) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("pisces");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("pisces_Symbol");
		}
		//預設為牡羊座
		else {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("aries");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("aries_Symbol");
		}
	}



}//Home_Page
