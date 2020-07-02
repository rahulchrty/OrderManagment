using OrderManagment.CLI.Interfaces;
using OrderManagment.CLI.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagment.CLI.Implementations
{
    public class BillingProvider : IBillingProvider
    {
        private readonly IList<IBillable> _billables;
        public BillingProvider(IList<IBillable> billables)
        {
            _billables = billables;
        }
        public IBillable GetBillingType(string billingItemType)
        {
            return _billables.FirstOrDefault(x => x.BillingItemType == billingItemType);
        }
    }
}
