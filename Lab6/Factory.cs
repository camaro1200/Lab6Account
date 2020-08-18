using System;
namespace Lab6
{
    public static class Factory
    {
        public static BaseAccount CreateAccount(double? interest = null,
            double? limit = null, int ?fee = null, int? day = null, Client client = null)
        {
            if (client == null)
            {
                Console.WriteLine("Fail");
                //throw exception
            }

            AccountType? accountType = null;

            if (day.HasValue && interest.HasValue)
            {
                accountType = AccountType.DepositAccount;
            }
            else  if (interest.HasValue)
            {
                accountType = AccountType.StandartAccount;
            }
            else if (fee.HasValue && limit.HasValue)
            {
                accountType = AccountType.CreditAccount;
            }
            if (!accountType.HasValue)
            {
                Console.WriteLine("Fail");
                //throw exception
            }

            switch (accountType)
            {
                case AccountType.DepositAccount:
                    return new DepositAccount(day.Value, interest.Value, client);
                case AccountType.StandartAccount:
                    return new StandardAccount(interest.Value, client);
                case AccountType.CreditAccount:
                    return new CreditAccount(limit.Value, fee.Value, client);
                default:
                    Console.WriteLine("Fail");
                    throw new Exception("Fail");
            }
        }
    }
}