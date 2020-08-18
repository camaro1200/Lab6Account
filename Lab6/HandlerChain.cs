using System;

namespace Lab6
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        
        object Handle(object request);
    }

    abstract class BaseHandler : IHandler
    {
        public IHandler nextHandler;

        public BaseHandler() { }
        
        public BaseHandler(IHandler handler)
        {
            SetNext(handler);
        }
        public IHandler SetNext(IHandler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public virtual object Handle(object request)
        {
            if (nextHandler != null)
            {
                return nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
    }
    
    class WithdrawHandler : BaseHandler
    {
        public override object Handle(object request)
        {
            if (request is CreditAccount || request is DepositAccount || request is StandardAccount)
            {
                var account = request as BaseAccount;
                account.Withdraw(account.Amount);
                Console.WriteLine("succesful withdraw in handler");
                if (nextHandler != null)
                {
                    return nextHandler.Handle(request);
                }
                else
                {
                    return account;
                }
            }
            else
            {
                return base.Handle(request);
            }
        }
    }

    class SetInterestHandler : BaseHandler
    {
        public override object Handle(object request)
        {
            if (request is DepositAccount)
            {
                var account = request as DepositAccount;
                account.Deposit(account.Amount * account.Interest);
                return nextHandler.Handle(request);
            }
            else
            {
                if (request is StandardAccount)
                {
                    var account = request as StandardAccount;
                    account.Deposit(account.Amount * account.Interest);
                    Console.WriteLine("interest added");
                    if (nextHandler != null)
                    {
                        Console.WriteLine("hhh");
                        return nextHandler.Handle(request);
                    }
                    else
                    {
                        Console.WriteLine("ll");
                        return account;
                    }

                }
                else
                {
                    return base.Handle(request);
                }
            }
        }
    }

}