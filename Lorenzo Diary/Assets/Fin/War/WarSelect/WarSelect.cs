//戰爭選項
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class WarSelect : MonoBehaviour {

	//宣告變數*************************************************************************************
	public GameObject Port;  //顯示Port關卡
	public GameObject Viseu; //顯示Viseu關卡
	public GameObject Beja;  //顯示Beja關卡
	public GameObject Infinite;//顯示Infinite關卡
	public GameObject StartButton; //開始Button

	public GameObject WarPort2;
	public GameObject WarPort3;
	public GameObject WarPort4;

	public GameObject WarViseu2;
	public GameObject WarViseu3;
	public GameObject WarViseu4;

	public GameObject WarBeja2;
	public GameObject WarBeja3;
	public GameObject WarBeja4;

	public static int amount;       //敵人數量
	public static int Live;         //城門生命值
	public static int EnemyCateMax; //敵人種類
	public static float CreateTime; //敵人生成時間
	public static bool infiniteStart = false;   //是否開啟無限模式 true:開啟 false:未開啟

	public Text Title;     //關卡標題
	public Text Detailtext;//關卡敵人訊息
	public Text Message;   //關卡內容
	public Text SkillNameText;   //戰術名稱
	public Text SkillDetailText; //戰術細節

	public GameObject WarSelecttoWarFadeOut; //戰爭選項到戰爭的淡出動畫
	public GameObject WarSelecttoMainFadeOut;//戰爭選項到主畫面的淡出動畫

	public AudioSource ButtonMusic;     //按扭音效
	public AudioSource BackGroundMusic; //背景音效
	public AudioSource BackMusic;       //返回音效
	public Animation TitleMove;         //訊息移動動畫
	public Animation DetailMove;        //訊息移動動畫
	public Animation MessageMove;       //訊息移動動畫
	public Animation ImageMove;         //Image移動動畫
	public GameObject NowChice;         //現在選擇亮點

	public Image Detail_Image_1; 		//敵人出現種類1
	public Image Detail_Image_2;
	public Image Detail_Image_3;
	public Image Detail_Image_4;
	public Image Detail_Image_5;
	public Image Detail_Image_6;
	public Image Detail_Image_7;
	public Image Detail_Image_8;
	public Image Detail_Image_9;

	public Image AddLive_Image;			//補血按鈕圖片
	public Image AddBomb_Image;			//爆炸按鈕圖片
	public Image AddEnergy_Image;		//能量按鈕圖片
	public Image AddDoor_Image;			//城門按鈕圖片

	float timef;

	//戰爭儲存**************************************************************************************
	public static int WarLevel=0;                //戰爭關卡 
	public static int[] PortPass = new int[5];   //是否通過關卡 0:沒通過 1:已通過
	public static int[] ViseuPass = new int[5];  //是否通過關卡 0:沒通過 1:已通過
	public static int[] BejaPass = new int[5];   //是否通過關卡 0:沒通過 1:已通過
	public static int   InfinitePass = 1;        //無限關卡最大年份
	// Use this for initialization
	void Start () {
		Port.SetActive(false);     //隱藏Port關卡
		Viseu.SetActive(false);    //隱藏Viseu關卡
		Beja.SetActive(false);     //隱藏Beja關卡
		Infinite.SetActive(false); //隱藏Infinite關卡

		StartButton.SetActive(false);     //隱藏開始Button
		WarSelecttoWarFadeOut.SetActive(false);//隱藏戰爭選項到戰爭的淡出動畫
		WarSelecttoMainFadeOut.SetActive(false);//隱藏戰爭選項到主畫面的淡出動畫
		if(Musicbotton.musicplay) BackGroundMusic.Play(); 
		else BackGroundMusic.Pause(); 
		BackGroundMusic.volume = Musicbotton.MusicVo;
		//AddLiveText ();

		//讀入紀錄
		PortPass[1] =  PlayerPrefs.GetInt("PortPass1"); //讀入成就記錄(以下相同)
		PortPass[2] =  PlayerPrefs.GetInt("PortPass2"); //讀入成就記錄(以下相同)
		PortPass[3] =  PlayerPrefs.GetInt("PortPass3"); //讀入成就記錄(以下相同) 
		PortPass[4] =  PlayerPrefs.GetInt("PortPass4"); //讀入成就記錄(以下相同)

		ViseuPass[1] =  PlayerPrefs.GetInt("ViseuPass1"); //讀入成就記錄(以下相同)
		ViseuPass[2] =  PlayerPrefs.GetInt("ViseuPass2"); //讀入成就記錄(以下相同)
		ViseuPass[3] =  PlayerPrefs.GetInt("ViseuPass3"); //讀入成就記錄(以下相同) 
		ViseuPass[4] =  PlayerPrefs.GetInt("ViseuPass4"); //讀入成就記錄(以下相同)

		BejaPass[1] =  PlayerPrefs.GetInt("BejaPass1"); //讀入成就記錄(以下相同)
		BejaPass[2] =  PlayerPrefs.GetInt("BejaPass2"); //讀入成就記錄(以下相同)
		BejaPass[3] =  PlayerPrefs.GetInt("BejaPass3"); //讀入成就記錄(以下相同) 
		BejaPass[4] =  PlayerPrefs.GetInt("BejaPass4"); //讀入成就記錄(以下相同)

		InfinitePass = PlayerPrefs.GetInt("InfinitePass"); //讀入成就記錄(以下相同)

		Placeyesno.Placetime =  PlayerPrefs.GetInt("Placetime1"); //讀入成就記錄(以下相同)
		Placeyesno2.Placetime =  PlayerPrefs.GetInt("Placetime2"); //讀入成就記錄(以下相同)
		Placeyesno3.Placetime =  PlayerPrefs.GetInt("Placetime3"); //讀入成就記錄(以下相同)
		Placeyesno4.Placetime =  PlayerPrefs.GetInt("Placetime4"); //讀入成就記錄(以下相同)
		Placeyesno5.Placetime =  PlayerPrefs.GetInt("Placetime5"); //讀入成就記錄(以下相同)

	}
	
	// Update is called once per frame
	void Update () {
		//鍵盤輸入(返回)
		if(Input.GetKeyDown("escape"))WarSelecttoMain();

		//如果船已經出航
		timef +=Time.deltaTime;   //記錄時間
		if (timef >= 1) { //如果時間>=1 && Placetime[0]!=0 && 已按下按鈕 
			if(Placeyesno.Placetime!=30 && Placeyesno.Placetime!=0) Placeyesno.Placetime--;
			if(Placeyesno2.Placetime!=60 && Placeyesno2.Placetime!=0) Placeyesno2.Placetime--;
			if(Placeyesno3.Placetime!=80 && Placeyesno3.Placetime!=0) Placeyesno3.Placetime--;
			if(Placeyesno4.Placetime!=100 && Placeyesno4.Placetime!=0) Placeyesno4.Placetime--;
			if(Placeyesno5.Placetime!=120 && Placeyesno5.Placetime!=0) Placeyesno5.Placetime--;
			timef = 0;
		}

		CreatePeople.WarStart = false;

		PlayerPrefs.SetInt("Placetime1", Placeyesno.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime2", Placeyesno2.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime3", Placeyesno3.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime4", Placeyesno4.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime5", Placeyesno5.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

	}


	//切換動畫********************************************************************************
	public void WarSelecttoWar(){
		ButtonMusic.Play ();
		WarSelecttoWarFadeOut.SetActive(true);//顯示戰爭選項到戰爭的淡出動畫
	}

	public void WarSelecttoMain(){
		BackMusic.Play ();
		WarSelecttoMainFadeOut.SetActive(true);//隱藏戰爭選項到主畫面的淡出動畫
	}


	//顯示關卡*****************************************************************************************
	//顯示Port關卡
	public void ShowPort(){
		ButtonMusic.Play ();
		Port.SetActive(true); //顯示Port關卡
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		if(PortPass[1]==1)WarPort2.SetActive(true);  //如果通過一關則顯示後續關卡
		else WarPort2.SetActive(false);
		if(PortPass[2]==1)WarPort3.SetActive(true);
		else WarPort3.SetActive(false);
		if(PortPass[3]==1)WarPort4.SetActive(true);
		else WarPort4.SetActive(false);
		Viseu.SetActive(false);     //隱藏Viseu關卡
		Beja.SetActive(false);      //隱藏Beja關卡
		Infinite.SetActive(false);   //隱藏Infinite關卡
		StartButton.SetActive(false);     //隱藏開始Button
		infiniteStart = false;
		ImageMove.Play();
		NowChice.transform.localPosition = new Vector3(-527.22f, 331.7f, 0);
		Title.text = "♞Portalegre♞(<color=#C2FBBA>簡單地區</color>)";   
		Detailtext.text = "敵人種類:";

		Detail_Image_1.color = new Color32 (255, 255, 255, 255);
		Detail_Image_2.color = new Color32 (255, 255, 255, 255);
		Detail_Image_3.color = new Color32 (255, 255, 255, 255);
		Detail_Image_4.color = new Color32 (255, 255, 255, 125);
		Detail_Image_5.color = new Color32 (255, 255, 255, 125);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 125);
		Detail_Image_8.color = new Color32 (255, 255, 255, 125);
		Detail_Image_9.color = new Color32 (255, 255, 255, 125);

		Message.text = "Portalegre的大權在15世紀後期，逐漸落入美第奇家族的一小撮人手裡。\n事實證明：與大金融銀行家合作，對工商業者很有利。第三代「僭主」洛倫佐·德·美第奇治下，佛羅倫斯進入黃金時代，成為文藝復興的典範。";    
	}

	//顯示Viseu關卡
	public void ShowViseu(){
		ButtonMusic.Play ();
		Port.SetActive(false);//隱藏Port關卡
		Viseu.SetActive(true);//顯示Viseu關卡
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		if(ViseuPass[1]==1)WarViseu2.SetActive(true);
		else WarViseu2.SetActive(false);
		if(ViseuPass[2]==1)WarViseu3.SetActive(true);
		else WarViseu3.SetActive(false);
		if(ViseuPass[3]==1)WarViseu4.SetActive(true);
		else WarViseu4.SetActive(false);
		Beja.SetActive(false);     //隱藏Beja關卡
		Infinite.SetActive(false);   //隱藏Infinite關卡
		StartButton.SetActive(false);     //隱藏開始Button
		infiniteStart = false;
		ImageMove.Play();
		NowChice.transform.localPosition = new Vector3(-527.22f, 331.7f, 0);
		Title.text = "♛Viseu♛(<color=#F4FFC4>中等地區</color>)";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 125);
		Detail_Image_2.color = new Color32 (255, 255, 255, 125);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 255);
		Detail_Image_5.color = new Color32 (255, 255, 255, 255);
		Detail_Image_6.color = new Color32 (255, 255, 255, 255);
		Detail_Image_7.color = new Color32 (255, 255, 255, 125);
		Detail_Image_8.color = new Color32 (255, 255, 255, 125);
		Detail_Image_9.color = new Color32 (255, 255, 255, 125);
		Message.text = "15世紀，Viseu在亞平寧半島上不斷取得土地，它的疆域由阿爾卑斯山直至波河，由阿達河直至伊松佐河，成了義大利政治的重要因素。\n它在國內的統治穩定而健康，各個階級都能從繁榮的對外貿易和工商業中獲利。";  
	}

	//顯示Beja關卡
	public void ShowBeja(){
		ButtonMusic.Play ();
		Port.SetActive(false);  //隱藏Port關卡
		Viseu.SetActive(false); //隱藏Viseu關卡
		Beja.SetActive(true);   //顯示Beja關卡
		Infinite.SetActive(false);   //隱藏Infinite關卡
		TitleMove.Play ();      //訊息移動動畫
		DetailMove.Play ();     //訊息移動動畫
		MessageMove.Play ();    //訊息移動動畫
		if(BejaPass[1]==1)WarBeja2.SetActive(true);
		else WarBeja2.SetActive(false);
		if(BejaPass[2]==1)WarBeja3.SetActive(true);
		else WarBeja3.SetActive(false);
		if(BejaPass[3]==1)WarBeja4.SetActive(true);
		else WarBeja4.SetActive(false);
		StartButton.SetActive(false);     //隱藏開始Button
		infiniteStart = false;
		ImageMove.Play();
		NowChice.transform.localPosition = new Vector3(-527.22f, 331.7f, 0);
		Title.text = "♚Beja♚(<color=#FF0000>困難地區</color>)";  
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 125);
		Detail_Image_2.color = new Color32 (255, 255, 255, 125);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 125);
		Detail_Image_5.color = new Color32 (255, 255, 255, 125);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 255);
		Detail_Image_8.color = new Color32 (255, 255, 255, 255);
		Detail_Image_9.color = new Color32 (255, 255, 255, 255);
		Message.text = "1395年，由Beja領主加里西奧·維斯孔蒂所建立。1447年維斯孔蒂家族絕嗣，雖然根據條約，奧爾良公爵查理一世是公國的合法繼承人，但Beja仍宣布成立共和國。查理一世沒法繼承公國，但這個共和國卻是一個短命的共和國。維斯孔蒂家族最後一個繼承人的女婿，僱傭兵弗朗切斯科·斯福爾扎，於1450年奪取了Beja，並自行宣布成為公爵。";  
	}

	//關卡內容****************************************************************//FFD095FF 414040FF
	//關卡Port1
	public void Port1(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-432.0f, 331.7f, 0);
		Title.text = "♞第一次北方戰爭♞";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 255);
		Detail_Image_2.color = new Color32 (255, 255, 255, 125);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 125);
		Detail_Image_5.color = new Color32 (255, 255, 255, 125);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 125);
		Detail_Image_8.color = new Color32 (255, 255, 255, 125);
		Detail_Image_9.color = new Color32 (255, 255, 255, 125);
		Message.text = "又稱北方七年戰爭，1563年至1570年期間，發生在瑞典與丹麥、呂貝克、波蘭立陶宛聯邦之間的戰爭。戰爭的主角是瑞典和丹麥，戰爭的動因是爭奪波羅的海海上霸權。瑞典發展為新興海上強國。";  
		amount = 9999; 
		CreatePeople.Live = 10;
		Live = 5;         
		EnemyCateMax = 2;
		CreateTime = 3.0f;   
		WarLevel = 1;
	}
	//關卡Port2
	public void Port2(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-303.0f, 331.7f, 0);
		Title.text = "♞法國宗教戰爭♞";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 255);
		Detail_Image_2.color = new Color32 (255, 255, 255, 255);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 125);
		Detail_Image_5.color = new Color32 (255, 255, 255, 125);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 125);
		Detail_Image_8.color = new Color32 (255, 255, 255, 125);
		Detail_Image_9.color = new Color32 (255, 255, 255, 125);
		Message.text = "又名胡格諾戰爭，是發生在1562年-1598年間法蘭西王國國內的內戰和民眾騷動事件，內戰雙方為羅馬天主教廷和胡格諾派（加爾文派）新教徒。戰爭進行了連續八次，對當時的法國造成了嚴重的破壞。據估計在當時三百萬民眾死於戰亂及戰爭帶來的饑荒和瘟疫，在宗教戰爭中僅次於造成八百萬人喪生的三十年戰爭。";  
		amount = 9999;    
		CreatePeople.Live = 10;
		Live = 7;         
		EnemyCateMax = 3;
		CreateTime = 3.0f;   
		WarLevel = 2;
	}
	//關卡Port3
	public void Port3(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-172.2f, 331.7f, 0);
		Title.text = "♞瑞典解放戰爭♞";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 255);
		Detail_Image_2.color = new Color32 (255, 255, 255, 255);
		Detail_Image_3.color = new Color32 (255, 255, 255, 255);
		Detail_Image_4.color = new Color32 (255, 255, 255, 125);
		Detail_Image_5.color = new Color32 (255, 255, 255, 125);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 125);
		Detail_Image_8.color = new Color32 (255, 255, 255, 125);
		Detail_Image_9.color = new Color32 (255, 255, 255, 125);
		Message.text = "於1521至1523年之間發生，導致卡爾馬聯合解體。1520年11月，卡爾馬聯合君主克里斯蒂安二世佔領斯德哥爾摩後，屠殺了上百個反對聯合的瑞典人，史稱斯德哥爾摩慘案。24歲的古斯塔夫·瓦薩逃出，但他的父親則被殺。";  
		amount = 9999;  
		CreatePeople.Live = 10;
		Live = 10;       
		EnemyCateMax = 3;
		CreateTime = 3.0f;
		WarLevel = 3;
	}
	//關卡Port4
	public void Port4(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-36.28f, 331.7f, 0);
		Title.text = "♞三十年戰爭♞";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 255);
		Detail_Image_2.color = new Color32 (255, 255, 255, 255);
		Detail_Image_3.color = new Color32 (255, 255, 255, 255);
		Detail_Image_4.color = new Color32 (255, 255, 255, 125);
		Detail_Image_5.color = new Color32 (255, 255, 255, 125);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 125);
		Detail_Image_8.color = new Color32 (255, 255, 255, 125);
		Detail_Image_9.color = new Color32 (255, 255, 255, 125);
		Message.text = "，是由神聖羅馬帝國的內戰演變而成的一場大規模戰爭。戰爭以波希米亞人反抗哈布斯堡家族統治為肇始，最後以哈布斯堡家族戰敗並簽訂《西發里亞和約》而告結束。這場戰爭使日耳曼各邦國大約被消滅了25至40個百分比的人口；路德城維滕貝格四分之三人口陣亡，波莫瑞百分之六十五的人口陣亡，西里西亞四分之一的人口陣亡，日耳曼各邦國男性有將近一半陣亡。";  
		amount = 9999; 
		CreatePeople.Live = 15;
		Live = 12;         
		EnemyCateMax = 4;
		CreateTime = 2.0f; 
		WarLevel = 4;
	}


	//關卡Viseu1
	public void Viseu1(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-432.0f, 331.7f, 0);
		Title.text = "♛札克雷暴動♛";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 125);
		Detail_Image_2.color = new Color32 (255, 255, 255, 125);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 255);
		Detail_Image_5.color = new Color32 (255, 255, 255, 125);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 125);
		Detail_Image_8.color = new Color32 (255, 255, 255, 125);
		Detail_Image_9.color = new Color32 (255, 255, 255, 125);
		Message.text = "是一場在百年戰爭期間發生於法國北部中世紀後期歐洲人民起義。這場以巴黎北部瓦茲河河谷為中心、1358年初夏發生的暴動在數周之後，起義軍就因領袖吉約姆·卡爾被誘捕斬殺而群龍無首，最終被平息，兩萬農民軍被殺。「札克雷」一詞是當時的貴族給農民們起的蔑稱。";  
		amount = 9999;  
		CreatePeople.Live = 15;
		Live = 15;         
		EnemyCateMax = 5;
		CreateTime = 2.0f;   
		WarLevel = 5;
	}

	//關卡Viseu2
	public void Viseu2(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-303.0f, 331.7f, 0);
		Title.text = "♛貝爾格勒之圍♛";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 125);
		Detail_Image_2.color = new Color32 (255, 255, 255, 125);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 255);
		Detail_Image_5.color = new Color32 (255, 255, 255, 255);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 125);
		Detail_Image_8.color = new Color32 (255, 255, 255, 125);
		Detail_Image_9.color = new Color32 (255, 255, 255, 125);
		Message.text = "1456年鄂圖曼帝國圍攻匈牙利王國要塞貝爾格勒的一次戰役，匈牙利軍隊在名將匈雅提·亞諾什的帶領下打敗對手。圍城最終演變成激戰。期間，處於守勢的匈雅提·亞諾什發動了一次出其不意的逆襲，直搗土耳其軍營，使形勢發生戲劇性逆轉，最終迫使受傷的穆罕默德二世放棄包圍，全線撤退。貝爾格勒一役「挽救了基督教命運」。";  
		amount = 9999; 
		CreatePeople.Live = 15;
		Live = 20;         
		EnemyCateMax = 6;
		CreateTime = 3.0f;   
		WarLevel = 6;
	}

	//關卡Viseu3
	public void Viseu3(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-172.2f, 331.7f, 0);
		Title.text = "♛玫瑰戰爭♛";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 125);
		Detail_Image_2.color = new Color32 (255, 255, 255, 125);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 255);
		Detail_Image_5.color = new Color32 (255, 255, 255, 255);
		Detail_Image_6.color = new Color32 (255, 255, 255, 255);
		Detail_Image_7.color = new Color32 (255, 255, 255, 125);
		Detail_Image_8.color = new Color32 (255, 255, 255, 125);
		Detail_Image_9.color = new Color32 (255, 255, 255, 125);
		Message.text = "是英王愛德華三世（1327年-1377年在位）的兩支後裔——蘭開斯特家族和約克家族的支持者為了爭奪英格蘭王位而發生斷續的內戰。";  
		amount = 9999;   
		CreatePeople.Live = 15;
		Live = 25;         
		EnemyCateMax = 7;
		CreateTime = 3.0f;   
		WarLevel = 7;
	}

	//關卡Viseu4
	public void Viseu4(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-36.28f, 331.7f, 0);
		Title.text = "♛百年戰爭♛";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 125);
		Detail_Image_2.color = new Color32 (255, 255, 255, 125);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 255);
		Detail_Image_5.color = new Color32 (255, 255, 255, 255);
		Detail_Image_6.color = new Color32 (255, 255, 255, 255);
		Detail_Image_7.color = new Color32 (255, 255, 255, 125);
		Detail_Image_8.color = new Color32 (255, 255, 255, 125);
		Detail_Image_9.color = new Color32 (255, 255, 255, 125);
		Message.text = "1337年至1453年，交戰雙方是英格蘭王國和法蘭西王國；後來勃艮第公國等國亦加入戰爭。它是世界最長的戰爭之一，長達116年，最後由法方勝出，不少新的戰術和武器因而發明。";  
		amount = 9999;  
		CreatePeople.Live = 15;
		Live = 30;         
		EnemyCateMax = 7;
		CreateTime = 3.0f;   
		WarLevel = 8;
	}


	//關卡Beja1
	public void Beja1(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-432.0f, 331.7f, 0);
		Title.text = "♚維也納之戰♚";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 125);
		Detail_Image_2.color = new Color32 (255, 255, 255, 125);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 125);
		Detail_Image_5.color = new Color32 (255, 255, 255, 125);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 255);
		Detail_Image_8.color = new Color32 (255, 255, 255, 125);
		Detail_Image_9.color = new Color32 (255, 255, 255, 125);
		Message.text = "發生於1683年9月12日，是哈布斯堡王朝與波蘭王國聯軍對圍困維也納兩個月的鄂圖曼帝國軍隊進行的一場解圍之戰。這場阻止了鄂圖曼帝國攻入歐洲行動的戰役被視為奧斯曼帝國向外擴張的句點，並維持了哈布斯堡王朝在中歐的霸權。";  
		amount = 9999;   
		CreatePeople.Live = 10;
		Live = 50;         
		EnemyCateMax = 8;
		CreateTime = 1.5f;   
		WarLevel = 9;
	}

	//關卡Beja2
	public void Beja2(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-303.0f, 331.7f, 0);
		Title.text = "♚義大利戰爭♚";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 125);
		Detail_Image_2.color = new Color32 (255, 255, 255, 125);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 125);
		Detail_Image_5.color = new Color32 (255, 255, 255, 125);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 255);
		Detail_Image_8.color = new Color32 (255, 255, 255, 255);
		Detail_Image_9.color = new Color32 (255, 255, 255, 255);
		Message.text = "據義大利戰爭簡介記載，這場曠日持久的戰爭源於十五世紀末期到十六中葉，法國與神聖羅馬帝國、西班牙等國為爭奪義大利的領土和重要資源而開展的大規模軍事較量，是歐洲大陸的強盜們為瓜分政局動盪的鄰國而實施的一場可恥的侵略戰爭。";  
		amount = 9999;     
		CreatePeople.Live = 10;
		Live = 70;         
		EnemyCateMax = 10;
		CreateTime = 1.5f;   
		WarLevel = 10;
	}

	//關卡Beja3
	public void Beja3(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-172.2f, 331.7f, 0);
		Title.text = "♚費拉拉戰爭♚";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 125);
		Detail_Image_2.color = new Color32 (255, 255, 255, 125);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 125);
		Detail_Image_5.color = new Color32 (255, 255, 255, 125);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 255);
		Detail_Image_8.color = new Color32 (255, 255, 255, 255);
		Detail_Image_9.color = new Color32 (255, 255, 255, 255);
		Message.text = "是一個發生於15世紀末期的戰爭，是由費拉拉公爵埃爾科萊一世·埃斯特與他的對手西斯都四世及其盟友威尼斯共和國間的戰爭。戰爭結束於1484年8月7日簽訂的巴尼奧洛和約（Pace di Bagnolo）。";  
		amount = 9999; 
		CreatePeople.Live = 10;
		Live = 80;         
		EnemyCateMax = 10;
		CreateTime = 1.0f;   
		WarLevel = 11;
	}

	//關卡Beja4
	public void Beja4(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-36.28f, 331.7f, 0);
		Title.text = "♚倫巴第同盟♚";   
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 125);
		Detail_Image_2.color = new Color32 (255, 255, 255, 125);
		Detail_Image_3.color = new Color32 (255, 255, 255, 125);
		Detail_Image_4.color = new Color32 (255, 255, 255, 125);
		Detail_Image_5.color = new Color32 (255, 255, 255, 125);
		Detail_Image_6.color = new Color32 (255, 255, 255, 125);
		Detail_Image_7.color = new Color32 (255, 255, 255, 255);
		Detail_Image_8.color = new Color32 (255, 255, 255, 255);
		Detail_Image_9.color = new Color32 (255, 255, 255, 255);
		Message.text = "是一個成立於1467年的中世紀聯盟，其目的是為了對抗霍亨斯陶芬家族的神聖羅馬帝國皇帝在義大利擴張勢力的企圖。在其巔峰時期，北義大利的多數城市都加入了同盟，並且得到了教皇的支持。隨著第三位、也是最後一位霍亨斯陶芬皇帝腓特烈二世在1650年去世，同盟的使命完成，並隨後解散。";  
		amount = 9999;    
		CreatePeople.Live = 10;
		Live = 100;         
		EnemyCateMax = 10;
		CreateTime = 1.0f;   
		WarLevel = 12;

	}

	//特殊關卡=====================================================================================================================================================================
	//顯示infinite關卡
	public void Showinfinite(){
		ButtonMusic.Play ();
		Port.SetActive(false);//隱藏Port關卡
		Viseu.SetActive(false);//隱藏BViseu關卡
		Beja.SetActive(false);     //隱藏Beja關卡
		Infinite.SetActive(true); //顯示Infinite關卡
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(false);     //隱藏開始Button
		infiniteStart = true;
		ImageMove.Play();
		NowChice.transform.localPosition = new Vector3(-527.22f, 331.7f, 0);
		Title.text = "∞無限戰場∞ (共經歷 " + InfinitePass + " 年)";  
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 255);
		Detail_Image_2.color = new Color32 (255, 255, 255, 255);
		Detail_Image_3.color = new Color32 (255, 255, 255, 255);
		Detail_Image_4.color = new Color32 (255, 255, 255, 255);
		Detail_Image_5.color = new Color32 (255, 255, 255, 255);
		Detail_Image_6.color = new Color32 (255, 255, 255, 255);
		Detail_Image_7.color = new Color32 (255, 255, 255, 255);
		Detail_Image_8.color = new Color32 (255, 255, 255, 255);
		Detail_Image_9.color = new Color32 (255, 255, 255, 255);
		Message.text = "戰爭從來都沒有結束，只是以不同的方式存在著。我們不討論其它方式在這裡只用最原始的方式，那就是不斷的攻打對方。";  

	
	}

	//無限關卡infinite
	public void infinite(){
		ButtonMusic.Play ();
		TitleMove.Play ();    //訊息移動動畫
		DetailMove.Play ();   //訊息移動動畫
		MessageMove.Play ();  //訊息移動動畫
		StartButton.SetActive(true);//顯示開始Button
		NowChice.transform.localPosition = new Vector3(-209.9f, 331.7f, 0);
		Title.text = "∞無限戰場∞ (共經歷 " + InfinitePass + " 年)";  
		Detailtext.text = "敵人種類:";
		Detail_Image_1.color = new Color32 (255, 255, 255, 255);
		Detail_Image_2.color = new Color32 (255, 255, 255, 255);
		Detail_Image_3.color = new Color32 (255, 255, 255, 255);
		Detail_Image_4.color = new Color32 (255, 255, 255, 255);
		Detail_Image_5.color = new Color32 (255, 255, 255, 255);
		Detail_Image_6.color = new Color32 (255, 255, 255, 255);
		Detail_Image_7.color = new Color32 (255, 255, 255, 255);
		Detail_Image_8.color = new Color32 (255, 255, 255, 255);
		Detail_Image_9.color = new Color32 (255, 255, 255, 255);
		Message.text = "敵人會不斷生成，直到你疲勞不堪。";  
		amount = 9999;    
		CreatePeople.Live = 10;
		Live = 999999999;         
		EnemyCateMax = 2;
		CreateTime = 3.0f;   
		WarLevel = 1;
	}

	//=====================================================================================================================================================================================================
	//戰術:補血
	public void AddLiveText(){
		ButtonMusic.Play ();
		SkillNameText.text = "戰術名稱: 道奇的決心";
		SkillDetailText.text = "效果:恢復我方全體士兵生命值，恢復的總量將依<color=#FF0059FF>房屋</color>、<color=#FF0059FF>鐵匠鋪</color>、<color=#FF0059FF>醫院</color>、<color=#FF0059FF>農田</color>等級而提升。";

		AddLive_Image.color = new Color32 (255, 255, 255, 125);			//補血按鈕圖片
		AddBomb_Image.color = new Color32 (255, 255, 255, 255);			//爆炸按鈕圖片
		AddEnergy_Image.color = new Color32 (255, 255, 255, 255);		//能量按鈕圖片
		AddDoor_Image.color = new Color32 (255, 255, 255, 255);			//城門按鈕圖片
	}

	//戰術:爆炸
	public void AddBombText(){
		ButtonMusic.Play ();
		SkillNameText.text = "戰術名稱: 隆薩爾的爆炸";
		SkillDetailText.text = "效果:發動全面爆炸使敵方士兵受到一定的傷害，傷害的總量為<color=#FF0059FF>敵人生命值20%</color>。";
		AddLive_Image.color = new Color32 (255, 255, 255, 255);			//補血按鈕圖片
		AddBomb_Image.color = new Color32 (255, 255, 255, 125);			//爆炸按鈕圖片
		AddEnergy_Image.color = new Color32 (255, 255, 255, 255);		//能量按鈕圖片
		AddDoor_Image.color = new Color32 (255, 255, 255, 255);			//城門按鈕圖片
	}

	//戰術:能量條
	public void AddEnergyText(){
		ButtonMusic.Play ();
		SkillNameText.text = "戰術名稱: 美第奇家族的尊嚴";
		SkillDetailText.text = "效果:增加一些能量條，恢復的總量將依<color=#FF0059FF>鐵匠鋪</color>和<color=#FF0059FF>礦場</color>等級而提升。";
		AddLive_Image.color = new Color32 (255, 255, 255, 255);			//補血按鈕圖片
		AddBomb_Image.color = new Color32 (255, 255, 255, 255);			//爆炸按鈕圖片
		AddEnergy_Image.color = new Color32 (255, 255, 255, 125);		//能量按鈕圖片
		AddDoor_Image.color = new Color32 (255, 255, 255, 255);			//城門按鈕圖片
	}

	//戰術:修補城門
	public void AddDoorText(){
		ButtonMusic.Play ();
		SkillNameText.text = "戰術名稱: 工匠的意志";
		SkillDetailText.text = "效果:恢復我方城門生命值，恢復的總量為<color=#FF0059FF>城門生命值+5</color>。";
		AddLive_Image.color = new Color32 (255, 255, 255, 255);			//補血按鈕圖片
		AddBomb_Image.color = new Color32 (255, 255, 255, 255);			//爆炸按鈕圖片
		AddEnergy_Image.color = new Color32 (255, 255, 255, 255);		//能量按鈕圖片
		AddDoor_Image.color = new Color32 (255, 255, 255, 125);			//城門按鈕圖片
	}


}//WarSelect結束
