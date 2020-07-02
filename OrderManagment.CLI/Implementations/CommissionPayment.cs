using OrderManagment.CLI.Interfaces;
using OrderManagment.CLI.Models;

namespace OrderManagment.CLI.Implementations
{
    public class CommissionPayment : ICommissionPayment
    {
        public Commission GetCommissionPayment()
        {
            return new Commission {
                CommissionTo = "The Agent",
                CommissionAmmount = 12f
            };
        }
    }
}
