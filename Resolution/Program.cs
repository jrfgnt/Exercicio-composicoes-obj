using Resolution.Entities;
using Resolution.Entities.Enums;
using System.Globalization; 

namespace Resolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture; 



            Console.WriteLine("Enter cliente data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email:");
            string mail = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY):");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, mail, date);
         

            Console.WriteLine("Enter order data:");
            Console.Write("Status:");
            string status = Console.ReadLine();
            Console.WriteLine("How many items to this order? ");
            int nItems = int.Parse(Console.ReadLine());

            OrderStatus os = Enum.Parse<OrderStatus>(status);

            Order order = new Order(DateTime.Now, os, client);

            for (int i =1; i<=nItems; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name:");
                string productName = Console.ReadLine();
                Console.Write("Product price:");
                double productPrice = double.Parse(Console.ReadLine(), CI);
                Console.Write("Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                Product prod = new Product(productName, productPrice);

                OrderItem orderItem = new OrderItem(quantity, productPrice, prod);

                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);




        }
    }
}