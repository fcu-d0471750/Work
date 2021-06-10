/*
 * 所有競爭對手初始資料
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositeData : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //5位競爭對手
    public Opposite_Class[] Opposite = new Opposite_Class[5];

    //5位競爭對手的Description
    private string[] Opposite_Description = new string[30];

    //============
    //迴圈用
    //============
    private int i, j;

    //============
    //初始化
    //============
    private void Awake()
    {
        //生成Opposite_Description
        CreateOpposite_Description();

        //5位競爭對手
        Opposite[0] = new Opposite_Class(0, "亞丁尼酒店", "亞商", 1, 2000, 0, Opposite_Description[0], true);
        Opposite[1] = new Opposite_Class(1, "天壺館", "九龍", 2, 10000, 0, Opposite_Description[1], false);
        Opposite[2] = new Opposite_Class(2, "太乙商旅", "周王", 3, 35000, 0, Opposite_Description[2], false);
        Opposite[3] = new Opposite_Class(3, "北城", "十八子李", 4, 60000, 0, Opposite_Description[3], false);
        Opposite[4] = new Opposite_Class(4, "帝啻", "武齋", 5, 100000, 0, Opposite_Description[4], false);
        
    }

    //============
    //生成Opposite_Description
    //============
    private void CreateOpposite_Description()
    {
        Opposite_Description[0] = "亞商透過募資的方式，興建了亞丁尼酒店，雖然跟另外幾家比起來，還是屬於年輕一備的酒店，大部份的客人都是介於20~30歲之間，偏好性感的女人和醉到不行的派對時間。";
        Opposite_Description[1] = "由於喜歡武俠小說內江湖的世界，期望打造一間仿照古代風格的酒館，客人們都談笑風生，大部份的客人都是介於30~35歲之間，偏好有樂趣的女人和停不下來的聊天。";
        Opposite_Description[2] = "這一家旅館極為有特色，從裡到外都跟八卦占卜知識拖不了關係，不知道是擁有者的喜好，還是其它原因，大部份的客人都是40歲以上，偏好技巧高的女人。";
        Opposite_Description[3] = "一家開於市中心的飯店，不僅占地廣大，裡面更是五花八門，商店、超市、餐廳......樣樣皆聚，宛如像是一座鮮活的城市，而要入住更是要捧著鈔票，大部份的客人都是45歲以上，偏好可愛、給人戀愛感覺的女人。";
        Opposite_Description[4] = "專門服侍有錢人的最大飯店，提供最優質的服務和品質極高的小姐，大部份的客人都是60歲以上，口袋多的是錢的男人，只偏好漂亮的女人。";
    }

    /*
     * 
     *  //int : id
    private int id;

    //string : 競爭對手店鋪名稱
    private string Opposite_Name;

    //string : 競爭對手老闆姓名
    private string Opposite_Boss;

    //int : 競爭對手店鋪階級
    private int Opposite_Level;

    //uint : 競爭對手粉絲人數
    private uint Opposite_FansNumber;

    //uint : 競爭對手區域粉絲人數
    private uint Opposite_AreaFans;

    //string : 競爭對手資訊
    private string Opposite_Description;

    //bool : 是否解鎖，true:解鎖 false:未解鎖
    private bool Opposite_isunLocked;
     */

}//OppositeData
