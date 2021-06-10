//類別:宮位
using UnityEngine;
using System.Collections;

public class Palace_Class : MonoBehaviour {

    //============================================
    //屬性=====================================================
    //============================================
    //宮位名稱
    string Palace_Name;
	//宮位號碼
	string Palace_Number;
	//宮位星座
	string Palace_Constellations;
	//宮位守護星
	string Palace_Planet;
	//宮位描述
	string Palace_Description;


	

    //============================================
    //方法=====================================================
    //============================================
    //建構子****************************************************
    public Palace_Class(string Palace_Name,string Palace_Number,string Palace_Constellations,string Palace_Planet,string Palace_Description){
		this.Palace_Name = Palace_Name;
		this.Palace_Number = Palace_Number;
		this.Palace_Constellations = Palace_Constellations;
		this.Palace_Planet = Palace_Planet;
		this.Palace_Description = Palace_Description;
		
	}

    //============================================
    //取值******************************************************
    //============================================
    //宮位名稱
    public string Getter_Palace_Name(){
		return Palace_Name;
	}
	//宮位號碼
	public string Getter_Palace_Number(){
		return Palace_Number;
	}
	//宮位星座
	public string Getter_Palace_Constellations(){
		return Palace_Constellations;
	}
	//宮位守護星
	public string Getter_Palace_Planet(){
		return Palace_Planet;
	}
	//宮位描述
	public string Getter_Palace_Description(){
		return Palace_Description;
	}

    //============================================
    //設定值******************************************************
    //============================================
    //宮位名稱
    public void Setter_Palace_Name(string Palace_Name){
		this.Palace_Name = Palace_Name;
	}
	//宮位號碼
	public void Setter_Palace_Number(string Palace_Number){
		this.Palace_Number = Palace_Number;
	}
	//宮位星座
	public void Setter_Palace_Constellations(string Palace_Constellations){
		this.Palace_Constellations = Palace_Constellations;
	}
	//宮位守護星
	public void Setter_Palace_Planet(string Palace_Planet){
		this.Palace_Planet = Palace_Planet;
	}
	//宮位描述
	public void Setter_Palace_Description(string Palace_Description){
		this.Palace_Description = Palace_Description;
	}
}
