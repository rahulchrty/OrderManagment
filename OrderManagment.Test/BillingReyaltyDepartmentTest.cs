using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagment.CLI.Implementations;
using OrderManagment.CLI.Interfaces;
using OrderManagment.CLI.Models;
using System.Collections.Generic;

namespace OrderManagment.Test
{
    [TestClass]
    public class BillingReyaltyDepartmentTest
    {
        private Mock<IBillable> _mockBill;
        private BillingReyaltyDepartment _billingReyaltyDepartment;
        [TestInitialize]
        public void Setup()
        {
            _mockBill = new Mock<IBillable>();
            _billingReyaltyDepartment = new BillingReyaltyDepartment(_mockBill.Object);
        }

        //Given: An a book as a product
        //When: I call GenerateBill
        //Then: I get  a type of Billing
        [TestMethod]
        public void Given_Book_Itme()
        {
            string itemName = "some book";
            Billing billing = new Billing
            {
                Receipts = new List<Receipt> { new Receipt {
                TotalBillingAmout = 1f,
                BilligFor = "Packing",
                BillTo = "Customer",
                Item = "book"} },
                Commission = new Commission { CommissionAmmount = 1f, CommissionTo = "Agent" }
            };
            _mockBill.Setup(x => x.GenerateBill(It.IsAny<string>())).Returns(billing);
            var result = _billingReyaltyDepartment.GenerateBill(itemName);
            Assert.IsTrue(result is Billing);
        }

        //Given: An a book as a product
        //When: I call GenerateBill
        //Then: I get 2 receipts
        [TestMethod]
        public void Given_Book_Itme_Get_2_Receipts()
        {
            string itemName = "some book";
            Billing billing = new Billing
            {
                Receipts = new List<Receipt> { new Receipt {
                TotalBillingAmout = 1f,
                BilligFor = "Packing",
                BillTo = "Customer",
                Item = "book"} },
                Commission = new Commission { CommissionAmmount = 1f, CommissionTo = "Agent" }
            };
            _mockBill.Setup(x => x.GenerateBill(It.IsAny<string>())).Returns(billing);
            var result = _billingReyaltyDepartment.GenerateBill(itemName);
            Assert.AreEqual(result.Receipts.Count, 2);
        }

        //Given: An a book as a product
        //When: I call GenerateBill
        //Then: I get 2nd receipt BillTo as 'Royalty Department'
        [TestMethod]
        public void Given_Book_Itme_Get_2nd_Receipt_With_Royalty_Department()
        {
            string itemName = "some book";
            Billing billing = new Billing
            {
                Receipts = new List<Receipt> { new Receipt {
                TotalBillingAmout = 1f,
                BilligFor = "Packing",
                BillTo = "Customer",
                Item = "book"} },
                Commission = new Commission { CommissionAmmount = 1f, CommissionTo = "Agent" }
            };
            _mockBill.Setup(x => x.GenerateBill(It.IsAny<string>())).Returns(billing);
            var result = _billingReyaltyDepartment.GenerateBill(itemName);
            Assert.AreEqual(result.Receipts[1].BillTo, "Royalty Department");
        }
    }
}
