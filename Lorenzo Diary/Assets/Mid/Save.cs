using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour {
	public static int nInt;

	void Start () {
		
	}

	public static void Saves() {
		//PlayerPrefs.SetInt("Key01", 0);
		//PlayerPrefs.Save(); //加上這步驟後，存檔就完成了
		//PlayerPrefs.SetString("Key02", "Hellow");
		//PlayerPrefs.SetFloat("key03", 5.5f);
	}

	public static void Load() {
		//PlayerPrefs.GetInt("Key01");
		//string sString = PlayerPrefs.GetString("Key02");
		//float fNum = PlayerPrefs.GetFloat("Key03");

		//Debug.Log("nInt: " + nInt.ToString() + ", sString: " + sString + ", fNum: " + fNum.ToString());
	}
}
