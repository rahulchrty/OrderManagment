using OrderManagment.CLI.Implementations;
using OrderManagment.CLI.Interfaces;
using OrderManagment.CLI.Models;
using System;
using System.Collections.Generic;

namespace OrderManagment.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region DEPENDENCIES
            IBillable physicalProductBilling = new PhysicalProductBilling(new CommissionPayment());
            IList<IBillable> billables = new List<IBillable>
            {
                physicalProductBilling,
                new BillingReyaltyDepartment(physicalProductBilling)
            };
            IBillingProvider billingProvider = new BillingProvider(billables);
            IOrder order = new Order(billingProvider);
            #endregion

            ItemType();
            string userItemType = Console.ReadLine();
            int itemTypeId;
            Int32.TryParse(userItemType, out itemTypeId);
            Item(itemTypeId);
            string userItem = Console.ReadLine();
            int itemId;
            Int32.TryParse(userItem, out itemId);

            OrderedItem item = new OrderedItem
            {
                Type = "book",
                ItemName = "some book"
            };
            Billing billing = order.Process(item);

            Console.WriteLine();
            Console.WriteLine("*************************************************");
            foreach (Receipt receipt in billing.Receipts)
            {
                Console.WriteLine("Billig For: {0}", receipt.BilligFor);
                Console.WriteLine("Billig To: {0}", receipt.BillTo);
                Console.WriteLine("Item: {0}", receipt.Item);
                Console.WriteLine("Total Billing Amout: {0}", receipt.TotalBillingAmout);
                Console.WriteLine("====================================================");
            }
            if (billing.Commission != null)
            {
                Console.WriteLine("Commission To: {0}", billing.Commission.CommissionTo);
                Console.WriteLine("Commission Ammount: {0}", billing.Commission.CommissionAmmount);
            }
        }

        static void ItemType()
        {
            Console.WriteLine("1. Other physical product");
            Console.WriteLine("2. Book");
            Console.WriteLine("3. Subscriprion");
            Console.WriteLine("4. Subscriprion Upgrade");
            Console.WriteLine("5. Digital");
            Console.Write("Select Item Type(1-5): ");
        }

        static void Item(int type)
        {
            switch (type)
            {
                case 1:
                    Console.WriteLine("1. Computer");
                    Console.WriteLine("2. Mouse");
                    break;
                case 2:
                    Console.WriteLine("1. book 1");
                    Console.WriteLine("2. book 2");
                    break;
                case 3:
                    Console.WriteLine("1. New user Subscriprion");
                    break;
                case 4:
                    Console.WriteLine("1. Subscriprion upgrade");
                    break;
                case 5:
                    Console.WriteLine("1. Learning to ski");
                    Console.WriteLine("2. Some other video");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            Console.Write("Select a Product: ");
        }
    }
}
