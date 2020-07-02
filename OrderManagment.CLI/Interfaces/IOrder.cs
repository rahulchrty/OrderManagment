using OrderManagment.CLI.Models;

namespace OrderManagment.CLI.Interfaces
{
    public interface IOrder
    {
        Billing Process(OrderedItem item);
    }
}
