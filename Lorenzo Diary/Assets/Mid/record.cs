using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class record : MonoBehaviour {

	//宣告變數
	public  AudioSource music;          //音樂
	public Text CorrectsumText = null;  //總正確題數
	public Text MistakesumText = null;  //總錯誤題數
	public Text SText = null;           //評價次數
	public Text AText = null;           //評價次數
	public Text BText = null;           //評價次數
	public Text CText = null;           //評價次數
	public Text DText = null;           //評價次數
	public Text EText = null;           //評價次數
	public AudioSource ButtonMusic;     //按扭音效
	float timef;                        //時間
	// Use this for initialization
	void Start () {
		//音樂
		if(Musicbotton.musicplay == true) music.Play();  //如果開始畫面音效被開啟,音樂播放
		else music.Pause();                              //如果開始畫面音效被關閉,音樂暫停
		music.volume = Musicbotton.MusicVo;
		CorrectsumText.text = "總答對題數: " + AllScore.LevelCorrectsum;       //顯示總答對數 
		MistakesumText.text = "總答錯題數: " + AllScore.LevelMistakesum;       //顯示總答錯數
		SText.text = "<color=#FFFAB9>S</color> " +  AllScore.S;
		AText.text = "<color=#BBBBBB>A</color> " +  AllScore.A;
		BText.text = "<color=#F1AD63>B</color> " +  AllScore.B;
		CText.text = "<color=#C1F9FF>C</color> " +  AllScore.C;
		DText.text = "<color=#FF6767>D</color> " +  AllScore.D;
		EText.text = "E " +  AllScore.E;

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
	}

	//主選單
	public void Home()
	{
		ButtonMusic.Play ();
		Application.LoadLevel("startscreen");  //切換主選單  
	}
}
