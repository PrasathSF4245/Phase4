using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public class FileHaandling
    {
        public static void Create()
        {
            //Folder is created 
            if (!Directory.Exists("CafetariaDatabase"))
            {
                System.Console.WriteLine("Folder is created");
                Directory.CreateDirectory("CafetariaDatabase");
            }
            //Message is displayed if folder is created
            else
            {
                System.Console.WriteLine("Folder already Exist");
            }

              //File is created 
            if (!File.Exists("CafetariaDatabase/CartItems.csv"))
            {
                System.Console.WriteLine("file is created");
                File.Create("CafetariaDatabase/CartItems.csv").Close();
            }
             //Message is displayed if File is created
            else
            {
                System.Console.WriteLine("file already Exist");
            }
             //File is created 

            if (!File.Exists("CafetariaDatabase/FoodDetails.csv"))
            {
                System.Console.WriteLine("file is created");
                File.Create("CafetariaDatabase/FoodDetails.csv").Close();
            }
             //Message is displayed if File is created
            else
            {
                System.Console.WriteLine("file already Exist");
            }
             //File is created 
            if (!File.Exists("CafetariaDatabase/OrderDetails.csv"))
            {
                System.Console.WriteLine("file is created");
                File.Create("CafetariaDatabase/OrderDetails.csv").Close();
            }
             //Message is displayed if File is created
            else
            {
                System.Console.WriteLine("file already Exist");
            }
             //File is created 
            if (!File.Exists("CafetariaDatabase/UserDetails.csv"))
            {
                System.Console.WriteLine("file is created");
                File.Create("CafetariaDatabase/UserDetails.csv").Close();
            }
             //Message is displayed if File is created
            else
            {
                System.Console.WriteLine("file already Exist");
            }
        }

        //Write the data to file 
        public static void WritetoCSV()
        {

            string[] CartItems = new string[Application.cartlist.Count];
            for (int i = 0; i < Application.cartlist.Count; i++)
            {
                CartItems[i] = $"{Application.cartlist[i].ItemID},{Application.cartlist[i].OrderID},{Application.cartlist[i].FoodID},{Application.cartlist[i].OrderPrice},{Application.cartlist[i].OrderQuantity}";
            }
            File.WriteAllLines("CafetariaDatabase/CartItems.csv", CartItems);


            string[] FoodDetails = new string[Application.foodList.Count];
            for (int i = 0; i < Application.foodList.Count; i++)
            {
                FoodDetails[i] = $"{Application.foodList[i].FoodID},{Application.foodList[i].FoodName},{Application.foodList[i].FoodPrice},{Application.foodList[i].AvailableQuantity}";
            }
            File.WriteAllLines("CafetariaDatabase/FoodDetails.csv", FoodDetails);


            string[] OrderDetails = new string[Application.orderList.Count];
            for (int i = 0; i < Application.orderList.Count; i++)
            {
                OrderDetails[i] = $"{Application.orderList[i].OrderID},{Application.orderList[i].UserID},{Application.orderList[i].OrderDate.ToString("dd/MM/yyyy")},{Application.orderList[i].TotalPrice},{Application.orderList[i].Status}";
            }
            File.WriteAllLines("CafetariaDatabase/OrderDetails.csv", OrderDetails);


            string[] UserDetails = new string[Application.userList.Count];

            for (int i = 0; i < Application.userList.Count; i++)
            {
                UserDetails[i] = $"{Application.userList[i].UserID},{Application.userList[i].Name},{Application.userList[i].FatherName},{Application.userList[i].Mobile},{Application.userList[i].MailID},{Application.userList[i].Gender},{Application.userList[i].WorkStationNumber},{Application.userList[i].WalletBalance}";
            }
            File.WriteAllLines("CafetariaDatabase/UserDetails.csv", UserDetails);
        }

        //Read the data from file
        public static void ReadFromCSV()
        {
            string[] UserDetails = File.ReadAllLines("CafetariaDatabase/UserDetails.csv");
            foreach (string user in UserDetails)
            {
                UserDetails newUser = new UserDetails(user);
                Application.userList.Add(newUser);
            }
            string[] OrderDetails = File.ReadAllLines("CafetariaDatabase/OrderDetails.csv");
            foreach (string order in OrderDetails)
            {
                OrderDetails newOrder = new OrderDetails(order);
                Application.orderList.Add(newOrder);
            }
            string[] FoodDetails = File.ReadAllLines("CafetariaDatabase/FoodDetails.csv");
            foreach (string food in FoodDetails)
            {
                FoodDetails newFood = new FoodDetails(food);
                Application.foodList.Add(newFood);
            }
            string[] CartItems = File.ReadAllLines("CafetariaDatabase/CartItems.csv");
            foreach (string cart in CartItems)
            {
                CartItems newCart = new CartItems(cart);

                Application.cartlist.Add(newCart);
            }


        }
    }
}