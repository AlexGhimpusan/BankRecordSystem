using System;
using System.Collections.Generic;
using System.Text;

namespace BankRecordSystem
{
    class ATM
    {
        public static Costumer myCostumer = new Costumer();

        public static void welcome()
        {
            Console.WriteLine("***********************************************************************\n" +
                              "Buna ziua domnule " + myCostumer.Name + "!\n");
        }

        public static void showActions()
        {
            Console.WriteLine("***********************************************************************\n");
            Console.WriteLine("Soldul dumneavoastra este de: " + myCostumer.Acc.getMoney() + "$.\n");

            Console.WriteLine("Alegeti una dintre optiunile de jos\n" +
                              "0->Iesire.\n" +
                              "1->Retragere numerar.\n" +
                              "2->Depunere numerar.\n" +
                              "3->Schimbare PIN.\n");
            Console.Write("Optiunea: ");
        }

        public static int takeAction()
        {
            int action = Convert.ToInt32(Console.ReadLine());

            return action;
        }

        static void Main(string[] args)
        {
            welcome();
            if (myCostumer.Acc.checkPIN())
            {
                while (true)
                {
                    showActions();
                    int action = takeAction();
                    switch (action)
                    {
                        case 0:
                            Console.WriteLine("Va multumim! La revedere!");
                            System.Threading.Thread.Sleep(2000);
                            return;
                        case 1:
                            myCostumer.Acc.withdrawMoney();
                            System.Threading.Thread.Sleep(2000);
                            break;
                        case 2:
                            myCostumer.Acc.depositMoney();
                            System.Threading.Thread.Sleep(2000);
                            break;
                        case 3:
                            myCostumer.Acc.changePIN();
                            System.Threading.Thread.Sleep(2000);
                            break;
                        case 4:
                            
                            break;
                        default:
                            Console.WriteLine("Nu ati introdus o optiune valabila. Va rugam reincercati.\n");
                            System.Threading.Thread.Sleep(2000);
                            break;
                    }
                }
            }
        }
    }
}

//TO DO:

//Schimbare PIN
//Mai multe account-uri
//Transfer intre account-uri