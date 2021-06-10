//Palace頁面
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Palace_Page : MonoBehaviour {
	
	//宣告變數**********************************************************
	//宣告UI************************************************************
	//Button***********************
	//宮位按鈕
	public Button[] Palace_Button = new Button[12];

	//Text*************************
	//宮位名稱
	public Text Palace_Name_Text;
	//宮位編號
	public Text Palace_Number_Text;
	//宮位星座
	public Text Palace_Constellation_Text;
	//宮位守護星
	public Text Palace_Planet_Text;
	//宮位特質
	public Text Palace_Personality_Text;

	//Image************************
	//宮位Image
	public Image Palace_Image;



    //============================================
    //副程式(按鈕):將所有按鈕設為可用
    //============================================
    public void Set_Palace_Button(){
		for(int i=0; i<=11; i++)Palace_Button[i].interactable = true;
	}

    //============================================
    //副程式(按鈕):將所有按鈕設為不可用(宮位編號)
    //============================================
    public void Set_Palace_Descripiton(int Number){
		for(int i=0; i<=11; i++)Palace_Button[i].interactable = false;
		//設定宮位資訊Text
		Set_Palace_Description (Number);
		//設定宮位Image
		Set_Palace_Image(Number);
	}

    //============================================
    //副程式:給Set_Constellations_Description使用於設定Text
    //============================================
    void Set_Palace_Description_Text(string Palace_Name_Text , string Palace_Number_Text , string Palace_Constellation_Text , string Palace_Planet_Text , string Palace_Personality_Text){
		//宮位名稱
		this.Palace_Name_Text.text = "" + Palace_Name_Text;
		//宮位編號
		this.Palace_Number_Text.text = "" + Palace_Number_Text;
		//宮位星座
		this.Palace_Constellation_Text.text = "" + Palace_Constellation_Text;
		//宮位守護星
		this.Palace_Planet_Text.text = "" + Palace_Planet_Text;
		//宮位特質
		this.Palace_Personality_Text.text = "" + Palace_Personality_Text;

	}

    //============================================
    //副程式:設定我的星座Text
    //============================================
    void Set_Palace_Description(int Palace_Number){
		//命運宮
		if ( Palace_Number == 1 ) {
			int Number = 0;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());
		}
		//財運宮
		else if ( Palace_Number == 2 ) {
			int Number = 1;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());
		}
		//兄弟宮
		else if ( Palace_Number == 3 ) {
			int Number = 2;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());
		}
		//家庭宮
		else if ( Palace_Number == 4 ) {
			int Number = 3;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());
		}
		//子女宮
		else if ( Palace_Number == 5 ) {
			int Number = 4;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());
		}
		//健康宮
		else if ( Palace_Number == 6 ) {
			int Number = 5;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());

		}
		//夫妻宮
		else if ( Palace_Number == 7 ) {
			int Number = 6;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());

		}
		//疾厄宮
		else if ( Palace_Number == 8 ) {
			int Number = 7;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());

		}
		//遷移宮
		else if ( Palace_Number == 9 ) {
			int Number = 8;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());

		}
		//事業宮
		else if ( Palace_Number == 10 ) {
			int Number = 9;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());

		}
		//人際宮
		else if ( Palace_Number == 11 ) {
			int Number = 10;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());

		}
		//精神宮
		else if ( Palace_Number == 12 ) {
			int Number = 11;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());

		}
		//預設為命運宮
		else{
			int Number = 0;
			Set_Palace_Description_Text (DataManage.Palace[Number].Getter_Palace_Name() , DataManage.Palace[Number].Getter_Palace_Number() , DataManage.Palace[Number].Getter_Palace_Constellations() , DataManage.Palace[Number].Getter_Palace_Planet() , DataManage.Palace[Number].Getter_Palace_Description());
		}
	}


    //============================================
    //副程式:設定我的星座Image
    //============================================
    void Set_Palace_Image(int Palace_Number){
		//命運宮
		if (Palace_Number == 1) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("gyeongbokgung-palace");
		}
		//財運宮
		else if (Palace_Number == 2) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("pantheon");
		}
		//兄弟宮
		else if (Palace_Number == 3) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("wat-benchamapohit");
		}
		//家庭宮
		else if (Palace_Number == 4) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("pagoda");
		}
		//子女宮
		else if (Palace_Number == 5) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("antim-monastery");
		}
		//健康宮
		else if (Palace_Number == 6) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("basilica-of-the-sacred-heart");
		}
		//夫妻宮
		else if (Palace_Number == 7) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("bibi-heybat-mosque");
		}
		//疾厄宮
		else if (Palace_Number == 8) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("boudhanath");
		}
		//遷移宮
		else if (Palace_Number == 9) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("kunya-urgench");
		}
		//事業宮
		else if (Palace_Number == 10) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("bayterek");
		}
		//人際宮
		else if (Palace_Number == 11) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("brandenburg-gate");
		}
		//精神宮
		else if (Palace_Number == 12) {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("berlin-cathedral");
		}
		//預設為命運宮
		else {
			//宮位圖案
			Palace_Image.sprite = (Sprite)Resources.Load<Sprite> ("gyeongbokgung-palace");
		}
	}
}
