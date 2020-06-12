using RestaurantApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Model;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantCRUD crud = new RestaurantCRUD();
            bool spin = true;

            while (spin == true)
            {
                Console.WriteLine("\tWELCOME\n");
                Console.WriteLine("1. Create order:");
                Console.WriteLine("2. Read order:");
                Console.WriteLine("3. Read all orders:");
                Console.WriteLine("4. Update:");
                Console.WriteLine("5. Delete:");
                Console.WriteLine("6. Exit:");

                string pick = Console.ReadLine();
                RestaurantCRUD restaurant = new RestaurantCRUD();

                switch (pick)
                {
                    case "1":
                        restaurant.CreateOrder();
                        break;
                    case "2":    
                        crud.ReadOrder();
                        break;
                    case "3":
                        crud.ReadAllOrders();
                        break;
                    case "4":
                        crud.UpdateOrder();
                        break;
                    case "5":
                        restaurant.DeleteOrder();
                        break;
                    case "6":
                        spin = false;
                        break;
                    default:
                        Console.WriteLine("Please select one of the proposed options:");
                        break;
                }
            }
        }
    }
}
