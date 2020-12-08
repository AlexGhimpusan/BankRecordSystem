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

        public static bool checkPIN()
        {
            Console.WriteLine("Va ruga introduceti PIN-ul si apasati tasta ENTER: ");
            try
            {
                string enteredVal = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    // Backspace should not work  
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        enteredVal += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && enteredVal.Length > 0)
                        {
                            enteredVal = enteredVal.Substring(0, (enteredVal.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            if (string.IsNullOrWhiteSpace(enteredVal))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Nu ati introdus nicio cifra.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                break;
                            }
                        }
                    }
                } while (true);
                if (myCostumer.Acc.correctPIN(enteredVal))
                {
                    Console.WriteLine("AUTENTIFICAT!\n");
                    System.Threading.Thread.Sleep(2000);
                    return true;
                }
                else
                {
                    Console.WriteLine("NEAUTENTIFICAT!\n");
                    System.Threading.Thread.Sleep(2000);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void showActions()
        {
            Console.WriteLine("***********************************************************************\n");
            Console.WriteLine("Soldul dumneavoastra este de: " + myCostumer.Acc.getMoney() + "$.\n");

            Console.WriteLine("Alegeti una dintre optiunile de jos\n" +
                              "0->Iesire.\n" +
                              "1->Retragere numerar.\n" +
                              "2->Depunere numerar.\n");
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
            if (checkPIN())
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
                            Console.Write("Introduceti suma pentru retragere: ");
                            float withdrawSum = Convert.ToInt32(Console.ReadLine());
                            myCostumer.Acc.withdrawMoney(withdrawSum);
                            Console.WriteLine("Ati retras suma de: " + withdrawSum + "$\n");
                            System.Threading.Thread.Sleep(2000);
                            break;
                        case 2:
                            Console.Write("Introduceti suma pentru depozitare: ");
                            float depositSum = Convert.ToInt32(Console.ReadLine());
                            myCostumer.Acc.depositMoney(depositSum);
                            Console.WriteLine("Ati depozitat suma de: " + depositSum + "$\n");
                            System.Threading.Thread.Sleep(2000);
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