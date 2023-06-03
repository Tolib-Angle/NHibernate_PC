using System;
using System.Collections.Generic;
using PublishingCenter_v2.NHibernate;
using PublishingCenter_v2.PublishingCenter.Interface;
using PublishingCenter_v2.NHibernate.Data;

namespace PublishingCenter_v2.PublishingCenter.Tables
{
    public class TabOrders
    {
        private static int BLOCK = 10, pages, page = 1, user_num = 1;
        private static int user_action = -1, all_orders = Repository.Instance.GetCount<Orders>();
        private static TemplateInterface<Orders> templateInterface = new TemplateInterface<Orders>(BLOCK);
        private static IList<Orders> orders;
        public static void OrdersStart()
        {
            templateInterface.Reset();
            if (all_orders % BLOCK != 0)
                pages = (all_orders / BLOCK) + 1;
            else
                pages = all_orders / BLOCK;
            OrdersMenu();
        }

        private static void OrdersMenu()
        {
            bool exit = false;
            while (!exit)
            {
                user_num = BLOCK * (page - 1) + 1;
                if (user_action != 2 || user_action == -1)
                    ShowNext();
                else if (user_action == 2)
                    ShowPrev();
                ShowListBooks();
                Console.WriteLine("Page {0} from {1}", page, pages);
                user_action = TemplateHelpFunctions.ReturnUserAction(page, pages);
                switch (user_action)
                {
                    case 1:
                        {
                            page++;
                            Console.Clear();
                        }
                        break;
                    case 2:
                        {
                            page--;
                            Console.Clear();
                        }
                        break;
                    case 3:
                        {
                            Add();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        {
                            Update();
                            Console.Clear();
                        }
                        break;
                    case 5:
                        {
                            Delete();
                            Console.Clear();
                        }
                        break;
                    case 6:
                        {
                            //Search();
                            Console.Clear();
                        }
                        break;
                    case 7:
                        exit = true;
                        break;
                }
            }
        }

        private static void ShowNext()
        {
            orders = templateInterface.NextPackage();
            templateInterface.SetNewId(orders[0].id, orders[orders.Count - 1].id);
        }

        private static void ShowPrev()
        {
            orders = templateInterface.PrevPackage();
            templateInterface.SetNewId(orders[0].id, orders[orders.Count - 1].id);
        }

        private static void ShowListBooks()
        {
            Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");
            Console.WriteLine("|{0, -8}|{1, -30}|{2, -12}|{3, -12}|{4, -12}|{5, -30}|{6, -12}|", "N", "Customer name", "Order N", "Date R.", "Date C.", "Book title", "N books");
            Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");

            foreach (Orders ordersItem in orders)
            {
                Console.WriteLine("|{0, -8}|{1, -30}|{2, -12}|{3, -12}|{4, -12}|{5, -30}|{6, -12}|", user_num, ordersItem.customer.full_name_customers, ordersItem.order_number, ordersItem.date_of_receipt_order.ToShortDateString(), ordersItem.order_completion_date.ToShortDateString(), ordersItem.book.title, ordersItem.numbers_of_order);
                Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");
                user_num++;
            }
        }

        private static void Add()
        {
            Orders orderItem = new Orders();
            Console.Write("Enter number customers. ");
            orderItem.customer = TemplateInterface<Customers>.GetDataByNumber(TemplateHelpFunctions.EnterNumber(1, Repository.Instance.GetCount<Customers>()));
            Console.Write("Enter order number. ");
            orderItem.order_number = TemplateHelpFunctions.EnterNumber(10000000, 99999999);
            Console.Write("Enter date of receip. ");
            orderItem.date_of_receipt_order = TemplateHelpFunctions.EnterDateTime(1950, 2050);
            Console.Write("Enter complite date. ");
            orderItem.order_completion_date = TemplateHelpFunctions.EnterDateTime(1950, 2050);
            Console.Write("Enter number book. ");
            orderItem.book = TemplateInterface<Books>.GetDataByNumber(TemplateHelpFunctions.EnterNumber(1, Repository.Instance.GetCount<Books>()));
            Console.Write("Enter numbers of orders. ");
            orderItem.numbers_of_order = TemplateHelpFunctions.EnterNumber(1, 99999999);

            all_orders = Repository.Instance.GetCount<Orders>();
            if (Repository.Instance.GetCount<Books>() % BLOCK != 0)
                pages = (all_orders / BLOCK) + 1;
            else
                pages = all_orders / BLOCK;

            Repository.Instance.Create<Orders>(orderItem);
        }

        private static void Update()
        {
            bool end_update = false;
            int number = TemplateHelpFunctions.EnterNumber(1, all_orders);
            Orders ordersItem = new Orders();
            ordersItem = TemplateInterface<Orders>.GetDataByNumber(number - 1);
            Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");
            Console.WriteLine("|{0, -8}|{1, -30}|{2, -12}|{3, -12}|{4, -12}|{5, -30}|{6, -12}|", "N", "Customer name", "Order N", "Date R.", "Date C.", "Book title", "N books");
            Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");
            Console.WriteLine("|{0, -8}|{1, -30}|{2, -12}|{3, -12}|{4, -12}|{5, -30}|{6, -12}|", number, ordersItem.customer.full_name_customers, ordersItem.order_number, ordersItem.date_of_receipt_order.ToShortDateString(), ordersItem.order_completion_date.ToShortDateString(), ordersItem.book.title, ordersItem.numbers_of_order);
            Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");

            while (!end_update)
            {
                Console.WriteLine("Enter name parametr for update. Enter \'Exit\' for save update and exit");
                string parametr = Console.ReadLine();
                Console.Write("Enter new " + parametr + ": ");
                if (parametr == "Customer name")
                    ordersItem.customer = TemplateInterface<Customers>.GetDataByNumber(TemplateHelpFunctions.EnterNumber(1, Repository.Instance.GetCount<Customers>()));
                else if (parametr == "Order N")
                    ordersItem.order_number = TemplateHelpFunctions.EnterNumber(10000000, 99999999);
                else if (parametr == "Date R.")
                    ordersItem.date_of_receipt_order = TemplateHelpFunctions.EnterDateTime(1950, 2050);
                else if (parametr == "Date C.")
                    ordersItem.order_completion_date = TemplateHelpFunctions.EnterDateTime(1950, 2050);
                else if (parametr == "Book title")
                    ordersItem.book = TemplateInterface<Books>.GetDataByNumber(TemplateHelpFunctions.EnterNumber(1, Repository.Instance.GetCount<Books>()));
                else if (parametr == "N books")
                    ordersItem.numbers_of_order = TemplateHelpFunctions.EnterNumber(1, 99999999);
                else if (parametr == "Exit")
                {
                    end_update = true;
                    Repository.Instance.Update(ordersItem);
                }
                else
                    Console.WriteLine("Incorrect Value!");
            }
        }
        private static void Delete()
        {
            int number = TemplateHelpFunctions.EnterNumber(1, all_orders);
            Orders ordersItem = new Orders();
            ordersItem = TemplateInterface<Orders>.GetDataByNumber(number - 1);

            Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");
            Console.WriteLine("|{0, -8}|{1, -30}|{2, -12}|{3, -12}|{4, -12}|{5, -30}|{6, -12}|", "N", "Customer name", "Order N", "Date R.", "Date C.", "Book title", "N books");
            Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");
            Console.WriteLine("|{0, -8}|{1, -30}|{2, -12}|{3, -12}|{4, -12}|{5, -30}|{6, -12}|", number, ordersItem.customer.full_name_customers, ordersItem.order_number, ordersItem.date_of_receipt_order.ToShortDateString(), ordersItem.order_completion_date.ToShortDateString(), ordersItem.book.title, ordersItem.numbers_of_order);
            Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");

            Console.WriteLine("Delete this entry?[Yes/No]");
            string str = Console.ReadLine();
            if (str == "Yes")
            {
                Repository.Instance.Delete<Orders>(ordersItem);
                all_orders = Repository.Instance.GetCount<Orders>();
                if (Repository.Instance.GetCount<Orders>() % BLOCK != 0)
                    pages = (all_orders / BLOCK) + 1;
                else
                    pages = all_orders / BLOCK;
            }
            else if (str == "No") { }
            else
                Console.WriteLine("Incorrect value!");
        }

        private static void Search()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Write("[Search/Exit]: ");
                string action = Console.ReadLine();
                if (action == "Search")
                {
                    Console.Write("Enter text to search: ");
                    string str = Console.ReadLine();

                    str = TemplateHelpFunctions.UpdateStringForDateBase(str);

                    string Hql = $"from Orders as e where " +
                         (int.TryParse(str, out var _) ? $"e.order_number = {str} or " : "") +
                         (int.TryParse(str, out var _) ? $"e.numbers_of_order = {str} or " : "") +
                         (DateTime.TryParse(str, out var _) ? $"e.date_of_receipt_order = '{str}' or " : "") +
                         (DateTime.TryParse(str, out var _) ? $"e.order_completion_date = '{str}' or " : "") +
                         $" e.book.title like '%{str}%'" +
                         $" or e.cutomer.full_name_customer like '%{str}%'";

                    List<Orders> orders_tmp = TemplateInterface<Orders>.SearchDataByText(Hql, str);

                    user_num = 1;
                    Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");
                    Console.WriteLine("|{0, -8}|{1, -30}|{2, -12}|{3, -12}|{4, -12}|{5, -30}|{6, -12}|", "N", "Customer name", "Order N", "Date R.", "Date C.", "Book title", "N books");
                    Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");

                    foreach (Orders ordersItem in orders_tmp)
                    {
                        Console.WriteLine("|{0, -8}|{1, -30}|{2, -12}|{3, -12}|{4, -12}|{5, -30}|{6, -12}|", user_num, ordersItem.customer.full_name_customers, ordersItem.order_number, ordersItem.date_of_receipt_order.ToShortDateString(), ordersItem.order_completion_date.ToShortDateString(), ordersItem.book.title, ordersItem.numbers_of_order);
                        Console.WriteLine("+--------+------------------------------+------------+------------+------------+------------------------------+------------+");
                        user_num++;
                    }
                }
                else if (action == "Exit") { exit = true; }
                else
                    Console.WriteLine("Incorrect value!");
            }
        }
    }
}
