namespace OrderManagment.CLI.Models
{
    public class Receipt
    {
        public string BillTo { get; set; }
        public string BilligFor { get; set; }
        public string Item { get; set; }
        public float TotalBillingAmout { get; set; }
    }
}
