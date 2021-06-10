using UnityEngine;
using System.Collections;

public class Misaki : MonoBehaviour {

	private Animator animator;
	private bool Run_Punch=false;    //是否遇到過敵人 true:遇到 false:沒遇到
	private float Live = 20.0f;  //生命值
	float Run_PunchT;
	float maxtime;
	public AudioSource Punchmusic;//打擊音效
	public GameObject LiveBar; //生命條
	bool   LiveAction;            //獲得補血 true:補血 fasle:沒補血
	bool BombAction;            //受到爆炸傷害 true:受傷 fasle:沒受傷
	public GameObject DeathPart;  //死亡粒子
	public GameObject AddLivePart;//補血粒子

	public GameObject PunchPart;  //攻擊粒子
	float  PrunchPartTime;        //攻擊粒子延遲生成時間

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		maxtime = 0.3f;
		Live = 20.0f * (1 + (Main.Apeople + Main.Aweapon + Main.Ahospital + Main.Afood) );    //依照建照等級提升生命值
		LiveAction = false;
	}

	// Update is called once per frame
	void Update () {
		if(!CreatePeople.WarPause){
		LiveBar.transform.localScale = new Vector3(Live/(20.0f * (1 + (Main.Apeople + Main.Aweapon + Main.Ahospital + Main.Afood)))/10.0f, 0.1f, 0);

		if(Run_Punch)Punchmusic.Play ();

		if(Run_Punch)Run_PunchT=0.0f;           //有遇到敵人
		else Run_PunchT += Time.deltaTime; //沒遇到敵人的時間增加

		Run_Punch = false;

		if (Run_PunchT >= maxtime) {
			animator.SetBool("Run_Punch", Run_Punch);
				gameObject.transform.position += new Vector3(0.01f + ((float)Main.Afood/150.0f) ,0,0); //不斷向右移動
			Punchmusic.Pause ();
		}
		if(CreatePeople.Live<=0 || CreateEnemy.Live<=0)Destroy(gameObject);//如果我方或敵方的城門生命值<=0消滅物件本身
		//if(Live==0)Destroy(gameObject);//消滅物件本身
		animator.SetFloat("Live", Live);	 
		}
		else Punchmusic.Pause();

		//補血技能釋放********************************************************************************************************
		if(Skill.AddLiveAction) LiveAction = true;
		if(LiveAction){
			if ((Live / (20.0f * (1 + (Main.Apeople + Main.Aweapon + Main.Ahospital + Main.Afood)))) < 0.7f)        //如果現在血量低於 70% ，則現在血量 = 現在血量+最大血量*30%
				Live = Live + (20.0f * ((1 + (Main.Apeople + Main.Aweapon + Main.Ahospital + Main.Afood))) * 0.3f);
			else
				Live = (20.0f * (1 + (Main.Apeople + Main.Aweapon + Main.Ahospital + Main.Afood)));                 //如果現在血量高於 70% ，則現在血量 = 最大血量
			Instantiate (AddLivePart, gameObject.transform.position, gameObject.transform.rotation);               //生成補血粒子

			LiveAction = false;
		}

		//爆炸傷害釋放********************************************************************************************************
		if(EnemySkills.AddBombAction) BombAction = true;                   //啟動爆炸傷害

		if (BombAction) {
			if (Live > ((20.0f * (1 + (Main.Apeople + Main.Aweapon + Main.Ahospital + Main.Afood))) * 0.2f))         //只要現在血量大於現在血量20% 則現在血量 = 現在血量-最大血量*20%
				Live = Live - ((20.0f * (1 + (Main.Apeople + Main.Aweapon + Main.Ahospital + Main.Afood))) * 0.2f);
			else {                                                   //現在血量 = 0 播放死亡動畫
				Live = 0.0f;
				Run_Punch  = true;
				animator.SetBool("Run_Punch", Run_Punch);
			}
			BombAction = false;                                      //爆炸傷害結束
		}

	}

	//碰到敵人
	void OnTriggerStay2D(Collider2D col)
	{
		if (!CreatePeople.WarPause && col.tag == "EHolger" || col.tag == "EYuko" || col.tag == "EYuji" || col.tag == "EArcher1"|| col.tag == "EArcher2" || col.tag == "EArcher3" || col.tag == "ECindy" || col.tag == "EMisaki"|| col.tag == "EToko")
		{
			Run_Punch = true;
			animator.SetBool("Run_Punch", Run_Punch);
			if (Live != 0)Live=Live - (0.05f - ((float)Main.Afood/150.0f)  );
			else Destroy(gameObject);//消滅物件本身
			animator.SetFloat("Live", Live);	 
			maxtime = 1.0f;
			PrunchPartTime += Time.deltaTime;      //攻擊粒子延遲生成時間
			if(PrunchPartTime >= 0.2f){
				Instantiate (PunchPart, gameObject.transform.position, gameObject.transform.rotation);               //生成攻擊粒子
				PrunchPartTime = 0.0f;
			}
		}

	}

	//消滅物件
	void DestoryObject(){
		Instantiate (DeathPart, gameObject.transform.position, gameObject.transform.rotation); //士兵生成粒子
		Destroy(gameObject);//消滅物件本身
	}
}
