﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Account
    {
        private decimal minimumBalance = 10m;
        private decimal balance;

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            balance -= amount;
        }

        public void TransferFunds(Account destination, decimal amount)
        {
            if (balance - amount < minimumBalance)
                throw new InsufficientFundsException();

            destination.Deposit(amount);

            Withdraw(amount);
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public decimal MinimumBalance
        {
            get { return minimumBalance; }
        }
    }

    public class InsufficientFundsException : ApplicationException
    {
    }
}
