using PublishingCenter_v2.PublishingCenter.Tables;
using System;

namespace PublishingCenter_v2.PublishingCenter.Menu
{
    public class Menu
    {
        public static void Start()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Publishing Center");
                Console.WriteLine("1. Writers\n2. Contracts\n3. Customers\n4. Books\n5. Orders\n6. Exit");
                string str = Console.ReadLine();
                if (str == "Writers")
                {
                    Console.Clear();
                    TabWriters.WritersStart();
                    
                }
                else if (str == "Contracts")
                {
                    Console.Clear();
                    TabContarcts.ContractsStart();
                    
                }
                else if (str == "Customers")
                {
                    Console.Clear();
                    TabCustomers.CustomersStart();
                }
                else if (str == "Books")
                {
                    Console.Clear();
                    TabBooks.BooksStart();
                }
                else if (str == "Orders")
                {
                    Console.Clear();
                    TabOrders.OrdersStart();
                }
                else if (str == "Exit")
                    exit = true;
                else
                    Console.WriteLine("Incorrect value!");
            }
        }
    }
}
