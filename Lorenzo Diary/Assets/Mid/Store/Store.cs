using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class Store : MonoBehaviour {

	//分數
	public Text Score1;        //分數text
	public Text Score2;        //分數text
	public Button  Score;      //分數按鈕
	int intScore=1;            //分數購買次數
	public static int pintScore=0;  //判斷是否購買(給使用)
	//答對
	public Text Correct1;        //答對text
	public Text Correct2;        //答對text
	public Button  Correct;      //答對按鈕
	int intCorrect=1;            //答對購買次數
	public static int pintCorrect=0;   //判斷是否購買
	//答錯
	public Text Mistake1;        //答錯text
	public Text Mistake2;        //答錯text
	public Button  Mistake;      //答錯按鈕
	int intMistake=1;            //答錯購買次數
	public static int pintMistake=0;  //判斷是否購買


	//額外
	public Text Correctsum = null;       //總答對數
	public Text Mistakesum = null;       //總答錯數
	public AudioSource music;            //音樂
	public AudioSource ButtonMusic;            //按扭音效
//=====================================================================================================
	// Use this for initialization
	void Start () {
		intScore = PlayerPrefs.GetInt("intScore1");
		pintScore = PlayerPrefs.GetInt("pintScore");

		intCorrect = PlayerPrefs.GetInt("intCorrect");
	    pintCorrect = PlayerPrefs.GetInt("pintCorrect");

		intMistake = PlayerPrefs.GetInt("intMistake");
		pintMistake = PlayerPrefs.GetInt("pintMistake");

		Correctsum.text = "總答對題數: " + AllScore.LevelCorrectsum;       //顯示總答對數 
		Mistakesum.text = "總答錯題數: " + AllScore.LevelMistakesum;       //顯示總答錯數

		//音樂
		if(Musicbotton.musicplay == true)music.Play();  //如果開始畫面音效被開啟,音樂播放
		else music.Pause();                              //如果開始畫面音效被關閉,音樂暫停



	}
	
	// Update is called once per frame
	void Update () {
		//分數========================================================================================
		if (intScore == 1) Score1.text = "分數提升LvI   (達對時分數增加30)";
		if (intScore == 1) Score2.text = "總達對題數10可購買";
		if (intScore == 2) Score1.text = "分數提升LvII   (達對時分數增加50)";
		if (intScore == 2) Score2.text = "總達對題數100可購買";
		if (intScore == 3) Score1.text = "分數提升LvIII   (達對時分數增加100)";
		if (intScore == 3) Score2.text = "總達對題數200可購買";
		if (intScore == 4) Score1.text = "分數提升LvIV   (達對時分數增加150)";
		if (intScore == 4) Score2.text = "總達對題數500可購買";
		if (intScore == 5) Score1.text = "分數提升LvV   (達對時分數增加200)";
		if (intScore == 5) Score2.text = "總達對題數1000可購買";
		if (intScore == 6) Score1.text = "已售完";
		if (intScore == 6) Score2.text = " ";
			
		if (intScore == 1 && AllScore.LevelCorrectsum >= 10) {
			Score.interactable = true;	
		} else if (intScore == 2 && AllScore.LevelCorrectsum >= 100) {
			Score.interactable = true;

		} else if (intScore == 3 && AllScore.LevelCorrectsum >= 200) {
			Score.interactable = true;
		}
		else if (intScore == 4 && AllScore.LevelCorrectsum >= 500) {
			Score.interactable = true;
		}
		else if (intScore == 5 && AllScore.LevelCorrectsum >= 1000) {
			Score.interactable = true;
		}
		else Score.interactable = false;

       //答對=========================================================================================
		if (intCorrect == 1) Correct1.text = "答對提升LvI   (總達對題數+1)";
		if (intCorrect == 1) Correct2.text = "總達對題數500可購買";
		if (intCorrect == 2) Correct1.text = "答對提升LvII   (總達對題數+2)";
		if (intCorrect == 2) Correct2.text = "總達對題數1000可購買";
		if (intCorrect == 3) Correct1.text = "答對提升LvIII   (總達對題數+3)";
		if (intCorrect == 3) Correct2.text = "總達對題數3000可購買";
		if (intCorrect == 4) Correct1.text = "答對提升LvIV   (總達對題數+4)";
		if (intCorrect == 4) Correct2.text = "總達對題數4000可購買";
		if (intCorrect == 5) Correct1.text = "答對提升LvV   (總達對題數+5)";
		if (intCorrect == 5) Correct2.text = "總達對題數5000可購買";
		if (intCorrect == 6) Correct1.text = "已售完";
		if (intCorrect == 6) Correct2.text = " ";

		if (intCorrect == 1 && AllScore.LevelCorrectsum >= 500) {
			Correct.interactable = true;	
		} else if (intCorrect == 2 && AllScore.LevelCorrectsum >= 1000) {
			Correct.interactable = true;
		} else if (intCorrect == 3 && AllScore.LevelCorrectsum >= 3000) {
			Correct.interactable = true;
		}
		else if (intCorrect == 4 && AllScore.LevelCorrectsum >= 4000) {
			Correct.interactable = true;
		}
		else if (intCorrect == 5 && AllScore.LevelCorrectsum >= 5000) {
			Correct.interactable = true;
		}
		else Correct.interactable = false;
	   //答錯=========================================================================================
		if (intMistake == 1) Mistake1.text = "答錯提升LvI   (總達錯題數+1)";
		if (intMistake == 1) Mistake2.text = "總達錯題數100可購買";
		if (intMistake == 2) Mistake1.text = "答錯提升LvII   (總達錯題數+2)";
		if (intMistake == 2) Mistake2.text = "總達錯題數500可購買";
		if (intMistake == 3) Mistake1.text = "答錯提升LvIII   (總達錯題數+3)";
		if (intMistake == 3) Mistake2.text = "總達錯題數1000可購買";
		if (intMistake == 4) Mistake1.text = "答錯提升LvIV   (總達錯題數+4)";
		if (intMistake == 4) Mistake2.text = "總達錯題數2000可購買";
		if (intMistake == 5) Mistake1.text = "答錯提升LvV   (總達錯題數+5)";
		if (intMistake == 5) Mistake2.text = "總達錯題數3000可購買";
		if (intMistake == 6) Mistake1.text = "已售完";
		if (intMistake == 6) Mistake2.text = " ";

		if (intMistake == 1 && AllScore.LevelMistakesum >= 100) {
			Mistake.interactable = true;	
		} else if (intMistake == 2 && AllScore.LevelMistakesum >= 500) {
			Mistake.interactable = true;
		} else if (intMistake == 3 && AllScore.LevelMistakesum >= 1000) {
			Mistake.interactable = true;
		}
		else if (intMistake == 4 && AllScore.LevelMistakesum >= 2000) {
			Mistake.interactable = true;
		}
		else if (intMistake == 5 && AllScore.LevelMistakesum >= 3000) {
			Mistake.interactable = true;
		}
		else Mistake.interactable = false;

       //儲存=========================================================================================
		PlayerPrefs.SetInt("intScore1", intScore);
		PlayerPrefs.Save();  
		PlayerPrefs.SetInt("pintScore", pintScore);
		PlayerPrefs.Save();  

		PlayerPrefs.SetInt("intCorrect", intCorrect);
		PlayerPrefs.Save();  
		PlayerPrefs.SetInt("pintCorrect", pintCorrect);
		PlayerPrefs.Save();  

		PlayerPrefs.SetInt("intMistake", intMistake);
		PlayerPrefs.Save();  
		PlayerPrefs.SetInt("pintMistake", pintMistake);
		PlayerPrefs.Save();  
	}

	//分數購買***************************************************************************************
	public void ScoreButton()
	{
		ButtonMusic.Play ();

		if(intScore==1)pintScore = 1;
		else if(intScore==2)pintScore = 2;
		else if(intScore==3)pintScore = 3;
		else if(intScore==4)pintScore = 4;
		else if(intScore==5)pintScore = 5;

		intScore++;
	} 

	//答對購買***************************************************************************************
	public void CorrectButton()
	{
		ButtonMusic.Play ();

		if(intCorrect==1)pintCorrect = 1;
		else if(intCorrect==2)pintCorrect = 2;
		else if(intCorrect==3)pintCorrect = 3;
		else if(intCorrect==4)pintCorrect = 4;
		else if(intCorrect==5)pintCorrect = 5;

		intCorrect++;
	} 

	//答錯購買***************************************************************************************
	public void MistakeButton()
	{
		ButtonMusic.Play ();

		if(intMistake==1)pintMistake = 1;
		else if(intMistake==2)pintMistake = 2;
		else if(intMistake==3)pintMistake = 3;
		else if(intMistake==4)pintMistake = 4;
		else if(intMistake==5)pintMistake = 5;


		intMistake++;
	} 


	//主選單*****************************************************************************************
	public void Home()
	{
		ButtonMusic.Play ();



		Application.LoadLevel("startscreen");  //切換主選單  
	}
}
