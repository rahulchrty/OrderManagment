using OrderManagment.CLI.Interfaces;
using OrderManagment.CLI.Models;

namespace OrderManagment.CLI.Implementations
{
    public class Order : IOrder
    {
        private readonly IBillingProvider _billingProvider;
        public Order(IBillingProvider billingProvider)
        {
            _billingProvider = billingProvider;
        }
        public Billing Process(OrderedItem item)
        {
            IBillable billable = _billingProvider.GetBillingType(item.Type);
            Billing billing = billable.GenerateBill(item.ItemName);
            return billing;
        }
    }
}
