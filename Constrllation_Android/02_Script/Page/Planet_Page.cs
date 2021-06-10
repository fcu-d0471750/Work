//Planet頁面
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Planet_Page : MonoBehaviour {

	//宣告變數**********************************************************
	//宣告UI************************************************************
	//Button***********************
	//星球按鈕
	public Button[] Planet_Button = new Button[15];

	//Text*************************
	//星球名稱
	public Text Planet_Name_Text;
	//星球英文名稱
	public Text Planet_EName_Text;
	//星球象徵
	public Text Planet_Symbol_Text;
	//星球主要影響
	public Text Planet_Influence_Text;
	//星球代表
	public Text Planet_Represent_Text;

	//Image************************
	//星球Image
	public Image Planet_Image;


    //============================================
    //副程式(按鈕):將所有按鈕設為可用
    //============================================
    public void Set_Planet_Button(){
		for(int i=0; i<=14; i++)Planet_Button[i].interactable = true;
	}

    //============================================
    //副程式(按鈕):將所有按鈕設為不可用(行星編號)
    //============================================
    public void Set_Planet_Descripiton(int Number){
		for(int i=0; i<=14; i++)Planet_Button[i].interactable = false;
		//設定行星資訊Text
		Set_Planet_Description (Number);
		//設定行星Image
		Set_Planet_Image(Number);
	}

    //============================================
    //副程式:給Set_Constellations_Description使用於設定Text
    //============================================
    void Set_Planet_Description_Text(string Planet_Name_Text , string Planet_EName_Text , string Planet_Symbol_Text , string Planet_Influence_Text , string Planet_Represent_Text){
		//行星名稱
		this.Planet_Name_Text.text = "" + Planet_Name_Text;
		//行星英文
		this.Planet_EName_Text.text = "" + Planet_EName_Text;
		//行星象徵
		this.Planet_Symbol_Text.text = "" + Planet_Symbol_Text;
		//行星影響
		this.Planet_Influence_Text.text = "" + Planet_Influence_Text;
		//行星代表
		this.Planet_Represent_Text.text = "" + Planet_Represent_Text;
	}

    //============================================
    //副程式:設定行星Text
    //============================================
    void Set_Planet_Description(int Planet_Number){
		//太陽
		if ( Planet_Number == 1 ) {
			int Number = 0;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		
		}
		//月亮
		else if ( Planet_Number == 2 ) {
			int Number = 1;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		
		}
		//水星
		else if ( Planet_Number == 3 ) {
			int Number = 2;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		
		}
		//金星
		else if ( Planet_Number == 4 ) {
			int Number = 3;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		
		}
		//火星
		else if ( Planet_Number == 5 ) {
			int Number = 4;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		
		}
		//木星
		else if ( Planet_Number == 6 ) {
			int Number = 5;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		

		}
		//土星
		else if ( Planet_Number == 7 ) {
			int Number = 6;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		

		}
		//天王星
		else if ( Planet_Number == 8 ) {
			int Number = 7;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		

		}
		//海王星
		else if ( Planet_Number == 9 ) {
			int Number = 8;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		

		}
		//冥王星
		else if ( Planet_Number == 10 ) {
			int Number = 9;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		

		}
		//婚神星
		else if ( Planet_Number == 11 ) {
			int Number = 10;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		

		}
		//灶神星
		else if ( Planet_Number == 12 ) {
			int Number = 11;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		

		}
		//轂神星
		else if ( Planet_Number == 13 ) {
			int Number = 12;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		

		}
		//智神星
		else if ( Planet_Number == 14 ) {
			int Number = 13;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		

		}
		//凱龍星
		else if ( Planet_Number == 15 ) {
			int Number = 14;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		

		}
		//預設為太陽
		else{
			int Number = 0;
			Set_Planet_Description_Text (DataManage.Planet[Number].Getter_Name() , DataManage.Planet[Number].Getter_EName() , DataManage.Planet[Number].Getter_Description() , DataManage.Planet[Number].Getter_Influence() , DataManage.Planet[Number].Getter_Represent());		
		}
	}

    //============================================
    //副程式:設定行星Image
    //============================================
    void Set_Planet_Image(int Planet_Number){
		//太陽
		if (Planet_Number == 1) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("sun");
		}
		//月亮
		else if (Planet_Number == 2) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("moon");
		}
		//水星
		else if (Planet_Number == 3) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("mercury");
		}
		//金星
		else if (Planet_Number == 4) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("venus");
		}
		//火星
		else if (Planet_Number == 5) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("mars");
		}
		//木星
		else if (Planet_Number == 6) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("jupiters");
		}
		//土星
		else if (Planet_Number == 7) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("saturn");
		}
		//天王星
		else if (Planet_Number == 8) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("uranus");
		}
		//海王星
		else if (Planet_Number == 9) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("neptune");
		}
		//冥王星
		else if (Planet_Number == 10) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("pluto");
		}
		//婚神星
		else if (Planet_Number == 11) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("europa");
		}
		//灶神星
		else if (Planet_Number == 12) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("jupiter");
		}
		//轂神星
		else if (Planet_Number == 13) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("moons");
		}
		//智神星
		else if (Planet_Number == 14) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("satellite");
		}
		//凱龍星
		else if (Planet_Number == 15) {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("milky-way");
		}
		//預設為太陽
		else {
			//行星圖案
			Planet_Image.sprite = (Sprite)Resources.Load<Sprite> ("sun");
		}
	}

}
