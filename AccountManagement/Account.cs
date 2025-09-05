using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement
{

    public class Account
    {

        private string name;
        protected double balance;

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.name = name;
            this.balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (balance - amount >= 0)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetBalance()
        {
            return balance;
        }

        public override string ToString()
        {
            return $"[Account: {name}: {balance}]";
        }



    }
}
