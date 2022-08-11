using Resolution.Entities.Enums;
using System.Text;
using System.Globalization; 

namespace Resolution.Entities
{
    internal class Order
    {
        CultureInfo CI = CultureInfo.InvariantCulture; 



        public DateTime Moment { get; set; }

        public  OrderStatus Status { get; set; }

        public Client Client { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem (OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem (OrderItem item)
        {
            Items.Remove(item); 
        }

        public double Total()
        {
            double sum = 0.0; 
            foreach(OrderItem item in Items)
            {
                sum += item.SubTotal();
            }

            return sum; 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment:" + Moment.ToString("dd/MM/yyyy HH:MM:ss"));
            sb.AppendLine("Order status:" + Status);
            sb.AppendLine("Client:" + Client);
            sb.AppendLine("Order items:"); 
            foreach(OrderItem order in Items)
            {
                sb.AppendLine(order.ToString());
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CI));

            return sb.ToString(); 


        }


    }
}
