using OrderManagment.CLI.Interfaces;
using OrderManagment.CLI.Models;
using System.Collections.Generic;

namespace OrderManagment.CLI.Implementations
{
    public class BillingReyaltyDepartment : IBillable
    {
        private IBillable _bill;
        public string BillingItemType { get; set; } = "book";
        public BillingReyaltyDepartment(IBillable bill)
        {
            _bill = bill;
        }
        public Billing GenerateBill(string itemName)
        {
            Billing billing = new Billing();
            Billing physicalItem = _bill.GenerateBill(itemName);
            Receipt royaltyDuplicate = new Receipt { 
                TotalBillingAmout = physicalItem.Receipts[0].TotalBillingAmout,
                BilligFor = physicalItem.Receipts[0].BilligFor,
                BillTo = "Royalty Department",
                Item = physicalItem.Receipts[0].Item
            };
            billing.Receipts = new List<Receipt>();
            billing.Receipts.AddRange(physicalItem.Receipts);
            billing.Receipts.Add(royaltyDuplicate);
            billing.Commission = physicalItem.Commission;
            return billing;
        }
    }
}
