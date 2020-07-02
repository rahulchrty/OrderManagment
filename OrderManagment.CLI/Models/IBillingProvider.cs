using OrderManagment.CLI.Interfaces;

namespace OrderManagment.CLI.Models
{
    public interface IBillingProvider
    {
        IBillable GetBillingType(string billingItemType);
    }
}
