//類別:行星
using UnityEngine;
using System.Collections;

public class Planet_Class : MonoBehaviour {

    //============================================
    //屬性==============================================================
    //============================================
    //行星名稱
    string Name;
	//行星英文名稱
	string EName;
	//行星代表
	string Represent;
	//行星影響
	string Influence;
	//行星描述
	string Description;

	

    //============================================
    //方法=============================================================
    //============================================
    //建構子***********************************************
    public Planet_Class(string Name,string EName,string Represent,string Influence,string Description){
		this.Name = Name;
		this.EName = EName;
		this.Represent = Represent;
		this.Influence = Influence;
		this.Description = Description;
	}

    //============================================
    //取值********************************************************
    //============================================
    //行星名稱
    public string Getter_Name(){
		return this.Name;
	}
	//行星英文名稱
	public string Getter_EName(){
		return this.EName;
	}
	//行星代表
	public string Getter_Represent(){
		return this.Represent;
	}
	//行星影響
	public string Getter_Influence(){
		return this.Influence;
	}
	//行星描述
	public string Getter_Description(){
		return this.Description;
	}

    //============================================
    //設定值******************************************************
    //============================================
    //行星名稱
    public void Setter_Name(string Name){
		this.Name = Name;
	}
	//行星英文名稱
	public void Setter_EName(string EName){
		this.EName = EName;
	}
	//行星代表
	public void Setter_Represent(string Represent){
		this.Represent = Represent;
	}
	//行星影響
	public void Setter_Influence(string Influence){
		this.Influence = Influence;
	}
	//行星描述
	public void Setter_Description(string Description){
		this.Description = Description;
	}


}
