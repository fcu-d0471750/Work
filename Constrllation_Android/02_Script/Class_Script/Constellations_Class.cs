//類別:星座
using UnityEngine;
using System.Collections;

public class Constellations_Class : MonoBehaviour {

    //============================================
    //屬性=====================================================
    //============================================
    //星座名稱
    string Name;
	//星座英文名稱
	string EName;
	//星座開始月份
	int Month1;
	//星座開始日期
	int Day1;
	//星座結束月份
	int Month2;
	//星座結束日期
	int Day2;
	//星座分類1
	string Class1;
	//星座分類2
	string Class2;
	//星座分類3
	string Class3;
	//星座節氣
	string SolarTerms;
	//星座守護星
	string Planet;
	//星座守護神
	string God;
	//星座黃道十二宮
	string Zodiac;
	//星座宮位
	string Palace;
	//星座符號
	string Symbol;
	//星座優點
	string Advantage;
	//星座缺點
	string Disadvantage;
	//星座個人特質
	string Personality;


	

    //============================================
    //方法=====================================================
    //============================================
    public Constellations_Class(){
		
	}

	//建構子**********************************
	public Constellations_Class(string Name,string EName,int Month1,int Day1,int Month2,int Day2,string Class1,string Class2,string Class3,string SolarTerms,string Planet,string God,string Zodiac,string Palace,string Symbol,string Advantage,string Disadvantage,string Personality){
		this.Name = Name;
		this.EName = EName;
		this.Month1 = Month1;
		this.Day1 = Day1;
		this.Month2 = Month2;
		this.Day2 = Day2;
		this.Class1 = Class1;
		this.Class2 = Class2;
		this.Class3 = Class3;
		this.SolarTerms = SolarTerms;
		this.Planet = Planet;
		this.God = God;
		this.Zodiac = Zodiac;
		this.Palace = Palace;
		this.Symbol = Symbol;
		this.Advantage = Advantage;
		this.Disadvantage = Disadvantage;
		this.Personality = Personality;
	}

    //============================================
    //取值Getter================================================
    //============================================
    //星座名稱
    public string Getter_Name(){
		return this.Name;
	}
	//星座英文名稱
	public string Getter_EName(){
		return this.EName;
	}
	//星座開始月份
	public int Getter_Month1(){
		return this.Month1;
	}
	//星座開始日期
	public int Getter_Day1(){
		return this.Day1;

	}
	//星座結束月份
	public int Getter_Month2(){
		return this.Month2;

	}
	//星座結束日期
	public int Getter_Day2(){
		return this.Day2;
	}
	//星座分類1
	public string Getter_Class1(){
		return this.Class1;

	}
	//星座分類2
	public string Getter_Class2(){
		return this.Class2;

	}
	//星座分類3
	public string Getter_Class3(){
		return this.Class3;

	}
	//星座節氣
	public string Getter_SolarTerms(){
		return this.SolarTerms;

	}
	//星座守護星
	public string Getter_Planet(){
		return this.Planet;

	}
	//星座守護神
	public string Getter_God(){
		return this.God;

	}
	//星座黃道十二宮
	public string Getter_Zodiac(){
		return this.Zodiac;

	}
	//星座宮位
	public string Getter_Palace(){
		return this.Palace;

	}
	//星座符號
	public string Getter_Symbol(){
		return this.Symbol;

	}
	//星座優點
	public string Getter_Advantage(){
		return this.Advantage;

	}
	//星座缺點
	public string Getter_Disadvantage(){
		return this.Disadvantage;

	}
	public string Getter_Personality(){
		return this.Personality;
	}

    //============================================
    //設定值Setter===========================================
    //============================================
    //星座名稱
    public void Setter_Name(string Name){
		this.Name = Name;
	}
	//星座英文名稱
	public void Setter_EName(string EName){
		this.EName = EName;
	}
	//星座開始月份
	public void Setter_Month1(int Month1){
		this.Month1 = Month1;
	}
	//星座開始日期
	public void Setter_Day1(int Day1){
		this.Day1 = Day1;
	}
	//星座結束月份
	public void Setter_Month2(int Month2){
		this.Month2 = Month2;
	}
	//星座結束日期
	public void Setter_Day2(int Day2){
		this.Day2 = Day2;
	}
	//星座分類1
	public void Setter_Class1(string Class1){
		this.Class1 = Class1;
	}
	//星座分類2
	public void Setter_Class2(string Class2){
		this.Class2 = Class2;
	}
	//星座分類3
	public void Setter_Class3(string Class3){
		this.Class3 = Class3;
	}
	//星座節氣
	public void Setter_SolarTerms(string SolarTerms){
		this.SolarTerms = SolarTerms;
	}
	//星座守護星
	public void Setter_Planet(string Planet){
		this.Planet = Planet;
	}
	//星座守護神
	public void Setter_God(string God){
		this.God = God;
	}
	//星座黃道十二宮
	public void Setter_Zodiac(string Zodiac){
		this.Zodiac = Zodiac;
	}
	//星座宮位
	public void Setter_Palace(string Palace){
		this.Palace = Palace;
	}
	//星座符號
	public void Setter_Symbol(string Symbol){
		this.Symbol = Symbol;
	}
	//星座優點
	public void Setter_Advantage(string Advantage){
		this.Advantage = Advantage;
	}
	//星座缺點
	public void Setter_Disadvantage(string Disadvantage){
		this.Disadvantage = Disadvantage;
	}
	public void Setter_Personality(string Personality){
		this.Personality = Personality;
	}
}
