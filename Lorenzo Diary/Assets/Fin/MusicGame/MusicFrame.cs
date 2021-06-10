//音樂符號
using UnityEngine;
using System.Collections;
using UnityEngine.UI; //使用UI

public class MusicFrame : MonoBehaviour { 

	// |20 21 22 23    24 25 26 27 28    29 30 31 32 33 34 35 36 37 38    39 40 41 42 43    44 45 46 47 48|9 10 10 4 5 5
	//宣告變數
	public GameObject DestoryPart;   //銷毀粒子

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!MusicGame.MusicPause)gameObject.transform.position += new Vector3(0,-0.018f,0); //不斷向下移動 數字越大下降越快
	}

	//Bar碰到音樂符號
	void OnTriggerStay2D(Collider2D Col)
	{
		//上
		if (gameObject.tag=="MusicUP" && Col.tag == "MusicBar" && MusicGame.Directionstate == 1) {
			Instantiate (DestoryPart, gameObject.transform.position, gameObject.transform.rotation);	//銷毀粒子
			Destroy(gameObject);//消滅物件本身
		} 
		else if (gameObject.tag=="MusicDown" && Col.tag == "MusicBar" && MusicGame.Directionstate == 2) {//下
			Instantiate (DestoryPart, gameObject.transform.position, gameObject.transform.rotation);	//銷毀粒子
			Destroy(gameObject);//消滅物件本身
		} 
		else if (gameObject.tag=="MusicLeft" && Col.tag == "MusicBar" && MusicGame.Directionstate == 3) {//左
			Instantiate (DestoryPart, gameObject.transform.position, gameObject.transform.rotation);	//銷毀粒子
			Destroy(gameObject);//消滅物件本身
		} 
		else if (gameObject.tag=="MusicRight" && Col.tag == "MusicBar" && MusicGame.Directionstate == 4) {//右
			Instantiate (DestoryPart, gameObject.transform.position, gameObject.transform.rotation);	//銷毀粒子
			Destroy(gameObject);//消滅物件本身
		}
		else if (gameObject.tag=="MusicSpace" && Col.tag == "MusicBar" && MusicGame.Directionstate == 5) {//中間
			Instantiate (DestoryPart, gameObject.transform.position, gameObject.transform.rotation);	//銷毀粒子
			Destroy(gameObject);//消滅物件本身
		}
		//else print ("Miss" + transform.localPosition.y);

		//超過MusicBar
		if(Col.tag == "Destroy"){
			MusicGame.Combo = 0;
			MusicGame.MissCount++;
			MusicGame.MissBool = true;
			Instantiate (DestoryPart, gameObject.transform.position, gameObject.transform.rotation);	//銷毀粒子
			Destroy(gameObject);
		}


	} 
}
