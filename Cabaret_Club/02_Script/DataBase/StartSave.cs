/*
 * 存檔，用於被繼承給其它存檔，讓繼承的class可以自由撰寫存檔、讀檔的方法
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StartSave : MonoBehaviour {

     public SaveGame_Class Sav = new SaveGame_Class();

    //============
    //副程式:存檔
    //============
    public void DoSave(){
       
    }

    //============
    //副程式:讀檔
    //============
    public void DoLoad(){
       
    }
  
    /*
    //存檔類別****************
    SaveGame_Class Sav = new SaveGame_Class();

	//UI
	public Text Score_1;
	public Text Score_2;
	public Text hp;
	public Text Name;
	public Image Icon;
	public Sprite[] Icon_Picture;

	// Use this for initialization
	void Start () {
		

	}//Start
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Sav.Score [0]++;
			Sav.Score [1]--;
			//Sav.hp = Sav.hp + 0.3f;
			Sav.Name = Sav.Name + "o";
			print ("功");
		}


		if (Input.GetKeyDown (KeyCode.S))
			DoSave ();

		if (Input.GetKeyDown (KeyCode.L))
			DoLoad ();
	}//Update

	//副程式:存檔
	void DoSave(){
		PlayerPrefs.SetString ("SaveFile_1", JsonUtility.ToJson (Sav));
		print (PlayerPrefs.GetString("SaveFile_1"));
		print ("存檔成功");
	}

	//副程式:讀檔
	void DoLoad(){
		JsonUtility.FromJsonOverwrite (PlayerPrefs.GetString("SaveFile_1") , Sav);
		Score_1.text = Sav.Score[0] + ""; 
		Score_2.text = Sav.Score[1] + ""; 
		hp.text = Sav.hp + "";
		Name.text = Sav.Name + "";
		Icon.sprite = Icon_Picture [Sav.icon];

		print ("讀檔成功");
	}
    */


}//StartSave
