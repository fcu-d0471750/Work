/*
 * Fever，控制Fever狀態
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever_Script : MonoBehaviour
{


    //======================================================
    //宣告屬性
    //======================================================

    //float : 能量
    private float FeverEnergy = 0.0f;

    //float : 每次增加的能量
    private float AddEnergy = 0.01f;

    //float : 使用一次減少的能量
    private float UseEnergy = 33.0f;

    //float : 使用Fever後的使用時間 
    private float FeverTime = 0.0f;

    //============
    //State
    //============

    //是否可以使用Fever，true:可以使用 false:不可以使用
    private bool isFever = false;

    //是否使用Fever中，true:使用中 false:未使用
    private bool isuseFever = false;

    //======================================================
    //建構子(無參數)
    //======================================================
    public Fever_Script() {
        this.FeverEnergy = 0.0f;

        this.AddEnergy = 0.01f;

        this.UseEnergy = 33.0f;

        this.isFever = false;

        this.FeverTime = 0.0f;

        this.isuseFever = false;
    }

    //======================================================
    //外部方法
    //======================================================

    //============
    //使用Fever
    //============
    public void DoFever(CustomerSeat_Class[] CustomerSeat)
    {
        
        //隨機挑選CustomerSeat進入Fever
        FeverSeat(CheckFeverSeat(), CustomerSeat);
        //使用後 FeverEnergy = 現在的FeverEnergy - (間距*使用一次減少的能量)
        FeverEnergy = FeverEnergy - (CheckFeverSeat() * UseEnergy);

        //不可以使用Fever
        isFever = false;

        //使用Fever中
        isuseFever = true;

        //設定Fever使用時間
        FeverTime = 15.0f;
    }

    //============
    //檢查Fever是否可使用
    //============
    public bool CheckFever()
    {

        //如果FeverEnergy達到33.0(包含)以上，可以使用Fever，回傳true
        if (FeverEnergy >= 33.0f) {

            isFever = true;

            return true;
        }

        //反之，回傳false
        return false;

    }

    //============
    //增加FeverEnergy
    //============
    public void AddFeverEnergy() {
        //如果FeverEnergy < 100.0f，則一直增加FeverEnergy
        if (FeverEnergy < 100.0f)
        {
            FeverEnergy = FeverEnergy + Time.deltaTime;        
        }
        //如果FeverEnergy >= 100.0f，則一直停止增加FeverEnergy，並設為100.0f
        else FeverEnergy = 100.0f;

        //檢查Fever是否可使用
        CheckFever();
        
    }

    //============
    //扣除FeverTime
    //============
    public void SubFeverTime()
    {
        //如果使用Fever中，則扣除FeverTime
        if (FeverTime > 0.0f) FeverTime = FeverTime - Time.deltaTime;
        //否則，FeverTime設為0，沒有使用Fever中
        else
        {
            FeverTime = 0.0f;
            isuseFever = false;
        }
        
    }

    //======================================================
    //內部方法
    //======================================================

    //============
    //檢查Fever是在哪一個間距
    //============
    private int CheckFeverSeat() {
        //如果FeverEnergy >= 33.0f 且 如果FeverEnergy < 66.0f，回傳 1
        if (FeverEnergy >= 33.0f && FeverEnergy < 66.0f) return 1;
        //如果FeverEnergy >= 66.0f 且 如果FeverEnergy < 99.0f，回傳 2
        else if (FeverEnergy >= 66.0f && FeverEnergy < 99.0f) return 2;
        //否則，都回傳 3
        return 3;
    }

    //============
    //隨機挑選CustomerSeat進入Fever(Count: Fever是在哪一個間距)
    //============
    private void  FeverSeat(int Count ,CustomerSeat_Class[] CustomerSeat)
    {
        //隨機挑選CustomerSeat，進入Fever狀態
        int id;

        //用於計算幾個CustomerSeat可以進入Fever
        int Temp = 0;

        //判斷有幾個CustomerSeat是在遊玩狀態
        int CustomerSeatGame = 0;

        //迴圈用
        int i, j;

        
        //如果CustomerSeat有Customer 且 有Lady，則CustomerSeatGame + 1 
        for (i = 0; i < CustomerSeat.Length; i++) {
            if (CustomerSeat[i].GetisGame() == true && CustomerSeat[i].GetisLady() == true) CustomerSeatGame = CustomerSeatGame + 1;
        }
        
        //計算幾個CustomerSeat可以進入Fever
        if(CustomerSeatGame > 0) Temp = CheckFeverTemp(Count , CustomerSeatGame);
        
        
        //如果還有CustomerSeat可以進入Fever狀態
        while (Temp >= 1)
        {
            //隨機選擇CustomerSeat
            id = Random.Range(0, CustomerSeat.Length);
            //如果CustomerSeat有Customer 且 有Lady，則進入Fever狀態
            if (CustomerSeat[id].GetisGame() == true && CustomerSeat[id].GetisLady() == true && CustomerSeat[id].GetisFever() ==false )
            {
                //設定CustomerSeat進入Fever狀態
                CustomerSeat[id].SetisFever(true);
                //剩下可以CustomerSeat - 1
                Temp = Temp - 1;
            }//if
        }//while (Temp >= 1)
              
    }

    //============
    //計算幾個CustomerSeat可以進入Fever(Count: Fever是在哪一個間距 ， CustomerSeatGame: 有幾個CustomerSeat是在遊玩狀態)
    //============
    private int CheckFeverTemp(int Count , int CustomerSeatGame) {
        //第1間距
        if (Count == 1)
        {
            //如果只有1個CustomerSeat是在遊玩狀態
            if (CustomerSeatGame == 1)
            {
                //只有1個CustomerSeat可以進入Fever狀態
                return 1;
            }
            //如果2個以上(含)CustomerSeat是在遊玩狀態
            else
            {
                //最多2個CustomerSeat可以進入Fever狀態
                return 2;
            }
        }//if (Count == 1)

        //第二間距
        else if (Count == 2)
        {
            
            //如果只有1個CustomerSeat是在遊玩狀態
            if (CustomerSeatGame == 1)
            {
                //只有1個CustomerSeat可以進入Fever狀態
                return 1;
            }
            //如果2個CustomerSeat可以進入Fever狀態
            else if (CustomerSeatGame == 2)
            {
                //最多2個CustomerSeat可以進入Fever狀態
                return 2;
            }
            //如果3個CustomerSeat可以進入Fever狀態
            else if (CustomerSeatGame == 3)
            {
                //最多3個CustomerSeat可以進入Fever狀態
                return 3;
            }
            //如果4個以上(含)CustomerSeat是在遊玩狀態
            else
            {
                //最多4個CustomerSeat可以進入Fever狀態
                return 4;
            }
            
        }//else if (Count == 2)

        //第三間距
        else
        {
            //如果只有1個CustomerSeat是在遊玩狀態
            if (CustomerSeatGame == 1)
            {
                //只有1個CustomerSeat可以進入Fever狀態
                return 1;
            }
            //如果2個CustomerSeat可以進入Fever狀態
            else if (CustomerSeatGame == 2)
            {
                //最多2個CustomerSeat可以進入Fever狀態
                return 2;
            }
            //如果3個CustomerSeat可以進入Fever狀態
            else if (CustomerSeatGame == 3)
            {
                //最多3個CustomerSeat可以進入Fever狀態
                return 3;
            }
            //如果4個CustomerSeat可以進入Fever狀態
            else if (CustomerSeatGame == 4)
            {
                //最多4個CustomerSeat可以進入Fever狀態
                return 4;
            }
            //如果5個CustomerSeat可以進入Fever狀態
            else if (CustomerSeatGame == 5)
            {
                //最多5個CustomerSeat可以進入Fever狀態
                return 5;
            }

            //如果6個CustomerSeat是在遊玩狀態
            else
            {
                //最多6個CustomerSeat可以進入Fever狀態
                return 6;
            }
        }//else

        //最多6個CustomerSeat可以進入Fever狀態
        return 6;
    }

    //======================================================
    //Getter
    //======================================================

    //============
    //FeverEnergy
    //============
    public float GetFeverEnergy()
    {
        return FeverEnergy;
    }

    //============
    //AddEnergy
    //============
    public float GetAddEnergy()
    {
        return AddEnergy;
    }

    //============
    //UseEnergy
    //============
    public float GetUseEnergy()
    {
        return UseEnergy;
    }

    //============
    //FeverTime
    //============
    public float GetFeverTime()
    {
        return FeverTime;
    }
    
    //============
    //isFever
    //============
    public bool GetisFever()
    {
        return isFever;
    }

    //============
    //isuseFever
    //============
    public bool GetisuseFever()
    {
        return isuseFever;
    }
    
    //======================================================
    //Setter
    //======================================================

    //============
    //FeverEnergy
    //============
    public void SetFeverEnergy(float FeverEnergy)
    {
        this.FeverEnergy = FeverEnergy;
    }

    //============
    //AddEnergy
    //============
    public void SetAddEnergy(float AddEnergy)
    {
        this.AddEnergy = AddEnergy;
    }

    //============
    //UseEnergy
    //============
    public void SetUseEnergy(float UseEnergy)
    {
        this.UseEnergy = UseEnergy;
    }

    //============
    //FeverTime
    //============
    public void SetFeverTime(float FeverTime)
    {
        this.FeverTime = FeverTime;
    }
    
    //============
    //isFever
    //============
    public void SetisFever(bool isFever)
    {
        this.isFever = isFever;
    }

    //============
    //isuseFever
    //============
    public void SetisuseFever(bool isuseFever)
    {
        this.isuseFever = isuseFever;
    }
    
}//Fever_Script
