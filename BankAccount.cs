using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Nubia Levon MEID 2054987

namespace BankAccount
{
    class BankAccount
    {
        private String accountName;
        private int accountNo;
        private double beginBalance;
        private double currBalance;

        // Get Set methods
        public String AccountName
        {
            
            get
            {
                return accountName;
            }
        }
        public int AccountNo
        {
            
            get
            {
                return accountNo;
            }
        }
        public double BeginBalance
        {
            get
            {
                return beginBalance;
            }
        }
        public double CurrBalance
        {
            set
            {
                currBalance = value;
            }
            get
            {
                return currBalance;
            }
        }

        // Default constructor
        public BankAccount()
        {
            
        }

        // This method processes the withdrawal
        // converting the textbox value
        public void DoWithdraw(String s)
        {
            double withdraw;
            withdraw = Double.Parse(s);
            currBalance -= withdraw;
        }
        // This method processes the deposit
        // converting the textbox value
        public void DoDeposit(String s)
        {
            double deposit;
            deposit = Double.Parse(s);
            currBalance += deposit;
        }
        // This method saves the account 
        // information
        public void DoAccountInfo(String n, String numStr, String balStr)
        {
            
            accountName = n;
            accountNo = Int32.Parse(numStr);
            beginBalance = Double.Parse(balStr);
            currBalance = beginBalance;
        }
        // This method clears all values in the object
        public void Clear()
        {
            accountName = "";
            accountNo = 0;
            beginBalance = 0.0;
            currBalance = 0.0;
        }

    }
}
