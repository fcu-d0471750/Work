/* 
 * Class : 結帳事件，繼承GameSituation_Class
 * 
 * 結帳
 * 送上拌手禮、有禮貌送客、誇獎小姐、給予小姐獎勵
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCalculation_Class : GameSituation_Class
{
    //======================================================
    //建構子(無參數)
    //======================================================
    public GameCalculation_Class()
    {
        Setid(0);
        SetGameSituationName("發生爭執問題");
        SetCorrectName("送上道歉禮品");
        SetMistakeName_1("袒護小姐");
        SetMistakeName_2("責罵小姐");
        SetMistakeName_3("送客");

        SetGameSituationSprite(null);
        SetGameRewardSprite(null);
    }

    //======================================================
    //建構子(有參數)
    //======================================================
    public GameCalculation_Class(int id , string GameSituationName, string CorrectName, string MistakeName_1, string MistakeName_2, string MistakeName_3, Sprite GameSituationSprite)
    {
        Setid(id);
        SetGameSituationName(GameSituationName);
        SetCorrectName(CorrectName);
        SetMistakeName_1(MistakeName_1);
        SetMistakeName_2(MistakeName_2);
        SetMistakeName_3(MistakeName_3);

        SetGameSituationSprite(GameSituationSprite);
        SetGameRewardSprite(null);
    }

    //======================================================
    //外部方法
    //======================================================

    //============
    //送上拌手禮
    //============
    public void DoGift(CustomerSeat_Class CustomerSeat, LadySeat_Class LadySeat)
    {
        //恢復Lady Hp，增加量為Lady的HpMax的20%
        CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHp() + (CustomerSeat.GetLady().GetHpMax() * 0.2f));
        //如果Lady恢復的Hp超過HpMax，則將Hp設為HpMax
        if (CustomerSeat.GetLady().GetHp() > CustomerSeat.GetLady().GetHpMax()) CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHpMax());

        //Lady增加單次營業額
        CustomerSeat.GetLady().SetOnceIncome(CustomerSeat.GetLady().GetOnceIncome() + CustomerSeat.GetInCome());

        //Lady回到LadySeat
        LadySeat.SetLadyBack(CustomerSeat.GetLady());

        //讓客人離開
        CustomerSeat.SetCustomerleave();

        //設定結果敘述
        SetConsole("因為口碑而大幅增加粉絲!!!");
    }

    //============
    //有禮貌送客
    //============
    public void DoOut(CustomerSeat_Class CustomerSeat, LadySeat_Class LadySeat)
    {
        //恢復Lady Hp，增加量為Lady的HpMax的15%
        CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHp() + (CustomerSeat.GetLady().GetHpMax() * 0.15f));
        //如果Lady恢復的Hp超過HpMax，則將Hp設為HpMax
        if (CustomerSeat.GetLady().GetHp() > CustomerSeat.GetLady().GetHpMax()) CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHpMax());

        //Lady增加單次營業額
        CustomerSeat.GetLady().SetOnceIncome(CustomerSeat.GetLady().GetOnceIncome() + CustomerSeat.GetInCome());

        //Lady回到LadySeat
        LadySeat.SetLadyBack(CustomerSeat.GetLady());

        //讓客人離開
        CustomerSeat.SetCustomerleave();

        //設定結果敘述
        SetConsole("稍微增加粉絲。");
    }

    //============
    //誇獎小姐
    //============
    public void DoPraise(CustomerSeat_Class CustomerSeat, LadySeat_Class LadySeat)
    {
        //恢復Lady Hp，增加量為Lady的HpMax的25%
        CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHp() + (CustomerSeat.GetLady().GetHpMax() * 0.25f));
        //如果Lady恢復的Hp超過HpMax，則將Hp設為HpMax
        if (CustomerSeat.GetLady().GetHp() > CustomerSeat.GetLady().GetHpMax()) CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHpMax());

        //Lady增加單次營業額
        CustomerSeat.GetLady().SetOnceIncome(CustomerSeat.GetLady().GetOnceIncome() + CustomerSeat.GetInCome());

        //Lady回到LadySeat
        LadySeat.SetLadyBack(CustomerSeat.GetLady());

        //讓客人離開
        CustomerSeat.SetCustomerleave();

        //設定結果敘述
        SetConsole("小姐稍微恢復體力了。");
    }

    //============
    //給予小姐獎勵
    //============
    public void DoPrize(CustomerSeat_Class CustomerSeat , LadySeat_Class LadySeat)
    {
        //恢復Lady Hp，增加量為Lady的HpMax的40%
        CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHp() + (CustomerSeat.GetLady().GetHpMax() * 0.4f));
        //如果Lady恢復的Hp超過HpMax，則將Hp設為HpMax
        if (CustomerSeat.GetLady().GetHp() > CustomerSeat.GetLady().GetHpMax()) CustomerSeat.GetLady().SetHp(CustomerSeat.GetLady().GetHpMax());

        //Lady增加單次營業額
        CustomerSeat.GetLady().SetOnceIncome(CustomerSeat.GetLady().GetOnceIncome() + CustomerSeat.GetInCome());

        //Lady回到LadySeat
        LadySeat.SetLadyBack(CustomerSeat.GetLady());

        //讓客人離開
        CustomerSeat.SetCustomerleave();
  
        //設定結果敘述
        SetConsole("小姐恢復體力了!!!");
    }

}//GameCalculation_Class
