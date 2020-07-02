using System.Collections.Generic;

namespace OrderManagment.CLI.Models
{
    public class Billing
    {
        public List<Receipt> Receipts { get; set; }
        public Commission Commission { get; set; }
        public string Notification { get; set; }
        public string ValueAdded { get; set; }
    }
}
