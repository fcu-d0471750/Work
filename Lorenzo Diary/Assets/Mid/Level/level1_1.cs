using UnityEngine;
using System.Collections;
using UnityEngine.UI; //使用UI

public class level1_1 : MonoBehaviour {

	//宣告變數********************************
	public  Text ScoreText = null;             //分數text
	public  Text NumberText = null;            //題目數text
	public  Text Question = null;              //題目text
	public  Text TimeText = null;              //遊戲剩餘時間text
	public  Text CateText = null;              //題目類別text
	public  GameObject yes;                    //按鈕元件 yes
	public  GameObject no1,no2,no3;            //按鈕元件 no1 no2 no3
	public  Button yes1;                       //按鈕元件 yes
	public  Button no4,no5,no6;                //按鈕元件 no1 no2 no3
	public  Image TimeImage;                   //遊戲剩餘時間Image 
	public  AudioSource music;                 //音樂
	public  AudioSource questionmusic;         //問題音效
	public  AudioSource correctmusic;          //正確音效
	public  AudioSource incorrectmusic;        //錯誤音效
	public  Animation  CorrectAnimation;       //正確動畫
	public  Animation  IncorrectAnimation;     //錯誤動畫
	public  Animation  ContinousAnimation;     //連續答對動畫
	public Animation SaveImage;                //儲存中動畫
	public  Text       ContinousText;          //連續答對Text
	int     ContinousNumber;                   //連續答對題數        
	float   time = 9;                          //遊戲限制時間(玩家只有7秒可以選答案,2秒是玩家沒選答案顯示答案的時間)
	float   time1;       			           //遊戲剩餘時間
	int     randlevel;     				       //產生20~50之間的關卡整數亂數
	int     choose;                            //產生1~4之間的選向排序
	float   timef;                             //時間
	float   Atime;                             //選出答案當時的系統剩餘時間 
	float   StartTime = 4.0f;                  //遊戲開始倒數時間
	public  Text StartTimeText;                //遊戲開始倒數時間Text
	//暫停*****************************************
	public static bool LevelPause = false;     //問題暫停 true:暫停 false:未暫停   
	bool   Answer = false;                     //是否已選擇答案 true:已答題 fasle:未答題
	public AudioSource ButtonMusic;            //Button音效
	public GameObject  LevelPauseButton;       //問題中途結束Button
	public GameObject  Image;                  //檔住答案Image
	public GameObject  FadeOut;                //淡出動畫

	//題目答案說明
	public Animation DescriptionAniamte;       //題目答案說明動畫
	public Text DescriptionText;               //題目答案說明Text

	// Use this for initialization
	void Start () {
		//恢復初始值
		LevelPause = false;
		Answer = false;
		LevelPauseButton.SetActive (false);
		Image.SetActive (false);
		FadeOut.SetActive (false);
		ContinousNumber = 0;
		AllScore.Level = false;     //連續答對=false

		//音樂
		if(Musicbotton.musicplay == true) music.Play();  //如果開始畫面音效被開啟,音樂播放
		else music.Pause();                              //如果開始畫面音效被關閉,音樂暫停
		music.volume = Musicbotton.MusicVo;
		time = 0.0f;
	    
		Placeyesno.Placetime =  PlayerPrefs.GetInt("Placetime1"); //讀入成就記錄(以下相同)
		Placeyesno2.Placetime =  PlayerPrefs.GetInt("Placetime2"); //讀入成就記錄(以下相同)
		Placeyesno3.Placetime =  PlayerPrefs.GetInt("Placetime3"); //讀入成就記錄(以下相同)
		Placeyesno4.Placetime =  PlayerPrefs.GetInt("Placetime4"); //讀入成就記錄(以下相同)
		Placeyesno5.Placetime =  PlayerPrefs.GetInt("Placetime5"); //讀入成就記錄(以下相同)

	}

	// Update is called once per frame
	void Update () {
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

		//===================================================================================================
		//===================================================================================================
		if(StartTime < 0.0f){
			StartTime = -0.1f;
			StartTimeText.text = "<color=#32323200>5</color>";
		//問題遊戲暫停*************************************************************************************************
		if(Input.GetKeyDown("escape") && time > 2){
			if (LevelPause) {
				LevelPause = false;
				LevelPauseButton.SetActive (false);
				Image.SetActive (false);
				if(!Answer){
				 yes1.interactable = true;  //按鈕元件 yes設為可用
				 no4.interactable  = true;  //按鈕元件 yes設為可用
				 no5.interactable  = true;  //按鈕元件 yes設為可用
				 no6.interactable  = true;  //按鈕元件 yes設為可用
				}
			} else {
				LevelPause = true;
				LevelPauseButton.SetActive(true);
				Image.SetActive (true);
				yes1.interactable = false;  //按鈕元件 yes設為不可用
				no4.interactable  = false;  //按鈕元件 yes設為不可用
				no5.interactable  = false;  //按鈕元件 yes設為不可用
				no6.interactable  = false;  //按鈕元件 yes設為不可用
			}
		} 

		//問題遊戲開始=========================================================================================
		if(!LevelPause){                            //遊戲未暫停
		
		music.UnPause(); 	                        //音樂繼續播放
		
		//減少遊戲時間
		time = time - Time.deltaTime;      
		TimeText.text = ""+(int)(time-4.0f);
		if(time-4.0f < 0.0f)TimeText.text = "0";
        //TimeTextImage
		TimeImage.fillAmount = (time - 4.0f) / 7.5f;     
		if ((time - 4.0f) >= 6.0f) TimeImage.color = new Color(0,0,0);                             //依照剩餘作答時間改變TimeTextImage的顏色 
		else if( (time - 4.0f)<6.0f && (time - 4.0f)>2.0f ) TimeImage.color = new Color(230,255,0);//依照剩餘作答時間改變TimeTextImage的顏色 
		else  TimeImage.color = new Color(255,0,0);                                                //依照剩餘作答時間改變TimeTextImage的顏色 

		//目前題目數
		NumberText.text = "題目 " + AllScore.Level1;
		if(selectlevel.select==1 && AllScore.Level1 == 5)      NumberText.text = "最後一題";
		else if(selectlevel.select==2 && AllScore.Level1 == 7) NumberText.text = "最後一題";
		else if(selectlevel.select==3 && AllScore.Level1 == 9) NumberText.text = "最後一題";
		else if(selectlevel.select==4 && AllScore.Level1 == 12)NumberText.text = "最後一題";
        
        //防止玩家等太久
		if(time<=4.0f && Answer && Atime>=6.0f) time = 0.0f;

		//顯示分數
		ScoreText.text = " " + (int)AllScore.LevelScore;  //顯示分數

		//***********************************************************************************
		//5秒玩家沒選答案,顯示答案,挑選下一題***********************************************************
		if (time <= 3) 
		{
			yes1.interactable = false; //按鈕元件 yes設為不可用
			no4.interactable = false; //按鈕元件 yes設為不可用
			no5.interactable = false; //按鈕元件 yes設為不可用
			no6.interactable = false; //按鈕元件 yes設為不可用
			if(!Answer && AllScore.Level1>=1) DescriptionAniamte.Play(); //如果未答題則播放題目答案說明動畫
			
		} //if結束


		//切到下一題(依照玩家選擇難度)

		do{
		if(selectlevel.select==1)randlevel = Random.Range(1, 221);         //(難度:學生)產生1~8之間的整數亂數
			else if(selectlevel.select==2)randlevel = Random.Range(1, 221);    //(難度:新鮮人)產生2~181之間的整數亂數
			else if(selectlevel.select==3)randlevel = Random.Range(1, 221);    //(難度:職場)產生2~251之間的整數亂數
			else if(selectlevel.select==4)randlevel = Random.Range(1, 221);    //(難度:高階)產生2~301之間的整數亂數

		}while(selectlevel.playing[randlevel] == 1);                       //關卡出現過重新選1題
		


		//如果遊戲限制時間<=0 且 已經5,7,9,12題切換到結算畫面(依照玩家選擇難度)
		if(selectlevel.select==1 && time <= 0 && AllScore.Level1>=5)       Application.LoadLevel("LastScene");  //(難度:學生)
		else if(selectlevel.select==2 && time <= 0 && AllScore.Level1>=7)  Application.LoadLevel("LastScene");  //(難度:新鮮人)
		else if(selectlevel.select==3 && time <= 0 && AllScore.Level1>=9)  Application.LoadLevel("LastScene");  //(難度:職場)
		else if(selectlevel.select==4 && time <= 0 && AllScore.Level1>=12) Application.LoadLevel("LastScene");  //(難度:高階)

		//如果遊戲限制時間<=0切換到下一題
		else if(time <= 0) 
		{
			    

				//過場音效
			    questionmusic.Play();         //播放問題音效
				//選項位置
				choose = Random.Range (1, 5); //產生1~4之間的亂數  
				Answer = false;               //未答題
				if (choose == 1) {
					//改變位置1
					yes.transform.position = new Vector3 (500.0f, 480.0f, 0.0f);
					no1.transform.position = new Vector3 (500.0f, 360.0f, 0.0f);
					no2.transform.position = new Vector3 (500.0f, 240.0f, 0.0f);
					no3.transform.position = new Vector3 (500.0f, 120.0f, 0.0f);
				} else if (choose == 2) {
					//改變位置2
					no1.transform.position = new Vector3 (500.0f, 480.0f, 0.0f);
					yes.transform.position = new Vector3 (500.0f, 360.0f, 0.0f);
					no2.transform.position = new Vector3 (500.0f, 240.0f, 0.0f);
					no3.transform.position = new Vector3 (500.0f, 120.0f, 0.0f);
				} else if (choose == 3) {
					//改變位置3
					no1.transform.position = new Vector3 (500.0f, 480.0f, 0.0f);
					no2.transform.position = new Vector3 (500.0f, 360.0f, 0.0f);
					yes.transform.position = new Vector3 (500.0f, 240.0f, 0.0f);
					no3.transform.position = new Vector3 (500.0f, 120.0f, 0.0f);
				} else if (choose == 4) {
					//改變位置4
					no1.transform.position = new Vector3 (500.0f, 480.0f, 0.0f);
					no2.transform.position = new Vector3 (500.0f, 360.0f, 0.0f);
					no3.transform.position = new Vector3 (500.0f, 240.0f, 0.0f);
					yes.transform.position = new Vector3 (500.0f, 120.0f, 0.0f);
				}	
			

				selectlevel.playing [randlevel] = 1;                             //關卡已出現

				//改變題目
				//題目1
				if (randlevel == 1) {
					Question.text = "拜占庭帝國因為遭哪國人侵擾，導致「文藝復興」開啟?";
				    CateText.text = "歷史";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "土耳其人"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "波斯人"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "埃及人"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "羅馬人"; //更改no3的test
					DescriptionText.text = "中世紀末,拜占庭帝國屢遭土耳其人侵擾，拜占庭學者逃到義大利，由於他們提倡研究希臘，羅馬古典文化，「文藝復興運動」因此揭開。";  //題目答案說明
				}
			//題目2
			else if (randlevel == 2) {
					Question.text = "文藝復興從開始到結束持續了多少年?";
				    CateText.text = "地理";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "十四世紀~十六世紀"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "十三世紀~十四世紀"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "十四世紀~十七世紀"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "十四世紀~十五世紀"; //更改no3的test
					DescriptionText.text = "指中世紀末葉起,以義大利為中心所掀起的西歐新文化，思想運動，大約自十四世紀持續到十六世紀(大約是當時中國的明朝)。";  //題目答案說明
				}
			//題目3
			else if (randlevel == 3) {
					Question.text = "文藝復興英文為「Renaissance」，是代表什麼意思?";
					CateText.text = "人文";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "再生"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "繼承";   //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "流放"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "宗教"; //更改no3的test
					DescriptionText.text = "「Renaissance」本意是再生,指「自由精神」與「人文主義」的再生。";  //題目答案說明
				}
			//題目4
			else if (randlevel == 4) {
					Question.text = "「文藝復興」的學者主要是研究哪些地區的文化?";
				    CateText.text = "歷史";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "希臘、羅馬"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "波斯、拜占庭"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "埃及、北歐"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "威尼斯、佛羅倫斯"; //更改no3的test
					DescriptionText.text = "中世紀末,拜占庭帝國屢遭土耳其人侵擾，拜占庭學者逃到義大利，由於他們提倡研究希臘，羅馬古典文化，「文藝復興運動」因此揭開。";  //題目答案說明
				}
			//題目5
			else if (randlevel == 5) {
					Question.text = "何種精神是整個「文藝復興」的推動力?";
					CateText.text = "歷史";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "人文主義"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "神學主義"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "反思主義"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "古典主義"; //更改no3的test
					DescriptionText.text = "中世紀的美德，不再被盲目接受。人們開始對許多事情發生疑問，並尋求答案。這種新的精神是「人文主義」是整個文藝復興的推動力。";  //題目答案說明
				}
			//題目6
			else if (randlevel == 6) {
				Question.text = "哪位人物是文藝復興之父?";
				CateText.text = "教育";
				GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "喬托"; //更改yes的test
				GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "羅倫佐"; //更改no1的test
				GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "馬薩奇奧"; //更改no2的test
				GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "馬基維利"; //更改no3的test
				DescriptionText.text = "喬托(Giotto di Bondone，1267-1317)是第一個把宗教裡的聖者，配上樹林景色，穿著百姓衣服的畫家。";  //題目答案說明
			}

			//題目7
			else if (randlevel == 7) {
				Question.text = "十五世紀初，佛羅倫斯出現了「孤兒之家」，什麼是「孤兒之家」?";
				CateText.text = "科技";
				GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "塵世生活"; //更改yes的test
				GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "古典生活"; //更改no1的test
				GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "未知領域"; //更改no2的test
				GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "世俗規範"; //更改no3的test
				DescriptionText.text = "天花板不高，房間大小也適中，比例仿照古希臘建築均稱調和，而且它是一個孤兒院。表示人文主義重視塵世生活及幸福的精神。";  //題目答案說明
			}

			//題目8
			else if (randlevel == 8) {
					Question.text = "「文藝復興」的繪畫的特色為?";
				CateText.text = "偉人";
				GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "明暗法、透視法"; //更改yes的test
				GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "點畫、印象派"; //更改no1的test
				GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "野獸派、立體主義"; //更改no2的test
				GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "未來派、達達主義"; //更改no3的test
				DescriptionText.text = "明暗法:通過強烈明暗對比的基調以塑造三維立體的效果。\n透視法:立體三維空間的形象表現在二維平面上的繪畫方法。\n";  //題目答案說明
			}

			//題目9
			else if (randlevel == 9) {
				Question.text = "文藝復興運動的中心在哪座城市?";
				CateText.text = "偉人";
				GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "佛羅倫斯"; //更改yes的test
				GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "羅馬"; //更改no1的test
				GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "威尼斯"; //更改no2的test
				GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "塔斯卡尼"; //更改no3的test
				DescriptionText.text = "第三代「僭主」洛倫佐·德·麥第奇治下，佛羅倫斯進入黃金時代，麥第奇家族的政治資本就是巨大的聲望，成為文藝復興的典範。";  //題目答案說明
			}

				//題目10
				else if (randlevel == 10) {
					Question.text = "下列哪個人物不是「畫壇三傑」?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "薄伽丘"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "達文西"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no3的test
					DescriptionText.text = "喬凡尼·薄伽丘(1313－1375），文藝復興時期的義大利作家、詩人，以故事集《十日談》留名後世。";  //題目答案說明
				}

				//題目11
				else if (randlevel == 11) {
					Question.text = "薄伽丘所著的短篇小說「十日談」，請問十日指的是什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "十個日子"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "十次冬天"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "十個人"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "十年"; //更改no3的test
					DescriptionText.text = "《十日談》內容是講述七位女性和三位男性到山上躲避瘟疫，大家決定每人每天講一個故事來渡過酷熱的日子。";  //題目答案說明
				}

				//題目12
				else if (randlevel == 12) {
					Question.text = "薄伽丘原本要將《十日談》完全燒毀，是在誰的勸說下得以阻止?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "佩脫拉克"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "達文西"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "莎士比亞"; //更改no3的test
					DescriptionText.text = "《十日談》的「第三日」描述了一位猛男馬賽多如何以肉體滿足了修道院的修女們，因此薄伽丘備受教會的打壓，使他一度想燒燬他的著作。";  //題目答案說明
				}

				//題目13
				else if (randlevel == 13) {
					Question.text = "《十日談》共有幾位男性和女性?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "7、3"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "5、5"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "6、4"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "1、9"; //更改no3的test
					DescriptionText.text = "《十日談》內容是講述七位女性和三位男性到山上躲避瘟疫，大家決定每人每天講一個故事來渡過酷熱的日子。";  //題目答案說明
				}

				//題目14
				else if (randlevel == 14) {
					Question.text = "文藝復興時期北部中心在威尼斯，當時的畫家是受到何種繪畫技巧得影響?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "帆布畫油畫"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "蛋彩畫"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "油布畫素描"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "石板刻字"; //更改no3的test
					DescriptionText.text = "當時的義大利畫家是在木板上畫蛋彩畫，接觸到法國在帆布畫油畫的新技法因此轉變為色彩明朗豔麗、光線柔和的特色。";  //題目答案說明
				}

				//題目15
				else if (randlevel == 15) {
					Question.text = "哪位不是文藝復興時期在「威尼斯」主要畫家?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "達文西"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "貝利尼"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "吉奧喬尼"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "提香"; //更改no3的test
					DescriptionText.text = "「達文西」主要活動的地區為佛羅倫斯和羅馬。";  //題目答案說明
				}

				//題目16
				else if (randlevel == 16) {
					Question.text = "「李奧納多·達文西」這個名字的意義為何?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "皮耶羅先生之子"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "不可遏制的好奇心"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "傑出之人"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "文藝復興的人物"; //更改no3的test
					DescriptionText.text = "「李奧納多·達文西」是公證員瑟皮耶羅·達文西和農民婦女卡特琳娜的非婚生子女。";  //題目答案說明
				}

				//題目17
				else if (randlevel == 17) {
					Question.text = "下列何者不是「李奧納多·達文西」的作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "創造亞當"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "蒙娜麗莎"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "最後的晚餐"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "維特魯威人"; //更改no3的test
					DescriptionText.text = "《創造亞當》是米開朗基羅創作的西斯廷禮拜堂天頂畫《創世紀》的一部分。";  //題目答案說明
				}

				//題目18
				else if (randlevel == 18) {
					Question.text = "「達文西」沒有概念性發明哪一樣作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "馬車"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "直升機"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "坦克"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "機關槍"; //更改no3的test
					DescriptionText.text = "達文西因為技術上的獨創性具有超越當時的廣泛構思，其中著名的概念性發明有：直升機、機關槍、機器人、坦克、太陽能聚焦使用、計算器。";  //題目答案說明
				}

				//題目19
				else if (randlevel == 19) {
					Question.text = "「大衛像」置於佛羅倫斯的市政廳舊宮入口是代表什麼的精神?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "不畏強權"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "自由平等"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "戰爭勝利"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "宗教統治"; //更改no3的test
					DescriptionText.text = "人們對雕像的放置地點進行了討論，原計劃放在教堂頂樓，最終人們決定將其置於佛羅倫斯，取代多納泰羅的一尊銅像，以代表弗洛倫薩不畏強權的精神。";  //題目答案說明
				}

				//題目20
				else if (randlevel == 20) {
					Question.text = "「大衛像」原本的作者是誰?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "多那太羅"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "達文西"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no3的test
					DescriptionText.text = "1464年「多那太羅」簽約完成一座大衛像但1466年，多納泰羅去世，留下了未完成的雕像，之後由米開朗基羅完成這項工作。";  //題目答案說明
				}

				//題目21
				else if (randlevel == 21) {
					Question.text = "「達文西」提出何種概念，轉變為今日的變速箱?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "無段連續自動變速箱"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "蒸氣壓縮馬達"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "十字轉盤樞紐"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "螺旋氣壓工程"; //更改no3的test
					DescriptionText.text = "1490年，達文西將無段連續自動變速箱概念繪製成草圖。今日，達文西的變速概念以現代化形式實際使用在汽車上。";  //題目答案說明
				}

				//題目22
				else if (randlevel == 22) {
					Question.text = "達文西的發明中哪一項為第一個「機械計算機」的齒輪裝置?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "潛水艇"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "坦克車"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "巨型弩砲"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "降落傘"; //更改no3的test
					DescriptionText.text = "「達文西」的筆記中也包含了軍事設計:機關槍、武裝坦克車、軍用降落傘、潛水艇，其中潛水艇被詮譯為第一個機械計算機的齒輪裝置。";  //題目答案說明
				}

				//題目23
				else if (randlevel == 23) {
					Question.text = "「達文西」策劃了數部飛行機器，但因為什麼原因而失敗?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "旋轉"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "重量"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "材質"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "動力"; //更改no3的test
					DescriptionText.text = "由於著迷飛行現象，策劃了數部飛行機器，包括了以4個人力運作的直昇機，但因機體本身亦會旋轉故無法作用。";  //題目答案說明
				}

				//題目24
				else if (randlevel == 24) {
					Question.text = "「達文西」寫字特色為何?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "鏡像反寫"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "顛倒慢寫"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "左右雙寫"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "由左至右"; //更改no3的test
					DescriptionText.text = "達文西終其一生每天都做筆記，並以個人獨特的鏡像反寫字書寫。儘管大多數人認為達文西是為了保守秘密，但比較合理的看法則是鏡像反寫才合乎左撇子書寫的天性。";  //題目答案說明
				}

				//題目25
				else if (randlevel == 25) {
					Question.text = "《最後的晚餐》這幅畫共有多少人?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "13人"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "12人"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "11人"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "10人"; //更改no3的test
					DescriptionText.text = "《最後的晚餐》壁畫取材自基督教聖經馬太福音第26章，描繪耶穌在遭羅馬兵逮捕的前夕和十二宗徒共進最後一餐。";  //題目答案說明
				}

				//題目26
				else if (randlevel == 26) {
					Question.text = "《蒙娜麗莎》是因為何種原因而被世人所知?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "失竊"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "畫中的女人"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "達文西所畫"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "國王喜愛"; //更改no3的test
					DescriptionText.text = "《蒙娜麗莎》被在羅浮宮內擔任油漆匠的佩魯賈竊出博物館，物館祭出高額懸賞金。由於持續沒有畫作的下落，在各家報紙的報導下，《蒙娜麗莎》逐漸有了知名度。";  //題目答案說明
				}

				//題目27
				else if (randlevel == 27) {
					Question.text = "《最後的晚餐》達文西共花了幾年才完成?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "23年"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "20年"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "3年"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "15年"; //更改no3的test
					DescriptionText.text = "《最後的晚餐》的起草圖，達文西至少用了二十年的時間，真正開始繪畫，則用了三年時間。";  //題目答案說明
				}

				//題目28
				else if (randlevel == 28) {
					Question.text = "《聖母像》是誰的作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "達文西"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "多那太羅"; //更改no3的test
					DescriptionText.text = "拉斐爾最著名的，就是他的聖母像。他的聖母寓崇高於平凡，是平民式的母親，純樸善良和藹可親，充滿母愛與人情味。";  //題目答案說明
				}

				//題目29
				else if (randlevel == 29) {
					Question.text = "拉斐爾曾在梵諦岡宮畫壁畫，以神學、哲學、法學和哪一項為內容?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "詩歌"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "文學"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "教會"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "聖經"; //更改no3的test
					DescriptionText.text = "拉斐爾與教皇、學者們交換意見許久以後，決定依據詩人德拉‧ 欣雅杜爾的詩來配畫，以歌頌神學、哲學、詩歌、法學為內容。";  //題目答案說明
				}

				//題目30
				else if (randlevel == 30) {
					Question.text = "拉斐爾的四幅畫中神學的「聖禮之爭」是代表什麼意思?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "上帝的參與"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "人類的戰爭"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "思想的改革"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "文化的信仰"; //更改no3的test
					DescriptionText.text = " 拉斐爾透過不同時間中人物的匯集，表達出神學與教義之成形，而這整個歷史過程，上帝都有參與。";  //題目答案說明
				}

				//題目31
				else if (randlevel == 31) {
					Question.text = "拉斐爾的四幅畫中哲學的「雅典學院」是代表什麼意思?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "啟示的真理"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "智慧的改革"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "經濟的繁榮"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "繪畫的技巧"; //更改no3的test
					DescriptionText.text = "表達拉斐爾渴望走進這人文薈萃的場所，參與進神聖的知識殿堂—從數學到音樂到哲學到科學—一切的一切都是如此和諧，如此神聖、如此有秩序。";  //題目答案說明
				}

				//題目32
				else if (randlevel == 32) {
					Question.text = "拉斐爾的四幅畫中詩歌的「帕拿巴斯山」是代表什麼意思?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "藝術的保護"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "上帝的悲憐"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "民族的團結"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "過去的錯誤"; //更改no3的test
					DescriptionText.text = "拉斐爾畫「帕拿巴斯山」，以藝術文學保護神阿波羅為中心，環繞他的為分管文學、藝術、科學的九位文藝女神和古今詩人。";  //題目答案說明
				}

				//題目33
				else if (randlevel == 33) {
					Question.text = "拉斐爾的四幅畫中法學的「三德」不包括下列哪一個?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "博愛"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "真理"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "權力"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "節制"; //更改no3的test
					DescriptionText.text = "拉斐爾畫「三德像」，三德包括真理「女人看鏡子」、權力「腳伏獅子，手拿代表法律的樹枝」、節制「手拿繩索看天」。";  //題目答案說明
				}
					
				//題目34
				else if (randlevel == 34) {
					Question.text = "拉斐爾的作品「西斯汀聖母」，是要表現什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "母愛"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "和諧"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "同情"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "感情"; //更改no3的test
					DescriptionText.text = "西斯汀聖母不同於過去天倫之樂型的《聖母像》，拉斐爾讓西斯丁聖母緩緩向人走來，表現出聖母不僅只是絕對美的觀念、更是可以讓人親近依靠的聖母。";  //題目答案說明
				}

				//題目35
				else if (randlevel == 35) {
					Question.text = "「米開朗基羅」為何是畫壇三傑中代表衝突與矛盾?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "支持者"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "繪畫風格"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "家庭"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "學歷"; //更改no3的test
					DescriptionText.text = "米開朗基羅一方面支持佛羅倫斯走向市民社會，但他的藝術支持者，卻是屢屢破壞市民社會的教皇。";  //題目答案說明
				}

				//題目36
				else if (randlevel == 36) {
					Question.text = "「大衛像」是引用聖經的哪一則故事?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "哥利亞的戰鬥"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "所羅門的事蹟"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "耶利米的嘲笑"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "巴力的先知們"; //更改no3的test
					DescriptionText.text = "米開朗基羅用大衛戰勝巨人哥利亞的聖經故事，暗喻動盪不安的佛羅倫斯面臨外來強敵。";  //題目答案說明
				}

				//題目37
				else if (randlevel == 37) {
					Question.text = "米開朗基羅的作品「聖母悼子」，是暗喻著什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "婦女的貞潔"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "母親的偉大"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "孩子的成長"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "少女的哭泣"; //更改no3的test
					DescriptionText.text = "「貞潔的婦女會比較容易保持青春，沒有淫亂鑽進心胸的婦女，身體是不會受多大影響的，我也相信，上帝會用這樣的方式讓她證明自己的貞潔。」";  //題目答案說明
				}

				//題目38
				else if (randlevel == 38) {
					Question.text = "米開朗基羅的作品「創世紀」，是暗喻著什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "毀滅的命運"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "母親的偉大"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "四面受敵"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "人文主義"; //更改no3的test
					DescriptionText.text = "米開朗基羅透過創世紀，幾乎是控訴上帝毀滅與嚴厲的屬性，他宣告毀滅的命運，而不是愛的福音。上帝與亞當的手若即若離，這已暗示出人類未來的命運。";  //題目答案說明
				}

				//題目39
				else if (randlevel == 39) {
					Question.text = "米開朗基羅雕刻了夜、晝、晨、昏四個人身像，是表現什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "鬱悶不平的心情"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "新的希望"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "四季的交替"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "人文主義"; //更改no3的test
					DescriptionText.text = "米開朗基羅帶領人民保衛佛羅倫斯不陷入教皇與德皇的勾結侵略，結果卻失敗了，他授命雕刻麥第奇教堂。這再一次是藝術被迫臣服於政治。";  //題目答案說明
				}

				//題目40
				else if (randlevel == 40) {
					Question.text = "米開朗基羅的「最後的審判」主題是什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "死亡"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "希望"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "恨意"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "人文主義"; //更改no3的test
					DescriptionText.text = "「最後的審判」主題呈現死亡、面對審判的絕望與痛苦。米開朗基羅透過此主題，反映了羅馬在1527年的大掠奪之後，瀰漫在社會上灰暗不安的氣氛。";  //題目答案說明
				}

				//題目41
				else if (randlevel == 41) {
					Question.text = "「藝術是否有罪」的由來為何?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "雕刻人體"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "思想自由"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "開放言論"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "批判聖經"; //更改no3的test
					DescriptionText.text = "米開朗基羅的藝術品，最擅長的就是雕刻人體，尤其是男性裸體，他很喜愛男性裸體可以呈現出來的力與美。但也因此常遭「道德淪喪」的非議。";  //題目答案說明
				}

				//題目42
				else if (randlevel == 42) {
					Question.text = "「米開朗基羅」有生之年的最後三幅雕刻都跟何者有關?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "十字架事件"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "上帝的悲憫"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "世界之苦罪"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "上帝相遇相識"; //更改no3的test
					DescriptionText.text = "米開朗基羅晚年只著重呈現「哀傷」，這哀傷仍與基督受難有關，是出自米開朗基羅心意誠摯的雕琢。";  //題目答案說明
				}

				//題目43
				else if (randlevel == 43) {
					Question.text = "下列何者不是「文壇三傑」之一?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "安徒生"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "但丁"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "佩脫拉克"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "薄伽丘"; //更改no3的test
					DescriptionText.text = "在文學界，義大利是人文主義文學的發源地，但丁、佩脫拉克、薄伽丘是文藝復興的先驅，被稱為「文藝復興三巨星」，也稱為「文壇三傑」。";  //題目答案說明
				}

				//題目44
				else if (randlevel == 44) {
					Question.text = "但丁曾在詩中說自己是在哪個星座下誕生?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "雙子座"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "巨蟹座"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "天蠍座"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "摩羯座"; //更改no3的test
					DescriptionText.text = "但丁生於1265年，出生日期不清，按他自己在詩中的說法「生在雙子座下」，應該是5月下旬或6月上旬。";  //題目答案說明
				}

				//題目45
				else if (randlevel == 45) {
					Question.text = "但丁的作品基本是以「何種語言」寫作?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "托斯卡納方言"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "西南官話"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "喬迪方言"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "斯拉夫語"; //更改no3的test
					DescriptionText.text = "但丁的作品基本上是以義大利托斯卡納方言寫作，由拉丁語演變至現在的形式，它成為義大利各地區的官方語言，逐步形成現在的標準義大利語。";  //題目答案說明
				}

				//題目46
				else if (randlevel == 46) {
					Question.text = "《神曲》沒有寫到但丁到哪個地方遊歷?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "天域"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "地獄"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "煉獄"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "天堂"; //更改no3的test
					DescriptionText.text = "《神曲》（La Divina Commedia）描述但丁在地獄、煉獄及天堂遊歷的經過。";  //題目答案說明
				}

				//題目47
				else if (randlevel == 47) {
					Question.text = "《神曲》中後半段但丁的引路人從「維吉爾」變為何人?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "貝緹麗彩"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "喬萬尼"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "傑弗里"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "但丁"; //更改no3的test
					DescriptionText.text = "貝緹麗彩是一位佛羅倫薩女士，維吉爾因為是一個異教徒，維吉爾無法進入天堂。貝緹麗彩是幸福和愛的化身，正如她的名字那樣，自然的成為了但丁的嚮導。";  //題目答案說明
				}

				//題目48
				else if (randlevel == 48) {
					Question.text = "《神曲》的地獄篇中描述地獄共分幾層?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "9層"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "10層"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "18層"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "7層"; //更改no3的test
					DescriptionText.text = "地獄形似一個上寬下窄的漏斗，共9層，靈薄獄、貪色、貪食、貪婪、憤怒、信奉邪教、強姦、欺詐、背叛等九層。";  //題目答案說明
				}

				//題目49
				else if (randlevel == 49) {
					Question.text = "《神曲》中冥界的判官為何人?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "米諾斯米"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米諾陶"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "米諾隆爾"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "諾克里特"; //更改no3的test
					DescriptionText.text = "但丁和維吉爾來到第一層和第二層的交界，並見到冥界的判官米諾斯（Minos），生前為克里特國王，執法嚴明，死後因而成為冥界判官。";  //題目答案說明
				}

				//題目50
				else if (randlevel == 50) {
					Question.text = "七宗罪中的「貪婪」和「忌妒」差別在於?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "物質"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "欲望"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "罪惡"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "滿足"; //更改no3的test
					DescriptionText.text = "嫉妒跟貪婪一樣，是一種因為不能滿足的欲望而產生的罪惡。貪婪通常跟物質財產有關，而嫉妒則跟其他方面有關，例如愛情，或他人的成功。";  //題目答案說明
				}

				//題目51
				else if (randlevel == 51) {
					Question.text = "誰被稱為「人文主義之父」?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "佩脫拉克"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "但丁"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "薄伽丘"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "達文西"; //更改no3的test
					DescriptionText.text = "佩脫拉克為了搜尋拉丁語寫成的經典和手稿，他不惜穿梭於法國、德國、義大利和西班牙。隨著《阿非利加》的出爐成為了歐洲的一個名人亦被視為人文主義之父。";  //題目答案說明
				}

				//題目52
				else if (randlevel == 52) {
					Question.text = "逃避現實、無責任心及浪費時間是「七宗罪」中的哪一項描述?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "懶惰"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "傲慢"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "貪婪"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "嫉妒"; //更改no3的test
					DescriptionText.text = "懶惰被宣告為有罪是因為：\n1.其他人需更努力工作以填補缺失。\n2.該做的事情還沒有做好，對自己是百害而無一利。";  //題目答案說明
				}

				//題目53
				else if (randlevel == 53) {
					Question.text = "「七宗罪」中的哪一項是最為嚴重的惡行?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "傲慢"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "貪婪"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "嫉妒"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "懶惰"; //更改no3的test
					DescriptionText.text = "傲慢被認為是七宗罪中最原始，最嚴重的一項，因為撒旦擁有統治世界的權力，而濫用權力正是一種傲慢。";  //題目答案說明
				}

				//題目54
				else if (randlevel == 54) {
					Question.text = "形成「文藝復興」的主要原因為何?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "經濟崩潰"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "人民思想"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "國王命令"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "國家戰爭"; //更改no3的test
					DescriptionText.text = "許多繁榮的年代，商人迅速的將所賺取的財富再度進行投資以求更多金錢。然而在貧困的十四世紀，財富較少被投入到頗具前景的投資機會中，反而是注入到文化與藝術的層面。";  //題目答案說明
				}

				//題目55
				else if (randlevel == 55) {
					Question.text = "《聖經》中誰化身為「伊甸園之蛇」誘騙人類?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "撒旦"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "利維坦"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "瑪門"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "貝爾芬格"; //更改no3的test
					DescriptionText.text = "上帝明令人類不可食用智慧之樹的果實，撒旦為了摧毀上帝的創造物，化為蛇引誘人類犯罪，導致人類被逐出伊甸園，從此必須忍受寒冷與飢餓。";  //題目答案說明
				}

				//題目56
				else if (randlevel == 56) {
					Question.text = "「偉大的洛倫佐」是誰的稱號?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "洛倫佐"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "皮耶羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "喬凡尼"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "科西莫"; //更改no3的test
					DescriptionText.text = "洛倫佐透過家族事業和議會贊助那時期的藝術家，直接影響文藝復興的發展，締造出文藝復興的黃金時代，後被稱為「偉大的洛倫佐」。";  //題目答案說明
				}

				//題目57
				else if (randlevel == 57) {
					Question.text = "《創世紀》和《最後的審判》這兩幅畫被放置在哪一間教堂?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "西斯汀小堂"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "聖母百花大教堂"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "新聖母大殿"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "聖伯多祿大殿"; //更改no3的test
					DescriptionText.text = "西斯汀小堂是一座位於梵蒂岡宗座宮殿內的天主教小堂，緊鄰聖伯多祿大殿，以米開朗基羅所繪《創世紀》穹頂畫，及壁畫《最後的審判》而聞名。";  //題目答案說明
				}

				//題目58
				else if (randlevel == 58) {
					Question.text = "「黑死病」是14世紀的大瘟疫，它的命名由來為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "黑死病的恐懼"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "教會的無能"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "皮膚變黑"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "黑鼠散播"; //更改no3的test
					DescriptionText.text = "丹麥的年鑑第一次用「黑色的」來描述這一事件，不只是因為患者晚期的皮膚會因皮下出血變黑，更確切的是指此事件給人帶來灰暗可怕的黑色恐怖陰霾。";  //題目答案說明
				}

				//題目59
				else if (randlevel == 59) {
					Question.text = "洛倫佐因為跟誰合作，導致跟教廷的關係發生衝突?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "米蘭"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "威尼斯"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "羅馬"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "佛羅倫斯"; //更改no3的test
					DescriptionText.text = "美第奇家族的商業帝國逐漸地在腐蝕當中，洛倫佐繼續與米蘭維持同盟合作，但與教廷的關係卻開始變質。接著在1478年，羅馬教皇與帕齊家族聯盟，嘗試刺殺洛倫佐，最後這個陰謀失敗了。";  //題目答案說明
				}

				//題目60
				else if (randlevel == 60) {
					Question.text = "下列何者是文藝復興之後，才變成義大利文學所使用的語言?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "義大利語"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "拉丁文"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "法文"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "普羅旺斯語"; //更改no3的test
					DescriptionText.text = "在文藝復興之前文學家大多使用拉丁文來寫作，直到13世紀大量的義大利文學家開始使用義大利語，使得義大利語變為母語。";  //題目答案說明
				}

				//題目61
				else if (randlevel == 61) {
					Question.text = "美第奇家族在佛羅倫斯主要的競爭家族為何?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "奧比奇家族"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "波吉亞家族"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "盧森家族"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "奧狄托雷家族"; //更改no3的test
					DescriptionText.text = "奧比奇家族是文藝復興時期來自阿雷佐的貴族家族，執意推行新的嚴厲控管、壓制貧民，雖獲得美第奇提供的大量貸款以減低稅收，卻也使美第奇家族的勢力大增，幾乎可與爭雄匹敵。";  //題目答案說明
				}

				//題目62
				else if (randlevel == 62) {
					Question.text = "在羅倫佐之後，誰也成為文藝復興的典範人物?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "伊莎貝拉·埃斯特"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "弗朗切斯科·奧比奇"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "切薩雷·波吉亞"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "德拉·羅維雷"; //更改no3的test
					DescriptionText.text = "伊莎貝拉是曼圖亞的侯爵夫人，也是義大利文藝復興中的女性領袖，在文化與政治上起著無與倫比的作用。也被頌揚為「世界第一夫人」。";  //題目答案說明
				}

				//題目63
				else if (randlevel == 63) {
					Question.text = "早期文藝復興音樂作品主要以什麼作為和音?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "第三間隔"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "不同音高"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "同時發聲"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "橫向"; //更改no3的test
					DescriptionText.text = "早期文藝復興音樂作品主要是對第三間隔的依靠作為和音。從12世紀開始的複調音樂在整個14世紀變得更為細緻而不依靠聲音的表述。15世紀初的音樂趨向簡單，聲音致力於平滑。";  //題目答案說明
				}

				//題目64
				else if (randlevel == 64) {
					Question.text = "文藝復興全盛期主要是從什麼時候開始?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "最後的晚餐"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "虛榮戰火"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "佛利之歌"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "聖母百花大教堂"; //更改no3的test
					DescriptionText.text = "這一時期起始於達芬奇《最後的晚餐》繪成、洛倫佐·德·美第奇逝世的1490年代，結束於1527年的羅馬之劫。";  //題目答案說明
				}

				//題目65
				else if (randlevel == 65) {
					Question.text = "哪一場「戰爭」結束了文藝復興的全盛期?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "羅馬之劫"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "虛榮戰火"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "維亞納戰爭"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "倫巴底戰爭"; //更改no3的test
					DescriptionText.text = "羅馬之劫發生於1527年5月6日，是羅馬皇帝查理五世屬下的軍隊判變後，部隊陷入無紀律的放任狀態：約1000個教宗首都及聖殿的衛兵被殘酷地處決，然後開始了搶掠。教堂、修道院以及高級神職人員的宮廷被破壞及搜掠。";  //題目答案說明
				}

				//題目66
				else if (randlevel == 66) {
					Question.text = "「波吉亞家族」發跡於何處?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "瓦倫西亞"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "威尼斯"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "維也納"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "米蘭"; //更改no3的test
					DescriptionText.text = "波吉亞家族發跡於西班牙的瓦倫西亞，據家族聲稱，他們是阿拉貢王室的後代。家族第一位發跡的人是阿方索·德·博爾哈。";  //題目答案說明
				}

				//題目67
				else if (randlevel == 67) {
					Question.text = "「教皇子午線」是哪兩個國家決定的?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "西班牙、葡萄牙"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "義大利、波斯"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "英國、法國"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "羅馬、佛羅倫斯"; //更改no3的test
					DescriptionText.text = "「教皇子午線」是地理大發現時代早期，兩大航海強國西班牙和葡萄牙在教皇亞歷山大六世的調解下，於1494年6月7日在西班牙卡斯蒂利亞簽訂的一份瓜分新世界的分界線。";  //題目答案說明
				}

				//題目68
				else if (randlevel == 68) {
					Question.text = "文藝復興的義大利政治上是四分五裂，請問哪一個地區是較為弱勢的?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "維也納"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "羅馬"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "那不勒斯"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "米蘭"; //更改no3的test
					DescriptionText.text = "15世紀正經歷著文藝復興洗禮的義大利是一個經濟繁榮發達，文化輝煌燦爛的富庶之地，然而它在政治上卻是四分五裂。羅馬教廷、威尼斯、佛羅倫斯、那不勒斯和米蘭是五個旗鼓相當的地區。";  //題目答案說明
				}

				//題目69
				else if (randlevel == 69) {
					Question.text = "被稱為「教宗國」的是哪一個地區?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "羅馬"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "佛羅倫斯"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "米蘭"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "威尼斯"; //更改no3的test
					DescriptionText.text = "自從天主教大分裂結束，教廷從亞維儂遷回羅馬之時起，它就不遺餘力的試圖將在教皇宗主權之下的所有義大利土地置於教廷直接控制之下。";  //題目答案說明
				}

				//題目70
				else if (randlevel == 70) {
					Question.text = "「僭主」是一種君主制的變體，指的是透過什麼來獲政權?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "聲望"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "世襲"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "選舉"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "宗教"; //更改no3的test
					DescriptionText.text = "「僭主」又譯為暴君，是一種君主制的變體。希臘時代認為，不通過世襲、傳統或是合法民主選舉程序，憑藉個人的聲望與影響力，獲得權力，這樣的統治者被稱為僭主。";  //題目答案說明
				}

				//題目71
				else if (randlevel == 71) {
					Question.text = "「巴洛克風格」是在文藝復興後誕生的一種藝術風格，「巴洛克」是什麼意思?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "俗麗凌亂"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "富貴典雅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "莊嚴鄭重"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "雜亂不堪"; //更改no3的test
					DescriptionText.text = "巴洛克一詞的來源意思是不規則(變形)的珠子。作為形容詞，此字有「俗麗凌亂」之意。歐洲人最初用這個詞指「缺乏古典主義均衡特性的作品」。";  //題目答案說明
				}

				//題目72
				else if (randlevel == 72) {
					Question.text = "「巴洛克風格」以強調什麼為特點?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "運動"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "平衡"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "音樂"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "宗教"; //更改no3的test
					DescriptionText.text = "巴洛克風格以強調「運動」與「轉變」為特點，尤其是身體和情緒方面的，同時，巴洛克也是對矯飾主義的一種反動。";  //題目答案說明
				}

				//題目73
				else if (randlevel == 73) {
					Question.text = "「巴洛克時期」慣指的時間是在什麼時候?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "17世紀~18世紀"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "15世紀~16世紀"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "13世紀~15世紀"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "19世紀~20世紀"; //更改no3的test
					DescriptionText.text = "在歐洲文化史中，「巴洛克」慣指的時間是17世紀以及18世紀上半葉（約1600年-1750年），但年份並不代表絕對的藝術風格，特別是建築與音樂。";  //題目答案說明
				}

				//題目74
				else if (randlevel == 74) {
					Question.text = "歐洲文化「除舊布新」，在各方面都有重大的改變與成就，主要跟什麼有關?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "資產階級興起"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "宗教權力擴大"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "戰爭減少"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "軍權獨立"; //更改no3的test
					DescriptionText.text = "由於資產階級興起，君主政治逐漸獨立於宗教之外以及民主思想萌芽等原因，讓歐洲的思想開始有了轉變。";  //題目答案說明
				}

				//題目75
				else if (randlevel == 75) {
					Question.text = "「巴洛克時期」的繪畫跟「文藝復興時期」最大的差別在於巴洛克畫家們更喜歡描繪?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "衝突激烈"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "男女情愛"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "宗教禮俗"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "市民生活"; //更改no3的test
					DescriptionText.text = "巴洛克繪畫其作品特徵為富有豐富而濃重的色彩和大面積的陰影。與之前的文藝復興繪畫不同的是，巴洛克畫家們更喜歡描繪衝突激烈的場景。";  //題目答案說明
				}

				//題目76
				else if (randlevel == 76) {
					Question.text = "「巴洛克時期」跟「文藝復興時期」兩者的繪畫風格有差，但最常用的繪畫技巧為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "明暗法"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "素描法"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "印象法"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "立體主義"; //更改no3的test
					DescriptionText.text = "明暗法是文藝復興時期發展出的繪畫技巧，通過強烈明暗對比以塑造三維立體的效果，此技巧到巴洛克時期依然受到愛戴。";  //題目答案說明
				}

				//題目77
				else if (randlevel == 77) {
					Question.text = "「文藝復興」時期的音樂因為受到什麼影響，而朝向內心的抒發為特色?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "人文主藝"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "宗教思想"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "市民生活"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "托斯卡尼"; //更改no3的test
					DescriptionText.text = "在中世紀「新藝術」的基礎上，更加追求人性的解放與對人的內心情感的抒發與表達。這時的音樂家在人文主義思潮的推動下，對復調音樂進行了發展和變革。";  //題目答案說明
				}

				//題目78
				else if (randlevel == 78) {
					Question.text = "「羅馬樂派」是「文藝復興」時期成立的一個樂派，其特色是什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "無伴奏合唱"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "合音"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "管弦樂伴奏"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "前奏曲"; //更改no3的test
					DescriptionText.text = "此時期的一個專門創作服務於宗教作品的樂派，以無伴奏合唱的形式為主。代表人物有帕萊斯特里納、G.M.納尼諾、F.索里亞諾等。";  //題目答案說明
				}

				//題目79
				else if (randlevel == 79) {
					Question.text = "「威尼斯樂派」是「文藝復興」時期成立的一個樂派，其特色是什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "寬廣宏大"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "無伴奏合唱"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "合音"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "管弦樂伴奏"; //更改no3的test
					DescriptionText.text = "在1530-1620年間的一個器樂樂派，其特點是音響氣勢寬廣宏大、對比效果鮮明。創作內容有銅管樂與弦樂的重奏曲。";  //題目答案說明
				}

				//題目80
				else if (randlevel == 80) {
					Question.text = "「尼德蘭樂派」是「文藝復興」時期成立的一個樂派，其特色是什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "宗教音樂"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "寬廣宏大"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "無伴奏合唱"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "前奏曲"; //更改no3的test
					DescriptionText.text = "主要音樂活動在尼德蘭的一批音樂家。創作內容多為彌撒曲與經文歌等宗教音樂，也有世俗音樂。代表人物有迪費、若斯坎、班舒瓦、奧克岡等。";  //題目答案說明
				}

				//題目81
				else if (randlevel == 81) {
					Question.text = "「文藝復興」時期因為什麼的技術得到改善使得音樂的傳播更加便利?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "五線譜"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "樂器"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "人聲訓練"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "政府支持"; //更改no3的test
					DescriptionText.text = "這一時期五線譜已得到完善，印刷術也運用到曲譜上，這都使音樂的傳播更加便利和廣泛。";  //題目答案說明
				}

				//題目82
				else if (randlevel == 82) {
					Question.text = "樂譜常用的「五線譜」的前身是什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "紐姆符"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "記譜法"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "葛利果聖歌"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "古琴譜"; //更改no3的test
					DescriptionText.text = "在西方中世紀早期人們使用紐姆符（neumes）來記錄樂譜。紐姆譜以橫線為標準，只能通過符號表示音調高低，但不能準確表示音值的長短。當時只能通過這些助記符記錄音樂。";  //題目答案說明
				}

				//題目83
				else if (randlevel == 83) {
					Question.text = "音符是用來標識音的符號，「不是」用以下哪一項組成?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "符身"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "符頭"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "符杆"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "符尾"; //更改no3的test
					DescriptionText.text = "音符是用來標識音的符號，通常由符頭，符杆，符尾三個部分組成。不同音符所表示的音的長短比例稱之為時值。";  //題目答案說明
				}

				//題目84
				else if (randlevel == 84) {
					Question.text = "「紐碼記譜法」有異於現在的「記譜法」，主要是哪部分表達不清楚?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "節奏"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "音高"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "音程"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "音調"; //更改no3的test
					DescriptionText.text = "紐碼記譜法有異於現在的記譜法，從譜面大致知道旋律的音高或音程，但對節奏則很不清楚。";  //題目答案說明
				}

				//題目85
				else if (randlevel == 85) {
					Question.text = "人們常說的「彌撒」是什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "感恩祭結束"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "禮拜的時間"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "吃飯的時間"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "睡覺的時間"; //更改no3的test
					DescriptionText.text = "「彌撒」一詞乃是源自拉丁文 missa。在羅馬禮儀的傳統中，感恩祭結束的時候，執事或主祭會以 \"lte, missa est\" 來作彌撒結束的派遣用詞。";  //題目答案說明
				}

				//題目86
				else if (randlevel == 86) {
					Question.text = "「日課」是什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "吟唱的時間"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "禮拜的時間"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "吃飯的時間"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "睡覺的時間"; //更改no3的test
					DescriptionText.text = "聖歌所吟唱的時間分為日課與彌撒兩大類。以三個小時為單位，將一天劃分為八個部分。分為朝課、朝讚、早課、第三時課、第六時課、午時課、晚課與晚禱。";  //題目答案說明
				}

				//題目87
				else if (randlevel == 87) {
					Question.text = "「巴洛克音樂」的強調特點是?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "極盡奢華"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "低調奢華"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "誇張動態"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "平靜風雅"; //更改no3的test
					DescriptionText.text = "巴洛克音樂的特點是極盡奢華，加入大量裝飾性的音符。節奏強烈、短促而律動，旋律精緻。複調音樂仍然佔據主導地位，大小調取代了教會調式，同時主調音樂也在蓬勃發展。";  //題目答案說明
				}

				//題目88
				else if (randlevel == 88) {
					Question.text = "哪一項「表演藝術」在「巴洛克時期」的威尼斯開始發展?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "歌劇"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "神劇"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "協奏曲"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "奏鳴曲"; //更改no3的test
					DescriptionText.text = "歌劇在威尼斯快速興起，藉著音樂和戲劇的結合將情感抒發到最高點。音樂創作從此步入了一個蓬勃發展的階段。";  //題目答案說明
				}

				//題目89
				else if (randlevel == 89) {
					Question.text = "「巴洛克時期」開始發展的「歌劇」是什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "表演藝術"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "演唱方式"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "音樂風格"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "繪畫技巧"; //更改no3的test
					DescriptionText.text = "歌劇主要或完全以歌唱和音樂來交代和表達劇情的戲劇，是唱出來而不是說出來的戲劇。";  //題目答案說明
				}

				//題目90
				else if (randlevel == 90) {
					Question.text = "「歌劇」的「代表字」為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "Opera0"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "Operation"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "Organize"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "Optimal"; //更改no3的test
					DescriptionText.text = "歌劇在西方語言的代表字Opera來源於拉丁語「作品」的複數形式（Opus, Opera），後經義大利文推廣至其他歐洲語言。";  //題目答案說明
				}

				//題目91
				else if (randlevel == 91) {
					Question.text = "「歌劇的歌詞」一般都記錄於?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "辭本"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "歌本"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "字本"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "曲本"; //更改no3的test
					DescriptionText.text = "歌劇的歌詞往往紀錄在「辭本」（libretto，直譯為小冊子）上。一些歌劇作曲家，往往會為自己的歌劇填詞。";  //題目答案說明
				}

				//題目92
				else if (randlevel == 92) {
					Question.text = "首齣「德語歌劇」是哪一齣歌劇?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "達芙妮"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "魔笛"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "弄臣"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "茶花女"; //更改no3的test
					DescriptionText.text = "首齣德語歌劇是德國作曲家海因里希·許茨在1627年所寫的《達芙妮》，但曲譜已經散佚。直到18世紀為止，義大利歌劇對德語地區一直有很大的影響力。";  //題目答案說明
				}

				//題目93
				else if (randlevel == 93) {
					Question.text = "哪一齣歌劇不是「朱塞佩·威爾第」的代表作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "費加羅的婚禮"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "弄臣"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "遊唱詩人"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "茶花女"; //更改no3的test
					DescriptionText.text = "美聲時期過後，朱塞佩·威爾第帶動了一種更直接，更震撼的新風格，一連推出三部最受歡迎的歌劇：《弄臣》、《遊唱詩人》和《茶花女》。";  //題目答案說明
				}

				//題目94
				else if (randlevel == 94) {
					Question.text = "「紅髮神父」指的是哪一位人物?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "韋瓦第"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "蕭邦"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "巴赫"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "韓德爾"; //更改no3的test
					DescriptionText.text = "韋瓦第在15歲的時候即行剃髮並且接受了首次世俗聖職儀式，25歲時，韋瓦第成為神父。[6]他從父親那邊遺傳得來的頭髮顏色使得他被稱為「紅髮神父」。很多威尼斯人不曉得韋瓦第，卻知道紅髮神父。";  //題目答案說明
				}

				//題目95
				else if (randlevel == 95) {
					Question.text = "韋瓦第近500部協奏曲中有超過241部是為什麼「獨奏」而寫的?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "小提琴"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "大提琴"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "巴松管"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "管風琴"; //更改no3的test
					DescriptionText.text = "韋瓦第近500部協奏曲中有超過241部是為小提琴獨奏而寫的，其中的代表作為當屬「四季」小提琴協奏曲。";  //題目答案說明
				}

				//題目96
				else if (randlevel == 96) {
					Question.text = "韋瓦第的「四季」是搭配什麼內容?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "十四行詩"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "聖經"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "合奏曲"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "協奏曲"; //更改no3的test
					DescriptionText.text = "表面上「四季」的音樂搭配著十四行詩的內容，因此得以讓聆聽者清楚的體會音樂的描繪，而大受歡迎。相傳這十四行詩是維瓦第自己所寫，不過也有人認為作者不詳。";  //題目答案說明
				}

				//題目97
				else if (randlevel == 97) {
					Question.text = "韋瓦第的「四季」是出自於?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "和聲與創意的競爭"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "現實和理想的妥協"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "男孩和女孩的約定"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "家庭和朋友的關心"; //更改no3的test
					DescriptionText.text = "「四季」出自韋瓦第作品八，那是一組名稱為「和聲與創意的競爭」由十二首小提琴協奏曲構成的作品。「四季」是十二首裡面的前四首。";  //題目答案說明
				}

				//題目98
				else if (randlevel == 98) {
					Question.text = "巴哈在哪一部作品發表後，被世人所知?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "馬太受難曲"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "聖母頌"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "B小調彌撒"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "小提琴協奏曲"; //更改no3的test
					DescriptionText.text = "作曲家孟德爾頌在萊比錫的圖書館中發現了巴哈的《馬太受難曲》，並且在其音樂會上演奏，才震驚音樂界。";  //題目答案說明
				}

				//題目99
				else if (randlevel == 99) {
					Question.text = "「十四行詩」的作者為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "莎士比亞"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "孟德爾頌"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "但丁"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no3的test
					DescriptionText.text = "1609年，莎士比亞發表了《十四行詩》，這是他最後一部出版的非戲劇類著作。學者無法確認154首十四行詩每一首的完成時間，但是有證據表明莎士比亞在整個創作生涯中為一位私人讀者創作了這些十四行詩。";  //題目答案說明
				}

				//題目100
				else if (randlevel == 100) {
					Question.text = "莎士比亞慣用的「詩的形式」是?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "無韻詩"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "押韻詩"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "記譜法"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "反鏡法"; //更改no3的test
					DescriptionText.text = "莎士比亞慣用的詩的形式是無韻詩，同時結合抑揚格五音步。實際上，這意味著他的詩通常是不押韻的。";  //題目答案說明
				}

				//題目101
				else if (randlevel == 101) {
					Question.text = "位於羅馬的「聖天使城堡」原本建造的目的為何?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "陵墓"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "堡壘"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "監獄"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "教皇宮殿"; //更改no3的test
					DescriptionText.text = "聖天使城堡是由羅馬帝國皇帝哈德良於123年至139年期間興建，準備當作自己及其家人之陵墓，也被稱為哈德良的鼴鼠。";  //題目答案說明
				}

				//題目102
				else if (randlevel == 102) {
					Question.text = "「哈德良的鼴鼠」是用來形容哪一個「城堡」?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "聖天使城堡"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "聖伯多祿大殿"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "聖母主教座堂"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "皮耶楓城堡"; //更改no3的test
					DescriptionText.text = "聖天使城堡是由羅馬帝國皇帝哈德良於123年至139年期間興建，準備當作自己及其家人之陵墓，也被稱為哈德良的鼴鼠。";  //題目答案說明
				}

				//題目103
				else if (randlevel == 103) {
					Question.text = "「弗萊文圓形劇場」是哪一座建築物原本的名稱?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "羅馬鬥獸場"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "巨石陣"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "救世基督像"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "聖索菲亞大教堂"; //更改no3的test
					DescriptionText.text = "羅馬鬥獸場又譯作羅馬競技場、弗萊文圓形劇場是古羅馬時期最大的圓形角鬥場，建於公元72年-82年間，現僅存遺蹟位於現今義大利羅馬市的中心。羅馬競技場是卵形的圓形劇場，也是目前最大的圓形劇場。";  //題目答案說明
				}

				//題目104
				else if (randlevel == 104) {
					Question.text = "「羅馬競技場」建築形態起源於?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "古希臘"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "佛羅倫斯"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "法國"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "米蘭"; //更改no3的test
					DescriptionText.text = "競技場這種建築形態起源於古希臘時期的劇場，當時的劇場都傍山而建，呈半圓形，觀眾席就在山坡上層層升起。";  //題目答案說明
				}

				//題目105
				else if (randlevel == 105) {
					Question.text = "以下哪一座聖殿「不是」特級宗座聖殿?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "聖奧斯定聖殿"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "聖伯多祿大殿"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "聖母大殿國"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "城外聖保祿大殿"; //更改no3的test
					DescriptionText.text = "特級宗座聖殿的特殊之處是均擁有聖門，聖門開啟標誌著聖年，聖奧斯定聖殿並沒有聖門。";  //題目答案說明
				}

				//題目106
				else if (randlevel == 106) {
					Question.text = "「特級宗座聖殿」因為都具有什麼特殊之處而被列為「特級」?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "聖門"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "教宗"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "基督教"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "皇帝"; //更改no3的test
					DescriptionText.text = "該級別僅包含四座位於羅馬的教宗教堂。它們的特殊之處是均擁有聖門（holy door），它們的開啟標誌著聖年（Roman Jubilee）的來臨。";  //題目答案說明
				}

				//題目107
				else if (randlevel == 107) {
					Question.text = "在火砲出現後，城堡逐漸被什麼所取代?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "要塞"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "軍營"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "土屋"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "輪塔"; //更改no3的test
					DescriptionText.text = "要塞是指險要的關隘，亦作要隘，常出現邊城或戰略區域的要害處，是一種特別加固且固定的軍事設施。今天的要塞一詞一般是指16世紀在歐洲特別流行用於對抗砲兵的防禦設施。";  //題目答案說明
				}

				//題目108
				else if (randlevel == 108) {
					Question.text = "「梳毛工起義」是因為梳毛工沒有什麼而爆發?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "市民權"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "薪水"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "房子"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "醫療權"; //更改no3的test
					DescriptionText.text = "梳毛工起義是1378年在佛羅倫斯爆發的一場以梳毛工下層階層的起義。這些下層人作為人沒有市民權，作為職業群體沒有行會組織。";  //題目答案說明
				}

				//題目109
				else if (randlevel == 109) {
					Question.text = "哪個家族因為「梳毛工起義」而得到了發展的機會?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "美第奇家族"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "波吉亞家族"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "奧比奇家族"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "瓦薩里家族"; //更改no3的test
					DescriptionText.text = "梳毛工起義是這個下層階層贏得的一次短時間的勝利，它對上層階層成員的衝擊非常大；從長遠觀點來看這次起義導致了美第奇家族得以長時間地成為佛羅倫斯的秩序穩定勢力。";  //題目答案說明
				}

				//題目110
				else if (randlevel == 110) {
					Question.text = "「君王論」是誰的作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "馬基維利"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "羅倫佐"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "凱薩"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "但丁"; //更改no3的test
					DescriptionText.text = "《君王論》是義大利文藝復興時期作家馬基維利的政治論著，1513年獻給羅倫佐二世·德·麥第奇，但此書在馬基維利死後才出版。";  //題目答案說明
				}

				//題目111
				else if (randlevel == 111) {
					Question.text = "「君王論」中寫道，君王應當效法何種動物?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "狐狸"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "豺狼"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "大象"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "蒙狐"; //更改no3的test
					DescriptionText.text = "在守信和失信方面，君王應當效法狐狸與獅子。「由於獅子不能夠防止自己落入陷阱，而狐狸則不能夠抵禦豺狼。因此，君王必須是一頭狐狸以便認識陷阱，同時又必須是一頭獅子，以便使豺狼驚駭。」 ";  //題目答案說明
				}

				//題目112
				else if (randlevel == 112) {
					Question.text = "「君王論」中寫道，君王不能濫用什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "仁慈"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "殘酷"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "權力"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "戰爭"; //更改no3的test
					DescriptionText.text = "在殘酷和仁慈方面，君王對於殘酷這個惡名不必介意，所應重視的倒是不要濫用仁慈，因為仁慈會帶來滅頂之災， 「被人畏懼比受人愛戴是安全得多的」。";  //題目答案說明
				}

				//題目113
				else if (randlevel == 113) {
					Question.text = "「君王論」中寫道，主張建立什麼樣的民族國家?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "中央集權"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "地方獨立"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "思想統一"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "各自為政"; //更改no3的test
					DescriptionText.text = "資本主義經濟的發展，急切需要趨向穩定統一秩序的政治變革。馬基維利主張建立統一的中央集權的民族國家，結束義大利的分立狀態。";  //題目答案說明
				}

				//題目114
				else if (randlevel == 114) {
					Question.text = "「維特魯威人」是誰的作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "達文西"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "洛倫佐·瓦拉"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no3的test
					DescriptionText.text = "「維特魯威人」是李奧納多·達·文西在1487年前後創作的世界著名素描。根據約1500年前維特魯威在《建築十書》中的描述，達文西努力繪出了完美比例的人體。";  //題目答案說明
				}

				//題目115
				else if (randlevel == 115) {
					Question.text = "「維特魯威人」的另一個名字是什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "卡儂比例"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "北歐蠻人"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "希臘男人"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "阿薩族人"; //更改no3的test
					DescriptionText.text = "描繪了一個男人在同一位置上的「十」字型和「火」字型的姿態，並同時被分別嵌入到一個矩形和一個圓形當中。這幅畫有時也被稱作卡儂比例。";  //題目答案說明
				}

				//題目116
				else if (randlevel == 116) {
					Question.text = "在法國，文藝復興運動明顯地形成兩派，其中代表貴族派的名字是?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "七星詩社"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "藍星詩社"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "拉伯雷"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "巨人傳"; //更改no3的test
					DescriptionText.text = "七星詩社是16世紀的一群法國詩人，他們力圖按照希臘和拉丁語典範把法語和法國文學從中世紀的遺風中解放出來。";  //題目答案說明
				}

				//題目117
				else if (randlevel == 117) {
					Question.text = "在法國，文藝復興運動明顯地形成兩派，其中代表民主派的人是?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "拉伯雷"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "荷馬"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "莎士比亞"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "巨人傳"; //更改no3的test
					DescriptionText.text = "弗朗索瓦·拉伯雷是繼薄伽丘之後傑出的人文主義作家，是法國文藝復興民主派的代表。他用20年時間創作的《巨人傳》是一部現實與幻想交織的現實主義作品，在歐洲文學史和教育史上佔有重要地位。";  //題目答案說明
				}

				//題目118
				else if (randlevel == 118) {
					Question.text = "莎士比亞是西方文藝史上最傑出的作家之一，作品眾多，共創作了幾部戲劇?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "38"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "45"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "39"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "55"; //更改no3的test
					DescriptionText.text = "威廉·莎士比亞是全世界最卓越的文學家之一。他流傳下來的作品包括38部戲劇、154首十四行詩、兩首長敘事詩和其他詩歌。";  //題目答案說明
				}

				//題目119
				else if (randlevel == 119) {
					Question.text = "佛羅倫斯作為文藝復興的發祥地，在各領域都有名人，代表「雕刻家」的為何人?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "達文西"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "彼特拉克"; //更改no3的test
					DescriptionText.text = "米開朗基羅是文藝復興時期傑出的通才、雕塑家、建築師以人物「健美」著稱，即使女性的身體也描畫的肌肉健壯。他的雕刻作品「大衛像」舉世聞名。";  //題目答案說明
				}

				//題目120
				else if (randlevel == 120) {
					Question.text = "「哺乳聖母」是誰繪製的一副油畫?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "達文西"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "薄伽丘"; //更改no3的test
					DescriptionText.text = "「哺乳聖母」是列奧納多·達·芬奇在15世紀末期繪製的一副油畫，以聖母哺育聖嬰為主題。";  //題目答案說明
				}

				//題目121
				else if (randlevel == 121) {
					Question.text = "歐洲黑暗時代在編史工作上是指在西歐歷史上，從「哪一個帝國」的滅亡到文藝復興開始?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "羅馬帝國"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "波斯帝國"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "埃及王朝"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "希臘王朝"; //更改no3的test
					DescriptionText.text = "在西歐歷史上，從羅馬帝國的滅亡到文藝復興開始，一段文化層次下降或者社會崩潰的時期。在19世紀，隨著對中世紀更多的了解，整個時代都被描述成「黑暗」的說法受到了挑戰。";  //題目答案說明
				}

				//題目122
				else if (randlevel == 122) {
					Question.text = "「黑暗時代」是由哪位學者提出?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "彼特拉克"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "馬基維利"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "但丁"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "狄更斯"; //更改no3的test
					DescriptionText.text = "黑暗時代的概念由彼特拉克在1330年代提出。在寫到關於那些在他之前的人們，他說：「在種種謬誤之中仍然有天才之人熠熠生煇，雖然被昏昧黑暗所包圍著，他們的目光依然銳利。」";  //題目答案說明
				}

				//題目123
				else if (randlevel == 123) {
					Question.text = "歐洲黑暗時代是一個封建社會，社會階級森嚴，下面哪一個是大封建主?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "公爵"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "子爵"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "男爵"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "騎士"; //更改no3的test
					DescriptionText.text = "歐洲國家貴族爵位中，從最低級貴族爵位以上的第五級一般在中文裏譯作「公爵」，在王或親王之下，在侯爵之上。";  //題目答案說明
				}

				//題目124
				else if (randlevel == 124) {
					Question.text = "歐洲黑暗時代是一個封建社會，社會階級森嚴，下面哪一個是中等封建主?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "子爵"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "侯爵"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "伯爵"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "騎士"; //更改no3的test
					DescriptionText.text = "子爵是歐洲貴族爵位之一，一般高於男爵,低於伯爵。這一爵位在英國出現於1387年。";  //題目答案說明
				}

				//題目125
				else if (randlevel == 125) {
					Question.text = "歐洲黑暗時代是一個封建社會，社會階級森嚴，下面哪一個是小封建主?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "騎士"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "子爵"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "平民"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "伯爵"; //更改no3的test
					DescriptionText.text = "騎士原為歐洲中世紀受過正規軍事訓練的騎兵，後來成為一種貴族階層。騎士的頭銜來自另一位騎士或是領主的冊封。";  //題目答案說明
				}

				//題目126
				else if (randlevel == 126) {
					Question.text = "歐洲黑暗時代的科學發展因為什麼糟到重大打擊?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "戰爭"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "宗教"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "天災"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "奪權"; //更改no3的test
					DescriptionText.text = "科學發展因為戰亂受到重大打擊，而文化發展方面的打擊更大，羅馬及希臘的文明遺產則受到暴徒破壞，其中亦包括基督徒教狂熱份子。";  //題目答案說明
				}

				//題目127
				else if (randlevel == 127) {
					Question.text = "「黑暗時代」又被稱為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "中世紀前期"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "文藝復興時期"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "古羅馬時期"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "拜占庭帝國"; //更改no3的test
					DescriptionText.text = "在19世紀，隨著對中世紀更多的了解，整個時代都被描述成「黑暗」的說法受到了挑戰。又因為整個時期都是中世紀的一部分——稱為中世紀前期。";  //題目答案說明
				}

				//題目128
				else if (randlevel == 128) {
					Question.text = "「聖母百花聖殿」哥特式風格的主教座堂共建立多久?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "140年"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "90年"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "126年"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "33年"; //更改no3的test
					DescriptionText.text = "建於1296年，由建築師卡姆比奧設計，並採用了精通羅馬古建築的工匠菲利波著名的圓頂建造，1436年最終完工。";  //題目答案說明
				}

				//題目129
				else if (randlevel == 129) {
					Question.text = "佛羅倫斯的「市徽」是何種圖案?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "百合"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "梅花"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "鳶尾花"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "玫瑰"; //更改no3的test
					DescriptionText.text = "自從11世紀以來，佛羅倫斯的市徽就是百合圖案。1251年，市徽上的圖案是紅色背景的白色花朵。";  //題目答案說明
				}

				//題目130
				else if (randlevel == 130) {
					Question.text = "佛羅倫斯的「市徽」是何種圖案?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "300年"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "230年"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "158年"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "253年"; //更改no3的test
					DescriptionText.text = "美第奇家族（1434年開始）手中，美第奇家族曾經出過幾任教皇，美第奇家族的獨裁統治持續將近300年(1434-1737年中的絕大多數時間)。";  //題目答案說明
				}

				//題目131
				else if (randlevel == 131) {
					Question.text = "「羅馬紀元」是從什麼時候開始?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "羅馬城建起"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "耶穌離世"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "凱薩即位"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "亞歷山大即位"; //更改no3的test
					DescriptionText.text = "羅馬的建城同時標誌著羅馬紀元的開始，「羅馬紀元」(ab urbe condita，縮寫a.u.c.)就是「從羅馬建城起」的意思。";  //題目答案說明
				}

				//題目132
				else if (randlevel == 132) {
					Question.text = "15世紀的哪個地區是歐洲城市化水平最高的地區?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "義大利"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "法國"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "德國"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "希臘"; //更改no3的test
					DescriptionText.text = "15世紀的義大利是歐洲城市化水平最高的地區。許多義大利城市就建立在古羅馬建築的廢墟之上。";  //題目答案說明
				}

				//題目133
				else if (randlevel == 133) {
					Question.text = "《巨人傳》的作者是誰?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "拉伯雷"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "佩脫拉克"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "薄伽丘"; //更改no3的test
					DescriptionText.text = "由作家弗朗索瓦·拉伯雷創作，共有五集，1545年出版。具體反映出中古時期具有資產思想的人解放與追求的理念。";  //題目答案說明
				}

				//題目134
				else if (randlevel == 134) {
					Question.text = "《巨人傳》寫巨人卡岡都亞的兒子龐大固埃到法國學習，遇到許多人物:代表「迅速」是誰?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "卡爾巴里"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "奧斯太納"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "艾比斯太蒙"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "巴努希"; //更改no3的test
					DescriptionText.text = "代表「迅速」的卡爾巴里；代表「強大」的奧斯太納；代表「明智」的艾比斯太蒙；代表「高明」的巴努希。";  //題目答案說明
				}

				//題目135
				else if (randlevel == 135) {
					Question.text = "《巨人傳》寫巨人卡岡都亞的兒子龐大固埃到法國學習，遇到許多人物:代表「強大」是誰?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "奧斯太納"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "卡爾巴里"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "艾比斯太蒙"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "巴努希"; //更改no3的test
					DescriptionText.text = "代表「迅速」的卡爾巴里；代表「強大」的奧斯太納；代表「明智」的艾比斯太蒙；代表「高明」的巴努希。";  //題目答案說明
				}

				//題目136
				else if (randlevel == 136) {
					Question.text = "《巨人傳》寫巨人卡岡都亞的兒子龐大固埃到法國學習，遇到許多人物:代表「明智」是誰?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "艾比斯太蒙"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "卡爾巴里"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "奧斯太納"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "巴努希"; //更改no3的test
					DescriptionText.text = "代表「迅速」的卡爾巴里；代表「強大」的奧斯太納；代表「明智」的艾比斯太蒙；代表「高明」的巴努希。";  //題目答案說明
				}

				//題目137
				else if (randlevel == 137) {
					Question.text = "《巨人傳》寫巨人卡岡都亞的兒子龐大固埃到法國學習，遇到許多人物:代表「高明」是誰?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "巴努希"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "卡爾巴里"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "奧斯太納"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "艾比斯太蒙"; //更改no3的test
					DescriptionText.text = "代表「迅速」的卡爾巴里；代表「強大」的奧斯太納；代表「明智」的艾比斯太蒙；代表「高明」的巴努希。";  //題目答案說明
				}

				//題目138
				else if (randlevel == 138) {
					Question.text = "羅馬因此被稱為「七丘之城」，是因為擁有七個?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "山丘"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "雕像"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "城門"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "教堂"; //更改no3的test
					DescriptionText.text = "在河岸邊有七座山丘：帕拉提諾、阿文提諾、卡比托利歐、奎利那雷、維米那勒、埃斯奎利諾和西里歐，羅馬因此也被稱為「七丘之城」。";  //題目答案說明
				}

				//題目139
				else if (randlevel == 139) {
					Question.text = "「聖母與諸殉道者教堂」是哪座建築物的正是名稱?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "萬神殿"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "卡拉卡拉浴場"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "台伯島"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "凱撒神廟"; //更改no3的test
					DescriptionText.text = "公元609年拜占廷皇帝將萬神廟獻給羅馬教皇卜尼法斯四世，後者將它更名為聖母與諸殉道者教堂，這也是今天萬神廟的正式名稱。";  //題目答案說明
				}

				//題目140
				else if (randlevel == 140) {
					Question.text = "萬神廟整幢建築都用什麼澆灌而成?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "混凝土"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "花崗石"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "大理石"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "玄武岩"; //更改no3的test
					DescriptionText.text = "萬神廟整幢建築都用混凝土澆灌而成，古羅馬人當時使用的混凝土是來自那波利附近的天然火山灰，再混入凝灰岩等多種骨料。";  //題目答案說明
				}

				//題目141
				else if (randlevel == 141) {
					Question.text = "十三世紀時歐洲的「雕刻」仍保持濃厚什麼樣的風格?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "哥德式"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "巴洛克"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "古羅馬"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "人文再現"; //更改no3的test
					DescriptionText.text = "哥德式藝術，為一種源自歐洲法國的藝術風格，該風格始於12世紀的法國，盛行於13世紀，至14世紀末期，其風格逐漸大眾化和自然化。";  //題目答案說明
				}

				//題目142
				else if (randlevel == 142) {
					Question.text = "下列哪一尊雕像「不是」米開郎基羅的作品之一?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "救世基督像"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "大衛像"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "摩西像"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "聖瘍"; //更改no3的test
					DescriptionText.text = "在科科瓦多山上建造一座雕像的想法始於1850年代中期，那時一個天主教神父博斯請求巴西帝國的伊莎貝爾公主籌措資金建造一座大型的宗教紀念物。";  //題目答案說明
				}

				//題目143
				else if (randlevel == 143) {
					Question.text = "歷史上第一次復興運動被稱為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "卡洛林文藝復興"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "義大利文藝復興"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "米蘭文藝復興"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "佛羅倫斯文藝復興"; //更改no3的test
					DescriptionText.text = "卡洛林文藝復興，發生在公元8世紀晚期至9世紀的卡洛林王朝，由查理曼在歐洲推行的文藝的復興運動，被稱為是「歐洲的第一次覺醒」。";  //題目答案說明
				}

				//題目144
				else if (randlevel == 144) {
					Question.text = "什麼樣的風格，開創了建築史上羅馬式建築風格的時代?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "拜占庭風格"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "巴洛克風格"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "亞琛風格"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "古羅馬風格"; //更改no3的test
					DescriptionText.text = "查理曼統治時期，推崇古羅馬巴西利卡式建築，並受當時的拜占庭風格影響，開創了建築史上羅馬式建築風格的時代。";  //題目答案說明
				}

				//題目145
				else if (randlevel == 145) {
					Question.text = "卡洛林文藝復興時期，以什麼為時期代表作?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "亞琛大教堂"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "聖索非亞大教堂"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "倭馬亞大清真寺"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "洛爾施修道院"; //更改no3的test
					DescriptionText.text = "查理曼統治時期，推崇古羅馬巴西利卡式建築，並受當時的拜占庭風格影響，位於當時首都亞琛的亞琛大教堂為其代表作。";  //題目答案說明
				}

				//題目146
				else if (randlevel == 146) {
					Question.text = "歷史上共有幾次卡洛林文藝復興?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "3次"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "5次"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "1次"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "2次"; //更改no3的test
					DescriptionText.text = "分為查理曼推行的「第一次卡洛林文藝復興」、其後繼者統治下的「第二次卡洛林文藝復興」，並將後來的奧托文藝復興視為相同現象的延續，而納入成「第三次卡洛林文藝復興」。";  //題目答案說明
				}

				//題目147
				else if (randlevel == 147) {
					Question.text = "「卡洛林文義復興」一詞是誰創造?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "雅克·安培"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "雅克·勒高夫"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "卡洛林·梅根"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "克里斯多福·道森"; //更改no3的test
					DescriptionText.text = "雅克·安培於1830年代後期首度創造「卡洛林文義復興」一詞，並提出相關的概念。";  //題目答案說明
				}

				//題目148
				else if (randlevel == 148) {
					Question.text = "哪一本著作被稱為「文藝復興時代的宣言」?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "論人的尊嚴"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "君王論"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "神曲"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "歌本"; //更改no3的test
					DescriptionText.text = "喬瓦尼·皮科 義大利文藝復興時期哲學家。其著作《論人的尊嚴被稱為「文藝復興時代的宣言」。一種新柏拉圖的話語框架里來闡釋人類對知識的追求。";  //題目答案說明
				}

				//題目149
				else if (randlevel == 149) {
					Question.text = "位於佛羅倫斯的「聖瑪麗亞費奧利教堂」，因為放棄什麼設計成為當時建築的典範?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "哥德式"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "巴洛克式"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "希臘式"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "古羅馬式"; //更改no3的test
					DescriptionText.text = "文藝復興的建築風格可以說是布魯內列斯基所創立的。他完全遵守古典的形式，揚棄哥德式的煩瑣設計，成為當時建築的典範。";  //題目答案說明
				}

				//題目150
				else if (randlevel == 150) {
					Question.text = "哥德式建築是由何種建築演變而來?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "羅馬"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "巴洛克"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "希臘"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "波斯"; //更改no3的test
					DescriptionText.text = "哥德式建築，是一種興盛於歐洲中世紀高峰與末期的建築風格。它是由羅馬式建築發展而來，為文藝復興建築所繼承。";  //題目答案說明
				}

				//題目151
				else if (randlevel == 151) {
					Question.text = "哥德式建築最常見於何種建築?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "主教座堂"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "大學"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "私人住宅"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "城堡"; //更改no3的test
					DescriptionText.text = "哥德式建築的特色包括尖形拱門、肋狀拱頂、飛扶璧，最常見於歐洲的主教座堂。";  //題目答案說明
				}

				//題目152
				else if (randlevel == 152) {
					Question.text = "世界上現存最大的羅馬式教堂是?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "施派爾主教座堂"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "聖羅倫佐教堂"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "聖彼得大教堂"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "聖瑪麗亞費奧利教堂"; //更改no3的test
					DescriptionText.text = "目前世界上現存最大的羅曼式教堂施派爾主教座堂，是對於帝國的力量和建築革新的一種體現，也是德國羅曼式教堂普遍超高形象的代表。";  //題目答案說明
				}

				//題目153
				else if (randlevel == 153) {
					Question.text = "文藝復興時期因為印刷術的進步，什麼相關書籍獲得推廣?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "聖經"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "兵法"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "科學"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "人文"; //更改no3的test
					DescriptionText.text = "文藝復興時期的作家們開始更多地使用這些地方語言寫作；而印刷術的推廣亦使得更多的人能夠接觸到各種書籍，特別是聖經。";  //題目答案說明
				}

				//題目154
				else if (randlevel == 154) {
					Question.text = "人文主義者研究什麼，導致了宗教改革運動的興起?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "聖經"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "兵法"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "科學"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "人文"; //更改no3的test
					DescriptionText.text = "人文主義者開始用研究古典文學的方法研究《聖經》，將聖經翻譯民族語言，導致了宗教改革運動的興起。";  //題目答案說明
				}

				//題目155
				else if (randlevel == 155) {
					Question.text = "文藝復興時期是以什麼為中心?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "人情"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "神學"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "教育"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "科學"; //更改no3的test
					DescriptionText.text = "人文主義歌頌世俗蔑視天堂，標榜理性以取代神啟，肯定「人」是現世生活的創造者和享受者。";  //題目答案說明
				}

				//題目156
				else if (randlevel == 156) {
					Question.text = "因為什麼發現，為地圓說提供了有力的證據?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "地理大發現"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "文化大發現"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "黑死病發現"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "人文主藝發現"; //更改no3的test
					DescriptionText.text = "地理大發現指從15世紀到17世紀時期。：航海技術產生了一次革命性地飛躍，葡萄牙、西班牙、義大利的探險家們開始了一系列遠程航海活動。";  //題目答案說明
				}

				//題目157
				else if (randlevel == 157) {
					Question.text = "哪位人物是薄伽丘之後傑出的人文主義作家?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "弗朗索瓦·拉伯雷"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "威廉·莎士比亞"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "維加"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "托馬斯·莫爾"; //更改no3的test
					DescriptionText.text = "弗朗索瓦·拉伯雷是法國文藝復興民主派的代表。他用20年時間創作的《巨人傳》是一部現實與幻想交織的現實主義作品。";  //題目答案說明
				}

				//題目158
				else if (randlevel == 158) {
					Question.text = "以下誰不是歐洲劃時代的「四大作家」?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "薄伽丘"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "莎士比亞"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "但丁"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "歌德"; //更改no3的test
					DescriptionText.text = "莎士比亞、荷馬、但丁、歌德的作品結構完整，情節生動，語言豐富精煉，人物個性突出，集中地代表歐洲文藝復興文學的最高成就。";  //題目答案說明
				}

				//題目159
				else if (randlevel == 159) {
					Question.text = "「唐吉訶德」是誰的作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "塞萬提斯"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "莎士比亞"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "但丁"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "荷馬"; //更改no3的test
					DescriptionText.text = "《唐吉訶德》是西班牙作家塞萬提斯於1605年和1615年分兩部分出版的反騎士小說。，主角唐吉訶德幻想自己是個騎士，因而作出種種令人匪夷所思的行徑。";  //題目答案說明
				}

				//題目160
				else if (randlevel == 160) {
					Question.text = "「唐吉訶德」的主角-唐吉訶德共經歷幾次歷險?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "3次"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "9次"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "5次"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "8次"; //更改no3的test
					DescriptionText.text = "《唐吉訶德》全書共由兩個部分所構成，敘述了唐吉訶德的三次冒險歷程。";  //題目答案說明
				}

				//題目161
				else if (randlevel == 161) {
					Question.text = "《唐吉訶德》中主角的本名為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "阿隆索·吉哈諾"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "阿隆辛·吉哈諾"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "哈薩吉·吉哈諾"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "哈薩克·吉哈諾"; //更改no3的test
					DescriptionText.text = "唐吉訶德，本書的主人翁。本名為：阿隆索·吉哈諾(Alonso Quijano)。";  //題目答案說明
				}

				//題目162
				else if (randlevel == 162) {
					Question.text = "《唐吉訶德》中老闆把什麼當作聖經，冊封唐吉訶德為騎士?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "馬料帳本"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "銀行帳本"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "紡織顏料"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "國王家徽"; //更改no3的test
					DescriptionText.text = "唐吉訶德把鄉村客店當做城堡，把老闆當做寨主，硬要老闆封他做騎士；老闆把馬料帳本當做《聖經》，冊封唐吉訶德為騎士。";  //題目答案說明
				}

				//題目163
				else if (randlevel == 163) {
					Question.text = "「歐洲繪畫之父」是誰的稱號?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "喬托"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "彼特拉克"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "達文西"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no3的test
					DescriptionText.text = "喬托·迪·邦多納(約1267年－1337年1月8日)義大利畫家與建築師，被認定為是義大利文藝復興時期的開創者，被譽為「歐洲繪畫之父」。";  //題目答案說明
				}

				//題目164
				else if (randlevel == 164) {
					Question.text = "何者不是「喬托」的作品之一?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "最後的晚餐"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "猶大之吻"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "最後審判"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "哀悼基督"; //更改no3的test
					DescriptionText.text = "《最後的晚餐》是李奧納多·達文西於1498年作於義大利米蘭恩寵聖母多明我會院食堂。";  //題目答案說明
				}

				//題目165
				else if (randlevel == 165) {
					Question.text = "「美第奇家族」在哪一個人之後就此沒有名正言順的繼承者了?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "公吉安·加斯托內"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "法蘭茲·史蒂芬"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "安娜·瑪麗亞"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "羅倫佐一世·德"; //更改no3的test
					DescriptionText.text = "1737年，第7代托斯卡尼大公吉安·加斯托內·德·麥第奇沒有留下繼承人就去世了，但並不是說家族裡沒有活下來的人，只是沒有名正言順的繼承者了。";  //題目答案說明
				}

				//題目166
				else if (randlevel == 166) {
					Question.text = "「梳毛工起義」事件是由美第奇家族何人平定?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "薩爾韋斯特羅"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "喬凡尼"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "羅倫佐"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "科西莫一世"; //更改no3的test
					DescriptionText.text = "薩爾韋斯特羅·德·麥第奇(1331年–1388年)，鎮壓梳毛工起義事件，成為佛羅倫斯的正義旗手，1382年被驅逐。";  //題目答案說明
				}

				//題目167
				else if (randlevel == 167) {
					Question.text = "「美第奇家族」大部分的收藏都放置何處?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "烏菲茲美術館"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "羅浮宮"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "大英博物館"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "梵蒂岡博物館"; //更改no3的test
					DescriptionText.text = "麥第奇家族世世代代傳承下來的收藏品，現在還保存在烏菲茲美術館里。家族使用過的碧提宮等等建築物也大多在佛羅倫斯市內完好地保留著。";  //題目答案說明
				}

				//題目168
				else if (randlevel == 168) {
					Question.text = "麥第奇家族最後一位女性是何人?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "安娜·瑪麗亞"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "凱薩琳·德"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "瑪麗·德"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "吉安·加斯托內"; //更改no3的test
					DescriptionText.text = "安娜·瑪麗亞·路易薩·德·麥地奇(1667年8月11日 - 1743年2月18日)，住在碧提宮的麥地奇家族的最後一位直系後裔。";  //題目答案說明
				}

				//題目169
				else if (randlevel == 169) {
					Question.text = "美第奇家族的「家徽」哪一項代表與法國皇室的關係?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "藍底尾鳶花"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "金條"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "錢幣"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "武士盾牌"; //更改no3的test
					DescriptionText.text = "家徽上六個圓形圖案，最上方藍底尾鳶花代表與法國皇室的關係。";  //題目答案說明
				}

				//題目170
				else if (randlevel == 170) {
					Question.text = "世界最大的穹頂是哪一項教堂擁有?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "聖母百花大教堂"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "巴迪亞教堂"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "教義會聖堂"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "佛羅倫斯聖神大殿"; //更改no3的test
					DescriptionText.text = "科西莫委任布魯內萊斯基繼續未完成的圓頂聖母百花大教堂，1436年當時世界最大的穹頂完工。";  //題目答案說明
				}

				//題目171
				else if (randlevel == 171) {
					Question.text = "「羅倫佐·德·麥第奇」一生共有幾名子女?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "9名"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "5名"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "3名"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "4名"; //更改no3的test
					DescriptionText.text = "1469年2月7日，羅倫佐和克拉麗切·奧爾西尼結婚。他們有9個孩子。";  //題目答案說明
				}

				//題目172
				else if (randlevel == 172) {
					Question.text = "羅倫佐死後，伴隨他的死亡，文藝復興的中心由佛羅倫斯轉移至何處?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "羅馬"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "威尼斯"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "米蘭"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "塔斯卡尼"; //更改no3的test
					DescriptionText.text = "羅倫佐死後的6個月，哥倫布發現新大陸。同時，伴隨他的死亡，文藝復興的中心由佛羅倫斯轉移至羅馬，並在那裡又持續了一個多世紀。";  //題目答案說明
				}

				//題目173
				else if (randlevel == 173) {
					Question.text = "「羅倫佐」的哪一個子女成為法國的內穆爾公爵?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "朱利亞諾·迪"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "皮耶羅·迪"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "喬瓦尼·德"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "路易莎·德"; //更改no3的test
					DescriptionText.text = "朱利亞諾·迪·羅倫佐·德·麥地奇(1479年3月12日—1516年3月17日)後來成為法國的內穆爾公爵。";  //題目答案說明
				}

				//題目174
				else if (randlevel == 174) {
					Question.text = "羅倫佐死後，是葬在誰設計的禮拜室內?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "達文西"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "薄伽丘"; //更改no3的test
					DescriptionText.text = "1492年4月8號或9號的晚上，羅倫佐在卡里奇的別墅去世。羅倫佐死後和他的兄弟朱利亞諾葬在一個由米開朗基羅設計的禮拜室內。";  //題目答案說明
				}

				//題目175
				else if (randlevel == 175) {
					Question.text = "「維納斯的誕生」是誰的作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "波提且利"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "達文西"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no3的test
					DescriptionText.text = "山德羅·波提且利1485年完成的《維納斯的誕生》是波提且利的另一幅傑作，表現的是希臘神話中代表愛與美的女神維納斯從大海中誕生的場景。";  //題目答案說明
				}

				//題目176
				else if (randlevel == 176) {
					Question.text = "「虛榮的篝火」是由誰發起?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "撒佛納羅拉"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "波提且利"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "亞歷山大六世"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "博家切"; //更改no3的test
					DescriptionText.text = "1497年2月7日，極端宗教人士撒佛納羅拉與之追隨者們在佛羅倫薩點燃了他們從城內搜出。";  //題目答案說明
				}

				//題目177
				else if (randlevel == 177) {
					Question.text = "「虛榮的篝火」在哪裡發生?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "君主廣場"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "人民廣場"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "聯邦廣場"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "國家廣場"; //更改no3的test
					DescriptionText.text = "作為意大利最漂亮的廣場之一的君主廣場以其四周的建築和廣場上的藝術作品而成為一個地地道道的露天藝術博物館，廣場一直是城市的政治和民事生活的中心。";  //題目答案說明
				}

				//題目178
				else if (randlevel == 178) {
					Question.text = "山德羅·波提且利擅長以什麼為作畫風格?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "哥德式"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "巴洛克式"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "希臘式"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "古羅馬式"; //更改no3的test
					DescriptionText.text = "波提且利以哥德式的手法，對三維立體事物的把握、對細微人物臉部表情的表現和對細節的重視都對波提且利日後的繪畫風格造成了深遠影響。";  //題目答案說明
				}

				//題目179
				else if (randlevel == 179) {
					Question.text = "山德羅·波提且利因為受到「哪個家族」的賞識而獲得政治上的保護?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "美第奇家族"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "奧比奇家族"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "帕齊家族"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "波吉亞家族"; //更改no3的test
					DescriptionText.text = "1470年，波提且利開設個人繪畫工作室，很快就受到美第奇家族的賞識與強大的美第奇家族保持著良好的關係也使畫家獲得政治上的保護。";  //題目答案說明
				}

				//題目180
				else if (randlevel == 180) {
					Question.text = "「三博士來朝」是誰的作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "波提且利"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "達文西"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no3的test
					DescriptionText.text = "世人所熟知的畫作是他的《三博士來朝》。這幅畫為他在整個歐洲贏得了聲譽，並也因此於1481年7月被教皇召喚到羅馬，為西斯廷禮拜堂作壁畫。";  //題目答案說明
				}

				//題目181
				else if (randlevel == 181) {
					Question.text = "山德羅·波提且利的《春》中三美神並沒有象徵哪一項?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "典雅"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "華美"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "貞淑"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "歡悅"; //更改no3的test
					DescriptionText.text = "為美第奇別墅所畫《春》，維納斯的右手邊是三美神手拉手翩翩起舞，她們分別象徵「華美」、「貞淑」和「歡悅」。";  //題目答案說明
				}

				//題目182
				else if (randlevel == 182) {
					Question.text = "《交付天國之鑰》是誰的作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "佩魯吉諾"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "波提且利"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "達文西"; //更改no3的test
					DescriptionText.text = "彼得羅·佩魯吉諾(1446年-1523年)，是一位義大利文藝復興時期的畫家，活躍於文藝復興全盛期。其最著名的學生是拉斐爾。";  //題目答案說明
				}

				//題目183
				else if (randlevel == 183) {
					Question.text = "《施洗約翰》是誰的作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "佩魯吉諾"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "波提且利"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "達文西"; //更改no3的test
					DescriptionText.text = "《施洗約翰》是彼得羅·佩魯吉諾(1446年-1523年)，1480年時應教皇西斯都四世之召前往羅馬製的壁畫之一。";  //題目答案說明
				}

				//題目184
				else if (randlevel == 184) {
					Question.text = "「彼得羅·佩魯吉諾」最後是死於何種疾病?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "黑死病"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "肺炎"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "心臟病"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "瘟疫"; //更改no3的test
					DescriptionText.text = "1523年佩魯吉諾身處豐蒂納諾，在這裡感染了黑死病，也死於此地。他的遺體也像其他死者一樣被草草地掩埋了，具體地點未知。";  //題目答案說明
				}

				//題目185
				else if (randlevel == 185) {
					Question.text = "《維納斯與戰神》是誰的作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "波提且利"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "達文西"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "佩魯吉諾"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no3的test
					DescriptionText.text = "波提且利約於1483年繪成的作品，現藏於英國倫敦的國家美術館。愛神維納斯和戰神瑪爾斯躺在一起。維納斯穿著衣服，胸前掛著連接頭髮的飾品。";  //題目答案說明
				}

				//題目186
				else if (randlevel == 186) {
					Question.text = "波提且利的作品《維納斯與戰神》象徵的意義是?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "愛征服戰爭"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "情關難過"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "戀人分離"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "戰爭勝利"; //更改no3的test
					DescriptionText.text = "愛神維納斯和戰神瑪爾斯躺在一起。環繞背景的是一片愛神樹林。整個畫面構圖平穩，寧靜。象徵愛的力量征服了戰爭。";  //題目答案說明
				}

				//題目187
				else if (randlevel == 187) {
					Question.text = "《達文西自畫像》是以什麼顏色的粉筆繪製?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "紅色"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "黑色"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "黃色"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "白色"; //更改no3的test
					DescriptionText.text = "紅色粉筆畫的肖像，畫於大約1512年至1515年，被廣泛視為最初的達文西自畫像。";  //題目答案說明
				}

				//題目188
				else if (randlevel == 188) {
					Question.text = "《耶穌受洗》是達文西和誰共同完成?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "委羅基奧"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "巴哈"; //更改no3的test
					DescriptionText.text = "《耶穌受洗》(1472–1475) — Uffizi，由委羅基奧和達文西共同作畫。";  //題目答案說明
				}

				//題目189
				else if (randlevel == 189) {
					Question.text = "達文西為「香波爾城堡」設計了什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "螺旋雙梯"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "拱橋"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "主塔"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "側翼"; //更改no3的test
					DescriptionText.text = "香波爾城堡中，雙螺旋梯是由達文西設計，位於城堡的主塔中央，兩座不同入口的螺旋式階梯環繞同一空心石柱。";  //題目答案說明
				}

				//題目190
				else if (randlevel == 190) {
					Question.text = "第一個畫出子宮中胎兒的人是誰?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "達文西"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "巴哈"; //更改no3的test
					DescriptionText.text = "達文西是第一個畫出子宮中胎兒(他希望瞭解「生育奇蹟」)同時也是第一個畫出腹腔中闌尾的人。";  //題目答案說明
				}

				//題目191
				else if (randlevel == 191) {
					Question.text = "「喬爾喬·瓦薩里」曾說誰不斷的展現該如何抬昇喬凡尼洗禮池?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "達文西"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "巴哈"; //更改no3的test
					DescriptionText.text = "喬爾喬·瓦薩里在《達文西的一生》一書中說達文西不斷的展現該如何抬昇喬凡尼洗禮池，而能涉足其中不損壞之。";  //題目答案說明
				}

				//題目192
				else if (randlevel == 192) {
					Question.text = "《吉內薇拉‧班琪》是誰的作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "達文西"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "莎士比亞"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "羅倫佐"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "但丁"; //更改no3的test
					DescriptionText.text = "吉內薇拉‧班琪是15世紀佛羅倫斯的一位貴族。她因睿智而廣受同時代人的敬仰。達‧芬奇為她創作了一幅肖像畫。";  //題目答案說明
				}

				//題目193
				else if (randlevel == 193) {
					Question.text = "達文西唯一一幅在美洲的作品為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "吉內薇拉‧班琪"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "哺乳聖母"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "救世主"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "音樂家肖像"; //更改no3的test
					DescriptionText.text = "達文西為吉內薇拉‧班琪創作了一幅肖像畫這幅木板油畫現收藏在坐落於華盛頓的國家藝廊。這是唯一一幅能在美洲見到的達文西畫作。";  //題目答案說明
				}

				//題目194
				else if (randlevel == 194) {
					Question.text = "達文西共花多久完成《聖母子與聖安妮》?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "3年"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "10年"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "25年"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "9年"; //更改no3的test
					DescriptionText.text = "《聖母子與聖安妮》是達文西的畫板油畫，作於1508年－1510年，現藏於法國巴黎羅浮宮。";  //題目答案說明
				}

				//題目195
				else if (randlevel == 195) {
					Question.text = "達文西共花多久完成《蒙娜麗莎》?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "4年"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "10年"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "25年"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "9年"; //更改no3的test
					DescriptionText.text = "達文西在1502年（義大利文藝復興時期）開始創作《蒙娜麗莎》，並根據瓦薩里的記載，這幅畫耗時4年完成。";  //題目答案說明
				}

				//題目196
				else if (randlevel == 196) {
					Question.text = "達文西因為誰而有機會到羅馬?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "凱薩·波吉亞"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "羅倫佐"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no3的test
					DescriptionText.text = "在佛羅倫斯，達文西進入教宗亞歷山大六世之子凱薩·波吉亞的部門，擔任軍事建築暨工程師，並隨凱薩·波吉亞遊遍義大利。";  //題目答案說明
				}

				//題目197
				else if (randlevel == 197) {
					Question.text = "達文西曾想用什麼來製作《馬雕塑》?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "青銅"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "鋼鐵"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "白金"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "黃金"; //更改no3的test
					DescriptionText.text = "1495年米蘭公爵企圖拯救米蘭避免被法國查理斯八世統治，將70噸青銅鑄造成武器的地方，而這些材料原本是達文西打算用來製作馬雕塑。";  //題目答案說明
				}

				//題目198
				else if (randlevel == 198) {
					Question.text = "現在已知達文西最早的作品為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "阿莫谷"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "最後的晚餐"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "蒙娜麗莎"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "抱銀鼠的女子"; //更改no3的test
					DescriptionText.text = "已知最早的達文西畫作——《阿莫谷》(作於1473年)，現藏於烏菲茲美術館。";  //題目答案說明
				}

				//題目199
				else if (randlevel == 199) {
					Question.text = "米開朗基羅在美第奇墓前創作「晝」、「夜」、「晨」和哪一個雕像?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "昏"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "冥"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "午"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "夢"; //更改no3的test
					DescriptionText.text = "米開朗基羅美第奇墓前的「晝」、「夜」、「晨」、「昏」四座雕像構思新奇，此外著名的雕塑作品還有「摩西像」、「大奴隸」等。";  //題目答案說明
				}

				//題目200
				else if (randlevel == 200) {
					Question.text = "米開朗基羅在佛羅倫薩度過的半年裡，創作了聖若翰洗者像和什麼?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "沉睡的丘比特"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "佛羅倫薩的主"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "聖殤像"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "大衛像"; //更改no3的test
					DescriptionText.text = "在佛羅倫薩度過的半年裡，他創作了兩件小雕像，一件是幼年的聖若翰洗者像，另一件是沉睡的丘比特。";  //題目答案說明
				}

				//題目201
				else if (randlevel == 201) {
					Question.text = "達文西在1452/04/15出生，1519/??/??死亡?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "05/02"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "04/15"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "01/01"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "10/10"; //更改no3的test
					DescriptionText.text = "李奧納多·達文西(儒略曆1452年4月15日－1519年5月2日)，意為「文西城皮耶羅先生之子」。";  //題目答案說明
				}

				//題目202
				else if (randlevel == 202) {
					Question.text = "米開朗基羅在1475/03/06出生，1564/??/??死亡?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "02/18"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "02/29"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "04/04"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "12/31"; //更改no3的test
					DescriptionText.text = "米開朗基羅(1475年3月6日－1564年2月18日)，是文藝復興時期傑出的通才、雕塑家、建築師、畫家和詩人，與李奧納多·達文西和拉斐爾並稱「文藝復興藝術三傑」。";  //題目答案說明
				}

				//題目203
				else if (randlevel == 203) {
					Question.text = "拉斐爾在1483/??/??出生，1520/04/06死亡?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "04/06"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "02/18"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "05/02"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "06/30"; //更改no3的test
					DescriptionText.text = "拉斐爾·聖齊奧(1483年4月6日－1520年4月6日)，義大利畫家、建築師。與李奧納多·達文西和米開朗基羅合稱「文藝復興藝術三傑」。";  //題目答案說明
				}

				//題目204
				else if (randlevel == 204) {
					Question.text = "拉斐爾1520年高燒猝逝於羅馬，終年37歲，葬於何處?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "萬神廟"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "梵蒂岡"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "雅典學院"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "西斯廷"; //更改no3的test
					DescriptionText.text = "拉斐爾的性情平和、文雅，和他的畫作一樣。拉斐爾於1520年高燒猝逝於羅馬，終年37歲，葬於萬神廟。";  //題目答案說明
				}

				//題目205
				else if (randlevel == 205) {
					Question.text = "拉斐爾的大型壁畫《雅典學院》，畫於何處?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "梵蒂岡"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "羅馬"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "威尼斯"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "佛羅倫斯"; //更改no3的test
					DescriptionText.text = "拉斐爾為梵蒂岡教宗居室創作的大型壁畫《雅典學院》是經典之作，他將柏拉圖和亞里斯多德，將基督教和異教，統統融合在一起。";  //題目答案說明
				}

				//題目206
				else if (randlevel == 206) {
					Question.text = "拉斐爾所繪畫的畫以什麼著稱?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "秀美"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "狂亂"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "安靜"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "寫實"; //更改no3的test
					DescriptionText.text = "拉斐爾所繪畫的畫以「秀美」著稱，畫作中的人物清秀，場景祥和。";  //題目答案說明
				}

				//題目207
				else if (randlevel == 207) {
					Question.text = "「梵蒂岡」一詞來自拉丁語，意為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "先知之地"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "耶穌之地"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "天主之地"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "信仰之地"; //更改no3的test
					DescriptionText.text = "「梵蒂岡」一詞來自拉丁語，意為「先知之地」。";  //題目答案說明
				}

				//題目208
				else if (randlevel == 208) {
					Question.text = "梵蒂岡前的「廣場」名稱為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "聖伯多祿"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "台伯島"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "聖作"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "公教會"; //更改no3的test
					DescriptionText.text = "聖伯多祿廣場，位於梵蒂岡聖伯多祿大殿前，長340公尺，寬240公尺，由貝爾尼尼設計。";  //題目答案說明
				}

				//題目209
				else if (randlevel == 209) {
					Question.text = "下面哪一幅畫拉斐爾沒有完成?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "基督變容"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "披紗女子像"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "聖母的婚禮"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "雅典學院"; //更改no3的test
					DescriptionText.text = "在1520年的春天，已患重病的拉斐爾仍在繪畫《基督變容》，最後因逝世而未能完成。";  //題目答案說明
				}

				//題目210
				else if (randlevel == 210) {
					Question.text = "拉斐爾曾被教皇賜予什麼騎士勳章?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "黃金馬"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "先知"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "聖母子"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "學院"; //更改no3的test
					DescriptionText.text = "拉斐爾被教皇稱為貼身男僕，這也給予他宮廷中的地位及其額外收入，也獲得教皇賜予的黃金馬刺騎士勳章。";  //題目答案說明
				}

				//題目211
				else if (randlevel == 211) {
					Question.text = "《十日談》中什麼是惡魔的代名詞?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "羅馬教會"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "鐵匠"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "貴族"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "市井平民"; //更改no3的test
					DescriptionText.text = "在《十日談》中，羅馬教會教士簡直成了惡魔的代名詞，貪財好色，甚至無惡不作。";  //題目答案說明
				}

				//題目212
				else if (randlevel == 212) {
					Question.text = "《菲洛斯特拉托》這一篇敘事詩又名為?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "愛的摧殘"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "愛的真諦"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "愛的包容"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "愛的開端"; //更改no3的test
					DescriptionText.text = "《菲洛斯特拉托》又名《愛的摧殘》，是用義大利語佛羅倫斯方言寫成的長篇敘事詩，是指被愛情擊倒的人，內容取材於義大利人圭多。";  //題目答案說明
				}

				//題目213
				else if (randlevel == 213) {
					Question.text = "文藝復興的建築風格則以何者為代表?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "坦比哀多教堂"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "聖索菲亞教堂"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "萬神殿"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "台伯島"; //更改no3的test
					DescriptionText.text = "文藝復興全盛期作品有著細緻的刻畫、並有復古的風格。這一時期的建築風格則以羅馬式建築坦比哀多教堂為代表。";  //題目答案說明
				}

				//題目214
				else if (randlevel == 214) {
					Question.text = "文藝復興時期「樂器」和什麼逐漸分離?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "聲樂"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "復調"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "五線譜"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "印刷術"; //更改no3的test
					DescriptionText.text = "這時的音樂家在人文主義思潮的推動下，對復調音樂進行了發展和變革，聲樂與器樂逐漸分離而獨立發展。";  //題目答案說明
				}

				//題目215
				else if (randlevel == 215) {
					Question.text = "文藝復興的美術在哪個世紀達到了鼎盛期?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "16世紀"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "15世紀"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "14世紀"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "17世紀"; //更改no3的test
					DescriptionText.text = "大致發展階段是在14世紀興起，15世紀全面展開，16世紀達到了鼎盛期17世紀後，歐洲美術風格漸漸轉向矯飾主義。";  //題目答案說明
				}

				//題目216
				else if (randlevel == 216) {
					Question.text = "文藝復興時期，哪一項發展成就最大?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "繪畫"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "建築"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "雕刻"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "音樂"; //更改no3的test
					DescriptionText.text = "文藝復興美術是西歐城市文化繁榮的產物，同時它與教會關係密切。在繪畫上的成就最大，建築和雕刻則稍遜之。";  //題目答案說明
				}

				//題目217
				else if (randlevel == 217) {
					Question.text = "《天堂之門》是哪種作品?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "浮雕"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "繪畫"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "音樂"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "建築"; //更改no3的test
					DescriptionText.text = "文藝復興美術是西歐城市文化繁榮的產物，同時它與教會關係密切。在繪畫上的成就最大，建築和雕刻則稍遜之。";  //題目答案說明
				}

				//題目218
				else if (randlevel == 218) {
					Question.text = "拉斐爾將「異教」和哪一教融合在一起?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "基督教"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "天主教"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "猶太教"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "印度教"; //更改no3的test
					DescriptionText.text = "拉斐爾能夠將宗教的虔誠和非宗教的美貌有機地融為一體，將基督教和異教，統統融合在一起，創造出和諧的場面。";  //題目答案說明
				}

				//題目219
				else if (randlevel == 219) {
					Question.text = "米開朗基羅的哪項作品被認為「畫盡了所有的人體」?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "最後的審判"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "大衛像"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "交鑰匙"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "三博士來朝"; //更改no3的test
					DescriptionText.text = "米開朗基羅追求藝術的完美，他的作品《最後的審判》被認為畫盡了所有的人體。";  //題目答案說明
				}

				//題目220
				else if (randlevel == 220) {
					Question.text = "文藝復興的畫壇三傑中，誰是最年長的?";
					CateText.text = "偉人";
					GameObject.Find ("yes").GetComponentInChildren<Text> ().text = "達文西"; //更改yes的test
					GameObject.Find ("no1").GetComponentInChildren<Text> ().text = "米開朗基羅"; //更改no1的test
					GameObject.Find ("no2").GetComponentInChildren<Text> ().text = "拉斐爾"; //更改no2的test
					GameObject.Find ("no3").GetComponentInChildren<Text> ().text = "波提切利"; //更改no3的test
					DescriptionText.text = "由於達文西、米開朗基羅、拉斐爾三人成就極大，這三人被譽為文藝復興三傑。其中達文西最為年長，拉斐爾最年輕。";  //題目答案說明
				}

			//恢復預設***************************************************************************************
			yes1.interactable = true; //按鈕元件 yes設為不可用
			no4.interactable = true; //按鈕元件 yes設為不可用
			no5.interactable = true; //按鈕元件 yes設為不可用
			no6.interactable = true; //按鈕元件 yes設為不可用

			time = 12;
			AllScore.Level1++;          //總共5,7,9,12題,題數+1
		}
	
	  }//問題遊戲執行
		else {
			music.Pause();  //遊戲暫停，音樂暫停
			yes1.interactable = false; //按鈕元件 yes設為不可用
			no4.interactable  = false;  //按鈕元件 yes設為不可用
			no5.interactable  = false;  //按鈕元件 yes設為不可用
			no6.interactable  = false;  //按鈕元件 yes設為不可用
		}
	
	}
	else{
			StartTime = StartTime - Time.deltaTime;   
			StartTimeText.text = "<size=50>生成題目中...</size>\n" + (int)StartTime;
			yes1.interactable = false; //按鈕元件 yes設為不可用
			no4.interactable = false; //按鈕元件 yes設為不可用
			no5.interactable = false; //按鈕元件 yes設為不可用
			no6.interactable = false; //按鈕元件 yes設為不可用
		}

	}//Update結束******************************************************************************************


	//答題正確*******************************************************************
	public void correct()
	{
		//Button設定
		yes1.interactable = false; //按鈕元件 yes設為不可用
		no4.interactable = false;  //按鈕元件 no4設為不可用
		no5.interactable = false;  //按鈕元件 no5設為不可用
		no6.interactable = false;  //按鈕元件 no6設為不可用
		Answer = true;             //已答題
		correctmusic.Play();       //播放正確音效
		DescriptionAniamte.Play(); //如果未答題則播放題目答案說明動畫
		Atime = time;
		ContinousNumber++;                           //連續答對題數+1
		CorrectAnimation.Play();                     //播放正確動畫
		SaveImage.Play();
		ScoreImage.Tempbool = true;

		//計算分數***
		int rand = Random.Range(20, 51);   //產生20~50之間的整數亂數
		if(AllScore.Level == true) {
			AllScore.LevelScore = (AllScore.LevelScore  + ( (int)time * rand )) + rand ; //(連續答對)關卡分數 = 關卡分數 + (剩餘時間 * 亂數) 
			ContinousText.text = "連續答對 " + ContinousNumber + " 題";                  //播放連續Text
			ContinousAnimation.Play();                                                   //播放連續答對動畫
		}
		else AllScore.LevelScore = AllScore.LevelScore  + ( (int)time * rand ) ; //(沒連續答對)關卡分數 = 關卡分數 + (剩餘時間 * 亂數) 

		//商店加分***
		/*if (Store.pintScore == 1)     AllScore.LevelScore = AllScore.LevelScore + 30;
		else if(Store.pintScore == 2) AllScore.LevelScore = AllScore.LevelScore + 50;
		else if(Store.pintScore == 3) AllScore.LevelScore = AllScore.LevelScore + 100;
		else if(Store.pintScore == 4) AllScore.LevelScore = AllScore.LevelScore + 150;
		else if(Store.pintScore == 5) AllScore.LevelScore = AllScore.LevelScore + 200;*/


		AllScore.Level = true;                       //連續答對=true	
		AllScore.LevelCorrect++;                     //答對題數+1
		AllScore.LevelCorrectsum++;                  //總答對題數+1
	}

	//答題錯誤*******************************************************************
	public void fail()
	{
		//Button設定
		yes1.interactable = false;//按鈕元件 yes設為不可用
		no4.interactable = false; //按鈕元件 no4設為不可用
		no5.interactable = false; //按鈕元件 no5設為不可用
		no6.interactable = false; //按鈕元件 no6設為不可用
		Answer = true;            //已答題
		incorrectmusic.Play();    //播放錯誤音效
		DescriptionAniamte.Play(); //如果未答題則播放題目答案說明動畫
		Atime = time;
		ContinousNumber = 0;       //連續答對題數 = 0
		IncorrectAnimation.Play(); //播放錯誤動畫
		SaveImage.Play();

		//答錯分數
		int  randw = Random.Range(20, 51);   //產生20~50之間的整數亂數
		AllScore.LevelWorstScore =  (AllScore.LevelWorstScore  + ( 12 - ((int)time * randw) )) + randw ; //(連續答對)關卡分數 = 關卡分數 + (剩餘時間 * 亂數) 

		//答錯
		AllScore.LevelMistake++;    //答錯題數+1
		AllScore.LevelMistakesum++; //總答錯題數+1
		AllScore.Level = false;     //連續答對=false
	}

	//中途回到難度選擇**************************************************************
	public void Back(){
		ButtonMusic.Play ();
		FadeOut.SetActive (true);
	}


}
