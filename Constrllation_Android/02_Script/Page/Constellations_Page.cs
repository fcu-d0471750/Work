//Constellations頁面
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Constellations_Page : MonoBehaviour {

	//宣告變數**********************************************************
	//bool***********************************


	//宣告UI************************************************************

	//Button***********************
	//12星座按鈕
	public Button[] Constellations_Button = new Button[12];

	//Text*************************
	//星座名稱
	public Text Constellation_Name_Text;
	//星座英文名稱
	public Text Constellation_EName_Text;
	//星座符號
	public Text Constellation_Symbol_Text;
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

	//Image************************
	//星座圖案
	public Image Constellation_Image;
	//星座符號
	public Image Constellation_Symbol_Image;


    //============================================
    //副程式(按鈕):
    //============================================
    public void Set_Constellation_Button(){
		for(int i=0; i<=11; i++)Constellations_Button[i].interactable = true;
	}

    //============================================
    //副程式(按鈕):將所有按鈕設為不可用(星座編號)
    //============================================
    public void Set_Constellation_Descripiton(int Number){
		for(int i=0; i<=11; i++)Constellations_Button[i].interactable = false;
		//設定星座資訊Text
		Set_Constellations_Description (Number);
		//設定星座Image
		Set_Constellations_Image(Number);
	}

    //============================================
    //副程式:給Set_Constellations_Description使用於設定Text
    //============================================
    void Set_Constellations_Description_Text(string Constellation_Name_Text , string Constellation_EName_Text , string Constellation_Symbol_Text , int Month1 , int Day1 , int Month2 , int Day2 , string Class1_Text , string Class2_Text , string Class3_Text , string Zodiac_Text , string Planet_Text , string SolarTerms_Text , string God_Text , string Palace_Text , string Advantage_Text , string Disadvantage_Text , string Personality_Text){
		//星座名稱
		this.Constellation_Name_Text.text = "" + Constellation_Name_Text;
		//星座英文名稱
		this.Constellation_EName_Text.text = "" + Constellation_EName_Text;
		//星座象徵
		this.Constellation_Symbol_Text.text = "" + Constellation_Symbol_Text;
		//誕生日期
		this.Month_Day_Text.text =  Month1 + "月" + Day1 + "日" + "~" + Month2 + "月" + Day2 + "日";
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
    void Set_Constellations_Description(int Constellations_Number){
		//牡羊座
		if ( Constellations_Number == 1 ) {
			int Number = 0;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
		//金牛座
		else if ( Constellations_Number == 2 ) {
			int Number = 1;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
		//雙子座
		else if ( Constellations_Number == 3 ) {
			int Number = 2;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
		//巨蟹座
		else if ( Constellations_Number == 4 ) {
			int Number = 3;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
		//獅子座
		else if ( Constellations_Number == 5 ) {
			int Number = 4;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
		//處女座
		else if ( Constellations_Number == 6 ) {
			int Number = 5;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//天秤座
		else if ( Constellations_Number == 7 ) {
			int Number = 6;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//天蠍座
		else if ( Constellations_Number == 8 ) {
			int Number = 7;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//射手座
		else if ( Constellations_Number == 9 ) {
			int Number = 8;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//魔羯座
		else if ( Constellations_Number == 10 ) {
			int Number = 9;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//水瓶座
		else if ( Constellations_Number == 11 ) {
			int Number = 10;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//雙魚座
		else if ( Constellations_Number == 12 ) {
			int Number = 11;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());

		}
		//預設為牡羊座
		else{
			int Number = 0;
			Set_Constellations_Description_Text (DataManage.Constellation[Number].Getter_Name() , DataManage.Constellation[Number].Getter_EName() , DataManage.Constellation[Number].Getter_Symbol() , DataManage.Constellation[Number].Getter_Month1() , DataManage.Constellation[Number].Getter_Day1() , DataManage.Constellation[Number].Getter_Month2() , DataManage.Constellation[Number].Getter_Day2() , DataManage.Constellation[Number].Getter_Class1() , DataManage.Constellation[Number].Getter_Class2() , DataManage.Constellation[Number].Getter_Class3() , DataManage.Constellation[Number].Getter_Zodiac() , DataManage.Constellation[Number].Getter_Planet() , DataManage.Constellation[Number].Getter_SolarTerms() , DataManage.Constellation[Number].Getter_God() , DataManage.Constellation[Number].Getter_Palace() , DataManage.Constellation[Number].Getter_Advantage() , DataManage.Constellation[Number].Getter_Disadvantage() , DataManage.Constellation[Number].Getter_Personality());
		}
	}


    //============================================
    //副程式:設定星座Image
    //============================================
    void Set_Constellations_Image(int Constellations_Number){
		//牡羊座
		if (Constellations_Number == 1) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("aries");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("aries_Symbol");
		}
		//金牛座
		else if (Constellations_Number == 2) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("taurus");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("taurus_Symbol");
		}
		//雙子座
		else if (Constellations_Number == 3) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("gemini");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("gemini_Symbol");
		}
		//巨蟹座
		else if (Constellations_Number == 4) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("cancer");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("cancer_Symbol");
		}
		//獅子座
		else if (Constellations_Number == 5) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("leo");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("leo_Symbol");
		}
		//處女座
		else if (Constellations_Number == 6) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("virgo");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("virgo_Symbol");
		}
		//天秤座
		else if (Constellations_Number == 7) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("libra");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("libra_Symbol");
		}
		//天蠍座
		else if (Constellations_Number == 8) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("scorpio");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("scorpion_Symbol");
		}
		//射手座
		else if (Constellations_Number == 9) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("sagittarius");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("sagittarius_Symbol");
		}
		//魔羯座
		else if (Constellations_Number == 10) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("capricorn");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("capricorn_Symbol");
		}
		//水瓶座
		else if (Constellations_Number == 11) {
			//星座圖案
			Constellation_Image.sprite = (Sprite)Resources.Load<Sprite> ("aquarius");
			//星座符號
			Constellation_Symbol_Image.sprite = (Sprite)Resources.Load<Sprite> ("aquarius_Symbol");
		}
		//雙魚座
		else if (Constellations_Number == 12) {
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

}
