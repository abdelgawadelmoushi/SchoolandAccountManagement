using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement
{


    public class TrustAccount : SavingsAccount
    {
        private int withdrawCount;
        private const int MaxWithdrawals = 3;
        private const double BonusAmount = 50.0;

        public TrustAccount(string name = "Unnamed Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance, interestRate)
        {
            withdrawCount = 0;
        }

        public override bool Deposit(double amount)
        {
            if (amount >= 5000)
                balance += BonusAmount;

            return base.Deposit(amount);
        }

        public override bool Withdraw(double amount)
        {
            if (withdrawCount >= MaxWithdrawals)
                return false;

            if (amount > balance * 0.25)
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
            return $"[TrustAccount: Balance={balance}, Withdrawals={withdrawCount}/{MaxWithdrawals}]";
        }
    }
}
