using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scaler : MonoBehaviour
{
    private Lady_Class[] lady = new Lady_Class[6];
    private Lady_Class lady_one;
    private Lady_Class lady_two;
    private Customer_Class Customer;

    private CustomerSeat_Class[] CustomerSeat = new CustomerSeat_Class[2];

    private LadySeat_Class ladyseat;

    public Text NameText;
    public SpriteRenderer LadySprite;

    public int AAAA = 1;
    public int LadyTemp = 0;
    public int CustomerTemp = 0;

    public Button[] button = new Button[8];

    // Start is called before the first frame update
    void Start()
    {
        //float width = ScreenSize.GetScreenToWorldWidth;
        //transform.localScale = Vector3.one * width;

        lady_one = new Lady_Class();
        lady_two = new Lady_Class();
        Customer = new Customer_Class();

        lady[0] = new Lady_Class();
        lady[1] =  lady[0];
        lady[2] = new Lady_Class();
        lady[3] = new Lady_Class();
        lady[4] = new Lady_Class();
        lady[5] = new Lady_Class();
        //ladyseat = new LadySeat_Class(lady);
        
        //print(ladyseat.GetLady(0).GetDescription());
        //print("Down");
        //lady[0] = new Lady_Class(1 , "A" , "B" , null , null , 10 , 12 , 1000 , 15515 , 1551 , 50.0f , 20.0f , 70.0f , 80.0f , 90.0f , "D" , "c" , "T" , "C" , false , false);
        

        //print(ladyseat.GetLady(0).GetDescription());


        CustomerSeat[0] = new CustomerSeat_Class(0);
        CustomerSeat[0].SetCustomerinSeat(Customer);
        lady_one.SetName("CCC");
        lady_one.SetCute("Cuteeeee");
        lady[1] = lady_one;
        //CustomerSeat[0].SetLadyinSeat(lady_one);
        ladyseat = new LadySeat_Class(lady);
        //print(CustomerSeat[0].Getid() + " " + CustomerSeat.GetCustomer().GetAbility() + " " + CustomerSeat.GetCustomer().GetAbility() + " " + CustomerSeat.GetInCome());
        //print("Down");


        //lady_two.SetName("CCC");
        //CustomerSeat[1] = new CustomerSeat_Class(1, 0, Customer, 90.0f, 9.0f, true, false, false, false, false);
        //CustomerSeat[1].SetLady(lady_two);
        //print(CustomerSeat.Getid() + " " + CustomerSeat.GetLady().GetHp() + " " + CustomerSeat.GetCustomer().GetAbility() + " " + CustomerSeat.GetInCome());
        //print(CustomerSeat[0].GetLady().GetName());
        //CustomerSeat[0].SetLady(ladyseat.SetLadyChangeCustomerSeat(0 , CustomerSeat[0].GetLady()));
        //print(CustomerSeat[0].GetLady().GetName());
    }

    //通知View修改
    public  static void Upd(Lady_Class lady){
        print(lady.GetName());
    }

    public void TextCH(CustomerSeat_Class CustomerSeat) {
        NameText.text = CustomerSeat.GetLady().GetName();
        LadySprite.sprite = CustomerSeat.GetLadyHeadShot();
    }

    //(Button)進入選擇小姐狀態(id : 設定是哪一個CustomerSeat)
    public void SetseatCustom(int id)
    {
        //儲存座位id
        CustomerTemp = id;
        //進入選擇小姐狀態
        AAAA = 2;
    }

    //(Button)進入小姐選擇完成狀態(id : 設定是哪一個Lady)
    public void SetseatLady(int id)
    {
        //儲存Lady id
        LadyTemp = id;
        //進入選擇小姐完成狀態
        AAAA = 3;
    }

     private void Update()
     {
         /*if (AAAA == 3) {
             //如果CustomerSeat沒有Lady，直接指派
             if (CustomerSeat[CustomerTemp].GetisLady() == false)
             {
                 CustomerSeat[CustomerTemp].SetLadyinSeat(ladyseat.SetLadyToCustomerSeat(LadyTemp));
                 print("No lady");
             }
             //如果CustomerSeat有Lady，進行交換
             else {
                 CustomerSeat[CustomerTemp].SetLadyinSeat(ladyseat.SetLadyChangeCustomerSeat(LadyTemp  , CustomerSeat[CustomerTemp].GetLady()));
                 print("yes lady");
             }
             TextCH(CustomerSeat[CustomerTemp]);
             AAAA = 1;
         }

        //在選擇Lady的狀態下才開啟Lady的Button
        if (AAAA == 2)
        {
            for (int i = 0; i < ladyseat.GetLadyMax(); i++)
            {
                if (ladyseat.GetisLadySeat(i) == true) button[i].interactable = false;
                else button[i].interactable = true;

            }
        }
        else {
            button[0].interactable = false;
            button[1].interactable = false;
            button[2].interactable = false;
            button[3].interactable = false;
            button[4].interactable = false;
            button[5].interactable = false;
            button[6].interactable = false;
            button[7].interactable = false;
           
        }
        */
    }

}
