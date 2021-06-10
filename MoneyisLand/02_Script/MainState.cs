//所有全域變數 狀態 存檔 讀檔
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainState : MonoBehaviour{

  //宣告變數============================================================================
	//持有金錢(最大 0 到 18,446,744,073,709,551,615)
	public static ulong OwnMoney = 2500000000;
	//持有金錢暫存
	public static ulong OwnMoneyTemp = 0;
	//持有金錢變化(true:變化 false:未變化)
	public static bool OwnMoneyBool = true;
	//經理(共10位)
	public static ManageClass[] Manage = new ManageClass[10];
	//經理人數
	public static int ManageNumber = 10; 
	//經理圖片讀取
	public static string[] Manage_Image_String = new string[]{"Manage_Image_01","Manage_Image_02","Manage_Image_03","Manage_Image_04","Manage_Image_05","Manage_Image_06","Manage_Image_07","Manage_Image_08","Manage_Image_09","Manage_Image_10"};
	//警衛(共10位)
	public static SecurityClass[] Security = new SecurityClass[10];
	//警衛人數
	public static int SecurityNumber = 10; 
	//警衛圖片讀取
	public static string[] Security_Image_String = new string[]{"Security_Image_01","Security_Image_02","Security_Image_03","Security_Image_04","Security_Image_05","Security_Image_06","Security_Image_07","Security_Image_08","Security_Image_09","Security_Image_10"};
	//顧問(共20位)
	public static ConsultantClass[] Consultant = new ConsultantClass[20];
	//顧問人數
	public static int ConsultantNumber = 20; 
	//顧問圖片讀取
	public static string[] Consultant_Image_String = new string[]{"Consultant_Image_01","Consultant_Image_02","Consultant_Image_03","Consultant_Image_04","Consultant_Image_05","Consultant_Image_06","Consultant_Image_07","Consultant_Image_08","Consultant_Image_09","Consultant_Image_10","Consultant_Image_11","Consultant_Image_12","Consultant_Image_13","Consultant_Image_14","Consultant_Image_15","Consultant_Image_16","Consultant_Image_17","Consultant_Image_18","Consultant_Image_19","Consultant_Image_20"};

	//是否存過檔，以決定讀檔按鈕是否開啟 0:未存檔 1:已存檔
	public static int Saved = 0;

	//讀檔按鈕
	public Button Write_Show_Button;
	//讀檔畫面
	public GameObject Write_Show_Draw;

	//存檔按鈕
	public Button Save_Show_Button;
	//存檔畫面
	public GameObject Save_Show_Draw;

	//音效*********************************************************
	//按鈕音效
	public AudioSource Button_Sounds;
	//按鈕音效播放BOOL true:播放 false:不播放
	public static bool Button_Sounds_Bool = false;

	//取消按鈕音效
	public AudioSource Cancel_Button_Sounds;
	//取消按鈕音效播放BOOL true:播放 false:不播放
	public static bool Cancel_Button_Sounds_Bool = false;

	//PayBack按鈕音效
	public AudioSource PayBack_Button_Sounds;
	//PayBack按鈕音效播放BOOL true:播放 false:不播放
	public static bool PayBack_Button_Sounds_Bool = false;

	//買東西音效
	public AudioSource Buy_Button_Sounds;
	//Buy按鈕音效播放BOOL true:播放 false:不播放
	public static bool Buy_Button_Sounds_Bool = false;

	//獲得金錢音效
	public AudioSource GetMoney_Button_Sounds;
	//獲得金錢音效播放BOOL true:播放 false:不播放
	public static bool GetMoney_Button_Sounds_Bool = false;

	//等級提升音效
	public AudioSource LevelUP_Button_Sounds;
	//等級提升音效播放BOOL true:播放 false:不播放
	public static bool LevelUP_Button_Sounds_Bool = false;

	//經驗值提升音效
	public AudioSource LevelEx_Button_Sounds;
	//經驗值提升音效播放BOOL true:播放 false:不播放
	public static bool LevelEx_Button_Sounds_Bool = false;


	//區域(共5個區域)*********************************************************************
	//麵包師傅區域
	public static AreaClass BreadArea;
	//音樂人區域
	public static AreaClass MusicArea;
	//科技新貴區域
	public static AreaClass TehcnologyArea;
	//機工區域
	public static AreaClass FactoryArea;
	//銀行家區域
	public static AreaClass EconomicArea;

	//景氣(麵包師傅)
	public static byte Bread_NowEconomy = 85;
	//景氣(音樂人)
	public static byte Music_NowEconomy;
	//景氣(科技新貴)
	public static byte Tehcnology_NowEconomy;
	//景氣(機工)
	public static byte Factory_NowEconomy;
	//景氣(銀行家)
	public static byte Economic_NowEconomy;

	//治安(麵包師傅)
	public static byte Bread_NowSecurity;
	//治安(音樂人)
	public static byte Music_NowSecurity;
	//治安(科技新貴)
	public static byte Tehcnology_NowSecurity;
	//治安(機工)
	public static byte Factory_NowSecurity;
	//治安(銀行家)
	public static byte Economic_NowSecurity;



	//店鋪(麵包師傅區域共10間)
	public static Store[] BreadStore = new Store[10];
	//店鋪總數量(麵包師傅)
	public static int BreadStoreNumber = 10;
	//店鋪圖片讀取(麵包師傅)
	public static string[] BreadStoreImage_String = new string[]{"BreadStore_01","BreadStore_02","BreadStore_03","BreadStore_04","BreadStore_05","BreadStore_06","BreadStore_07","BreadStore_08","BreadStore_09","BreadStore_10"};
	//店鋪(音樂人區域共10間)
	public static Store[] MusicStore = new Store[10];
	//店鋪總數量(音樂人)
	public static int MusicStoreNumber = 10;
	//店鋪圖片讀取(音樂人)
	public static string[] MusicStoreImage_String = new string[]{"MusicStore_01","MusicStore_02","MusicStore_03","MusicStore_04","MusicStore_05","MusicStore_06","MusicStore_07","MusicStore_08","MusicStore_09","MusicStore_10"};
	//店鋪(科技新貴區域共10間)
	public static Store[] TehcnologyStore = new Store[10];
	//店鋪總數量(科技新貴)
	public static int TehcnologyStoreNumber = 10;
	//店鋪圖片讀取(音樂人)
	public static string[] TehcnologyStoreImage_String = new string[]{"TehcnologyStore_01","TehcnologyStore_02","TehcnologyStore_03","TehcnologyStore_04","TehcnologyStore_05","TehcnologyStore_06","TehcnologyStore_07","TehcnologyStore_08","TehcnologyStore_09","TehcnologyStore_10"};
	//店鋪(機工區域共10間)
	public static Store[] FactoryStore = new Store[10];
	//店鋪總數量(機工)
	public static int FactoryStoreNumber = 10;
	//店鋪圖片讀取(音樂人)
	public static string[] FactoryStoreImage_String = new string[]{"FactoryStore_01","FactoryStore_02","FactoryStore_03","FactoryStore_04","FactoryStore_05","FactoryStore_06","FactoryStore_07","FactoryStore_08","FactoryStore_09","FactoryStore_10"};
	//店鋪(銀行家區域共10間)
	public static Store[] EconomicStore = new Store[10];
	//店鋪總數量(銀行家)
	public static int EconomicStoreNumber = 10;
	//店鋪圖片讀取(音樂人)
	public static string[] EconomicStoreImage_String = new string[]{"EconomicStore_01","EconomicStore_02","EconomicStore_03","EconomicStore_04","EconomicStore_05","EconomicStore_06","EconomicStore_07","EconomicStore_08","EconomicStore_09","EconomicStore_10"};

	//存檔變數(員工)************************************************************************
	 //經理僱用狀態
	 public static string[] Save_Manage_Hire = new string[]{"Manage_Hire00","Manage_Hire01","Manage_Hire02","Manage_Hire03","Manage_Hire04","Manage_Hire05","Manage_Hire06","Manage_Hire07","Manage_Hire08","Manage_Hire09",};
	 //警衛僱用狀態
	 public static string[] Save_Security_Hire = new string[]{"Security_Hire00","Security_Hire01","Security_Hire02","Security_Hire03","Security_Hire04","Security_Hire05","Security_Hire06","Security_Hire07","Security_Hire08","Security_Hire09",};
	 //顧問僱用狀態
	 public static string[] Save_Consultant_Hire = new string[]{"Consltant_Hire00","Consltant_Hire01","Consltant_Hire02","Consltant_Hire03","Consltant_Hire04","Consltant_Hire05","Consltant_Hire06","Consltant_Hire07","Consltant_Hire08","Consltant_Hire09",
		"Consltant_Hire10","Consltant_Hire11","Consltant_Hire12","Consltant_Hire13","Consltant_Hire14","Consltant_Hire15","Consltant_Hire16","Consltant_Hire17","Consltant_Hire18","Consltant_Hire19"};

	//經理出勤狀態
	public static string[] Save_Manage_Work = new string[]{"Manage_Work00","Manage_Work01","Manage_Work02","Manage_Work03","Manage_Work04","Manage_Work05","Manage_Work06","Manage_Work07","Manage_Work08","Manage_Work09",};
	//警衛出勤狀態
	public static string[] Save_Security_Work = new string[]{"Security_Work00","Security_Work01","Security_Work02","Security_Work03","Security_Work04","Security_Work05","Security_Work06","Security_Work07","Security_Work08","Security_Work09",};
	//顧問出勤狀態
	public static string[] Save_Consultant_Work = new string[]{"Consltant_Work00","Consltant_Work01","Consltant_Work02","Consltant_Work03","Consltant_Work04","Consltant_Work05","Consltant_Work06","Consltant_Work07","Consltant_Work08","Consltant_Work09",
		"Consltant_Work10","Consltant_Work11","Consltant_Work12","Consltant_Work13","Consltant_Work14","Consltant_Work15","Consltant_Work16","Consltant_Work17","Consltant_Work18","Consltant_Work19"};

	//經理工作地點
	public static string[] Save_Manage_WorkPlace = new string[]{"Manage_WorkPlace00","Manage_WorkPlace01","Manage_WorkPlace02","Manage_WorkPlace03","Manage_WorkPlace04","Manage_WorkPlace05","Manage_WorkPlace06","Manage_WorkPlace07","Manage_WorkPlace08","Manage_WorkPlace09",};
	//警衛工作地點
	public static string[] Save_Security_WorkPlace = new string[]{"Security_WorkPlace00","Security_WorkPlace01","Security_WorkPlace02","Security_WorkPlace03","Security_WorkPlace04","Security_WorkPlace05","Security_WorkPlace06","Security_WorkPlace07","Security_WorkPlace08","Security_WorkPlace09",};

	//存檔變數(店鋪)************************************************************************
	//店鋪擁有狀態(麵包師傅區域共10間)
	public static string[] Save_Bread_OwnBool = new string[]{"Bread_OwnBool00","Bread_OwnBool01","Bread_OwnBool02","Bread_OwnBool03","Bread_OwnBool04","Bread_OwnBool05","Bread_OwnBool06","Bread_OwnBool07","Bread_OwnBool08","Bread_OwnBool09"};
	//店鋪擁有狀態(音樂人區域共10間)
	public static string[] Save_Music_OwnBool = new string[]{"Music_OwnBool00","Music_OwnBool01","Music_OwnBool02","Music_OwnBool03","Music_OwnBool04","Music_OwnBool05","Music_OwnBool06","Music_OwnBool07","Music_OwnBool08","Music_OwnBool09"};
	//店鋪擁有狀態(科技新貴區域共10間)
	public static string[] Save_Tehcnology_OwnBool = new string[]{"Technology_OwnBool00","Technology_OwnBool01","Technology_OwnBool02","Technology_OwnBool03","Technology_OwnBool04","Technology_OwnBool05","Technology_OwnBool06","Technology_OwnBool07","Technology_OwnBool08","Technology_OwnBool09"};
	//店鋪擁有狀態(機工區域共10間)
	public static string[] Save_Factory_OwnBool = new string[]{"Factory_OwnBool00","Factory_OwnBool01","Factory_OwnBool02","Factory_OwnBool03","Factory_OwnBool04","Factory_OwnBool05","Factory_OwnBool06","Factory_OwnBool07","Factory_OwnBool08","Factory_OwnBool09"};
	//店鋪擁有狀態(銀行家區域共10間)
	public static string[] Save_Economic_OwnBool = new string[]{"Economic_OwnBool00","Economic_OwnBool01","Economic_OwnBool02","Economic_OwnBool03","Economic_OwnBool04","Economic_OwnBool05","Economic_OwnBool06","Economic_OwnBool07","Economic_OwnBool08","Economic_OwnBool09"};

	//店鋪投資狀態(麵包師傅區域共10間)
	public static string[] Save_Bread_InvestBool = new string[]{"Bread_InvestBool00","Bread_InvestBool01","Bread_InvestBool02","Bread_InvestBool03","Bread_InvestBool04","Bread_InvestBool05","Bread_InvestBool06","Bread_InvestBool07","Bread_InvestBool08","Bread_InvestBool09"};
	//店鋪投資狀態(音樂人區域共10間)
	public static string[] Save_Music_InvestBool = new string[]{"Music_InvestBool00","Music_InvestBool01","Music_InvestBool02","Music_InvestBool03","Music_InvestBool04","Music_InvestBool05","Music_InvestBool06","Music_InvestBool07","Music_InvestBool08","Music_InvestBool09"};
	//店鋪投資狀態(科技新貴區域共10間)
	public static string[] Save_Tehcnology_InvestBool = new string[]{"Technology_InvestBool00","Technology_InvestBool01","Technology_InvestBool02","Technology_InvestBool03","Technology_InvestBool04","Technology_InvestBool05","Technology_InvestBool06","Technology_InvestBool07","Technology_InvestBool08","Technology_InvestBool09"};
	//店鋪投資狀態(機工區域共10間)
	public static string[] Save_Factory_InvestBool = new string[]{"Factory_InvestBool00","Factory_InvestBool01","Factory_InvestBool02","Factory_InvestBool03","Factory_InvestBool04","Factory_InvestBool05","Factory_InvestBool06","Factory_InvestBool07","Factory_InvestBool08","Factory_InvestBool09"};
	//店鋪投資狀態(銀行家區域共10間)
	public static string[] Save_Economic_InvestBool = new string[]{"Economic_InvestBool00","Economic_InvestBool01","Economic_InvestBool02","Economic_InvestBool03","Economic_InvestBool04","Economic_InvestBool05","Economic_InvestBool06","Economic_InvestBool07","Economic_InvestBool08","Economic_InvestBool09"};

	//店鋪等級(麵包師傅區域共10間)
	public static string[] Save_Bread_Level = new string[]{"Bread_Level00","Bread_Level01","Bread_Level02","Bread_Level03","Bread_Level04","Bread_Level05","Bread_Level06","Bread_Level07","Bread_Level08","Bread_Level09"};
	//店鋪等級(音樂人區域共10間)
	public static string[] Save_Music_Level = new string[]{"Music_Level00","Music_Level01","Music_Level02","Music_Level03","Music_Level04","Music_Level05","Music_Level06","Music_Level07","Music_Level08","Music_Level09"};
	//店鋪等級(科技新貴區域共10間)
	public static string[] Save_Tehcnology_Level = new string[]{"Technology_Level00","Technology_Level01","Technology_Level02","Technology_Level03","Technology_Level04","Technology_Level05","Technology_Level06","Technology_Level07","Technology_Level08","Technology_Level09"};
	//店鋪等級(機工區域共10間)
	public static string[] Save_Factory_Level = new string[]{"Factory_Level00","Factory_Level01","Factory_Level02","Factory_Level03","Factory_Level04","Factory_Level05","Factory_Level06","Factory_Level07","Factory_Level08","Factory_Level09"};
	//店鋪等級(銀行家區域共10間)
	public static string[] Save_Economic_Level = new string[]{"Economic_Level00","Economic_Level01","Economic_Level02","Economic_Level03","Economic_Level04","Economic_Level05","Economic_Level06","Economic_Level07","Economic_Level08","Economic_Level09"};

	//店鋪經驗(麵包師傅區域共10間)
	public static string[] Save_Bread_LevelEx = new string[]{"Bread_LevelEx00","Bread_LevelEx01","Bread_LevelEx02","Bread_LevelEx03","Bread_LevelEx04","Bread_LevelEx05","Bread_LevelEx06","Bread_LevelEx07","Bread_LevelEx08","Bread_LevelEx09"};
	//店鋪經驗(音樂人區域共10間)
	public static string[] Save_Music_LevelEx = new string[]{"Music_LevelEx00","Music_LevelEx01","Music_LevelEx02","Music_LevelEx03","Music_LevelEx04","Music_LevelEx05","Music_LevelEx06","Music_LevelEx07","Music_LevelEx08","Music_LevelEx09"};
	//店鋪經驗(科技新貴區域共10間)
	public static string[] Save_Tehcnology_LevelEx = new string[]{"Technology_LevelEx00","Technology_LevelEx01","Technology_LevelEx02","Technology_LevelEx03","Technology_LevelEx04","Technology_LevelEx05","Technology_LevelEx06","Technology_LevelEx07","Technology_LevelEx08","Technology_LevelEx09"};
	//店鋪經驗(機工區域共10間)
	public static string[] Save_Factory_LevelEx = new string[]{"Factory_LevelEx00","Factory_LevelEx01","Factory_LevelEx02","Factory_LevelEx03","Factory_LevelEx04","Factory_LevelEx05","Factory_LevelEx06","Factory_LevelEx07","Factory_LevelEx08","Factory_LevelEx09"};
	//店鋪經驗(銀行家區域共10間)
	public static string[] Save_Economic_LevelEx = new string[]{"Economic_LevelEx00","Economic_LevelEx01","Economic_LevelEx02","Economic_LevelEx03","Economic_LevelEx04","Economic_LevelEx05","Economic_LevelEx06","Economic_LevelEx07","Economic_LevelEx08","Economic_LevelEx09"};

	//存檔變數(區域)************************************************************************
	//區域經營狀態(5大區域)
	public static string[] Save_Area_Manage = new string[]{"Area_Manage00","Area_Manage01","Area_Manage02","Area_Manage03","Area_Manage04",};
	//區域回收時間(5大區域)
	public static string[] Save_Area_ManageTime = new string[]{"Area_ManageTime00","Area_ManageTime01","Area_ManageTime02","Area_ManageTime03","Area_ManageTime04",};



  //宣告狀態============================================================================
	//工作一覽狀態 true:開啟工作一覽狀態 false:關閉工作一覽狀態
	public static bool WorkBool = true;
	//管理狀態 true:開啟管理狀態 false:關閉管理狀態
	public static bool ManageBool = false;
	//店鋪一覽狀態 true:開啟店鋪一覽狀態 false:關閉店鋪一覽狀態
	public static bool AreaBool = false;
	//人員一覽狀態 true:開啟人員一覽狀態 false:關閉人員一覽狀態
	public static bool PeopleBool = false;
	//徵人狀態 true:開啟徵人狀態 false:關閉徵人狀態
	public static bool HireBool = false;
	//置產狀態 true:開啟置產狀態 false:關閉置產狀態
	public static bool BuyStoreBool = false;
	//決定狀態 true:開啟決定狀態 false:關閉決定狀態
	public static bool DecisionBool = false;   
	//員工 區域 店鋪 生成狀態 true:生成完成 false:生成未完成
	public static bool CreateBool = false;


	// Use this for initialization
	void Start () {
		//生成員工==========================================================================
		CreateEmployee ();
		//生成區域==========================================================================
		CreateArea();
		//生成店鋪==========================================================================
		CreateStore();
		//生成完成==========================================================================
		CreateBool = true;



		//讀檔=============================================================================
		//Saved = PlayerPrefs.GetInt("Saved" , 0); 
		//Write_ALL();


	}
	
	// Update is called once per frame
	void Update () {
		//播放按鈕音效
		if (Button_Sounds_Bool) {
			Button_Sounds.Play ();
			Button_Sounds_Bool = false;
		}

		//播放取消按鈕音效
		if (Cancel_Button_Sounds_Bool) {
			Cancel_Button_Sounds.Play ();
			Cancel_Button_Sounds_Bool = false;
		}

		//播放PayBack按鈕音效
		if (PayBack_Button_Sounds_Bool) {
			PayBack_Button_Sounds.Play ();
			PayBack_Button_Sounds_Bool = false;
		}

		//播放Buy按鈕音效
		if (Buy_Button_Sounds_Bool) {
			Buy_Button_Sounds.Play ();
			Buy_Button_Sounds_Bool = false;
		}

		//播放獲得金錢音效
		if (GetMoney_Button_Sounds_Bool) {
			GetMoney_Button_Sounds.Play ();
			GetMoney_Button_Sounds_Bool = false;
		}

		//播放等級提升音效
		if (LevelUP_Button_Sounds_Bool) {
			LevelUP_Button_Sounds.Play ();
			LevelUP_Button_Sounds_Bool = false;
		}

		//播放經驗值提升音效
		if (LevelEx_Button_Sounds_Bool) {
			LevelEx_Button_Sounds.Play ();
			LevelEx_Button_Sounds_Bool = false;
		}
			
	}

	//生成員工=============================================================================================
	void CreateEmployee(){
		//生成經理(ID 姓名 能力 薪水 僱用費用 自我介紹 僱用狀態 出勤狀態 工作地點)
		Manage [0] = new ManageClass (0 ,"沃特‧巴特" , 1 , 460000   , 0 , "雇用人之前，你需要確認三項素質：誠實，聰明，活力。但是最重要的是誠實。" , true , true , 0);
		Manage [1] = new ManageClass (1 ,"彼得·薩奇" , 2 , 789000   , 1654700 , "當市場下跌時，你輕易的將好東西打折變賣，但是一旦市場向上，再想買回來，難之又難。" , true , false , 1);
		Manage [2] = new ManageClass (2 ,"寶迪·鄧普頓" , 2 , 1180000  , 2141000 , "我可以靠著學生時期賣愛心筆的經驗，適時的給予幫助。" , false , false , 1);
		Manage [3] = new ManageClass (3 ,"班傑明·格嵐費姆" , 2 , 1680000  , 4300000 , "我不認識一個叫富蘭克林的人，但我認識隔壁賣奶茶的妹子。" , false , false , 1);
		Manage [4] = new ManageClass (4 ,"喬治·威盛頓" , 3 , 3468000  , 6570000 , "成功在優點的發揮，失敗是缺點的累積，我覺得是廢話。" , false , false , 1);
		Manage [5] = new ManageClass (5 ,"約翰‧醒夫" , 3 , 5689000  , 9672000 , "沒有口水與汗水，就只能去喝早餐店的紅茶。" , false , false , 1);
		Manage [6] = new ManageClass (6 ,"狂古·博格爾" , 4 , 9897000  , 13400000 , "做好手中事，珍惜眼前人。" , false , false , 1);
		Manage [7] = new ManageClass (7 ,"麥爾遜‧威斯" , 4 , 14200000 , 35550000 , "我只能說:問君能有幾多愁，睏了累了喝蠻牛。" , false , false , 1);
		Manage [8] = new ManageClass (8 ,"朱利亞‧迪伯遜" , 4 , 32640000 , 50000000 , "老闆我喜歡交朋友，尤其是女朋友。" , false , false , 1);
		Manage [9] = new ManageClass (9 ,"馬克·墨比普斯" , 5 , 56970000 , 84000000 , "少說多做，句句都會得到別人的重視；多說少做，句句都會受到別人的忽視。" , false , false , 1);
		//生成警衛(ID 姓名 能力 薪水 僱用費用 自我介紹 僱用狀態 出勤狀態 工作地點)
		Security[0] = new SecurityClass (0 ,"傑克·邱爾" , 1 , 236000  , 0 , "爭吵的時候，男人和女人的區別就像步槍和機關槍的區別。" , true , true , 0);
		Security[1] = new SecurityClass (1 ,"馬汀‧尼格" , 1 , 452100  , 84900 , "寒冷到了極致時，太陽就要光臨。" , true , false , 1);
		Security[2] = new SecurityClass (2 ,"黃浦興" , 2 , 553210  , 98000 , "不怕虎一樣的敵人，就怕豬一樣的隊友。" , false , false , 1);
		Security[3] = new SecurityClass (3 ,"李自白" , 2 , 804320  , 134520 , "成功是一種觀念，致富是一種義務，快樂是一種權力。" , false , false , 1);
		Security[4] = new SecurityClass (4 ,"趙永昌" , 3 , 1300000 , 179500 , "老闆，錢對你來說真的就那麼重要嗎？講了三個多小時了一分錢都不降？" , false , false , 1);
		Security[5] = new SecurityClass (5 ,"關漢壽" , 3 , 1850000 , 253000 , "強者向人們揭示的是確認人生的價值，弱者向人們揭示的卻是對人生的懷疑。" , false , false , 1);
		Security[6] = new SecurityClass (6 ,"克雷·哈森" , 3 , 3240000 , 324000 , "我要是做了人事部經理，第一件事就是提拔自己做老總。" , false , false , 1);
		Security[7] = new SecurityClass (7 ,"羅·福爾" , 4 , 4685000 , 495100 , "超乎一切之上的一件事，就是保持青春朝氣。" , false , false , 1);
		Security[8] = new SecurityClass (8 ,"馬克·科爾" , 4 , 5239600 , 541000 , "廢話是人際關係的第一句。" , false , false , 1);
		Security[9] = new SecurityClass (9 ,"羅剎" , 5 , 8745000 , 785100 , "每一個成功者都有一個開始。勇於開始，才能找到成功。" , false , false , 1);
		//生成顧問(ID 姓名 能力 薪水 僱用費用 自我介紹 僱用狀態 出勤狀態 工作地點 烹飪 音樂 科技 機工 金融)
		Consultant[0] = new ConsultantClass (0 ,"貝果" , 1 , 230000  , 0 , "逆風的方向更適合飛翔，我不怕千萬人阻擋只怕自己投降。" , true , false , 3 , 1 , 1 , 0 , 1);
		Consultant[1] = new ConsultantClass (1 ,"米其輪" , 1 , 280000  , 0 , "世界上那些最容易的事情中，拖延時間最不費力。" , true , false , 2 , 2 , 2 , 0 , 1);
		Consultant[2] = new ConsultantClass (2 ,"弗朗索瓦" , 1 , 370000  , 0 , "每天晚上疲憊地坐到椅子上時，才覺得真真切切地過了一天。" , true , false , 1 , 3 , 1 , 0 , 1);
		Consultant[3] = new ConsultantClass (3 ,"幔酘" , 1 , 450000  , 1555555 , "成功不是將來才有的，而是從決定去做的那一刻起，持續累積而成。" , false , false , 3 , 1 , 1 , 0 , 0);
		Consultant[4] = new ConsultantClass (4 ,"布里茲" , 2 , 680000  , 1974100 , "用腦思考，用心琢磨，用行動證實。" , false , false , 3 , 2 , 1 , 0 , 1);
		Consultant[5] = new ConsultantClass (5 ,"阿瑪迪斯" , 2 , 860000  , 2841000 , "工作的最高境界就是看著別人上班，領著別人的工資。" , false , false , 1 , 3 , 1 , 1 , 1);
		Consultant[6] = new ConsultantClass (6 ,"塞巴斯蒂安" , 2 , 930000  , 3333333 , "前程四緊就是：手頭緊、眉頭緊、衣服緊、時間緊。" , false , false , 2 , 3 , 3 , 1 , 1);
		Consultant[7] = new ConsultantClass (7 ,"費曲·博德" , 2 , 1700000 , 3485200 , "既然上了賊船，就要做個成功的海盜。" , false , false , 3 , 2 , 0 , 0 , 0);
		Consultant[8] = new ConsultantClass (8 ,"路德維希" , 3 , 1954000 , 4320000 , "學習要加，驕傲要減，機會要乘，懶惰要除。" , false , false , 1 , 3 , 2 , 2 , 1);
		Consultant[9] = new ConsultantClass (9 ,"威廉·G" , 3 , 2350000 , 5100000 , "唯女人與英語難過也，唯老婆與工作難找也。" , false , false , 2 , 2 , 3 , 2 , 0);

		Consultant[10] = new ConsultantClass (10 ,"史蒂芬·J" , 3 , 3360000  , 5505500 , "人生自古誰無死，哪個拉屎不用紙！" , false , false , 1 , 1 , 3 , 1 , 1);
		Consultant[11] = new ConsultantClass (11 ,"托瓦茲" , 3 , 4890000  , 6484100 , "積極思考造成積極人生，消極思考造成消極人生。" , false , false , 2 , 1 , 3 , 0 , 0);
		Consultant[12] = new ConsultantClass (12 ,"恰配克" , 3 , 6300000  , 8940100 , "微笑是我們心靈的最真誠傾訴，是在困難面前最好的良藥。" , false , false , 0 , 0 , 1 , 3 , 1);
		Consultant[13] = new ConsultantClass (13 ,"瓦特" , 3 , 7056000  , 14523000 , "在非洲，每隔一分鐘，就有六十秒過去。" , false , false , 2 , 2 , 2 , 3 , 1);
		Consultant[14] = new ConsultantClass (14 ,"紐克曼" , 4 , 8641000  , 26348100 , "跟你通電話的那晚，聽見了你的聲音。" , false , false , 1 , 2 , 1 , 3 , 2);
		Consultant[15] = new ConsultantClass (15 ,"達文西" , 4 , 8800000  , 45200000 , "跟你在一起時，回憶一天前的事情，就如回想昨天的事情。" , false , false , 3 , 0 , 2 , 3 , 1);
		Consultant[16] = new ConsultantClass (16 ,"湯普遜" , 4 , 9800000  , 57841000 , "比別人多一點志氣，你就會多一份出息。" , false , false , 1 , 2 , 3 , 0 , 3);
		Consultant[17] = new ConsultantClass (17 ,"摩根" , 5 , 13200000 , 63890000 , "比別人多一點執著，你就會創造奇蹟。" , false , false , 2 , 1 , 3 , 3 , 3);
		Consultant[18] = new ConsultantClass (18 ,"園潔三菱" , 5 , 35100000 , 78400000 , "月亮好美麗啊…到了這個時候，我還在工作喔！" , false , false , 1 , 1 , 3 , 3 , 3);
		Consultant[19] = new ConsultantClass (19 ,"易中滿" , 5 , 68740000 , 99999999 , "你付的出錢請我嗎?" , false , false , 3 , 3 , 3 , 3 , 3);

	}//生成員工=============================================================================================

	//生成區域=============================================================================================
	void CreateArea(){
		//麵包師傅區域(ID 區域名稱 總預期利潤 佔有率 可否開始經營狀態 回收時間 擁有店鋪數 區域景氣 區域治安)
		BreadArea = new AreaClass(0 ,"麵包師傅" , 0 , 20.0f , true , 0.0f , 2 , 100.0f , 100.0f);
		//音樂人區域(ID 區域名稱 總預期利潤 佔有率 可否開始經營狀態 回收時間 擁有店鋪數 區域景氣 區域治安)
		MusicArea = new AreaClass(1 ,"音樂人" , 0 , 10.0f , true , 0.0f , 1 , 100.0f , 100.0f);
		//科技新貴區域(ID 區域名稱 總預期利潤 佔有率 可否開始經營狀態 回收時間 擁有店鋪數 區域景氣 區域治安)
		TehcnologyArea = new AreaClass(2 ,"科技新貴" , 0 , 0.0f , false , 0.0f , 0 , 100.0f , 100.0f);
		//機工區域(ID 區域名稱 總預期利潤 佔有率 可否開始經營狀態 回收時間 擁有店鋪數 區域景氣 區域治安)
		FactoryArea = new AreaClass(3 ,"機工" , 0 , 0.0f , false , 0.0f , 0, 100.0f , 100.0f);
		//銀行家區域(ID 區域名稱 總預期利潤 佔有率 可否開始經營狀態 回收時間 擁有店鋪數 區域景氣 區域治安)
		EconomicArea = new AreaClass(4 ,"銀行家" , 0 , 0.0f , false , 0.0f , 0 , 100.0f , 100.0f);

	}//生成區域=============================================================================================

	//生成店鋪(1:烹飪 2:音樂 3:科技 4:機工 5:金融)==========================================================
	void CreateStore(){
		//麵包師傅區域(ID 店鋪名稱 預期利潤 置產價格 擁有狀態 投資狀態 店鋪分類 店鋪等級 店鋪經驗)
		BreadStore [0] = new Store (0 ,"香噴噴麵包" , 48000 , 0 , true , false , 1 , 1 , 0.0f);
		BreadStore [1] = new Store (1 ,"24小時烤爐" , 55555 , 0 , true , false , 1 , 1 , 0.0f);
		BreadStore [2] = new Store (2 ,"手持設備專門店" , 70000 , 1560000 , false , false , 3 , 1 , 0.0f);
		BreadStore [3] = new Store (3 ,"盧森音樂" , 74000 , 2270000 , false , false , 2 , 1 , 0.0f);
		BreadStore [4] = new Store (4 ,"糧食銀行" , 79000 , 2500000 , false , false , 5 , 1 , 0.0f);
		BreadStore [5] = new Store (5 ,"人力有限運輸公司" , 89900 , 3360000 , false , false , 4 , 1 , 0.0f);
		BreadStore [6] = new Store (6 ,"笛娘娘" , 91200 , 4590000 , false , false , 2 , 1 , 0.0f);
		BreadStore [7] = new Store (7 ,"記憶小舖" , 93540 , 6970000 , false , false , 3 , 1 , 0.0f);
		BreadStore [8] = new Store (8 ,"牛奶一日粥" , 97000 , 8009000 , false , false , 1 , 1 , 0.0f);
		BreadStore [9] = new Store (9 ,"麥可成麵包" , 99999 , 9840000 , false , false , 1 , 1 , 0.0f);
		//音樂人區域(ID 店鋪名稱 預期利潤 置產價格 擁有狀態 投資狀態 店鋪分類 店鋪等級 店鋪經驗)
		MusicStore [0] = new Store (0 ,"伊集音樂學院" , 59000 , 0 , true , false , 2 , 1 , 0.0f);
		MusicStore [1] = new Store (1 ,"齊燕蛋糕" , 78040 , 6200000 , false , false , 1 , 1 , 0.0f);
		MusicStore [2] = new Store (2 ,"皮耶諾公主" , 89152 , 7941025 , false , false , 2 , 1 , 0.0f);
		MusicStore [3] = new Store (3 ,"味噌3C用品" , 98741 , 8340100 , false , false , 3 , 1 , 0.0f);
		MusicStore [4] = new Store (4 ,"太平製鞋工廠" , 102410 , 8941502 , false , false , 4 , 1 , 0.0f);
		MusicStore [5] = new Store (5 ,"深醬燒烤" , 115203 , 9374100 , false , false , 1 , 1 , 0.0f);
		MusicStore [6] = new Store (6 ,"DJ的音樂庫" , 124529 , 10452100 , false , false , 2 , 1 , 0.0f);
		MusicStore [7] = new Store (7 ,"光影螢幕" , 137451 , 12451200 , false , false , 3 , 1 , 0.0f);
		MusicStore [8] = new Store (8 ,"艾倫的CD片" , 146500 , 15698741 , false , false , 2 , 1 , 0.0f);
		MusicStore [9] = new Store (9 ,"平安夜" , 160000 , 22974123 , false , false , 2 , 1 , 0.0f);
		//科技新貴區域(ID 店鋪名稱 預期利潤 置產價格 擁有狀態 投資狀態 店鋪分類 店鋪等級 店鋪經驗)
		TehcnologyStore [0] = new Store (0 ,"禿輪軸工業" , 63123 , 6506666 , false , false , 4 , 1 , 0.0f);
		TehcnologyStore [1] = new Store (1 ,"早上8:00吉他店" , 74011 , 6974100 , false , false , 2 , 1 , 0.0f);
		TehcnologyStore [2] = new Store (2 ,"APP工作坊" , 79103 , 7984102 , false , false , 3 , 1 , 0.0f);
		TehcnologyStore [3] = new Store (3 ,"世紀音樂鋪" , 83641 , 8341200 , false , false , 2 , 1 , 0.0f);
		TehcnologyStore [4] = new Store (4 ,"IOX獨立店" , 91122 , 8888841 , false , false , 3 , 1 , 0.0f);
		TehcnologyStore [5] = new Store (5 ,"素一食" , 143000 , 9410234 , false , false , 1 , 1 , 0.0f);
		TehcnologyStore [6] = new Store (6 ,"窗戶網" , 154003 , 10241000 , false , false , 3 , 1 , 0.0f);
		TehcnologyStore [7] = new Store (7 ,"鍵盤俠" , 192410 , 13254100 , false , false , 4 , 1 , 0.0f);
		TehcnologyStore [8] = new Store (8 ,"鷹哥的公開菜" , 221403 , 15555100 , false , false , 3 , 1 , 0.0f);
		TehcnologyStore [9] = new Store (9 ,"麥身塔" , 254000 , 19741000 , false , false , 3 , 1 , 0.0f);
		//機工區域(ID 店鋪名稱 預期利潤 置產價格 擁有狀態 投資狀態 店鋪分類 店鋪等級 店鋪經驗)
		FactoryStore[0] = new Store (0 ,"冷氣房" , 120000 , 23000000 , false , false , 4 , 1 , 0.0f);
		FactoryStore[1] = new Store (1 ,"Andromeda系統" , 154000 , 34100000 , false , false , 3 , 1 , 0.0f);
		FactoryStore[2] = new Store (2 ,"陳年救物" , 187900 , 39741000 , false , false , 2 , 1 , 0.0f);
		FactoryStore[3] = new Store (3 ,"輪胎燒業" , 234015 , 48970100 , false , false , 4 , 1 , 0.0f);
		FactoryStore[4] = new Store (4 ,"葉子板投幣基" , 274193 , 54100000 , false , false , 4 , 1 , 0.0f);
		FactoryStore[5] = new Store (5 ,"濃厚豆漿早餐店" , 364851 , 67410000 , false , false , 1 , 1 , 0.0f);
		FactoryStore[6] = new Store (6 ,"工業用榨汁機" , 462987 , 78000000 , false , false , 4 , 1 , 0.0f);
		FactoryStore[7] = new Store (7 ,"堆高噴機" , 551006 , 86541100 , false , false , 4 , 1 , 0.0f);
		FactoryStore[8] = new Store (8 ,"混音師" , 597410 , 96741000 , false , false , 2 , 1 , 0.0f);
		FactoryStore[9] = new Store (9 ,"機器人生活坊" , 681040 , 100000000 , false , false , 4 , 1 , 0.0f);
		//銀行家區域(ID 店鋪名稱 預期利潤 置產價格 擁有狀態 投資狀態 店鋪分類 店鋪等級 店鋪經驗)
		EconomicStore[0] = new Store (0 ,"極簡商業" , 3000000 , 40687400 , false , false , 5 , 1 , 0.0f);
		EconomicStore[1] = new Store (1 ,"Paradise半導體" , 4120365 , 54074110 , false , false , 3 , 1 , 0.0f);
		EconomicStore[2] = new Store (2 ,"摩爾電晶體" , 4379874 , 65741000 , false , false , 3 , 1 , 0.0f);
		EconomicStore[3] = new Store (3 ,"大西洋標準保險" , 5974125 , 74100000 , false , false , 5 , 1 , 0.0f);
		EconomicStore[4] = new Store (4 ,"德普安畢會計事務所" , 6874124 , 103650000 , false , false , 5 , 1 , 0.0f);
		EconomicStore[5] = new Store (5 ,"英泰樂處理器" , 7352879 , 188410000 , false , false , 4 , 1 , 0.0f);
		EconomicStore[6] = new Store (6 ,"ZeGuess圖形運算器" , 7741741 , 230000000 , false , false , 4 , 1 , 0.0f);
		EconomicStore[7] = new Store (7 ,"國家中央銀行" , 8347120 , 369741100 , false , false , 5 , 1 , 0.0f);
		EconomicStore[8] = new Store (8 ,"太平洋儲蓄金庫" , 8877495 , 520410000 , false , false , 5 , 1 , 0.0f);
		EconomicStore[9] = new Store (9 ,"世界聯邦銀行" , 9271000 , 1500000000 , false , false , 5 , 1 , 0.0f);


	}//生成店鋪===============================================================================================

	//副程式:回傳顧問支援能力圖形=================================================================================================
	public static void Consultant_Advantage(int Number , Text Advantage_Text){
		if (Number == 0)
			Advantage_Text.text = "✕";
		else if (Number == 1)
			Advantage_Text.text = "▲";
		else if (Number == 2)
			Advantage_Text.text = "○";
		else if (Number == 3)
			Advantage_Text.text = "✮";
	}

	//副程式:增加持有金錢(共13位數)===============================================================================================
	public static void ADD_OwnMoney(ulong Money , Text OwnMoney_Text){
		OwnMoney = OwnMoney + Money;
		if (OwnMoney > 9999999999999)
			OwnMoney = 9999999999999;
		SetText_OwnMoney (OwnMoney_Text);
		MainState.OwnMoneyBool = false;
	}
	//副程式:減少持有金錢(共13位數)===============================================================================================
	public static void SUB_OwnMoney(ulong Money , Text OwnMoney_Text){
		OwnMoney = OwnMoney - Money;
		if (OwnMoney < 0)
			OwnMoney = 0;
		SetText_OwnMoney (OwnMoney_Text);
		MainState.OwnMoneyBool = false; 
	}

	//副程式:設定持有金錢Text(共13位數)===============================================================================================
	public static void SetText_OwnMoney(Text OwnMoney_Text){
		//最大位數
		int Biggest_Number;
		//前4位數
		int Front_Four_Number;
		//中4位數
		int Mid_Four_NUmber;
		//後4位數
		int Behind_Four_NUmber;
		//暫存數字
		ulong Temp,Temp2,Temp3,Temp4;

		//最大位數
		Temp = OwnMoney / 1000000000000;
		Biggest_Number = (int)Temp;
		//前4位數
		Temp2 = (OwnMoney - (ulong)Biggest_Number*1000000000000) / 100000000;
		Front_Four_Number = (int)Temp2;
		//中4位數
		Temp3 = (OwnMoney - (ulong)Biggest_Number*1000000000000 - (ulong)Front_Four_Number*100000000) / 10000;
		Mid_Four_NUmber = (int)Temp3;
		//後4位數
		Temp4 = (OwnMoney - (ulong)Biggest_Number*1000000000000 - (ulong)Front_Four_Number*100000000 - (ulong)Mid_Four_NUmber*10000);
		Behind_Four_NUmber = (int)Temp4;

		if(Biggest_Number>0) OwnMoney_Text.text = (ulong)Biggest_Number + "兆" + (ulong)Front_Four_Number + "億" + (ulong)Mid_Four_NUmber + "萬" + (ulong)Behind_Four_NUmber + "圓";
		else if(Biggest_Number<=0 && Front_Four_Number>0) OwnMoney_Text.text = (ulong)Front_Four_Number + "億" + (ulong)Mid_Four_NUmber + "萬" + (ulong)Behind_Four_NUmber + "圓";
		else if(Biggest_Number<=0 && Front_Four_Number<=0 && Mid_Four_NUmber>0) OwnMoney_Text.text = (ulong)Mid_Four_NUmber + "萬" + (ulong)Behind_Four_NUmber + "圓";
		else OwnMoney_Text.text = (ulong)Behind_Four_NUmber + "圓";
	}

	//副程式:設定預期利潤Text(共12位數)9999 9999 9999===============================================================================================
	public static void SetText_Pricey(uint Price ,Text Price_Text){
		//前4位數
		uint Front_Four_Number;
		//中4位數
		uint Mid_Four_NUmber;
		//後4位數
		uint Behind_Four_NUmber;
		//暫存數字
		uint Temp,Temp2,Temp3;

		//前4位數
		Temp = Price / 100000000;
		Front_Four_Number = Temp;
		//中4位數
		Temp2 = (Price - Front_Four_Number*100000000) / 10000;
		Mid_Four_NUmber = Temp2;
		//後4位數
		Temp3 = (Price - Front_Four_Number*100000000 - Mid_Four_NUmber*10000);
		Behind_Four_NUmber = Temp3;

		if(Front_Four_Number>0) Price_Text.text = Front_Four_Number + "億" + Mid_Four_NUmber + "萬" + Behind_Four_NUmber + "圓";
		else if(Front_Four_Number<=0 && Mid_Four_NUmber>0) Price_Text.text = Mid_Four_NUmber + "萬" + Behind_Four_NUmber + "圓";
		else Price_Text.text = Behind_Four_NUmber + "圓";
	}

	//存檔:持有金錢(共13位數)9 9999 9999 9999===============================================================================================
	public static void Save_OwnMoney(){
		//最大位數
		int Biggest_Number;
		//前4位數
		int Front_Four_Number;
		//中4位數
		int Mid_Four_NUmber;
		//後4位數
		int Behind_Four_NUmber;
		//暫存數字
		ulong Temp,Temp2,Temp3,Temp4;

		//最大位數
		Temp = OwnMoney / 1000000000000;
		if (Temp > 9)
			Biggest_Number = 9;
		else
			Biggest_Number = (int)Temp;

		//前4位數
		Temp2 = (OwnMoney - (ulong)Biggest_Number*1000000000000) / 100000000;
		Front_Four_Number = (int)Temp2;
		//中4位數
		Temp3 = (OwnMoney - (ulong)Biggest_Number*1000000000000 - (ulong)Front_Four_Number*100000000) / 10000;
		Mid_Four_NUmber = (int)Temp3;
		//後4位數
		Temp4 = (OwnMoney - (ulong)Biggest_Number*1000000000000 - (ulong)Front_Four_Number*100000000 - (ulong)Mid_Four_NUmber*10000);
		Behind_Four_NUmber = (int)Temp4;

		//print (Biggest_Number + " " + Front_Six_Number + " " + Behind_Six_NUmber);
		PlayerPrefs.SetInt ("Biggest_Number" , Biggest_Number);
		PlayerPrefs.Save (); 
		PlayerPrefs.SetInt ("Front_Four_Number" , Front_Four_Number);
		PlayerPrefs.Save (); 
		PlayerPrefs.SetInt ("Mid_Four_NUmber" , Mid_Four_NUmber);
		PlayerPrefs.Save (); 
		PlayerPrefs.SetInt ("Behind_Four_NUmber" , Behind_Four_NUmber);
		PlayerPrefs.Save (); 

	}
		
	//讀檔:持有金錢(共13位數)===============================================================================================
	public static void Write_OwnMoney(){
		int Biggest_Number = PlayerPrefs.GetInt("Biggest_Number" , 0); 
		int Front_Four_Number = PlayerPrefs.GetInt("Front_Six_Number" , 0); 
		int Mid_Four_NUmber = PlayerPrefs.GetInt("Mid_Four_NUmber" , 2000); 
		int Behind_Four_NUmber = PlayerPrefs.GetInt("Behind_Four_NUmber" , 0); 

		OwnMoney = (ulong)Biggest_Number*1000000000000 + (ulong)Front_Four_Number*100000000  + (ulong)Mid_Four_NUmber*10000 + (ulong)Behind_Four_NUmber;
	}

	/*//顯示存檔================================================================================================================
	public void Save_Show(){
		//顯示存檔畫面
		Save_Show_Draw.SetActive(true);
		//關閉存檔按鈕
		Save_Show_Button.interactable = false;
	}

	//取消存檔===============================================================================================================
	public void Save_Show_cancel(){
		//隱藏存檔畫面
		Save_Show_Draw.SetActive(false);
		//開啟存檔按鈕
		Save_Show_Button.interactable = true;
	}*/

	//確定存檔================================================================================================================
	public static void Save_ALL(){
		//開啟存檔按鈕
		//Save_Show_Button.interactable = true;

		//有存過檔
		Saved = 1;
		PlayerPrefs.SetInt ("Saved" , Saved);
		PlayerPrefs.Save (); 

		//持有金錢========================================================================
		Save_OwnMoney ();

		//員工========================================================================
		//存檔(經理)==================================================
		for(int i=0; i<ManageNumber; i++){
			Manage [i].Save_Hire ();
			Manage [i].Save_Work ();
			Manage [i].Save_WorkPlace ();
		}
		//存檔(警衛)==================================================
		for(int i=0; i<SecurityNumber; i++){
			Security [i].Save_Hire ();
			Security [i].Save_Work ();
			Security [i].Save_WorkPlace ();
		}
		//存檔(顧問)==================================================
		for(int i=0; i<ConsultantNumber; i++){
			Consultant [i].Save_Hire ();
		}

		//店鋪存檔===========================================================================
		//存檔(麵包師傅)==============================================
		for(int i=0; i<BreadStoreNumber; i++){
			BreadStore [i].Save_InvestBool (Save_Bread_InvestBool);
			BreadStore [i].Save_Level (Save_Bread_Level);
			BreadStore [i].Save_LevelEx (Save_Bread_LevelEx);
			BreadStore [i].Save_OwnBool (Save_Bread_OwnBool);
		}
		//存檔(音樂人)==============================================
		for(int i=0; i<MusicStoreNumber; i++){
			MusicStore [i].Save_InvestBool (Save_Music_InvestBool);
			MusicStore [i].Save_Level (Save_Music_Level);
			MusicStore [i].Save_LevelEx (Save_Music_LevelEx);
			MusicStore [i].Save_OwnBool (Save_Music_OwnBool);
		}
		//存檔(科技新貴)==============================================
		for(int i=0; i<TehcnologyStoreNumber; i++){
			TehcnologyStore [i].Save_InvestBool (Save_Tehcnology_InvestBool);
			TehcnologyStore [i].Save_Level (Save_Tehcnology_Level);
			TehcnologyStore [i].Save_LevelEx (Save_Tehcnology_LevelEx);
			TehcnologyStore [i].Save_OwnBool (Save_Tehcnology_OwnBool);
		}
		//存檔(機工)==============================================
		for(int i=0; i<FactoryStoreNumber; i++){
			FactoryStore [i].Save_InvestBool (Save_Factory_InvestBool);
			FactoryStore [i].Save_Level (Save_Factory_Level);
			FactoryStore [i].Save_LevelEx (Save_Factory_LevelEx);
			FactoryStore [i].Save_OwnBool (Save_Factory_OwnBool);
		}
		//存檔(銀行家)==============================================
		for(int i=0; i<EconomicStoreNumber; i++){
			EconomicStore [i].Save_InvestBool (Save_Economic_InvestBool);
			EconomicStore [i].Save_Level (Save_Economic_Level);
			EconomicStore [i].Save_LevelEx (Save_Economic_LevelEx);
			EconomicStore [i].Save_OwnBool (Save_Economic_OwnBool);
		}

		//區域存檔==========================================================================
		//存檔(麵包師傅)==============================================
		BreadArea.Save_Manage(Save_Area_Manage);
		BreadArea.Save_ManageTime (Save_Area_ManageTime);
		//存檔(音樂人)==============================================
		MusicArea.Save_Manage(Save_Area_Manage);
		MusicArea.Save_ManageTime (Save_Area_ManageTime);
		//存檔(科技新貴)==============================================
		TehcnologyArea.Save_Manage(Save_Area_Manage);
		TehcnologyArea.Save_ManageTime (Save_Area_ManageTime);
		//存檔(機工)==============================================
		FactoryArea.Save_Manage(Save_Area_Manage);
		FactoryArea.Save_ManageTime (Save_Area_ManageTime);
		//存檔(銀行家)==============================================
		EconomicArea.Save_Manage(Save_Area_Manage);
		EconomicArea.Save_ManageTime (Save_Area_ManageTime);


	}//整體存檔================================================================================================================

	/*//顯示讀檔================================================================================================================
	public static void Write_Show(){
		//顯示讀檔畫面
		Write_Show_Draw.SetActive(true);
		//關閉讀檔按鈕
		Write_Show_Button.interactable = false;
	}

	//取消讀檔===============================================================================================================
	public void Write_Show_cancel(){
		//隱藏讀檔畫面
		Write_Show_Draw.SetActive(false);
		//開啟讀檔按鈕
		Write_Show_Button.interactable = true;
	}*/
		
	//整體讀檔=================================================================================================================
	public static void Write_ALL(){
		//開啟讀檔按鈕
		//Write_Show_Button.interactable = true;

		//持有金錢===========================================================================
		Write_OwnMoney();

		//員工讀檔===========================================================================
		//讀檔(經理)==================================================
		for(int i=0; i<ManageNumber; i++){
			Manage [i].Write_Hire ();
			Manage [i].Write_Work ();
			Manage [i].Write_WorkPlace ();
		}
		//讀檔(警衛)==================================================
		for(int i=0; i<SecurityNumber; i++){
			Security [i].Write_Hire ();
			Security [i].Write_Work ();
			Security [i].Write_WorkPlace ();
		}
		//讀檔(顧問)==================================================
		for(int i=0; i<ConsultantNumber; i++){
			Consultant [i].Write_Hire ();
		}

		//店鋪讀檔===========================================================================
		//讀檔(麵包師傅)==============================================
		for(int i=0; i<BreadStoreNumber; i++){
			BreadStore [i].Write_InvestBool (Save_Bread_InvestBool);
			BreadStore [i].Write_Level (Save_Bread_Level);
			BreadStore [i].Write_LevelEx (Save_Bread_LevelEx);
			BreadStore [i].Write_OwnBool (Save_Bread_OwnBool);
			if (BreadStore [i].GetOwnBool () == true)
				BreadArea.SetStoreNumber (BreadArea.GetStoreNumber() + 1);
		}
		//讀檔(音樂人)==============================================
		for(int i=0; i<MusicStoreNumber; i++){
			MusicStore [i].Write_InvestBool (Save_Music_InvestBool);
			MusicStore [i].Write_Level (Save_Music_Level);
			MusicStore [i].Write_LevelEx (Save_Music_LevelEx);
			MusicStore [i].Write_OwnBool (Save_Music_OwnBool);
			if (MusicStore [i].GetOwnBool () == true)
				MusicArea.SetStoreNumber (MusicArea.GetStoreNumber() + 1);
		}
		//讀檔(科技新貴)==============================================
		for(int i=0; i<TehcnologyStoreNumber; i++){
			TehcnologyStore [i].Write_InvestBool (Save_Tehcnology_InvestBool);
			TehcnologyStore [i].Write_Level (Save_Tehcnology_Level);
			TehcnologyStore [i].Write_LevelEx (Save_Tehcnology_LevelEx);
			TehcnologyStore [i].Write_OwnBool (Save_Tehcnology_OwnBool);
			if (TehcnologyStore [i].GetOwnBool () == true)
				TehcnologyArea.SetStoreNumber (TehcnologyArea.GetStoreNumber() + 1);
		}
		//讀檔(機工)==============================================
		for(int i=0; i<FactoryStoreNumber; i++){
			FactoryStore [i].Write_InvestBool (Save_Factory_InvestBool);
			FactoryStore [i].Write_Level (Save_Factory_Level);
			FactoryStore [i].Write_LevelEx (Save_Factory_LevelEx);
			FactoryStore [i].Write_OwnBool (Save_Factory_OwnBool);
			if (FactoryStore [i].GetOwnBool () == true)
				FactoryArea.SetStoreNumber (FactoryArea.GetStoreNumber() + 1);
		}
		//讀檔(銀行家)==============================================
		for(int i=0; i<EconomicStoreNumber; i++){
			EconomicStore [i].Write_InvestBool (Save_Economic_InvestBool);
			EconomicStore [i].Write_Level (Save_Economic_Level);
			EconomicStore [i].Write_LevelEx (Save_Economic_LevelEx);
			EconomicStore [i].Write_OwnBool (Save_Economic_OwnBool);
			if (EconomicStore [i].GetOwnBool () == true)
				EconomicArea.SetStoreNumber (EconomicArea.GetStoreNumber() + 1);
		}

		//區域讀檔==========================================================================
		//讀檔(麵包師傅)==============================================
		BreadArea.Write_Manage(Save_Area_Manage);
		BreadArea.Write_ManageTime (Save_Area_ManageTime);
		//讀檔(音樂人)==============================================
		MusicArea.Write_Manage(Save_Area_Manage);
		MusicArea.Write_ManageTime (Save_Area_ManageTime);
		//讀檔(科技新貴)==============================================
		TehcnologyArea.Write_Manage(Save_Area_Manage);
		TehcnologyArea.Write_ManageTime (Save_Area_ManageTime);
		//讀檔(機工)==============================================
		FactoryArea.Write_Manage(Save_Area_Manage);
		FactoryArea.Write_ManageTime (Save_Area_ManageTime);
		//讀檔(銀行家)==============================================
		EconomicArea.Write_Manage(Save_Area_Manage);
		EconomicArea.Write_ManageTime (Save_Area_ManageTime);
	}
	//整體讀檔=================================================================================================================

	//副程式:播放按鈕音效
	public static void Button_Sounds_Play(){
		Button_Sounds_Bool = true;
	}

	//副程式:播放取消按鈕音效
	public static void Cancel_Button_Sounds_Play(){
		Cancel_Button_Sounds_Bool = true;
	}

	//副程式:播放按鈕音效
	public static void PayBack_Button_Sounds_Play(){
		PayBack_Button_Sounds_Bool = true;
	}

	//副程式:播放Buy音效
	public static void Buy_Button_Sounds_Play(){
		Buy_Button_Sounds_Bool = true;
	}

	//副程式:播放獲得金錢音效
	public static void GetMoney_Button_Sounds_Play(){
		GetMoney_Button_Sounds_Bool = true;
	}

	//副程式:等級提升音效
	public static void LevelUP_Button_Sounds_Play(){
		LevelUP_Button_Sounds_Bool = true;
	}

	//副程式:經驗值提升音效
	public static void LevelEx_Button_Sounds_Play(){
		LevelEx_Button_Sounds_Bool = true;
	}


    //副程式:離開遊戲
    public static void Quit_Game()
    {
        Application.Quit();
    }

}
