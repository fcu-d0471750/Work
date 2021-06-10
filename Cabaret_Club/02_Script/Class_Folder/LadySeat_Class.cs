/*
 * Class : LadySeat_Class
 * 用於操控遊玩畫面出勤的小姐。
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadySeat_Class : MonoBehaviour
{
    //======================================================
    //宣告屬性
    //======================================================
    
    //Lady : 出勤小姐，共八位Lady
    private Lady_Class[] Lady = new Lady_Class[8];

    //bool : 位置是否有空位，true: 有空位(沒有小姐) false:沒有空位(有小姐)
    private bool[] isLadySeat = new bool[] { true , true, true, true, true, true, true, true };

    //最多小姐數量
    private int LadyMax = 0;

    //======================================================
    //建構子(有參數)
    //======================================================
    public LadySeat_Class(Lady_Class[] Lady_P) {

        //設定外部傳進來的小姐數量
        //LadyMax = Lady_P.Length;

        //按照順序排座位
        int Temp = 0;

        //將從外部傳進來的Lady_P，放入到自身的Lady裡面，並將相對應的isLadySeat設為false，表示沒有空位。
        for (int i = 0; i < Lady_P.Length; i++) {
            if (Lady_P[i].Getid() >= 0)
            {
                this.Lady[Temp] = Lady_P[i];
                this.isLadySeat[Temp] = false;
                LadyMax = LadyMax + 1;
                //下一個座位
                Temp = Temp + 1;
               
            }
           
        }
       
    }

    //======================================================
    //外部方法
    //======================================================

    //============
    //設定回到LadySeat的Lady、isLadySeat
    //============
    public void SetLadyBack(Lady_Class Lady) {

        /*方法一
        //因為LadySeat要加1位Lady到最後一個位置，所以依照當時的LadyMax為LadySeat的陣列位置。
        this.Lady[LadyMax] = Lady;
        this.isLadySeat[LadyMax] = false;
        //因為Lady回到LadySeat，所以最多小姐數量 + 1;
        LadyMax = LadyMax + 1;
        */

        //找尋空位，一有空位就放入Lady，方法二
        for (int i = 0; i <= LadyMax; i++) {
            if (this.isLadySeat[i] == true) {
                //設定Lady資料
                this.Lady[i] = Lady;
                //設定該位置沒有空位
                this.isLadySeat[i] = false;
                //不用再找空位
                break;
            }
        }

        //因為Lady回到LadySeat，所以最多小姐數量 + 1;
        LadyMax = LadyMax + 1;


    }

    //============
    //設定CustomerSeat要交換Lady，(id : LadySeat上要交換的Lady的id ， Lady : 要換下來的CustomerSeat的Lady)
    //============
    public Lady_Class SetLadyChangeCustomerSeat(int id , Lady_Class CustomerSeat_Lady)
    {
        //暫存選擇的LadySeat的Lady
        Lady_Class Lady_Temp;

        //Lady_Temp設定為選擇的LadySeat的Lady
        Lady_Temp = this.Lady[id];

        //將原本LadySeat上的Lady換成要交換的CustomerSeat的Lady
        this.Lady[id] = CustomerSeat_Lady;

        return Lady_Temp;
    }


    //============
    //設定Lady到CustomerSeat，(id : Lady的id)
    //============
    public Lady_Class SetLadyToCustomerSeat(int id)
    {
        //暫存Lady
        Lady_Class TempLady;

        //因為Lady出勤，所以產生空位
        this.isLadySeat[id] = true;      

        //因為Lady到CustomerSeat，所以最多小姐數量 - 1;
        LadyMax = LadyMax - 1;

        TempLady = Lady[id];

        Lady[id] = null;

        return TempLady;
    }

    //============
    //Ladyseat上的Lady恢復Hp
    //============
    public void CalLadySeatHp()
    {
        for (int i = 0; i < Lady.Length; i++) {
            //如果有Lady在Ladyseat，則恢復Hp
            if (isLadySeat[i] == false) Lady[i].DoGame_AddHp();
        }
    }

    //======================================================
    //Getter
    //======================================================

    //============
    //Lady(有指定)
    //============
    public Lady_Class GetLady(int i)
    {
        return Lady[i];
    }

    //============
    //Lady(全部)
    //============
    public Lady_Class[] GetAllLady()
    {
        return Lady;
    }

    //============
    //isLadyWorked(有指定)
    //============
    public bool GetisLadySeat(int i)
    {
        return isLadySeat[i];
    }

    //============
    //Lady(全部)
    //============
    public bool[] GetAllisLadySeat()
    {
        return isLadySeat;
    }

    //============
    //LadyMax
    //============
    public int GetLadyMax()
    {
        return LadyMax;
    }

    //======================================================
    //Setter
    //======================================================

    //============
    //Lady(指定)
    //============
    public void SetLady(int i , Lady_Class Lady_P)
    {
        this.Lady[i] = Lady_P;
    }

    //============
    //Lady(全部)
    //============
    public void SetAllLady( Lady_Class[] Lady_P)
    {
        for(int i=0; i< LadyMax; i++) this.isLadySeat[i] = true;

        for (int i=0; i < Lady_P.Length; i++)
        {
            this.Lady[i] = Lady_P[i];
            this.isLadySeat[i] = false;
        }
    }

    //============
    //isLadySeat(指定)
    //============
    public void SetisLadySeat(int i, bool isLadySeat_P)
    {
        this.isLadySeat[i] = isLadySeat_P;
    }

    //============
    //isLadySeat(全部)
    //============
    public void SetAllLadySeat(bool[] isLadySeat_P)
    {
        for (int i = 0; i < isLadySeat_P.Length; i++) this.isLadySeat[i] = isLadySeat_P[i];
    }


    //============
    //LadyMax
    //============
    public void SetLadyMax(int LadyMax)
    {
        this.LadyMax = LadyMax;
    }



}//LadySeat_Class
