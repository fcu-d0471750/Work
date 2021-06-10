//Unity FireBase 使用 
using UnityEngine;
using System.Collections;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections.Generic;

public class FireBase_Script : MonoBehaviour {

	//宣告FireBase===============================================================================================
	//讀取資料位置***************************
	DatabaseReference reference;
	//讀取資料的資料庫*******************************
	DataSnapshot snapshot;

	//bool==============================================================================================
	//是否讀完全部資料 true:已讀完 false:未讀完******
	public static bool FireBase_Read_Bool = false;

    //============================================
    // Use this for initialization
    //============================================
    void Awake () {
        Home_Page.aaa = 5;
        FireBase_Read_Bool = true;
        //1. 初始化FireBase=======================================================================================
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
			var dependencyStatus = task.Result;
			if (dependencyStatus == Firebase.DependencyStatus.Available) {
                // Set a flag here indiciating that Firebase is ready to use by your
                // application.
                Home_Page.aaa = 6;
                print("6");
                FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://unityandroid-53004.firebaseio.com/");
                Home_Page.aaa = 9;

                //3. 將上面資料庫的位置放入reference========================================================================
                reference = FirebaseDatabase.DefaultInstance.RootReference;

                //以下為開始使用資料庫======================================================================================
                //==========================================================================================================


                //副程式:讀取全部資料(一次只能使用一個)====================================================


                Read_Once_Data();

            } else {
				UnityEngine.Debug.LogError(System.String.Format(
					"Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
                Home_Page.aaa = 7;
                print("7");
            }
		});
        Home_Page.aaa = 8;
        //2. 讀取資料的位置========================================================================================
      
        Home_Page.aaa = 12;
        
        //讀完全部資料

        //副程式:讀取全部資料並排序(一次只能使用一個)====================================================
        //Read_Once_Data_Order();
        //副程式:讀取特定資料並排序(一次只能使用一個)====================================================
        //Read_Once_Data_Order_Spec();

        //修改資料========================================================================================
        //writeNewUser("aaaa", "sdssd");

    }

    //============================================
    // Update is called once per frame
    //============================================
    void Update () {
		/*if (FireBase_Read_Bool == true) {
			
			print (DataManage.Constellation [5].Getter_EName ());
		}*/
	}


    //============================================
    //副程式:讀取全部資料====================================================
    //============================================
    void Read_Once_Data(){
		FirebaseDatabase.DefaultInstance.GetReference("").GetValueAsync().ContinueWith(task => {
			//讀取資料失敗
			if (task.IsFaulted) {
				print("ERROR");
                Home_Page.aaa = 3;

            }
			//讀取資料成功
			else if (task.IsCompleted) {
				//unityandroid-53004
				snapshot = task.Result;
				// 用snapshot開始使用讀取到的資料=============================================
				//print(snapshot.Child("9").Child("Name").Value.ToString());

				//Ds為某1筆Key(snapshot.ChildrenCount = 總共幾筆資料)
				for(int i=0; i<snapshot.ChildrenCount; i++){
					
					//儲存每一筆Key*********************************
					DataSnapshot Ds;
					//Ds為某1筆Key
					Ds = snapshot.Child(i.ToString());
					//副程式:星座資料放入類別中(儲存第Number筆資料 , 第幾筆)
					if(i<=11)Constellation_Read (Ds , i);
					//副程式:分類法資料放入類別中(儲存第Number筆資料 , 第幾筆)
					else if(i>=12 && i<=14) Separate_Read (Ds , i);
					//副程式:宮位資料放入類別中
					else if(i==15) Palace_Read(Ds , i);
					//副程式:行星資料放入類別中
					else if(i==16) Planet_Read(Ds , i);

				}

			
			}
		});
		//讀完全部資料
		FireBase_Read_Bool = true;
        Home_Page.aaa = 2;
        print("讀完全部資料: " + FireBase_Read_Bool);
	}

    /*//副程式:讀取全部資料並排序====================================================
	void Read_Once_Data_Order(){
		//讀取資料並排序
		FirebaseDatabase.DefaultInstance.GetReference("").OrderByKey().ValueChanged += HandleValueChanged;
	}

	//副程式:讀取特定資料並排序====================================================
	void Read_Once_Data_Order_Spec(){
		//讀取特定資料並排序
		FirebaseDatabase.DefaultInstance.GetReference("").OrderByChild("Class").EqualTo("3").ValueChanged += HandleValueChanged;
	}

	//監聽處理================================================================================================
	void HandleValueChanged(object sender, ValueChangedEventArgs args) {
		if (args.DatabaseError != null) {
			Debug.LogError(args.DatabaseError.Message);
			return;
		}
		//使用args.Snapshot開始使用讀取到的資料
		print(args.Snapshot.ChildrenCount);
	}



	//副程式:改寫資料==============================================================================================
	private void writeNewUser(string name, string email) {
		User user = new User(name, email);
		string json = JsonUtility.ToJson(user);

		//將reference這個位置的子節點214的子節點Add的值改為name
		reference.Child ("214").Child ("Add").SetValueAsync (name);
	}*/


    //============================================
    //副程式:將JSON的整數轉成可使用的整數，不能直接用JSON的整數，所以要轉換
    //============================================
    public int JSON_StringToInt(string S){
		int intValue = int.Parse(S);
		return intValue;
	}


    //============================================
    //副程式:星座資料放入類別中(儲存第Number筆資料 , 第幾筆)============================================================================================
    //============================================
    void Constellation_Read(DataSnapshot Ds , int Number){
    

		//處理月份日期
		string M1 = Ds.Child("Month1").Value.ToString();
		int Month1 = JSON_StringToInt(M1);
		string M2 = Ds.Child("Month2").Value.ToString();
		int Month2 = JSON_StringToInt(M2);
		string D1 = Ds.Child("Day1").Value.ToString();
		int Day1 = JSON_StringToInt(D1);
		string D2 = Ds.Child("Day2").Value.ToString();
		int Day2 = JSON_StringToInt(D2);

		//星座名稱
		string Name = Ds.Child("Name").Value.ToString();
		//星座英文名稱
		string EName =  Ds.Child("EName").Value.ToString();
		//星座分類1
		string Class1 =  Ds.Child("Class1").Value.ToString();
		//星座分類2
		string Class2 = Ds.Child("Class2").Value.ToString();
		//星座分類3
		string Class3 =  Ds.Child("Class3").Value.ToString();
		//星座節氣
		string SolarTerms =  Ds.Child("SolarTerms").Value.ToString();
		//星座守護星
		string Planet = Ds.Child("Planet").Value.ToString();
		//星座守護神
		string God = Ds.Child("God").Value.ToString();
		//星座黃道十二宮
		string Zodiac =  Ds.Child("Zodiac").Value.ToString();
		//星座宮位
		string Palace = Ds.Child("Palace").Value.ToString();
		//星座符號
		string Symbol =  Ds.Child("Symbol").Value.ToString();
		//星座優點
		string Advantage = Ds.Child("Advantage").Value.ToString();
		//星座缺點
		string Disadvantage =  Ds.Child("DisAdvantage").Value.ToString();
		//星座個人特質
		string Personality =  Ds.Child("Personality").Value.ToString();

		//本地端資料存檔
		//DataManage.Constellations_Class_Save(Number , DataManage.Constellations_Save_String , Name , EName , Month1 , Day1 , Month2 , Day2 ,  Class1 , Class2, Class3, SolarTerms,Planet ,God , Zodiac , Palace,Symbol,Advantage ,Disadvantage , Personality);
		//讀取本地端資料
		//DataManage.Constellations_Class_Save_Write(Number);

		//放入資料		
		DataManage.Constellation[Number] = new Constellations_Class (Name , EName , Month1 , Day1 , Month2 , Day2 ,  Class1 , Class2, Class3, SolarTerms,Planet ,God , Zodiac , Palace,Symbol,Advantage ,Disadvantage , Personality);

	}

    //============================================
    //副程式:分類法資料放入類別中(儲存第Number筆資料 , 第幾筆)============================================================================================
    //============================================
    void Separate_Read(DataSnapshot Ds , int Number){
		

		if (Number == 12) {
			string Name = Ds.Child("Name").Value.ToString();
			string Class1 = Ds.Child ("Class1").Value.ToString ();
			string Constellation1  = Ds.Child ("Constellation1").Value.ToString ();
			string Description1 = Ds.Child ("Description1").Value.ToString ();
			string Class2 = Ds.Child ("Class1").Value.ToString ();
			string Constellation2  = Ds.Child ("Constellation2").Value.ToString ();
			string Description2 = Ds.Child ("Description1").Value.ToString ();

			DataManage.Two_Separate [0] = new Separate_Class_ ( Name , Class1 , Constellation1 , Description1);
			DataManage.Two_Separate [1] = new Separate_Class_ ( Name , Class2 , Constellation2 , Description2);

			//本地端資料存檔
			//DataManage.Two_Separate_Save(0 , DataManage.Two_Separate_Save_String , Name , Class1 , Constellation1 , Description1);
			//DataManage.Two_Separate_Save(1 , DataManage.Two_Separate_Save_String ,  Name , Class2 , Constellation2 , Description2);
			//讀取本地端資料
			//DataManage.Two_Separate_Save_Write(0);
			//DataManage.Two_Separate_Save_Write(1);


		} else if (Number == 13) {
			string Name = Ds.Child("Name").Value.ToString();
			string Class1 = Ds.Child ("Class1").Value.ToString ();
			string Constellation1  = Ds.Child ("Constellation1").Value.ToString ();
			string Description1 = Ds.Child ("Description1").Value.ToString ();

			string Class2 = Ds.Child ("Class1").Value.ToString ();
			string Constellation2  = Ds.Child ("Constellation2").Value.ToString ();
			string Description2 = Ds.Child ("Description1").Value.ToString ();

			string Class3 = Ds.Child ("Class3").Value.ToString ();
			string Constellation3  = Ds.Child ("Constellation3").Value.ToString ();
			string Description3 = Ds.Child ("Description3").Value.ToString ();
		
			DataManage.Three_Separate [0] = new Separate_Class_ ( Name , Class1 , Constellation1 , Description1);
			DataManage.Three_Separate [1] = new Separate_Class_ ( Name , Class2 , Constellation2 , Description2);
			DataManage.Three_Separate [2] = new Separate_Class_ ( Name , Class3 , Constellation3 , Description3);

			//本地端資料存檔
			//DataManage.Three_Separate_Save(0 , DataManage.Three_Separate_Save_String , Name , Class1 , Constellation1 , Description1);
			//DataManage.Three_Separate_Save(1 , DataManage.Three_Separate_Save_String ,  Name , Class2 , Constellation2 , Description2);
			//DataManage.Three_Separate_Save(2 , DataManage.Three_Separate_Save_String ,  Name , Class3 , Constellation3 , Description3);
			//讀取本地端資料
			//DataManage.Three_Separate_Save_Write(0);
			//DataManage.Three_Separate_Save_Write(1);
			//DataManage.Three_Separate_Save_Write(2);

		} else if (Number == 14) {
			string Name = Ds.Child("Name").Value.ToString();
			string Class1 = Ds.Child ("Class1").Value.ToString ();
			string Constellation1  = Ds.Child ("Constellation1").Value.ToString ();
			string Description1 = Ds.Child ("Description1").Value.ToString ();

			string Class2 = Ds.Child ("Class1").Value.ToString ();
			string Constellation2  = Ds.Child ("Constellation2").Value.ToString ();
			string Description2 = Ds.Child ("Description1").Value.ToString ();

			string Class3 = Ds.Child ("Class3").Value.ToString ();
			string Constellation3  = Ds.Child ("Constellation3").Value.ToString ();
			string Description3 = Ds.Child ("Description3").Value.ToString ();

			string Class4 = Ds.Child ("Class4").Value.ToString ();
			string Constellation4  = Ds.Child ("Constellation4").Value.ToString ();
			string Description4 = Ds.Child ("Description4").Value.ToString ();

			DataManage.Four_Separate [0] = new Separate_Class_ ( Name , Class1 , Constellation1 , Description1);
			DataManage.Four_Separate [1] = new Separate_Class_ ( Name , Class2 , Constellation2 , Description2);
			DataManage.Four_Separate [2] = new Separate_Class_ ( Name , Class3 , Constellation3 , Description3);
			DataManage.Four_Separate [3] = new Separate_Class_ ( Name , Class4 , Constellation4 , Description4);

			//本地端資料存檔
			//DataManage.Four_Separate_Save(0 , DataManage.Four_Separate_Save_String , Name , Class1 , Constellation1 , Description1);
			//DataManage.Four_Separate_Save(1 , DataManage.Four_Separate_Save_String ,  Name , Class2 , Constellation2 , Description2);
			//DataManage.Four_Separate_Save(2 , DataManage.Four_Separate_Save_String ,  Name , Class3 , Constellation3 , Description3);
			//DataManage.Four_Separate_Save(3 , DataManage.Four_Separate_Save_String ,  Name , Class4 , Constellation4 , Description4);
			//讀取本地端資料
			//DataManage.Four_Separate_Save_Write(0);
			//DataManage.Four_Separate_Save_Write(1);
			//DataManage.Four_Separate_Save_Write(2);
			//DataManage.Four_Separate_Save_Write(3);
		}
	}

    //============================================
    //副程式:宮位資料放入類別中============================================================================================
    //============================================
    void Palace_Read(DataSnapshot Ds , int Number){
		
		string Class1 = Ds.Child ("Class1").Value.ToString ();
		string Class2 = Ds.Child ("Class2").Value.ToString ();
		string Class3 = Ds.Child ("Class3").Value.ToString ();
		string Class4 = Ds.Child ("Class4").Value.ToString ();
		string Class5 = Ds.Child ("Class5").Value.ToString ();
		string Class6 = Ds.Child ("Class6").Value.ToString ();
		string Class7 = Ds.Child ("Class7").Value.ToString ();
		string Class8 = Ds.Child ("Class8").Value.ToString ();
		string Class9 = Ds.Child ("Class9").Value.ToString ();
		string Class10 = Ds.Child ("Class10").Value.ToString ();
		string Class11 = Ds.Child ("Class11").Value.ToString ();
		string Class12 = Ds.Child ("Class12").Value.ToString ();

		string Palace1 = Ds.Child ("Palace1").Value.ToString ();
		string Palace2 = Ds.Child ("Palace2").Value.ToString ();
		string Palace3 = Ds.Child ("Palace3").Value.ToString ();
		string Palace4 = Ds.Child ("Palace4").Value.ToString ();
		string Palace5 = Ds.Child ("Palace5").Value.ToString ();
		string Palace6 = Ds.Child ("Palace6").Value.ToString ();
		string Palace7 = Ds.Child ("Palace7").Value.ToString ();
		string Palace8 = Ds.Child ("Palace8").Value.ToString ();
		string Palace9 = Ds.Child ("Palace9").Value.ToString ();
		string Palace10 = Ds.Child ("Palace10").Value.ToString ();
		string Palace11 = Ds.Child ("Palace11").Value.ToString ();
		string Palace12 = Ds.Child ("Palace12").Value.ToString ();

		string Constellation1 = Ds.Child ("Constellation1").Value.ToString ();
		string Constellation2 = Ds.Child ("Constellation2").Value.ToString ();
		string Constellation3 = Ds.Child ("Constellation3").Value.ToString ();
		string Constellation4 = Ds.Child ("Constellation4").Value.ToString ();
		string Constellation5 = Ds.Child ("Constellation5").Value.ToString ();
		string Constellation6 = Ds.Child ("Constellation6").Value.ToString ();
		string Constellation7 = Ds.Child ("Constellation7").Value.ToString ();
		string Constellation8 = Ds.Child ("Constellation8").Value.ToString ();
		string Constellation9 = Ds.Child ("Constellation9").Value.ToString ();
		string Constellation10 = Ds.Child ("Constellation10").Value.ToString ();
		string Constellation11 = Ds.Child ("Constellation11").Value.ToString ();
		string Constellation12 = Ds.Child ("Constellation12").Value.ToString ();

		string Planet1 = Ds.Child ("Planet1").Value.ToString ();
		string Planet2 = Ds.Child ("Planet2").Value.ToString ();
		string Planet3 = Ds.Child ("Planet3").Value.ToString ();
		string Planet4 = Ds.Child ("Planet4").Value.ToString ();
		string Planet5 = Ds.Child ("Planet5").Value.ToString ();
		string Planet6 = Ds.Child ("Planet6").Value.ToString ();
		string Planet7 = Ds.Child ("Planet7").Value.ToString ();
		string Planet8 = Ds.Child ("Planet8").Value.ToString ();
		string Planet9 = Ds.Child ("Planet9").Value.ToString ();
		string Planet10 = Ds.Child ("Planet10").Value.ToString ();
		string Planet11 = Ds.Child ("Planet11").Value.ToString ();
		string Planet12 = Ds.Child ("Planet12").Value.ToString ();

		string Description1 = Ds.Child ("Description1").Value.ToString ();
		string Description2 = Ds.Child ("Description2").Value.ToString ();
		string Description3 = Ds.Child ("Description3").Value.ToString ();
		string Description4 = Ds.Child ("Description4").Value.ToString ();
		string Description5 = Ds.Child ("Description5").Value.ToString ();
		string Description6 = Ds.Child ("Description6").Value.ToString ();
		string Description7 = Ds.Child ("Description7").Value.ToString ();
		string Description8 = Ds.Child ("Description8").Value.ToString ();
		string Description9 = Ds.Child ("Description9").Value.ToString ();
		string Description10 = Ds.Child ("Description10").Value.ToString ();
		string Description11 = Ds.Child ("Description11").Value.ToString ();
		string Description12 = Ds.Child ("Description12").Value.ToString ();

		DataManage.Palace [0] = new Palace_Class ( Palace1 , Class1 , Constellation1 , Planet1 , Description1);
		DataManage.Palace [1] = new Palace_Class ( Palace2 , Class2 , Constellation2 , Planet2 , Description2);
		DataManage.Palace [2] = new Palace_Class ( Palace3 , Class3 , Constellation3 , Planet3 , Description3);
		DataManage.Palace [3] = new Palace_Class ( Palace4 , Class4 , Constellation4 , Planet4 , Description4);
		DataManage.Palace [4] = new Palace_Class ( Palace5 , Class5 , Constellation5 , Planet5 , Description5);
		DataManage.Palace [5] = new Palace_Class ( Palace6 , Class6 , Constellation6 , Planet6 , Description6);
		DataManage.Palace [6] = new Palace_Class ( Palace7 , Class7 , Constellation7 , Planet7 , Description7);
		DataManage.Palace [7] = new Palace_Class ( Palace8 , Class8 , Constellation8 , Planet8 , Description8);
		DataManage.Palace [8] = new Palace_Class ( Palace9 , Class9 , Constellation9 , Planet9 , Description9);
		DataManage.Palace [9] = new Palace_Class ( Palace10 , Class10 , Constellation10 , Planet10 , Description10);
		DataManage.Palace [10] = new Palace_Class ( Palace11 , Class11 , Constellation11 , Planet11 , Description11);
		DataManage.Palace [11] = new Palace_Class ( Palace12 , Class12 , Constellation12 , Planet12 , Description12);

		/*//本地端資料存檔
		DataManage.Palace_Save(0 , DataManage.Planet_Save_String , Palace1 , Class1 , Constellation1 , Planet1 , Description1);
		DataManage.Palace_Save(1 , DataManage.Planet_Save_String , Palace2 , Class2 , Constellation2 , Planet2 , Description2);
		DataManage.Palace_Save(2 , DataManage.Planet_String , Palace3 , Class3 , Constellation3 , Planet3 , Description3);
		DataManage.Palace_Save(3 , DataManage.Planet_String , Palace4 , Class4 , Constellation4 , Planet4 , Description4);
		DataManage.Palace_Save(4 , DataManage.Planet_String , Palace5 , Class5 , Constellation5 , Planet5 , Description5);
		DataManage.Palace_Save(5 , DataManage.Planet_String , Palace6 , Class6 , Constellation6 , Planet6 , Description6);
		DataManage.Palace_Save(6 , DataManage.Planet_String , Palace7 , Class7 , Constellation7 , Planet7 , Description7);
		DataManage.Palace_Save(7 , DataManage.Planet_String , Palace8 , Class8 , Constellation8 , Planet8 , Description8);
		DataManage.Palace_Save(8 , DataManage.Planet_String , Palace9 , Class9 , Constellation9 , Planet9 , Description9);
		DataManage.Palace_Save(9 , DataManage.Planet_String , Palace10 , Class10 , Constellation10 , Planet10 , Description10);
		DataManage.Palace_Save(10 , DataManage.Planet_String , Palace11 , Class11 , Constellation11 , Planet11 , Description11);
		DataManage.Palace_Save(11 , DataManage.Planet_String , Palace12 , Class12 , Constellation12 , Planet12 , Description12);

		//讀取本地端資料
		DataManage.Palace_Class_Save_Write(0);
		DataManage.Palace_Class_Save_Write(1);
		DataManage.Palace_Class_Save_Write(2);
		DataManage.Palace_Class_Save_Write(3);
		DataManage.Palace_Class_Save_Write(4);
		DataManage.Palace_Class_Save_Write(5);
		DataManage.Palace_Class_Save_Write(6);
		DataManage.Palace_Class_Save_Write(7);
		DataManage.Palace_Class_Save_Write(8);
		DataManage.Palace_Class_Save_Write(9);
		DataManage.Palace_Class_Save_Write(10);
		DataManage.Palace_Class_Save_Write(11);*/


	}

    //============================================
    //副程式:行星資料放入類別中============================================================================================
    //============================================
    void Planet_Read(DataSnapshot Ds , int Number){
		
		string Planet1 = Ds.Child ("Planet1").Value.ToString ();
		string Planet2 = Ds.Child ("Planet2").Value.ToString ();
		string Planet3 = Ds.Child ("Planet3").Value.ToString ();
		string Planet4 = Ds.Child ("Planet4").Value.ToString ();
		string Planet5 = Ds.Child ("Planet5").Value.ToString ();
		string Planet6 = Ds.Child ("Planet6").Value.ToString ();
		string Planet7 = Ds.Child ("Planet7").Value.ToString ();
		string Planet8 = Ds.Child ("Planet8").Value.ToString ();
		string Planet9 = Ds.Child ("Planet9").Value.ToString ();
		string Planet10 = Ds.Child ("Planet10").Value.ToString ();
		string Planet11 = Ds.Child ("Planet11").Value.ToString ();
		string Planet12 = Ds.Child ("Planet12").Value.ToString ();
		string Planet13 = Ds.Child ("Planet13").Value.ToString ();
		string Planet14 = Ds.Child ("Planet14").Value.ToString ();
		string Planet15 = Ds.Child ("Planet15").Value.ToString ();

		string EName1 = Ds.Child ("EName1").Value.ToString ();
		string EName2 = Ds.Child ("EName2").Value.ToString ();
		string EName3 = Ds.Child ("EName3").Value.ToString ();
		string EName4 = Ds.Child ("EName4").Value.ToString ();
		string EName5 = Ds.Child ("EName5").Value.ToString ();
		string EName6 = Ds.Child ("EName6").Value.ToString ();
		string EName7 = Ds.Child ("EName7").Value.ToString ();
		string EName8 = Ds.Child ("EName8").Value.ToString ();
		string EName9 = Ds.Child ("EName9").Value.ToString ();
		string EName10 = Ds.Child ("EName10").Value.ToString ();
		string EName11 = Ds.Child ("EName11").Value.ToString ();
		string EName12 = Ds.Child ("EName12").Value.ToString ();
		string EName13 = Ds.Child ("EName13").Value.ToString ();
		string EName14 = Ds.Child ("EName14").Value.ToString ();
		string EName15 = Ds.Child ("EName15").Value.ToString ();

		string Represent1 = Ds.Child ("Represent1").Value.ToString ();
		string Represent2 = Ds.Child ("Represent2").Value.ToString ();
		string Represent3 = Ds.Child ("Represent3").Value.ToString ();
		string Represent4 = Ds.Child ("Represent4").Value.ToString ();
		string Represent5 = Ds.Child ("Represent5").Value.ToString ();
		string Represent6 = Ds.Child ("Represent6").Value.ToString ();
		string Represent7 = Ds.Child ("Represent7").Value.ToString ();
		string Represent8 = Ds.Child ("Represent8").Value.ToString ();
		string Represent9 = Ds.Child ("Represent9").Value.ToString ();
		string Represent10 = Ds.Child ("Represent10").Value.ToString ();
		string Represent11 = Ds.Child ("Represent11").Value.ToString ();
		string Represent12 = Ds.Child ("Represent12").Value.ToString ();
		string Represent13 = Ds.Child ("Represent13").Value.ToString ();
		string Represent14 = Ds.Child ("Represent14").Value.ToString ();
		string Represent15 = Ds.Child ("Represent15").Value.ToString ();

		string Influence1 = Ds.Child ("Influence1").Value.ToString ();
		string Influence2 = Ds.Child ("Influence2").Value.ToString ();
		string Influence3 = Ds.Child ("Influence3").Value.ToString ();
		string Influence4 = Ds.Child ("Influence4").Value.ToString ();
		string Influence5 = Ds.Child ("Influence5").Value.ToString ();
		string Influence6 = Ds.Child ("Influence6").Value.ToString ();
		string Influence7 = Ds.Child ("Influence7").Value.ToString ();
		string Influence8 = Ds.Child ("Influence8").Value.ToString ();
		string Influence9 = Ds.Child ("Influence9").Value.ToString ();
		string Influence10 = Ds.Child ("Influence10").Value.ToString ();
		string Influence11 = Ds.Child ("Influence11").Value.ToString ();
		string Influence12 = Ds.Child ("Influence12").Value.ToString ();
		string Influence13 = Ds.Child ("Influence13").Value.ToString ();
		string Influence14 = Ds.Child ("Influence14").Value.ToString ();
		string Influence15 = Ds.Child ("Influence15").Value.ToString ();

		string Description1 = Ds.Child ("Description1").Value.ToString ();
		string Description2 = Ds.Child ("Description2").Value.ToString ();
		string Description3 = Ds.Child ("Description3").Value.ToString ();
		string Description4 = Ds.Child ("Description4").Value.ToString ();
		string Description5 = Ds.Child ("Description5").Value.ToString ();
		string Description6 = Ds.Child ("Description6").Value.ToString ();
		string Description7 = Ds.Child ("Description7").Value.ToString ();
		string Description8 = Ds.Child ("Description8").Value.ToString ();
		string Description9 = Ds.Child ("Description9").Value.ToString ();
		string Description10 = Ds.Child ("Description10").Value.ToString ();
		string Description11 = Ds.Child ("Description11").Value.ToString ();
		string Description12 = Ds.Child ("Description12").Value.ToString ();
		string Description13 = Ds.Child ("Description13").Value.ToString ();
		string Description14 = Ds.Child ("Description14").Value.ToString ();
		string Description15 = Ds.Child ("Description15").Value.ToString ();

		DataManage.Planet [0] = new Planet_Class (Planet1 , EName1 , Represent1 , Influence1 , Description1);
		DataManage.Planet [1] = new Planet_Class (Planet2 , EName2 , Represent2 , Influence2 , Description2);
		DataManage.Planet [2] = new Planet_Class (Planet3 , EName3 , Represent3 , Influence3 , Description3);
		DataManage.Planet [3] = new Planet_Class (Planet4 , EName4 , Represent4 , Influence4 , Description4);
		DataManage.Planet [4] = new Planet_Class (Planet5 , EName5 , Represent5 , Influence5 , Description5);
		DataManage.Planet [5] = new Planet_Class (Planet6 , EName6 , Represent6 , Influence6 , Description6);
		DataManage.Planet [6] = new Planet_Class (Planet7 , EName7 , Represent7 , Influence7 , Description7);
		DataManage.Planet [7] = new Planet_Class (Planet8 , EName8 , Represent8 , Influence8 , Description8);
		DataManage.Planet [8] = new Planet_Class (Planet9 , EName9 , Represent9 , Influence9 , Description9);
		DataManage.Planet [9] = new Planet_Class (Planet10 , EName10 , Represent10 , Influence10 , Description10);
		DataManage.Planet [10] = new Planet_Class (Planet11 , EName11 , Represent11 , Influence11 , Description11);
		DataManage.Planet [11] = new Planet_Class (Planet12 , EName12 , Represent12 , Influence12 , Description12);
		DataManage.Planet [12] = new Planet_Class (Planet13 , EName13 , Represent13 , Influence13 , Description13);
		DataManage.Planet [13] = new Planet_Class (Planet14 , EName14 , Represent14 , Influence14 , Description14);
		DataManage.Planet [14] = new Planet_Class (Planet15 , EName15 , Represent15 , Influence15 , Description15);

		/*//本地端資料存檔
		DataManage.Planet_Save(0 , DataManage.Planet_Save_String , EName1 , Represent1 , Influence1 , Description1);
		DataManage.Planet_Save(1 , DataManage.Planet_Save_String , EName2 , Represent2 , Influence2 , Description2);
		DataManage.Planet_Save(2 , DataManage.Planet_Save_String , EName3 , Represent3 , Influence3 , Description3);
		DataManage.Planet_Save(3 , DataManage.Planet_Save_String , EName4 , Represent4 , Influence4 , Description4);
		DataManage.Planet_Save(4 , DataManage.Planet_Save_String , EName5 , Represent5 , Influence5 , Description5);
		DataManage.Planet_Save(5 , DataManage.Planet_Save_String , EName6 , Represent6 , Influence6 , Description6);
		DataManage.Planet_Save(6 , DataManage.Planet_Save_String , EName7 , Represent7 , Influence7 , Description7);
		DataManage.Planet_Save(7 , DataManage.Planet_Save_String , EName8 , Represent8 , Influence8 , Description8);
		DataManage.Planet_Save(8, DataManage.Planet_Save_String , EName9 , Represent9 , Influence9 , Description9);
		DataManage.Planet_Save(9 , DataManage.Planet_Save_String , EName10 , Represent10 , Influence10 , Description10);
		DataManage.Planet_Save(10 , DataManage.Planet_Save_String , EName11 , Represent11 , Influence11 , Description11);
		DataManage.Planet_Save(11 , DataManage.Planet_Save_String , EName12 , Represent12 , Influence12 , Description12);
		DataManage.Planet_Save(12 , DataManage.Planet_Save_String , EName13 , Represent13 , Influence13 , Description13);
		DataManage.Planet_Save(13 , DataManage.Planet_Save_String , EName14 , Represent14 , Influence14 , Description14);
		DataManage.Planet_Save(14 , DataManage.Planet_Save_String , EName15 , Represent15 , Influence15 , Description15);
		//讀取本地端資料
		DataManage.Planet_Save_Write(0);
		DataManage.Planet_Save_Write(1);
		DataManage.Planet_Save_Write(2);
		DataManage.Planet_Save_Write(3);
		DataManage.Planet_Save_Write(4);
		DataManage.Planet_Save_Write(5);
		DataManage.Planet_Save_Write(6);
		DataManage.Planet_Save_Write(7);
		DataManage.Planet_Save_Write(8);
		DataManage.Planet_Save_Write(9);
		DataManage.Planet_Save_Write(10);
		DataManage.Planet_Save_Write(11);
		DataManage.Planet_Save_Write(12);
		DataManage.Planet_Save_Write(13);
		DataManage.Planet_Save_Write(14);*/

	}


}








//============================================
//用於改寫資料的類別(改寫資料前要將FireBase的寫開啟)===============================================================
//============================================
public class User {
	public string Add;
	public string Description;

	public User() {
	}

	public User(string Add, string Description) {
		this.Add = Add;
		this.Description = Description;
	}
		
}
