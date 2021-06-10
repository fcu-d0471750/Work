/*
 * 所有在籍小姐初始資料
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadyData : MonoBehaviour
{
    //======================================================
    //宣告變數
    //======================================================

    //30位在籍小姐
    public static Lady_Class[] Lady = new Lady_Class[30];

    //30位在籍小姐的Description
    private string[] Lady_Description = new string[30];

    //======================================================
    //UI來源
    //======================================================
    public ManageScene_View_UI MVU;


    //============
    //迴圈用
    //============
    private int i, j;

    //============
    //初始化
    //============
    private void Awake()
    {
        //生成Lady_Description
        CreateLady_Description();

        //生成30位在籍小姐(int id , string Name, string Description, Sprite Headshot, Sprite hierarchy_Sprite, int hierarchy, int Level, uint Cost, ulong AllIncome, uint OnceIncome, float Hp, float HpMax , float Talk, float Party, float Love, float Skill, string Sexy, string Beauty, string Cute, string Funny , bool isunLock, bool isWorked)
        Lady[0] = new Lady_Class(0 , "小雪", Lady_Description[0] , MVU.LadyHeadShot[0] , MVU.GetPrepareStaffhierarchy(4) , 4 , 1 , 10000 , 0 , 0 , 500.0f , 1000.0f , 1000.0f , 150.0f , 100.0f , 80.0f , "DCircle" , "Circle" , "Triangle" , "Cross" ,true , false);
        Lady[1] = new Lady_Class(1, "佑怡", Lady_Description[1] , MVU.LadyHeadShot[1] , MVU.GetPrepareStaffhierarchy(1) , 1 , 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "Cross", "Triangle", "Triangle", "Cross", true, false);
        Lady[2] = new Lady_Class(2, "檀雅", Lady_Description[2] , MVU.LadyHeadShot[2] , MVU.GetPrepareStaffhierarchy(1) , 1 , 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[3] = new Lady_Class(3, "熙雯", Lady_Description[3] , MVU.LadyHeadShot[3] , MVU.GetPrepareStaffhierarchy(1) , 1 , 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "Triangle", "Cross", "Cross", "Cross", true, false);
        Lady[4] = new Lady_Class(4, "鑫蕾", Lady_Description[4] , MVU.LadyHeadShot[4] , MVU.GetPrepareStaffhierarchy(2) , 2 , 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[5] = new Lady_Class(5, "碧萱", Lady_Description[5], MVU.LadyHeadShot[5]  , MVU.GetPrepareStaffhierarchy(2), 2, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[6] = new Lady_Class(6, "慧妍", Lady_Description[6], MVU.LadyHeadShot[6]  , MVU.GetPrepareStaffhierarchy(3), 3, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[7] = new Lady_Class(7, "璟雯", Lady_Description[7], MVU.LadyHeadShot[7]  , MVU.GetPrepareStaffhierarchy(2), 2, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[8] = new Lady_Class(8, "婧琪", Lady_Description[8], MVU.LadyHeadShot[8]  , MVU.GetPrepareStaffhierarchy(3), 3, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[9] = new Lady_Class(9, "夢婷", Lady_Description[9], MVU.LadyHeadShot[9]  , MVU.GetPrepareStaffhierarchy(1), 1, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[10] = new Lady_Class(10, "雪怡", Lady_Description[10], MVU.LadyHeadShot[10], MVU.GetPrepareStaffhierarchy(1), 1, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "Cross", "Circle", "Cross", "Cross", true, false);
        Lady[11] = new Lady_Class(11, "可嵐", Lady_Description[11], MVU.LadyHeadShot[11], MVU.GetPrepareStaffhierarchy(4), 4, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "DCircle", true, false);
        Lady[12] = new Lady_Class(12, "天瑜", Lady_Description[12], MVU.LadyHeadShot[12], MVU.GetPrepareStaffhierarchy(3), 3, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[13] = new Lady_Class(13, "婧琪", Lady_Description[13], MVU.LadyHeadShot[13], MVU.GetPrepareStaffhierarchy(2), 2, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[14] = new Lady_Class(14, "媛馨", Lady_Description[14], MVU.LadyHeadShot[14], MVU.GetPrepareStaffhierarchy(2), 2, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[15] = new Lady_Class(15, "玥婷", Lady_Description[15], MVU.LadyHeadShot[15], MVU.GetPrepareStaffhierarchy(1), 1, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[16] = new Lady_Class(16, "瀅心", Lady_Description[16], MVU.LadyHeadShot[16], MVU.GetPrepareStaffhierarchy(4), 4, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[17] = new Lady_Class(17, "雪馨", Lady_Description[17], MVU.LadyHeadShot[17], MVU.GetPrepareStaffhierarchy(4), 4, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[18] = new Lady_Class(18, "夢潔", Lady_Description[18], MVU.LadyHeadShot[18], MVU.GetPrepareStaffhierarchy(2), 2, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Cross", "Cross", "Cross", true, false);
        Lady[19] = new Lady_Class(19, "美蓮", Lady_Description[19], MVU.LadyHeadShot[19], MVU.GetPrepareStaffhierarchy(3), 3, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[20] = new Lady_Class(20, "雅芙", Lady_Description[20], MVU.LadyHeadShot[20], MVU.GetPrepareStaffhierarchy(3), 3, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "Circle", "Circle", "Circle", "Cross", true, false);
        Lady[21] = new Lady_Class(21, "雨婷", Lady_Description[21], MVU.LadyHeadShot[21], MVU.GetPrepareStaffhierarchy(3), 3, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[22] = new Lady_Class(22, "姝瑗", Lady_Description[22], MVU.LadyHeadShot[22], MVU.GetPrepareStaffhierarchy(1), 1, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[23] = new Lady_Class(23, "穎娟", Lady_Description[23], MVU.LadyHeadShot[23], MVU.GetPrepareStaffhierarchy(4), 4, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[24] = new Lady_Class(24, "歆瑤", Lady_Description[24], MVU.LadyHeadShot[24], MVU.GetPrepareStaffhierarchy(4), 4, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[25] = new Lady_Class(25, "凌菲", Lady_Description[25], MVU.LadyHeadShot[25], MVU.GetPrepareStaffhierarchy(3), 3, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[26] = new Lady_Class(26, "鈺琪", Lady_Description[26], MVU.LadyHeadShot[26], MVU.GetPrepareStaffhierarchy(2), 2, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[27] = new Lady_Class(27, "婧宸", Lady_Description[27], MVU.LadyHeadShot[27], MVU.GetPrepareStaffhierarchy(2), 2, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[28] = new Lady_Class(28, "靖瑤", Lady_Description[28], MVU.LadyHeadShot[28], MVU.GetPrepareStaffhierarchy(1), 1, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);
        Lady[29] = new Lady_Class(29, "瑾萱", Lady_Description[29], MVU.LadyHeadShot[29], MVU.GetPrepareStaffhierarchy(1), 1, 1, 10000, 0, 0, 500.0f, 1000.0f, 1000.0f, 150.0f, 100.0f, 80.0f, "DCircle", "Circle", "Triangle", "Cross", true, false);

    }


    //============
    //生成Lady_Description
    //============
    private void CreateLady_Description() {
        Lady_Description[0] = "雪:晶瑩剔透之貌。";
        Lady_Description[1] = "怡:好心情。";
        Lady_Description[2] = "檀:植物 雅:正規。";
        Lady_Description[3] = "熙:光明 雯:成花紋的雲彩。";
        Lady_Description[4] = "鑫:財富。";
        Lady_Description[5] = "萱:一種忘憂的草。";
        Lady_Description[6] = "慧:智慧 妍:美好。";
        Lady_Description[7] = "玉的光彩 雯:色彩斑斕的雲，多用於人名。";
        Lady_Description[8] = "婧:女子有才 琪:美玉。";
        Lady_Description[9] = "婷:美好。";
        Lady_Description[10] = "怡:心曠神怡。";
        Lady_Description[11] = "嵐:早上山中的霧氣。";
        Lady_Description[12] = "瑜:美玉。";
        Lady_Description[13] = "婧:女子有才 琪:美玉。";
        Lady_Description[14] = "媛:美好。";
        Lady_Description[15] = "玥:傳說中一種神珠 婷:美好。";
        Lady_Description[16] = "瀅:清澈。";
        Lady_Description[17] = "馨:香氣。";
        Lady_Description[18] = "一個夢幻般的女生，心地善良，純潔。";
        Lady_Description[19] = "美麗如蓮花一樣，還有出淤泥而不染的高尚品質。";
        Lady_Description[20] = "文雅，如出水芙蓉一般。";
        Lady_Description[21] = "溫柔，聰明，漂亮。";
        Lady_Description[22] = "姝:美麗，美好 瑗:璧玉。";
        Lady_Description[23] = "穎:聰穎 娟:娟秀，秀美。";
        Lady_Description[24] = "歆:心悅，歡愉 瑤:美玉。";
        Lady_Description[25] = "菲:草木的香氣很濃。";
        Lady_Description[26] = "鈺:寶物，珍寶 琪:美玉。";
        Lady_Description[27] = "婧:女子有才 宸:古代君王的代稱。";
        Lady_Description[28] = "靖:平安 瑤:美玉。";
        Lady_Description[29] = "瑾:美玉 萱:傳說中一種忘憂的草。";

    }


}//LadyData
