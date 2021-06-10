//修改文字條
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI

public class MainText : MonoBehaviour {


	public Text maintext; //文字條
	float   time = 5;                       //文字顯示時間
	float   a = 350.0f;                         //起始位置
	int     rand;     				        //產生整數亂數

	// Use this for initializationAllScore.LevelScore/1000
	void Start () {
		maintext.text = " ";
	}

	// Update is called once per frame
	void Update () {


		//文字條
		this.transform.localPosition = new Vector3 (a,-6.5f,0.0f);
		if(a>=2.6f) a = a - 0.5f;

		//改變文字條
		if (a <= 2.6f && time>=0.0) {

			//減少時間
			time = time - Time.deltaTime;
			if (time <= 0) {
				a = 350.0f;
				time = 5;
				rand = Random.Range(1, 51);         //產生1~10之間的整數亂數
				if(rand==1)      maintext.text = "鄰國發生了旱災";
				else if(rand==2) maintext.text = "今年農作物收成非常的好";
				else if(rand==3) maintext.text = "人民開始遊行";	
				else if(rand==4) maintext.text = "告訴我，孩子，你裝著怎樣的想法？";	
				else if(rand==5) maintext.text = "都是假的，是眼睛業障重";	
				else if(rand==6) maintext.text = "城裡來了一群外來民族";	
				else if(rand==7) maintext.text = "新的研究改良了藥品的效果";	
				else if(rand==8) maintext.text = "最近大雨不斷，農田的作物都爛掉";
				else if(rand==9) maintext.text = "人沒有夢想，跟鹹魚一樣";	
				else if(rand==10) maintext.text = "西部地區開始有人民移入";	
				else if(rand==11) maintext.text = "一批失去控制的馬在城裡亂跑，造成許多人受傷";	
				else if(rand==12) maintext.text = "城裡的大廚一種新的食物保存方法";	
				else if(rand==13) maintext.text = "市面上開始流竄著大量的假鈔";	
				else if(rand==14) maintext.text = "許多人民都出現了嘔吐的情況";	
				else if(rand==15) maintext.text = "他好像在笑，笑到你心裡發寒";	
				else if(rand==16) maintext.text = "有一本秘笈很便宜的";	
				else if(rand==17) maintext.text = "人民感受到幸福";	
				else if(rand==18) maintext.text = "人口出生率開始驟降";	
				else if(rand==19) maintext.text = "最近老人的壽命越來越長";	
				else if(rand==20) maintext.text = "巭孬嫑夯尻";	
				else if(rand==21) maintext.text = "國家會議將要在聖瓦倫舉行";	
				else if(rand==22) maintext.text = "國家日漸壯大，人民一日一日過";	
				else if(rand==23) maintext.text = "酒是爹，菜是娘喝死總比槍斃強";	
				else if(rand==24) maintext.text = "都說女人是水做的，可是最近水污染好嚴重哦";	
				else if(rand==25) maintext.text = "廣告就是告訴你，錢可以這麼花";	
				else if(rand==26) maintext.text = "你知道就算大雨讓整座城市顛倒 開學我也得滾回學校";	
				else if(rand==27) maintext.text = "上帝說，愛我你會紅";	
				else if(rand==28) maintext.text = "常在河邊走，哪有不濕鞋，既然鞋濕了，乾脆洗個澡";	
				else if(rand==29) maintext.text = "女人不是妖，性感不是騷";	
				else if(rand==30) maintext.text = "人丑就該多讀書";	
				else if(rand==31) maintext.text = "知識就像內褲，看不見但很重要";	
				else if(rand==32) maintext.text = "保護自己，愛護他人，請不要半夜出來嚇人";	
				else if(rand==33) maintext.text = "天沒降大任於我，照樣苦我心智，勞我筋骨";	
				else if(rand==34) maintext.text = "說到摩天輪當然就是親嘴啊…它根本就是為了親嘴才蓋的";	
				else if(rand==35) maintext.text = "你問為什麼海水是鹹的？還不是你們這些都市人一邊游泳還不忘大小便";	
				else if(rand==36) maintext.text = "菜單樣式多的拉麵店，生意大多都不會很好";	
				else if(rand==37) maintext.text = "去旅行就算忘了帶內褲，也不可以忘記帶UNO";	
				else if(rand==38) maintext.text = "人見人愛，花見花開，車見車爆胎";	
				else if(rand==39) maintext.text = "我的優點是：我很帥；但是我的缺點是：我帥的不明顯";	
				else if(rand==40) maintext.text = "沒有拆不散的夫妻，只有不努力的小三";	
				else if(rand==41) maintext.text = "別和我談理想，戒了";	
				else if(rand==42) maintext.text = "老師，我遇見強盜了，就是作業被搶了";	
				else if(rand==43) maintext.text = "鹹魚翻身，還是鹹魚";	
				else if(rand==44) maintext.text = "託夢可是人類歷史上最早的無線通訊方式";	
				else if(rand==45) maintext.text = "我想問問：我們在學校都交了錢，不是應該讓老師聽我們的嗎";	
				else if(rand==46) maintext.text = "錢不是問題，問題是沒錢";	
				else if(rand==47) maintext.text = "人生自古誰無死，哪個拉屎不用紙";	
				else if(rand==48) maintext.text = "物價與歐洲接軌，房價與月球接軌，工資與非洲接軌";	
				else if(rand==49) maintext.text = "大師兄，二師兄的肉現在比師傅的還貴";	
				else if(rand==50) maintext.text = "猜忌、說謊…，這愈來愈像婚姻了";	
				else maintext.text = "............";	
			}
		}

	}//Updateend


}
