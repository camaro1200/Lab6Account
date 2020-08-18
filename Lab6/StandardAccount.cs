using System;
namespace Lab6
{
    public class StandardAccount : BaseAccount
    {
       

        public StandardAccount(double inter,  Client client)
        {
            Interest = inter;
            C = client;
        }

        public override void Withdraw(double sum)
        {
            if (sum > Amount)
            {
                Console.WriteLine("Fail ");
                return;
            }
            
            Amount -= sum;
            Console.WriteLine("succesful withdraw " + this.Amount);
        }
        

        public void InterestPayment()
        {
            Amount += Amount * Interest;
        }
    }
}