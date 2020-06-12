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


        public void ReadOrder()
        {
            while (true)
            {
                bool isIn = false;
                //number input
                Console.WriteLine("Enter order number for order you want to display? ");

                int orderNumber;
                bool tryHowMany = Int32.TryParse(Console.ReadLine(), out orderNumber);
                while (!tryHowMany || orderNumber < 1)
                {
                    Console.WriteLine("Incorrect input, please try again:");
                    tryHowMany = Int32.TryParse(Console.ReadLine(), out orderNumber);
                }
                //from table to list
                List<tblOrder> listOfOrders = context.tblOrders.ToList();
                tblMenu menu = new tblMenu();
                //looking for user
                for (int i = 0; i < listOfOrders.Count; i++)
                {
                    if (listOfOrders[i].OrderNumber == orderNumber)
                    {
                        tblOrder viaOrder = listOfOrders[i];
                        menu = context.tblMenus.Where(x => x.MenuID == viaOrder.MenuID).Select(x => x).First();
                        isIn = true;
                        //displaiying user
                        Console.WriteLine("\nOrder date:{0}\nOrder number:{1}\nPizza number:{2}\nChicken number:{3}\nPasta number:{4}\nSoup number:{5}\nSandwich number:{6}\n", listOfOrders[i].OrderTime, listOfOrders[i].OrderNumber, menu.Pizza, menu.Chicken, menu.Pasta, menu.Soup, menu.Sandwich);
                        break;
                    }
                }
                Console.WriteLine("If you want to exit press ~ or any other key to continue");
                if (Console.ReadLine() == "~")
                {
                    break;
                }
                //in case there is no selected user
                if (isIn == false)
                {
                    Console.WriteLine("There is no such order with inputed order number.\n");
                    break;
                }
            }
        }

        public void ReadAllOrders()
        {
            List<tblOrder> listOrder = context.tblOrders.ToList();
            List<tblMenu> listMenu = context.tblMenus.ToList();
            if (listOrder.Count < 1)
            {
                Console.WriteLine("\nThere are no orders.\n");
            }
            else
            {
                for (int i = 0; i < listOrder.Count; i++)
                {
                    tblOrder viaOrder = listOrder[i];
                    tblMenu viaMenu = context.tblMenus.Where(x => x.MenuID == viaOrder.MenuID).Select(x => x).First();
                    Console.WriteLine("\nOrder date:{0}\nOrder number:{1}\nPizza number:{2}\nChicken number:{3}\nPasta number:{4}\nSoup number:{5}\nSandwich number:{6}\n", viaOrder.OrderTime, viaOrder.OrderNumber, viaMenu.Pizza, viaMenu.Chicken, viaMenu.Pasta, viaMenu.Soup, viaMenu.Sandwich);
                }
            }
        }

        public void UpdateOrder()
        {
            while (true)
            {
                bool isIn = false;
                Console.WriteLine("Enter order number for order you want to update:");
                int orderNumber;
                bool tryHowMany = Int32.TryParse(Console.ReadLine(), out orderNumber);
                while (!tryHowMany || orderNumber < 1)
                {
                    Console.WriteLine("Incorrect input, please try again:");
                    tryHowMany = Int32.TryParse(Console.ReadLine(), out orderNumber);
                }
                //Putting numbers from table to list
                List<tblOrder> listOfOrders = context.tblOrders.ToList();

                //looking for number in list
                for (int i = 0; i < listOfOrders.Count; i++)
                {
                    // in case that number exists
                    if (listOfOrders[i].OrderNumber == orderNumber)
                    {
                        tblOrder viaOrder = listOfOrders[i];
                        tblMenu viaMenu = context.tblMenus.Where(x => x.MenuID == viaOrder.MenuID).Select(x => x).First();
                        isIn = true;
                        Console.WriteLine("\nOrder date:{0}\nOrder number:{1}\nPizza number:{2}\nChicken number:{3}\nPasta number:{4}\nSoup number:{5}\nSandwich number:{6}\n", viaOrder.OrderTime, viaOrder.OrderNumber, viaMenu.Pizza, viaMenu.Chicken, viaMenu.Pasta, viaMenu.Soup, viaMenu.Sandwich);

                    }
                }
                //if number does not exists
                if (isIn == false)
                {
                    Console.WriteLine("There is no such order with inputed number.\n");
                    break;
                }
                else
                {
                    //finding user to update and updating chosen field
                    tblOrder viaOrder = context.tblOrders.FirstOrDefault(x => x.OrderNumber == orderNumber);
                    tblMenu viaMenu = context.tblMenus.FirstOrDefault(x => x.MenuID == viaOrder.MenuID);
                    bool spin = true;
                    while (spin == true)
                    {
                        Console.WriteLine("\nWhat do you want to update?\n");
                        Console.WriteLine("1: Pizza");
                        Console.WriteLine("2: Chicken");
                        Console.WriteLine("3: Sandwich");
                        Console.WriteLine("4: Pasta");
                        Console.WriteLine("5: Soup");
                        Console.WriteLine("6: Exit\n");

                        string pick = Console.ReadLine();

                        switch (pick)
                        {
                            case "1":
                                Console.WriteLine("Enter new pizza amount:");
                                int pizzaNumber;
                                bool tryPizza = Int32.TryParse(Console.ReadLine(), out pizzaNumber);
                                while (!tryPizza || pizzaNumber < 0)
                                {
                                    Console.WriteLine("Incorrect input, please try again:");
                                    tryPizza = Int32.TryParse(Console.ReadLine(), out pizzaNumber);
                                }
                                viaMenu.Pizza = pizzaNumber;
                                viaOrder.OrderTime = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                context.SaveChanges();
                                Console.WriteLine("Pizza number is updated.\n");
                                break;
                            case "2":
                                Console.WriteLine("Enter new chicken amount:");
                                int chickenNumber;
                                bool tryChicken = Int32.TryParse(Console.ReadLine(), out chickenNumber);
                                while (!tryChicken || chickenNumber < 0)
                                {
                                    Console.WriteLine("Incorrect input, please try again:");
                                    tryChicken = Int32.TryParse(Console.ReadLine(), out chickenNumber);
                                }
                                viaMenu.Chicken = chickenNumber;
                                viaOrder.OrderTime = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                context.SaveChanges();
                                Console.WriteLine("Chicken number is updated.\n");
                                break;
                            case "3":
                                Console.WriteLine("Enter new sandwich amount:");
                                int sandwichNumber;
                                bool trySandwich = Int32.TryParse(Console.ReadLine(), out sandwichNumber);
                                while (!trySandwich || sandwichNumber < 0)
                                {
                                    Console.WriteLine("Incorrect input, please try again:");
                                    trySandwich = Int32.TryParse(Console.ReadLine(), out sandwichNumber);
                                }
                                viaMenu.Sandwich = sandwichNumber;
                                viaOrder.OrderTime = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                context.SaveChanges();
                                Console.WriteLine("Sandwich number is updated.\n");
                                break;
                            case "4":
                                Console.WriteLine("Enter new pasta amount:");
                                int pastaNumber;
                                bool tryPasta = Int32.TryParse(Console.ReadLine(), out pastaNumber);
                                while (!tryPasta || pastaNumber < 0)
                                {
                                    Console.WriteLine("Incorrect input, please try again:");
                                    tryPasta = Int32.TryParse(Console.ReadLine(), out pastaNumber);
                                }
                                viaMenu.Pasta = pastaNumber;
                                viaOrder.OrderTime = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                context.SaveChanges();
                                Console.WriteLine("Pasta number is updated.\n");
                                break;
                            case "5":
                                Console.WriteLine("Enter new soup amount:");
                                int soupNumber;
                                bool trySoup = Int32.TryParse(Console.ReadLine(), out soupNumber);
                                while (!trySoup || soupNumber < 0)
                                {
                                    Console.WriteLine("Incorrect input, please try again:");
                                    trySoup = Int32.TryParse(Console.ReadLine(), out soupNumber);
                                }
                                viaMenu.Soup = soupNumber;
                                viaOrder.OrderTime = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                context.SaveChanges();
                                Console.WriteLine("Soup number is updated.\n");
                                break;
                            case "6":
                                spin = false;
                                break;
                            default:
                                Console.WriteLine("Wrong input.");
                                break;

                        }
                    }
                    break;
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

        }
    }

