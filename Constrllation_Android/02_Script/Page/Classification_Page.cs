//Classification頁面
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Classification_Page : MonoBehaviour {
	
	//宣告變數**********************************************************
	//宣告UI************************************************************
	//Button***********************
	//陰陽法
	public Button Divide_Two_Button;
	//三分法
	public Button Divide_Three_Button;
	//四象法
	public Button Divide_Four_Button;


	//Divide_Two Text*************************
	//陰陽法名稱
	public Text Divide_Two_Name_Text;
	//分類
	public Text Divide_Two_Class_Text;

	//分類1星座
	public Text Divide_Two_Class1_Constellations_Text;
	//分類1描述
	public Text Divide_Two_Class1_Description_Text;

	//分類2星座
	public Text Divide_Two_Class2_Constellations_Text;
	//分類2描述
	public Text Divide_Two_Class2_Description_Text;

	//Divide_Three Text*************************
	//三分法名稱
	public Text Divide_Three_Name_Text;
	//分類
	public Text Divide_Three_Class_Text;

	//分類1星座
	public Text Divide_Three_Class1_Constellations_Text;
	//分類1描述
	public Text Divide_Three_Class1_Description_Text;

	//分類2星座
	public Text Divide_Three_Class2_Constellations_Text;
	//分類2描述
	public Text Divide_Three_Class2_Description_Text;

	//分類3星座
	public Text Divide_Three_Class3_Constellations_Text;
	//分類3描述
	public Text Divide_Three_Class3_Description_Text;

	//Divide_Four Text*************************
	//四象法名稱
	public Text Divide_Four_Name_Text;
	//分類
	public Text Divide_Four_Class_Text;

	//分類1星座
	public Text Divide_Four_Class1_Constellations_Text;
	//分類1描述
	public Text Divide_Four_Class1_Description_Text;

	//分類2星座
	public Text Divide_Four_Class2_Constellations_Text;
	//分類2描述
	public Text Divide_Four_Class2_Description_Text;

	//分類3星座
	public Text Divide_Four_Class3_Constellations_Text;
	//分類3描述
	public Text Divide_Four_Class3_Description_Text;

	//分類4星座
	public Text Divide_Four_Class4_Constellations_Text;
	//分類4描述
	public Text Divide_Four_Class4_Description_Text;



    //============================================
    //副程式(按鈕):將所有按鈕設為可用
    //============================================
    public void Set_Classification_Button(){
		//陰陽法
		Divide_Two_Button.interactable = true;
		//三分法
		Divide_Three_Button.interactable = true;
		//四象法
		Divide_Four_Button.interactable = true;
	}

    //============================================
    //副程式(按鈕)(陰陽法):將所有按鈕設為不可用(星座編號)
    //============================================
    public void Set_Classification_Descripiton(){
		//陰陽法
		Divide_Two_Button.interactable = false;
		//三分法
		Divide_Three_Button.interactable = false;
		//四象法
		Divide_Four_Button.interactable = false;
	}

}
