/*
 * View : PrepareBase、PrepareBaseCanvas的View
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_Manage_Prepare_Script : MonoBehaviour
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
    //(PrepareStaff)
    //============

    //出勤小姐大頭照
    public SpriteRenderer[] PrepareStaff_Picture_Sprite = new SpriteRenderer[8];

    //出勤小姐階級圖
    public SpriteRenderer[] PrepareStaff_hierarchy_Sprite = new SpriteRenderer[8];

    //============
    //Text
    //============

    //============
    //(PreparStaff)
    //============

    //出勤小姐名字
    public Text[] PrepareStaffName_Text = new Text[8];

    //出勤小姐等級
    public Text[] PrepareStaffLevel_Text = new Text[8];

    //============
    //(PrepareAbility)
    //============

    //出勤小姐的Hp
    public Text PrepareAbility_Hp_Text;

    //出勤小姐的Talk
    public Text PrepareAbility_Talk_Text;

    //出勤小姐的Party
    public Text PrepareAbility_Party_Text;

    //出勤小姐的Love
    public Text PrepareAbility_Love_Text;

    //出勤小姐的Skill
    public Text PrepareAbility_Skill_Text;

    //出勤小姐人數
    public Text PrepareNumber_Text;

    //出勤花費
    public Text PrepareCost_Text;

    //============
    //Image
    //============

    //============
    //(PreparStaff)
    //============

    //出勤小姐Hp，長條圖
    public Image[] PrepareStaffHp_InSide_Image = new Image[8];

    //============
    //(PrepareAbility)
    //============

    //出勤小姐的Hp，長條圖
    public Image PrepareAbility_Hp_Bar_Image;

    //出勤小姐的Talk，長條圖
    public Image PrepareAbility_Talk_Bar_Image;

    //出勤小姐的Party，長條圖
    public Image PrepareAbility_Party_Bar_Image;

    //出勤小姐的Love，長條圖
    public Image PrepareAbility_Love_Bar_Image;

    //出勤小姐的Skill，長條圖
    public Image PrepareAbility_Skill_Bar_Image;


    //======================================================
    //外部方法
    //======================================================

    //============
    //(Prepare頁面 : PreparStaff)
    //============

    //============
    //出勤小姐大頭照，(PrepareLady: 出勤小姐)
    //============
    public void SetPrepareLady_HeadShot(Lady_Class[] PrepareLady)
    {
        for (i = 0; i < PrepareLady.Length; i++)
        {
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) PrepareStaff_Picture_Sprite[i].sprite = MVU.LadyHeadShot[PrepareLady[i].Getid()];
            //未出勤
            else PrepareStaff_Picture_Sprite[i].sprite = null;
        }
    }

    //============
    //出勤小姐階級圖，(PrepareLady: 出勤小姐)
    //============
    public void SetPrepareStaff_hierarchy(Lady_Class[] PrepareLady)
    {
        for (i = 0; i < PrepareLady.Length; i++)
        {
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) PrepareStaff_hierarchy_Sprite[i].sprite = MVU.GetPrepareStaffhierarchy(PrepareLady[i].Gethierarchy());
            //未出勤
            else PrepareStaff_hierarchy_Sprite[i].sprite = null;
        }
    }

    //============
    //出勤小姐姓名，(PrepareLady: 出勤小姐)
    //============
    public void SetPrepareStaffName_Text(Lady_Class[] PrepareLady)
    {
        for (i = 0; i < PrepareLady.Length; i++)
        {
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) PrepareStaffName_Text[i].text = PrepareLady[i].GetName();
            //未出勤
            else PrepareStaffName_Text[i].text = "";
        }
    }

    //============
    //出勤小姐等級，(PrepareLady: 出勤小姐)
    //============
    public void SetPrepareStaffLevel_Text(Lady_Class[] PrepareLady)
    {
        for (i = 0; i < PrepareLady.Length; i++)
        {
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) PrepareStaffLevel_Text[i].text = "LV." + PrepareLady[i].GetLevel();
            //未出勤
            else PrepareStaffLevel_Text[i].text = "";
        }
    }

    //============
    //出勤小姐Hp，長條圖，(PrepareLady: 出勤小姐)
    //============
    public void SetPrepareStaffHp_InSide_Image(Lady_Class[] PrepareLady)
    {
        for (i = 0; i < PrepareLady.Length; i++)
        {
            //出勤中
            if (PrepareLady[i].GetisWorked() == true) PrepareStaffHp_InSide_Image[i].fillAmount = PrepareLady[i].GetHp() / PrepareLady[i].GetHpMax();
            //未出勤
            else PrepareStaffHp_InSide_Image[i].fillAmount = 0.0f;
        }
    }

    //============
    //一次修改PrepareStaff，(PrepareLady: 出勤小姐)
    //============
    public void SetPrepareStaff(Lady_Class[] PrepareLady)
    {
        SetPrepareLady_HeadShot(PrepareLady);
        SetPrepareStaff_hierarchy(PrepareLady);
        SetPrepareStaffName_Text(PrepareLady);
        SetPrepareStaffLevel_Text(PrepareLady);
        SetPrepareStaffHp_InSide_Image(PrepareLady);
    }


    //============
    //(Prepare頁面 : PreparAbility)
    //============


    //============
    //PreparAbility的Hp(Text)
    //============
    public void SetPrepareAbility_Hp_Text(float Hp)
    {
        PrepareAbility_Hp_Text.text = "" + (int)Hp;
    }

    //============
    //清空PreparAbility的Hp(Text)
    //============
    public void SetPrepareAbility_Hp_Text_Clear()
    {
        PrepareAbility_Hp_Text.text = " ";
    }

    //============
    //PreparAbility的Talk(Text)
    //============
    public void SetPrepareAbility_Talk_Text(float Talk)
    {
        PrepareAbility_Talk_Text.text = "" + (int)Talk;
    }

    //============
    //清空PreparAbility的Talk(Text)
    //============
    public void SetPrepareAbility_Talk_Text_Clear()
    {
        PrepareAbility_Talk_Text.text = " ";
    }

    //============
    //PreparAbility的Party(Text)
    //============
    public void SetPrepareAbility_Party_Text(float Party)
    {
        PrepareAbility_Party_Text.text = "" + (int)Party;
    }

    //============
    //清空PreparAbility的Party(Text)
    //============
    public void SetPrepareAbility_Party_Text_Clear()
    {
        PrepareAbility_Party_Text.text = " ";
    }

    //============
    //PreparAbility的Love(Text)
    //============
    public void SetPrepareAbility_Love_Text(float Love)
    {
        PrepareAbility_Love_Text.text = "" + (int)Love;
    }

    //============
    //清空PreparAbility的Love(Text)
    //============
    public void SetPrepareAbility_Love_Text_Clear()
    {
        PrepareAbility_Love_Text.text = " ";
    }

    //============
    //PreparAbility的Skill(Text)
    //============
    public void SetPrepareAbility_Skill_Text(float Skill)
    {
        PrepareAbility_Skill_Text.text = "" + (int)Skill;
    }

    //============
    //清空PreparAbility的Skill(Text)
    //============
    public void SetPrepareAbility_Skill_Text_Clear()
    {
        PrepareAbility_Skill_Text.text = " ";
    }

    //============
    //一次修改PreparAbility的Hp、Talk、Party、Love、Skill的Text
    //============
    public void SetPrepareAbility_Text(Lady_Class PrepareLady)
    {
        SetPrepareAbility_Hp_Text(PrepareLady.GetHp());
        SetPrepareAbility_Talk_Text(PrepareLady.GetTalk());
        SetPrepareAbility_Party_Text(PrepareLady.GetParty());
        SetPrepareAbility_Love_Text(PrepareLady.GetLove());
        SetPrepareAbility_Skill_Text(PrepareLady.GetSkill());
    }

    //============
    //一次清空PreparAbility的Hp、Talk、Party、Love、Skill的Text
    //============
    public void SetPrepareAbility_Text_Clear()
    {
        SetPrepareAbility_Hp_Text_Clear();
        SetPrepareAbility_Talk_Text_Clear();
        SetPrepareAbility_Party_Text_Clear();
        SetPrepareAbility_Love_Text_Clear();
        SetPrepareAbility_Skill_Text_Clear();
    }

    //============
    //PreparAbility的出勤小姐人數(Text)(PrepareLady : 出勤小姐)
    //============

    public void SetPrepareAbility_PrepareNumber_Text(Lady_Class[] PrepareLady) {
        PrepareNumber_Text.text = "" + MVU.GetPrepareLadyNumber(PrepareLady) + "名";
    }

    //============
    //PreparAbility的出勤花費(Text)(PrepareLady : 出勤小姐)
    //============
    public void SetPrepareAbility_PrepareCost_Text(Lady_Class[] PrepareLady)
    {
        PrepareCost_Text.text = "" + MVU.GetPrepareLadyCost(PrepareLady) + "元";
    }

    //============
    //一次修改PrepareNumber、PrepareCost(Text)(PrepareLady : 出勤小姐)
    //============
    public void SetPrepareAbility_PrepareNumber_PrepareCost_Text(Lady_Class[] PrepareLady)
    {
        SetPrepareAbility_PrepareNumber_Text(PrepareLady);
        SetPrepareAbility_PrepareCost_Text(PrepareLady);
    }

    //============
    //PreparAbility的Hp的Bar_Image(Image)(PrepareLady : 出勤小姐)
    //============
    public void SetPreparAbility_Hp_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        PrepareAbility_Hp_Bar_Image.fillAmount = PrepareLady.GetHp() / PrepareLady.GetHpMax();
    }

    //============
    //清空PreparAbility的Hp的Bar_Image(Image)
    //============
    public void SetPreparAbility_Hp_Bar_Image_FillAmount_Clear()
    {
        PrepareAbility_Hp_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //PreparAbility的Talk的Bar_Image(Image)(PrepareLady : 出勤小姐)
    //============
    public void SetPreparAbility_Talk_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        PrepareAbility_Talk_Bar_Image.fillAmount = PrepareLady.GetTalk() / 9999.0f;
    }

    //============
    //清空PreparAbility的Talk的Bar_Image(Image)
    //============
    public void SetPreparAbility_Talk_Bar_Image_FillAmount_Clear()
    {
        PrepareAbility_Talk_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //PreparAbility的Party的Bar_Image(Image)(PrepareLady : 出勤小姐)
    //============
    public void SetPreparAbility_Party_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        PrepareAbility_Party_Bar_Image.fillAmount = PrepareLady.GetParty() / 9999.0f;
    }

    //============
    //清空PreparAbility的Party的Bar_Image(Image)
    //============
    public void SetPreparAbility_Party_Bar_Image_FillAmount_Clear()
    {
        PrepareAbility_Party_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //PreparAbility的Love的Bar_Image(Image)(PrepareLady : 出勤小姐)
    //============
    public void SetPreparAbility_Love_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        PrepareAbility_Love_Bar_Image.fillAmount = PrepareLady.GetLove() / 9999.0f;
    }

    //============
    //清空PreparAbility的Love的Bar_Image(Image)
    //============
    public void SetPreparAbility_Love_Bar_Image_FillAmount_Clear()
    {
        PrepareAbility_Love_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //PreparAbility的Skill的Bar_Image(Image)(PrepareLady : 出勤小姐)
    //============
    public void SetPreparAbility_Skill_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        PrepareAbility_Skill_Bar_Image.fillAmount = PrepareLady.GetSkill() / 9999.0f;
    }

    //============
    //清空PreparAbility的Skill的Bar_Image(Image)
    //============
    public void SetPreparAbility_Skill_Bar_Image_FillAmount_Clear()
    {
        PrepareAbility_Skill_Bar_Image.fillAmount = 0.0f;
    }

    //============
    //一次修改PreparAbility的Bar_Image(PrepareLady : 出勤小姐)
    //============
    public void SetPrepareAbility_Bar_Image_FillAmount(Lady_Class PrepareLady)
    {
        SetPreparAbility_Hp_Bar_Image_FillAmount(PrepareLady);
        SetPreparAbility_Talk_Bar_Image_FillAmount(PrepareLady);
        SetPreparAbility_Party_Bar_Image_FillAmount(PrepareLady);
        SetPreparAbility_Love_Bar_Image_FillAmount(PrepareLady);
        SetPreparAbility_Skill_Bar_Image_FillAmount(PrepareLady);
    }

    //============
    //一次清空PreparAbility的Bar_Image
    //============
    public void SetPrepareAbility_Bar_Image_FillAmount_Clear()
    {
        SetPreparAbility_Hp_Bar_Image_FillAmount_Clear();
        SetPreparAbility_Talk_Bar_Image_FillAmount_Clear();
        SetPreparAbility_Party_Bar_Image_FillAmount_Clear();
        SetPreparAbility_Love_Bar_Image_FillAmount_Clear();
        SetPreparAbility_Skill_Bar_Image_FillAmount_Clear();
    }

}//View_Manage_Script

