//背景計算各區域的經營時間
using UnityEngine;
using System.Collections;

public class ManageTime : MonoBehaviour {

  //宣告變數====================================================================
	//麵包師傅的經營時間*********
	//用於計算1秒
	float Bread_Count_Time = 0.0f;
	//幾秒加1%進度
	float Bread_Max_Time = 1.0f;
	//音樂人的經營時間*********
	//用於計算3秒
	float Music_Count_Time = 0.0f;   
	//幾秒加1%進度
	float Music_Max_Time = 3.0f;
	//科技新貴的經營時間*********
	//用於計算5秒
	float Tehcnology_Count_Time = 0.0f;   
	//幾秒加1%進度
	float Tehcnology_Max_Time = 5.0f;
	//機工的經營時間*********
	//用於計算7秒
	float Factory_Count_Time = 0.0f;   
	//幾秒加1%進度
	float Factory_Max_Time = 7.0f;
	//銀行家的經營時間*********
	//用於計算10秒
	float Economic_Count_Time = 0.0f;   
	//幾秒加1%進度
	float Economic_Max_Time = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//(麵包師傅區域)
		//不可經營狀態 && 至少擁有1間店
		if (!MainState.BreadArea.GetManage () && MainState.BreadArea.GetStoreNumber () >= 1 && MainState.BreadArea.GetManageTime () < 100.0f) {
			//計算經營時間
			Bread_Count_Time = Bread_Count_Time + Time.deltaTime;
			//過1秒
			if (Bread_Count_Time >= Bread_Max_Time) {
				//設定經營時間
				MainState.BreadArea.SetManageTime ((MainState.BreadArea.GetManageTime() + 100.0f));
				Bread_Count_Time = 0.0f;
			}
		}

		//(音樂人區域)
		//不可經營狀態 && 至少擁有1間店
		if (!MainState.MusicArea.GetManage () && MainState.MusicArea.GetStoreNumber () >= 1 && MainState.MusicArea.GetManageTime () < 100.0f) {
			//計算經營時間
			Music_Count_Time = Music_Count_Time + Time.deltaTime;
			//過1秒
			if (Music_Count_Time >= Music_Max_Time) {
				//設定經營時間
				MainState.MusicArea.SetManageTime ((MainState.MusicArea.GetManageTime() + 1.0f));
				Music_Count_Time = 0.0f;
			}
		}

		//(科技新貴傅區域)
		//不可經營狀態 && 至少擁有1間店
		if (!MainState.TehcnologyArea.GetManage () && MainState.TehcnologyArea.GetStoreNumber () >= 1 && MainState.TehcnologyArea.GetManageTime () < 100.0f) {
			//計算經營時間
			Tehcnology_Count_Time = Tehcnology_Count_Time + Time.deltaTime;
			//過1秒
			if (Tehcnology_Count_Time >= Tehcnology_Max_Time) {
				//設定經營時間
				MainState.TehcnologyArea.SetManageTime ((MainState.TehcnologyArea.GetManageTime() + 1.0f));
				Tehcnology_Count_Time = 0.0f;
			}
		}

		//(機工區域)
		//不可經營狀態 && 至少擁有1間店
		if (!MainState.FactoryArea.GetManage () && MainState.FactoryArea.GetStoreNumber () >= 1 && MainState.FactoryArea.GetManageTime () < 100.0f) {
			//計算經營時間
			Factory_Count_Time = Factory_Count_Time + Time.deltaTime;
			//過1秒
			if (Factory_Count_Time >= Factory_Max_Time) {
				//設定經營時間
				MainState.FactoryArea.SetManageTime ((MainState.FactoryArea.GetManageTime() + 1.0f));
				Factory_Count_Time = 0.0f;
			}
		}

		//(銀行家區域)
		//不可經營狀態 && 至少擁有1間店
		if (!MainState.EconomicArea.GetManage () && MainState.EconomicArea.GetStoreNumber () >= 1 && MainState.EconomicArea.GetManageTime () < 100.0f) {
			//計算經營時間
			Economic_Count_Time = Economic_Count_Time + Time.deltaTime;
			//過1秒
			if (Economic_Count_Time >= Economic_Max_Time) {
				//設定經營時間
				MainState.EconomicArea.SetManageTime ((MainState.EconomicArea.GetManageTime() + 1.0f));
				Economic_Count_Time = 0.0f;
			}
		}


	}



}
