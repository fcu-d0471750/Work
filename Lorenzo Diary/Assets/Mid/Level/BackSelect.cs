using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class BackSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Back(){
		AllScore.Level1 = 0;                    //關卡數恢復初始值
		Application.LoadLevel("selectscreen");  //切到難度選擇畫面  
	}


}
