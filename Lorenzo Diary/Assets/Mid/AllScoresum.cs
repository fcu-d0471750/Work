//結算畫面
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class AllScoresum : MonoBehaviour {


	//宣告變數****************
	public GameObject Nextbutton;           //按鈕:回到主選單
	public Text LevelCorrectsumText = null; //總正確題數
	public Text LevelMistakeSumText= null;  //總錯誤題數
	public Text LevelText = null;			//題目數
	public Text ScoreText = null;			//總分數
	public Text LevelCorrectText = null;    //正確題數
	public Text LevelMistakeText = null;    //錯誤題數
	public Text EnglishText = null;         //英文評價
	public Text ArchievementText = null;    //解鎖成就
	public  AudioSource music;              //音樂
	float  time = 7;                        //結果顯示時間
	public AudioSource ButtonMusic;         //按扭音效
	int Rand = 0;                           //隨機獲得物資
	float timef;                            //時間
	public Animation SaveImage;             //儲存中動畫
	//AllScore.LevelCorrectsum LevelMistakesum
	// Use this for initialization
	void Start () {
		
		//音樂
		if(Musicbotton.musicplay == true) music.Play();  //如果開始畫面音效被開啟,音樂播放
		else music.Pause();                              //如果開始畫面音效被關閉,音樂暫停

		Nextbutton.SetActive(false);  		        //隱藏按鈕:回到主選單



		/*/商店答對********************************************************************************
		if (Store.pintCorrect == 1) {
			//AllScore.LevelCorrect++;                     //答對題數+1
			AllScore.LevelCorrectsum++;                  //總答對題數+1
		}
		else if (Store.pintCorrect == 2) {
			//AllScore.LevelCorrect = AllScore.LevelCorrect+2;                     //答對題數+2
			AllScore.LevelCorrectsum = AllScore.LevelCorrectsum+2;               //總答對題數+2
		}
		else if (Store.pintCorrect == 3) {
			//AllScore.LevelCorrect = AllScore.LevelCorrect+3;                     //答對題數+3
			AllScore.LevelCorrectsum = AllScore.LevelCorrectsum+3;               //總答對題數+3
		}
		else if (Store.pintCorrect == 4) {
			//AllScore.LevelCorrect = AllScore.LevelCorrect+4;                     //答對題數+4
			AllScore.LevelCorrectsum = AllScore.LevelCorrectsum+4;               //總答對題數+4
		}
		else if (Store.pintCorrect == 5) {
			//AllScore.LevelCorrect = AllScore.LevelCorrect+5;                     //答對題數+5
			AllScore.LevelCorrectsum = AllScore.LevelCorrectsum+5;               //總答對題數+5
		}

		//商店答錯************************************************************************************
		if (Store.pintMistake == 1) {
			//AllScore.LevelMistake = AllScore.LevelMistake+2;                        //答錯題數+1
			AllScore.LevelMistakesum = AllScore.LevelMistakesum+1;                  //總答錯題數+1
		}
		else if (Store.pintMistake == 2) {
			//AllScore.LevelMistake = AllScore.LevelMistake+4;                        //答錯題數+2
			AllScore.LevelMistakesum = AllScore.LevelMistakesum+2;                  //總答錯題數+2
		}
		else if (Store.pintMistake == 3) {
			//AllScore.LevelMistake = AllScore.LevelMistake+5;                        //答錯題數+3
			AllScore.LevelMistakesum = AllScore.LevelMistakesum+3;                  //總答錯題數+3
		}
		else if (Store.pintMistake == 4) {
			//AllScore.LevelMistake = AllScore.LevelMistake+7;                        //答錯題數+4
			AllScore.LevelMistakesum = AllScore.LevelMistakesum+4;                  //總答錯題數+4
		}
		else if (Store.pintMistake == 5) {
			//AllScore.LevelMistake = AllScore.LevelMistake+8;                        //答錯題數+5
			AllScore.LevelMistakesum = AllScore.LevelMistakesum+5;                  //總答錯題數+5
		}*/



		PlayerPrefs.SetInt("LevelCorrectsum", AllScore.LevelCorrectsum);  //儲存總答對題數
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了

		PlayerPrefs.SetInt("LevelMistakesum", AllScore.LevelMistakesum);  //儲存總答對題數
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了

		//評價次數
		//英文分數評價
		if (AllScore.LevelScore < 200) AllScore.E++;
		else if (AllScore.LevelScore < 600 && AllScore.LevelScore >= 200) AllScore.D++;
		else if (AllScore.LevelScore < 800 && AllScore.LevelScore >= 600) AllScore.C++;
		else if (AllScore.LevelScore < 1000 && AllScore.LevelScore >= 800) AllScore.B++;
		else if (AllScore.LevelScore < 1200 && AllScore.LevelScore >= 1000) AllScore.A++;
		else 	AllScore.S++;

		//讀入物資
		Main.peoplesum   =  PlayerPrefs.GetInt("peoplesum1"); //讀入成就記錄(以下相同)
		Main.weaponsum   =  PlayerPrefs.GetInt("weaponsum1"); //讀入成就記錄(以下相同)
		Main.hospitalsum =  PlayerPrefs.GetInt("hospitalsum1"); //讀入成就記錄(以下相同)
		Main.foodsum     =  PlayerPrefs.GetInt("foodsum1"); //讀入成就記錄(以下相同)
		Main.moneysum    =  PlayerPrefs.GetInt("moneysum1"); //讀入成就記錄(以下相同)

		Placeyesno.Placetime =  PlayerPrefs.GetInt("Placetime1"); //讀入成就記錄(以下相同)
		Placeyesno2.Placetime =  PlayerPrefs.GetInt("Placetime2"); //讀入成就記錄(以下相同)
		Placeyesno3.Placetime =  PlayerPrefs.GetInt("Placetime3"); //讀入成就記錄(以下相同)
		Placeyesno4.Placetime =  PlayerPrefs.GetInt("Placetime4"); //讀入成就記錄(以下相同)
		Placeyesno5.Placetime =  PlayerPrefs.GetInt("Placetime5"); //讀入成就記錄(以下相同)

		//獲得物資
		if (AllScore.LevelScore < 200 && AllScore.LevelScore >= 100) Rand = UnityEngine.Random.Range( 10, 200 );
		else if (AllScore.LevelScore < 600 && AllScore.LevelScore >= 200)   Rand = UnityEngine.Random.Range( 200, 600 );
		else if (AllScore.LevelScore < 800 && AllScore.LevelScore >= 600)   Rand = UnityEngine.Random.Range( 600, 800 );
		else if (AllScore.LevelScore < 1000 && AllScore.LevelScore >= 800)  Rand = UnityEngine.Random.Range( 800, 1000 );
		else if (AllScore.LevelScore < 1200 && AllScore.LevelScore >= 1000)	 Rand = UnityEngine.Random.Range( 1000, 1200 );
		else if (AllScore.LevelScore >= 1200) Rand = UnityEngine.Random.Range( 1200, 2000 );

		Main.peoplesum    = Main.peoplesum    + Rand;
		Main.weaponsum    = Main.weaponsum    + Rand;
		Main.hospitalsum  = Main.hospitalsum  + Rand;
		Main.foodsum      = Main.foodsum      + Rand;
		Main.moneysum     = Main.moneysum     + Rand;

		SaveImage.Play ();

	}
	
	// Update is called once per frame
	void Update () {
		time = time - Time.deltaTime;      //減少結果顯示時間(這樣就能一行一行顯示)

		//分數顯示**************************************************************
		if((int)time == 6) LevelText.text = "" + AllScore.Level1;    //顯示文字
		if((int)time == 5) LevelCorrectText.text = "" + AllScore.LevelCorrect; //顯示文字
		if((int)time == 4) LevelMistakeText.text = "" + AllScore.LevelMistake; //顯示文字
		if((int)time == 3) LevelCorrectsumText.text = "" + AllScore.LevelCorrectsum;  //顯示文字
		if((int)time == 2) LevelMistakeSumText.text = "" + AllScore.LevelMistakesum;  //顯示文字
		if((int)time == 0) 
		{
			ScoreText.text = "" + AllScore.LevelScore;  //顯示分數文字

			//英文分數評價
			if (AllScore.LevelScore < 200) EnglishText.text = "E";
			else if (AllScore.LevelScore < 600 && AllScore.LevelScore >= 200) EnglishText.text = "D";
			else if (AllScore.LevelScore < 800 && AllScore.LevelScore >= 600) EnglishText.text = "C";	 
			else if (AllScore.LevelScore < 1000 && AllScore.LevelScore >= 800) EnglishText.text = "B";
			else if (AllScore.LevelScore < 1200 && AllScore.LevelScore >= 1000)EnglishText.text = "A";	
			else if (AllScore.LevelScore >= 1200)EnglishText.text = "S";
			 	
			ArchievementText.text = "獲得物資x" + Rand;



			/*/成就解鎖(總答對題數)*******************************************
			if(AllScore.LevelCorrectsum>=5 && Award1.Get[1]!=1) 
			{
				Award1.Get [1] = 1;                     //成就已解鎖(以下都相同)
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelCorrectsum>=50 && Award1.Get[2]!=1) 
			{
				Award1.Get [2] = 1;
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelCorrectsum>=500 && Award1.Get[3]!=1)
			{
				Award1.Get [3] = 1;
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelCorrectsum>=1000 && Award1.Get[4]!=1) 
			{
				Award1.Get [4] = 1;
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelCorrectsum>=3000 && Award1.Get[5]!=1) 
			{
				Award1.Get [5] = 1;
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelCorrectsum>=5000 && Award1.Get[6]!=1) 
			{
				Award1.Get [6] = 1;
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelCorrectsum>=9999 && Award1.Get[7]!=1) 
			{
				Award1.Get [7] = 1;
				ArchievementText.text = "成就解鎖";
			}

			//成就解鎖(總答錯題數)*******************************************
			if(AllScore.LevelMistakesum>=5 && Award1.Get[8]!=1)
			{
				Award1.Get [8] = 1;
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelMistakesum>=50 && Award1.Get[9]!=1) 
			{
				Award1.Get [9] = 1;
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelMistakesum>=500 && Award1.Get[10]!=1) 
			{
				Award1.Get [10] = 1;
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelMistakesum>=1000 && Award1.Get[11]!=1) 
			{
				Award1.Get [11] = 1;
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelMistakesum>=3000 && Award1.Get[12]!=1) 
			{
				Award1.Get [12] = 1;
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelMistakesum>=5000 && Award1.Get[13]!=1) 
			{
				Award1.Get [13] = 1;
				ArchievementText.text = "成就解鎖";
			}
			if(AllScore.LevelMistakesum>=9999 && Award1.Get[14]!=1) 
			{
				Award1.Get [14] = 1;
				ArchievementText.text = "成就解鎖";
			}

			//成就解鎖(全部)*******************************************
			if(AllScore.LevelCorrectsum>=9999 && AllScore.LevelMistakesum>=9999 && Award1.Get[15]!=1) 
			{
				Award1.Get [15] = 1;
				ArchievementText.text = "成就解鎖";
			}*/

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


			Nextbutton.SetActive(true);  		        //顯示按鈕:回到主選單
		}




		/*/獎杯是否獲得(防止玩家已解鎖成就,卻又跑出已解鎖成就的訊息)*********************************************************************
		PlayerPrefs.SetInt("Award1Get1", Award1.Get[1]);   //儲存成就是否解鎖
		PlayerPrefs.Save();                      		   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get2", Award1.Get[2]);   //儲存成就是否解鎖
		PlayerPrefs.Save();                      		    //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get3", Award1.Get[3]);   //儲存成就是否解鎖
		PlayerPrefs.Save();                       		   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get4", Award1.Get[4]);   //儲存成就是否解鎖
		PlayerPrefs.Save();                       		   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get5", Award1.Get[5]);   //儲存成就是否解鎖
		PlayerPrefs.Save();                        		   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get6", Award1.Get[6]);   //儲存成就是否解鎖
		PlayerPrefs.Save();                        		   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get7", Award1.Get[7]);   //儲存成就是否解鎖
		PlayerPrefs.Save();                        		   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get8", Award1.Get[8]);   //儲存成就是否解鎖
		PlayerPrefs.Save();                         	   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get9", Award1.Get[9]);   //儲存成就是否解鎖
		PlayerPrefs.Save();                        		   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get10", Award1.Get[10]); //儲存成就是否解鎖
		PlayerPrefs.Save();                        		   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get11", Award1.Get[11]); //儲存成就是否解鎖
		PlayerPrefs.Save();                         	   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get12", Award1.Get[12]); //儲存成就是否解鎖
		PlayerPrefs.Save();                          	   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get13", Award1.Get[13]); //儲存成就是否解鎖
		PlayerPrefs.Save();                                //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get14", Award1.Get[14]); //儲存成就是否解鎖
		PlayerPrefs.Save();                         	   //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("Award1Get15", Award1.Get[15]); //儲存成就是否解鎖
		PlayerPrefs.Save();                         	   //加上這步驟後，存檔就完成了*/

		//關卡是否出現,恢復初始值*************************************************************
		for(int i=0; i<400; i++) selectlevel.playing[i] = 0; 
		//紀錄評價次數*********************************************************************************
		PlayerPrefs.SetInt("SS", AllScore.S);  //儲存總答對題數
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("AS", AllScore.A);  //儲存總答對題數
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("BS", AllScore.B);  //儲存總答對題數
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("CS", AllScore.C);  //儲存總答對題數
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("DS", AllScore.D);  //儲存總答對題數
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("ES", AllScore.E);  //儲存總答對題數
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了
		PlayerPrefs.SetInt("peoplesum1", Main.peoplesum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("weaponsum1", Main.weaponsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("hospitalsum1", Main.hospitalsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("foodsum1", Main.foodsum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 
		PlayerPrefs.SetInt("moneysum1", Main.moneysum );
		PlayerPrefs.Save(); //加上這步驟後，存檔就完成了 

	}

	public void Next()
	{
		ButtonMusic.Play ();
		AllScore.Level1 = 0;                    //關卡數恢復初始值
		Application.LoadLevel("selectscreen");  //切到難度選擇畫面  
	}

}
