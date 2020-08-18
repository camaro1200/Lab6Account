using System;
namespace Lab6
{
    public class CreditAccount: BaseAccount
    {
        public double Limit;
        public double Fee;

        public CreditAccount(double lim, double f, Client client)
        {
            Limit = lim;
            Fee = f;
            C = client;

        }

        override public void Withdraw(double sum)
        {
            if (sum > Limit )
            {
                Console.WriteLine("CreditAccount: Limit exceeded");
                return;
            }
            
            Amount -= sum;
            Console.WriteLine("succesful withdraw of CreditAcc " + this.Amount);
        }

        public void PayFee()
        {
            if (Amount < 0)
            {
                Amount -= Fee;
                Console.WriteLine("succesful Feepay " + this.Amount);
            }
            else
                Console.WriteLine("no fee " + this.Amount);
        }
        
        
    }
}