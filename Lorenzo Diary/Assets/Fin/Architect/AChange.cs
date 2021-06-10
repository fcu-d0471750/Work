//建造切換動畫
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class AChange : MonoBehaviour {

	//宣告變數************************************************
	public int number;                //建築物編號
	public GameObject House;          //房屋 1
	public GameObject Factory;        //工廠 2
	public GameObject Hospital;       //醫院 3
	public GameObject Food;           //農田 4
	public GameObject Money;          //礦場 5
	public Animation  AChangeAnimate; //建造切換動畫


	// Use this for initialization
	void Start () {
		number = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}

	//Upbutton
	public void Upbutton(){
		
		AChangeAnimate.Play();
		number = number + 1;
		if (number > 5) number = 1;

		House.SetActive (false);
		Factory.SetActive (false);
		Hospital.SetActive (false);
		Food.SetActive (false);
		Money.SetActive (false);
	}

	//Downbutton
	public void Downbutton(){
		
		AChangeAnimate.Play();
		number = number - 1;
		if (number < 1) number = 5;

		House.SetActive (false);
		Factory.SetActive (false);
		Hospital.SetActive (false);
		Food.SetActive (false);
		Money.SetActive (false);
	}

	//建築物
	public void Change(){
		if (number == 1) {
			House.SetActive (true);
			Factory.SetActive (false);
			Hospital.SetActive (false);
			Food.SetActive (false);
			Money.SetActive (false);
		}
		else if(number==2){
			House.SetActive (false);
			Factory.SetActive (true);
			Hospital.SetActive (false);
			Food.SetActive (false);
			Money.SetActive (false);
		}
		else if(number==3){
			House.SetActive (false);
			Factory.SetActive (false);
			Hospital.SetActive (true);
			Food.SetActive (false);
			Money.SetActive (false);
		}
		else if(number==4){
			House.SetActive (false);
			Factory.SetActive (false);
			Hospital.SetActive (false);
			Food.SetActive (true);
			Money.SetActive (false);
		}
		else if(number==5){
			House.SetActive (false);
			Factory.SetActive (false);
			Hospital.SetActive (false);
			Food.SetActive (false);
			Money.SetActive (true);
		}
	}

}
