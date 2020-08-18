using System;
using System.Collections.Generic;


//using System.Console;
namespace Lab6 
{
    internal class Program 
    { 
      
      public static void Main(string[] args)
      {
            ClientBuilder builder = new ClientBuilder();
            builder.AddName("John", "Green");
            //builder.AddAddress("CA");
            //builder.AddPassportNumber(111);
            Client client1 = builder.GetResult();
            Console.WriteLine(client1.ToString() + "\n");
            
            builder.Reset();
            builder.AddName("Angela", "Green");
            builder.AddAddress("NY");
            builder.AddPassportNumber(222);
            Client client2 = builder.GetResult();
            Console.WriteLine(client2.ToString() + "\n");
            
            
            BaseAccount acc1 = Factory.CreateAccount(interest: 0.04,  client: client1); // standard acc
            BaseAccount acc2 = Factory.CreateAccount(limit: 300, fee: 50, client: client2);  // credit acc
            BaseAccount acc3 = Factory.CreateAccount(day: 2, interest: 50, client: client2);  // deposit acc
            
            acc2.Deposit(1000);
            acc2.Withdraw(305);
            acc1.Deposit(1000);
            acc3.Deposit(1000);
            acc3.Withdraw(500);
            acc1.Transfer( acc2, 50);
            
            BaseAccount unverifiedAccount = new Decorator(acc1, 1000);
            try
            {
                unverifiedAccount.Withdraw(1200);
                unverifiedAccount.Transfer(acc2, 500);
                //Console.WriteLine(unverifiedAccount.Client.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            var task1 = new SetInterestHandler();
            var task2 = new WithdrawHandler();
            
            task1.SetNext(task2);
            task1.Handle(acc1);
           
      }
    }
}