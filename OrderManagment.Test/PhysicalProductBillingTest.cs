using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrderManagment.CLI.Implementations;
using OrderManagment.CLI.Interfaces;
using OrderManagment.CLI.Models;

namespace OrderManagment.Test
{
    [TestClass]
    public class PhysicalProductBillingTest
    {
        private Mock<ICommissionPayment> _mockCommissionPayment;
        private PhysicalProductBilling _physicalProductBilling;
        [TestInitialize]
        public void Setup()
        {
            _mockCommissionPayment = new Mock<ICommissionPayment>();
            _physicalProductBilling = new PhysicalProductBilling(_mockCommissionPayment.Object);
        }

        //Given: A Item as 'computer'
        //When: I call GenerateBill
        //Then: I get an billing object
        [TestMethod]
        public void Given_Item_As_Computer()
        {
            string itemName = "computer";
            _mockCommissionPayment.Setup(x => x.GetCommissionPayment())
                .Returns(new Commission { CommissionTo = "Agent", CommissionAmmount = 1f});
            var result = _physicalProductBilling.GenerateBill(itemName);
            Assert.IsTrue(result is Billing);
        }

        //Given: A Item as 'computer'
        //When: I call GenerateBill
        //Then: The billable object as a commission type
        [TestMethod]
        public void Given_Item_As_Computer_Then_Billable_Object_Has_Commission()
        {
            string itemName = "computer";
            _mockCommissionPayment.Setup(x => x.GetCommissionPayment())
                .Returns(new Commission { CommissionTo = "Agent", CommissionAmmount = 1f });
            var result = _physicalProductBilling.GenerateBill(itemName);
            Assert.IsTrue(result.Commission is Commission);
        }
    }
}
