/*
 * Customer_Script : 生成Customer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Script : MonoBehaviour
{
    //======================================================
    //宣告Customer
    //======================================================

    //Talk
    private Customer_Class[] Customer_Talk = new Customer_Class[5];
    //Party
    private Customer_Class[] Customer_Party = new Customer_Class[5];
    //Love
    private Customer_Class[] Customer_Love = new Customer_Class[5];
    //Skill
    private Customer_Class[] Customer_Skill = new Customer_Class[5];


    //======================================================
    //建構子(無參數)
    //======================================================
    public Customer_Script() {
        CreateCustomer_Talk();
        CreateCustomer_Party();
        CreateCustomer_Love();
        CreateCustomer_Skill();
    }

    //======================================================
    //外部方法
    //======================================================

    //============
    //隨機生成Customer
    //============
    public Customer_Class CreateCustomer() {

        //暫存Customer的陣列編號
        int id;

        //隨機生成Customer的陣列編號
        id = Random.Range(0, Customer_Talk.Length);
        
        //回傳Customer
        return Customer_Talk[id];


    }

    //============
    //取得Customer(Talk)，(id : Customer_Script所生成的Customer的陣列編號)
    //============
    public Customer_Class GetCustomer_Talk(int id)
    {
        return Customer_Talk[id];
    }

    //============
    //取得Customer(Party)，(id : Customer_Script所生成的Customer的陣列編號)
    //============
    public Customer_Class GetCustomer_Party(int id)
    {
        return Customer_Party[id];
    }

    //============
    //取得Customer(Love)，(id : Customer_Script所生成的Customer的陣列編號)
    //============
    public Customer_Class GetCustomer_Love(int id) {
        return Customer_Love[id];
    }

    //============
    //取得Customer(Skill)，(id : Customer_Script所生成的Customer的陣列編號)
    //============
    public Customer_Class GetCustomer_Skill(int id)
    {
        return Customer_Skill[id];
    }

    //======================================================
    //內部方法
    //======================================================

    //============
    //生成Customer(Talk)
    //============
    private void CreateCustomer_Talk()
    {
        Customer_Talk[0] = new Customer_Class(4, 60, "Talk", "Sexy", 15.0f);
        Customer_Talk[1] = new Customer_Class(4, 60, "Talk", "Sexy", 15.0f);
        Customer_Talk[2] = new Customer_Class(4, 60, "Talk", "Sexy", 15.0f);
        Customer_Talk[3] = new Customer_Class(4, 60, "Talk", "Sexy", 15.0f);
        Customer_Talk[4] = new Customer_Class(4, 60, "Talk", "Sexy", 15.0f);
    }

    //============
    //生成Customer(Party)
    //============
    private void CreateCustomer_Party()
    {
        Customer_Party[0] = new Customer_Class(4, 60, "Party", "Beauty", 89.0f);
        Customer_Party[1] = new Customer_Class();
        Customer_Party[2] = new Customer_Class();
        Customer_Party[3] = new Customer_Class();
        Customer_Party[4] = new Customer_Class();
    }

    //============
    //生成Customer(Love)
    //============
    private void CreateCustomer_Love()
    {
        Customer_Love[0] = new Customer_Class(4, 60, "Love", "Cute", 89.0f);
        Customer_Love[1] = new Customer_Class();
        Customer_Love[2] = new Customer_Class();
        Customer_Love[3] = new Customer_Class();
        Customer_Love[4] = new Customer_Class();
    }

    //============
    //生成Customer(Skill)
    //============
    private void CreateCustomer_Skill() {
        Customer_Skill[0] = new Customer_Class(4 , 50 , "Skill" , "Sexy" , 89.0f);
        Customer_Skill[1] = new Customer_Class();
        Customer_Skill[2] = new Customer_Class();
        Customer_Skill[3] = new Customer_Class();
        Customer_Skill[4] = new Customer_Class();
    }



}//Customer_Script
