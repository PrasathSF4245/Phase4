using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public class FoodDetails
    {
        private static int s_id = 100;
        private string _foodId;
        public string FoodID
        {
            get
            {
                return _foodId;
            }
        }
        public string FoodName { get; set; }
        public double FoodPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public FoodDetails(string foodName, double foodPrice, int availableQuantity)
        {
            s_id++;
            _foodId = "FID" + s_id;
            FoodName = foodName;
            FoodPrice = foodPrice;
            AvailableQuantity = availableQuantity;
        }
        public FoodDetails(string food)
        {
            string[]foodDetails=food.Split(",");
             s_id=int.Parse(foodDetails[0].Remove(0,3));
            _foodId = foodDetails[0];
            FoodName = foodDetails[1];
            FoodPrice = double.Parse(foodDetails[2]);
            AvailableQuantity = int.Parse(foodDetails[3]);


        }
    }
}