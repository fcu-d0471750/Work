using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class Question : MonoBehaviour {


	public GameObject people;
	public GameObject weapon;
	public GameObject hospital;
	public GameObject food;
	public GameObject money;
	//public GameObject gobutton;
	public GameObject obtainbutton;
	public GameObject Placeimage;        //宣告Placeimage物件
	public int yn ;                  //是否已經按下按鈕 true:已按下 false: 未按下
	public Text peopleText= null;
	public Text weaponText= null;
	public Text hospitalText= null;
	public Text foodText= null;
	public Text moneyText= null; 
	//public Text gotext= null;
	public Text obtaintext= null;
	public AudioSource ButtonMusic;      //按扭音效

	// Use this for initialization
	void Start () {
		people.SetActive(false);   //隱藏按鈕
		weapon.SetActive(false);   //隱藏按鈕;
		hospital.SetActive(false);   //隱藏按鈕;
		food.SetActive(false);   //隱藏按鈕;
		money.SetActive(false);   //隱藏按鈕;
//		gobutton.SetActive(false);   //隱藏按鈕;
		obtainbutton.SetActive(false);   //隱藏按鈕;
		Placeimage.SetActive(false);   //隱藏按鈕;

		peopleText.text= "";
		weaponText.text= "";
		hospitalText.text= "";
		foodText.text= "";
		moneyText.text= "";
	//	gotext.text= "";
		obtaintext.text= "";
	}
	
	// Update is called once per frame
	void Update () {
	   
		//按鍵輸入*****************************************************
		if(Input.GetKeyDown(KeyCode.Q))push();



	}

	//按下按鈕*******************************************************************
	public void push()
	{
		//已按下
		if (yn == 1) {
			ButtonMusic.Play ();
			people.SetActive (false);   //隱藏按鈕
			weapon.SetActive (false);   //隱藏按鈕;
			hospital.SetActive (false);   //隱藏按鈕;
			food.SetActive (false);   //隱藏按鈕;
			money.SetActive (false);   //隱藏按鈕;
			//gobutton.SetActive (false);   //隱藏按鈕;
			obtainbutton.SetActive (false);   //隱藏按鈕;
			Placeimage.SetActive(false);   //隱藏按鈕;

			peopleText.text = "";
			weaponText.text = "";
			hospitalText.text = "";
			foodText.text = "";
			moneyText.text = "";
			//gotext.text = "";
			obtaintext.text = "";

			yn = 0;
		} 

		//未按下
		else {
			ButtonMusic.Play ();
			people.SetActive (true);   //隱藏按鈕
			weapon.SetActive (true);   //隱藏按鈕;
			hospital.SetActive (true);   //隱藏按鈕;
			food.SetActive (true);   //隱藏按鈕;
			money.SetActive (true);   //隱藏按鈕;
			//gobutton.SetActive (true);   //隱藏按鈕;
			obtainbutton.SetActive (true);   //隱藏按鈕;
			Placeimage.SetActive(true);   //隱藏按鈕;

			peopleText.text = "人口";
			weaponText.text = "武器";
			hospitalText.text = "醫療";
			foodText.text = "食物";
			moneyText.text = "金錢";
			//gotext.text = "出航";
			obtaintext.text = "收穫";

			yn = 1;
		}	

	}

}
