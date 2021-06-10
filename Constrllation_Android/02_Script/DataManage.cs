//全部的本地端儲存資料
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.IO;  //StreamWrite會用到

public class DataManage : MonoBehaviour {

	//宣告變數=======================================================================
	//類別===========================================================
	//12星座
	public static Constellations_Class[] Constellation = new Constellations_Class[12];

	//二分法
	public static Separate_Class_[] Two_Separate = new Separate_Class_[2];
	//三分法
	public static Separate_Class_[] Three_Separate = new Separate_Class_[3];
	//四分法
	public static Separate_Class_[] Four_Separate = new Separate_Class_[4];

	//宮位
	public static Palace_Class[] Palace = new Palace_Class[12];

	//行星
	public static Planet_Class[] Planet = new Planet_Class[15];


	//float=================================================
	//用於計算當資料讀取完後，電腦改變狀態的時間
	public static float Use_Time = 2.0f;

	//bool==================================================
	//系統可以使用資料 true:可以 fasle:不可以
	public static bool Use_Data_Bool = false;


	//存檔變數==============================================
	//誕生年月日***********************************
	public static string[] BornYMD = new string[3]{"BornYear","BornMonth","BornDay"} ;  

	//十二星座
	public static string[,] Constellations_Save_String = new string[12,18]
	{
		{"Constellations_Class_Name_1","Constellations_Class_EName_1" , "Constellations_Class_Month1_1" , "Constellations_Class_Day1_1" , "Constellations_Class_Month2_1" , "Constellations_Class_Day2_1" , "Constellations_Class_Class1_1" , "Constellations_Class_Class2_1" , "Constellations_Class_Class3_1" , "Constellations_Class_SolarTerms_1" , "Constellations_Class_Planet_1" , "Constellations_Class_God_1" , "Constellations_Class_Zodiac_1" , "Constellations_Class_Palace_1" , "Constellations_Class_Symbol_1" , "Constellations_Class_Advantage_1" , "Constellations_Class_Disadvantage_1" , "Constellations_Class_Personality_1"},
		{"Constellations_Class_Name_2","Constellations_Class_EName_2" , "Constellations_Class_Month1_2" , "Constellations_Class_Day1_2" , "Constellations_Class_Month2_2" , "Constellations_Class_Day2_2" , "Constellations_Class_Class1_2" , "Constellations_Class_Class2_2" , "Constellations_Class_Class3_2" , "Constellations_Class_SolarTerms_2" , "Constellations_Class_Planet_2" , "Constellations_Class_God_2" , "Constellations_Class_Zodiac_2" , "Constellations_Class_Palace_2" , "Constellations_Class_Symbol_2" , "Constellations_Class_Advantage_2" , "Constellations_Class_Disadvantage_2" , "Constellations_Class_Personality_2"},
		{"Constellations_Class_Name_3","Constellations_Class_EName_3" , "Constellations_Class_Month1_3" , "Constellations_Class_Day1_3" , "Constellations_Class_Month2_3" , "Constellations_Class_Day2_3" , "Constellations_Class_Class1_3" , "Constellations_Class_Class2_3" , "Constellations_Class_Class3_3" , "Constellations_Class_SolarTerms_3" , "Constellations_Class_Planet_3" , "Constellations_Class_God_3" , "Constellations_Class_Zodiac_3" , "Constellations_Class_Palace_3" , "Constellations_Class_Symbol_3" , "Constellations_Class_Advantage_3" , "Constellations_Class_Disadvantage_3" , "Constellations_Class_Personality_3"},
		{"Constellations_Class_Name_4","Constellations_Class_EName_4" , "Constellations_Class_Month1_4" , "Constellations_Class_Day1_4" , "Constellations_Class_Month2_4" , "Constellations_Class_Day2_4" , "Constellations_Class_Class1_4" , "Constellations_Class_Class2_4" , "Constellations_Class_Class3_4" , "Constellations_Class_SolarTerms_4" , "Constellations_Class_Planet_4" , "Constellations_Class_God_4" , "Constellations_Class_Zodiac_4" , "Constellations_Class_Palace_4" , "Constellations_Class_Symbol_4" , "Constellations_Class_Advantage_4" , "Constellations_Class_Disadvantage_4" , "Constellations_Class_Personality_4"},
		{"Constellations_Class_Name_5","Constellations_Class_EName_5" , "Constellations_Class_Month1_5" , "Constellations_Class_Day1_5" , "Constellations_Class_Month2_5" , "Constellations_Class_Day2_5" , "Constellations_Class_Class1_5" , "Constellations_Class_Class2_5" , "Constellations_Class_Class3_5" , "Constellations_Class_SolarTerms_5" , "Constellations_Class_Planet_5" , "Constellations_Class_God_5" , "Constellations_Class_Zodiac_5" , "Constellations_Class_Palace_5" , "Constellations_Class_Symbol_5" , "Constellations_Class_Advantage_5" , "Constellations_Class_Disadvantage_5" , "Constellations_Class_Personality_5"},
		{"Constellations_Class_Name_6","Constellations_Class_EName_6" , "Constellations_Class_Month1_6" , "Constellations_Class_Day1_6" , "Constellations_Class_Month2_6" , "Constellations_Class_Day2_6" , "Constellations_Class_Class1_6" , "Constellations_Class_Class2_6" , "Constellations_Class_Class3_6" , "Constellations_Class_SolarTerms_6" , "Constellations_Class_Planet_6" , "Constellations_Class_God_6" , "Constellations_Class_Zodiac_6" , "Constellations_Class_Palace_6" , "Constellations_Class_Symbol_6" , "Constellations_Class_Advantage_6" , "Constellations_Class_Disadvantage_6" , "Constellations_Class_Personality_6"},
		{"Constellations_Class_Name_7","Constellations_Class_EName_7" , "Constellations_Class_Month1_7" , "Constellations_Class_Day1_7" , "Constellations_Class_Month2_7" , "Constellations_Class_Day2_7" , "Constellations_Class_Class1_7" , "Constellations_Class_Class2_7" , "Constellations_Class_Class3_7" , "Constellations_Class_SolarTerms_7" , "Constellations_Class_Planet_7" , "Constellations_Class_God_7" , "Constellations_Class_Zodiac_7" , "Constellations_Class_Palace_7" , "Constellations_Class_Symbol_7" , "Constellations_Class_Advantage_7" , "Constellations_Class_Disadvantage_7" , "Constellations_Class_Personality_7"},
		{"Constellations_Class_Name_8","Constellations_Class_EName_8" , "Constellations_Class_Month1_8" , "Constellations_Class_Day1_8" , "Constellations_Class_Month2_8" , "Constellations_Class_Day2_8" , "Constellations_Class_Class1_8" , "Constellations_Class_Class2_8" , "Constellations_Class_Class3_8" , "Constellations_Class_SolarTerms_8" , "Constellations_Class_Planet_8" , "Constellations_Class_God_8" , "Constellations_Class_Zodiac_8" , "Constellations_Class_Palace_8" , "Constellations_Class_Symbol_8" , "Constellations_Class_Advantage_8" , "Constellations_Class_Disadvantage_8" , "Constellations_Class_Personality_8"},
		{"Constellations_Class_Name_9","Constellations_Class_EName_9" , "Constellations_Class_Month1_9" , "Constellations_Class_Day1_9" , "Constellations_Class_Month2_9" , "Constellations_Class_Day2_9" , "Constellations_Class_Class1_9" , "Constellations_Class_Class2_9" , "Constellations_Class_Class3_9" , "Constellations_Class_SolarTerms_9" , "Constellations_Class_Planet_9" , "Constellations_Class_God_9" , "Constellations_Class_Zodiac_9" , "Constellations_Class_Palace_9" , "Constellations_Class_Symbol_9" , "Constellations_Class_Advantage_9" , "Constellations_Class_Disadvantage_9" , "Constellations_Class_Personality_9"},
		{"Constellations_Class_Name_10","Constellations_Class_EName_10" , "Constellations_Class_Month1_10" , "Constellations_Class_Day1_10" , "Constellations_Class_Month2_10" , "Constellations_Class_Day2_10" , "Constellations_Class_Class1_10" , "Constellations_Class_Class2_10" , "Constellations_Class_Class3_10" , "Constellations_Class_SolarTerms_10" , "Constellations_Class_Planet_10" , "Constellations_Class_God_10" , "Constellations_Class_Zodiac_10" , "Constellations_Class_Palace_10" , "Constellations_Class_Symbol_10" , "Constellations_Class_Advantage_10" , "Constellations_Class_Disadvantage_10" , "Constellations_Class_Personality_10"},
		{"Constellations_Class_Name_11","Constellations_Class_EName_11" , "Constellations_Class_Month1_11" , "Constellations_Class_Day1_11" , "Constellations_Class_Month2_11" , "Constellations_Class_Day2_11" , "Constellations_Class_Class1_11" , "Constellations_Class_Class2_11" , "Constellations_Class_Class3_11" , "Constellations_Class_SolarTerms_1" , "Constellations_Class_Planet_11" , "Constellations_Class_God_11" , "Constellations_Class_Zodiac_11" , "Constellations_Class_Palace_11" , "Constellations_Class_Symbol_11" , "Constellations_Class_Advantage_11" , "Constellations_Class_Disadvantage_11" , "Constellations_Class_Personality_11"},
		{"Constellations_Class_Name_12","Constellations_Class_EName_12" , "Constellations_Class_Month1_12" , "Constellations_Class_Day1_12" , "Constellations_Class_Month2_12" , "Constellations_Class_Day2_12" , "Constellations_Class_Class1_12" , "Constellations_Class_Class2_12" , "Constellations_Class_Class3_12" , "Constellations_Class_SolarTerms_12" , "Constellations_Class_Planet_12" , "Constellations_Class_God_12" , "Constellations_Class_Zodiac_12" , "Constellations_Class_Palace_12" , "Constellations_Class_Symbol_12" , "Constellations_Class_Advantage_12" , "Constellations_Class_Disadvantage_12" , "Constellations_Class_Personality_12"}
	};

	//二分法
	public static string[,] Two_Separate_Save_String = new string[2, 4] 
	{
		{"Two_Separate_Save_Name_1" , "Two_Separate_Save_Classification_1" , "Two_Separate_Save_Constellations_1" , "Two_Separate_Save_Description_1"},
		{"Two_Separate_Save_Name_2" , "Two_Separate_Save_Classification_2" , "Two_Separate_Save_Constellations_2" , "Two_Separate_Save_Description_2"}
	};

	//三分法
	public static string[,] Three_Separate_Save_String = new string[3, 4] 
	{
		{"Three_Separate_Save_Name_1" , "Three_Separate_Save_Classification_1" , "Three_Separate_Save_Constellations_1" , "Three_Separate_Save_Description_1"},
		{"Three_Separate_Save_Name_2" , "Three_Separate_Save_Classification_2" , "Three_Separate_Save_Constellations_2" , "Three_Separate_Save_Description_2"},
		{"Three_Separate_Save_Name_3" , "Three_Separate_Save_Classification_3" , "Three_Separate_Save_Constellations_3" , "Three_Separate_Save_Description_3"}

	};

	//四分法
	public static string[,] Four_Separate_Save_String = new string[4, 4] 
	{
		{"Four_Separate_Save_Name_1" , "Four_Separate_Save_Classification_1" , "Four_Separate_Save_Constellations_1" , "Four_Separate_Save_Description_1"},
		{"Four_Separate_Save_Name_2" , "Four_Separate_Save_Classification_2" , "Four_Separate_Save_Constellations_2" , "Four_Separate_Save_Description_2"},
		{"Four_Separate_Save_Name_3" , "Four_Separate_Save_Classification_3" , "Four_Separate_Save_Constellations_3" , "Four_Separate_Save_Description_3"},
		{"Four_Separate_Save_Name_4" , "Four_Separate_Save_Classification_4" , "Four_Separate_Save_Constellations_4" , "Four_Separate_Save_Description_4"}
	};

	//宮位
	public static string[,] Palace_Save_String = new string[12, 5] 
	{
		{"Palace_Save_Name_1" , "Palace_Save_Number_1" , "Palace_Save_Constellations_1" , "Palace_Save_Planet_1" , "Palace_Save_Description_1"},
		{"Palace_Save_Name_2" , "Palace_Save_Number_2" , "Palace_Save_Constellations_2" , "Palace_Save_Planet_2" , "Palace_Save_Description_2"},
		{"Palace_Save_Name_3" , "Palace_Save_Number_3" , "Palace_Save_Constellations_3" , "Palace_Save_Planet_3" , "Palace_Save_Description_3"},
		{"Palace_Save_Name_4" , "Palace_Save_Number_4" , "Palace_Save_Constellations_4" , "Palace_Save_Planet_4" , "Palace_Save_Description_4"},
		{"Palace_Save_Name_5" , "Palace_Save_Number_5" , "Palace_Save_Constellations_5" , "Palace_Save_Planet_5" , "Palace_Save_Description_5"},
		{"Palace_Save_Name_6" , "Palace_Save_Number_6" , "Palace_Save_Constellations_6" , "Palace_Save_Planet_6" , "Palace_Save_Description_6"},
		{"Palace_Save_Name_7" , "Palace_Save_Number_7" , "Palace_Save_Constellations_7" , "Palace_Save_Planet_7" , "Palace_Save_Description_7"},
		{"Palace_Save_Name_8" , "Palace_Save_Number_8" , "Palace_Save_Constellations_8" , "Palace_Save_Planet_8" , "Palace_Save_Description_8"},
		{"Palace_Save_Name_9" , "Palace_Save_Number_9" , "Palace_Save_Constellations_9" , "Palace_Save_Planet_9" , "Palace_Save_Description_9"},
		{"Palace_Save_Name_10" , "Palace_Save_Number_10" , "Palace_Save_Constellations_10" , "Palace_Save_Planet_10" , "Palace_Save_Description_10"},
		{"Palace_Save_Name_11" , "Palace_Save_Number_11" , "Palace_Save_Constellations_11" , "Palace_Save_Planet_11" , "Palace_Save_Description_11"},
		{"Palace_Save_Name_12" , "Palace_Save_Number_12" , "Palace_Save_Constellations_12" , "Palace_Save_Planet_12" , "Palace_Save_Description_12"}
	};

	//行星
	public static string[,] Planet_Save_String = new string[15, 5] 
	{
		{"Planet_Save_Name_1" , "Planet_Save_EName_1" , "Planet_Save_Represent_1" , "Planet_Save_Influence_1" , "Planet_Save_Description_1"},
		{"Planet_Save_Name_2" , "Planet_Save_EName_2" , "Planet_Save_Represent_2" , "Planet_Save_Influence_2" , "Planet_Save_Description_2"},
		{"Planet_Save_Name_3" , "Planet_Save_EName_3" , "Planet_Save_Represent_3" , "Planet_Save_Influence_3" , "Planet_Save_Description_3"},
		{"Planet_Save_Name_4" , "Planet_Save_EName_4" , "Planet_Save_Represent_4" , "Planet_Save_Influence_4" , "Planet_Save_Description_4"},
		{"Planet_Save_Name_5" , "Planet_Save_EName_5" , "Planet_Save_Represent_5" , "Planet_Save_Influence_5" , "Planet_Save_Description_5"},
		{"Planet_Save_Name_6" , "Planet_Save_EName_6" , "Planet_Save_Represent_6" , "Planet_Save_Influence_6" , "Planet_Save_Description_6"},
		{"Planet_Save_Name_7" , "Planet_Save_EName_7" , "Planet_Save_Represent_7" , "Planet_Save_Influence_7" , "Planet_Save_Description_7"},
		{"Planet_Save_Name_8" , "Planet_Save_EName_8" , "Planet_Save_Represent_8" , "Planet_Save_Influence_8" , "Planet_Save_Description_8"},
		{"Planet_Save_Name_9" , "Planet_Save_EName_9" , "Planet_Save_Represent_9" , "Planet_Save_Influence_9" , "Planet_Save_Description_9"},
		{"Planet_Save_Name_10" , "Planet_Save_EName_10" , "Planet_Save_Represent_10" , "Planet_Save_Influence_10" , "Planet_Save_Description_10"},
		{"Planet_Save_Name_11" , "Planet_Save_EName_11" , "Planet_Save_Represent_11" , "Planet_Save_Influence_11" , "Planet_Save_Description_11"},
		{"Planet_Save_Name_12" , "Planet_Save_EName_12" , "Planet_Save_Represent_12" , "Planet_Save_Influence_12" , "Planet_Save_Description_12"},
		{"Planet_Save_Name_13" , "Planet_Save_EName_13" , "Planet_Save_Represent_13" , "Planet_Save_Influence_13" , "Planet_Save_Description_13"},
		{"Planet_Save_Name_14" , "Planet_Save_EName_14" , "Planet_Save_Represent_14" , "Planet_Save_Influence_14" , "Planet_Save_Description_14"},
		{"Planet_Save_Name_15" , "Planet_Save_EName_15" , "Planet_Save_Represent_15" , "Planet_Save_Influence_15" , "Planet_Save_Description_15"},
	};

    //============================================
    // Use this for initialization
    //============================================
    void Start () {
	
	}

    //============================================
    // Update is called once per frame
    //============================================
    void Update () {
		//電腦改變狀態的時間
		if (FireBase_Script.FireBase_Read_Bool == true) Use_Time -= Time.deltaTime;

		//系統可以使用資料
		if (Use_Time <= 0.0f && Use_Data_Bool == false) {
			//防止Use_Time一直減下去
			FireBase_Script.FireBase_Read_Bool = false;
			//讀取誕生年月日
			Born_Save_Write();
			//可以使用資料
			Use_Data_Bool = true;
            Control_Bar.Check_Bool = true;
            //防止Use_Time一直扣下去
            Use_Time = 3.0f;
		}

		//if(Use_Data_Bool == true)print (Three_Separate[2].Getter_Description() + " " + Two_Separate[1].Getter_Description());//print (" " + Constellation[0].Getter_Personality() + " " + Constellation[1].Getter_Name() +" " + Constellation[2].Getter_Name() +" " + Constellation[3].Getter_Name() +" " + Constellation[4].Getter_Name() +" " + Constellation[5].Getter_Name() +" " + Constellation[6].Getter_Name() +" " + Constellation[7].Getter_Name() +" " + Constellation[8].Getter_Name() +" " + Constellation[9].Getter_Name() +" " + Constellation[10].Getter_Name() +" " + Constellation[11].Getter_Name() );
		//if(Use_Data_Bool == true)aass.text = Three_Separate[2].Getter_Description();
	}

    //============================================
    //副程式:誕生年月日存檔
    //============================================
    public static void Born_Save(int Year , int Month , int Day){
		PlayerPrefs.SetInt (BornYMD[0], Year); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetInt (BornYMD[1] , Month); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetInt (BornYMD[2] , Day); 
		PlayerPrefs.Save (); 
	}

    //============================================
    //副程式:誕生年月日讀檔
    //============================================
    public static void Born_Save_Write(){
		Input_Field.Year = PlayerPrefs.GetInt (BornYMD[0], 1990); 
		Input_Field.Month = PlayerPrefs.GetInt (BornYMD[1], 01); 
		Input_Field.Day = PlayerPrefs.GetInt (BornYMD[2], 01); 
	}

    //============================================
    //副程式:星座存檔
    //============================================
    public static void Constellations_Class_Save(int Number , string[,] Save_String , string Name,string EName,int Month1,int Day1,int Month2,int Day2,string Class1,string Class2,string Class3,string SolarTerms,string Planet,string God,string Zodiac,string Palace,string Symbol,string Advantage,string Disadvantage,string Personality){
		PlayerPrefs.SetString (Save_String[Number,0] , Name); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,1] , EName); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetInt (Save_String[Number,2] , Month1); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetInt (Save_String[Number,3] , Day1); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetInt (Save_String[Number,4] , Month2); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetInt (Save_String[Number,5] , Day2); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,6] , Class1); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,7] , Class2); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,8] , Class3); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,9] , SolarTerms); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,10] , Planet); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,11] , God); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,12] , Zodiac); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,13] , Palace); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,14] , Symbol); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,15] , Advantage); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,16] , Disadvantage); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,17] , Personality); 
		PlayerPrefs.Save (); 
	}

    //============================================
    //副程式:星座讀檔
    //============================================
    public static void Constellations_Class_Save_Write(int Nubmer ){
		
		//星座名稱
		string Name = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 0], "牡羊座"); 
		//星座英文名稱
		string EName = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 1], "Aries"); 
		//
		int Month1 = PlayerPrefs.GetInt (Constellations_Save_String [Nubmer, 2], 3); 
		//
		int Day1 = PlayerPrefs.GetInt (Constellations_Save_String [Nubmer, 3], 21); 
		//
		int Month2 = PlayerPrefs.GetInt (Constellations_Save_String [Nubmer, 4], 4); 
		//
		int Day2 = PlayerPrefs.GetInt (Constellations_Save_String [Nubmer, 5], 20); 
		//星座分類1
		string Class1 = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 6], "陽性"); 
		//星座分類2
		string Class2 = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 7], "本位"); 
		//星座分類3
		string Class3 = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 8], "火象星座"); 
		//星座節氣
		string SolarTerms = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 9], "春至"); 
		//星座守護星
		string Planet = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 10], "牡羊座"); 
		//星座守護神
		string God = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 11], "戰神-阿瑞斯"); 
		//星座黃道十二宮
		string Zodiac = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 12], "一"); 
		//星座宮位
		string Palace = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 13], "命運宮"); 
		//星座符號
		string Symbol = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 14], "羊角"); 
		//星座優點
		string Advantage = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 15], "勇於嘗試，永不言敗的星座，也是一個火爆，容易生氣的星座，另一方面，白羊座的人十分喜歡幫助別人。"); 
		//星座缺點
		string Disadvantage = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 16], "自信、純真、嘗新、勇往直前、冒險不怕失敗"); 
		//星座個人特質
		string Personality = PlayerPrefs.GetString (Constellations_Save_String [Nubmer, 17], "自我、粗心、急躁、三分鐘熱度、孩子氣、過份自負、有勇無謀"); 

		//放入資料
		Constellation [Nubmer] = new Constellations_Class (Name, EName, Month1, Day1, Month2, Day2, Class1, Class2, Class3, SolarTerms, Planet, God, Zodiac, Palace, Symbol, Advantage, Disadvantage, Personality);

	}


    //============================================
    //副程式:二分法存檔
    //============================================
    public static void Two_Separate_Save(int Number , string[,] Save_String , string Name,string Classification,string Constellations,string Description){
		PlayerPrefs.SetString (Save_String[Number,0] , Name); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,1] , Classification); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,2] , Constellations); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,3] , Description); 
		PlayerPrefs.Save (); 
	}

    //============================================
    //副程式:二分法讀檔
    //============================================
    public static void Two_Separate_Save_Write(int Number){

		string Name = PlayerPrefs.GetString (Two_Separate_Save_String [Number, 0], "二分法"); 
		string Class = PlayerPrefs.GetString (Two_Separate_Save_String [Number, 1], "陽性"); 
		string Constellation  = PlayerPrefs.GetString (Two_Separate_Save_String [Number, 2], "牡羊座、雙子座、獅子座、天秤座、射手座、水瓶座"); 
		string Description = PlayerPrefs.GetString (Two_Separate_Save_String [Number, 3], "這些星座的人比較外向、主動、帶有侵略性。個性比較積極、樂觀，開創性強。"); 
	
		//放入資料
		Two_Separate [Number] = new Separate_Class_ ( Name , Class , Constellation , Description);

	}


    //============================================
    //副程式:三分法存檔
    //============================================
    public static void Three_Separate_Save(int Number , string[,] Save_String , string Name,string Classification,string Constellations,string Description){
		PlayerPrefs.SetString (Save_String[Number,0] , Name); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,1] , Classification); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,2] , Constellations); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,3] , Description); 
		PlayerPrefs.Save (); 
	}

    //============================================
    //副程式:三分法讀檔
    //============================================
    public static void Three_Separate_Save_Write(int Number){

		string Name = PlayerPrefs.GetString (Three_Separate_Save_String [Number, 0], "三分法"); 
		string Class = PlayerPrefs.GetString (Three_Separate_Save_String [Number, 1], "本位"); 
		string Constellation  = PlayerPrefs.GetString (Three_Separate_Save_String [Number, 2], "牡羊座、巨蟹座、天秤座、摩羯座"); 
		string Description = PlayerPrefs.GetString (Three_Separate_Save_String [Number, 3], "帶有開創的特質。這些星座的人熱切、有野心、熱忱、獨立、心思快捷，但不容易滿足，做事倉促草率，專斷自我。"); 

		//放入資料
		Three_Separate [Number] = new Separate_Class_ ( Name , Class , Constellation , Description);

	}

    //============================================
    //副程式:四分法存檔
    //============================================
    public static void Four_Separate_Save(int Number , string[,] Save_String , string Name,string Classification,string Constellations,string Description){
		PlayerPrefs.SetString (Save_String[Number,0] , Name); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,1] , Classification); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,2] , Constellations); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,3] , Description); 
		PlayerPrefs.Save (); 
	}

    //============================================
    //副程式:四分法讀檔
    //============================================
    public static void Four_Separate_Save_Write(int Number){

		string Name = PlayerPrefs.GetString (Four_Separate_Save_String [Number, 0], "四分法"); 
		string Class = PlayerPrefs.GetString (Four_Separate_Save_String [Number, 1], "火象"); 
		string Constellation  = PlayerPrefs.GetString (Four_Separate_Save_String [Number, 2], "牡羊座、獅子座、射手座"); 
		string Description = PlayerPrefs.GetString (Four_Separate_Save_String [Number, 3], "這些星座的人衝動、重視直覺，很有自信但卻沒有耐性。溫暖、狂熱都算是基本特質。他們最擅長的就是「搧風點火」、「鼓舞人心」。氣火爆，性格熱情、果斷、自信、率性而天真。但是自負、專橫、霸道、衝動、激烈。是非常有個性的一群。"); 

		//放入資料
		Four_Separate [Number] = new Separate_Class_ ( Name , Class , Constellation , Description);

	}

    //============================================
    //副程式:宮位存檔
    //============================================
    public static void Palace_Save(int Number , string[,] Save_String , string Palace_Name,string Palace_Number,string Palace_Constellations,string Palace_Planet,string Palace_Description){
		PlayerPrefs.SetString (Save_String[Number,0] , Palace_Name); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,1] , Palace_Number); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,2] , Palace_Constellations); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,3] , Palace_Planet); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,4] , Palace_Description); 
		PlayerPrefs.Save (); 

	}

    //============================================
    //副程式:宮位讀檔
    //============================================
    public static void Palace_Class_Save_Write(int Nubmer ){

		string Class = PlayerPrefs.GetString (Palace_Save_String [Nubmer, 0], "第一宮"); 
		string Palace =PlayerPrefs.GetString (Palace_Save_String [Nubmer, 1], "命運宮"); 
		string Constellation = PlayerPrefs.GetString (Palace_Save_String [Nubmer, 2], "牡羊座"); 
		string Planet = PlayerPrefs.GetString (Palace_Save_String [Nubmer, 3], "火星"); 
		string Description = PlayerPrefs.GetString (Palace_Save_String [Nubmer, 4], "命運、身體狀況、外貌、生命力、自我。"); 
		//放入資料
		DataManage.Palace [Nubmer] = new Palace_Class ( Palace , Class , Constellation , Planet , Description);
	}

    //============================================
    //副程式:行星存檔
    //============================================
    public static void Planet_Save(int Number , string[,] Save_String , string Name,string EName,string Represent,string Influence,string Description){
		PlayerPrefs.SetString (Save_String[Number,0] , Name); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,1] , EName); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,2] , Represent); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,3] , Influence); 
		PlayerPrefs.Save (); 
		PlayerPrefs.SetString (Save_String[Number,4] , Description); 
		PlayerPrefs.Save (); 

	}

    //============================================
    //副程式:行星讀檔
    //============================================
    public static void Planet_Save_Write(int Nubmer ){

		string Planet = PlayerPrefs.GetString (Planet_Save_String [Nubmer, 0], "太陽"); 
		string EName =PlayerPrefs.GetString (Planet_Save_String [Nubmer, 1], "Sun"); 
		string Represent = PlayerPrefs.GetString (Planet_Save_String [Nubmer, 2], "活力、能量、光、意志、外在形象、創造力、表現、陽性功能、爸爸的影響"); 
		string Influence = PlayerPrefs.GetString (Planet_Save_String [Nubmer, 3], "個人意識、表現方式、個人意志、自我的人事物"); 
		string Description = PlayerPrefs.GetString (Planet_Save_String [Nubmer, 4], "個性"); 
		//放入資料
		DataManage.Planet [Nubmer] = new Planet_Class ( Planet , EName , Represent , Influence , Description);
	}

}

