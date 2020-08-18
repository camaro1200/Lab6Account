using System;

namespace Lab6
{
    public abstract class BaseAccount
    {
        public double Amount;
        public Client C;
        public double Interest;

        public BaseAccount(Client client)
        {
            this.C = client;
        }

        public BaseAccount()
        {
            
        }
        
        public void Deposit(double sum)
        {
            Amount += sum;
            Console.WriteLine("succesful deposit " + this.Amount);
        }

        public abstract void Withdraw(double money);

        public virtual void Transfer(BaseAccount account, double sum)
        {
            if (Amount < sum)
                return;
            
            Withdraw(sum);
            account.Deposit(sum);
            
            Console.WriteLine("transfer complete " + Amount);
        }
        
    }
}