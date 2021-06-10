//分類法:類別
using UnityEngine;
using System.Collections;

public class Separate_Class_ : MonoBehaviour {

    //============================================
    //屬性******************************************
    //============================================

    //名稱
    string Name;
	//分類
	string Classification;
	//星座
	string Constellations;
	//描述
	string Description;

	

    //============================================
    //方法**************************************************
    //============================================
    //建構子
    public Separate_Class_(string Name,string Classification,string Constellations,string Description){
		this.Name = Name;
		this.Classification = Classification;
		this.Constellations = Constellations;
		this.Description = Description;

	}

    //============================================
    //取值******************************************************
    //============================================
    //名稱
    public string Getter_Name(){
		return this.Name;
	}
	//分類
	public string Getter_Classification(){
		return this.Classification;
	}
	//星座
	public string Getter_Constellations(){
		return this.Constellations;
	}
	//描述
	public string Getter_Description(){
		return this.Description;
	}

    //============================================
    //設定值******************************************************
    //============================================
    //名稱
    public void Setter_Name(string Name){
		this.Name = Name;
	}
	//分類
	public void Setter_Classification(string Classification){
		this.Classification = Classification;
	}
	//星座
	public void Setter_Constellations(string Constellations){
		this.Constellations = Constellations;
	}
	//描述
	public void Setter_NameDescription(string Description){
		this.Description = Description;
	}
}


/*

//分類法1:陰陽法=============================================================================================================================================
public class Two_Separate : Separate_Class_{
	//屬性**************************************************
	//分類1
	string Class1;
	//分類2
	string Class2;
	//星座1
	string Constellation1;
	//星座2
	string Constellation2;
	//描述1
	string Description1;
	//描述2
	string Description2;

	//方法**************************************************
	//建構子
	Two_Separate(string Name,string Class1,string Class2,string Constellation1,string Constellation2,string Description1,string Description2){
		this.Name = Name;
		this.Class1 = Class1;
		this.Class2 = Class2;
		this.Constellation1 = Constellation1;
		this.Constellation2 = Constellation2;
		this.Description1 = Description1;
		this.Description2 = Description2;
	}

	//取值******************************************************
	//分類1
	string Getter_Class1(){
		return this.Class1;
	}
	//分類2
	string Getter_Class2(){
		return this.Class2;
	}
	//星座1
	string Getter_Constellation1(){
		return this.Constellation1;
	}
	//星座2
	string Getter_Constellation2(){
		return this.Constellation2;
	}
	//描述1
	string Getter_Description1(){
		return this.Description1;
	}
	//描述2
	string Getter_Description2(){
		return this.Description2;
	}
	//設定值****************************************************
	//分類1
	void Setter_Class1(string Class1){
		this.Class1 = Class1;
	}
	//分類2
	void Setter_Class2(string Class2){
		this.Class2 = Class2;
	}
	//星座1
	void Setter_Constellation1(string Constellation1){
		this.Constellation1 = Constellation1;
	}
	//星座2
	void Setter_Constellation2(string Constellation2){
		this.Constellation2 = Constellation2;
	}
	//描述1
	void Setter_Description1(string Description1){
		this.Description1 = Description1;
	}
	//描述2
	void Setter_Description2(string Description2){
		this.Description2 = Description2;
	}

}


//分類法2:三分法=============================================================================================================================================
public class Three_Separate : Separate_Class_{
		//屬性**************************************************
		//分類1
		string Class1;
		//分類2
		string Class2;
		//分類3
		string Class3;
		//星座1
		string Constellation1;
		//星座2
		string Constellation2;
		//星座3
		string Constellation3;
		//描述1
		string Description1;
		//描述2
		string Description2;
		//描述3
		string Description3;

		//方法**************************************************
		//建構子
		Three_Separate(string Name,string Class1,string Class2,string Class3,string Constellation1,string Constellation2 ,string Constellation3,string Description1,string Description2,string Description3){
			this.Name = Name;
			this.Class1 = Class1;
			this.Class2 = Class2;
			this.Class3 = Class3;
			this.Constellation1 = Constellation1;
			this.Constellation2 = Constellation2;
			this.Constellation3 = Constellation3;
			this.Description1 = Description1;
			this.Description2 = Description2;
			this.Description3 = Description3;
		}

		//取值******************************************************
		//分類1
		string Getter_Class1(){
			return this.Class1;
		}
		//分類2
		string Getter_Class2(){
			return this.Class2;
		}
		//分類3
		string Getter_Class3(){
			return this.Class3;
		}
		//星座1
		string Getter_Constellation1(){
			return this.Constellation1;
		}
		//星座2
		string Getter_Constellation2(){
			return this.Constellation2;
		}
		//星座3
		string Getter_Constellation3(){
			return this.Constellation3;
		}
		//描述1
		string Getter_Description1(){
			return this.Description1;
		}
		//描述2
		string Getter_Description2(){
			return this.Description2;
		}
		//描述3
		string Getter_Description3(){
			return this.Description3;
		}
		//設定值****************************************************
		//分類1
		void Setter_Class1(string Class1){
			this.Class1 = Class1;
		}
		//分類2
		void Setter_Class2(string Class2){
			this.Class2 = Class2;
		}
		//分類3
		void Setter_Class3(string Class3){
			this.Class3 = Class3;
		}
		//星座1
		void Setter_Constellation1(string Constellation1){
			this.Constellation1 = Constellation1;
		}
		//星座2
		void Setter_Constellation2(string Constellation2){
			this.Constellation2 = Constellation2;
		}
		//星座3
		void Setter_Constellation3(string Constellation3){
			this.Constellation3 = Constellation3;
		}
		//描述1
		void Setter_Description1(string Description1){
			this.Description1 = Description1;
		}
		//描述2
		void Setter_Description2(string Description2){
			this.Description2 = Description2;
		}
		//描述3
		void Setter_Description3(string Description3){
			this.Description3 = Description3;
		}
			
}



//分類法3:四分法=============================================================================================================================================
public class Four_Separate : Separate_Class_{
	//屬性**************************************************
	//分類1
	string Class1;
	//分類2
	string Class2;
	//分類3
	string Class3;
	//分類4
	string Class4;
	//星座1
	string Constellation1;
	//星座2
	string Constellation2;
	//星座3
	string Constellation3;
	//星座4
	string Constellation4;
	//描述1
	string Description1;
	//描述2
	string Description2;
	//描述3
	string Description3;
	//描述4
	string Description4;

	//方法**************************************************
	//建構子
	Four_Separate(string Name,string Class1,string Class2,string Class3,string Class4,string Constellation1,string Constellation2,string Constellation3,string Constellation4,string Description1,string Description2,string Description3,string Description4){
		this.Name = Name;
		this.Class1 = Class1;
		this.Class2 = Class2;
		this.Class3 = Class3;
		this.Class4 = Class4;
		this.Constellation1 = Constellation1;
		this.Constellation2 = Constellation2;
		this.Constellation3 = Constellation3;
		this.Constellation4 = Constellation4;
		this.Description1 = Description1;
		this.Description2 = Description2;
		this.Description3 = Description3;
		this.Description4 = Description4;
	}

	//取值******************************************************
	//分類1
	string Getter_Class1(){
		return this.Class1;
	}
	//分類2
	string Getter_Class2(){
		return this.Class2;
	}
	//分類3
	string Getter_Class3(){
		return this.Class3;
	}
	//分類3
	string Getter_Class4(){
		return this.Class4;
	}
	//星座1
	string Getter_Constellation1(){
		return this.Constellation1;
	}
	//星座2
	string Getter_Constellation2(){
		return this.Constellation2;
	}
	//星座3
	string Getter_Constellation3(){
		return this.Constellation3;
	}
	//星座4
	string Getter_Constellation4(){
		return this.Constellation4;
	}
	//描述1
	string Getter_Description1(){
		return this.Description1;
	}
	//描述2
	string Getter_Description2(){
		return this.Description2;
	}
	//描述3
	string Getter_Description3(){
		return this.Description3;
	}
	//描述4
	string Getter_Description4(){
		return this.Description4;
	}
	//設定值****************************************************
	//分類1
	void Setter_Class1(string Class1){
		this.Class1 = Class1;
	}
	//分類2
	void Setter_Class2(string Class2){
		this.Class2 = Class2;
	}
	//分類3
	void Setter_Class3(string Class3){
		this.Class3 = Class3;
	}
	//分類3
	void Setter_Class4(string Class4){
		this.Class4 = Class4;
	}
	//星座1
	void Setter_Constellation1(string Constellation1){
		this.Constellation1 = Constellation1;
	}
	//星座2
	void Setter_Constellation2(string Constellation2){
		this.Constellation2 = Constellation2;
	}
	//星座3
	void Setter_Constellation3(string Constellation3){
		this.Constellation3 = Constellation3;
	}
	//星座4
	void Setter_Constellation4(string Constellation4){
		this.Constellation4 = Constellation4;
	}
	//描述1
	void Setter_Description1(string Description1){
		this.Description1 = Description1;
	}
	//描述2
	void Setter_Description2(string Description2){
		this.Description2 = Description2;
	}
	//描述3
	void Setter_Description3(string Description3){
		this.Description3 = Description3;
	}
	//描述4
	void Setter_Description4(string Description4){
		this.Description4 = Description4;
	}

}*/

