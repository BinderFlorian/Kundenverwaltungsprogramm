using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.IO;

namespace MyBib
{
    public class CustomerList 
    {
        private Customer [] customerList = new Customer[0];
        private Customer foundCustomer;

        #region Konstruktor

        public CustomerList()
        {
            
        }

        #endregion

        #region Methoden

        public void AddNewCustomer(Customer customer)
        {
            Array.Resize(ref customerList, customerList.Length + 1);
            customerList[customerList.Length - 1] = customer;
        }

        public void WriteCustomerList()
        {

            StreamWriter writer = new StreamWriter(@"..\..\CustomerList.txt",false, Encoding.UTF32);

          
            foreach (Customer customer in this.customerList)
            {
                if (customer != null)
                {
                    writer.WriteLine(customer.ToString());
                }
            }

            writer.Close();
        }

        public void ReadCustomerList()
        {
            if (File.Exists(@"..\..\CustomerList.txt"))
            {
                StreamReader reader = new StreamReader(@"..\..\CustomerList.txt", Encoding.UTF32);

                string[] line = new string[0];
                int i = 0;


                while (reader.Peek() > -1)
                {
                    
                        Array.Resize(ref line, line.Length + 1);
                        line[line.Length - 1] = reader.ReadLine();
                        i++;
                    
                }

                reader.Close();
                //CSV in BindingList

                for (int j = 0; j < i; j++)
                {
                    string[] split = line[j].Split(';');
                    AddNewCustomer(new Customer(split[1], split[2], split[3], Convert.ToDouble(split[4]),  Convert.ToInt32(split[0]), Convert.ToDateTime(split[5])));
                }
            }
        }

        public void ChangedCustomer(Customer customerchanged)
                {
                    int custnumr = customerchanged.CustNum;
                    for (int i = 0; i < customerList.Length; i++)
                    {
                        if (customerList[i].CustNum == customerchanged.CustNum)
                        {
                            customerList[i] = customerchanged;
                            break;
                        }
                    }
                }
            

                 

        public Customer [] Data()
        {
            return this.customerList;
        }

        public int numberOfCustomers()
        {
            return customerList.Length;
        }

        public Customer SelectedCustomer(int customerNumber)
        {
            foreach (Customer customer in customerList)
            {
                if (customer != null)
                {
                    if (customer.CustNum == customerNumber)
                    {
                        foundCustomer = customer;                   
                    }
                }
            }

            return foundCustomer;  
        }

        #endregion
    }
}
