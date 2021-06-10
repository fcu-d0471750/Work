/*
 * 使用於Cabaret Club整個遊戲的存檔，繼承StartSave
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public  class GameSave : StartSave
{
    //迴圈用
    private int i,j;


    //============
    //存檔(ManageScene用)，(Cabaret_Club_S : Cabaret_Club基本資料，PrepareLady_S : 從ManageScene安排的出勤小姐，Opposite_S : 競爭對手，Opposite_Number: 選擇的競爭對手編號)
    //============
    public void DoSave_ManageScene(Cabaret_Club_Class Cabaret_Club_S, Lady_Class[] PrepareLady_S, Opposite_Class[] Opposite_S , int Opposite_Number)
    {

        //============
        //Cabaret_Club_Class
        //============
        Sav.Cabaret_Club_Boss = Cabaret_Club_S.GetCabaret_Club_Boss();

        Sav.Cabaret_Club_Level = Cabaret_Club_S.GetCabaret_Club_Level();

        Sav.Cabaret_Club_FansNumber = Cabaret_Club_S.GetCabaret_Club_FansNumber();

        //============
        //Cabaret_Club_Class - StaffLady
        //============
        for (i = 0; i < 30; i++)
        {
            //儲存等級
            Sav.Cabaret_Club_StaffLady_Level[i] = Cabaret_Club_S.GetStaffLady(i).GetLevel();
            //儲存小姐總營業額
            Sav.Cabaret_Club_StaffLady_AllIncome[i] = Cabaret_Club_S.GetStaffLady(i).GetAllIncome();
            //儲存單次最高營業額
            Sav.Cabaret_Club_StaffLady_OnceIncome[i] = Cabaret_Club_S.GetStaffLady(i).GetOnceIncome();
            //儲存是否解鎖
            Sav.Cabaret_Club_StaffLady_isunLock[i] = Cabaret_Club_S.GetStaffLady(i).GetisunLock();
            //儲存是否出勤中
            Sav.Cabaret_Club_StaffLady_isWorked[i] = Cabaret_Club_S.GetStaffLady(i).GetisWorked();

            /*(將30位在勤小姐的初始值寫好後，再將現在的預設值換掉)
            //儲存出勤小姐Hp
            Sav.Cabaret_Club_StaffLady_Hp[i] = 500.0f;
            //儲存出勤小姐Talk
            Sav.Cabaret_Club_StaffLady_Talk[i] = 1000.0f;
            //儲存出勤小姐Party
            Sav.Cabaret_Club_StaffLady_Party[i] = 150.0f;
            //儲存出勤小姐Love
            Sav.Cabaret_Club_StaffLady_Love[i] = 100.0f;
            //儲存出勤小姐Skill
            Sav.Cabaret_Club_StaffLady_Skill[i] = 80.0f;
            */
        }

        //============
        //PrepareLady
        //============
        for (i = 0; i < 8; i++)
        {
            //(只要id不為0~29代表該欄位沒有安排出勤小姐)
            if (PrepareLady_S[i].GetisWorked() == true) Sav.PrepareLady_id[i] = PrepareLady_S[i].Getid();
            else Sav.PrepareLady_id[i] = -1;
        }

        //============
        //Opposite
        //============

        //儲存選擇的競爭對手編號
        Sav.Opposite_Number = Opposite_Number;

        //============
        //進行存檔
        //============
        PlayerPrefs.SetString("SaveFile_1", JsonUtility.ToJson(Sav));

        print(PlayerPrefs.GetString("SaveFile_1"));

        print("ManageScene存檔成功。");

        SceneManager.LoadScene("GameScene");
    }

    //============
    //讀檔(ManageScene用)，(Cabaret_Club_S : Cabaret_Club基本資料，PrepareLady_S : 從ManageScene安排的出勤小姐，Opposite_S : 競爭對手)
    //============
    public void DoLoad_ManageScene(Cabaret_Club_Class Cabaret_Club_S, Lady_Class[] PrepareLady_S, Opposite_Class[] Opposite_S)
    {

        //============
        //進行讀檔
        //============
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("SaveFile_1"), Sav);

        print(PlayerPrefs.GetString("SaveFile_1"));

        //====================================================
        //第1次讀檔
        //====================================================
        if (Sav.FirstSave == true)
        {
            //============
            //Cabaret_Club_Class
            //============
            Cabaret_Club_S.SetCabaret_Club_Boss("真島吾郎");

            Cabaret_Club_S.SetCabaret_Club_Level(0);

            Cabaret_Club_S.SetCabaret_Club_FansNumber(0);
        
            //============
            //Opposite
            //============
            for (i = 0; i < 5; i++)
            {
                //設定區域粉絲人數
                Opposite_S[i].SetOpposite_AreaFans(0);
                //設定區域是否解鎖
                if(i==0) Opposite_S[0].SetOpposite_isunLocked(true);
                else Opposite_S[i].SetOpposite_isunLocked(false);
            }

            //============
            //將FirstSave設為false，表示已有讀檔
            //============
            Sav.FirstSave = false;

            //============
            //進行存檔，儲存FirstSave設為false
            //============
            PlayerPrefs.SetString("SaveFile_1", JsonUtility.ToJson(Sav));

        }

        //====================================================
        //第2次以上(含)讀檔
        //====================================================
        else
        {
            //============
            //Cabaret_Club_Class
            //============
            Cabaret_Club_S.SetCabaret_Club_Boss(Sav.Cabaret_Club_Boss);

            Cabaret_Club_S.SetCabaret_Club_Level(Sav.Cabaret_Club_Level);

            Cabaret_Club_S.SetCabaret_Club_FansNumber(Sav.Cabaret_Club_FansNumber);


            //============
            //Cabaret_Club_Class - StaffLady
            //============
            for (i = 0; i < 30; i++)
            {
                //取得等級
                Cabaret_Club_S.GetStaffLady(i).SetLevel(Sav.Cabaret_Club_StaffLady_Level[i]);
                //取得小姐總營業額
                Cabaret_Club_S.GetStaffLady(i).SetAllIncome(Sav.Cabaret_Club_StaffLady_AllIncome[i]);
                //取得單次最高營業額
                Cabaret_Club_S.GetStaffLady(i).SetOnceIncome(Sav.Cabaret_Club_StaffLady_OnceIncome[i]);
                //取得小姐現有經驗值
                Cabaret_Club_S.GetStaffLady(i).SetExperience(Sav.Cabaret_Club_StaffLady_Experience[i]);
                //取得小姐升級所需經驗值
                Cabaret_Club_S.GetStaffLady(i).SetExperience(Sav.Cabaret_Club_StaffLady_ExperienceMax[i]);
                //取得是否解鎖
                Cabaret_Club_S.GetStaffLady(i).SetisunLock(Sav.Cabaret_Club_StaffLady_isunLock[i]);
                //取得是否出勤中
                Cabaret_Club_S.GetStaffLady(i).SetisWorked(Sav.Cabaret_Club_StaffLady_isWorked[i]);

                //取得小姐Hp
                Cabaret_Club_S.GetStaffLady(i).SetHp(Sav.Cabaret_Club_StaffLady_Hp[i]);
                //取得小姐Talk
                Cabaret_Club_S.GetStaffLady(i).SetTalk(Sav.Cabaret_Club_StaffLady_Talk[i]);
                //取得小姐Party
                Cabaret_Club_S.GetStaffLady(i).SetParty(Sav.Cabaret_Club_StaffLady_Party[i]);
                //取得小姐Love
                Cabaret_Club_S.GetStaffLady(i).SetLove(Sav.Cabaret_Club_StaffLady_Love[i]);
                //取得小姐Skill
                Cabaret_Club_S.GetStaffLady(i).SetSkill(Sav.Cabaret_Club_StaffLady_Skill[i]);


            }

            //============
            //PrepareLady
            //============
            for (i = 0; i < 8; i++)
            {
                if (Sav.PrepareLady_id[i] >= 0)
                {
                    //設定出勤小姐名稱
                    PrepareLady_S[i].SetName(Cabaret_Club_S.GetStaffLady(Sav.PrepareLady_id[i]).GetName());
                    //設定出勤小姐等級
                    PrepareLady_S[i].Setid(Sav.PrepareLady_id[i]);
                    //設定出勤小姐階級圖
                    PrepareLady_S[i].Sethierarchy(Cabaret_Club_S.GetStaffLady(Sav.PrepareLady_id[i]).Gethierarchy());
                    //設定出勤小姐出勤中
                    PrepareLady_S[i].SetisWorked(true);
                    //設定出勤小姐等級，(依照該欄位出勤小姐的id)
                    PrepareLady_S[i].SetLevel(Sav.Cabaret_Club_StaffLady_Level[PrepareLady_S[i].Getid()]);
                    //設定出勤小姐現有經驗值
                    PrepareLady_S[i].SetExperience(Sav.Cabaret_Club_StaffLady_Experience[PrepareLady_S[i].Getid()]);
                    //設定出勤小姐升級所需經驗值
                    PrepareLady_S[i].SetExperienceMax(Sav.Cabaret_Club_StaffLady_ExperienceMax[PrepareLady_S[i].Getid()]);

                    //設定出勤小姐Hp
                    PrepareLady_S[i].SetHp(Sav.Cabaret_Club_StaffLady_Hp[PrepareLady_S[i].Getid()]);
                    //設定出勤小姐Talk
                    PrepareLady_S[i].SetTalk(Sav.Cabaret_Club_StaffLady_Talk[PrepareLady_S[i].Getid()]);
                    //設定出勤小姐Party
                    PrepareLady_S[i].SetParty(Sav.Cabaret_Club_StaffLady_Party[PrepareLady_S[i].Getid()]);
                    //設定出勤小姐Love
                    PrepareLady_S[i].SetLove(Sav.Cabaret_Club_StaffLady_Love[PrepareLady_S[i].Getid()]);
                    //設定出勤小姐Skill
                    PrepareLady_S[i].SetSkill(Sav.Cabaret_Club_StaffLady_Skill[PrepareLady_S[i].Getid()]);
                }
            }

            //============
            //Opposite
            //============


            for (i = 0; i < 5; i++)
            {
                //設定區域粉絲人數
                Opposite_S[i].SetOpposite_AreaFans(Sav.Opposite_AreaFans[i]);
                //設定區域是否解鎖
                Opposite_S[i].SetOpposite_isunLocked(Sav.Opposite_isunLocked[i]);
            }
        }

        print("ManageScene讀檔成功。");

    }



    //============
    //存檔(GameScene用)，(LadySeat_S : 所有LadySeat上的出勤小姐 ，GameConsole : 遊戲結算資料，LadyMax : 出勤小姐總人數)
    //============
    public void DoSave_GameScene(LadySeat_Class LadySeat_S, GameConsole_Class GameConsole, int LadyMax)
    {

        //============
        //Cabaret_Club_Class
        //============
        Sav.Cabaret_Club_FansNumber = Sav.Cabaret_Club_FansNumber + GameConsole.GetOnceFans();

        //============
        //Cabaret_Club_Class - StaffLady
        //============
        for (i = 0; i < LadyMax; i++)
        {
            //儲存出勤小姐等級
            Sav.Cabaret_Club_StaffLady_Level[LadySeat_S.GetLady(i).Getid()] = LadySeat_S.GetLady(i).GetLevel();
            //儲存各位出勤小姐的總營業額
            Sav.Cabaret_Club_StaffLady_AllIncome[LadySeat_S.GetLady(i).Getid()] = Sav.Cabaret_Club_StaffLady_AllIncome[LadySeat_S.GetLady(i).Getid()] + LadySeat_S.GetLady(i).GetOnceIncome();
            //儲存出勤小姐單次最高營業額
            Sav.Cabaret_Club_StaffLady_OnceIncome[LadySeat_S.GetLady(i).Getid()] = LadySeat_S.GetLady(i).GetOnceIncome();
            //儲存出勤小姐現有經驗值
            Sav.Cabaret_Club_StaffLady_Experience[LadySeat_S.GetLady(i).Getid()] = LadySeat_S.GetLady(i).GetExperience();
            //儲存出勤小姐升級所需經驗值
            Sav.Cabaret_Club_StaffLady_ExperienceMax[LadySeat_S.GetLady(i).Getid()] = LadySeat_S.GetLady(i).GetExperienceMax();

            //儲存出勤小姐Hp
            Sav.Cabaret_Club_StaffLady_Hp[LadySeat_S.GetLady(i).Getid()] = LadySeat_S.GetLady(i).GetHp();
            //儲存出勤小姐Talk
            Sav.Cabaret_Club_StaffLady_Talk[LadySeat_S.GetLady(i).Getid()] = LadySeat_S.GetLady(i).GetTalk();
            //儲存出勤小姐Party
            Sav.Cabaret_Club_StaffLady_Party[LadySeat_S.GetLady(i).Getid()] = LadySeat_S.GetLady(i).GetParty();
            //儲存出勤小姐Love
            Sav.Cabaret_Club_StaffLady_Love[LadySeat_S.GetLady(i).Getid()] = LadySeat_S.GetLady(i).GetLove();
            //儲存出勤小姐Skill
            Sav.Cabaret_Club_StaffLady_Skill[LadySeat_S.GetLady(i).Getid()] = LadySeat_S.GetLady(i).GetSkill();
        }



        //============
        //Opposite
        //============

        //儲存這次營業增加的區域粉絲人數
        Sav.Opposite_AreaFans[Sav.Opposite_Number] = Sav.Opposite_AreaFans[Sav.Opposite_Number] + GameConsole.GetOnceFans();
        

        //============
        //進行存檔
        //============
        PlayerPrefs.SetString("SaveFile_1", JsonUtility.ToJson(Sav));

        print(PlayerPrefs.GetString("SaveFile_1"));

        print("GameScene存檔成功。");


    }


    //============
    //讀檔(GameScene用)，(Lady : 從ManageScene安排的出勤小姐)
    //============
    public void DoLoad_GameScene(Lady_Class[] Lady)
    {
        //============
        //進行讀檔
        //============
        JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("SaveFile_1"), Sav);



        for (i = 0; i < 8; i++)
        {
            //將ManageScene的Prepare頁面的出勤小姐，放到GameScene中要放在LadySeat的Lady中
            if (Sav.PrepareLady_id[i] >= 0)
            {
                //設定出勤小姐id
                Lady[i].Setid(Sav.PrepareLady_id[i]);
                //設定小姐名稱
                //Lady[i].SetName(LD.Lady[Sav.PrepareLady_id[i]].GetName());
                Lady[i].SetName(LadyData.Lady[Sav.PrepareLady_id[i]].GetName());

                //設定小姐階級
                //Lady[i].Sethierarchy(LD.Lady[Sav.PrepareLady_id[i]].Gethierarchy());
                Lady[i].Sethierarchy(LadyData.Lady[Sav.PrepareLady_id[i]].Gethierarchy());

                //設定出勤小姐等級
                Lady[i].SetLevel(Sav.Cabaret_Club_StaffLady_Level[Sav.PrepareLady_id[i]]);
                //設定出勤小姐總營業額
                Lady[i].SetAllIncome(Sav.Cabaret_Club_StaffLady_AllIncome[Sav.PrepareLady_id[i]]);
                //設定出勤小姐單次最高營業額，(需完成判斷最高營業額Function)
                Lady[i].SetOnceIncome(0);
                //設定出勤小姐現有經驗值
                Lady[i].SetExperience(Sav.Cabaret_Club_StaffLady_Experience[Sav.PrepareLady_id[i]]);
                //設定出勤小姐升級所需經驗值
                Lady[i].SetExperienceMax(Sav.Cabaret_Club_StaffLady_ExperienceMax[Sav.PrepareLady_id[i]]);
                //升級出勤小姐出勤中
                Lady[i].SetisWorked(Sav.Cabaret_Club_StaffLady_isWorked[Sav.PrepareLady_id[i]]);
                //升級出勤小姐是否解鎖
                Lady[i].SetisunLock(Sav.Cabaret_Club_StaffLady_isunLock[Sav.PrepareLady_id[i]]);

                //設定Hp
                Lady[i].SetHp(Sav.Cabaret_Club_StaffLady_Hp[Sav.PrepareLady_id[i]]);

                //設定Talk
                Lady[i].SetTalk(Sav.Cabaret_Club_StaffLady_Talk[Sav.PrepareLady_id[i]]);

                //設定Party
                Lady[i].SetParty(Sav.Cabaret_Club_StaffLady_Party[Sav.PrepareLady_id[i]]);

                //設定Love
                Lady[i].SetLove(Sav.Cabaret_Club_StaffLady_Love[Sav.PrepareLady_id[i]]);

                //設定Skill
                Lady[i].SetSkill(Sav.Cabaret_Club_StaffLady_Skill[Sav.PrepareLady_id[i]]);

            }
            //未安排的Lady的id則維持-1
            else
            {
                Lady[i].Setid(Sav.PrepareLady_id[i]);
            }
                       
        }
      
        print("GameScene讀檔成功。");
    }


    /*
    //============
    //存檔(ManageScene用)，(Cabaret_Club_S : Cabaret_Club基本資料，PrepareLady_S : 從ManageScene安排的出勤小姐，Opposite_S : 競爭對手)
    //============
    public void DoSave_ManageScene(Cabaret_Club_Class Cabaret_Club_S , Lady_Class[] PrepareLady_S, Opposite_Class[] Opposite_S)
    {
        //Sav.SetCabaret_Club_(Cabaret_Club_S);
        //Sav.GetCabaret_Club().SetCabaret_Club_Boss("AAAAA");
        //Sav.Cabaret_Club_.Add(Cabaret_Club_S);
        for (i = 0; i < 8; i++) Sav.SetPrepareLady(i, PrepareLady_S[i]);
            
        
        for (i = 0; i <5; i++) Sav.SetOpposite(i , Opposite_S[i]);

        Sav.AllIncome = 100000;

        PlayerPrefs.SetString("SaveFile_1", JsonUtility.ToJson(Sav));
        //print("ManageScene存檔成功。");
        print(PlayerPrefs.GetString("SaveFile_1"));
        
    }

   
   //============
   //讀檔(ManageScene用)，(Cabaret_Club_S : Cabaret_Club基本資料，PrepareLady_S : 從ManageScene安排的出勤小姐，Opposite_S : 競爭對手)
   //============
   public void DoLoad_ManageScene(Cabaret_Club_Class Cabaret_Club_S, Lady_Class[] PrepareLady_S, Opposite_Class[] Opposite_S)
   {

       JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("SaveFile_1"), Sav);

       //Cabaret_Club_S = Sav.GetCabaret_Club();

       //PrepareLady_S = Sav.GetAllPrepareLady();

       //Opposite_S = Sav.GetAllOpposite();

       //print("ManageScene讀檔成功。");

       //print(Sav.Cabaret_Club_[0]);
       //print(Sav.AllIncome);
   }


   //============
   //存檔(GameScene用)，(LeadSeat_S : GameScene的出勤小姐)
   //============
   public void DoSave_GameScene(LadySeat_Class LeadSeat_S)
   {
       //由於LadySeat的Lady陣列位置會改變，所以找出擁有相同id的PrepareLady，並從LeadSeat上存新的資料到PrepareLady
       for (i = 0; i < 8; i++) {
           for (j = 0; j < 8; j++) {
               if (Sav.GetPrepareLady(i).Getid() == LeadSeat_S.GetLady(j).Getid())
               {
                   Sav.SetPrepareLady(i, LeadSeat_S.GetLady(j));
               }
           }
       }

       PlayerPrefs.SetString("SaveFile_1", JsonUtility.ToJson(Sav));
       print("GameScene存檔成功。");
   }


   //============
   //讀檔(GameScene用)，(PrepareLady_S : 從ManageScene安排的出勤小姐，Opposite_S : 競爭對手)
   //============
   public void DoLoad_GameScene(Lady_Class[] Lady)
   {
       JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString("SaveFile_1"), Sav);



       for (i = 0; i < 8; i++)
       {
           //Lady[i] = Sav.GetPrepareLady(i);
           //print(Sav.GetPrepareLady(i).GetName());
       }


       print("GameScene讀檔成功。");
   }

   */


}//GameSave
