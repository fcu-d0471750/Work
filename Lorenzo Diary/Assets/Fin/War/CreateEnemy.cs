//城門創立敵人
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class CreateEnemy : MonoBehaviour {
	//宣告變數===================================================================
	public GameObject EHolger;  // 宣告一個物件叫EHolger
	public GameObject EYuko;    // 宣告一個物件叫EYuko
	public GameObject EYuji;    // 宣告一個物件叫EYuji
	public GameObject EArcher1; // 宣告一個物件叫EArcher1
	public GameObject EArcher2; // 宣告一個物件叫EArcher2
	public GameObject EArcher3; // 宣告一個物件叫EArcher3
	public GameObject ECindy;   // 宣告一個物件叫ECindy
	public GameObject EMisaki;  // 宣告一個物件叫EMisaki
	public GameObject EToko;    // 宣告一個物件叫EToko
	public GameObject EnemyPart;// 敵方士兵生成粒子

	public float time; //宣告浮點數，名稱time
	int amount=5;    //敵人數量
	int EnemyCate=0; //敵人種類
	int EnemyCAteStart = 1; //敵人開始種類
	public static int Live=10;  //城門生命值
	public Text EDoorText;   //EDoorText 
	public static int infiniteStartLevel = 1;  //無限關卡等級



	// Use this for initialization
	void Start () {
		//amount = UnityEngine.Random.Range (1, 21);     //敵人數量 產生亂數(1~20);
		amount = WarSelect.amount;
		Live = WarSelect.Live;
		EDoorText.text = "" + Live;
		if (WarSelect.WarLevel <= 4) EnemyCAteStart = 1;
		else if(WarSelect.WarLevel>4 && WarSelect.WarLevel<=8) EnemyCAteStart = 4;
		else EnemyCAteStart = 7;

		//開啟無限關卡=========================
		if(WarSelect.infiniteStart){
			infiniteStartLevel = 1;
			amount = 9999;
			Live = WarSelect.Live;
			EDoorText.text = "∞";
			EnemyCAteStart = 1;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	 if(CreatePeople.WarStart){
			
		time += Time.deltaTime; //時間增加
			if (time>WarSelect.CreateTime && amount>0 && Live>0 && !CreatePeople.WarPause) {
			Vector3 pos = gameObject.transform.position + new Vector3 (-1.0f, 0.05f, 0);
			EnemyCate =  UnityEngine.Random.Range (EnemyCAteStart, WarSelect.EnemyCateMax); //產生亂數(1~WarSelect.EnemyCateMax-1)決定敵人種類
			if(EnemyCate==1){ pos = gameObject.transform.position + new Vector3 (0.0f, -0.02f, 0);
				Instantiate (EHolger, pos, gameObject.transform.rotation);}//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
				
			else if(EnemyCate==2)Instantiate (EYuko, pos, gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
			else if(EnemyCate==3)Instantiate (EYuji, pos, gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
			else if(EnemyCate==4)Instantiate (EArcher1, pos, gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
			else if(EnemyCate==5)Instantiate (EArcher2, pos, gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
			else if(EnemyCate==6){pos = gameObject.transform.position + new Vector3 (0.0f, 0.383f, 0); 
					              Instantiate (EArcher3, pos, gameObject.transform.rotation);}//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
			else if(EnemyCate==7)Instantiate (ECindy, pos, gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
			else if(EnemyCate==8)Instantiate (EMisaki, pos, gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)
			else if(EnemyCate==9)Instantiate (EToko, pos, gameObject.transform.rotation);//就是產生物件的指令Instantiate(物件, 初始位置,初始角度)

			Instantiate (EnemyPart, pos, gameObject.transform.rotation);	//敵方士兵生成粒子
			
			time = 0f; //時間歸零
			amount--;
		}
        
		

				
		if(Live>0)EDoorText.text = "" + Live; //城門生命值
		else EDoorText.text = "敗";

			//無限關卡==============================================================================
			if(WarSelect.infiniteStart){
				WarSelect.EnemyCateMax = ( infiniteStartLevel * 20) / 20;      //敵人種類隨時間增加
				if (WarSelect.EnemyCateMax >= 10) WarSelect.EnemyCateMax = 10; //敵人種類最多9種
				WarSelect.CreateTime = (3.0f / ((float)infiniteStartLevel/2.0f) );//敵人生成時間
				if(WarSelect.CreateTime<=0.1f)WarSelect.CreateTime = 0.1f;       //敵人生成時間最快0.1秒
				amount = 9999;
				Live = 9999;
				EDoorText.text = "∞";
			}
	
		}


	}

	//碰到城門
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Holger" || col.tag == "Yuko" || col.tag == "Yuji" || col.tag == "Archer1"  || col.tag == "Archer2" || col.tag == "Archer3"|| col.tag == "Cindy" || col.tag == "Misaki"|| col.tag == "Toko")
		{
			Destroy(col.gameObject);
			Live--; //城門減少生命值
		}

	}
}//主程式結束=====================================================================================================================
