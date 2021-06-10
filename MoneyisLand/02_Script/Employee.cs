//撰寫類別: 經理 警衛 顧問
using UnityEngine;
using System.Collections;

//員工基本資料============================================================================
public class Employee : MonoBehaviour {

  //宣告變數==========================================================
	//ID
	public byte ID;
	//姓名
	public string Name = " ";
	//能力
	public byte   Ability = 1;
	//薪水
	public uint    Salary = 0;
	//僱用費用
	public uint    HireSalary = 0;
	//自我介紹
	public string Introduce = " ";
	//僱用狀態(true:已僱用 fasle:未僱用)
	public bool   Hire = false;
	//出勤狀態(true:出勤中 fasle:未出勤)
	public bool   Work = false;
	//工作地點(0:麵包師傅區域 1:音樂人區域 2:科技新貴區域 3:機工區域 4:銀行家區域)
	public int  WorkPlace;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  //宣告建構子1號(給經理,警衛繼承)=======================================================
	public Employee(byte ID , string Name , byte Ability , uint Salary , uint HireSalary , string Introduce , bool Hire , bool Work , int WorkPlace){
		this.ID = ID;
		this.Name = Name;
		this.Ability = Ability;
		this.Salary = Salary;
		this.HireSalary = HireSalary;
		this.Introduce = Introduce;
		this.Hire = Hire;
		this.Work = Work;
		this.WorkPlace = WorkPlace;
	}

  //宣告建構子2號(給顧問繼承)=======================================================
	public Employee(byte ID , string Name , byte Ability , uint Salary , uint HireSalary , string Introduce , bool Hire , bool Work , byte FoodNumber,byte MusicNumber , byte TechnologyNumber , byte FactoryNumber , byte EconomicNumber){
		this.ID = ID;
		this.Name = Name;
		this.Ability = Ability;
		this.Salary = Salary;
		this.HireSalary = HireSalary;
		this.Introduce = Introduce;
		this.Hire = Hire;
		this.Work = Work;
	}

  //副程式獲取=======================================================
	//副程式:獲取ID
	public byte GetID(){
		return this.ID;
	}
	//副程式:獲取名字
	public string GetName(){
		return this.Name;
	}
	//副程式:獲取能力
	public byte GetAbility(){
		return this.Ability;
	}
	//副程式:獲取薪水
	public uint GetSalary(){
		return this.Salary;
	}
	//副程式:獲取僱用費用
	public uint GetHireSalary(){
		return this.HireSalary;
	}
	//副程式:自我介紹
	public string GetIntroduce(){
		return this.Introduce;
	}
	//副程式:獲取僱用狀態
	public bool GetHire(){
		return this.Hire;
	}
	//副程式:獲取出勤狀態
	public bool GetWork(){
		return this.Work;
	}
	//副程式:獲取工作地點
	public int GetWorkPlace(){
		return this.WorkPlace;
	}

  //副程式設定=======================================================
	//副程式:設定僱用狀態
	public void SetHire(bool Hirebool){
		this.Hire = Hirebool;
	}
	//副程式:設定出勤狀態
	public void SetWork(bool Workbool){
		this.Work = Workbool;
	}
	//副程式:設定工作地點
	public void SetWorkPlace(int WorkPlace){
		this.WorkPlace = WorkPlace;
	}
		

}//Employee===================================================================================

//類別:經理=================================================================================
public class ManageClass:Employee{
  //繼承建構子
	public ManageClass(byte ID , string Name , byte Ability , uint Salary , uint HireSalary , string Introduce , bool Hire , bool Work , int WorkPlace):base(ID , Name ,  Ability ,  Salary ,  HireSalary ,  Introduce , Hire ,  Work , WorkPlace){
		
	}

  //副程式存檔========================================================
	//僱用狀態(true:已僱用 fasle:未僱用)
	public void Save_Hire(){
		byte HireSave;
		if (GetHire())
			HireSave = 1;
		else
			HireSave = 0;
		PlayerPrefs.SetInt (MainState.Save_Manage_Hire[GetID()] , HireSave);
		PlayerPrefs.Save (); 

	}

	//出勤狀態(true:出勤中 fasle:未出勤)
	public void Save_Work(){
		byte WorkSave;
		if (GetWork())
			WorkSave = 1;
		else
			WorkSave = 0;
		PlayerPrefs.SetInt (MainState.Save_Manage_Work[GetID()] , WorkSave);
		PlayerPrefs.Save (); 
	}

	//工作地點
	public void Save_WorkPlace(){
		PlayerPrefs.SetInt (MainState.Save_Manage_WorkPlace[GetID()] , GetWorkPlace());
		PlayerPrefs.Save (); 
	}

	//副程式讀檔========================================================
	//僱用狀態(true:已僱用 fasle:未僱用)
	public void Write_Hire(){
		
		int HireSave = PlayerPrefs.GetInt(MainState.Save_Manage_Hire[GetID()] , 0); 

		if (HireSave == 1)
			SetHire (true);
		else
			SetHire (false);

	}

	//出勤狀態(true:出勤中 fasle:未出勤)
	public void Write_Work(){

		int WorkSave = PlayerPrefs.GetInt(MainState.Save_Manage_Work[GetID()] , 0); 

		if (WorkSave == 1)
			SetWork (true);
		else
			SetWork (false);
	}

	//工作地點
	public void Write_WorkPlace(){
		int WorkPlaceSave = PlayerPrefs.GetInt(MainState.Save_Manage_WorkPlace[GetID()] , 0); 
		SetWorkPlace(WorkPlaceSave);
	}

}
//類別:經理=================================================================================

//類別:警衛=================================================================================
public class SecurityClass:Employee{
	//繼承建構子
	public SecurityClass(byte ID , string Name , byte Ability , uint Salary , uint HireSalary , string Introduce , bool Hire , bool Work , int WorkPlace):base(ID ,  Name ,  Ability ,  Salary ,  HireSalary ,  Introduce , Hire ,  Work , WorkPlace){

	}

	//副程式存檔========================================================
	//僱用狀態(true:已僱用 fasle:未僱用)
	public void Save_Hire(){
		byte HireSave;
		if (GetHire())
			HireSave = 1;
		else
			HireSave = 0;
		PlayerPrefs.SetInt (MainState.Save_Security_Hire[GetID()] , HireSave);
		PlayerPrefs.Save (); 

	}

	//出勤狀態(true:出勤中 fasle:未出勤)
	public void Save_Work(){
		byte WorkSave;
		if (GetWork())
			WorkSave = 1;
		else
			WorkSave = 0;
		PlayerPrefs.SetInt (MainState.Save_Security_Work[GetID()] , WorkSave);
		PlayerPrefs.Save (); 
	}

	//工作地點
	public void Save_WorkPlace(){
		PlayerPrefs.SetInt (MainState.Save_Security_WorkPlace[GetID()] , GetWorkPlace());
		PlayerPrefs.Save (); 
	}

	//副程式讀檔========================================================
	//僱用狀態(true:已僱用 fasle:未僱用)
	public void Write_Hire(){

		int HireSave = PlayerPrefs.GetInt(MainState.Save_Security_Hire[GetID()] , 0); 

		if (HireSave == 1)
			SetHire (true);
		else
			SetHire (false);

	}

	//出勤狀態(true:出勤中 fasle:未出勤)
	public void Write_Work(){

		int WorkSave = PlayerPrefs.GetInt(MainState.Save_Security_Work[GetID()] , 0); 

		if (WorkSave == 1)
			SetWork (true);
		else
			SetWork (false);
	}

	//工作地點
	public void Write_WorkPlace(){
		int WorkPlaceSave = PlayerPrefs.GetInt(MainState.Save_Security_WorkPlace[GetID()] , 0); 
		SetWorkPlace(WorkPlaceSave);
	}

}
//類別:警衛=================================================================================

//類別:顧問=================================================================================
public class ConsultantClass : Employee{

  //宣告變數********************************************************************************
	//支援能力:烹飪
	private byte FoodNumber = 0;
	//支援能力:音樂
	private byte MusicNumber = 0;
	//支援能力:科技
	private byte TechnologyNumber = 0;
	//支援能力:機工
	private byte FactoryNumber = 0;
	//支援能力:金融
	private byte EconomicNumber = 0;

	//繼承建構子
	public ConsultantClass(byte ID , string Name , byte Ability , uint Salary , uint HireSalary , string Introduce , bool Hire , bool Work , byte FoodNumber,byte MusicNumber , byte TechnologyNumber , byte FactoryNumber , byte EconomicNumber):base(ID ,  Name ,  Ability ,  Salary ,  HireSalary ,  Introduce , Hire ,  Work , FoodNumber , MusicNumber , TechnologyNumber , FactoryNumber , EconomicNumber){
		this.ID = ID;
		this.Name = Name;
		this.Ability = Ability;
		this.Salary = Salary;
		this.HireSalary = HireSalary;
		this.Introduce = Introduce;
		this.Hire = Hire;
		this.Work = Work;

		this.FoodNumber = FoodNumber;
		this.MusicNumber = MusicNumber;
		this.TechnologyNumber = TechnologyNumber;
		this.FactoryNumber = FactoryNumber;
		this.EconomicNumber = EconomicNumber;
	}
		
	//副程式:獲取支援能力:烹飪********************************************************************************
	public byte GetFoodNumber(){
		return this.FoodNumber;
	}
	//副程式:獲取支援能力:音樂********************************************************************************
	public byte GetMusicNumber(){
		return this.MusicNumber;
	}
	//副程式:獲取支援能力:科技********************************************************************************
	public byte GetTechnologyNumber(){
		return this.TechnologyNumber;
	}
	//副程式:獲取支援能力:機工********************************************************************************
	public byte GetFactoryNumber(){
		return this.FactoryNumber;
	}
	//副程式:獲取支援能力:金融********************************************************************************
	public byte GetEconomicNumber(){
		return this.EconomicNumber;
	}
		
	//副程式設定*********************************************************************************************
	//副程式:設定支援能力:烹飪
	public void SetFoodNumber(byte FoodNumber){
		this.FoodNumber = FoodNumber;
	}
	//副程式:設定支援能力:音樂
	public void SetMusicNumber(byte MusicNumber){
		this.MusicNumber = MusicNumber;
	}
	//副程式:設定支援能力:科技
	public void SetTechnologyNumber(byte TechnologyNumber){
		this.TechnologyNumber = TechnologyNumber;
	}
	//副程式:設定支援能力:機工
	public void SetFactoryNumber(byte FactoryNumber){
		this.FactoryNumber = FactoryNumber;
	}
	//副程式:設定支援能力:金融
	public void SetEconomicNumber(byte EconomicNumber){
		this.EconomicNumber = EconomicNumber;
	}

	//副程式存檔========================================================
	//僱用狀態(true:已僱用 fasle:未僱用)
	public void Save_Hire(){
		byte HireSave;
		if (GetHire())
			HireSave = 1;
		else
			HireSave = 0;
		PlayerPrefs.SetInt (MainState.Save_Consultant_Hire[GetID()] , HireSave);
		PlayerPrefs.Save (); 

	}

		
	//副程式讀檔========================================================
	//僱用狀態(true:已僱用 fasle:未僱用)
	public void Write_Hire(){

		int HireSave = PlayerPrefs.GetInt(MainState.Save_Consultant_Hire[GetID()] , 0); 

		if (HireSave == 1)
			SetHire (true);
		else
			SetHire (false);

	}


		

}//顧問============================================================================================ 
	
