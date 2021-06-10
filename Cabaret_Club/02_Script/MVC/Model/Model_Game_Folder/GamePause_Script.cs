/*
 * GamePause : 遊戲暫停
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause_Script : MonoBehaviour
{


    //======================================================
    //外部方法
    //======================================================

    //============
    //繼續遊戲
    //============
    public int DoGameContinue()
    {
        //進入遊玩狀態
        return 10;
    }

    //============
    //離開遊戲
    //============
    public void DoGameExit()
    {
        //回到GameManageScene
        SceneManager.LoadScene("ManageScene");
    }


}//GamePause_Script
