using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Model;

namespace RestaurantApp
{
    class RestaurantCRUD
    {
        RestaurantMiticPrposEntities context = new RestaurantMiticPrposEntities();

        public void CreateOrder()
        {
            bool a = true;
            while (a)
            {
                bool menu = true;

                int piz = 0;
                int pas = 0;
                int chi = 0;
                int san = 0;
                int sou = 0;

                tblMenu chosen = new tblMenu();
                tblOrder order = new tblOrder();

                while (menu)
                {
                    Console.WriteLine("Plese choose your meal:\n");
                    Console.WriteLine("1. Pizza");
                    Console.WriteLine("2. Chicken");
                    Console.WriteLine("3. Sandwich");
                    Console.WriteLine("4. Pasta");
                    Console.WriteLine("5. Soup");
                    Console.WriteLine("6. Order");
                    Console.WriteLine("7. Give Up");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            string amountPizza = "";
                            while (!int.TryParse(amountPizza, out piz))
                            {
                                Console.WriteLine("Please enter the amount of pizzas you want to order");
                                amountPizza = Console.ReadLine();
                                if (!int.TryParse(amountPizza, out piz))
                                {
                                    Console.WriteLine("Please enter only number.");
                                }
                            }
                            break;

                        case "2":
                            string amountChicken = "";
                            while (!int.TryParse(amountChicken, out chi))
                            {
                                Console.WriteLine("Please enter the amount of chicken you want to order");
                                amountChicken = Console.ReadLine();
                                if (!int.TryParse(amountChicken, out chi))
                                {
                                    Console.WriteLine("Please enter only number.");
                                }
                            }
                            break;

                        case "3":
                            string amountSandwich = "";
                            while (!int.TryParse(amountSandwich, out san))
                            {
                                Console.WriteLine("Please enter the amount of sandwiches you want to order");
                                amountSandwich = Console.ReadLine();
                                if (!int.TryParse(amountSandwich, out san))
                                {
                                    Console.WriteLine("Please enter only number.");
                                }
                            }
                            break;

                        case "4":
                            string amountPasta = "";
                            while (!int.TryParse(amountPasta, out pas))
                            {
                                Console.WriteLine("Please enter the amount of pastas you want to order");
                                amountPasta = Console.ReadLine();
                                if (!int.TryParse(amountPasta, out pas))
                                {
                                    Console.WriteLine("Please enter only number.");
                                }
                            }
                            break;

                        case "5":
                            string amountSoup = "";
                            while (!int.TryParse(amountSoup, out sou))
                            {
                                Console.WriteLine("Please enter the amount of soups you want to order");
                                amountSoup = Console.ReadLine();
                                if (!int.TryParse(amountSoup, out sou))
                                {
                                    Console.WriteLine("Please enter only number.");
                                }
                            }
                            break;

                        case "6":
                            menu = false;
                            Random random = new Random();
                            chosen.Pizza = piz;
                            chosen.Chicken = chi;
                            chosen.Sandwich = san;
                            chosen.Pasta = pas;
                            chosen.Soup = sou;
                            context.tblMenus.Add(chosen);
                            context.SaveChanges();

                            order.MenuID = chosen.MenuID;
                            order.OrderTime = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            order.OrderNumber = random.Next(1000, 9999);
                            context.tblOrders.Add(order);
                            context.SaveChanges();

                            Console.WriteLine("\nYour order number is {0}", order.OrderNumber);
                            break;

                        case "7":
                            menu = false;
                            a = false;
                            break;
                    }
                }
             
            }
        }

        public void DeleteOrder()
        {
            Console.WriteLine("\nPlease enter the number of an order you want to delete");
            string d = Console.ReadLine();
            int orderNumberToDelete;

            try
            {
            int.TryParse(d, out orderNumberToDelete);
            tblOrder orderToDelete = context.tblOrders.Where(x => x.OrderNumber == orderNumberToDelete).Select(x => x).FirstOrDefault();
            context.tblOrders.Remove(orderToDelete);

            tblMenu menuToDelete = context.tblMenus.Where(x => x.MenuID == orderToDelete.MenuID).Select(x => x).FirstOrDefault();
            context.tblMenus.Remove(menuToDelete);
            context.SaveChanges();

                Console.WriteLine("\nOrder delete succesfull.\n");
            }
            catch 
            {
                Console.WriteLine("\nOrder delete not succesfull. Order with a number you have just entered does not exist.\n");
            }
           
        }

        public void ReadOrder()
        {

        }

        public void ReadAllOrders()
        {

        }

        public void UpdateOrder()
        {

        }
    }
}
