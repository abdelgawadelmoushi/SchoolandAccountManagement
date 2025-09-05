using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement
{

    public class SavingsAccount : Account
    {
        private double interestRate;
        private int withdrawCount;

        public SavingsAccount(string name = "Unnamed Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance)
        {
            this.interestRate = interestRate;
            withdrawCount = 0;
        }

        public override bool Deposit(double amount)
        {
            if (amount <= 0)
                return false;



            balance += amount + amount * interestRate / 100;
            return true;
        }

        public override bool Withdraw(double amount)
        {
            if (withdrawCount >= 3)
                return false;

            if (base.Withdraw(amount))
            {
                withdrawCount++;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"[SavingsAccount: Balance={balance}, InterestRate={interestRate}%, Withdrawals={withdrawCount}]";
        }
    }
}
