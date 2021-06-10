/*
 * View : PrepareStaffBase、PrepareStaffBaseCanvas的View
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class View_Manage_PrepareStaff_Script : MonoBehaviour
{

    //======================================================
    //UI來源
    //======================================================

    public ManageScene_View_UI MVU;

    //======================================================
    //宣告變數
    //======================================================

    //View_Manage_Script : Manage所有的View統一管理Script
    public View_Manage_Script VMS;

    //迴圈用
    private int i, j;

    //======================================================
    //宣告UI(Sprite、Text、Image、Button)
    //======================================================


    //============
    //Sprite
    //============

    //============
    //(PrepareStaffLady)
    //============

    //出勤小姐大頭照
    public SpriteRenderer[] PrepareStaffLadySprite = new SpriteRenderer[8];

    //出勤小姐階級圖
    public SpriteRenderer[] PrepareStaffLady_hierarchy_Sprite = new SpriteRenderer[8];


    //============
    //(PrepareStaffAbility)
    //============

    //出勤小姐大頭照
    public SpriteRenderer PrepareStaffAbility_Picture_Sprite;

    //出勤小姐階級圖
    public SpriteRenderer PrepareStaffAbility_hierarchy_Sprite;

    //出勤小姐Looks的Sexy圖
    public SpriteRenderer PrepareStaffAbility_Looks_Sexy_Sprite;

    //出勤小姐Looks的Beauty圖
    public SpriteRenderer PrepareStaffAbility_Looks_Beauty_Sprite;

    //出勤小姐Looks的Cute圖
    public SpriteRenderer PrepareStaffAbility_Looks_Cute_Sprite;

    //出勤小姐Looks的Funny圖
    public SpriteRenderer PrepareStaffAbility_Looks_Funny_Sprite;


    //============
    //Text
    //============

    //============
    //(PrepareStaffAbility)
    //============

    //小姐性名
    public Text PrepareStaffAbility_Name_Text;

    //小姐等級
    public Text PrepareStaffAbility_Level_Text;

    //小姐薪水
    public Text PrepareStaffAbility_Cost_Text;

    //小姐Hp
    public Text PrepareStaffLadyAbility_Hp_Text;
    //小姐Talk
    public Text PrepareStaffLadyAbility_Talk_Text;
    //小姐Party
    public Text PrepareStaffLadyAbility_Party_Text;
    //小姐Love
    public Text PrepareStaffLadyAbility_Love_Text;
    //小姐Skill
    public Text PrepareStaffLadyAbility_Skill_Text;

    //============
    //(PrepareStaffAllAbility)
    //============

    //合計小姐Hp
    public Text PrepareStaffAllAbility_Hp_Text;
    //合計小姐Talk
    public Text PrepareStaffAllAbility_Talk_Text;
    //合計小姐Party
    public Text PrepareStaffAllAbility_Party_Text;
    //合計小姐Love
    public Text PrepareStaffAllAbility_Love_Text;
    //合計小姐Skill
    public Text PrepareStaffAllAbility_Skill_Text;

    //出勤成員人數
    public Text PrepareStaffAllAbility_Number_Text;
    //出勤花費
    public Text PrepareStaffAllAbility_Cost_Text;



    //============
    //Image
    //============

    //============
    //(PrepareStaffAbility)
    //============

    //出勤小姐的Hp，長條圖
    public Image PrepareStaffLadyAbility_Hp_Bar;

    //出勤小姐的Talk，長條圖
    public Image PrepareStaffLadyAbility_Talk_Bar_Image;

    //出勤小姐的Party，長條圖
    public Image PrepareStaffLadyAbility_Party_Bar_Image;

    //出勤小姐的Love，長條圖
    public Image PrepareStaffLadyAbility_Love_Bar_Image;

    //出勤小姐的Skill，長條圖
    public Image PrepareStaffLadyAbility_Skill_Bar_Image;

    //============
    //(PrepareStaffAllAbility)
    //============

    //合計出勤小姐的Hp，長條圖
    public Image PrepareStaffAllAbility_Hp_Bar;

    //合計出勤小姐的Talk，長條圖
    public Image PrepareStaffAllAbility_Talk_Bar_Image;

    //合計出勤小姐的Party，長條圖
    public Image PrepareStaffAllAbility_Party_Bar_Image;

    //合計出勤小姐的Love，長條圖
    public Image PrepareStaffAllAbility_Love_Bar_Image;

    //合計出勤小姐的Skill，長條圖
    public Image PrepareStaffAllAbility_Skill_Bar_Image;


    //============
    //Button
    //============

    //============
    //(PrepareStaffLadies)
    //============

    //出勤小姐Button
    public Button[] PrepareStaffLadiesButton = new Button[8];



    //======================================================
    //外部方法
    //======================================================

    //============
    //(PrepareStaffLadies)
    //============

    //============
    //出勤小姐大頭照，(PrepareLady: Model_Manage_Script下的出勤小姐)
    //============
    public void SetPrepareStaffLady_Sprite(Lady_Class[] PrepareLady)
    {

        for (i = 0; i < 8; i++)
        {           
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) PrepareStaffLadySprite[i].sprite = MVU.LadyHeadShot[PrepareLady[i].Getid()];
            //未出勤
            else PrepareStaffLadySprite[i].sprite = null;
        }
    }

    //============
    //出勤小姐階級圖，(PrepareLady: Model_Manage_Script下的出勤小姐)
    //============
    public void SetPrepareStaffLady_hierarchy_Sprite(Lady_Class[] PrepareLady)
    {
        for (i = 0; i < 8; i++)
        {
            //已解鎖
            if (PrepareLady[i].GetisWorked() == true) PrepareStaffLady_hierarchy_Sprite[i].sprite = MVU.GetPrepareStaffhierarchy(PrepareLady[i].Gethierarchy());
            //未解鎖
            else PrepareStaffLady_hierarchy_Sprite[i].sprite = null;           
        }
    }


    //============
    //開啟或關閉，PrepareStaffLadiesButton的interactable，(id : 第幾個出勤小姐欄位, ButtonState : Button狀態)
    //============
    public void SetPrepareStaffLadiesButton_interactable(int id , bool ButtonState)
    {
        PrepareStaffLadiesButton[id].interactable = ButtonState;
    }


    //============
    //(PrepareStaffAbility)
    //============


    //============
    //出勤小姐大頭照，(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffAbility_Picture(Lady_Class PrepareLady)
    {
        //已解鎖
        if (PrepareLady.GetisWorked() == true) PrepareStaffAbility_Picture_Sprite.sprite = MVU.LadyHeadShot[PrepareLady.Getid()];
        //未解鎖
        else PrepareStaffAbility_Picture_Sprite.sprite = null;
    }

    //============
    //清空出勤小姐大頭照
    //============
    public void SetPrepareStaffAbility_Picture_Clear()
    {
        PrepareStaffAbility_Picture_Sprite.sprite = null;
    }


    //============
    //小姐階級圖，(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffAbility_hierarchy(Lady_Class PrepareLady)
    {
        //已解鎖
        if (PrepareLady.GetisWorked() == true) PrepareStaffAbility_hierarchy_Sprite.sprite = MVU.GetPrepareStaffhierarchy(PrepareLady.Gethierarchy());
        //未解鎖
        else PrepareStaffAbility_hierarchy_Sprite.sprite = null;
    }

    //============
    //清空出勤小姐階級圖
    //============
    public void SetPrepareStaffAbility_hierarchy_Clear()
    {
        PrepareStaffAbility_hierarchy_Sprite.sprite = null;
    }


    //============
    //PrepareStaffAbility的Looks(Sexy)，(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffAbility_Looks_Sexy(Lady_Class PrepareLady)
    {
        PrepareStaffAbility_Looks_Sexy_Sprite.sprite = MVU.GetLooksSprite(PrepareLady.GetSexy());
    }

    //============
    //清空StaffLadies的Looks(Sexy)
    //============
    public void SetPrepareStaffAbility_Looks_Sexy_Clear()
    {
        PrepareStaffAbility_Looks_Sexy_Sprite.sprite = null;
    }

    //============
    //PrepareStaffAbility的Looks(Beauty)，(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffAbility_Looks_Beauty(Lady_Class PrepareLady)
    {
        PrepareStaffAbility_Looks_Beauty_Sprite.sprite = MVU.GetLooksSprite(PrepareLady.GetBeauty());
    }

    //============
    //清空PrepareStaffAbility的Looks(Beauty)
    //============
    public void SetPrepareStaffAbility_Looks_Beauty_Clear()
    {
        PrepareStaffAbility_Looks_Beauty_Sprite.sprite = null;
    }

    //============
    //PrepareStaffAbility的Looks(Cute)，(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffAbility_Looks_Cute(Lady_Class PrepareLady)
    {
        PrepareStaffAbility_Looks_Cute_Sprite.sprite = MVU.GetLooksSprite(PrepareLady.GetCute());
    }

    //============
    //清空PrepareStaffAbility的Looks(Cute)
    //============
    public void SetPrepareStaffAbility_Looks_Cute_Clear()
    {
        PrepareStaffAbility_Looks_Cute_Sprite.sprite = null;
    }

    //============
    //PrepareStaffAbility的Looks(Funny)，(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffAbility_Looks_Funny(Lady_Class PrepareLady)
    {
        PrepareStaffAbility_Looks_Funny_Sprite.sprite = MVU.GetLooksSprite(PrepareLady.GetFunny());
    }

    //============
    //清空PrepareStaffAbility的Looks(Funny)
    //============
    public void SetPrepareStaffAbility_Looks_Funny_Clear()
    {
        PrepareStaffAbility_Looks_Funny_Sprite.sprite = null;
    }


    //============
    //一次修改PrepareStaffAbility的Looks，(PrepareLady: 選定的出勤小姐)
    //============
    public void SetStaffLadies_Looks(Lady_Class PrepareLady)
    {
        SetPrepareStaffAbility_Looks_Sexy(PrepareLady);
        SetPrepareStaffAbility_Looks_Beauty(PrepareLady);
        SetPrepareStaffAbility_Looks_Cute(PrepareLady);
        SetPrepareStaffAbility_Looks_Funny(PrepareLady);
    }

    //============
    //一次清空PrepareStaffAbility的Looks
    //============
    public void SetStaffLadies_Looks_Clear()
    {
        SetPrepareStaffAbility_Looks_Sexy_Clear();
        SetPrepareStaffAbility_Looks_Beauty_Clear();
        SetPrepareStaffAbility_Looks_Cute_Clear();
        SetPrepareStaffAbility_Looks_Funny_Clear();
    }


    //============
    //PrepareStaffAbility的Name(Text)
    //============
    public void SetPrepareStaffAbility_Name_Text(string Name)
    {
        PrepareStaffAbility_Name_Text.text = "" + Name;      
    }

    //============
    //清空PrepareStaffAbility的Name(Text)
    //============
    public void SetPrepareStaffAbility_Name_Text_Clear()
    {
        PrepareStaffAbility_Name_Text.text = " ";
    }

    //============
    //PrepareStaffAbility的Level(Text)
    //============
    public void SetPrepareStaffAbility_Level_Text(int Level)
    {
        PrepareStaffAbility_Level_Text.text = "" + Level;
    }

    //============
    //清空PrepareStaffAbility的Level(Text)
    //============
    public void SetPrepareStaffAbility_Level_Text_Clear()
    {
        PrepareStaffAbility_Level_Text.text = " ";
    }

    //============
    //PrepareStaffAbility的Cost(Text)
    //============
    public void SetPrepareStaffAbility_Cost_Text(uint Cost)
    {
        PrepareStaffAbility_Cost_Text.text = "" + Cost + "元";
    }

    //============
    //清空PrepareStaffAbility的Cost(Text)
    //============
    public void SetPrepareStaffAbility_Cost_Text_Clear()
    {
        PrepareStaffAbility_Cost_Text.text = " ";
    }



    //============
    //PrepareStaffAbility的Hp(Text)
    //============
    public void SetPrepareStaffLadyAbility_Hp_Text(float Hp)
    {
        PrepareStaffLadyAbility_Hp_Text.text = "" + (int)Hp;
    }

    //============
    //清空PrepareStaffLadyAbility的Hp(Text)
    //============
    public void SetPrepareStaffLadyAbility_Hp_Text_Clear()
    {
        PrepareStaffLadyAbility_Hp_Text.text = " ";
    }

    //============
    //PrepareStaffLadyAbility的Talk(Text)
    //============
    public void SetPrepareStaffLadyAbility_Talk_Text(float Talk)
    {
        PrepareStaffLadyAbility_Talk_Text.text = "" + (int)Talk;
    }

    //============
    //清空PrepareStaffLadyAbility的Talk(Text)
    //============
    public void SetPrepareStaffLadyAbility_Talk_Text_Clear()
    {
        PrepareStaffLadyAbility_Talk_Text.text = " ";
    }

    //============
    //PrepareStaffLadyAbility的Party(Text)
    //============
    public void SetPrepareStaffLadyAbility_Party_Text(float Party)
    {
        PrepareStaffLadyAbility_Party_Text.text = "" + (int)Party;
    }

    //============
    //清空PrepareStaffLadyAbility的Party(Text)
    //============
    public void SetPrepareStaffLadyAbility_Party_Text_Clear()
    {
        PrepareStaffLadyAbility_Party_Text.text = " ";
    }

    //============
    //PrepareStaffLadyAbility的Love(Text)
    //============
    public void SetPrepareStaffLadyAbility_Love_Text(float Love)
    {
        PrepareStaffLadyAbility_Love_Text.text = "" + (int)Love;
    }

    //============
    //清空PrepareStaffLadyAbility的Love(Text)
    //============
    public void SetPrepareStaffLadyAbility_Love_Text_Clear()
    {
        PrepareStaffLadyAbility_Love_Text.text = " ";
    }

    //============
    //PrepareStaffLadyAbility的Skill(Text)
    //============
    public void SetPrepareStaffLadyAbility_Skill_Text(float Skill)
    {
        PrepareStaffLadyAbility_Skill_Text.text = "" + (int)Skill;
    }

    //============
    //清空PrepareStaffLadyAbility的Skill(Text)
    //============
    public void SetPrepareStaffLadyAbility_Skill_Text_Clear()
    {
        PrepareStaffLadyAbility_Skill_Text.text = " ";
    }

    //============
    //一次修改PrepareStaffLadyAbility的Name、Level、Cost、Hp、Talk、Party、Love、Skill的Text，(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffLadyAbility_Text(Lady_Class PrepareLady)
    {
        SetPrepareStaffAbility_Name_Text(PrepareLady.GetName());
        SetPrepareStaffAbility_Level_Text(PrepareLady.GetLevel());
        SetPrepareStaffAbility_Cost_Text(PrepareLady.GetCost());


        SetPrepareStaffLadyAbility_Hp_Text(PrepareLady.GetHp());
        SetPrepareStaffLadyAbility_Talk_Text(PrepareLady.GetTalk());
        SetPrepareStaffLadyAbility_Party_Text(PrepareLady.GetParty());
        SetPrepareStaffLadyAbility_Love_Text(PrepareLady.GetLove());
        SetPrepareStaffLadyAbility_Skill_Text(PrepareLady.GetSkill());
    }

    //============
    //一次清空PrepareStaffLadyAbility的Name、Level、Cost、Hp、Talk、Party、Love、Skill的Text
    //============
    public void SetPrepareStaffLadyAbility_Text_Clear()
    {
        SetPrepareStaffAbility_Name_Text_Clear();
        SetPrepareStaffAbility_Level_Text_Clear();
        SetPrepareStaffAbility_Cost_Text_Clear();


        SetPrepareStaffLadyAbility_Hp_Text_Clear();
        SetPrepareStaffLadyAbility_Talk_Text_Clear();
        SetPrepareStaffLadyAbility_Party_Text_Clear();
        SetPrepareStaffLadyAbility_Love_Text_Clear();
        SetPrepareStaffLadyAbility_Skill_Text_Clear();
    }


    //============
    //PrepareStaffLadyAbility的Hp的Bar_Image(Image)(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffLadyAbility_Hp_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        PrepareStaffLadyAbility_Hp_Bar.fillAmount = PrepareLady.GetHp() / 9999.0f;
    }

    //============
    //清空PrepareStaffLadyAbility的Hp的Bar_Image(Image)
    //============
    public void SetPrepareStaffLadyAbility_Hp_Bar_Image_FillAmount_Clear()
    {
        PrepareStaffLadyAbility_Hp_Bar.fillAmount = 0.0f;
    }

    //============
    //PrepareStaffLadyAbility的Talk的Bar_Image(Image)(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffLadyAbility_Talk_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        PrepareStaffLadyAbility_Talk_Bar_Image.fillAmount = PrepareLady.GetTalk() / 9999.0f;
    }

    //============
    //清空PrepareStaffLadyAbility的Talk的Bar_Image(Image)
    //============
    public void SetPrepareStaffLadyAbility_Talk_Bar_Image_FillAmount_Clear()
    {
        PrepareStaffLadyAbility_Talk_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //PrepareStaffLadyAbility的Party的Bar_Image(Image)(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffLadyAbility_Party_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        PrepareStaffLadyAbility_Party_Bar_Image.fillAmount = PrepareLady.GetParty() / 9999.0f;
    }

    //============
    //清空PrepareStaffLadyAbility的Party的Bar_Image(Image)
    //============
    public void SetPrepareStaffLadyAbility_Party_Bar_Image_FillAmount_Clear()
    {
        PrepareStaffLadyAbility_Party_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //PrepareStaffLadyAbility的Love的Bar_Image(Image)(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffLadyAbility_Love_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        PrepareStaffLadyAbility_Love_Bar_Image.fillAmount = PrepareLady.GetLove() / 9999.0f;
    }

    //============
    //清空PrepareStaffLadyAbility的Love的Bar_Image(Image)
    //============
    public void SetPrepareStaffLadyAbility_Love_Bar_Image_FillAmount_Clear()
    {
        PrepareStaffLadyAbility_Love_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //PrepareStaffLadyAbility的Skill的Bar_Image(Image)(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffLadyAbility_Skill_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        PrepareStaffLadyAbility_Skill_Bar_Image.fillAmount = PrepareLady.GetSkill() / 9999.0f;
    }

    //============
    //清空PrepareStaffLadyAbility的Skill的Bar_Image(Image)
    //============
    public void SetPrepareStaffLadyAbility_Skill_Bar_Image_FillAmount_Clear()
    {
        PrepareStaffLadyAbility_Skill_Bar_Image.fillAmount = 0.0f;
    }


    //============
    //一次修改PrepareStaffLadyAbility的Bar_Image(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffLadyAbility_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        SetPrepareStaffLadyAbility_Hp_Bar_Image_FillAmount(PrepareLady);
        SetPrepareStaffLadyAbility_Talk_Bar_Image_FillAmount(PrepareLady);
        SetPrepareStaffLadyAbility_Party_Bar_Image_FillAmount(PrepareLady);
        SetPrepareStaffLadyAbility_Love_Bar_Image_FillAmount(PrepareLady);
        SetPrepareStaffLadyAbility_Skill_Bar_Image_FillAmount(PrepareLady);
    }

    //============
    //一次清空PrepareStaffLadyAbility的Bar_Image
    //============
    public void SetPrepareStaffLadyAbility_Bar_Image_FillAmount_Clear()
    {
        SetPrepareStaffLadyAbility_Hp_Bar_Image_FillAmount_Clear();
        SetPrepareStaffLadyAbility_Talk_Bar_Image_FillAmount_Clear();
        SetPrepareStaffLadyAbility_Party_Bar_Image_FillAmount_Clear();
        SetPrepareStaffLadyAbility_Love_Bar_Image_FillAmount_Clear();
        SetPrepareStaffLadyAbility_Skill_Bar_Image_FillAmount_Clear();
    }


    //============
    //一次修改PrepareStaffLadyAbility(PrepareLady: 選定的出勤小姐)
    //============
    public void SetPrepareStaffLadyAbility(Lady_Class PrepareLady) {
        //選定的出勤小姐的大頭照
        SetPrepareStaffAbility_Picture(PrepareLady);
        //選定的出勤小姐的階級圖
        SetPrepareStaffAbility_hierarchy(PrepareLady);
        //選定的出勤小姐的Looks
        SetStaffLadies_Looks(PrepareLady);
        //選定的出勤小姐的Text
        SetPrepareStaffLadyAbility_Text(PrepareLady);
        //選定的出勤小姐的Bar_Image
        SetPrepareStaffLadyAbility_Bar_Image_FillAmount(PrepareLady);
       
    }

    //============
    //一次清空PrepareStaffLadyAbility
    //============
    public void SetPrepareStaffLadyAbility_Clear()
    {
        //選定的出勤小姐的大頭照
        SetPrepareStaffAbility_Picture_Clear();
        //選定的出勤小姐的階級圖
        SetPrepareStaffAbility_hierarchy_Clear();
        //選定的出勤小姐的Looks
        SetStaffLadies_Looks_Clear();
        //選定的出勤小姐的Text
        SetPrepareStaffLadyAbility_Text_Clear();
        //選定的出勤小姐的Bar_Image
        SetPrepareStaffLadyAbility_Bar_Image_FillAmount_Clear();

    }




    //============
    //(PrepareStaffAllAbility)
    //============


    //============
    //PrepareStaffAllAbility的Cost(Text)
    //============
    public void SetPrepareStaffAllAbility_Number_Text(int Number)
    {
        PrepareStaffAllAbility_Number_Text.text = "" + Number + "名";
    }

    //============
    //清空PrepareStaffAllAbility的Cost(Text)
    //============
    public void SetPrepareStaffAllAbility_Number_Text_Clear()
    {
        PrepareStaffAllAbility_Number_Text.text = " ";
    }

    //============
    //PrepareStaffAllAbility的Cost(Text)
    //============
    public void SetPrepareStaffAllAbility_Cost_Text(uint Cost)
    {
        PrepareStaffAllAbility_Cost_Text.text = "" + Cost + "元";
    }

    //============
    //清空PrepareStaffAllAbility的Cost(Text)
    //============
    public void SetPrepareStaffAllAbility_Cost_Text_Clear()
    {
        PrepareStaffAllAbility_Cost_Text.text = " ";
    }



    //============
    //PrepareStaffAbility的Hp(Text)
    //============
    public void SetPrepareStaffAllAbility_Hp_Text(float Hp)
    {
        PrepareStaffAllAbility_Hp_Text.text = "" + (int)Hp;
    }

    //============
    //清空PrepareStaffLadyAbility的Hp(Text)
    //============
    public void SetPrepareStaffAllAbility_Hp_Text_Clear()
    {
        PrepareStaffAllAbility_Hp_Text.text = " ";
    }

    //============
    //PrepareStaffAllAbility的Talk(Text)
    //============
    public void SetPrepareStaffAllAbility_Talk_Text(float Talk)
    {
        PrepareStaffAllAbility_Talk_Text.text = "" + (int)Talk;
    }

    //============
    //清空PrepareStaffAllAbility的Talk(Text)
    //============
    public void SetPrepareStaffAllAbility_Talk_Text_Clear()
    {
        PrepareStaffAllAbility_Talk_Text.text = " ";
    }

    //============
    //PrepareStaffAllAbility的Party(Text)
    //============
    public void SetPrepareStaffAllAbility_Party_Text(float Party)
    {
        PrepareStaffAllAbility_Party_Text.text = "" + (int)Party;
    }

    //============
    //清空PrepareStaffAllAbility的Party(Text)
    //============
    public void SetPrepareStaffAllAbility_Party_Text_Clear()
    {
        PrepareStaffAllAbility_Party_Text.text = " ";
    }

    //============
    //PrepareStaffAllAbility的Love(Text)
    //============
    public void SetPrepareStaffAllAbility_Love_Text(float Love)
    {
        PrepareStaffAllAbility_Love_Text.text = "" + (int)Love;
    }

    //============
    //清空PrepareStaffAllAbility的Love(Text)
    //============
    public void SetPrepareStaffAllAbility_Love_Text_Clear()
    {
        PrepareStaffAllAbility_Love_Text.text = " ";
    }

    //============
    //PrepareStaffAllAbility的Skill(Text)
    //============
    public void SetPrepareStaffAllAbility_Skill_Text(float Skill)
    {
        PrepareStaffAllAbility_Skill_Text.text = "" + (int)Skill;
    }

    //============
    //清空PrepareStaffAllAbility的Skill(Text)
    //============
    public void SetPrepareStaffAllAbility_Skill_Text_Clear()
    {
        PrepareStaffAllAbility_Skill_Text.text = " ";
    }


    //============
    //一次修改PrepareStaffAllAbility的Number、Cost、Hp、Talk、Party、Love、Skill的Text，(Number : 出勤小姐人數，PrepareLady: 全部的出勤小姐)
    //============
    public void SetPrepareStaffLadyAllAbility_Text(int Number , Lady_Class[] PrepareLady)
    {
        SetPrepareStaffAllAbility_Number_Text(Number);
        SetPrepareStaffAllAbility_Cost_Text(MVU.Sum_PrepareStaffLadyAbility_Cost(PrepareLady));


        SetPrepareStaffAllAbility_Hp_Text(MVU.Sum_PrepareStaffLadyAbility_Hp(PrepareLady));
        SetPrepareStaffAllAbility_Talk_Text(MVU.Sum_PrepareStaffLadyAbility_Talk(PrepareLady));
        SetPrepareStaffAllAbility_Party_Text(MVU.Sum_PrepareStaffLadyAbility_Party(PrepareLady));
        SetPrepareStaffAllAbility_Love_Text(MVU.Sum_PrepareStaffLadyAbility_Love(PrepareLady));
        SetPrepareStaffAllAbility_Skill_Text(MVU.Sum_PrepareStaffLadyAbility_Skill(PrepareLady));
    }

    //============
    //一次清空PrepareStaffLadyAbility的Cost、Hp、Talk、Party、Love、Skill的Text
    //============
    public void SetPrepareStaffAllAbility_Text_Clear()
    {
        SetPrepareStaffAllAbility_Number_Text_Clear();
        SetPrepareStaffAllAbility_Cost_Text_Clear();

        SetPrepareStaffAllAbility_Hp_Text_Clear();
        SetPrepareStaffAllAbility_Talk_Text_Clear();
        SetPrepareStaffAllAbility_Party_Text_Clear();
        SetPrepareStaffAllAbility_Love_Text_Clear();
        SetPrepareStaffAllAbility_Skill_Text_Clear();
    }


    //============
    //PrepareStaffAllAbility的Hp的Bar_Image(Image)(PrepareLady: 所有的出勤小姐)
    //============
    public void SetPrepareStaffAllAbility_Hp_Bar_Image_FillAmount(Lady_Class[] PrepareLady)
    {
        PrepareStaffAllAbility_Hp_Bar.fillAmount = MVU.Sum_PrepareStaffLadyAbility_Hp(PrepareLady) / 99999.0f;
    }

    //============
    //清空PrepareStaffAllAbility的Hp的Bar_Image(Image)
    //============
    public void SetPrepareStaffAllAbility_Hp_Bar_Image_FillAmount_Clear()
    {
        PrepareStaffAllAbility_Hp_Bar.fillAmount = 0.0f;
    }

    //============
    //PrepareStaffAllAbility的Talk的Bar_Image(Image)(PrepareLady: 所有的出勤小姐)
    //============
    public void SetPrepareStaffAllAbility_Talk_Bar_Image_FillAmount(Lady_Class[] PrepareLady)
    {
        PrepareStaffAllAbility_Talk_Bar_Image.fillAmount = MVU.Sum_PrepareStaffLadyAbility_Talk(PrepareLady) / 99999.0f;
    }

    //============
    //清空PrepareStaffAllAbility的Talk的Bar_Image(Image)
    //============
    public void SetPrepareStaffAllAbility_Talk_Bar_Image_FillAmount_Clear()
    {
        PrepareStaffAllAbility_Talk_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //PrepareStaffAllAbility的Party的Bar_Image(Image)(PrepareLady: 所有的出勤小姐)
    //============
    public void SetPrepareStaffAllAbility_Party_Bar_Image_FillAmount(Lady_Class[] PrepareLady)
    {
        PrepareStaffAllAbility_Party_Bar_Image.fillAmount = MVU.Sum_PrepareStaffLadyAbility_Party(PrepareLady) / 99999.0f;
    }

    //============
    //清空PrepareStaffAllAbility的Party的Bar_Image(Image)
    //============
    public void SetPrepareStaffAllAbility_Party_Bar_Image_FillAmount_Clear()
    {
        PrepareStaffAllAbility_Party_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //PrepareStaffAllAbility的Love的Bar_Image(Image)(PrepareLady: 所有的出勤小姐)
    //============
    public void SetPrepareStaffAllAbility_Love_Bar_Image_FillAmount(Lady_Class[] PrepareLady)
    {
        PrepareStaffAllAbility_Love_Bar_Image.fillAmount = MVU.Sum_PrepareStaffLadyAbility_Love(PrepareLady) / 99999.0f;
    }

    //============
    //清空PrepareStaffAllAbility的Love的Bar_Image(Image)
    //============
    public void SetPrepareStaffAllAbility_Love_Bar_Image_FillAmount_Clear()
    {
        PrepareStaffAllAbility_Love_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //PrepareStaffAllAbility的Skill的Bar_Image(Image)(PrepareLady: 所有的出勤小姐)
    //============
    public void SetPrepareStaffAllAbility_Skill_Bar_Image_FillAmount(Lady_Class[] PrepareLady)
    {
        PrepareStaffAllAbility_Skill_Bar_Image.fillAmount = MVU.Sum_PrepareStaffLadyAbility_Skill(PrepareLady) / 99999.0f;
    }

    //============
    //清空PrepareStaffAllAbility的Skill的Bar_Image(Image)
    //============
    public void SetPrepareStaffAllAbility_Skill_Bar_Image_FillAmount_Clear()
    {
        PrepareStaffAllAbility_Skill_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //一次修改PrepareStaffAllAbility的Bar_Image(PrepareLady: 所有的出勤小姐)
    //============
    public void SetPrepareStaffAllAbility_Bar_Image_FillAmount(Lady_Class[] PrepareLady)
    {
        SetPrepareStaffAllAbility_Hp_Bar_Image_FillAmount(PrepareLady);
        SetPrepareStaffAllAbility_Talk_Bar_Image_FillAmount(PrepareLady);
        SetPrepareStaffAllAbility_Party_Bar_Image_FillAmount(PrepareLady);
        SetPrepareStaffAllAbility_Love_Bar_Image_FillAmount(PrepareLady);
        SetPrepareStaffAllAbility_Skill_Bar_Image_FillAmount(PrepareLady);
    }

    //============
    //一次清空PrepareStaffAllAbility的Bar_Image
    //============
    public void SetPrepareStaffAllAbility_Bar_Image_FillAmount_Clear()
    {
        SetPrepareStaffAllAbility_Hp_Bar_Image_FillAmount_Clear();
        SetPrepareStaffAllAbility_Talk_Bar_Image_FillAmount_Clear();
        SetPrepareStaffAllAbility_Party_Bar_Image_FillAmount_Clear();
        SetPrepareStaffAllAbility_Love_Bar_Image_FillAmount_Clear();
        SetPrepareStaffAllAbility_Skill_Bar_Image_FillAmount_Clear();
    }


    //============
    //一次修改PreStaff，(Number : 出勤小姐人數，PrepareLady: 所有的出勤小姐)
    //============
    public void SetPrepareStaff(int Number , Lady_Class[] PrepareLady)
    {
        //出勤小姐大頭照，(PrepareLady: Model_Manage_Script下的出勤小姐)
        SetPrepareStaffLady_Sprite(PrepareLady);
        //出勤小姐階級圖，(PrepareLady: Model_Manage_Script下的出勤小姐)
        SetPrepareStaffLady_hierarchy_Sprite(PrepareLady);

        //一次修改PrepareStaffAllAbility的Number、Cost、Hp、Talk、Party、Love、Skill的Text，(Number : 出勤小姐人數，PrepareLady: 全部的出勤小姐)
        SetPrepareStaffLadyAllAbility_Text(Number , PrepareLady);
        //一次修改PrepareStaffAllAbility的Bar_Image(PrepareLady: 所有的出勤小姐)
        SetPrepareStaffAllAbility_Bar_Image_FillAmount(PrepareLady);

    }

}//View_Manage_PrepareStaff_Script
