//撰寫類別: 店鋪
using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour {

  //宣告變數
	//ID
	public byte ID;
	//店鋪名稱
	public string Name;
	//預期利潤
	public uint Price;
	//置產價格
	public uint BuyPrice;
	//擁有狀態 true:已擁有 false:未擁有
	public bool OwnBool;
	//投資狀態 true:已投資 false:未投資
	public bool InvestBool;
	//店鋪分類 1:烹飪 2:音樂 3:科技 4:機工 5:金融
	public byte Classification;
	//店鋪等級
	public int Level;
	//店鋪經驗
	public float LevelEx;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//宣告建構子=======================================================
	public Store(byte ID , string Name , uint Price , uint BuyPrice , bool OwnBool , bool InvestBool , byte Classification , byte Level , float LevelEx){
		this.ID = ID;
		this.Name = Name;
		this.Price = Price;
		this.BuyPrice = BuyPrice;
		this.OwnBool = OwnBool;
		this.InvestBool = InvestBool;
		this.Classification = Classification;
		this.Level = Level;
		this.LevelEx = LevelEx;
	}

  //副程式獲取=======================================================
	//副程式:獲取ID
	public byte GetID(){
		return this.ID;
	}
	//副程式:獲取店鋪名稱
	public string GetName(){
		return this.Name;
	}
	//副程式:獲取預期利潤
	public uint GetPrice(){
		return this.Price;
	}
	//副程式:獲取置產價格
	public uint GetBuyPrice(){
		return this.BuyPrice;
	}
	//副程式:擁有狀態
	public bool GetOwnBool(){
		return this.OwnBool;
	}
	//副程式:獲取投資狀態
	public bool GetInvestBool(){
		return this.InvestBool;
	}
	//副程式:獲取店鋪分類
	public byte GetClassification(){
		return this.Classification;
	}
	//副程式:獲取店鋪等級
	public int GetLevel(){
		return this.Level;
	}
	//副程式:獲取店鋪經驗
	public float GetLevelEx(){
		return this.LevelEx;
	}
  //副程式設定=======================================================
	//副程式:設定擁有狀態
	public void SetOwnBool(bool Ownbool){
		this.OwnBool = Ownbool;
	}
	//副程式:設定投資狀態
	public void SetInvestBool(bool Investbool){
		this.InvestBool = Investbool;
	}
	//副程式:設定店鋪等級
	public void SetLevel(int Level){
		this.Level = Level;
	}
	//副程式:設定店鋪經驗
	public void SetLevelEx(float LevelEx){
		this.LevelEx = LevelEx;
	}

	//副程式存檔========================================================
	//擁有狀態(true:已擁有 false:未擁有)
	public void Save_OwnBool( string[] NameArray ){
		byte OwnSave;
		if (GetOwnBool())
			OwnSave = 1;
		else
			OwnSave = 0;
		PlayerPrefs.SetInt (NameArray[GetID()] , OwnSave);
		PlayerPrefs.Save (); 

	}

	//投資狀態(true:已投資 false:未投資)
	public void Save_InvestBool( string[] NameArray ){
		byte InvestSave;
		if (GetInvestBool())
			InvestSave = 1;
		else
			InvestSave = 0;
		PlayerPrefs.SetInt (NameArray[GetID()] , InvestSave);
		PlayerPrefs.Save (); 
	}

	//店鋪等級
	public void Save_Level( string[] NameArray ){
		PlayerPrefs.SetInt (NameArray[GetID()] , GetLevel());
		PlayerPrefs.Save (); 
	}

	//店鋪經驗
	public void Save_LevelEx( string[] NameArray ){
		PlayerPrefs.SetFloat (NameArray[GetID()] , GetLevelEx() );
		PlayerPrefs.Save (); 
	}

	//副程式讀檔========================================================
	//僱用狀態(true:已擁有 false:未擁有)
	public void Write_OwnBool( string[] NameArray ){

		int OwnSave = PlayerPrefs.GetInt(NameArray[GetID()] , 0); 

		if (OwnSave == 1)
			SetOwnBool (true);
		else
			SetOwnBool (false);

	}

	//出勤狀態(true:已投資 false:未投資)
	public void Write_InvestBool( string[] NameArray ){

		int InvestSave = PlayerPrefs.GetInt(NameArray[GetID()] , 0); 

		if (InvestSave == 1)
			SetInvestBool (true);
		else
			SetInvestBool (false);
	}

	//店鋪等級
	public void Write_Level( string[] NameArray ){
		int LevelSave = PlayerPrefs.GetInt(NameArray[GetID()] , 1); 
		SetLevel(LevelSave);
	}

	//店鋪經驗
	public void Write_LevelEx( string[] NameArray ){
		float LevelExSave = PlayerPrefs.GetFloat(NameArray[GetID()] , 0.0f); 
		SetLevelEx(LevelExSave);
	}


}
