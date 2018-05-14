using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBib;


namespace UnitTest_CustomerLogin
{
    [TestClass]
    public class CustomerLogin_Unittest
    {

        //_Pos....Positiv Test
        //_Neg....Negativ Test

        //----------------Customer Class------------------

        [TestMethod]
        public void Customer_Const_Pos()
        {
            try
            {
                Customer customer = new Customer("Flo", "Binder", "flo@gmx.at");

            
            }
            catch (Exception ex)
            {
                Assert.Fail();
                return;
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentException), "E-Mail not correct!(allowed symbols A-Z,a-z,@,.,0-9,#,$,%,&,',*,+,-,/,=,?,^,_,',{,|,},~,!)")]
        public void Customer_Const_Neg_EMail()
        {
            Customer customer = new Customer("Flo", "Binder", "f:lo@gmx.at");
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException), "No firstname!")]
        public void Customer_Const_Neg_firstname()
        {
            Customer customer = new Customer("", "Binder", "flo@gmx.at");
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException), "No lastname!")]
        public void Customer_Const_Neg_secname()
        {
            Customer customer = new Customer("Flo", "", "flo@gmx.at");
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException), "No lastname!")]
        public void Customer_Const_Neg_NoEMAIL()
        {
            Customer customer = new Customer("Flo", "Binder", "");
        }

        [TestMethod]
        public void Customer_ChangeSecname_Pos()
        {
            try
            {
                // arrange
                Customer customer = new Customer("Florian", "Binder", "flo@gmx.at");
                //act
                customer.ChangeLastName = "Bindeeeer";

            
            }
            catch (Exception ex)
            {
                Assert.Fail();
                return;
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException), "No lastname!")]
        public void Customer_ChangeSecname_Neg()
        {
            // arrange
            Customer customer = new Customer("Flo", "Binder", "flo@gmx.at");
            //act
            customer.ChangeLastName = "";
        }

        [TestMethod]
        public void Customer_ReadLastcustNum_Pos()
        {
            try
            {
                // arrange
                Customer customer = new Customer("Florian", "Binder", "flo@gmx.at");
                CustomerList customerList = new CustomerList();
                customerList.ReadCustomerList();

                //act
                customer.ReadLastCustNum(customerList.Data());
                Assert.IsTrue(customer.CustNum >= 10000);
            }
            catch (Exception ex)
            {
                Assert.Fail();
                return;
            }
        }


        public void Customer_ChangeEMAIL_Pos()
        {
            try
            {
                // arrange
                Customer customer = new Customer("Flo", "Binder", "flo@gmx.at");
                //act
                customer.ChangeEmail = "flllllo@gmx.at";


            }
            catch (Exception ex)
            {
                Assert.Fail();
                return;
            }
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException), "No E-Mail!")]
        public void Customer_ChangeEMAIL_null_Neg()
        {
            // arrange
            Customer customer = new Customer("Flo", "Binder", "flo@gmx.at");
            //act
            customer.ChangeEmail = "";
        }

        [TestMethod, ExpectedException(typeof(ArgumentException), "E-Mail not correct!(allowed symbols A-Z,a-z,@,.,0-9,#,$,%,&,',*,+,-,/,=,?,^,_,',{,|,},~,!)")]
        public void Customer_ChangeEMAIL_Neg()
        {
            // arrange
            Customer customer = new Customer("Flo", "Binder", "flo@gmx.at");
            //act
            customer.ChangeEmail = "flo@gmx.at::";
        }

        [TestMethod]
        public void Customer_PaidOwed_Pos()
        {
            // arrange
            Customer customer = new Customer("Flo", "Binder", "flo@gmx.at");

            customer.Owed(10.0);
            double amount = Convert.ToDouble(customer.ToString().Split(';')[4]);
            Assert.IsTrue(amount == 10.0);

            customer.Paid(10.0);
            amount = Convert.ToDouble(customer.ToString().Split(';')[4]);
            Assert.IsTrue(amount == 0.0);
        }


        //----------------CustomerList Class--------------------

        [TestMethod]
        public void CustomerList_ReadCustList_Pos()
        {
            try
            {
                // arrange
                Customer customer = new Customer("Flo", "Binder", "flo@gmx.at");
                CustomerList customerList = new CustomerList();

                //act
                customerList.ReadCustomerList();

            }
            catch (Exception ex)
            {
                Assert.Fail();
                return;
            }
        }

        [TestMethod]
        public void CustomerList_AddCustomer_Pos()
        {
            try
            {
                // arrange
                Customer customer = new Customer("Flo", "Binder", "flo@gmx.at");
                CustomerList customerList = new CustomerList();
                customerList.ReadCustomerList();
                customer.ReadLastCustNum(customerList.Data());

                //act
                customerList.AddNewCustomer(customer);

            }
            catch (Exception ex)
            {
                Assert.Fail();
                return;
            }
        }

        [TestMethod]
        public void CustomerList_WriteList_Pos()
        {
            try
            {
                // arrange
                Customer customer = new Customer("Flo", "Binder", "flo@gmx.at");
                CustomerList customerList = new CustomerList();
                customerList.ReadCustomerList();
                customer.ReadLastCustNum(customerList.Data());
                customerList.AddNewCustomer(customer);

                //act
                customerList.WriteCustomerList();

            }
            catch (Exception ex)
            {
                Assert.Fail();
                return;
            }
        }

        public void Customer_ChangeCustomerinList_Pos()
        {
            try
            {
                // arrange
                
                CustomerList customerList = new CustomerList();
                customerList.ReadCustomerList();
                Customer customer = customerList.Data()[0];
                customer.ChangeLastName = "Biiiinnndder";

                //act
                customerList.ChangedCustomer(customer);

            }
            catch (Exception ex)
            {
                Assert.Fail();
                return;
            }
        }
    }
}
    

