using System;
using System.Collections.Generic;
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
            while (true)
            {
                bool menu = true;
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
                            while (!int.TryParse(amountPizza, out int i))
                            {
                                Console.WriteLine("Please enter the amount of pizzas you want to order");
                                amountPizza = Console.ReadLine();
                            }
                            break;

                        case "2":
                            string amountChicken = "";
                            while (!int.TryParse(amountChicken, out int i))
                            {
                                Console.WriteLine("Please enter the amount of chicken you want to order");
                                amountChicken = Console.ReadLine();
                            }
                            break;

                        case "3":
                            Console.WriteLine("Please enter the amount of sandwiches you want to order");
                            Console.WriteLine("plezr 3");
                            break;

                        case "4":
                            Console.WriteLine("Please enter the amount of pastas you want to order");
                            break;

                        case "5":
                            Console.WriteLine("Please enter the amount of pizzas you want to order");
                            break;

                        case "6":
                            menu = false;
                            break;
                    }
                }
            }
        }

            public void DeleteOrde()
            {

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
