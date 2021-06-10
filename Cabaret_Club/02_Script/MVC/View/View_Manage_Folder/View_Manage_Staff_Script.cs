/*
 * View : StaffBase、StaffBaseCanvas的View
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class View_Manage_Staff_Script : MonoBehaviour
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
    //(StaffLadies)
    //============

    //出勤小姐大頭照
    public SpriteRenderer[] StaffLady_Picture_Sprite = new SpriteRenderer[8];

    //出勤小姐階級圖
    public SpriteRenderer[] StaffLady_hierarchy_Sprite = new SpriteRenderer[8];

    //============
    //(StaffAbility)
    //============

    //出勤小姐大頭照
    public SpriteRenderer StaffAbility_Picture_Sprite;

    //出勤小姐階級圖
    public SpriteRenderer StaffAbility_hierarchy_Sprite;

    //出勤小姐Looks的Sexy圖
    public SpriteRenderer StaffAbility_Looks_Sexy_Sprite;

    //出勤小姐Looks的Beauty圖
    public SpriteRenderer StaffAbility_Looks_Beauty_Sprite;

    //出勤小姐Looks的Cute圖
    public SpriteRenderer StaffAbility_Looks_Cute_Sprite;

    //出勤小姐Looks的Funny圖
    public SpriteRenderer StaffAbility_Looks_Funny_Sprite;

    //============
    //Text
    //============

    //============
    //(StaffLadies)
    //============

    //出勤字樣
    public Text[] StaffLadies_Work_Text = new Text[8];

    //當前頁數
    public Text StaffLady_Page_Text;



    //============
    //(StaffAbility)
    //============

    //小姐性名
    public Text StaffAbility_Name_Text;

    //小姐等級
    public Text StaffAbility_Level_Text;

    //小姐薪水
    public Text StaffAbility_Cost_Text;

    //小姐營業額
    public Text StaffAbility_Revenue_Text;

    //小姐Hp
    public Text StaffLadyAbility_Hp_Text;
    //小姐Talk
    public Text StaffLadyAbility_Talk_Text;
    //小姐Party
    public Text StaffLadyAbility_Party_Text;
    //小姐Love
    public Text StaffLadyAbility_Love_Text;
    //小姐Skill
    public Text StaffLadyAbility_Skill_Text;

    //小姐資訊
    public Text StaffLady_Description_Text;


    //============
    //Image
    //============

    //============
    //(StaffAbility)
    //============

    //出勤小姐的Hp，長條圖
    public Image StaffLadyAbility_Hp_Bar_Image;

    //出勤小姐的Talk，長條圖
    public Image StaffLadyAbility_Talk_Bar_Image;

    //出勤小姐的Party，長條圖
    public Image StaffLadyAbility_Party_Bar_Image;

    //出勤小姐的Love，長條圖
    public Image StaffLadyAbility_Love_Bar_Image;

    //出勤小姐的Skill，長條圖
    public Image StaffLadyAbility_Skill_Bar_Image;


    //============
    //Button
    //============

    //============
    //(StaffLadies)
    //============
    
    //上一頁Button
    public Button StaffPage_Button_Previous;

    //下一頁Button
    public Button StaffPage_Button_Next;


    //======================================================
    //外部方法
    //======================================================

    //============
    //(Staff頁面 : StaffLadies)
    //============

    //============
    //小姐大頭照，(Page: 當前頁數 ， StaffLadies: 所有的在籍小姐)
    //============
    public void SetStaffLadies_HeadShot(int Page , Lady_Class[] StaffLadies)
    {
       
        for (i = 0; i < 8; i++)
        {
            //已解鎖
            if (StaffLadies[i + (Page * 8)].GetisunLock() == true)  StaffLady_Picture_Sprite[i].sprite = MVU.LadyHeadShot[StaffLadies[i + (Page * 8)].Getid()];
            //未解鎖
            else StaffLady_Picture_Sprite[i].sprite = null;

            //由於只有30名在籍小姐，最後一頁的最後2個欄位不會有資料，所以要跳出，並將最後兩張圖設為null，防止超出陣列範圍
            if (i + (Page * 8) == 29) {
                StaffLady_Picture_Sprite[6].sprite = null;
                StaffLady_Picture_Sprite[7].sprite = null;
                break;
            }
        }
    }

    //============
    //小姐階級圖，(Page: 當前頁數 ， StaffLadies: 所有的在籍小姐)
    //============
    public void SetStaffLadies_hierarchy(int Page , Lady_Class[] StaffLadies)
    {
        for (i = 0; i < 8; i++)
        {
            //已解鎖
            if (StaffLadies[i + (Page*8)].GetisunLock() == true) StaffLady_hierarchy_Sprite[i].sprite = MVU.GetPrepareStaffhierarchy(StaffLadies[i + (Page * 8)].Gethierarchy());
            //未解鎖
            else StaffLady_hierarchy_Sprite[i].sprite = null;

            //由於只有30名在籍小姐，最後一頁的最後2個欄位不會有資料，所以要跳出，並將最後兩張圖設為null，防止超出陣列範圍
            if (i + (Page * 8) == 29)
            {
                StaffLady_hierarchy_Sprite[6].sprite = null;
                StaffLady_hierarchy_Sprite[7].sprite = null;
                break;
            }
        }
    }


    //============
    //出勤字樣，(Page: 當前頁數，StaffLadies: 所有的在籍小姐)
    //============
    public void SetStaffLadies_Work_Text(int Page , Lady_Class[] StaffLadies) {

        for (i = 0; i < 8; i++) {
            //出勤中
            if (StaffLadies[i + (Page * 8)].GetisWorked() == true) StaffLadies_Work_Text[i].text = "出勤";
            //未出勤
            else StaffLadies_Work_Text[i].text = "";

            //由於只有30名在籍小姐，最後一頁的最後2個欄位不會有資料，所以要跳出，防止超出陣列範圍
            if (i + (Page * 8) == 29) break;
        }

    }

    //============
    //當前頁數(Page: 當前頁數)
    //============
    public void SetStaffLady_Page_Text(int Page) {
        //(Page + 1)是因為Page是從0開始，方便其它方法使用陣列
        StaffLady_Page_Text.text = (Page + 1) + "/" + "4";
    }



    //============
    //一次修改StaffLadies，(Page: 當前頁數 ， StaffLadies: 所有的在籍小姐)
    //============
    public void SetStaffLadies(int Page, Lady_Class[] StaffLadies)
    {
        SetStaffLadies_HeadShot(Page, StaffLadies);
        SetStaffLadies_hierarchy(Page, StaffLadies);
        SetStaffLadies_Work_Text(Page, StaffLadies);
        SetStaffLady_Page_Text(Page);
    }

    //============
    //開啟或關閉，StaffPage_Button_Previous的interactable，(ButtonState : Button狀態)
    //============
    public void SetStaffPage_Button_Previous_interactable(bool ButtonState) {
        StaffPage_Button_Previous.interactable = ButtonState;
    }


    //============
    //開啟或關閉，StaffPage_Button_Next的interactable，(ButtonState : Button狀態)
    //============
    public void SetStaffPage_Button_Next_interactable(bool ButtonState)
    {
        StaffPage_Button_Next.interactable = ButtonState;
    }

    //============
    //一次修改StaffPage_Button_Previous、StaffPage_Button_Next的interactable(Page: 當前頁數)
    //============
    public void SetStaffPage_Button(int Page)
    {
        MVU.StaffPage_Button_interactable(Page , StaffPage_Button_Previous , StaffPage_Button_Next);
    }




    //============
    //(Staff頁面 : StaffAbility)
    //============

    //============
    //小姐大頭照，(StaffLadies: 選定的在籍小姐)
    //============
    public void SetStaffAbility_Picture_Sprite(Lady_Class StaffLadies)
    {
        //已解鎖
        if (StaffLadies.GetisunLock() == true) StaffAbility_Picture_Sprite.sprite = MVU.LadyHeadShot[StaffLadies.Getid()];
        //未解鎖
        else StaffAbility_Picture_Sprite.sprite = null;
    }

    //============
    //清空小姐大頭照
    //============
    public void SetStaffAbility_Picture_Sprite_Clear()
    {
        StaffAbility_Picture_Sprite.sprite = null;
    }


    //============
    //小姐階級圖，(StaffLadies: 選定的在籍小姐)
    //============
    public void SetStaffLadies_hierarchy(Lady_Class StaffLadies)
    {
        //已解鎖
        if (StaffLadies.GetisunLock() == true) StaffAbility_hierarchy_Sprite.sprite = MVU.GetPrepareStaffhierarchy(StaffLadies.Gethierarchy());
        //未解鎖
        else StaffAbility_hierarchy_Sprite.sprite = null;
    }

    //============
    //清空小姐階級圖
    //============
    public void SetStaffLadies_hierarchy_Clear()
    {
        StaffAbility_hierarchy_Sprite.sprite = null;
    }


    //============
    //StaffLadies的Looks(Sexy)，(StaffLadies: 選定的在籍小姐)
    //============
    public void SetStaffLadies_Looks_Sexy(Lady_Class StaffLadies)
    {
        StaffAbility_Looks_Sexy_Sprite.sprite = MVU.GetLooksSprite(StaffLadies.GetSexy());
    }

    //============
    //清空StaffLadies的Looks(Sexy)
    //============
    public void SetStaffLadies_Looks_Sexy_Clear()
    {
        StaffAbility_Looks_Sexy_Sprite.sprite = null;
    }

    //============
    //StaffLadies的Looks(Beauty)，(StaffLadies: 選定的在籍小姐)
    //============
    public void SetStaffLadies_Looks_Beauty(Lady_Class StaffLadies)
    {
        StaffAbility_Looks_Beauty_Sprite.sprite = MVU.GetLooksSprite(StaffLadies.GetBeauty());
    }

    //============
    //清空StaffLadies的Looks(Beauty)
    //============
    public void SetStaffLadies_Looks_Beauty_Clear()
    {
        StaffAbility_Looks_Beauty_Sprite.sprite = null;
    }

    //============
    //StaffLadies的Looks(Cute)，(StaffLadies: 選定的在籍小姐)
    //============
    public void SetStaffLadies_Looks_Cute(Lady_Class StaffLadies)
    {
        StaffAbility_Looks_Cute_Sprite.sprite = MVU.GetLooksSprite(StaffLadies.GetCute());
    }

    //============
    //清空StaffLadies的Looks(Cute)
    //============
    public void SetStaffLadies_Looks_Cute_Clear()
    {
        StaffAbility_Looks_Cute_Sprite.sprite = null;
    }

    //============
    //StaffLadies的Looks(Funny)，(StaffLadies: 選定的在籍小姐)
    //============
    public void SetStaffLadies_Looks_Funny(Lady_Class StaffLadies)
    {
        StaffAbility_Looks_Funny_Sprite.sprite = MVU.GetLooksSprite(StaffLadies.GetFunny());
    }

    //============
    //清空StaffLadies的Looks(Funny)
    //============
    public void SetStaffLadies_Looks_Funny_Clear()
    {
        StaffAbility_Looks_Funny_Sprite.sprite = null;
    }

    //============
    //一次修改StaffLadies的Looks
    //============
    public void SetStaffLadies_Looks(Lady_Class StaffLadies)
    {
        SetStaffLadies_Looks_Sexy(StaffLadies);
        SetStaffLadies_Looks_Beauty(StaffLadies);
        SetStaffLadies_Looks_Cute(StaffLadies);
        SetStaffLadies_Looks_Funny(StaffLadies);
    }

    //============
    //一次清空StaffLadies的Looks
    //============
    public void SetStaffLadies_Looks_Clear()
    {
        SetStaffLadies_Looks_Sexy_Clear();
        SetStaffLadies_Looks_Beauty_Clear();
        SetStaffLadies_Looks_Cute_Clear();
        SetStaffLadies_Looks_Funny_Clear();
    }

   
 
    //============
    //StaffAbility的Name(Text)
    //============
    public void SetStaffAbility_Name_Text(string Name)
    {
        StaffAbility_Name_Text.text = "" + Name;
    }

    //============
    //清空StaffAbility的Name(Text)
    //============
    public void SetStaffLadyAbility_Name_Text_Clear()
    {
        StaffAbility_Name_Text.text = " ";
    }

    //============
    //StaffAbility的Level(Text)
    //============
    public void SetStaffAbility_Level_Text(int Level)
    {
        StaffAbility_Level_Text.text = "" + Level;
    }

    //============
    //清空StaffAbility的Level(Text)
    //============
    public void SetStaffLadyAbility_Level_Text_Clear()
    {
        StaffAbility_Level_Text.text = " ";
    }

    //============
    //StaffAbility的Cost(Text)
    //============
    public void SetStaffAbility_Cost_Text(uint Cost)
    {
        StaffAbility_Cost_Text.text = "" + Cost + "元";
    }

    //============
    //清空StaffAbility的Cost(Text)
    //============
    public void SetStaffLadyAbility_Cost_Text_Clear()
    {
        StaffAbility_Cost_Text.text = " ";
    }

    //============
    //StaffAbility的Revenue(Text)
    //============
    public void SetStaffAbility_Revenue_Text(ulong Revenue)
    {
        StaffAbility_Revenue_Text.text = "" + Revenue + "元";
    }

    //============
    //清空StaffAbility的Revenue(Text)
    //============
    public void SetStaffLadyAbility_Revenue_Text_Clear()
    {
        StaffAbility_Revenue_Text.text = " ";
    }

    //============
    //StaffAbility的Description(Text)
    //============
    public void SetStaffAbility_Description_Text(string Description)
    {
        StaffLady_Description_Text.text = "" + Description;
    }

    //============
    //清空StaffAbility的Description(Text)
    //============
    public void SetStaffLadyAbility_Description_Text_Clear()
    {
        StaffLady_Description_Text.text = " ";
    }


    //============
    //StaffAbility的Hp(Text)
    //============
    public void SetStaffLadyAbility_Hp_Text(float Hp)
    {
        StaffLadyAbility_Hp_Text.text = "" + (int)Hp;
    }

    //============
    //清空StaffAbility的Hp(Text)
    //============
    public void SetStaffLadyAbility_Hp_Text_Clear()
    {
        StaffLadyAbility_Hp_Text.text = " ";
    }

    //============
    //StaffAbility的Talk(Text)
    //============
    public void SetStaffLadyAbility_Talk_Text(float Talk)
    {
        StaffLadyAbility_Talk_Text.text = "" + (int)Talk;
    }

    //============
    //清空StaffAbility的Talk(Text)
    //============
    public void SetStaffLadyAbility_Talk_Text_Clear()
    {
        StaffLadyAbility_Talk_Text.text = " ";
    }

    //============
    //StaffAbility的Party(Text)
    //============
    public void SetStaffLadyAbility_Party_Text(float Party)
    {
        StaffLadyAbility_Party_Text.text = "" + (int)Party;
    }

    //============
    //清空StaffAbility的Party(Text)
    //============
    public void SetStaffLadyAbility_Party_Text_Clear()
    {
        StaffLadyAbility_Party_Text.text = " ";
    }

    //============
    //StaffAbility的Love(Text)
    //============
    public void SetStaffLadyAbility_Love_Text(float Love)
    {
        StaffLadyAbility_Love_Text.text = "" + (int)Love;
    }

    //============
    //清空StaffAbility的Love(Text)
    //============
    public void SetStaffLadyAbility_Love_Text_Clear()
    {
        StaffLadyAbility_Love_Text.text = " ";
    }

    //============
    //StaffAbility的Skill(Text)
    //============
    public void SetStaffLadyAbility_Skill_Text(float Skill)
    {
        StaffLadyAbility_Skill_Text.text = "" + (int)Skill;
    }

    //============
    //清空StaffAbility的Skill(Text)
    //============
    public void SetStaffLadyAbility_Skill_Text_Clear()
    {
        StaffLadyAbility_Skill_Text.text = " ";
    }

    //============
    //一次修改StaffAbility的Name、Level、Cost、Revenue、Description、Hp、Talk、Party、Love、Skill的Text
    //============
    public void SetStaffLadyAbility_Text(Lady_Class StaffLadies)
    {
        SetStaffAbility_Name_Text(StaffLadies.GetName());
        SetStaffAbility_Level_Text(StaffLadies.GetLevel());
        SetStaffAbility_Cost_Text(StaffLadies.GetCost());
        SetStaffAbility_Revenue_Text(StaffLadies.GetAllIncome());
        SetStaffAbility_Description_Text(StaffLadies.GetDescription());

        SetStaffLadyAbility_Hp_Text(StaffLadies.GetHp());
        SetStaffLadyAbility_Talk_Text(StaffLadies.GetTalk());
        SetStaffLadyAbility_Party_Text(StaffLadies.GetParty());
        SetStaffLadyAbility_Love_Text(StaffLadies.GetLove());
        SetStaffLadyAbility_Skill_Text(StaffLadies.GetSkill());
    }

    //============
    //一次清空StaffAbility的Name、Level、Cost、Revenue、Description、Hp、Talk、Party、Love、Skill的Text
    //============
    public void SetStaffLadyAbility_Text_Clear()
    {
        SetStaffLadyAbility_Name_Text_Clear();
        SetStaffLadyAbility_Level_Text_Clear();
        SetStaffLadyAbility_Cost_Text_Clear();
        SetStaffLadyAbility_Revenue_Text_Clear();
        SetStaffLadyAbility_Description_Text_Clear();

        SetStaffLadyAbility_Hp_Text_Clear();
        SetStaffLadyAbility_Talk_Text_Clear();
        SetStaffLadyAbility_Party_Text_Clear();
        SetStaffLadyAbility_Love_Text_Clear();
        SetStaffLadyAbility_Skill_Text_Clear();
    }



    //============
    //StaffLadyAbility的Hp的Bar_Image(Image)(StaffLadies: 選定的在籍小姐)
    //============
    public void SetStaffLadyAbility_Hp_Bar_Image_FillAmount(Lady_Class StaffLadies)
    {
        StaffLadyAbility_Hp_Bar_Image.fillAmount = StaffLadies.GetHp() / 9999.0f;
    }

    //============
    //清空StaffLadyAbility的Hp的Bar_Image(Image)
    //============
    public void SetStaffLadyAbility_Hp_Bar_Image_FillAmount_Clear()
    {
        StaffLadyAbility_Hp_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //StaffLadyAbility的Talk的Bar_Image(Image)(PrepareLady : 選定的在籍小姐)
    //============
    public void SetStaffLadyAbility_Talk_Bar_Image_FillAmount(Lady_Class StaffLadies)
    {
        StaffLadyAbility_Talk_Bar_Image.fillAmount = StaffLadies.GetTalk() / 9999.0f;
    }

    //============
    //清空StaffLadyAbility的Talk的Bar_Image(Image)
    //============
    public void SetStaffLadyAbility_Talk_Bar_Image_FillAmount_Clear()
    {
        StaffLadyAbility_Talk_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //StaffLadyAbility的Party的Bar_Image(Image)(StaffLadies : 選定的在籍小姐)
    //============
    public void SetStaffLadyAbility_Party_Bar_Image_FillAmount(Lady_Class StaffLadies)
    {
        StaffLadyAbility_Party_Bar_Image.fillAmount = StaffLadies.GetParty() / 9999.0f;
    }

    //============
    //清空StaffLadyAbility的Party的Bar_Image(Image)
    //============
    public void SetStaffLadyAbility_Party_Bar_Image_FillAmount_Clear()
    {
        StaffLadyAbility_Party_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //StaffLadyAbility的Love的Bar_Image(Image)(StaffLadies : 選定的在籍小姐)
    //============
    public void SetStaffLadyAbility_Love_Bar_Image_FillAmount(Lady_Class StaffLadies)
    {
        StaffLadyAbility_Love_Bar_Image.fillAmount = StaffLadies.GetLove() / 9999.0f;
    }

    //============
    //清空StaffLadyAbility的Love的Bar_Image(Image)
    //============
    public void SetStaffLadyAbility_Love_Bar_Image_FillAmount_Clear()
    {
        StaffLadyAbility_Love_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //StaffLadyAbility的Skill的Bar_Image(Image)(StaffLadies : 選定的在籍小姐)
    //============
    public void SetStaffLadyAbility_Skill_Bar_Image_FillAmount(Lady_Class StaffLadies)
    {
        StaffLadyAbility_Skill_Bar_Image.fillAmount = StaffLadies.GetSkill() / 9999.0f;
    }

    //============
    //清空StaffLadyAbility的Skill的Bar_Image(Image)
    //============
    public void SetStaffLadyAbility_Skill_Bar_Image_FillAmount_Clear()
    {
        StaffLadyAbility_Skill_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //一次修改StaffLadyAbility的Bar_Image的Text(StaffLadies : 選定的在籍小姐)
    //============
    public void SetStaffLadyAbility_Bar_Image_FillAmount(Lady_Class StaffLadies)
    {
        SetStaffLadyAbility_Hp_Bar_Image_FillAmount(StaffLadies);
        SetStaffLadyAbility_Talk_Bar_Image_FillAmount(StaffLadies);
        SetStaffLadyAbility_Party_Bar_Image_FillAmount(StaffLadies);
        SetStaffLadyAbility_Love_Bar_Image_FillAmount(StaffLadies);
        SetStaffLadyAbility_Skill_Bar_Image_FillAmount(StaffLadies);
    }

    //============
    //一次清空StaffLadyAbility的Bar_Image
    //============
    public void SetStaffLadyAbility_Bar_Image_FillAmount_Clear()
    {
        SetStaffLadyAbility_Hp_Bar_Image_FillAmount_Clear();
        SetStaffLadyAbility_Talk_Bar_Image_FillAmount_Clear();
        SetStaffLadyAbility_Party_Bar_Image_FillAmount_Clear();
        SetStaffLadyAbility_Love_Bar_Image_FillAmount_Clear();
        SetStaffLadyAbility_Skill_Bar_Image_FillAmount_Clear();
    }




    //============
    //StaffLadies的Looks的Color(Sexy)
    //============
    public void SetStaffLadies_Looks_Sexy_Color(Lady_Class StaffLadies)
    {
        StaffAbility_Looks_Sexy_Sprite.color = MVU.GetLady_Looks_Color(StaffLadies.GetSexy());
    }

    //============
    //StaffLadies的Looks的Color(Beauty)
    //============
    public void SetStaffLadies_Looks_Beauty_Color(Lady_Class StaffLadies)
    {
        StaffAbility_Looks_Beauty_Sprite.color = MVU.GetLady_Looks_Color(StaffLadies.GetBeauty());
    }

    //============
    //StaffLadies的Looks的Color(Cute)
    //============
    public void SetStaffLadies_Looks_Cute_Color(Lady_Class StaffLadies)
    {
        StaffAbility_Looks_Cute_Sprite.color = MVU.GetLady_Looks_Color(StaffLadies.GetCute());
    }

    //============
    //StaffLadies的Looks的Color(Funny)
    //============
    public void SetStaffLadies_Looks_Funny_Color(Lady_Class StaffLadies)
    {
        StaffAbility_Looks_Funny_Sprite.color = MVU.GetLady_Looks_Color(StaffLadies.GetFunny());
    }

    //============
    //一次修改StaffLadies的Looks的Color
    //============
    public void SetStaffLadies_Looks_Color(Lady_Class StaffLadies)
    {
        SetStaffLadies_Looks_Sexy_Color(StaffLadies);
        SetStaffLadies_Looks_Beauty_Color(StaffLadies);
        SetStaffLadies_Looks_Cute_Color(StaffLadies);
        SetStaffLadies_Looks_Funny_Color(StaffLadies);
    }



    //============
    //一次修改StaffAbility的所有項目(StaffLadies : 選定的在籍小姐)
    //============
    public void SetStaffLadyAbility(Lady_Class StaffLadies)
    {
        SetStaffAbility_Picture_Sprite(StaffLadies);
        SetStaffLadies_hierarchy(StaffLadies);
        SetStaffLadyAbility_Text(StaffLadies);
        SetStaffLadyAbility_Bar_Image_FillAmount(StaffLadies);
        SetStaffLadies_Looks(StaffLadies);
        SetStaffLadies_Looks_Color(StaffLadies);
    }

    //============
    //一次清空StaffAbility的所有項目
    //============
    public void SetStaffLadyAbility_Clear()
    {
        SetStaffAbility_Picture_Sprite_Clear();
        SetStaffLadies_hierarchy_Clear();
        SetStaffLadyAbility_Text_Clear();
        SetStaffLadyAbility_Bar_Image_FillAmount_Clear();
        SetStaffLadies_Looks_Clear();
    }

}//View_Manage_Staff_Script
