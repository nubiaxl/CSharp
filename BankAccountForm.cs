using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//by Nubia Levon MEID 2054987
namespace BankAccount
{
    public partial class BankAccountForm : Form
    {
        // Instantiate the bank account object for the form
        BankAccount anAccount = new BankAccount();
        public BankAccountForm()
        {
            InitializeComponent();
        }

        private void btnAccountInfo_Click(object sender, EventArgs e)
        {
            //Make the Account Information group visible to user
            groupAccountInfo.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear the text boxes
            txtAccountName.Text = "";
            txtAccountNo.Text = "";
            txtBalance.Text = "";
            txtDeposit.Text = "";
            txtWithdraw.Text = "";

            // Make the groups invisible
            groupAccountInfo.Visible = false;
            groupAccountActivity.Visible = false;

            // Make Account Info text boxes writable
            txtAccountName.ReadOnly = false;
            txtAccountNo.ReadOnly = false;
            txtBalance.ReadOnly = false;

            // Clear the data from the bank account object
            anAccount.Clear();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (ValidateAccountInfo())
            {   // Make text boxes readonly
                txtAccountName.ReadOnly = true;
                txtAccountNo.ReadOnly = true;
                txtBalance.ReadOnly = true;

                // Change balance label to available balance
                lblBalance.Text = "Available Balance";
                // Make Account Activity group visible
                groupAccountActivity.Visible = true;
                // Set the maximum length for the account number
                txtAccountNo.MaxLength = 8;

                //BankAccount anAccount = new BankAccount();
                ProcessAccountInfo();
                
            }

        }

        private Boolean ValidateAccountInfo()
        {
            Boolean isValid = true;
            // account name blank
            if (txtAccountName.Text == "")
                isValid = false;
            // account number blank or not 8 digits
            else if (txtAccountNo.Text == "" || txtAccountNo.TextLength != 8)
                isValid = false;
            // balance blank
            else if (txtBalance.Text == "")
                isValid = false;
            // account number is all digits
            else if (!CheckAllNumbers(txtAccountNo.Text))
                isValid = false;
            // text balance is in format ###.##
            else if (!CheckGoodAmount(txtBalance.Text))
                isValid = false;
            else
                isValid = true;

            if (!isValid)
                MessageBox.Show("You must enter a name," +
                    "\n8 dig account no formatted like ########," +
                    "\nand begin balance formatted like ###.##", "Bank Account",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            return isValid;

        }
        private Boolean ValidateAccountActivity()
        {
            Boolean isValid = true;
            // Blank deposit and withdrawal text boxes
            if ((txtDeposit.Text == "") && (txtWithdraw.Text == ""))
                isValid = false;
            // Withdrawal not in format ###.##
            else if (!CheckGoodAmount(txtWithdraw.Text))
                isValid = false;
            // Deposit not in format ###.##
            else if (!CheckGoodAmount(txtDeposit.Text))
                isValid = false;
            else
                isValid = true;

            if (!isValid)
                MessageBox.Show("Enter amounts in the format ###.##", "Bank Account",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            return isValid;
        }
        private Boolean CheckAllNumbers( String s )
        {
            Boolean valid = true;

            //Check each of the string positions checking for a digit, 
            //as soon as invalid char then exit loop
            for( int x = 0; x < s.Length && valid; x++ )
            {
                if (!char.IsNumber(s[x]))
                    valid = false;
                else
                    valid = true;
            }
            return valid;
        }
        private Boolean CheckGoodAmount(String s)
        {
            Boolean valid = true;

            // Check each of the char positions and as soon as invalid
            // character found exit the loop
            for (int x = 0; x < s.Length && valid; x++)
            {
                if (char.IsNumber(s[x]))
                {
                    valid = true;



                }
                else
                {   // Check for decimal point and correct number of digits
                    if ((s[x] == '.') && (x == s.Length - 3 ))
                        valid = true;
                    else
                        valid = false;
                }
                             
               
            }
            return valid;
            
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Process the account activity
            if (ValidateAccountActivity())
            {
                if (txtWithdraw.Text != "")
                    ProcessWithdrawal();
                if (txtDeposit.Text != "")
                    ProcessDeposit();
                // Clear the text boxes
                txtWithdraw.Text = "";
                txtDeposit.Text = "";
            }
            // Update the balance text box
            txtBalance.Text = anAccount.CurrBalance.ToString("F2");
            this.Update();
            
        }

        
        public void ProcessWithdrawal()
        {
            anAccount.DoWithdraw(txtWithdraw.Text);
        }
        public void ProcessDeposit()
        {
            anAccount.DoDeposit(txtDeposit.Text);
        }
        public void ProcessAccountInfo()
        {
            anAccount.DoAccountInfo(txtAccountName.Text, txtAccountNo.Text, txtBalance.Text);
        }

        
    }
}
