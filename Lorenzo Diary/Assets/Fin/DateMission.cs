//日常任務
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

public class DateMission : MonoBehaviour {

	//宣告變數****************************************************************************************************************************
	public GameObject yesbutton;       //宣告PlayButton物件
	public GameObject Placeimage;      //宣告Placeimage物件
	public int yesno ;                 //是否已經按下按鈕 true:已按下 false: 未按下
	public Text Datetext = null;       //日常任務內容
	public Text choosetext1 = null;    //選擇1訊息
	public Text choosetext2 = null;    //選擇1訊息
	public GameObject choosebutton1;   //宣告選擇1按鈕
	public GameObject choosebutton2;   //宣告選擇2按鈕
	public AudioSource ButtonMusic;    //按扭音效
	public GameObject StoryFadeout;    //對話淡出動畫
	public GameObject RedParticle;     //紅色粒子效果
	public GameObject BlueParticle;    //藍色粒子效果

	public Text Obtaintext = null;     //獲取物品text 
	public AudioSource ObtainMusic;    //收穫音效
	public AudioSource DateMusic;      //日常任務音效
	public Animation SaveImage;        //儲存中動畫

	float timef;              //時間
	int   missiontime = 0;    //日常任務出現時間
	int   mission = 0;        //日常任務編號 



	//主線任務
	bool  MainMission = false;          //主線任務 true:開啟主線任務 false:關閉主線任務 
	public GameObject MainMissionON;    //主線任務開啟圖示
	public GameObject MainMissionOFF;   //主線任務關閉圖示
	public static int MainMissionNumber;//主線任務編號

	//總紀錄
	public static float AllChoice;  //總事件數量
	public static float GoodChoice; //好選擇數量
	public static float BadChoice;  //壞選擇數量
	public Image GoodScoreIma;             //好選擇進度圖
	public Image BadScoreIma;              //壞選擇進度圖
	//動畫****************************************************************************************************************************************
	//public GameObject PoliceAnimate;   //警察動畫
	//public GameObject DoctorAnimate;   //醫生動畫
	public GameObject ObtainAnimate;     //收獲訊息動畫
	public GameObject ObtaintextAnimate; //收獲訊息動畫

	//********************************************************************************************************************************************
	//********************************************************************************************************************************************
	// Use this for initialization****************************************************************************************************************
	void Start () { 
		yesbutton.SetActive(false);         //隱藏按鈕
		Placeimage.SetActive(false);        //隱藏背景
		choosebutton1.SetActive(false);     //隱藏選擇1
		choosebutton2.SetActive(false);     //隱藏選擇2
		ObtainAnimate.SetActive(false);     //收獲訊息動畫
		ObtaintextAnimate.SetActive(false); //收獲訊息動畫
		MainMissionON.SetActive(false);     //主線任務開啟圖示
		MainMissionOFF.SetActive(true);     //主線任務關閉圖示
		RedParticle.SetActive(false);       //隱藏紅色粒子效果
		BlueParticle.SetActive (false);     //隱藏藍色粒子效果

		Datetext.text = "";                 //日常任務內容
		choosetext1.text = "";              //選擇1內容
		choosetext2.text = "";              //選擇2內容
		missiontime = UnityEngine.Random.Range( 10, 20 );   //產生亂數(10~19);
		yesno = 0;
		MainMissionNumber = 131;

		//動畫========================
		StoryFadeout.SetActive(false);     //隱藏對話淡出動畫

		//讀入紀錄
		AllChoice  = PlayerPrefs.GetFloat("AllChoice");
		GoodChoice = PlayerPrefs.GetFloat("GoodChoice");
		BadChoice  = PlayerPrefs.GetFloat("BadChoice");
		MainMissionNumber = PlayerPrefs.GetInt("MainMissionNumber");


		//print (MainMissionNumber);
	}
	
	// Update is called once per frame
	void Update () {
		timef +=Time.deltaTime;   //記錄時間
		if (timef >= missiontime && yesno == 0 && Main.peoplesum >= 500 && Main.weaponsum >= 500 && Main.hospitalsum >= 500 && Main.foodsum >= 500 && Main.moneysum >= 500) { //如果時間>=1  && 未按下按鈕 
			yesbutton.SetActive (true);   //顯示按鈕
			DateMusic.Play();             //播放日常任務音效
			if(!MainMission)mission = UnityEngine.Random.Range (1 ,131);   //產生亂數(1~130);
			else mission = MainMissionNumber;//UnityEngine.Random.Range (MainMissionNumber , MainMissionNumber+1 );            //產生亂數(131~300);
			yesno = 1;
			timef = 0;
		} 
		/*else if (Main.peoplesum < 2000 || Main.weaponsum < 2000 || Main.hospitalsum < 2000 || Main.foodsum < 2000 || Main.moneysum < 2000) {
			yesbutton.SetActive (false);   //顯示按鈕
			yesno = 0;
		}*/

		if (timef > 1000000) timef = 0;  //防止閒置太久,timef變太大


		GoodScoreIma.fillAmount = GoodChoice / AllChoice;  //好選擇進度條
		BadScoreIma.fillAmount = BadChoice / AllChoice;    //壞選擇進度條

		PlayerPrefs.SetFloat("AllChoice", AllChoice );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetFloat("GoodChoice", GoodChoice );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetFloat("BadChoice", BadChoice );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

	}


	//主線任務開啟按鈕**********************************************************
	public void MainMissionSet(){
		if (MainMission) {
			MainMission = false;
			MainMissionON.SetActive (false);
			MainMissionOFF.SetActive (true);
		} else {
			MainMission = true;
			MainMissionON.SetActive (true);
			MainMissionOFF.SetActive (false);
		}
	}


	//按下按鈕*******************************************************************
	public void push()
	{
		ButtonMusic.Play();
		SaveImage.Play ();
		yesbutton.SetActive(true);     //隱藏按鈕
		Placeimage.SetActive(true);    //顯示背景
		choosebutton1.SetActive(true); //顯示選擇1
		choosebutton2.SetActive(true); //顯示選擇2
		RedParticle.SetActive(true);   //顯示紅色粒子效果
		BlueParticle.SetActive (true); //顯示藍色粒子效果

		//日常任務內容
		if (mission == 1 ) {
			Datetext.text = "旱災來襲,各地田地收成不佳。";
			choosetext1.text = "給人民幫助";
			choosetext2.text = "不給予幫助";
		} else if (mission == 2 ) {
			Datetext.text = "城市的人民被強盜團洗劫一空。";
			choosetext1.text = "抓賊";
			choosetext2.text = "隨便";
		} else if (mission == 3 ) {
			Datetext.text = "一場大瘟疫肆虐了大地! 大量人民得病。";
			choosetext1.text = "醫治";
			choosetext2.text = "不給予";
		} 
		else if (mission == 4 ) {
			Datetext.text = "聽說城裡出現了一位罪大惡極的犯人!";
			choosetext1.text = "警戒";
			choosetext2.text = "不管";
		} 
		else if (mission == 5 ) {
			Datetext.text = "遠道而來的一位貴族，應該要舉辦宴席。";
			choosetext1.text = "舉辦";
			choosetext2.text = "趕走";
		} 
		else if (mission == 6 ) {
			Datetext.text = "鄰國似乎開始徵召士兵，是否要派人探查？";
			choosetext1.text = "准許";
			choosetext2.text = "否決";
		} 
		else if (mission == 7 ) {
			Datetext.text = "森林出現一隻巨大野兔，是否要進森林？";
			choosetext1.text = "進入";
			choosetext2.text = "快逃";
		} 
		else if (mission == 8  ) {
			Datetext.text = "告訴我，孩子，你裝著怎樣的想法？";
			choosetext1.text = "告訴";
			choosetext2.text = "不說";
		} 
		else if (mission == 9 ) {
			Datetext.text = "聽說在海上有一座藏著寶藏的島嶼。";
			choosetext1.text = "相信";
			choosetext2.text = "不信";
		} 
		else if (mission == 10 ) {
			Datetext.text = "雅南曾經是一座正常的城市。";
			choosetext1.text = "雅南";
			choosetext2.text = "城市";
		}
		else if (mission == 11 ) {
			Datetext.text = "最近天氣穩定，農作物收成情況良好，要分發給民眾嗎？";
			choosetext1.text = "分發";
			choosetext2.text = "徵收";
		}
		else if (mission == 12 ) {
			Datetext.text = "地震發生，造成礦場崩塌!";
			choosetext1.text = "了解";
			choosetext2.text = "不管";
		}
		else if (mission == 13 ) {
			Datetext.text = "最近國庫沒什麼錢，要不要派人去鄰國騙錢？";
			choosetext1.text = "好啊";
			choosetext2.text = "不行";
		}
		else if (mission == 14 ) {
			Datetext.text = "鄰國來的一批人，好便宜的!";
			choosetext1.text = "買了";
			choosetext2.text = "還是買";
		}
		else if (mission == 15 ) {
			Datetext.text = "他好像在笑，笑到你心裡發寒!";
			choosetext1.text = "逃跑";
			choosetext2.text = "笑回去";
		}
		else if (mission == 16 ) {
			Datetext.text = "地方人民認為應該要蓋更多的教堂!";
			choosetext1.text = "興建";
			choosetext2.text = "禁止";
		}
		else if (mission == 17 ) {
			Datetext.text = "世界會議將要舉行，是否要參加？";
			choosetext1.text = "參加";
			choosetext2.text = "不參加";
		}
		else if (mission == 18 ) {
			Datetext.text = "地方的民眾和官員爆發了衝突!";
			choosetext1.text = "說服";
			choosetext2.text = "鎮壓";
		}
		else if (mission == 19 ) {
			Datetext.text = "鄰國要求我們支付和平資金。";
			choosetext1.text = "付錢";
			choosetext2.text = "不給";
		}
		else if (mission == 20 ) {
			Datetext.text = "城裡來了一群外來民族，說要進貢。";
			choosetext1.text = "召見";
			choosetext2.text = "趕走";
		}
		else if (mission == 21 ) {
			Datetext.text = "夜晚來臨，今晚是狩獵之夜。";
			choosetext1.text = "獵人";
			choosetext2.text = "野獸";
		}
		else if (mission == 22 ) {
			Datetext.text = "一名血療師來到城中。";
			choosetext1.text = "詢問";
			choosetext2.text = "放棄";
		}
		else if (mission == 23 ) {
			Datetext.text = "武器庫發生火災。";
			choosetext1.text = "救人";
			choosetext2.text = "救武器";
		}
		else if (mission == 24 ) {
			Datetext.text = "新的研究改良了藥品的效果。";
			choosetext1.text = "接受";
			choosetext2.text = "試用";
		}
		else if (mission == 25 ) {
			Datetext.text = "卡爾符創造了新的打鐵技巧。";
			choosetext1.text = "接受";
			choosetext2.text = "忽視";
		}
		else if (mission == 26 ) {
			Datetext.text = "今晚又做了一個夢。";
			choosetext1.text = "美夢";
			choosetext2.text = "噩夢";
		}
		else if (mission == 27 ) {
			Datetext.text = "聽說舊金山發現了一做新的金礦場。";
			choosetext1.text = "買下";
			choosetext2.text = "佔領";
		}
		else if (mission == 28 ) {
			Datetext.text = "最近大雨不斷，農田的作物都爛掉。";
			choosetext1.text = "確認";
			choosetext2.text = "知道";
		}
		else if (mission == 29 ) {
			Datetext.text = "國庫被小偷洗劫，只剩下灰塵。";
			choosetext1.text = "追回";
			choosetext2.text = "徵稅";
		}
		else if (mission == 30 ) {
			Datetext.text = "偏遠地區應該興建學校。";
			choosetext1.text = "興建";
			choosetext2.text = "不變";
		}
		else if (mission == 31 ) {
			Datetext.text = "房屋因為年久失修，開始出現問題，是否要維修？";
			choosetext1.text = "維修";
			choosetext2.text = "重建";
		}
		else if (mission == 32 ) {
			Datetext.text = "暴風雨來襲，商船全部沉入海底。";
			choosetext1.text = "接受";
			choosetext2.text = "知道";
		}
		else if (mission == 33 ) {
			Datetext.text = "街道上出現一位販賣假藥的人。";
			choosetext1.text = "趕走";
			choosetext2.text = "留下";
		}
		else if (mission == 34 ) {
			Datetext.text = "一群人準備造反，推翻政權。";
			choosetext1.text = "說服";
			choosetext2.text = "鎮壓";
		}
		else if (mission == 35 ) {
			Datetext.text = "隨著釀酒技術的發展，食物吃不完都可以拿來釀酒。";
			choosetext1.text = "知道";
			choosetext2.text = "了解";
		}
		else if (mission == 36 ) {
			Datetext.text = "隨著學校的建立越來越多人得到教育。";
			choosetext1.text = "知道";
			choosetext2.text = "了解";
		}
		else if (mission == 37 ) {
			Datetext.text = "最近海上風向不太好，是否還要出航？";
			choosetext1.text = "出航";
			choosetext2.text = "停航";
		}
		else if (mission == 38 ) {
			Datetext.text = "西方的國王即將來訪。";
			choosetext1.text = "很好";
			choosetext2.text = "是喔";
		}
		else if (mission == 39 ) {
			Datetext.text = "我們應該舉辦一場盛大的晚宴。";
			choosetext1.text = "點頭";
			choosetext2.text = "搖頭";
		}
		else if (mission == 40 ) {
			Datetext.text = "鄰國正謀畫攻打我們，是否派兵支援？";
			choosetext1.text = "點頭";
			choosetext2.text = "搖頭";
		}
		else if (mission == 41 ) {
			Datetext.text = "今年的糧食收成特別好。";
			choosetext1.text = "分發";
			choosetext2.text = "給軍隊";
		}
		else if (mission == 42 ) {
			Datetext.text = "一隻鴿子腳上綁著一封信。";
			choosetext1.text = "打開";
			choosetext2.text = "不看";
		}
		else if (mission == 43 ) {
			Datetext.text = "城裡發生了爆炸，是否要關閉城門？";
			choosetext1.text = "關閉";
			choosetext2.text = "不關";
		}
		else if (mission == 44 ) {
			Datetext.text = "人民飽受飢荒之苦，動盪之勢四處擴散。";
			choosetext1.text = "什麼";
			choosetext2.text = "什麼？";
		}
		else if (mission == 45 ) {
			Datetext.text = "一場黑死病，病死了許多人民。";
			choosetext1.text = "什麼";
			choosetext2.text = "什麼？";
		}
		else if (mission == 46 ) {
			Datetext.text = "一群惡狼正在吃掉我們的子民。";
			choosetext1.text = "拯救";
			choosetext2.text = "獵殺";
		}
		else if (mission == 47 ) {
			Datetext.text = "我們應該換一下國旗上的圖案。";
			choosetext1.text = "點頭";
			choosetext2.text = "搖頭";
		}
		else if (mission == 48 ) {
			Datetext.text = "商人們想要組織一個行會。";
			choosetext1.text = "准許";
			choosetext2.text = "搖頭";
		}
		else if (mission == 49 ) {
			Datetext.text = "聽說有一位公主被關在地牢裡。";
			choosetext1.text = "拯救";
			choosetext2.text = "不管";
		}
		else if (mission == 50 ) {
			Datetext.text = "商會會長贈送了一些感激的憑證。";
			choosetext1.text = "收下";
			choosetext2.text = "不收";
		}
		else if (mission == 51 ) {
			Datetext.text = "井裡到處都是金子。";
			choosetext1.text = "分送";
			choosetext2.text = "占有";
		}
		else if (mission == 52 ) {
			Datetext.text = "醫院的屋頂塌掉了，需要幫助修裡。";
			choosetext1.text = "同意";
			choosetext2.text = "拒絕";
		}
		else if (mission == 53 ) {
			Datetext.text = "西方的國王將要來訪。";
			choosetext1.text = "很好";
			choosetext2.text = "真無聊";
		}
		else if (mission == 54 ) {
			Datetext.text = "今天的內褲顏色是。";
			choosetext1.text = "藍色";
			choosetext2.text = "紅色";
		}
		else if (mission == 55 ) {
			Datetext.text = "你應該知道誰凌駕於人民之上。";
			choosetext1.text = "食物";
			choosetext2.text = "武器";
		}
		else if (mission == 56 ) {
			Datetext.text = "維京人打過來了，我們要守住這波攻勢。";
			choosetext1.text = "防禦";
			choosetext2.text = "進攻";
		}
		else if (mission == 57 ) {
			Datetext.text = "城裡似乎出現一些奇怪的聲響，應該加強巡邏。";
			choosetext1.text = "點頭";
			choosetext2.text = "搖頭";
		}
		else if (mission == 58 ) {
			Datetext.text = "一位人民正在宣揚革命的思想，是否要罰一勸百？";
			choosetext1.text = "點頭";
			choosetext2.text = "搖頭";
		}
		else if (mission == 59 ) {
			Datetext.text = "農田遭受到汙染，是否要燒掉農作物？";
			choosetext1.text = "燒掉";
			choosetext2.text = "搖頭";
		}
		else if (mission == 60 ) {
			Datetext.text = "我們應該撥款建造一座公用穀倉。";
			choosetext1.text = "點頭";
			choosetext2.text = "搖頭";
		}
		else if (mission == 61 ) {
			Datetext.text = "你做了一個夢，夢中出現了？";
			choosetext1.text = "花園";
			choosetext2.text = "野獸";
		}
		else if (mission == 62 ) {
			Datetext.text = "港口爆發了鼠疫，是否要封鎖港口？";
			choosetext1.text = "封鎖";
			choosetext2.text = "不要";
		}
		else if (mission == 63 ) {
			Datetext.text = "船員發現了一座島，名為萊伯塔尼亞。";
			choosetext1.text = "知道";
			choosetext2.text = "了解";
		}
		else if (mission == 64 ) {
			Datetext.text = "萊伯塔尼亞，當初是由12個海盜團建立。";
			choosetext1.text = "知道";
			choosetext2.text = "了解";
		}
		else if (mission == 65 ) {
			Datetext.text = "亨利.艾佛瑞，建立萊伯塔尼亞的領導人。";
			choosetext1.text = "知道";
			choosetext2.text = "了解";
		}
		else if (mission == 66 ) {
			Datetext.text = "亨利.艾佛瑞，曾是一名皇家海軍。";
			choosetext1.text = "知道";
			choosetext2.text = "了解";
		}
		else if (mission == 67 ) {
			Datetext.text = "前方出現了獨角鯨的蹤影。";
			choosetext1.text = "繞過";
			choosetext2.text = "獵捕";
		}
		else if (mission == 68 ) {
			Datetext.text = "我們應該再蓋一間醫院。";
			choosetext1.text = "蓋";
			choosetext2.text = "不蓋";
		}
		else if (mission == 69 ) {
			Datetext.text = "你可以跟我講，但不可以碰我肩膀。";
			choosetext1.text = "再碰";
			choosetext2.text = "繼續碰";
		}
		else if (mission == 70 ) {
			Datetext.text = "船員發生了壞血症。";
			choosetext1.text = "知道";
			choosetext2.text = "治療";
		}
		else if (mission == 71 ) {
			Datetext.text = "一輛馬車在市場中亂竄。";
			choosetext1.text = "攔住";
			choosetext2.text = "殺死馬";
		}
		else if (mission == 72 ) {
			Datetext.text = "鄰國進貢了一些東西。";
			choosetext1.text = "食物";
			choosetext2.text = "黃金";
		}
		else if (mission == 73 ) {
			Datetext.text = "今天舉辦宴會，要不要打場牌？";
			choosetext1.text = "點頭";
			choosetext2.text = "搖頭";
		}
		else if (mission == 74 ) {
			Datetext.text = "改良了武器的製造流程。";
			choosetext1.text = "了解";
			choosetext2.text = "知道";
		}
		else if (mission == 75 ) {
			Datetext.text = "我們應該統一文字書寫。";
			choosetext1.text = "點頭";
			choosetext2.text = "搖頭";
		}
		else if (mission == 76 ) {
			Datetext.text = "水井被汙染，許多人民都出現了嘔吐的情況。";
			choosetext1.text = "醫生";
			choosetext2.text = "將軍";
		}
		else if (mission == 77 ) {
			Datetext.text = "出現了通貨膨脹，應該調低物價。";
			choosetext1.text = "調低";
			choosetext2.text = "調高";
		}
		else if (mission == 78 ) {
			Datetext.text = "來了一位小丑，說要進行表演。";
			choosetext1.text = "將軍";
			choosetext2.text = "砍頭";
		}
		else if (mission == 79 ) {
			Datetext.text = "暴風雨最近頻繁發生。";
			choosetext1.text = "知道";
			choosetext2.text = "了解";
		}
		else if (mission == 80 ) {
			Datetext.text = "亞當.巴德里奇出資建立了海盜天堂-布拉哈島。";
			choosetext1.text = "知道";
			choosetext2.text = "了解";
		}
		else if (mission == 81 ) {
			Datetext.text = "在一艘沈船中發現一張似乎是建築物的草圖。";
			choosetext1.text = "知道";
			choosetext2.text = "了解";
		}
		else if (mission == 82 ) {
			Datetext.text = "布拉哈島以前有一批人居住，卻在一夜之間消失無蹤。";
			choosetext1.text = "點頭";
			choosetext2.text = "知道";
		}
		else if (mission == 83 ) {
			Datetext.text = "在「這裡」人人平等，每個人都可以做想做的事。";
			choosetext1.text = "點頭";
			choosetext2.text = "知道";
		}
		else if (mission == 84 ) {
			Datetext.text = "市面上開始流竄著大量的假鈔，應該立即處理。";
			choosetext1.text = "處理";
			choosetext2.text = "調查";
		}
		else if (mission == 85 ) {
			Datetext.text = "由於大量的假鈔銀行發生了人潮擠兌。";
			choosetext1.text = "知道";
			choosetext2.text = "了解";
		}
		else if (mission == 86 ) {
			Datetext.text = "應該著手進行耕耘機的開發改善農作物的產量。";
			choosetext1.text = "同意";
			choosetext2.text = "拒絕";
		}
		else if (mission == 87 ) {
			Datetext.text = "你的椅子底下似乎有東西，是什麼？";
			choosetext1.text = "信";
			choosetext2.text = "垃圾";
		}
		else if (mission == 88 ) {
			Datetext.text = "你的床底下似乎有東西，是什麼？";
			choosetext1.text = "繩子";
			choosetext2.text = "寶藏圖";
		}
		else if (mission == 89 ) {
			Datetext.text = "今天想吃什麼？";
			choosetext1.text = "香腸";
			choosetext2.text = "熱狗";
		}
		else if (mission == 90 ) {
			Datetext.text = "一位官員收取了賄賂，應該怎麼處理？";
			choosetext1.text = "監禁";
			choosetext2.text = "處死";
		}
		else if (mission == 91 ) {
			Datetext.text = "亨利.艾佛瑞知道跟隨自己是怎樣的人。";
			choosetext1.text = "了解";
			choosetext2.text = "知道";
		}
		else if (mission == 92 ) {
			Datetext.text = "想帶領一群海盜光靠信念是遠遠不夠。";
			choosetext1.text = "了解";
			choosetext2.text = "知道";
		}
		else if (mission == 93 ) {
			Datetext.text = "一群來自「高麗」的族群說要進貢一種料理。";
			choosetext1.text = "泡菜";
			choosetext2.text = "人參雞";
		}
		else if (mission == 94 ) {
			Datetext.text = "你的食物跑出了一隻蟑螂，要如何處理料理長？";
			choosetext1.text = "砍頭";
			choosetext2.text = "吃蟑螂";
		}
		else if (mission == 95 ) {
			Datetext.text = "考古學家發現了一座古老的遺跡。";
			choosetext1.text = "了解";
			choosetext2.text = "知道";
		}
		else if (mission == 96 ) {
			Datetext.text = "人民發明了一種新的食物保存方法。";
			choosetext1.text = "了解";
			choosetext2.text = "知道";
		}
		else if (mission == 97 ) {
			Datetext.text = "森林中發現一座新的礦場，是什麼礦產？";
			choosetext1.text = "鐵礦";
			choosetext2.text = "金礦";
		}
		else if (mission == 98 ) {
			Datetext.text = "森林深處有動物的叫聲，是什麼動物？";
			choosetext1.text = "野兔";
			choosetext2.text = "巨熊";
		}
		else if (mission == 99 ) {
			Datetext.text = "城裡最近出現了刺客，我們應該增加守衛？";
			choosetext1.text = "同意";
			choosetext2.text = "拒絕";
		}
		else if (mission == 100 ) {
			Datetext.text = "是否要增加醫療品的數量？";
			choosetext1.text = "同意";
			choosetext2.text = "拒絕";
		}
		else if (mission == 101 ) {
			Datetext.text = "是否要增加海上的貿易量？";
			choosetext1.text = "同意";
			choosetext2.text = "拒絕";
		}
		else if (mission == 102 ) {
			Datetext.text = "鄰國的國王生日，應該派人贈送禮物？";
			choosetext1.text = "同意";
			choosetext2.text = "拒絕";
		}
		else if (mission == 103 ) {
			Datetext.text = "最近人民不斷的遊行抗議，應該增加衛兵的數量？";
			choosetext1.text = "接受";
			choosetext2.text = "拒絕";
		}
		else if (mission == 104 ) {
			Datetext.text = "山裡出現了一隻龍，要不要捉回來當寵物？";
			choosetext1.text = "接受";
			choosetext2.text = "拒絕";
		}
		else if (mission == 105 ) {
			Datetext.text = "最近有許多抗議的人要被砍頭，應該把刀磨利一點？";
			choosetext1.text = "接受";
			choosetext2.text = "拒絕";
		}
		else if (mission == 106 ) {
			Datetext.text = "最近醫生的數量略減，需要注意。";
			choosetext1.text = "了解";
			choosetext2.text = "知道";
		}
		else if (mission == 107 ) {
			Datetext.text = "近期農田收成特別好，是否要調低食物價格？";
			choosetext1.text = "了解";
			choosetext2.text = "知道";
		}
		else if (mission == 108 ) {
			Datetext.text = "國庫最近沒有錢了，要從人民身上徵收一些嗎？";
			choosetext1.text = "徵收";
			choosetext2.text = "拒絕";
		}
		else if (mission == 109 ) {
			Datetext.text = "今年徵收的稅金特別多，要不要多蓋工廠？";
			choosetext1.text = "同意";
			choosetext2.text = "拒絕";
		}
		else if (mission == 110 ) {
			Datetext.text = "今年農田收成不好，要不要停徵稅負？";
			choosetext1.text = "同意";
			choosetext2.text = "拒絕";
		}
		else if (mission == 111 ) {
			Datetext.text = "一個教堂的修女開始賣弄風騷，此風氣開始蔓延。";
			choosetext1.text = "醫生";
			choosetext2.text = "將軍";
		}
		else if (mission == 112 ) {
			Datetext.text = "我們應該建造一座活物博物館？";
			choosetext1.text = "同意";
			choosetext2.text = "拒絕";
		}
		else if (mission == 113 ) {
			Datetext.text = "我們應該在各個鄰國建立大使館，或許可以阻止戰爭？";
			choosetext1.text = "建造";
			choosetext2.text = "拒絕";
		}
		else if (mission == 114 ) {
			Datetext.text = "這次旅程裡遇到一位醫術高明的醫生。";
			choosetext1.text = "見面";
			choosetext2.text = "離開";
		}
		else if (mission == 115 ) {
			Datetext.text = "一封信上寫著鄰國將要進攻，應該先發至人。";
			choosetext1.text = "點頭";
			choosetext2.text = "搖頭";
		}
		else if (mission == 116 ) {
			Datetext.text = "一頭獅子在街上亂跑。";
			choosetext1.text = "將軍";
			choosetext2.text = "放任";
		}
		else if (mission == 117 ) {
			Datetext.text = "西方的國王願意和我國一起抵禦維京人的攻擊，要相信嗎？";
			choosetext1.text = "相信";
			choosetext2.text = "不相信";
		}
		else if (mission == 118 ) {
			Datetext.text = "一群醉醺醺的士兵傷害了教堂的修女，該如何處理？";
			choosetext1.text = "將軍";
			choosetext2.text = "處死";
		}
		else if (mission == 119 ) {
			Datetext.text = "將軍獲得了豐碩的戰果，要提升將軍的兵權嗎？";
			choosetext1.text = "同意";
			choosetext2.text = "不變";
		}
		else if (mission == 120 ) {
			Datetext.text = "一位女性帶著一位小孩說是你的孩子，要讓這個問題永遠消失嗎？";
			choosetext1.text = "同意";
			choosetext2.text = "搖頭";
		}
		else if (mission == 121 ) {
			Datetext.text = "近年來麵包的價格太便宜了，應該調高價格？";
			choosetext1.text = "同意";
			choosetext2.text = "搖頭";
		}
		else if (mission == 122 ) {
			Datetext.text = "攝入太多的糖分，這對你的身體傷害很大。";
			choosetext1.text = "點頭";
			choosetext2.text = "隨便";
		}
		else if (mission == 123 ) {
			Datetext.text = "我們遇到百年來最嚴重的寒流，人民陷入了饑荒。";
			choosetext1.text = "施捨";
			choosetext2.text = "不管";
		}
		else if (mission == 124 ) {
			Datetext.text = "在一個古井中挖到了黃金，還要繼續深挖嗎？";
			choosetext1.text = "同意";
			choosetext2.text = "搖頭";
		}
		else if (mission == 125 ) {
			Datetext.text = "學校是一個精心策劃的陰謀，用來洗腦人民，快點停辦。";
			choosetext1.text = "點頭";
			choosetext2.text = "搖頭";
		}
		else if (mission == 126 ) {
			Datetext.text = "古井裡都是黃金。";
			choosetext1.text = "分享";
			choosetext2.text = "發財了";
		}
		else if (mission == 127 ) {
			Datetext.text = "這封信非常重要，請分配一些軍隊到國境。";
			choosetext1.text = "同意";
			choosetext2.text = "拒絕";
		}
		else if (mission == 128 ) {
			Datetext.text = "一位怪女人，精通植物和夢的古典藝術，要接見她嗎？";
			choosetext1.text = "同意";
			choosetext2.text = "拒絕";
		}
		else if (mission == 129 ) {
			Datetext.text = "首都的工匠們建立一個工會壟斷了市場，他們希望得到你的支持。";
			choosetext1.text = "支持";
			choosetext2.text = "不支持";
		}
		else if (mission == 130 ) {
			Datetext.text = "東部區域是一處不遵守規律爾且野蠻的地方。";
			choosetext1.text = "醫生";
			choosetext2.text = "將軍";
		}
		//主線任務============================================================================================
		else if (mission == 131 ) {
			Datetext.text = "一場夢境將隨知而來。";
			choosetext1.text = "美夢";
			choosetext2.text = "惡夢";
		}
		else if (mission == 132 ) {
			Datetext.text = "海盜們的決定。";
			choosetext1.text = "海軍";
			choosetext2.text = "盜賊";
		}
		else if (mission == 133 && Main.Apeople>=1) {
			Datetext.text = "高樹多悲風，海水揚其波，利劍不再掌，結友何須多。";
			choosetext1.text = "家人們";
			choosetext2.text = "一身的摯友";
		}
		else if (mission == 134 ) {
			Datetext.text = "海盜的國家。";
			choosetext1.text = "事與願違";
			choosetext2.text = "天方夜譚";
		}
		else if (mission == 135 ) {
			Datetext.text = "「羅倫佐.托雷」 和 「烏托邦」。";
			choosetext1.text = "羅倫佐";
			choosetext2.text = "........";
		}
		else if (mission == 136 && Main.Apeople>=2) {
			Datetext.text = "「萊伯塔利亞」。";
			choosetext1.text = "自由的代價";
			choosetext2.text = "權力的挑戰";
		}
		else if (mission == 137) {
			Datetext.text = "「亨利.艾佛瑞」和 「十一位海盜們」。";
			choosetext1.text = "傳奇海盜";
			choosetext2.text = "跟隨者";
		}
		else if (mission == 138) {
			Datetext.text = "「建立者」的輪盤。";
			choosetext1.text = "大鐘樓";
			choosetext2.text = "城鎮中心";
		}
		else if (mission == 139) {
			Datetext.text = "傳說中的海盜天堂。";
			choosetext1.text = "萊伯塔利亞";
			choosetext2.text = "夢想新世界";
		}
		else if (mission == 140 && Main.Apeople>=3) {
			Datetext.text = "「這裡人人平等，每個人都可以做自己想做的事」。";
			choosetext1.text = "人的權力";
			choosetext2.text = "人的天性";
		}
		else if (mission == 141) {
			Datetext.text = "眼前的「萊伯塔利亞」其實是假的?";
			choosetext1.text = "災難的源頭";
			choosetext2.text = "被遺忘的城鎮";
		}
		else if (mission == 142) {
			Datetext.text = "前者隨著時間變成了後者......";
			choosetext1.text = "那一天的到來";
			choosetext2.text = "地獄的引路人";
		}
		else if (mission == 143 && Main.Apeople>=3 && Main.Amoney>=3) {
			Datetext.text = "一場大規模的動亂。";
			choosetext1.text = "貪婪";
			choosetext2.text = "欲望";
		}
		else if (mission == 144) {
			Datetext.text = "「強盜」。";
			choosetext1.text = "付出代價";
			choosetext2.text = "無能為力";
		}
		else if (mission == 145) {
			Datetext.text = "一個「徹頭徹尾、自始至終的謊言」。";
			choosetext1.text = "美夢的開端";
			choosetext2.text = "噩夢的謊言";
		}
		else if (mission == 146) {
			Datetext.text = "「羅倫佐家族」。";
			choosetext1.text = "家族";
			choosetext2.text = "初衷";
		}
		else {
			mission = 999;
			Datetext.text = "沒什麼特別的事發生。";
			choosetext1.text = "關閉";
			choosetext2.text = "關閉";
			if(mission==133 && Main.Apeople<1) Datetext.text = "房屋需達等級1。";
			else if(mission==136 && Main.Apeople<2)Datetext.text = "房屋需達等級2。";
			else if(mission==140 && Main.Apeople<3)Datetext.text = "房屋需達等級3。";
			else if(mission==143 && Main.Apeople<3 && Main.Amoney<3)Datetext.text = "房屋和礦場都需達等級3。";

		}
	}//按下按鈕結束*************************************************************************


	//選擇1
	public void Choose1()
	{
		ButtonMusic.Play();
		yesno = 0;
		timef = 0;
		Placeimage.SetActive(false);    //隱藏背景
		yesbutton.SetActive(false);     //隱藏按鈕
		choosebutton1.SetActive(false); //隱藏選擇1
		choosebutton2.SetActive(false); //隱藏選擇2
		RedParticle.SetActive(false);   //隱藏紅色粒子效果
		BlueParticle.SetActive (false); //隱藏藍色粒子效果
		//Main.FadePlay = true;
		Datetext.text = "";
		choosetext1.text = "";
		choosetext2.text = "";

		//任務獎勵===============================================
		if (mission == 1 ) {
			Main.foodsum = Main.foodsum - 100;
			Main.peoplesum = Main.peoplesum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+ "<color=#ff0000>⊗食物減少 100 公斤</color>\n";
			
			//if(Main.foodsum>=2000){
			Story.Speak = 43;                     //發生故事編號
			StoryFadeout.SetActive(true);//       //顯示對話淡出動畫
		}
		else if (mission == 2 ) {
			Main.moneysum = Main.moneysum - 100;
			Main.foodsum = Main.foodsum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 50 公斤\n"
				+ "<color=#ff0000>⊗金錢減少 100 法</color>\n";
			Story.Speak = 1;                     //發生故事編號
			StoryFadeout.SetActive(true);        //顯示對話淡出動畫
		}
		else if (mission == 3 ) {
			Main.hospitalsum = Main.hospitalsum - 50;
			Main.peoplesum = Main.peoplesum + 25;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 25 人\n"
				+ "<color=#ff0000>⊗醫療品減少 50 箱</color>\n";
			Story.Speak = 44;                     //發生故事編號
			StoryFadeout.SetActive(true);//       //顯示對話淡出動畫
		}
		else if (mission == 4 ) {
			Main.weaponsum = Main.weaponsum - 50;
			Main.peoplesum = Main.peoplesum + 20;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 20 人\n"
				+ "<color=#ff0000>⊗武器減少 50 把</color>\n";
			Story.Speak = 3;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 5 ) {
			Main.foodsum = Main.foodsum - 100;
			Main.moneysum = Main.moneysum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗食物減少 100 公斤</color>\n"
				+ "<color=#ff0000>⊗金錢減少 100 法</color>\n";
			Story.Speak = 4;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 6 ) {
			Main.weaponsum = Main.weaponsum - 200;
			Main.peoplesum = Main.peoplesum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+ "<color=#ff0000>⊗武器減少 200 把</color>\n";
			Story.Speak = 45;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 7 ) {
			Main.foodsum = Main.foodsum + 80;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 80 人\n";
			Story.Speak = 5;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 8 ) {
			Main.peoplesum = Main.peoplesum + 1;
			//if(Startfunction.storymission [0] == 0){
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 1 人\n";
			Story.Speak = 21;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 9 ) {
			Main.moneysum = Main.moneysum + 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 500 法\n";
			Story.Speak = 6;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 10 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.foodsum = Main.foodsum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人</color>\n"
				+ "<color=#ff0000>⊗食物減少 200 公斤</color>\n";
			Story.Speak = 46;                     //發生故事編號
			StoryFadeout.SetActive(true);         //顯示對話淡出動畫
		}
		else if (mission == 11 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.foodsum = Main.foodsum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人</color>\n"
				+ "<color=#ff0000>⊗食物減少 200 公斤</color>\n";
			Story.Speak = 7;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 12 ) {
			Main.peoplesum = Main.peoplesum - 25;
			Main.moneysum = Main.moneysum - 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 25 人</color>\n"
				+ "<color=#ff0000>⊗金錢減少 500 法</color>\n";
		}
		else if (mission == 13 ) {
			Main.moneysum = Main.moneysum + 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 500 法</color>\n";
			Story.Speak = 48;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 14 ) {
			Main.moneysum = Main.moneysum - 500;
			Main.peoplesum = Main.peoplesum + 65;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 65 人\n"
				+ "<color=#ff0000>⊗金錢減少 500 法</color>\n";
		}
		else if (mission == 15 ) {
			Main.FadePlay = true;
		}
		else if (mission == 16 ) {
			Main.peoplesum = Main.peoplesum + 25;
			Main.moneysum = Main.moneysum - 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 25 人\n"
				+ "<color=#ff0000>⊗金錢減少 500 法</color>\n";
		}
		else if (mission == 17 ) {
			Main.foodsum = Main.foodsum - 200;
			Main.moneysum = Main.moneysum - 350;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗食物減少 200 公斤</color>\n"
				+ "<color=#ff0000>⊗金錢減少 350 法</color>\n";
			Story.Speak = 9;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 18 ) {
			Main.hospitalsum = Main.hospitalsum - 250;
			Main.foodsum = Main.foodsum - 300;
			Main.moneysum = Main.moneysum - 300;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗醫療品減少 250 箱</color>\n"
				+ "<color=#ff0000>⊗食物減少 300 公斤</color>\n"
				+ "<color=#ff0000>⊗金錢減少 300 法</color>\n";
			Story.Speak = 10;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 19 ) {
			Main.moneysum = Main.moneysum - 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗金錢減少 500 法</color>\n";
		}
		else if (mission == 20 ) {
			Main.moneysum = Main.moneysum + 200;
			Main.hospitalsum = Main.hospitalsum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕醫療品增加 200 箱\n"
				+ "⊕金錢增加 200 法\n";
			Story.Speak = 51;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 21 ) {
			Main.hospitalsum = Main.hospitalsum - 99;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗醫療品減少 90 箱</color>\n";
			Story.Speak = 23;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 22 ) {
			Main.hospitalsum = Main.hospitalsum - 99;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗醫療品減少 90 箱</color>\n";
		}
		else if (mission == 23 ) {
			Main.peoplesum = Main.peoplesum - 55;
			Main.weaponsum = Main.weaponsum - 400;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 55 人</color>\n"
				+ "<color=#ff0000>⊗武器減少 400 把</color>\n";
			Story.Speak = 13;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 24 ) {
			Main.peoplesum = Main.peoplesum + 55;
			Main.hospitalsum = Main.hospitalsum + 199;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 55 人\n"
				+ "⊕醫療品增加 199 箱\n";
			Story.Speak = 14;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 25 ) {
			Main.weaponsum = Main.weaponsum + 299;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕武器增加 299 把\n";
			Story.Speak = 52;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 26 ) {
			Main.weaponsum = Main.weaponsum + 299;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕武器增加 299 把\n";
			Story.Speak = 25;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 27 ) {
			Main.moneysum = Main.moneysum + 399;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 399 法\n";
			Story.Speak = 15;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 28 ) {
			Main.foodsum = Main.foodsum - 129;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗食物減少 129 公斤</color>\n";
			Story.Speak = 16;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 29 ) {
			Main.moneysum = Main.moneysum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗金錢減少 200 法</color>\n";
			Story.Speak = 17;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 30 ) {
			Main.peoplesum = Main.peoplesum + 100;
			Main.moneysum = Main.moneysum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 100 人\n"
				+ "<color=#ff0000>⊗金錢減少 200 法</color>\n";
			Story.Speak = 18;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 31 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.moneysum = Main.moneysum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+ "<color=#ff0000>⊗金錢減少 200 法</color>\n";
		}
		else if (mission == 32 ) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.moneysum = Main.moneysum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n"
				+ "<color=#ff0000>⊗金錢減少 100 法</color>\n";
			Story.Speak = 19;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 33 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.hospitalsum = Main.hospitalsum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+ "<color=#ff0000>⊗醫療品減少 100 箱</color>\n";
			Story.Speak = 20;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 34 ) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.moneysum = Main.moneysum - 500;
			Main.foodsum = Main.foodsum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n"
				+ "<color=#ff0000>⊗食物減少 200 公斤</color>\n"
				+ "<color=#ff0000>⊗金錢減少 500 法</color>\n";
			Story.Speak = 54;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 35 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.foodsum = Main.foodsum + 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+ "⊕食物增加 200 公斤\n";
			Story.Speak = 26;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫

		}
		else if (mission == 36 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n";
		}
		else if (mission == 37 ) {
			Main.peoplesum = Main.peoplesum - 25;
			Main.moneysum = Main.moneysum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 25 人\n"
				+ "⊕金錢增加 50 法\n";
			Story.Speak = 56;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 38 ) {
			Main.foodsum = Main.foodsum - 200;
			Main.moneysum = Main.moneysum - 450;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗食物減少 200 公斤</color>\n"
				+ "<color=#ff0000>⊗金錢減少 450 法</color>\n";
			Story.Speak = 28;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 39 ) {
			Main.foodsum = Main.foodsum - 500;
			Main.moneysum = Main.moneysum - 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗食物減少 500 公斤</color>\n"
				+ "<color=#ff0000>⊗金錢減少 500 法</color>\n";
			Story.Speak = 57;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 40 ) {
			Main.foodsum = Main.foodsum - 350;
			Main.weaponsum = Main.weaponsum - 448;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗食物減少 350 公斤</color>\n"
				+ "<color=#ff0000>⊗金錢減少 448 法</color>\n";
			Story.Speak = 29;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 41 ) {
			Main.foodsum = Main.foodsum - 600;
			Main.peoplesum = Main.peoplesum + 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 200 人\n"
				+ "<color=#ff0000>⊗食物減少 600 公斤</color>\n";
		}
		else if (mission == 42 ) {
			Main.foodsum = Main.foodsum - 600;
			Main.peoplesum = Main.peoplesum + 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 200 人\n"
				+ "<color=#ff0000>⊗食物減少 600 公斤</color>\n";
			Story.Speak = 30;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 43 ) {
			Main.peoplesum = Main.peoplesum - 20;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 20 人</color>\n";
			Story.Speak = 31;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 44 ) {
			Main.peoplesum = Main.peoplesum - 150;
			Main.foodsum = Main.foodsum - 300;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 150 人</color>\n"
				+ "<color=#ff0000>⊗食物減少 300 公斤</color>\n";
		}
		else if (mission == 45 ) {
			Main.peoplesum = Main.peoplesum - 250;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 250 人</color>\n";
		}
		else if (mission == 46 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n";
			Story.Speak = 59;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 47 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.moneysum = Main.moneysum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+ "<color=#ff0000>⊗金錢減少 100 法</color>\n";
		}
		else if (mission == 48 ) {
			Main.moneysum = Main.moneysum + 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 500 法\n";
			Story.Speak = 33;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 49 ) {
			Main.weaponsum = Main.weaponsum - 300;
			Main.moneysum = Main.moneysum + 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗武器減少 300 把</color>\n"
				+ "⊕金錢增加 500 法\n";
			Story.Speak = 34;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 50 ) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.moneysum = Main.moneysum + 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n"
				+ "⊕金錢增加 500 法\n";
		}
		else if (mission == 51 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.moneysum = Main.moneysum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+ "⊕金錢增加 100 法\n";
			Story.Speak = 35;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 52 ) {
			Main.hospitalsum = Main.hospitalsum + 250;
			Main.moneysum = Main.moneysum - 150;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕醫療品增加 150 箱\n"
				+ "<color=#ff0000>⊗金錢減少 150 法</color>\n";
			Story.Speak = 60;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 53 ) {
			Main.hospitalsum = Main.hospitalsum + 250;
			Main.moneysum = Main.moneysum - 150;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕醫療品增加 150 箱\n"
				+ "<color=#ff0000>⊗金錢減少 150 法</color>\n";
			Story.Speak = 36;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 54 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 50 法\n";
		}
		else if (mission == 55 ) {
			Main.foodsum = Main.foodsum + 50;
			Main.weaponsum = Main.weaponsum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 50 公斤\n"
				+ "<color=#ff0000>⊗武器減少 100 把</color>\n";
		}
		else if (mission == 56 ) {
			Main.foodsum = Main.foodsum - 50;
			Main.weaponsum = Main.weaponsum - 100;
			Main.hospitalsum = Main.hospitalsum - 150;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗食物減少 50 公斤</color>\n"
				+ "<color=#ff0000>⊗武器減少 100 把</color>\n"
				+ "<color=#ff0000>⊗醫療品減少 150 箱</color>\n";
		}
		else if (mission == 57 ) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.weaponsum = Main.weaponsum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n"
				+ "<color=#ff0000>⊗武器減少 100 把</color>\n";

		}
		else if (mission == 58 ) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n";
		}
		else if (mission == 59 ) {
			Main.peoplesum = Main.peoplesum - 25;
			Main.foodsum = Main.foodsum - 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 25 人</color>\n"
				+ "<color=#ff0000>⊗食物減少 500 公斤</color>\n";
		}
		else if (mission == 60 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.foodsum = Main.foodsum - 500;
			Main.moneysum = Main.moneysum - 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 公斤\n"
				+ "<color=#ff0000>⊗食物減少 500 公斤</color>\n"
				+ "<color=#ff0000>⊗金錢減少 500 法</color>\n";
			Story.Speak = 39;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 62 ) {
			Main.peoplesum = Main.peoplesum - 80;
			Main.hospitalsum = Main.hospitalsum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				  "<color=#ff0000>⊗人口減少 80 人</color>\n"
				+ "<color=#ff0000>⊗醫療品減少 200 箱</color>\n";
			Story.Speak = 40;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 63 ) {
			Main.peoplesum = Main.peoplesum + 80;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 80 人\n";
		}
		else if (mission == 64 ) {
			Main.peoplesum = Main.peoplesum + 80;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 80 人\n";
		}
		else if (mission == 65 ) {
			Main.peoplesum = Main.peoplesum + 120;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 120 人\n";
		}
		else if (mission == 66 ) {
			Main.peoplesum = Main.peoplesum + 1;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 1 人\n";
		}
		else if (mission == 67 ) {
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕沒什麼事情發生\n";
		}
		else if (mission == 68 ) {
			Main.hospitalsum = Main.hospitalsum + 288;
			Main.moneysum = Main.moneysum - 423;
			Main.FadePlay = true; 
			Obtaintext.text = 
				"⊕醫療品增加 288 箱\n"
			    + "<color=#ff0000>⊗金錢減少 423 法</color>\n";
			Story.Speak = 42;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 70 ) {
			Main.foodsum = Main.foodsum - 233;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗食物減少 133 公斤</color>\n";
		}
		else if (mission == 71 ) {
			Main.peoplesum = Main.peoplesum - 55;
			Main.foodsum = Main.foodsum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				 "<color=#ff0000>⊗人口減少 55 人</color>\n"
				+"<color=#ff0000>⊗食物減少 200 公斤</color>\n";
		}
		else if (mission == 72 ) {
			Main.foodsum = Main.foodsum + 125;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 125 公斤\n";
		}
		else if (mission == 73 ) {
			Main.moneysum = Main.moneysum + 123;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 123 法\n";
		}
		else if (mission == 74 ) {
			Main.weaponsum = Main.weaponsum + 255;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕武器增加 255 把\n";
		}
		else if (mission == 75 ) {
			Main.peoplesum = Main.peoplesum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 100 人\n";
		}
		else if (mission == 76 ) {
			Main.peoplesum = Main.peoplesum - 55;
			Main.hospitalsum = Main.hospitalsum - 230;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 55 人</color>\n"
				+"<color=#ff0000>⊗醫療品減少 230 箱</color>\n";
		}
		else if (mission == 77 ) {
			Main.moneysum = Main.moneysum - 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗金錢減少 500 法</color>\n";
		}
		else if (mission == 79 ) {
			Main.moneysum = Main.moneysum - 120;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗金錢減少 120 法</color>\n";
		}
		else if (mission == 84 ) {
			Main.moneysum = Main.moneysum - 400;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗金錢減少 400 法</color>\n";
		}
		else if (mission == 85 ) {
			Main.moneysum = Main.moneysum - 600;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗金錢減少 600 法</color>\n";
		}
		else if (mission == 86 ) {
			Main.foodsum = Main.foodsum + 240;
			Main.moneysum = Main.moneysum - 555;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 240 公斤\n"
				+ "<color=#ff0000>⊗金錢減少 555 法</color>\n";
		}
		else if (mission == 87 ) {
			Main.peoplesum = Main.peoplesum + 20;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 20 人\n";
		}
		else if (mission == 89 ) {
			Main.peoplesum = Main.peoplesum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 100 人\n";
		}
		else if (mission == 90 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n";
		}
		else if (mission == 93 ) {
			Main.foodsum = Main.foodsum + 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 200 公斤\n";
		}
		else if (mission == 94 ) {
			Main.peoplesum = Main.peoplesum - 1;
			Main.foodsum = Main.foodsum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 1 人</color>\n"
				+"<color=#ff0000>⊗食物減少 100 公斤</color>\n";
		}
		else if (mission == 95 ) {
			Main.moneysum = Main.moneysum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 50 法\n";
		}
		else if (mission == 96 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n";
		}
		else if (mission == 97 ) {
			Main.weaponsum = Main.weaponsum + 123;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕武器增加 123 把\n";
		}
		else if (mission == 98 ) {
			Main.foodsum = Main.foodsum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 100 公斤\n";
		}
		else if (mission == 99 ) {
			Main.weaponsum = Main.weaponsum + 255;
			Main.moneysum = Main.moneysum - 420;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕武器增加 255 把\n"
				+ "<color=#ff0000>⊗金錢減少 420 法</color>\n";
		}
		else if (mission == 100 ) {
			Main.hospitalsum = Main.hospitalsum + 230;
			Main.moneysum = Main.moneysum - 550;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕醫療品增加 230 箱\n"
				+ "<color=#ff0000>⊗金錢減少 550 法</color>\n";
		}
		else if (mission == 101 ) {
			Main.peoplesum = Main.peoplesum - 200;
			Main.foodsum = Main.foodsum - 250;
			Main.moneysum = Main.moneysum + 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 240 公斤\n"
				+ "<color=#ff0000>⊗金錢減少 555 法</color>\n";
		}
		else if (mission == 102 ) {
			Main.moneysum = Main.moneysum - 220;
			Main.FadePlay = true;
			Obtaintext.text = 
				 "<color=#ff0000>⊗金錢減少 220 法</color>\n";
		}
		else if (mission == 103 ) {
			Main.weaponsum = Main.weaponsum - 200;
			Main.peoplesum = Main.peoplesum - 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 200 人</color>\n"
			   +"<color=#ff0000>⊗武器減少 50 把</color>\n";
		}
		else if (mission == 104 ) {
			Main.weaponsum = Main.weaponsum - 500;
			Main.foodsum = Main.foodsum - 250;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗武器減少 500 把</color>\n"
			   +"<color=#ff0000>⊗食物減少 250 公斤</color>\n";
		}
		else if (mission == 105 ) {
			Main.peoplesum = Main.peoplesum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 200 人</color>\n";
		}
		else if (mission == 106 ) {
			Main.hospitalsum = Main.hospitalsum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗醫療品減少 200 箱</color>\n";
		}
		else if (mission == 107 ) {
			Main.foodsum = Main.foodsum + 120;
			Main.peoplesum = Main.peoplesum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+ "⊕食物增加 120 公斤\n";
		}
		else if (mission == 108 ) {
			Main.moneysum = Main.moneysum + 300;
			Main.peoplesum = Main.peoplesum - 150;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 150 人</color>\n"
			   +"⊕金錢增加 300 法\n";
		}
		else if (mission == 109 ) {
			Main.moneysum = Main.moneysum + 100;
			Main.weaponsum = Main.weaponsum + 40;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕武器增加 40 把\n"
				+ "⊕金錢增加 100 法\n";
		}
		else if (mission == 110 ) {
			Main.peoplesum = Main.peoplesum + 10;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 10 人\n";
		}
		else if (mission == 111 ) {
			Main.hospitalsum = Main.hospitalsum - 30;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗醫療品減少 30 箱</color>\n";
		}
		else if (mission == 112 ) {
			Main.foodsum = Main.foodsum - 120;
			Main.moneysum = Main.moneysum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗食物減少 120 公斤</color>\n"
				+"⊕金錢增加 100 法\n";
		}
		else if (mission == 113 ) {
			Main.moneysum = Main.moneysum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗金錢減少 100 法</color>\n";
		}
		else if (mission == 114 ) {
			Main.peoplesum = Main.peoplesum + 20;
			Main.hospitalsum = Main.hospitalsum + 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 20 人\n"
				+ "⊕醫療品增加 200 箱\n";
		}
		else if (mission == 115 ) {
			Main.weaponsum = Main.weaponsum - 150;
			Main.moneysum = Main.moneysum + 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗武器減少 150 把</color>\n"
				+"⊕金錢增加 200 法\n";
		}
		else if (mission == 116 ) {
			Main.foodsum = Main.foodsum + 20;
			Main.moneysum = Main.moneysum + 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 20 公斤\n"
				+ "⊕金錢增加 200 法\n";
		}
		else if (mission == 117 ) {
			Main.peoplesum = Main.peoplesum + 20;
			Main.moneysum = Main.moneysum + 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 20 人\n"
				+ "⊕金錢增加 200 法\n";
		}
		else if (mission == 118 ) {
			Main.peoplesum = Main.peoplesum + 10;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 10 人\n";
		}
		else if (mission == 119 ) {
			Main.weaponsum = Main.weaponsum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕武器增加 50 公斤\n";
		}
		else if (mission == 120 ) {
			Main.peoplesum = Main.peoplesum - 2;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 2 人</color>\n";
		}
		else if (mission == 121 ) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.moneysum = Main.moneysum + 222;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n"
				+"⊕金錢增加 222 法\n";
		}
		else if (mission == 122 ) {
			Main.hospitalsum = Main.hospitalsum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕醫療品增加 50 箱\n";
		}
		else if (mission == 123 ) {
			Main.peoplesum = Main.peoplesum + 40;
			Main.foodsum = Main.foodsum - 60;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 40 人\n"
			   +"<color=#ff0000>⊗食物減少 60 公斤</color>\n";

		}
		else if (mission == 124 ) {
			Main.moneysum = Main.moneysum + 120;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 120 法\n";
		}
		else if (mission == 125 ) {
			Main.peoplesum = Main.peoplesum - 25;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 25 人</color>\n";
		}
		else if (mission == 126 ) {
			Main.moneysum = Main.moneysum + 70;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 70 法\n";
		}
		else if (mission == 127 ) {
			Main.weaponsum = Main.weaponsum - 100;
			Main.peoplesum = Main.peoplesum + 80;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 80 人\n"
				+"<color=#ff0000>⊗武器減少 100 把</color>\n";
		}
		else if (mission == 128 ) {
			Main.hospitalsum = Main.hospitalsum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕醫療品增加 100 箱\n";
		}
		else if (mission == 129 ) {
			Main.peoplesum = Main.peoplesum - 100;
			Main.weaponsum = Main.weaponsum + 100;
			Main.moneysum = Main.moneysum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 100 人</color>\n"
			  + "⊕武器增加 100 把\n"
			  + "⊕金錢增加 50 法\n";
		}
		else if (mission == 130 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.hospitalsum = Main.hospitalsum - 80;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+"<color=#ff0000>⊗醫療品減少 80 箱</color>\n";
		}
		else if( mission == 131 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 61;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 132 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 62;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 133 && Main.Apeople>=1){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 63;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 134 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 64;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 135 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 65;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 136 && Main.Apeople>=2){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 66;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 137 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 67;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 138 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 68;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 139 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 69;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 140 && Main.Apeople>=3){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 70;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 141 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 71;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 142 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 72;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 143 && Main.Apeople>=3 && Main.Amoney>=3){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 73;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 144 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 74;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 145 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 75;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 146 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 76;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else {
			Main.FadePlay = true;
			Datetext.text = " ";
			choosetext1.text = " ";
			choosetext2.text = " ";
			Obtaintext.text = "沒什麼特別的事情發生\n";
		}
		missiontime = UnityEngine.Random.Range( 10, 20 );   //產生亂數(30~50);
		AllChoice++;                    //總事件數量+1
		GoodChoice++;                   //好選擇數量+1
		SaveImage.Play ();
		if (mission <= 130) {
			ObtainAnimate.SetActive (true);   //收獲訊息動畫
			ObtaintextAnimate.SetActive (true); //收獲訊息動畫
			ObtainMusic.Play ();
		}
	}//選擇1結束===================================================================================================================================
	//=============================================================================================================================================

	//選擇2
	public void Choose2()
	{
		ButtonMusic.Play();
		yesno = 0;
		timef = 0;
		Placeimage.SetActive(false);    //隱藏背景
		yesbutton.SetActive(false);     //隱藏按鈕
		choosebutton1.SetActive(false); //隱藏選擇1
		choosebutton2.SetActive(false); //隱藏選擇2
		RedParticle.SetActive(false);   //隱藏紅色粒子效果
		BlueParticle.SetActive (false); //隱藏藍色粒子效果
		//Main.FadePlay = true;
		Datetext.text = "";
		choosetext1.text = "";
		choosetext2.text = "";
		//PoliceAnimate.SetActive(false); //隱藏警察動畫
		//DoctorAnimate.SetActive(false); //隱藏醫生動畫

		//任務獎勵=============================================================================================================
		if (mission == 1) {
			Main.moneysum = Main.moneysum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 100 法\n";
		}
		else if (mission == 2) {
			Main.hospitalsum = Main.hospitalsum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕醫療品增加 100 箱\n";
		}
		else if (mission == 3) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n";
		}
		else if (mission == 4) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n";
		}
		else if (mission == 5) {
			Main.hospitalsum = Main.hospitalsum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕醫療品增加 50 箱\n";
		}
		else if (mission == 6) {
			Main.peoplesum = Main.peoplesum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 100 人</color>\n";
		}
		else if (mission==8){
			Main.peoplesum = Main.peoplesum + 1;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 1 人\n";
			//if(Startfunction.storymission [0] == 0){
			Story.Speak = 22;                     //發生故事編號
			StoryFadeout.SetActive(true);         //顯示對話淡出動畫
		}
		else if (mission == 9) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n";
		}
		else if (mission == 11) {
			Main.peoplesum = Main.peoplesum - 100;
			Main.foodsum = Main.foodsum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 100 人</color>\n"
				+"⊕食物增加 100 公斤\n";
		}
		else if (mission == 12) {
			Main.peoplesum = Main.peoplesum - 85;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 85 人</color>\n";
			Story.Speak = 47;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
			
		}
		else if (mission == 13) {
			Main.peoplesum = Main.peoplesum - 85;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗什麼都沒有</color>\n";
		}
		else if (mission == 14) {
			Main.moneysum = Main.moneysum - 100;
			Main.peoplesum = Main.peoplesum + 20;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 20 人\n"
				+"<color=#ff0000>⊗金錢減少 100 法</color>\n";
			Story.Speak = 49;                     //發生故事編號
			StoryFadeout.SetActive(true);         //顯示對話淡出動畫
		}
		else if (mission == 15) {
			Main.moneysum = Main.moneysum - 1;
			Main.peoplesum = Main.peoplesum + 1;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 1 人\n"
				+"<color=#ff0000>⊗金錢減少 1 法</color>\n";
			Story.Speak = 50;                     //發生故事編號
			StoryFadeout.SetActive(true);         //顯示對話淡出動畫
		}
		else if (mission == 16) {
			Main.peoplesum = Main.peoplesum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 100 人</color>\n";
			Story.Speak = 8;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 17) {
			Main.peoplesum = Main.peoplesum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 100 人</color>\n";
		}
		else if (mission == 18) {
			Main.peoplesum = Main.peoplesum - 200;
			Main.weaponsum = Main.weaponsum - 350;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 200 人</color>\n"
			  + "<color=#ff0000>⊗武器減少 350 把</color>\n";
		}
		else if (mission == 19) {
			Main.peoplesum = Main.peoplesum - 200;
			Main.weaponsum = Main.weaponsum - 350;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 200 人</color>\n"
				+ "<color=#ff0000>⊗武器減少 350 把</color>\n";
			Story.Speak = 11;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 20) {
			Main.peoplesum = Main.peoplesum - 450;
			Main.weaponsum = Main.weaponsum - 450;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 450 人</color>\n"
				+ "<color=#ff0000>⊗武器減少 450 把</color>\n";
		}
		else if (mission == 22) {
			Main.peoplesum = Main.peoplesum - 450;
			Main.weaponsum = Main.weaponsum - 450;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 450 人</color>\n"
				+ "<color=#ff0000>⊗武器減少 450 把</color>\n";
			Story.Speak = 24;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 23) {
			Main.peoplesum = Main.peoplesum - 500;
			Main.weaponsum = Main.weaponsum - 99;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 500 人</color>\n"
				+ "<color=#ff0000>⊗武器減少 99 把</color>\n";
		}
		else if (mission == 24) {
			Main.peoplesum = Main.peoplesum + 45;
			Main.hospitalsum = Main.hospitalsum + 99;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 45 人\n"
				+ "⊕醫療品增加 99 箱\n";
		}
		else if (mission == 27 ) {
			Main.moneysum = Main.moneysum + 399;
			Main.weaponsum = Main.weaponsum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗武器減少 200 把</color>\n"
				+ "⊕金錢增加 399 法\n";
		}
		else if (mission == 28 ) {
			Main.foodsum = Main.foodsum - 229;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗食物減少 229 公斤</color>\n";
		}
		else if (mission == 29 ) {
			Main.moneysum = Main.moneysum + 399;
			Main.peoplesum = Main.peoplesum - 400;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 400 人</color>\n"
				+"⊕金錢增加 399 法\n";
		}
		else if (mission == 31 ) {
			Main.moneysum = Main.moneysum - 599;
			Main.peoplesum = Main.peoplesum + 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 200 人\n"
				+"<color=#ff0000>⊗金錢減少 599 法</color>\n";
			Story.Speak = 53;                     //發生故事編號
			StoryFadeout.SetActive(true);         //顯示對話淡出動畫
		}
		else if (mission == 32 ) {
			Main.moneysum = Main.moneysum - 200;
			Main.peoplesum = Main.peoplesum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 200 人</color>\n"
				+ "<color=#ff0000>⊗金錢減少 200 法</color>\n";
		}
		else if (mission == 33 ) {
			Main.peoplesum = Main.peoplesum - 154;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 154 人</color>\n";
		}
		else if (mission == 34 ) {
			Main.peoplesum = Main.peoplesum - 200;
			Main.weaponsum = Main.weaponsum - 250;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 200 人</color>\n"
				+ "<color=#ff0000>⊗武器減少 250 把</color>\n";
			Story.Speak = 55;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 35 ) {
			Main.peoplesum = Main.peoplesum + 200;
			Main.foodsum = Main.foodsum + 250;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 200 人\n"
				+ "⊕食物增加 250 公斤\n";
		}
		else if (mission == 36 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n";
			Story.Speak = 27;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 37 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.moneysum = Main.moneysum - 150;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+"<color=#ff0000>⊗金錢減少 150 法</color>\n";
		}
		else if (mission == 38 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.moneysum = Main.moneysum - 150;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+"<color=#ff0000>⊗金錢減少 150 法</color>\n";
		}
		else if (mission == 39 ) {
			Main.peoplesum = Main.peoplesum + 25;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 25 人\n";
		}
		else if (mission == 40 ) {
			Main.peoplesum = Main.peoplesum - 335;
			Main.hospitalsum = Main.hospitalsum - 590;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 335 人</color>\n"
			  + "<color=#ff0000>⊗醫療品減少 590 箱</color>\n";
		}
		else if (mission == 41 ) {
			Main.foodsum = Main.foodsum - 250;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗食物減少 250 公斤</color>\n";
			Story.Speak = 58;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 43 ) {
			Main.peoplesum = Main.peoplesum - 115;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 115 人</color>\n";
		}
		else if (mission == 44 ) {
			Main.peoplesum = Main.peoplesum - 250;
			Main.foodsum = Main.foodsum - 300;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 250 人</color>\n"
				+ "<color=#ff0000>⊗食物減少 300 公斤</color>\n";
		}
		else if (mission == 45 ) {
			Main.peoplesum = Main.peoplesum - 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 500 人</color>\n";
			Story.Speak = 32;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 46 ) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.foodsum = Main.foodsum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n"
				+"⊕食物增加 100 公斤\n";
		}
		else if (mission == 48 ) {
			Main.moneysum = Main.moneysum - 250;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗金錢減少 250 法</color>\n";
		}
		else if (mission == 50 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.moneysum = Main.moneysum - 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+"<color=#ff0000>⊗金錢減少 500 法</color>\n";
		}
		else if (mission == 51 ) {
			Main.moneysum = Main.moneysum + 500;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 500 法\n";
		}
		else if (mission == 52 ) {
			Main.hospitalsum = Main.hospitalsum - 250;
			Main.peoplesum = Main.peoplesum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 250 人</color>\n"
				+ "<color=#ff0000>⊗醫療品減少 200 箱</color>\n";
		}
		else if (mission == 54 ) {
			Main.weaponsum = Main.weaponsum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕武器增加 50 把\n";
		}
		else if (mission == 55 ) {
			Main.foodsum = Main.foodsum - 100;
			Main.weaponsum = Main.weaponsum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕武器增加 50 把\n"
			  + "<color=#ff0000>⊗食物減少 100 公斤</color>\n";
		}
		else if (mission == 56 ) {
			Main.foodsum = Main.foodsum - 500;
			Main.weaponsum = Main.weaponsum - 300;
			Main.hospitalsum = Main.hospitalsum - 400;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗武器減少 300 把</color>\n"
				+ "<color=#ff0000>⊗醫療品減少 400 箱</color>\n"
			    + "<color=#ff0000>⊗食物減少 500 公斤</color>\n";
			Story.Speak = 37;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 57 ) {
			Main.peoplesum = Main.peoplesum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 200 人</color>\n";
		}
		else if (mission == 58 ) {
			Main.peoplesum = Main.peoplesum - 200;
			Main.weaponsum = Main.weaponsum - 120;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 200 人</color>\n"
				+ "<color=#ff0000>⊗武器減少 120 把</color>\n";
		}
		else if (mission == 59 ) {
			Main.peoplesum = Main.peoplesum - 300;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 300 人</color>\n";
			Story.Speak = 38;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 60 ) {
			Main.peoplesum = Main.peoplesum - 150;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 150 人</color>\n";
		}
		else if (mission == 62 ) {
			Main.hospitalsum = Main.hospitalsum - 360;
			Main.peoplesum = Main.peoplesum - 400;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 400 人</color>\n"
				+ "<color=#ff0000>⊗醫療品減少 360 箱</color>\n";
			Story.Speak = 41;                     //發生故事編號
			StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 63 ) {
			Main.moneysum = Main.moneysum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 100 法\n";
		}
		else if (mission == 64 ) {
			Main.moneysum = Main.moneysum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 100 法\n";
		}
		else if (mission == 65 ) {
			Main.moneysum = Main.moneysum + 40;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 40 法\n";
		}
		else if (mission == 66 ) {
			Main.moneysum = Main.moneysum + 250;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 250 法\n";
		}
		else if (mission == 67 ) {
			Main.foodsum = Main.foodsum + 218;
			Main.moneysum = Main.moneysum + 333;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 218 公斤\n"
			  + "⊕金錢增加 333 法\n";
		}
		else if (mission == 70 ) {
			Main.hospitalsum = Main.hospitalsum - 362;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗醫療品減少 362 箱</color>\n";
		}
		else if (mission == 72 ) {
			Main.moneysum = Main.moneysum + 233;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 233 法\n";
		}
		else if (mission == 74 ) {
			Main.weaponsum = Main.weaponsum + 122;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕武器增加 122 把\n";
		}
		else if (mission == 76 ) {
			Main.peoplesum = Main.peoplesum - 250;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 250 人</color>\n";
		}
		else if (mission == 77 ) {
			Main.moneysum = Main.moneysum - 555;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 555 法\n";
		}
		else if (mission == 79 ) {
			Main.peoplesum = Main.peoplesum - 80;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 80 人</color>\n";
		}
		else if (mission == 84 ) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.moneysum = Main.moneysum - 255;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n"
			  + "<color=#ff0000>⊗金錢減少 255 法</color>\n";
		}
		else if (mission == 85 ) {
			Main.moneysum = Main.moneysum - 1000;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗金錢減少 1000 法</color>\n";
		}
		else if (mission == 88 ) {
			Main.moneysum = Main.moneysum + 420;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 420 法\n";
		}
		else if (mission == 89 ) {
			Main.foodsum = Main.foodsum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 100 公斤\n";
		}
		else if (mission == 90 ) {
			Main.peoplesum = Main.peoplesum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 100 人\n";
		}
		else if (mission == 93 ) {
			Main.foodsum = Main.foodsum + 220;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 220 公斤\n";
		}
		else if (mission == 94 ) {
			Main.peoplesum = Main.peoplesum - 1;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 1 人</color>\n";
		}
		else if (mission == 95 ) {
			Main.moneysum = Main.moneysum + 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 100 法\n";
		}
		else if (mission == 96 ) {
			Main.foodsum = Main.foodsum + 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 200 公斤\n";
		}
		else if (mission == 97 ) {
			Main.moneysum = Main.moneysum + 321;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 321 法\n";
		}
		else if (mission == 98 ) {
			Main.foodsum = Main.foodsum + 300;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 300 公斤\n";
		}
		else if (mission == 99 ) {
			Main.peoplesum = Main.peoplesum - 200;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 200 人</color>\n";
		}
		else if (mission == 100 ) {
			Main.hospitalsum = Main.hospitalsum + 230;
			Main.moneysum = Main.moneysum - 550;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕醫療品增加 230 箱\n"
				+ "<color=#ff0000>⊗金錢減少 550 法</color>\n";
			//Story.Speak = 2;                     //發生故事編號
			//StoryFadeout.SetActive(true);       //顯示對話淡出動畫
		}
		else if (mission == 102 ) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n";
		}
		else if (mission == 103 ) {
			Main.hospitalsum = Main.hospitalsum - 200;
			Main.peoplesum = Main.peoplesum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 100 人</color>\n"
				+"<color=#ff0000>⊗醫療品減少 200 箱</color>\n";
		}
		else if (mission == 105 ) {
			Main.peoplesum = Main.peoplesum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 100 人</color>\n";
		}
		else if (mission == 106 ) {
			Main.hospitalsum = Main.hospitalsum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗醫療品減少 100 箱</color>\n";
		}
		else if (mission == 107 ) {
			Main.foodsum = Main.foodsum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 50 公斤\n";
		}
		else if (mission == 110 ) {
			Main.moneysum = Main.moneysum + 50;
			Main.peoplesum = Main.peoplesum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 100 人</color>\n"
				+"⊕金錢增加 50 法\n";;
		}
		else if (mission == 111 ) {
			Main.peoplesum = Main.peoplesum - 1;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 1 人</color>\n";
		}
		else if (mission == 113 ) {
			Main.weaponsum = Main.weaponsum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗武器減少 100 把</color>\n";
		}
		else if (mission == 115 ) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.hospitalsum = Main.hospitalsum - 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n"
				+"<color=#ff0000>⊗醫療品減少 50 箱</color>\n";
		}
		else if (mission == 116 ) {
			Main.peoplesum = Main.peoplesum - 10;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 10 人</color>\n";
		}
		else if (mission == 117 ) {
			Main.hospitalsum = Main.hospitalsum - 55;
			Main.peoplesum = Main.peoplesum - 40;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 40 人</color>\n"
				+"<color=#ff0000>⊗醫療品減少 55 箱</color>\n";
		}
		else if (mission == 118 ) {
			Main.weaponsum = Main.weaponsum - 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗武器減少 50 把</color>\n";
		}
		else if (mission == 119 ) {
			Main.moneysum = Main.moneysum + 25;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 25 法\n";
		}
		else if (mission == 120 ) {
			Main.peoplesum = Main.peoplesum + 2;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 2 人\n";
		}
		else if (mission == 121 ) {
			Main.peoplesum = Main.peoplesum + 30;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕食物增加 30 公斤\n";
		}
		else if (mission == 122 ) {
			Main.hospitalsum = Main.hospitalsum - 60;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗醫療品減少 60 箱</color>\n";
		}
		else if (mission == 123 ) {
			Main.peoplesum = Main.peoplesum - 80;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 80 人</color>\n";
		}
		else if (mission == 124 ) {
			Main.moneysum = Main.moneysum + 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 50 法\n";
		}
		else if (mission == 125 ) {
			Main.peoplesum = Main.peoplesum + 25;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 25 人\n";
		}
		else if (mission == 126 ) {
			Main.moneysum = Main.moneysum + 150;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕金錢增加 150 法\n";
		}
		else if (mission == 127 ) {
			Main.peoplesum = Main.peoplesum - 50;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗人口減少 50 人</color>\n";
		}
		else if (mission == 129 ) {
			Main.peoplesum = Main.peoplesum + 50;
			Main.weaponsum = Main.weaponsum - 80;
			Main.FadePlay = true;
			Obtaintext.text = 
				"⊕人口增加 50 人\n"
				+"<color=#ff0000>⊗武器減少 80 把</color>\n";
		}
		else if (mission == 130) {
			Main.moneysum = Main.moneysum + 120;
			Main.weaponsum = Main.weaponsum - 100;
			Main.FadePlay = true;
			Obtaintext.text = 
				"<color=#ff0000>⊗武器減少 100 把</color>\n"
				+"⊕金錢增加 120 法\n";
		}
		//主線任務******************************************************************************************************
		else if( mission == 131 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 61;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 132 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 62;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 133 && Main.Apeople>=1){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 63;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 134 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 64;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 135 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 65;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 136 && Main.Apeople>=1){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 66;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 137 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 67;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 138 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 68;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 139 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 69;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 140 && Main.Apeople>=3){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 70;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 141 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 71;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 142 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 72;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 143 && Main.Apeople>=3 && Main.Amoney>=3){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 73;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 144 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 74;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 145 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 75;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else if( mission == 146 ){
			MainMissionNumber = MainMissionNumber + 1;
			//儲存主線任務進度
			PlayerPrefs.SetInt("MainMissionNumber", MainMissionNumber );
			PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 	

			Story.Speak = 76;                     //發生故事編號
			StoryFadeout.SetActive(true);
		}
		else {
			Main.FadePlay = true;
			Datetext.text = " "; 
			choosetext1.text = " ";
			choosetext2.text = " ";
			Obtaintext.text = "沒什麼特別的事情發生\n";
		}
		missiontime = UnityEngine.Random.Range( 10, 20 );   //產生亂數(30~50);
		AllChoice++;                    //總事件數量+1
		BadChoice++;                    //壞選擇數量+1
		SaveImage.Play ();
		if (mission <= 130) {
			ObtainAnimate.SetActive (true);   //收獲訊息動畫
			ObtaintextAnimate.SetActive (true); //收獲訊息動畫
			ObtainMusic.Play ();
		}
	}//選擇2結束



}//結束============================================================================================================================================
