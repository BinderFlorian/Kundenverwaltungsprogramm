
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyBib
{
    public class Customer
    {
        private string firstname;
        private string lastname;
        private string eMail;

        private double balance;
        public int custNum;
        private DateTime lastchange;

        public Customer(string firstname, string lastname, string eMail, double balance, int custNum, DateTime lastchange)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.eMail = eMail;
            this.balance = balance;
            this.custNum = custNum;
            this.lastchange = lastchange;
        }

        public Customer(string firstname, string lastname, string eMail)
        {
            this.Firstname = firstname;
            this.ChangeLastName = lastname;
            this.ChangeEmail = eMail;
            this.balance = 0;
            this.lastchange = DateTime.Now;
        }

        public int CustNum
        {
            get
            {
                return this.custNum;
            }
           
        }


        public void ReadLastCustNum(Customer[] customerList)
        {
            if (customerList.Length > 0)
            {
                this.custNum = customerList[customerList.Length - 1].CustNum + 1;
            }
            else
            {
                this.custNum = 10000;
            }
        }

        public string Firstname
        { 
            get
            {
                return this.firstname;
            }
            private set
            {
                if (value == null || value == String.Empty)
                {
                    throw new ArgumentNullException("No firstname!");
                }
                this.firstname = value;
            }
        }

        public string ChangeLastName
        {
            get
            {
                return this.lastname;
            }
            set
            {
                if (value == null || value == String.Empty)
                {
                    throw new ArgumentNullException("No lastname!");
                }
                this.lastname = value;
                this.lastchange = DateTime.Now;
            }
        }

        public string ChangeEmail
        {
            get
            {
                return this.eMail;
            }
            set
            {
                if (value == null || value == String.Empty)
                {
                    throw new ArgumentNullException("No lastname!");
                }
                else if(!CheckeMail(value))
                {
                    throw new ArgumentException("E-Mail not correct!(allowed symbols A-Z,a-z,@,.,0-9,#,$,%,&,',*,+,-,/,=,?,^,_,',{,|,},~,!)");
                }
                this.eMail = value;
                this.lastchange = DateTime.Now;
            }
        }

        public void Paid(double amount)
        {
            balance -= amount;
            this.lastchange = DateTime.Now;
        }
        public void Owed(double amount)
        {
            balance += amount;
            this.lastchange = DateTime.Now;
        }

        private static bool CheckeMail(string email)
        {
            bool mailcorrect = true;

            if (email.Contains("@") && email.Contains("."))
            {
                if (1 != email.Count(x => x.Equals('@')))
                {
                    mailcorrect = false;
                }

                string[] emailsplitAT = email.Split('@');
                if (1 < emailsplitAT[1].Count(x => x.Equals('.')))
                {
                    mailcorrect = false;
                }

                string[] emailsplitDot = email.Split('.');
                if ((emailsplitDot[emailsplitDot.Length - 1].Length > 4 || emailsplitDot[emailsplitDot.Length - 1].Length < 2))
                {
                    mailcorrect = false;
                }

                Regex r1 = new Regex("^[a-zA-Z]*$");
                if (!r1.IsMatch(emailsplitDot[emailsplitDot.Length - 1]))//Whit IsMatch the eMail part after the . is check about only letters)
                {
                    mailcorrect = false;
                }

                if (emailsplitAT[0].Length < 1)
                {
                    mailcorrect = false;
                }

                if (email[0] == '.' || emailsplitAT[0][emailsplitAT[0].Length - 1] == '.' || emailsplitAT[1][0] == '.' || email[email.Length - 1] == '.')
                {
                    mailcorrect = false;
                }
                Regex r2 = new Regex("^[a-zA-Z0-9!#$%&'*+-/=?^_'{|}~_]*$");
                if (!r2.IsMatch(emailsplitAT[0]))
                {
                    mailcorrect = false;
                }
            }
            else
            {
                mailcorrect = false;
            }

            return mailcorrect;
        }

        public override string ToString()
        {
            string text = string.Format("{0};{1};{2};{3};{4};{5}", this.custNum, this.firstname, this.lastname, this.eMail, this.balance, this.lastchange);
            return text;
        }
    }
}
