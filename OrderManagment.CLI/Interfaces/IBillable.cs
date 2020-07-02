using OrderManagment.CLI.Models;
using System.Collections.Generic;

namespace OrderManagment.CLI.Interfaces
{
    public interface IBillable
    {
        string BillingItemType { get; }
        Billing GenerateBill(string itemName);
    }
}
