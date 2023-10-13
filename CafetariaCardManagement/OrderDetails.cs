using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public enum Status { select, Initiated, Ordered, Cancelled }
    public class OrderDetails
    {
        private static int s_id = 1000;
        private string _orderId;
        public string OrderID
        {
            get
            {
                return _orderId;
            }
        }
        public string UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public Status Status { get; set; }
        public OrderDetails(string userId, DateTime orderDate, double totalPrice, Status status)
        {
            s_id++;
            _orderId = "OID" + s_id;
            UserID = userId;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            Status = status;
        }
        public OrderDetails(string order)
        {
            string[]orderDetails=order.Split(",");
            s_id=int.Parse(orderDetails[0].Remove(0,3));
            _orderId = orderDetails[0];
            UserID = orderDetails[1];
                OrderDate = DateTime.ParseExact(orderDetails[2],"dd/MM/yyyy",null);
            TotalPrice =double.Parse( orderDetails[3]);
            Status = Enum.Parse<Status>( orderDetails[4]);
        }
    }
}