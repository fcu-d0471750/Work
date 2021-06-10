//撰寫類別: 區域
using UnityEngine;
using System.Collections;

public class AreaClass : MonoBehaviour {

	//宣告變數
	//ID
	public byte ID;
	//區域名稱
	public string AreaName;
	//總預期利潤
	public ulong Price; 
	//佔有率
	public float Present;
	//可否開始經營狀態 true:可經營 fasle:不可經營
	public bool Manage;
	//回收時間(0(等待) ~ 100(可回收) )
	public float ManageTime;
	//擁有店鋪數
	public int StoreNumber;
	//區域景氣
	public float EconomyBack;
	//區域治安
	public float SecurityBack;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	//宣告建構子=======================================================
	public AreaClass(byte ID , string AreaName , ulong Price , float Present , bool Manage , float ManageTime , int StoreNumber , float EconomyBack , float SecurityBack){
		this.ID = ID;
		this.AreaName = AreaName;
		this.Price = Price;
		this.Present = Present;
		this.Manage = Manage;
		this.ManageTime = ManageTime;
		this.StoreNumber = StoreNumber;
		this.EconomyBack = EconomyBack;
		this.SecurityBack = SecurityBack;
	}

	//副程式獲取=======================================================
	//副程式:獲取ID
	public byte GetID(){
		return this.ID;
	}
	//副程式:獲取店鋪名稱
	public string GetAreaName(){
		return this.AreaName;
	}
	//副程式:獲取總預期利潤
	public ulong GetPrice(){
		return this.Price;
	}
	//副程式:獲取佔有率
	public float GetPresent(){
		return this.Present;
	}
	//副程式:獲取可否開始經營狀態
	public bool GetManage(){
		return this.Manage;
	}
	//副程式:獲取回收時間
	public float GetManageTime(){
		return this.ManageTime;
	}
	//副程式:獲取擁有店鋪數
	public int GetStoreNumber(){
		return this.StoreNumber;
	}
	//副程式:獲取景氣
	public float GetEconomyBack(){
		return this.EconomyBack;
	}
	//副程式:獲取治安
	public float GetSecurityBack(){
		return this.SecurityBack;
	}

	//副程式設定=======================================================
	//副程式:設定總預期利潤
	public void SetPrice(ulong Price){
		this.Price = Price;
	}
	//副程式:設定佔有率
	public void SetPresent(float Present){
		this.Present = Present;
	}
	//副程式:設定可否開始經營狀態
	public void SetManage(bool Manage){
		this.Manage = Manage;
	}
	//副程式:設定回收時間
	public void SetManageTime(float ManageTime){
		this.ManageTime = ManageTime;
	}
	//副程式:設定擁有店鋪數
	public void SetStoreNumber(int StoreNumber){
		this.StoreNumber = StoreNumber;
	}
	//副程式:設定景氣
	public void SetEconomyBack(float EconomyBack){
		this.EconomyBack = EconomyBack;
	}
	//副程式:設定治安
	public void SetSecurityBack(float SecurityBack){
		this.SecurityBack = SecurityBack;
	}

	//副程式存檔========================================================
	//經營狀態(true:可經營 fasle:經營中)
	public void Save_Manage( string[] NameArray ){
		byte ManageSave;
		if (GetManage())
			ManageSave = 1;
		else
			ManageSave = 0;
		PlayerPrefs.SetInt (NameArray[GetID()] , ManageSave);
		PlayerPrefs.Save (); 

	}

	//回收時間
	public void Save_ManageTime( string[] NameArray ){
		PlayerPrefs.SetFloat (NameArray[GetID()] , GetManageTime());
		PlayerPrefs.Save (); 
	}

	//副程式讀檔========================================================
	//經營狀態(true:可經營 fasle:經營中)
	public void Write_Manage( string[] NameArray ){

		int ManageSave = PlayerPrefs.GetInt(NameArray[GetID()] , 0); 

		if (ManageSave == 1)
			SetManage (true);
		else
			SetManage (false);

	}

	//回收時間
	public void Write_ManageTime( string[] NameArray ){
		float ManageTimeSave = PlayerPrefs.GetFloat(NameArray[GetID()] , 1.0f); 
		SetManageTime(ManageTimeSave);
	}



}
