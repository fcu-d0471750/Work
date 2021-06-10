using UnityEngine;
using System.Collections;

public class AllScore : MonoBehaviour {

	//宣告變數********
	public static float  LevelScore = 0;   //遊戲答對分數
	public static float  LevelWorstScore = 0;   //遊戲答錯分數
	public static int  LevelCorrect = 0;   //答對題數
	public static int  LevelMistake = 0;   //答錯題數
	public static int  LevelCorrectsum = 0;  //總答對題數
	public static int  LevelMistakesum = 0;  //總答錯題數
	public static bool Level = false;     //是否連續答對 true:連續答對 false:答錯
	public static int  Level1 = 0;       //總共5關
	public static int  S = 0;    //紀錄評價次數
	public static int  A = 0;
	public static int  B = 0;
	public static int  C = 0;
	public static int  D = 0;
	public static int  E = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
