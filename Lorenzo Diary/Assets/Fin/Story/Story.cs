//對話系統
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

//===============================================================================================================================
public class Story : MonoBehaviour {

	//宣告變數*****************************************************************************************
	public static int Speak=3;        //發生故事編號
	int[] Speakc = new int[100];      //故事內容編號
	public Text NameText = null;      //名字Text
	public Text ContentText = null;   //對話內容Text
	public GameObject ContectPoint;   //內容點

	public Text NameTextRight;         //右邊名字Text
	public GameObject NameshadowRight; //右邊人物名稱外框

	public Text PlaceNameText;         //地點名字Text

	public GameObject  BackButton;    //回到主畫面按鈕 
	public GameObject  Fadeout;       //淡出  
	public AudioSource ButtonMusic;   //按扭音效

	//宣告動畫
	public Animation  TalkAnimation;  //對話動畫
	public GameObject Police;         //警察動畫
	public GameObject Doctor;         //醫生動畫
	public GameObject Knight;         //騎士
	public GameObject Captain;        //船長
	public GameObject Person;         //人民
	public GameObject Devil;          //惡魔 
	public GameObject Angel;          //天使 
	public GameObject Business;       //商人
	public GameObject DreamOwner;     //夢境人

	/*public GameObject King;         //國王
	public GameObject Queen;          //皇后
	public GameObject Judger;         //法官
	public GameObject Wizard;         //巫師
	public GameObject Pope;           //主教
	public GameObject Jew;            //猶太人*/

	//宣告音效
	public AudioSource CastleinAudio;       //城堡內部音效
	public AudioSource StreetAudio;         //街道音效
	public AudioSource CelebrateRoomAudio;  //宴會房間音效
	public AudioSource ForestAudio;         //森林音效
	public AudioSource RoomAudio;           //房間音效
	public AudioSource DreamAudio;          //夢境音效

	//宣告背景
	public GameObject Castlein;       //城堡內部
	public GameObject Street;         //街道
	public GameObject CelebrateRoom;  //宴會房間
	public GameObject Forest;         //森林
	public GameObject Room;           //房間
	public GameObject Dream;          //夢境

	float timef;

	//==========================================================================================================
	// Use this for initialization******************************************************************************
	void Start () {
		BackButton.SetActive (false); //隱藏主畫面按鈕
		Fadeout.SetActive (false);    //隱藏淡出畫面   

		//隱藏圖型
		Police.SetActive (false);     //隱藏警察
		Doctor.SetActive (false);     //隱藏醫生
		Knight.SetActive (false);     //隱藏騎士
		Captain.SetActive (false);    //船長
		Person.SetActive (false);     //人民
		Devil.SetActive (false);      //惡魔 
		Angel.SetActive (false);      //天使 
		Business.SetActive (false);   //商人
		DreamOwner.SetActive (false); //夢境人
		//NameshadowRight.SetActive (false); //隱藏右邊對話外框
		//NameTextRight.text = " ";          //隱藏右邊名字Text

		//背景
		Castlein.SetActive (false);   //隱藏背景
		Street.SetActive (false);     //隱藏背景
		CelebrateRoom.SetActive (false);
		Forest.SetActive (false);
		Room.SetActive (false);
		Dream.SetActive (false);

		//音樂播放*****************************
		if(Speak==1 || Speak==2 ||  Speak==3 || Speak==7 || Speak==8 || Speak==11 || Speak==12 || Speak==13 || Speak==17 || Speak==20 || Speak==26 || Speak==27 || Speak==28 || Speak==29 || Speak==31 || Speak==32 || 
			Speak==34 || Speak==37 || Speak==39 || Speak==40 || Speak==41 || Speak==45 || Speak==51 || Speak==52 || Speak==54 || Speak==60 )CastleinAudio.Play ();     //播放音樂:城堡內部
		else if(Speak==6 || Speak==10 || Speak==15 || Speak==18 || Speak==33 || Speak==35 || Speak==38 || Speak==49 || Speak==53 || Speak==56 ) StreetAudio.Play (); //播放音樂:街道
		else if(Speak==4 || Speak==9 || Speak==36 || Speak==57 ) CelebrateRoomAudio.Play (); //播放音樂:宴會房間
		else if(Speak==5 || Speak==47 || Speak==48 || Speak==55 || Speak==59 ) ForestAudio.Play (); //播放音樂:森林
		else if(Speak>=61 && Speak<=76) DreamAudio.Play (); //播放音樂:夢境
		else RoomAudio.Play ();                //播放音樂:房間

		//背景*********************************
		if (Speak==1 || Speak==2 ||  Speak==3 || Speak==7 || Speak==8 || Speak==11 || Speak==12 || Speak==13 || Speak==17 || Speak==20 || Speak==26 || Speak==27 || Speak==28 || Speak==29 || Speak==31 || Speak==32 || 
			Speak==34 || Speak==37 || Speak==39 || Speak==40 || Speak==41 || Speak==45 || Speak==51 || Speak==52 || Speak==54 || Speak==60 ){
			Castlein.SetActive (true);   //城堡內部背景
			PlaceNameText.text = "城堡的議會廳";
		} else if (Speak==6 || Speak==10 || Speak==15 || Speak==18 || Speak==33 || Speak==35 || Speak==38 || Speak==49 || Speak==53 || Speak==56 ) {
			Street.SetActive (true); //街道背景
			PlaceNameText.text = "街道";
		} else if (Speak==4 || Speak==9 || Speak==36 || Speak==57 )  {
			CelebrateRoom.SetActive (true); //宴會房間背景
			PlaceNameText.text = "宴會的房間";
		} else if(Speak==5 || Speak==47 || Speak==48 || Speak==55 || Speak==59 ) {
			Forest.SetActive (true); //森林背景
			PlaceNameText.text = "郊邊的森林";
		} else if(Speak>=61 && Speak<=76) {
			Forest.SetActive (true); //夢境背景
			PlaceNameText.text = "羅倫佐的夢境";
		}else {
			Room.SetActive (true);   //房間背景
			PlaceNameText.text = "某處房間";
		}
		//讀入
		Placeyesno.Placetime =  PlayerPrefs.GetInt("Placetime1"); //讀入成就記錄(以下相同)
		Placeyesno2.Placetime =  PlayerPrefs.GetInt("Placetime2"); //讀入成就記錄(以下相同)
		Placeyesno3.Placetime =  PlayerPrefs.GetInt("Placetime3"); //讀入成就記錄(以下相同)
		Placeyesno4.Placetime =  PlayerPrefs.GetInt("Placetime4"); //讀入成就記錄(以下相同)
		Placeyesno5.Placetime =  PlayerPrefs.GetInt("Placetime5"); //讀入成就記錄(以下相同)
		

	
	}//Start結束===========================================================================================
	
	// Update is called once per frame===========================================================================================================
	void Update () {

		//如果船已經出航*******************************************************************************************************
		timef +=Time.deltaTime;   //記錄時間
		if (timef >= 1) { //如果時間>=1 && Placetime[0]!=0 && 已按下按鈕 
			if(Placeyesno.Placetime!=30 && Placeyesno.Placetime!=0) Placeyesno.Placetime--;
			if(Placeyesno2.Placetime!=60 && Placeyesno2.Placetime!=0) Placeyesno2.Placetime--;
			if(Placeyesno3.Placetime!=80 && Placeyesno3.Placetime!=0) Placeyesno3.Placetime--;
			if(Placeyesno4.Placetime!=100 && Placeyesno4.Placetime!=0) Placeyesno4.Placetime--;
			if(Placeyesno5.Placetime!=120 && Placeyesno5.Placetime!=0) Placeyesno5.Placetime--;
			timef = 0;
		}

		PlayerPrefs.SetInt("Placetime1", Placeyesno.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime2", Placeyesno2.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime3", Placeyesno3.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime4", Placeyesno4.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Placetime5", Placeyesno5.Placetime );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 */
		//*******************************************************************************************************
		//*******************************************************************************************************
		//對話顏色6E9B84FF FF9B84FF
		//對話1(Mission2_1 兩個人對話)***********************************************************************************************	
		if (Speak == 1) {
			//左邊
			NameText.text = "騎士道尼爾"; //說話者名字
			Knight.SetActive (true);      //說話者圖型
			//右邊
			//NameTextRight.text = "<color=#FF9B84FF>大衛醫生</color>";
			//Doctor.SetActive (true);
			//NameshadowRight.SetActive (true); //隱藏右邊對話外框

			if(Input.GetMouseButtonDown (0)) {
				Speakc[1]++;  //按一次左鍵,故事內容編號+1
				if(Speakc[1]<=2)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容(一行最多28個字)
			if (Speakc[1] == 0 ) ContentText.text = "城市的人民被強盜團洗劫一空。";
			else if (Speakc[1] == 1) ContentText.text = "在增加人手的情況下已經在下城區抓到主謀。";
			else if (Speakc[1] == 2) ContentText.text = "這裡是一點人民們的心意，請收下。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話1結束***********************************************************************************************	

		//對話2(Mission100_2 右邊的人說話)***********************************************************************************************	
		else if (Speak == 2) {
			//左邊
			NameText.text = " "; //說話者名字
			//右邊
			NameTextRight.text = "大衛醫生";
			Doctor.SetActive (true);
			if(Input.GetMouseButtonDown (0)) {
				Speakc[2]++; //按一次左鍵,故事內容編號+1
				if(Speakc[2]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[2] == 0 ) ContentText.text = "由於醫療品不足。";
			else if (Speakc[2] == 1) ContentText.text = "大量的人民在病痛中離去。";
			else if (Speakc[2] == 2) ContentText.text = "這一切都要歸功於國王的「仁政」。";
			else if (Speakc[2] == 3) ContentText.text = "我先離開了。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話2結束***********************************************************************************************	

		//對話3(Mission4_1 左邊的人說話)***********************************************************************************************	
		else if (Speak == 3) {
			//左邊
			NameText.text = "<color=#6E9B84FF>丹尼爾騎士</color>";//說話者名字
			Knight.SetActive (true);     //說話者圖型
			//右邊
			NameTextRight.text = " ";

			if(Input.GetMouseButtonDown (0)) {
				Speakc[3]++; //按一次左鍵,故事內容編號+1
				if(Speakc[3]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[3] == 0 ) ContentText.text = "聽說城裡出現了一位罪大惡極的犯人!";
			else if (Speakc[3] == 1) ContentText.text = "在加強巡邏以及增派士兵人數。";
			else if (Speakc[3] == 2) ContentText.text = "犯人似乎已經出城了。";
			else if (Speakc[3] == 3) ContentText.text = "人民不用在驚慌了。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話3結束***********************************************************************************************	

		//對話4(Mission5_1)***********************************************************************************************	
		else if (Speak == 4) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[4]++; //按一次左鍵,故事內容編號+1
				if(Speakc[4]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[4] == 0 ) ContentText.text = "這次為了丹爾爵士舉辦歡迎宴會。";
			else if (Speakc[4] == 1) ContentText.text = "可以增加兩國之間的聯繫。";
			else if (Speakc[4] == 2) ContentText.text = "畢竟多個朋友也好過多一個敵人。";
			else if (Speakc[4] == 3) ContentText.text = "好好享受宴會吧。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話4結束***********************************************************************************************	

		//對話5(Mission7_1)***********************************************************************************************	
		else if (Speak == 5) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[5]++; //按一次左鍵,故事內容編號+1
				if(Speakc[5]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[5] == 0 ) ContentText.text = "難得一次的打獵，竟然可以碰上巨大野兔。";
			else if (Speakc[5] == 1) ContentText.text = "一定要把牠活捉起來。";
			else if (Speakc[5] == 2) ContentText.text = "展示給全國的人民觀賞。";
			else if (Speakc[5] == 3) ContentText.text = "打起精神，跟我一起舉弓。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話5結束***********************************************************************************************	

		//對話6(Mission9_1)***********************************************************************************************	
		else if (Speak == 6) {
			NameText.text = "肯威船長";  //說話者名字
			Captain.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[6]++; //按一次左鍵,故事內容編號+1
				if(Speakc[6]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[6] == 0 ) ContentText.text = "聽說在海上有一座藏著寶藏的島嶼。";
			else if (Speakc[6] == 1) ContentText.text = "也許跟亨利.艾佛瑞有關。";
			else if (Speakc[6] == 2) ContentText.text = "許多人一直想找到但都是無功而返。";
			else if (Speakc[6] == 3) ContentText.text = "不知道這次出航我們能不能幸運一點。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話6結束***********************************************************************************************	

		//對話7(Mission11_1)***********************************************************************************************	
		else if (Speak == 7) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[7]++; //按一次左鍵,故事內容編號+1
				if(Speakc[7]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[7] == 0 ) ContentText.text = "最近天氣穩定，農作物收成情況良好。";
			else if (Speakc[7] == 1) ContentText.text = "國王決定分發給人民。";
			else if (Speakc[7] == 2) ContentText.text = "不然這麼多的農作物，倉庫也塞不下。";
			else if (Speakc[7] == 3) ContentText.text = "你就依照這份名單依序分配吧。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話7結束***********************************************************************************************	


		//對話8(Mission16_2)***********************************************************************************************	
		else if (Speak == 8) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[8]++; //按一次左鍵,故事內容編號+1
				if(Speakc[8]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[8] == 0 ) ContentText.text = "建立教堂，不過是人民想有個跟上帝接觸的地方。";
			else if (Speakc[8] == 1) ContentText.text = "國王卻連這一點要求都不肯。";
			else if (Speakc[8] == 2) ContentText.text = "只會不斷宴請各國的貴族。";
			else if (Speakc[8] == 3) ContentText.text = "真不知道要怎麼辦。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話8結束***********************************************************************************************	

		//對話9(Mission17_1)***********************************************************************************************	
		else if (Speak == 9) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[9]++; //按一次左鍵,故事內容編號+1
				if(Speakc[9]<=4)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[9] == 0 ) ContentText.text = "這次的世界會議來了許多王族和貴族。";
			else if (Speakc[9] == 1) ContentText.text = "喬治國王、亞歷山大國王、亨利公爵、彼得伯爵、伊凡男爵......。";
			else if (Speakc[9] == 2) ContentText.text = "這次會議將要決定未來世界的走向。";
			else if (Speakc[9] == 3) ContentText.text = "雖然各國都有各自的想法。";
			else if (Speakc[9] == 4) ContentText.text = "但奧迪托雷國王應該會選擇保持原樣。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話9結束***********************************************************************************************	

		//對話10(Mission18_1)***********************************************************************************************	
		else if (Speak == 10) {
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[10]++; //按一次左鍵,故事內容編號+1
				if(Speakc[10]<=4)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[10] == 0 ) ContentText.text = "地方的民眾和官員爆發了衝突!";
			else if (Speakc[10] == 1) ContentText.text = "主要的原因好像是官員想要增加稅金。";
			else if (Speakc[10] == 2) ContentText.text = "民眾不願意，在爭吵的過程中。";
			else if (Speakc[10] == 3) ContentText.text = "發生了一些肢體衝突。";
			else if (Speakc[10] == 4) ContentText.text = "我已經派人去說服，應該很快就能解決。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話10結束***********************************************************************************************	


		//對話11(Mission19_2)***********************************************************************************************	
		else if (Speak == 11) {
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[11]++; //按一次左鍵,故事內容編號+1
				if(Speakc[11]<=4)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[11] == 0 ) ContentText.text = "鄰國要求我們支付和平資金。";
			else if (Speakc[11] == 1) ContentText.text = "國王最後決定不支付。";
			else if (Speakc[11] == 2) ContentText.text = "這樣兩國就有可能發生衝突。";
			else if (Speakc[11] == 3) ContentText.text = "最近這幾個月需要派兵到兩國邊境。";
			else if (Speakc[11] == 4) ContentText.text = "防止對方發動突襲。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話11結束***********************************************************************************************	

		//對話12(Mission19_1)***********************************************************************************************	
		else if (Speak == 12) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[12]++; //按一次左鍵,故事內容編號+1
				if(Speakc[12]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[12] == 0 ) ContentText.text = "城裡來了一群外來民族，說要進貢。";
			else if (Speakc[12] == 1) ContentText.text = "國王已經宣告召見";
			else if (Speakc[12] == 2) ContentText.text = "他們帶來的東西十分罕見。";
			else if (Speakc[12] == 3) ContentText.text = "我還沒在國內看過。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話12結束***********************************************************************************************	

		//對話13(Mission23_1)***********************************************************************************************	
		else if (Speak == 13) {
			NameText.text = "丹尼爾騎士";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[13]++; //按一次左鍵,故事內容編號+1
				if(Speakc[13]<=4)TalkAnimation.Play();
			}
			
			//依照故事內容編號顯示對話內容
			if (Speakc[13] == 0 ) ContentText.text = "武器庫發生火災。";
			else if (Speakc[13] == 1) ContentText.text = "國王要求先救人。";
			else if (Speakc[13] == 2) ContentText.text = "至於武器能拿回多少就拿回多少。";
			else if (Speakc[13] == 3) ContentText.text = "不知道是什麼引發了火災。";
			else if (Speakc[13] == 4) ContentText.text = "之後需要查清楚。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話13結束***********************************************************************************************	

		//對話14(Mission24_1)***********************************************************************************************	
		else if (Speak == 14) {
			NameTextRight.text = "大衛醫生";
			Doctor.SetActive (true);
			if(Input.GetMouseButtonDown (0)){
				Speakc[14]++; //按一次左鍵,故事內容編號+1
				if(Speakc[14]<=3)TalkAnimation.Play();
			}
			
			//依照故事內容編號顯示對話內容
			if (Speakc[14] == 0 ) ContentText.text = "經過這麼多時間的研究。";
			else if (Speakc[14] == 1) ContentText.text = "藥品製作上已經能提高成功率。";
			else if (Speakc[14] == 2) ContentText.text = "這樣子人民生病也可以有更多機會可以救活。";
			else if (Speakc[14] == 3) ContentText.text = "這一切都是值得的。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話14結束***********************************************************************************************	

		//對話15(Mission27_1)***********************************************************************************************	
		else if (Speak == 15) {
			NameText.text = "肯威船長";//說話者名字
			Captain.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[15]++; //按一次左鍵,故事內容編號+1
				if(Speakc[15]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[15] == 0 ) ContentText.text = "舊金山發現了一做新的金礦場。";
			else if (Speakc[15] == 1) ContentText.text = "這座金礦的含金量很高。";
			else if (Speakc[15] == 2) ContentText.text = "但原先的礦場主人似乎要我們支付一大筆錢買下礦場。";
			else if (Speakc[15] == 3) ContentText.text = "國王已經授權給我命令我拿著現金買下。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話15結束***********************************************************************************************	

		//對話16(Mission28_1)***********************************************************************************************	
		else if (Speak == 16) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[16]++; //按一次左鍵,故事內容編號+1
				if(Speakc[16]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[16] == 0 ) ContentText.text = "最近大雨不斷，農田的作物都爛掉。";
			else if (Speakc[16] == 1) ContentText.text = "我正在派人確認這次的損失。";
			else if (Speakc[16] == 2) ContentText.text = "希望不會太嚴重。";
			else if (Speakc[16] == 3) ContentText.text = "不然接下來人民就會開始抗議。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話16結束***********************************************************************************************	

		//對話17(Mission29_1)***********************************************************************************************	
		else if (Speak == 17) {
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[17]++; //按一次左鍵,故事內容編號+1
				if(Speakc[17]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[17] == 0 ) ContentText.text = "國庫在昨天夜裡被小偷洗劫。";
			else if (Speakc[17] == 1) ContentText.text = "這麼大量的金錢是不可能一個人搬完。";
			else if (Speakc[17] == 2) ContentText.text = "肯定有內部的人在接應。";
			else if (Speakc[17] == 3) ContentText.text = "需要一些證據才能繩之以法。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話17結束***********************************************************************************************

		//對話18(Mission30_1)***********************************************************************************************	
		else if (Speak == 18) {
			NameText.text = "人民";//說話者名字
			Person.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){ 
				Speakc[18]++; //按一次左鍵,故事內容編號+1
				if(Speakc[18]<=3)TalkAnimation.Play();
			}
			
			//依照故事內容編號顯示對話內容
			if (Speakc[18] == 0 ) ContentText.text = "感謝你們願意在如此偏遠的地區興建學校。";
			else if (Speakc[18] == 1) ContentText.text = "這樣子地方上的孩子都能念書。";
			else if (Speakc[18] == 2) ContentText.text = "這裡是我們一點心意。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話18結束***********************************************************************************************

		//對話19(Mission32_1)***********************************************************************************************	
		else if (Speak == 19) {
			NameText.text = "肯威船長";//說話者名字
			Captain.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[19]++; //按一次左鍵,故事內容編號+1
				if(Speakc[19]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[19] == 0 ) ContentText.text = "暴風雨來襲，商船全部沉入海底。";
			else if (Speakc[19] == 1) ContentText.text = "在船上的船員也都全數罹難。";
			else if (Speakc[19] == 2) ContentText.text = "也需要安撫罹難者的家屬。";
			else if (Speakc[19] == 3) ContentText.text = "損失難已估算。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話19結束***********************************************************************************************

		//對話20(Mission33_1)***********************************************************************************************	
		else if (Speak == 20) {
			NameTextRight.text = "大衛醫生";
			Doctor.SetActive (true);
			if(Input.GetMouseButtonDown (0)) {
				Speakc[20]++; //按一次左鍵,故事內容編號+1
				if(Speakc[20]<=3)TalkAnimation.Play();
			}
			//依照故事內容編號顯示對話內容
			if (Speakc[20] == 0 ) ContentText.text = "街道上出現一位販賣假藥的人。";
			else if (Speakc[20] == 1) ContentText.text = "竟然有這種沒良心的人。";
			else if (Speakc[20] == 2) ContentText.text = "幸虧道尼爾發現。";
			else if (Speakc[20] == 3) ContentText.text = "不然這種來歷不明的徦藥，讓人吃下去不知道會發生什麼事。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話20結束***********************************************************************************************

		//對話21(Mission8_1)***********************************************************************************************	
		else if (Speak == 21) {
			NameText.text = "天使";//說話者名字
			Angel.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[21]++; //按一次左鍵,故事內容編號+1
				if(Speakc[21]<=7)TalkAnimation.Play();
			}
				//Startfunction.storymission [0] = 1; //紀錄對話觸發

			//依照故事內容編號顯示對話內容
			if (Speakc[21] == 0 ) ContentText.text = "告訴我，孩子，你裝著怎樣的想法？";
			else if (Speakc[21] == 1) ContentText.text = "道德、安定、還是美夢？";
			else if (Speakc[21] == 2) ContentText.text = "亨利.艾佛瑞一直活在你的夢中。";
			else if (Speakc[21] == 3) ContentText.text = "亨利.艾佛瑞一直在等，等著那位跟他有一樣想法的人。";
			else if (Speakc[21] == 4) ContentText.text = "你雖然在奧迪托雷國王底下做事。";
			else if (Speakc[21] == 5) ContentText.text = "但你的心中卻總是對國王的所作所為......，有所疑惑。";
			else if (Speakc[21] == 6) ContentText.text = "亨利.艾佛瑞可以解決這件事情。";
			else if (Speakc[21] == 7) ContentText.text = "今晚將是一場美妙的美夢。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話21結束***********************************************************************************************

		//對話22(Mission8_2)***********************************************************************************************	
		else if (Speak == 22) {
			NameText.text = "惡魔";//說話者名字
			Devil.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[22]++; //按一次左鍵,故事內容編號+1
				if(Speakc[22]<=8)TalkAnimation.Play();
			}
				//Startfunction.storymission [0] = 1; //紀錄對話觸發

			//依照故事內容編號顯示對話內容
			if (Speakc[22] == 0 ) ContentText.text = "告訴我，孩子，你腦子裡在想些什麼？";
			else if (Speakc[22] == 1) ContentText.text = "獵殺、血液、還是噩夢？";
			else if (Speakc[22] == 2) ContentText.text = "亨利.艾佛瑞一直活在你的夢中。";
			else if (Speakc[22] == 3) ContentText.text = "亨利.艾佛瑞一直在等，等著那位跟他有一樣想法的人。";
			else if (Speakc[22] == 4) ContentText.text = "現在我會對你開恩。";
			else if (Speakc[22] == 5) ContentText.text = "你將離去，忘掉這個夢，並在清晨的陽光下醒來。";
			else if (Speakc[22] == 6) ContentText.text = "你將得到解脫...。";
			else if (Speakc[22] == 7) ContentText.text = "...不再受到噩夢的侵擾。";
			else if (Speakc[22] == 8) ContentText.text = "今晚亨利.艾佛瑞以及他的船員將加入這場行動.......。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話22結束***********************************************************************************************

		//對話23(Mission21_1)***********************************************************************************************	
		else if (Speak == 23) {
			NameText.text = "惡魔";//說話者名字
			Devil.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[23]++; //按一次左鍵,故事內容編號+1
				if(Speakc[23]<=8)TalkAnimation.Play();
			}
				//Startfunction.storymission [1] = 1; //紀錄對話觸發

			//依照故事內容編號顯示對話內容
			if (Speakc[23] == 0 ) ContentText.text = "夜晚來臨，今晚是狩獵之夜!";
			else if (Speakc[23] == 1) ContentText.text = "高樹多悲風，海水揚其波。";
			else if (Speakc[23] == 2) ContentText.text = "利劍不再掌，結友何須多。";
			else if (Speakc[23] == 3) ContentText.text = "航海自古以來就是屬於男人的浪漫。";
			else if (Speakc[23] == 4) ContentText.text = "勇敢的水手們與天風海雨赤身搏鬥。";
			else if (Speakc[23] == 5) ContentText.text = "身後留下的傳奇不計其數......";
			else if (Speakc[23] == 6) ContentText.text = "那摻雜了陽光與海風的笛聲響起時。";
			else if (Speakc[23] == 7) ContentText.text = "亨利.艾佛瑞對大海的嚮往。";
			else if (Speakc[23] == 8) ContentText.text = "以及那不斷膨的財富渴望.......。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話23結束***********************************************************************************************


		//對話24(Mission22_2)***********************************************************************************************	
		else if (Speak == 24) {
			NameText.text = "惡魔";//說話者名字
			Devil.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[24]++; //按一次左鍵,故事內容編號+1
				if(Speakc[24]<=16)TalkAnimation.Play();
			}
				//Startfunction.storymission [2] = 1; //紀錄對話觸發

			//依照故事內容編號顯示對話內容
			if (Speakc[24] == 0 ) ContentText.text = "這一名血療師.......";
			else if (Speakc[24] == 1) ContentText.text = "是當年亨利.艾佛瑞船上的一位隨行船醫";
			else if (Speakc[24] == 2) ContentText.text = "由於出航一次需要相當長的時間。";
			else if (Speakc[24] == 3) ContentText.text = "這一次更是在海上漂泊了三個月。";
			else if (Speakc[24] == 4) ContentText.text = "船員們普遍都營養不足。";
			else if (Speakc[24] == 5) ContentText.text = "後來，船員一個一個病倒了，有的牙床破了，有的皮膚上出現斑斑血點。";
			else if (Speakc[24] == 6) ContentText.text = "有的流鼻血，有的渾身沒勁，隨後船員一個接著一個死去。";
			else if (Speakc[24] == 7) ContentText.text = "這名船醫才發現船員罹患壞血病而有死亡的危險。";
			else if (Speakc[24] == 8) ContentText.text = "這位船醫發現壞血病都發生在一般船員身上。";
			else if (Speakc[24] == 9) ContentText.text = "而包含他自己在內的船上幹部，卻沒有人得到壞血病。";
			else if (Speakc[24] == 10) ContentText.text = "直到有一天，他為了照顧病人到一般船員的餐廳用餐，才有了新的發現。";
			else if (Speakc[24] == 11) ContentText.text = "原來一般船員的伙食，只有麵包與醃肉。";
			else if (Speakc[24] == 12) ContentText.text = "而幹部們卻有馬鈴薯與高麗菜芽可以吃。";
			else if (Speakc[24] == 13) ContentText.text = "因此這位船醫認為，新鮮蔬果或許可以治療壞血病。";
			else if (Speakc[24] == 14) ContentText.text = "後來，他們遇上了滿載柳橙與檸檬的荷蘭貨船。";
			else if (Speakc[24] == 15) ContentText.text = "於是他們就將貨船劫了下來。";
			else if (Speakc[24] == 16) ContentText.text = "船醫用柳橙與檸檬來治療壞血病人，效果非常好。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話24結束***********************************************************************************************

		//對話25(Mission26_1)***********************************************************************************************	
		else if (Speak == 25) {
			NameText.text = "惡魔";//說話者名字
			Devil.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[25]++; //按一次左鍵,故事內容編號+1
				if(Speakc[25]<=10)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[25] == 0 ) ContentText.text = "今晚來跟你說說「羅倫佐.托雷」，一名海盜。";
			else if (Speakc[25] == 1) ContentText.text = "一位名為「羅倫佐.托雷」的海盜追查「傳奇海盜亨利.艾佛瑞」的巨額財富";
			else if (Speakc[25] == 2) ContentText.text = "亨利.艾佛瑞在晚年的時候靠著計謀，獲取了難以想像的財寶。";
			else if (Speakc[25] == 3) ContentText.text = "但是艾佛瑞最後把財寶藏到了哪沒有人知道。";
			else if (Speakc[25] == 4) ContentText.text = "不過羅倫佐.托雷也不是一名省油的燈。";
			else if (Speakc[25] == 5) ContentText.text = "總是能從一絲線索中找到更多。";
			else if (Speakc[25] == 6) ContentText.text = "隨著調查深入,羅倫佐發現亨利.艾佛瑞與當時名揚海外的十一位大海盜。";
			else if (Speakc[25] == 7) ContentText.text = "共同建立了一個屬於海盜們的理想社會，一個「烏托邦」。";
			else if (Speakc[25] == 8) ContentText.text = "並將其命名為萊伯塔利亞(Libertalia)。";
			else if (Speakc[25] == 9) ContentText.text = "「萊伯塔利亞」到底是一個什麼樣的地方。";
			else if (Speakc[25] == 10) ContentText.text = "現實世界「萊伯塔利亞」是真的存在嗎?";

			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話25結束***********************************************************************************************

		//對話26(Mission35_1)***********************************************************************************************	
		else if (Speak == 26) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[26]++; //按一次左鍵,故事內容編號+1
				if(Speakc[26]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[26] == 0 ) ContentText.text = "隨著釀酒技術的發展，食物吃不完都可以拿來釀酒。";
			else if (Speakc[26] == 1) ContentText.text = "總算是可以減少每年食物的浪費。";
			else if (Speakc[26] == 2) ContentText.text = "酒的產量有所增加。";
			else if (Speakc[26] == 3) ContentText.text = "地方上的酒館也可以增加收入。";
			else if (Speakc[26] == 4) ContentText.text = "對國家也是一筆可觀的收入。";
			else if (Speakc[26] == 5) ContentText.text = "應該在過不久所有的食物都可以拿來釀酒。";

			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話26結束***********************************************************************************************

		//對話27(Mission36_2)***********************************************************************************************	
		else if (Speak == 27) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[27]++; //按一次左鍵,故事內容編號+1
				if(Speakc[27]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[27] == 0 ) ContentText.text = "隨著學校的建立越來越多人得到教育。";
			else if (Speakc[27] == 1) ContentText.text = "人民的知識水準越來越高。";
			else if (Speakc[27] == 2) ContentText.text = "能夠為國家提供才能。";
			else if (Speakc[27] == 3) ContentText.text = "如此國家才會越來越強大。";
			else if (Speakc[27] == 4) ContentText.text = "不過還是有許多偏僻地區的人民沒有學校。";
			else if (Speakc[27] == 5) ContentText.text = "需要繼續努力。";

			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話27結束***********************************************************************************************

		//對話28(Mission38_1)***********************************************************************************************	
		else if (Speak == 28) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){ 
				Speakc[28]++; //按一次左鍵,故事內容編號+1
				if(Speakc[28]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[28] == 0 ) ContentText.text = "西方的國王即將來訪。";
			else if (Speakc[28] == 1) ContentText.text = "國王要我們親自去迎接。";
			else if (Speakc[28] == 2) ContentText.text = "這次來訪應該是要跟我國商討同盟事議。";
			else if (Speakc[28] == 3) ContentText.text = "畢竟現在我國國力強盛。";
			else if (Speakc[28] == 4) ContentText.text = "許多周邊小國都希望能跟我們結盟以保平安。";

			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話28結束***********************************************************************************************

		//對話29(Mission40_1)***********************************************************************************************	
		else if (Speak == 29) {
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[29]++; //按一次左鍵,故事內容編號+1
				if(Speakc[29]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[29] == 0 ) ContentText.text = "鄰國正謀畫攻打我們。";
			else if (Speakc[29] == 1) ContentText.text = "國王要我們派兵支援邊境。";
			else if (Speakc[29] == 2) ContentText.text = "雖然會損失一些兵力。";
			else if (Speakc[29] == 3) ContentText.text = "但至少可以將邊境地區的人民的死傷降到最低。";
			else if (Speakc[29] == 4) ContentText.text = "我一定會達成使命。";

			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話29結束***********************************************************************************************

		//對話30(Mission42_1)***********************************************************************************************	
		else if (Speak == 30) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[30]++; //按一次左鍵,故事內容編號+1
				if(Speakc[30]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[30] == 0 ) ContentText.text = "一隻鴿子腳上綁著一封信。";
			else if (Speakc[30] == 1) ContentText.text = "好像是道尼爾騎士傳來好消息。";
			else if (Speakc[30] == 2) ContentText.text = "信上寫說鄰國已經節節敗退。";
			else if (Speakc[30] == 3) ContentText.text = "派出降使準備到我國，請求投降。";
			else if (Speakc[30] == 4) ContentText.text = "國王知道了一定會很高興。";
			else if (Speakc[30] == 5) ContentText.text = "我們趕快去告訴陛下。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話30結束***********************************************************************************************

		//對話31(Mission43_1)***********************************************************************************************	
		else if (Speak == 31) {
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[31]++; //按一次左鍵,故事內容編號+1
				if(Speakc[31]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[31] == 0 ) ContentText.text = "城裡發生了爆炸!";
			else if (Speakc[31] == 1) ContentText.text = "快把城門關上，別讓犯人逃出城。";
			else if (Speakc[31] == 2) ContentText.text = "二號部隊趕快到爆炸地點處理傷患。";
			else if (Speakc[31] == 3) ContentText.text = "五號部隊則巡邏，找找看是否有其它炸藥。";
			else if (Speakc[31] == 4) ContentText.text = "犯人一定在附近，必須趕緊找出來。";
			else if (Speakc[31] == 5) ContentText.text = "也要趕緊告訴陛下。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話31結束***********************************************************************************************

		//對話32(Mission45_2)***********************************************************************************************	
		else if (Speak == 32) {
			NameTextRight.text = "大衛醫生";
			Doctor.SetActive (true);
			if(Input.GetMouseButtonDown (0)){
				Speakc[32]++; //按一次左鍵,故事內容編號+1
				if(Speakc[32]<=6)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[32] == 0 ) ContentText.text = "一場黑死病，病死了許多人民。";
			else if (Speakc[32] == 1) ContentText.text = "每天得病的人越來越多。";
			else if (Speakc[32] == 2) ContentText.text = "得病的人皮膚開始皮下出血而變黑。";
			else if (Speakc[32] == 3) ContentText.text = "一開始是一位男性農夫，以為只是一般的感冒。";
			else if (Speakc[32] == 4) ContentText.text = "卻在一夜之間皮膚大量出血，隔天早上就死去。";
			else if (Speakc[32] == 5) ContentText.text = "緊接著，農夫的家人也開始出現症狀。";
			else if (Speakc[32] == 6) ContentText.text = "簡直是一場災難。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話32結束***********************************************************************************************

		//對話33(Mission48_1)***********************************************************************************************	
		else if (Speak == 33) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[33]++; //按一次左鍵,故事內容編號+1
				if(Speakc[33]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[33] == 0 ) ContentText.text = "商人們想要組織一個行會。";
			else if (Speakc[33] == 1) ContentText.text = "從而制訂一套商業規則。";
			else if (Speakc[33] == 2) ContentText.text = "現在國王已經同意。";
			else if (Speakc[33] == 3) ContentText.text = "我需要聯絡各大行業的領頭。";
			else if (Speakc[33] == 4) ContentText.text = "雖然這樣會讓經濟掌握在一些人手上。";
			else if (Speakc[33] == 5) ContentText.text = "但能解決市場價格隨意浮動的情況。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話33結束***********************************************************************************************

		//對話34(Mission49_1)***********************************************************************************************	
		else if (Speak == 34) {
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[34]++; //按一次左鍵,故事內容編號+1
				if(Speakc[34]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[34] == 0 ) ContentText.text = "聽說有一位公主被關在地牢裡。";
			else if (Speakc[34] == 1) ContentText.text = "現在我派你和道尼爾騎士，去將這位公主帶回來。";
			else if (Speakc[34] == 2) ContentText.text = "如果你們成功了將會有獎賞。";
			else if (Speakc[34] == 3) ContentText.text = "我在皇宮裡等著你們的好消息。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話34結束***********************************************************************************************

		//對話35(Mission51_1)***********************************************************************************************	
		else if (Speak == 35) {
			NameText.text = "村民";//說話者名字
			Person.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[35]++; //按一次左鍵,故事內容編號+1
				if(Speakc[35]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[35] == 0 ) ContentText.text = "公爵，我們在挖井的時候發現井底到處都是金子。";
			else if (Speakc[35] == 1) ContentText.text = "公爵，現在該怎麼辦？";
			else if (Speakc[35] == 2) ContentText.text = "真的嗎!公爵願意把黃金全部給我們村子。";
			else if (Speakc[35] == 3) ContentText.text = "太好了!村裡的人一定會很高興。";
			else if (Speakc[35] == 4) ContentText.text = "今年可以過一個好年了。";
			else if (Speakc[35] == 5) ContentText.text = "謝謝公爵大人。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話35結束***********************************************************************************************

		//對話36(Mission53_1)***********************************************************************************************	
		else if (Speak == 36) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[36]++; //按一次左鍵,故事內容編號+1
				if(Speakc[36]<=13)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[36] == 0 ) ContentText.text = "西方的王國「大不列顛帝國的國王-溫特沃斯王」將要來訪。";
			else if (Speakc[36] == 1) ContentText.text = "跟上次派使臣不同，這次是親自到來。";
			else if (Speakc[36] == 2) ContentText.text = "奧迪托雷國王也很看重這次的來訪。";
			else if (Speakc[36] == 3) ContentText.text = "要商討兩國通婚之事。";
			else if (Speakc[36] == 4) ContentText.text = "公爵還記得之前從地牢中救回來的公主嗎？";
			else if (Speakc[36] == 5) ContentText.text = "那位公主其實就是西方國王的大女兒-愛爾蓮公主。";
			else if (Speakc[36] == 6) ContentText.text = "愛爾蓮公主因為出城遊玩，卻遭到叛國組織的襲擊。";
			else if (Speakc[36] == 7) ContentText.text = "叛國組織想透過綁架公主來逼迫國王退位。";
			else if (Speakc[36] == 8) ContentText.text = "所以沃斯王一方面跟叛國組織周旋拖延時間。";
			else if (Speakc[36] == 9) ContentText.text = "一方面派人偷偷捎信給奧迪托雷國王，請求幫助。";
			else if (Speakc[36] == 10) ContentText.text = "最後在公爵和道尼爾騎士努力下，總算將愛爾蓮公主平安帶回。";
			else if (Speakc[36] == 11) ContentText.text = "所以我在想溫特沃斯王應該會將愛爾蓮公主，許配給公爵。";
			else if (Speakc[36] == 12) ContentText.text = "如此一來，「愛爾蘭帝國」和「大不列顛帝國」就可以合併變成世界最大的帝國。";
			else if (Speakc[36] == 13) ContentText.text = "而公爵也會成為世界最大的帝國國王。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話36結束***********************************************************************************************

		//對話37(Mission56_2)***********************************************************************************************	
		else if (Speak == 37) {
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[37]++; //按一次左鍵,故事內容編號+1
				if(Speakc[37]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[37] == 0 ) ContentText.text = "維京人打過來了，我們要進攻。";
			else if (Speakc[37] == 1) ContentText.text = "一但長久處於守備只會不斷消耗我們的戰力。";
			else if (Speakc[37] == 2) ContentText.text = "現在我要帶著騎兵隊，繞到敵人的後方。";
			else if (Speakc[37] == 3) ContentText.text = "麻煩公爵繼續佯裝守備，吸引敵人的注意。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話37結束***********************************************************************************************

		//對話38(Mission59_2)***********************************************************************************************	
		else if (Speak == 38) {
			NameText.text = "村民";//說話者名字
			Person.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[38]++; //按一次左鍵,故事內容編號+1
				if(Speakc[38]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[38] == 0 ) ContentText.text = "農田遭受到汙染，全部都只能燒掉農作物。";
			else if (Speakc[38] == 1) ContentText.text = "一年的努力全都白費了。";
			else if (Speakc[38] == 2) ContentText.text = "汙染的原因是河流的源頭似乎被什麼東西而導致。";
			else if (Speakc[38] == 3) ContentText.text = "拜託公爵派人到河流的源頭查查看到底發生什麼事。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話38結束***********************************************************************************************

		//對話39(Mission60_1)***********************************************************************************************	
		else if (Speak == 39) {
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)) {
				Speakc[39]++; //按一次左鍵,故事內容編號+1
				if(Speakc[39]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[39] == 0 ) ContentText.text = "近年來穀物豐收，大多被放在國家的私倉裡。";
			else if (Speakc[39] == 1) ContentText.text = "現在國王要建造一座公用穀倉。";
			else if (Speakc[39] == 2) ContentText.text = "給沒有飯吃的人民有飯可以吃。";
			else if (Speakc[39] == 3) ContentText.text = "現在大街小巷都在稱讚國王。";
			else if (Speakc[39] == 4) ContentText.text = "國王的名聲又提升了。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話39結束***********************************************************************************************

		//對話40(Mission62_1)***********************************************************************************************	
		else if (Speak == 40) {
			NameTextRight.text = "大衛醫生";//說話者名字
			Doctor.SetActive (true);     //說話者圖型
			if(Input.GetMouseButtonDown (0)){
				Speakc[40]++; //按一次左鍵,故事內容編號+1
				if(Speakc[40]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[40] == 0 ) ContentText.text = "港口爆發了鼠疫，需要封鎖國內大小港口。";
			else if (Speakc[40] == 1) ContentText.text = "所有的船長、船員以及有到港口的人民，都必須隔離。";
			else if (Speakc[40] == 2) ContentText.text = "以防止更大的疫情擴散。";
			else if (Speakc[40] == 3) ContentText.text = "我已經將消毒藥分配給所有的醫療小隊。";
			else if (Speakc[40] == 4) ContentText.text = "大概在半天就可以控制疫情。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話40結束***********************************************************************************************

		//對話41(Mission62_2)***********************************************************************************************	
		else if (Speak == 41) {
			NameTextRight.text = "大衛醫生";
			Doctor.SetActive (true);
			if(Input.GetMouseButtonDown (0)) {
				Speakc[41]++; //按一次左鍵,故事內容編號+1
				if(Speakc[41]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[41] == 0 ) ContentText.text = "港口爆發了鼠疫，我們沒辦法在災情擴大前封鎖港口。";
			else if (Speakc[41] == 1) ContentText.text = "所有的船長、船員以及有到港口的人民都開始散播著鼠疫。";
			else if (Speakc[41] == 2) ContentText.text = "需要花費更多的資源才能以防止更大的疫情擴散。";
			else if (Speakc[41] == 3) ContentText.text = "我已經將所有消毒藥分配給所有的醫療小隊。";
			else if (Speakc[41] == 4) ContentText.text = "但遠遠不夠。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話41結束***********************************************************************************************

		//對話42(Mission68_1)***********************************************************************************************	
		else if (Speak == 42) {
			NameTextRight.text = "大衛醫生";
			Doctor.SetActive (true);
			if(Input.GetMouseButtonDown (0)) {
				Speakc[42]++; //按一次左鍵,故事內容編號+1
				if(Speakc[42]<=6)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[42] == 0 ) ContentText.text = "我們應該再蓋一間醫院。";
			else if (Speakc[42] == 1) ContentText.text = "更多更多的醫院。";
			else if (Speakc[42] == 2) ContentText.text = "雖然會花費許多的人力以及資源。";
			else if (Speakc[42] == 3) ContentText.text = "但能夠增加大量的醫療服務跟醫療小隊。";
			else if (Speakc[42] == 4) ContentText.text = "畢竟人民只要少生病，國家就能更強大。";
			else if (Speakc[42] == 5) ContentText.text = "絕對不能讓當年的悲劇再次降臨到這個國家。";
			else if (Speakc[42] == 6) ContentText.text = "(大衛醫生陷入沉思...........似乎回想起某些事情)";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話42結束***********************************************************************************************

		//對話43(Mission1_1)***********************************************************************************************	
		else if (Speak == 43) {
			//左邊
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[43]++; //按一次左鍵,故事內容編號+1
				if(Speakc[43]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[43] == 0 ) ContentText.text = "您願意在人民最難過的時候。";
			else if (Speakc[43] == 1) ContentText.text = "提供所有能幫助的。";
			else if (Speakc[43] == 2) ContentText.text = "人民會更加記住您的名字。";
			else if (Speakc[43] == 3) ContentText.text = "雖然幫忙會消耗一些食物。";
			else if (Speakc[43] == 4) ContentText.text = "但是至少人民可以度過這一次的危機。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話43結束***********************************************************************************************

		//對話44(Mission3_1)***********************************************************************************************	
		else if (Speak == 44) {
			//左邊
			NameTextRight.text = "大衛醫生";
			Doctor.SetActive (true);

			if(Input.GetMouseButtonDown (0)) {
				Speakc[44]++; //按一次左鍵,故事內容編號+1
				if(Speakc[44]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[44] == 0 ) ContentText.text = "小時候我還在沼城時也發生過像現在這樣的瘟疫。";
			else if (Speakc[44] == 1) ContentText.text = "當時的沼城不像現在如此繁榮。";
			else if (Speakc[44] == 2) ContentText.text = "連吃飽都是一個問題，更別說要注意衛生了。";
			else if (Speakc[44] == 3) ContentText.text = "所以當瘟疫發生時根本沒有任何防範措施，只能看著身邊的人一個一個的發病，因為痛苦而捲曲身體然後死去。";
			else if (Speakc[44] == 4) ContentText.text = "呈現在我眼前的就是一場人間地獄、災難.........，直到現在午夜時分我依然會夢見當時的慘劇。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話44結束***********************************************************************************************

		//對話45(Mission6_1)***********************************************************************************************	
		else if (Speak == 45) {
			//左邊
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[45]++; //按一次左鍵,故事內容編號+1
				if(Speakc[45]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[45] == 0 ) ContentText.text = "鄰國似乎開始徵召士兵，依照我們派出的探子回報。";
			else if (Speakc[45] == 1) ContentText.text = "似乎是有人在鄰國的市場中散佈我國將攻打他們的樣子。";
			else if (Speakc[45] == 2) ContentText.text = "所以鄰國才開始徵召士兵以防止我們攻打。";
			else if (Speakc[45] == 3) ContentText.text = "雖然不知道散布消息的人目的是為了什麼，但當務之急是先派出使臣去向鄰國說明我們並沒有要攻打他們。";
			else if (Speakc[45] == 4) ContentText.text = "等到這件事情平定下來之後再好好的查清楚。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話45結束***********************************************************************************************

		//對話46(Mission10_1)***********************************************************************************************	
		else if (Speak == 46) {
			//左邊
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[46]++; //按一次左鍵,故事內容編號+1
				if(Speakc[46]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[46] == 0 ) ContentText.text = "很久很久以前雅南是一個男人的名字。";
			else if (Speakc[46] == 1) ContentText.text = "這名男子很奇怪，他不斷的追求智慧，他認為智慧可以讓他更接近神的領域。";
			else if (Speakc[46] == 2) ContentText.text = "所以他不斷的專研書本中的知識，剛開始大家只認為他單純的愛看書。";
			else if (Speakc[46] == 3) ContentText.text = "但後來他卻從一般的科學、生物、語言......，開始看起宗教、醫療、造神論.......。";
			else if (Speakc[46] == 4) ContentText.text = "越來越朝著所謂的智慧遠去，有一天他把自己關在家裡，從那之後沒有人在看到男子走出來。";
			else if (Speakc[46] == 5) ContentText.text = "許久之後有人去男子的家中想看看他怎麼了，結果............。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話46結束***********************************************************************************************

		//對話47(Mission12_2)***********************************************************************************************	
		else if (Speak == 47) {
			//左邊
			NameText.text = "平民";//說話者名字
			Person.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[47]++; //按一次左鍵,故事內容編號+1
				if(Speakc[47]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[47] == 0 ) ContentText.text = "公爵你怎能如此狠心!!!";
			else if (Speakc[47] == 1) ContentText.text = "礦場內有多少的工人被壓在厚重的土石下面，大家是死是活都不知道。";
			else if (Speakc[47] == 2) ContentText.text = "你卻完全當作這件事情不存在，以防止自己需要付出賠償。";
			else if (Speakc[47] == 3) ContentText.text = "這些工人都有家庭啊!\n他們的家人都在等著他們啊!";
			else if (Speakc[47] == 4) ContentText.text = "(憤怒)你一定會下地獄!!!!!!!!!!!";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話47結束***********************************************************************************************

		//對話48(Mission13_1)***********************************************************************************************	
		else if (Speak == 48) {
			//左邊
			NameText.text = "鄰國平民";//說話者名字
			Person.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[48]++; //按一次左鍵,故事內容編號+1
				if(Speakc[48]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[48] == 0 ) ContentText.text = "奇怪?最近怎麼有人家裡的錢會無故不見?";
			else if (Speakc[48] == 1) ContentText.text = "明明都有把門窗關緊啊，看來需要告訴一下警備隊。";
			else if (Speakc[48] == 2) ContentText.text = "叫他們以後早晚都要出來巡邏。";
			else if (Speakc[48] == 3) ContentText.text = "(嘆氣)不然這樣真的會沒錢。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話48結束***********************************************************************************************

		//對話49(Mission14_2)***********************************************************************************************	
		else if (Speak == 49) {
			//左邊
			NameText.text = "商人";//說話者名字
			Business.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[49]++; //按一次左鍵,故事內容編號+1
				if(Speakc[49]<=1)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[49] == 0 ) ContentText.text = "公爵怎麼樣啊?";
			else if (Speakc[49] == 1) ContentText.text = "這一筆買賣是不是很划算啊。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話49結束***********************************************************************************************


		//對話50(Mission15_2)***********************************************************************************************	
		else if (Speak == 50) {
			//左邊
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[50]++; //按一次左鍵,故事內容編號+1
				if(Speakc[50]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[50] == 0 ) ContentText.text = "公爵你最近是不是睡不好?";
			else if (Speakc[50] == 1) ContentText.text = "看你近來一直發呆傻笑，注意力也很不集中總是沒在聽我講話。";
			else if (Speakc[50] == 2) ContentText.text = "該不會是生病了吧?";
			else if (Speakc[50] == 3) ContentText.text = "要不要我去找大衛醫生過來給你看看身體?";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話50結束***********************************************************************************************


		//對話51(Mission20_1)***********************************************************************************************	
		else if (Speak == 51) {
			//左邊
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[51]++; //按一次左鍵,故事內容編號+1
				if(Speakc[51]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[51] == 0 ) ContentText.text = "裡來了一群外來民族，說要進貢。";
			else if (Speakc[51] == 1) ContentText.text = "這些外來民族居無定所總是在國與國之間生存。";
			else if (Speakc[51] == 2) ContentText.text = "他們找到一個地方就會住下來，等到那個地方無法再生產食物就會離開，進而找出下一個地方。";
			else if (Speakc[51] == 3) ContentText.text = "來城裡的這些人因該是想藉由進貢，以換得定居在國內的機會吧。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話51結束***********************************************************************************************

		//對話52(Mission25_1)***********************************************************************************************	
		else if (Speak == 52) {
			//左邊
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[52]++; //按一次左鍵,故事內容編號+1
				if(Speakc[52]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[52] == 0 ) ContentText.text = "卡爾符真的是我國鐵匠的神人。";
			else if (Speakc[52] == 1) ContentText.text = "他總是能製造出許多超越人們想像的武器。";
			else if (Speakc[52] == 2) ContentText.text = "總是覺得他能夠看到未來。";
			else if (Speakc[52] == 3) ContentText.text = "得益於他的鍛造能力，我國的武力一直凌駕於其他國家之上。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話52結束***********************************************************************************************

		//對話53(Mission31_2)***********************************************************************************************	
		else if (Speak == 53) {
			//左邊
			NameText.text = "平民";//說話者名字
			Person.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[53]++; //按一次左鍵,故事內容編號+1
				if(Speakc[53]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[53] == 0 ) ContentText.text = "房屋因為年久失修本來連住人都是個問題，偏偏最近一直有颶風。";
			else if (Speakc[53] == 1) ContentText.text = "老房子當然是不可能撐的下去。";
			else if (Speakc[53] == 2) ContentText.text = "還好公爵願意自掏腰包幫助我們重建房子。";
			else if (Speakc[53] == 3) ContentText.text = "應該再過不久全部沒有房子的人都可以重新擁有房子。";
			else if (Speakc[53] == 4) ContentText.text = "這一切都要感謝公爵的善舉。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話53結束***********************************************************************************************

		//對話54(Mission34_1)***********************************************************************************************	
		else if (Speak == 54) {
			//左邊
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[54]++; //按一次左鍵,故事內容編號+1
				if(Speakc[54]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[54] == 0 ) ContentText.text = "一群人準備造反，推翻政權!!!";
			else if (Speakc[54] == 1) ContentText.text = "盡量是以說服的方式來安撫這一些人。";
			else if (Speakc[54] == 2) ContentText.text = "雖然需要花費較多的時間和金錢，但至少不會造成太多人民和士兵的傷害。";
			else if (Speakc[54] == 3) ContentText.text = "這件事情就由我去處理，我一定會在短期之內解決這件事。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話54結束***********************************************************************************************

		//對話55(Mission34_2)***********************************************************************************************	
		else if (Speak == 55) {
			//左邊
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[55]++; //按一次左鍵,故事內容編號+1
				if(Speakc[55]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[55] == 0 ) ContentText.text = "一群人準備造反，推翻政權!!!";
			else if (Speakc[55] == 1) ContentText.text = "我已經召集了騎士們準備用武力壓制這些暴民。";
			else if (Speakc[55] == 2) ContentText.text = "一段時間總是會跑出像他們這些想要自己當國王的人。";
			else if (Speakc[55] == 3) ContentText.text = "雖然最後會造成許多人民的死亡，但如果現在不解決這些人，後面只會有更多類似的事情發生，請公爵體諒。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話55結束***********************************************************************************************

		//對話56(Mission37_1)***********************************************************************************************	
		else if (Speak == 56) {
			//左邊
			NameText.text = "肯威船長";//說話者名字
			Captain.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[56]++; //按一次左鍵,故事內容編號+1
				if(Speakc[56]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[56] == 0 ) ContentText.text = "最近海上風向不太好，但我們還是要出航。";
			else if (Speakc[56] == 1) ContentText.text = "一個水手如果因為大海在生氣所以就害怕大海不出航。";
			else if (Speakc[56] == 2) ContentText.text = "我可不是那種人，從小就跟大海相依為命的我，可是一點都不害怕。";
			else if (Speakc[56] == 3) ContentText.text = "有時在這種情況下出海，搞不好會有一些想不到的際遇。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話56結束***********************************************************************************************

		//對話57(Mission39_1)***********************************************************************************************	
		else if (Speak == 57) {
			//左邊
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[57]++; //按一次左鍵,故事內容編號+1
				if(Speakc[57]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[57] == 0 ) ContentText.text = "這一場晚宴辦的非常成功。";
			else if (Speakc[57] == 1) ContentText.text = "每個來賓都十分的開心，這樣子我們跟其他國家之間的關係會越來越好。";
			else if (Speakc[57] == 2) ContentText.text = "雖然不知道關係可以持續多久?";
			else if (Speakc[57] == 3) ContentText.text = "但是多一千位朋友，好過樹立一名敵人。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話57結束***********************************************************************************************

		//對話58(Mission41_2)***********************************************************************************************	
		else if (Speak == 58) {
			//左邊
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[58]++; //按一次左鍵,故事內容編號+1
				if(Speakc[58]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[58] == 0 ) ContentText.text = "今年的糧食收成特別好，公爵願意將這些多出來的糧食分配給軍隊。";
			else if (Speakc[58] == 1) ContentText.text = "最近戰場的糧食總是告急，我還在想怎麼辦。";
			else if (Speakc[58] == 2) ContentText.text = "這一下子糧食的問題就可以解決了。";
			else if (Speakc[58] == 3) ContentText.text = "等一下我就派人把這些糧食送到前線去。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話58結束***********************************************************************************************

		//對話59(Mission46_1)***********************************************************************************************	
		else if (Speak == 59) {
			//左邊
			NameText.text = "丹尼爾騎士";//說話者名字
			Knight.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[59]++; //按一次左鍵,故事內容編號+1
				if(Speakc[59]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[59] == 0 ) ContentText.text = "這一些狼群總是在離城不遠的森林中徘徊。";
			else if (Speakc[59] == 1) ContentText.text = "可能是因為商人們平日運送食物的關係。";
			else if (Speakc[59] == 2) ContentText.text = "牠們知道只要守在道路附近就會有食物送上門。";
			else if (Speakc[59] == 3) ContentText.text = "結果就造成了牠們看到人就攻擊的習性。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話59結束***********************************************************************************************

		//對話60(Mission52_1)***********************************************************************************************	
		else if (Speak == 60) {
			//左邊
			NameText.text = "維吾大臣";//說話者名字
			Police.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[60]++; //按一次左鍵,故事內容編號+1
				if(Speakc[60]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[60] == 0 ) ContentText.text = "之前公爵同意幫助修裡醫院塌掉的屋頂。";
			else if (Speakc[60] == 1) ContentText.text = "院長寄了一封信給公爵，信中寫說......";
			else if (Speakc[60] == 2) ContentText.text = "感謝公爵的善舉幫助他們修復了屋頂，也幸好當時沒有任何人受傷。";
			else if (Speakc[60] == 3) ContentText.text = "在此送上一些禮物表答感謝。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話60結束***********************************************************************************************

		//主線*************************************************************************************************************
		//對話61(Mission131)***********************************************************************************************	
		else if (Speak == 61) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[61]++; //按一次左鍵,故事內容編號+1
				if(Speakc[61]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[61] == 0 ) ContentText.text = "你好啊羅倫佐公爵。這是我們第一次見面。";
			else if (Speakc[61] == 1) ContentText.text = "你可以姑且叫我夢境人。";
			else if (Speakc[61] == 2) ContentText.text = "這個國家充滿著許多秘密而我現在就來告訴你有關這個國家最初興建的過去。";
			else if (Speakc[61] == 3) ContentText.text = "你們羅倫佐家族之所以有能力站在現在的地位也跟那個秘密有關.......";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話61結束***********************************************************************************************

		//對話62(Mission132)***********************************************************************************************	
		else if (Speak == 62) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[62]++; //按一次左鍵,故事內容編號+1
				if(Speakc[62]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[62] == 0 ) ContentText.text = "很久很久以前這片土地其實是一群海盜們聚集的地方。";
			else if (Speakc[62] == 1) ContentText.text = "那些惡名昭彰的海盜因為背負太多罪名而無法在任何國家生活下去。";
			else if (Speakc[62] == 2) ContentText.text = "因此只能逃到大海上，但根本不可能永遠的待在海上。";
			else if (Speakc[62] == 3) ContentText.text = "所以在很長的一段時間裡這些海盜都靠著劫持商船才勉強的過日子。";
			else if (Speakc[62] == 4) ContentText.text = "最後這些海盜做了一個決定已中止這種心驚膽跳的生活。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話62結束***********************************************************************************************

		//對話63(Mission133)***********************************************************************************************	
		else if (Speak == 63) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[63]++; //按一次左鍵,故事內容編號+1
				if(Speakc[63]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[63] == 0 ) ContentText.text = "有一句話來形容這些漂洋在海上的海盜們。";
			else if (Speakc[63] == 1) ContentText.text = "高樹多悲風，海水揚其波，利劍不再掌，結友何須多。";
			else if (Speakc[63] == 2) ContentText.text = "這一句話的意思是:航海自古以來就是屬於男人的浪漫";
			else if (Speakc[63] == 3) ContentText.text = "勇敢的水手們與天風海雨赤身搏鬥，身後留下的傳奇不計其數。";
			else if (Speakc[63] == 4) ContentText.text = "那摻雜了陽光與海風的笛聲響起時，油然而生對大海的嚮往。";
			else if (Speakc[63] == 5) ContentText.text = "當時的男人們都認為大海在呼喚著他們，而他們也呼應了大海的招喚。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話63結束***********************************************************************************************

		//對話64(Mission134)***********************************************************************************************	
		else if (Speak == 64) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[64]++; //按一次左鍵,故事內容編號+1
				if(Speakc[64]<=6)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[64] == 0 ) ContentText.text = "上次跟你說到那些因為背負太多罪名而無法在任何國家生活下去的海盜們。";
			else if (Speakc[64] == 1) ContentText.text = "他們最後為了終止不斷逃亡的日子海盜做了一個決定。";
			else if (Speakc[64] == 2) ContentText.text = "而那一個決定就是如果沒有一個國家可以接受海盜的存在。";
			else if (Speakc[64] == 3) ContentText.text = "那麼海盜們就建立一個給海盜們住的國家。";
			else if (Speakc[64] == 4) ContentText.text = "聽起來雖然很天方夜譚，講給小孩子聽都不會相信。";
			else if (Speakc[64] == 5) ContentText.text = "但是他們是真的建立起了一個國家，這一段海盜建立國家的事情本來被其他國家盡全力的掩蓋。";
			else if (Speakc[64] == 6) ContentText.text = "不過這一個事實最後卻被一名學者所掀開來展現在眾人的眼前。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話64結束***********************************************************************************************

		//對話65(Mission135)***********************************************************************************************	
		else if (Speak == 65) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[65]++; //按一次左鍵,故事內容編號+1
				if(Speakc[65]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[65] == 0 ) ContentText.text = "那名學者做到了當時根本沒有人會做到的事。";
			else if (Speakc[65] == 1) ContentText.text = "一位名為羅倫佐.托雷的學者追查傳奇海盜「 亨利.艾佛瑞」的巨額財富。";
			else if (Speakc[65] == 2) ContentText.text = "原本只是追查海盜所遺留下來的寶物，卻找到了海盜們建立國家的證明。";
			else if (Speakc[65] == 3) ContentText.text = "隨著調查深入，羅倫佐發現亨利.艾佛瑞與當時名揚海外的十一位大海盜。";
			else if (Speakc[65] == 4) ContentText.text = "共同建立了一個屬於海盜們的理想社會一個「烏托邦」。";
			else if (Speakc[65] == 5) ContentText.text = "並將其命名為「 萊伯塔利亞(Libertalia)」。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話65結束***********************************************************************************************

		//對話66(Mission136)***********************************************************************************************	
		else if (Speak == 66) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[66]++; //按一次左鍵,故事內容編號+1
				if(Speakc[66]<=7)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[66] == 0 ) ContentText.text = "「萊伯塔利亞」到底是一個什麼樣的地方?";
			else if (Speakc[66] == 1) ContentText.text = "而當時的羅倫佐也正在思考現實世界的「萊伯塔利亞」是真的存在嗎?";
			else if (Speakc[66] == 2) ContentText.text = "這一切疑問都在羅倫佐翻閱當時各個海盜的人生記錄時有了進一步的發展。";
			else if (Speakc[66] == 3) ContentText.text = "那個死去的海盜所住的牢房裡發現一個聖狄思馬斯十字架，正是這個十字架引發了後面的故事。";
			else if (Speakc[66] == 4) ContentText.text = "聖狄思馬斯是《新約聖經》正典中，四福音書之一的路加福音所記錄的人。";
			else if (Speakc[66] == 5) ContentText.text = "他記載與耶穌兩名同釘的無名囚犯其中一人，他駁斥不知悔改的囚犯對耶穌的侮辱，並希望耶穌作王時記得他，耶穌答應帶他去樂園。";
			else if (Speakc[66] == 6) ContentText.text = "雖然他並沒有在《路加福音》記載名字，但後世基督宗教諸教會根據各自的傳說為他命名。";
			else if (Speakc[66] == 7) ContentText.text = "而聖狄思馬斯就是其中一個名字。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話66結束***********************************************************************************************

		//對話67(Mission137)***********************************************************************************************	
		else if (Speak == 67) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[67]++; //按一次左鍵,故事內容編號+1
				if(Speakc[67]<=6)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[67] == 0 ) ContentText.text = "羅倫佐在那個聖狄思馬斯十字架裡藏著一張地圖同時也是一張邀請函。";
			else if (Speakc[67] == 1) ContentText.text = "因為亨利.艾佛瑞在許多相同的十字架裡放置了同一張地圖。";
			else if (Speakc[67] == 2) ContentText.text = "並送給當時跟他齊名的海盜們，邀請海盜們參與測試。";
			else if (Speakc[67] == 3) ContentText.text = "而那個測試就是亨利.艾佛瑞邀請海盜們進行一系列測試,最後通過測試的人將會和他一起建立「萊伯塔利亞」。";
			else if (Speakc[67] == 4) ContentText.text = "根據歷史紀載當年很明顯最終只有十一位海盜通過了艾佛瑞設下的機關迷題。";
			else if (Speakc[67] == 5) ContentText.text = "羅倫佐很高興所有的事情終於有了進展但事與願違，羅倫佐找到了地圖不過去翻閱當時的世界地圖，邀請函上的地點根本不存在。";
			else if (Speakc[67] == 6) ContentText.text = "所有的事情又斷了聯繫，讓羅倫佐陷入了瓶頸。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話67結束***********************************************************************************************

		//對話68(Mission138)***********************************************************************************************	
		else if (Speak == 68) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[68]++; //按一次左鍵,故事內容編號+1
				if(Speakc[68]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[68] == 0 ) ContentText.text = "當羅倫佐因為找不到任何進一步的線索而準備放棄時。";
			else if (Speakc[68] == 1) ContentText.text = "羅倫佐卻發現了一個新的線索，一枚當時海盜們流通的硬幣。";
			else if (Speakc[68] == 2) ContentText.text = "海盜之間流通的硬幣本就非常稀少，想留到後世根本就是奇蹟，簡直就像「萊伯塔利亞」在等著羅倫佐的到來。";
			else if (Speakc[68] == 3) ContentText.text = "那枚海盜硬幣上印著一座火山，一座位於馬達加斯加島上的一座火山。";
			else if (Speakc[68] == 4) ContentText.text = "而在馬達加斯加島上有一座大鐘樓，位於鐘樓中心一個名為「建立者」的輪盤。";
			else if (Speakc[68] == 5) ContentText.text = "輪盤上共有十二個海盜徽記，將十二個海盜徽記排列完整後，就會發現是亨利.艾佛瑞和當時通過測試的十一位海盜的徽記。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話68結束***********************************************************************************************

		//對話69(Mission139)***********************************************************************************************	
		else if (Speak == 69) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[69]++; //按一次左鍵,故事內容編號+1
				if(Speakc[69]<=4)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[69] == 0 ) ContentText.text = "羅倫佐靠著這個僅存的線索，前往了馬達加斯加島。";
			else if (Speakc[69] == 1) ContentText.text = "羅倫佐在馬達加斯加島附近的海域不斷的航行數個月，終於發現了一座有大量人口居住過的小島。";
			else if (Speakc[69] == 2) ContentText.text = "羅倫佐和其船員在島上找到了海盜們籌建「萊伯塔利亞」的草圖和模型，這一切似乎顯示著傳說中的海盜天堂是真實存在的。";
			else if (Speakc[69] == 3) ContentText.text = "在島上經過數星期的探查，終於在羅倫佐和其船員跋山涉水終於發現隱藏於熱帶雨林中的「萊伯塔利亞」。";
			else if (Speakc[69] == 4) ContentText.text = "羅倫佐對此發現感到興奮不已，但羅倫佐也發現了一些問題。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話69結束***********************************************************************************************

		//對話70(Mission140)***********************************************************************************************	
		else if (Speak == 70) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[70]++; //按一次左鍵,故事內容編號+1
				if(Speakc[70]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[70] == 0 ) ContentText.text = "在這座傳奇般的小城裡依然殘留著當年濃濃的生活氣息，但仔細觀察後羅倫佐逐漸發現一些端倪。";
			else if (Speakc[70] == 1) ContentText.text = "小城的鐵匠鋪裡有一把短彎刀,可是刀的主人去了哪裡? 為甚麼走的這麼趕以至於自己的鐵器都遺留在這裡?";
			else if (Speakc[70] == 2) ContentText.text = "城中的餐廳廚房中還有食物在爐子上腐爛，是發生什麼事可以讓廚師連火都來不及熄滅就離開廚房?";
			else if (Speakc[70] == 3) ContentText.text = "在一家店鋪中有一封信，信中明確提到了「這裡人人平等，每個人都可以做自己想做的事」，寫信人寫到自己感受到了在家時不曾感受過的滿足。";
			else if (Speakc[70] == 4) ContentText.text = "從種種跡象描述中「萊伯塔利亞」的確是一處松花釀酒，春水煎茶的盎然景象的一座城市，可是這裡的人們卻又行色匆匆的離開。";
			else if (Speakc[70] == 5) ContentText.text = "這一些疑問不斷的在羅倫佐的腦中出現。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話70結束***********************************************************************************************

		//對話71(Mission141)***********************************************************************************************	
		else if (Speak == 71) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[71]++; //按一次左鍵,故事內容編號+1
				if(Speakc[71]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[71] == 0 ) ContentText.text = "隨著羅倫佐對「萊伯塔利亞」的進一步探索，發現城鎮中心立著一塊嚴苛海盜法規。";
			else if (Speakc[71] == 1) ContentText.text = "專門為監獄設計的特製枷鎖以及各種明顯的戰鬥痕跡。";
			else if (Speakc[71] == 2) ContentText.text = "如果「萊伯塔利亞」的居民真的過著圍爐賞雪，雙柑鬥酒的幸福生活。";
			else if (Speakc[71] == 3) ContentText.text = "為甚麼會有管理森嚴的監獄和苛刻的法律規程?";
			else if (Speakc[71] == 4) ContentText.text = "羅倫佐眼前的「萊伯塔利亞」真的是前面信中提到的「人人平等」的那個「萊伯塔利亞」嗎?";
			else if (Speakc[71] == 5) ContentText.text = "還是在羅倫佐眼前的「萊伯塔利亞」其實是假的?";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話71結束***********************************************************************************************

		//對話72(Mission142)***********************************************************************************************	
		else if (Speak == 72) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[72]++; //按一次左鍵,故事內容編號+1
				if(Speakc[72]<=3)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[72] == 0 ) ContentText.text = "羅倫佐對這一堆的疑問開始進行釐清。";
			else if (Speakc[72] == 1) ContentText.text = "在透過分析亨利.艾佛瑞和各個海盜們的經歷，以及散佈在島上的記錄，終於找出了問題的解答。";
			else if (Speakc[72] == 2) ContentText.text = "「人人平等」的「萊伯塔利亞」真的存在，而存在「苛刻的法律」的「萊伯塔利亞」也真的存在。";
			else if (Speakc[72] == 3) ContentText.text = "只是前者隨著時間變成了後者..........。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話72結束***********************************************************************************************

		//對話73(Mission143)***********************************************************************************************	
		else if (Speak == 73) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[73]++; //按一次左鍵,故事內容編號+1
				if(Speakc[73]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[73] == 0 ) ContentText.text = "那個讓「人人平等」的「萊伯塔利亞」變成存在「苛刻的法律」的「萊伯塔利亞」的主要原因就是亨利.艾佛瑞";
			else if (Speakc[73] == 1) ContentText.text = "其實「亨利.艾佛瑞」比任何人都清楚追隨自己的是一幫什麼樣的人。";
			else if (Speakc[73] == 2) ContentText.text = "要將這群各懷目的、惡性難改的海盜約束起來，僅僅靠一個所謂的「人人平等的信念」是遠遠不夠的。";
			else if (Speakc[73] == 3) ContentText.text = "這樣子的隱憂導致亨利.艾佛瑞制定嚴苛的法律、關押判徒的監獄，甚至組織自己的軍隊來維持「萊伯塔利亞的穩定」";
			else if (Speakc[73] == 4) ContentText.text = "在亨利.艾佛瑞以暴制暴的管理方針下，萊伯塔利亞的居民度過了短暫的平靜生活後";
			else if (Speakc[73] == 5) ContentText.text = "一場大規模的動亂就此爆發.........。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話73結束***********************************************************************************************

		//對話74(Mission144)***********************************************************************************************	
		else if (Speak == 74) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[74]++; //按一次左鍵,故事內容編號+1
				if(Speakc[74]<=5)TalkAnimation.Play();
			}

			//依照故事內容編號顯示對話內容
			if (Speakc[74] == 0 ) ContentText.text = "動亂起原於居民們突然發現十二位「萊伯塔利亞」的建立者將公共寶庫裡所有的財寶全部佔有。";
			else if (Speakc[74] == 1) ContentText.text = "打算帶著如此龐大的財寶遠走高飛。";
			else if (Speakc[74] == 2) ContentText.text = "當居民們付出慘烈代價闖進公共寶庫時，在他們眼前的只剩下早已搬空的寶庫。";
			else if (Speakc[74] == 3) ContentText.text = "所以羅倫佐在公共寶庫，看到掛著十二位海盜的相片都寫上了「強盜」的字眼。";
			else if (Speakc[74] == 4) ContentText.text = "最後，這場暴亂以十二位海盜成功「鎮壓」告終。";
			else if (Speakc[74] == 5) ContentText.text = "「人人平等」的「萊伯塔利亞」從此變成了一場短暫的美夢。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話74結束***********************************************************************************************

		//對話75(Mission145)***********************************************************************************************	
		else if (Speak == 75) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[75]++; //按一次左鍵,故事內容編號+1
				if(Speakc[75]<=7)TalkAnimation.Play();
			}
			//
			//依照故事內容編號顯示對話內容
			if (Speakc[75] == 0 ) ContentText.text = "但故事並沒有因為海盜們帶著財寶們而結束。";
			else if (Speakc[75] == 1) ContentText.text = "這群各懷惡意的海盜們在奪得巨額財富後，開始反目都想獨吞財寶。";
			else if (Speakc[75] == 2) ContentText.text = "於是「亨利.艾佛瑞」與另一名海盜「托馬斯.圖」設計一場響宴，宴會上他們二人毒殺其它十位海盜。";
			else if (Speakc[75] == 3) ContentText.text = "但海盜終究是海盜，不會把眼前的財寶交給別人。";
			else if (Speakc[75] == 4) ContentText.text = "之後二人搬移寶藏時，也都想私吞寶藏而互相殘殺。";
			else if (Speakc[75] == 5) ContentText.text = "最後兩位極負盛名的海盜王，在裝滿金銀財寶的船中，同歸於盡。";
			else if (Speakc[75] == 6) ContentText.text = "而那些懷著對自由的嚮往而追隨亨利.艾佛瑞的人們，直到死前那一刻才明白。";
			else if (Speakc[75] == 7) ContentText.text = "自己親手奉上畢生財富所希望的「海盜烏托邦」，不過是一個徹頭徹尾、自始至終的謊言。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話75結束***********************************************************************************************

		//對話76(Mission146)***********************************************************************************************	
		else if (Speak == 76) {
			//左邊
			NameText.text = "夢境人";//說話者名字
			DreamOwner.SetActive (true);     //說話者圖型

			if(Input.GetMouseButtonDown (0)) {
				Speakc[76]++; //按一次左鍵,故事內容編號+1
				if(Speakc[76]<=7)TalkAnimation.Play();
			}
			//最後羅倫佐把發生在這座島上的事實寫成一本遊記帶回了。
			//依照故事內容編號顯示對話內容
			if (Speakc[76] == 0 ) ContentText.text = "在這些金銀財寶面前，羅倫佐不准任何人拿走一枚金幣。";
			else if (Speakc[76] == 1) ContentText.text = "羅倫佐和船員們最後在沒有拿走任何財寶就離開了「萊伯塔利亞」。";
			else if (Speakc[76] == 2) ContentText.text = "可能會有人想這是一夜致富的機會，但羅倫佐知道這些財寶只會帶來災難。";
			else if (Speakc[76] == 3) ContentText.text = "與其最後遭受災難不如一開始就什麼都不拿走。";
			else if (Speakc[76] == 4) ContentText.text = "回到佛羅倫斯的回程中，羅倫佐完成了這些年來的記錄和日記以及這座島上的事實寫成了一本遊記。";
			else if (Speakc[76] == 5) ContentText.text = "最後這一本遊記讓羅倫佐成為了眾所皆知的名人，連國王都召見他到城堡裡講述這一段故事。";
			else if (Speakc[76] == 6) ContentText.text = "這也是為什麼你們羅倫佐家族能夠在現在的佛羅倫斯有如此高的地位。";
			else if (Speakc[76] == 7) ContentText.text = "不論羅倫佐家族能否一直保持高貴家族的名號，你要記得在這瞬息萬變的世界裡不論發生什麼事，都要保持自己的初衷。";
			else{ 
				ContectPoint.SetActive (false);      //隱藏內容點
				BackButton.SetActive (true);         //顯示主畫面按鈕
			}
		}//對話76結束***********************************************************************************************

		/*/日常對話紀錄
		PlayerPrefs.SetInt("Storymission0", Startfunction.storymission [0] ); //Speak21,22
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Storymission1", Startfunction.storymission [1] ); //Speak23
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Storymission2", Startfunction.storymission [2] ); //Speak24
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Storymission3", Startfunction.storymission [3] ); //Speak25
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Storymission4", Startfunction.storymission [4] ); //Speak34
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("Storymission5", Startfunction.storymission [5] ); //Speak36
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 */
	}//Update結束===========================================================================================================



	//淡出畫面=====================================================================================================
	public void Fadeoutf(){
		ButtonMusic.Play ();         //播放按鈕音效 
		Fadeout.SetActive (true);    //顯示淡出畫面  

	}




}//主程式結束===============================================================================================================================
