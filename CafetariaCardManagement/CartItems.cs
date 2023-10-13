using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public class CartItems
    {
        private static int s_id = 100;
        private string _itemId;
        public string ItemID
        {
            get
            {
                return _itemId;
            }
        }
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public double OrderPrice { get; set; }
        public int OrderQuantity { get; set; }
        public CartItems(string orderId, string foodId, double orderPrice, int orderQuantity)
        {
            s_id++;
            _itemId = "ITID" + s_id;
            OrderID = orderId;
            FoodID = foodId;
            OrderPrice = orderPrice;
            OrderQuantity = orderQuantity;
        }
        public  CartItems(string cart)
        {
            string[]cartItems=cart.Split(",");
             s_id=int.Parse(cartItems[0].Remove(0,4));
            _itemId = cartItems[0];
            OrderID = cartItems[1];
            FoodID = cartItems[2];
            OrderPrice =double.Parse( cartItems[3]);
            OrderQuantity = int.Parse( cartItems[4]);
        }
    }
}