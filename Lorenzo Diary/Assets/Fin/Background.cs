//背景圖片
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class Background : MonoBehaviour {

	//宣告變數
	public GameObject House0;
	public GameObject House1;
	public GameObject House2;
	public GameObject House3;

	public GameObject Factory0;
	public GameObject Factory1;
	public GameObject Factory2;
	public GameObject Factory3;

	public GameObject Hospital0;
	public GameObject Hospital1;
	public GameObject Hospital2;
	public GameObject Hospital3;

	public GameObject Food0;
	public GameObject Food1;
	public GameObject Food2;
	public GameObject Food3;

	public GameObject Money0;
	public GameObject Money1;
	public GameObject Money2;
	public GameObject Money3;

	// Use this for initialization
	void Start () {

		//房子===========================================================================================================
		if(Main.Apeople==0) 
		{
			House0.SetActive(true);
			House1.SetActive(false);
			House2.SetActive(false);
			House3.SetActive(false);
		}
		else if(Main.Apeople==1)
		{
			House0.SetActive(true);
			House1.SetActive(true);
			House2.SetActive(false);
			House3.SetActive(false);
		}
		else if(Main.Apeople==2)
		{
			House0.SetActive(true);
			House1.SetActive(true);
			House2.SetActive(true);
			House3.SetActive(false);
		}
		else if(Main.Apeople==3)
		{
			House0.SetActive(true);
			House1.SetActive(true);
			House2.SetActive(true);
			House3.SetActive(true);
		}

		//工廠==================================================================================================================
		if (Main.Aweapon == 0) 
		{
			Factory0.SetActive (true);
			Factory1.SetActive (false);
			Factory2.SetActive (false);
			Factory3.SetActive (false);
		}
		else if (Main.Aweapon == 1)
		{
			Factory0.SetActive(true);
			Factory1.SetActive(true);
			Factory2.SetActive(false);
			Factory3.SetActive(false);
		}
		else if (Main.Aweapon == 2)
		{
			Factory0.SetActive(true);
			Factory1.SetActive(true);
			Factory2.SetActive(true);
			Factory3.SetActive(false);
		}
		else if (Main.Aweapon == 3)
		{
			Factory0.SetActive(true);
			Factory1.SetActive(true);
			Factory2.SetActive(true);
			Factory3.SetActive(true);
		}

		//醫院=======================================================================================================================
		if (Main.Ahospital == 0) 
		{
			Hospital0.SetActive (true);
			Hospital1.SetActive (false);
			Hospital2.SetActive (false);
			Hospital3.SetActive (false);
		}
		else if (Main.Ahospital == 1)
		{
			Hospital0.SetActive(true);
			Hospital1.SetActive(true);
			Hospital2.SetActive(false);
			Hospital3.SetActive(false);
		}
		else if (Main.Ahospital == 2)
		{
			Hospital0.SetActive(true);
			Hospital1.SetActive(true);
			Hospital2.SetActive(true);
			Hospital3.SetActive(false);
		}
		else if (Main.Ahospital == 3)
		{
			Hospital0.SetActive(true);
			Hospital1.SetActive(true);
			Hospital2.SetActive(true);
			Hospital3.SetActive(true);
		}
		//農田=======================================================================================================================
		if (Main.Afood == 0) 
		{
			Food0.SetActive (true);
			Food1.SetActive (false);
			Food2.SetActive (false);
			Food3.SetActive (false);
		}
		else if (Main.Afood == 1)
		{
			Food0.SetActive(true);
			Food1.SetActive(true);
			Food2.SetActive(false);
			Food3.SetActive(false);
		}
		else if (Main.Afood == 2)
		{
			Food0.SetActive(true);
			Food1.SetActive(true);
			Food2.SetActive(true);
			Food3.SetActive(false);
		}
		else if (Main.Afood == 3)
		{
			Food0.SetActive(true);
			Food1.SetActive(true);
			Food2.SetActive(true);
			Food3.SetActive(true);
		}
		//礦場=======================================================================================================================
		if (Main.Amoney == 0) 
		{
			Money0.SetActive (true);
			Money1.SetActive (false);
			Money2.SetActive (false);
			Money3.SetActive (false);
		}
		else if (Main.Amoney == 1)
		{
			Money0.SetActive(true);
			Money1.SetActive(true);
			Money2.SetActive(false);
			Money3.SetActive(false);
		}
		else if (Main.Amoney == 2)
		{
			Money0.SetActive(true);
			Money1.SetActive(true);
			Money2.SetActive(true);
			Money3.SetActive(false);
		}
		else if (Main.Amoney == 3)
		{
			Money0.SetActive(true);
			Money1.SetActive(true);
			Money2.SetActive(true);
			Money3.SetActive(true);
		}
	}//Start結束
	
	// Update is called once per frame
	void Update () {
	   
	}
}
