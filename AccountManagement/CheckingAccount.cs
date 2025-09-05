using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement
{

    public class CheckingAccount : Account
    {
        private double withdrawFee = 1.50;

        public CheckingAccount(string name = "Unnamed Account", double balance = 0.0)
            : base(name, balance)
        {
        }

        public override bool Withdraw(double amount)
        {
            double totalAmount = amount + withdrawFee;
            if (balance - totalAmount >= 0)
            {
                balance -= totalAmount;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"[CheckingAccount: Balance={balance}, Fee={withdrawFee}]";
        }
    }
}
