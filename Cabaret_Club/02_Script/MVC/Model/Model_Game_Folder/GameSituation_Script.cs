/*
 * GameSituation_Script : 問題事件生成
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSituation_Script : MonoBehaviour
{
    //======================================================
    //宣告屬性
    //======================================================

    

    //問題事件，共5種情況，小姐用酒杯、客人用酒杯、更換毛巾、菜單、更換菸灰缸
    private GameSituation_Class[] GameSituation = new GameSituation_Class[5];

    //爭執事件，責罵小姐、袒護小姐、送上道歉禮品、送客
    private GameArgue_Class[] GameArgue = new GameArgue_Class[1];

    //結帳事件，送上拌手禮、有禮貌送客、誇獎小姐、給予小姐獎勵
    private GameCalculation_Class[] GameCalculation = new GameCalculation_Class[1];

    //float : 事件生成時間，5秒產生一次事件
    private float CreateTime = 5.0f;

    //float : 計算生成時間
    private float CalTime = 0.0f;

    //bool : 是否產生事件，true:產生事件 false:未產生事件
    private bool isCreate = false;

    //======================================================
    //建構子(無參數)
    //======================================================
    public GameSituation_Script() {
        //生成問題事件
        CreateGameSituation();
        //生成爭執事件
        CreateGameArgue();
        //生成結帳事件
        CreateGameCalculation();
    }

    //======================================================
    //初始化
    //======================================================
    /*private void Awake()
    {
        //生成問題事件
        CreateGameSituation();
        //生成爭執事件
        CreateGameArgue();
        //生成結帳事件
        CreateGameCalculation();
    }*/

    //======================================================
    //執行
    //======================================================
    /*private void Update()
    {
        
        //計算生成時間
        if (isCreate == false) CalTime = CalTime + Time.deltaTime;

        //如果超過事件生成時間，可以生成事件
        if (CalTime >= CreateTime) {
            //產生事件
            isCreate = true;
            //計算生成時間歸0
            CalTime = 0.0f;          
        }
        
    }*/

    //======================================================
    //內部方法
    //======================================================

    //============
    //生成問題事件
    //============
    private void CreateGameSituation() {
        //小姐用酒杯、客人用酒杯、更換毛巾、菜單、更換菸灰缸
        GameSituation[0] = new GameSituation_Class(0 , "小姐在打暗號..." , "小姐用酒杯" , "客人用酒杯" , "更換菸灰缸" , "菜單" , null);

        //小姐用酒杯、客人用酒杯、更換毛巾、菜單、更換菸灰缸
        GameSituation[1] = new GameSituation_Class(1 , "小姐在打暗號...", "客人用酒杯", "菜單", "小姐用酒杯", "更換毛巾", null);

        //小姐用酒杯、客人用酒杯、更換毛巾、菜單、更換菸灰缸
        GameSituation[2] = new GameSituation_Class(2 , "小姐在打暗號...", "更換毛巾", "菜單", "小姐用酒杯", "更換菸灰缸", null);

        //小姐用酒杯、客人用酒杯、更換毛巾、菜單、更換菸灰缸
        GameSituation[3] = new GameSituation_Class(3 , "小姐在打暗號...", "菜單", "更換菸灰缸", "客人用酒杯", "小姐用酒杯", null);

        //小姐用酒杯、客人用酒杯、更換毛巾、菜單、更換菸灰缸
        GameSituation[4] = new GameSituation_Class(4 , "小姐在打暗號...", "更換菸灰缸", "客人用酒杯", "菜單", "小姐用酒杯", null);
       
    }

    //============
    //生成爭執事件
    //============
    private void CreateGameArgue()
    {
        //責罵小姐、袒護小姐、送上道歉禮品、送客
        GameArgue[0] = new GameArgue_Class(0 , "跟客人起爭執!" , "責罵小姐", "袒護小姐", "送上道歉禮品", "送客", null);
    }

    //============
    //生成結帳事件
    //============
    private void CreateGameCalculation()
    {
        //送上拌手禮、有禮貌送客、誇獎小姐、給予小姐獎勵
        GameCalculation[0] = new GameCalculation_Class(0 , "客人要結帳了。", "送上拌手禮", "有禮貌送客", "誇獎小姐", "給予小姐獎勵", null);
    }

    //======================================================
    //外部方法
    //======================================================

    //======================================================
    //Getter
    //======================================================

    

    //============
    //GameSituation(id : 第幾題問題事件)
    //============
    public GameSituation_Class GetGameSituation(int id)
    {
        return GameSituation[id];
    }

    //============
    //GameSituation(全部)
    //============
    public GameSituation_Class[] GetAllGameSituation()
    {
        return GameSituation;
    }

    //============
    //GameArgue(id : 第幾題爭執事件)
    //============
    public GameArgue_Class GetGameArgue(int id)
    {
        return GameArgue[id];
    }

    //============
    //GameArgue(全部)
    //============
    public GameArgue_Class[] GetAllGameArgue()
    {
        return GameArgue;
    }

    //============
    //GameCalculation(id : 第幾題結帳事件)
    //============
    public GameCalculation_Class GetGameCalculation(int id)
    {
        return GameCalculation[id];
    }

    //============
    //GameCalculation(全部)
    //============
    public GameCalculation_Class[] GetAllGameCalculation()
    {
        return GameCalculation;
    }

    //============
    //CreateTime
    //============
    public float GetCreateTime()
    {
        return CreateTime;
    }

    //============
    //CalTime
    //============
    public float GetCalTime()
    {
        return CalTime;
    }

    //============
    //isCreate
    //============
    public bool GetisCreate()
    {
        return isCreate;
    }

    //======================================================
    //Setter
    //======================================================

    

    //============
    //CreateTime
    //============
    public void SetCreateTime(float Time)
    {
        this.CreateTime = Time;
    }

    //============
    //CalTime
    //============
    public void SetCalTime(float Time)
    {
        this.CalTime = Time;
    }

    //============
    //isCreate
    //============
    public void SetisCreate(bool isCreate)
    {
        this.isCreate = isCreate;
    }


}//GameSituation_Script
