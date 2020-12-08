using System;
using System.Collections.Generic;
using System.Text;

namespace BankRecordSystem
{
    class Account
    {
        //Properties
        private string AccountID = "54123280";
        private string PIN = "2811";
        private float Money = 2000;





        //Methods
        public float getMoney()
        {
            return this.Money;
        }

        public bool correctPIN(string introducedPIN)
        {
            return introducedPIN == this.PIN ? true : false;
        }

        public void depositMoney(float sum)
        {
            this.Money += sum;
        }

        public void withdrawMoney(float sum)
        {
            if(sum > this.Money)
            {
                Console.WriteLine("No money for withdraw, your account has " + this.Money + " $.");
            }
            else
            {
                this.Money -= sum;
            }
        }
    }
}
