using OrderManagment.CLI.Interfaces;
using OrderManagment.CLI.Models;
using System.Collections.Generic;

namespace OrderManagment.CLI.Implementations
{
    public class PhysicalProductBilling : IBillable
    {
        private ICommissionPayment _commissionPayment;
        public string BillingItemType { get; private set; } = "other physical product";
        public PhysicalProductBilling(ICommissionPayment commissionPayment)
        {
            _commissionPayment = commissionPayment;
        }
        public Billing GenerateBill(string itemName)
        {
            Billing billing = new Billing();
            Commission commission = _commissionPayment.GetCommissionPayment();
            billing.Receipts = new List<Receipt> 
            {
                new Receipt
                {
                    BillTo = "Customer",
                    Item = itemName,
                    BilligFor = "Packing",
                    TotalBillingAmout = 1.2f,
                } 
            };
            billing.Commission = commission;
            return billing;
        }
    }
}
