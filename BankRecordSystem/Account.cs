using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BankRecordSystem
{
    class Account
    {
        //Properties
        private string AccountID;
        private string PIN = "2811";
        private float Money = 2000;





        //Methods
        public float getMoney()
        {
            return this.Money;
        }

        public void setMoney(float sum)
        {
            this.Money = sum;
        }

        public void depositMoney()
        {
            Console.Write("Introduceti suma pentru depozitare: ");
            float depositSum = Convert.ToInt32(Console.ReadLine());
            if (depositSum > 0)
            {
                this.Money += depositSum;
                Console.WriteLine("Ati depozitat suma de: " + depositSum + "$");
            }
            else
            {
                Console.WriteLine("Nu puteti depozita valori negative sau egale cu 0. Va rugam reincercati.");
            }
            
        }

        public void withdrawMoney()
        {
            Console.Write("Introduceti suma pentru retragere: ");
            float withdrawSum = Convert.ToInt32(Console.ReadLine());
            if (withdrawSum > 0)
            {
                if (withdrawSum > this.Money)
                {
                    Console.WriteLine("Nu puteti retrage mai mult de " + this.Money + " $.");
                }
                else
                {
                    this.Money -= withdrawSum;
                    Console.WriteLine("Ati retras suma de: " + withdrawSum + "$");
                }
            }
            else
            {
                Console.WriteLine("Nu puteti retrage valori negative sau egale cu 0. Va rugam reincercati.");
            }
            
        }

        public bool correctPIN(string introducedPIN)
        {
            return introducedPIN == this.PIN ? true : false;
        }

        public bool checkPIN()
        {
            Console.Write("Va ruga introduceti PIN-ul si apasati tasta ENTER: ");
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
                if (this.correctPIN(enteredVal))
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

        public void changePIN()
        {
            string enteredVal = "";
            Console.Write("Va rugam introduceti PIN-ul actual: ");
            try
            {
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
            }
            catch(Exception ex)
            {
                throw ex;
            }
            string PIN = enteredVal;

            enteredVal = "";
            Console.Write("Va rugam introduceti noul PIN: ");
            try
            {
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
            }
            catch(Exception ex)
            {
                throw ex;
            }
            string newPIN = enteredVal;

            if (PIN == this.PIN)
            {
                this.PIN = newPIN;
                Console.WriteLine("PIN-ul a fost schimbat cu succes.");
            }
            else
            {
                Console.WriteLine("PIN-ul actual a fost gresit. Va rugam reincercati.");
                return;
            }
        }
    }
}
