using UnityEngine;
using System.Collections;

public class StoryFadeout : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//返回===========================================================================================================
	public void Back(){
		Application.LoadLevelAsync ("Main");  //回到主畫面
	}

}
