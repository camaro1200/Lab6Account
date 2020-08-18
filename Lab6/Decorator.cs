using System;

namespace Lab6
{
    public class Decorator: BaseAccount
    {
        public bool Verified { get; set; }
        public float? UnverifiedLimit { get; set; }
        

        public Decorator(BaseAccount account, Client client, float? unverifiedLimit) : base(client)
        {
            Account = account;
            UnverifiedLimit = unverifiedLimit;
            if (account.C.Passport == null || account.C.Addy == "")
            {
                Verified = false;
            }
            else
            {
                Verified = true;
            }
        }

        public Decorator(BaseAccount account,float? unverifiedLimit)
        {
            Account = account;
            UnverifiedLimit = unverifiedLimit;
            if (account.C.Passport == null || account.C.Addy == "")
            {
                Verified = false;
            }
            else
            {
                Verified = true;
            }
        }

        public BaseAccount Account { get; }
        
        new public Client Client
        {
            get { return Account.C; }
        }

        new public double Money
        {
            get { return Account.Amount; }
        }

        public override void  Withdraw(double money)
        {
            if (Account != null)
            {
                if (!Verified && money > UnverifiedLimit)
                {
                    throw new Exception("fuuuk off");
                }
                else
                {
                    Account.Withdraw(money);
                    Console.WriteLine("success");
                }
            }
            else
            {
                throw new Exception("doesnt exist");
            }
        }

        new public void Deposit(double money)
        {
            if (Account != null)
            {
                Account.Deposit(money);
            }
            else
            {
                throw new Exception("doesnt exist");
            }

        }

        new public  void Transfer(BaseAccount account, double money)
        {
            if (account != null)
            {
                if (!Verified && money > UnverifiedLimit)
                {
                    throw new Exception("cant transfer");
                }
                else
                {
                    Account.Transfer(Account, money);
                    Console.WriteLine("success");
                }
            }
            else
            {
                throw new Exception("doesnt exist");
            }
        }
    }
}