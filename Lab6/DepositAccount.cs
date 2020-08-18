using System;
using System.Data.SqlTypes;

namespace Lab6
{
    public class DepositAccount: BaseAccount
    {
        public DateTime Expires;

        public DepositAccount(int days, double inter, Client client)
        {
            Expires = new DateTime(DateTime.Now.Ticks + days * TimeSpan.TicksPerDay);
            Interest = inter;
            C = client;
        }
        
        override public void Withdraw(double money)
        {
            if (Amount - money < 0)
            {
                Console.WriteLine("not enough money");
                return;
            }
            if (this.Expires > DateTime.Now)
            {
                Console.WriteLine("cant withdraw yet");
            }
            Amount-= money;
        }

        public void Getinterest()
        {
            Amount += Amount * Interest;
        }
    }
}