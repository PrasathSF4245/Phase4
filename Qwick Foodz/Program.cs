using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
namespace QwickFoodz;

class Program
{
    public static List<CustomerDetails> CustomerDetailsList = new List<CustomerDetails>();

    public static List<FoodDetails> FoodDetailsList = new List<FoodDetails>();

    public static List<OrderDetails> OrderDetailsList = new List<OrderDetails>();

    public static List<ItemDetails> ItemDetailsList = new List<ItemDetails>();

    public static CustomerDetails CurrentCustomer;
    public static void Main(string[] args)
    {
        AddDetails();
        System.Console.WriteLine("Welcome to Qwick Foodz");
        System.Console.WriteLine("Main Menu");
        bool checkMainMenu = false;
        do
        {
            System.Console.WriteLine(" 1.CustomerRegistration\n2.CustomerLogin\n3.Exit");
            checkMainMenu = int.TryParse(Console.ReadLine(), out int mainMenuChoice);
            switch (mainMenuChoice)
            {
                case 1:
                    {
                        CustomerRegistration();
                        checkMainMenu = false;
                        break;
                    }
                case 2:
                    {
                        CustomerLogin();
                        checkMainMenu = false;
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                default:
                    {
                        checkMainMenu = false;
                        break;
                    }
            }
        } while (!checkMainMenu);

    }

    public static void AddDetails()
    {

        ItemDetailsList.Add(new ItemDetails("OID3001", "FID101", 2, 200));
        ItemDetailsList.Add(new ItemDetails("OID3001", "FID102", 2, 300));
        ItemDetailsList.Add(new ItemDetails("OID3001", "FID103", 1, 80));
        ItemDetailsList.Add(new ItemDetails("OID3002", "FID101", 1, 100));
        ItemDetailsList.Add(new ItemDetails("OID3002", "FID102", 4, 600));
        ItemDetailsList.Add(new ItemDetails("OID3002", "FID110", 1, 120));
        ItemDetailsList.Add(new ItemDetails("OID3002", "FID109", 1, 50));
        ItemDetailsList.Add(new ItemDetails("OID3003", "FID102", 2, 300));
        ItemDetailsList.Add(new ItemDetails("OID3003", "FID108", 4, 320));
        ItemDetailsList.Add(new ItemDetails("OID3003", "FID101", 2, 200));

        OrderDetailsList.Add(new OrderDetails("CID1001", 580, new DateTime(2022, 11, 26), OrderStatus.Ordered));

        OrderDetailsList.Add(new OrderDetails("CID1002", 870, new DateTime(2022, 11, 26), OrderStatus.Ordered));

        OrderDetailsList.Add(new OrderDetails("CID1001", 820, new DateTime(2022, 11, 26), OrderStatus.Cancelled));

        FoodDetailsList.Add(new FoodDetails("Chicken Briyani 1Kg", 100, 12));

        FoodDetailsList.Add(new FoodDetails("Mutton Briyani 1Kg", 150, 10));

        FoodDetailsList.Add(new FoodDetails("Veg Full Meals", 80, 30));

        FoodDetailsList.Add(new FoodDetails("Noodles", 100, 40));

        FoodDetailsList.Add(new FoodDetails("Dosa", 40, 40));

        FoodDetailsList.Add(new FoodDetails("Idly (2 pieces)", 20, 50));

        FoodDetailsList.Add(new FoodDetails("Pongal", 40, 20));

        FoodDetailsList.Add(new FoodDetails("Vegetable Briyani", 80, 15));

        FoodDetailsList.Add(new FoodDetails("Lemon Rice	", 50, 30));

        FoodDetailsList.Add(new FoodDetails("Veg Pulav", 120, 30));

        FoodDetailsList.Add(new FoodDetails("Cicken 65 (200 Grams)", 75, 30));




        CustomerDetailsList.Add(new CustomerDetails("Ravi", "Ravi", Gender.Male, 974774646, new DateTime(1999, 11, 11), "ravi@gmail.com", "Chennai", 1000));
        CustomerDetailsList.Add(new CustomerDetails("Baskaran", "Sethurajan", Gender.Male, 847575775, new DateTime(1999, 11, 11), "baskaran@gmail.com", "Chennai", 1500));
    }
    public static void CustomerRegistration()
    {


        System.Console.WriteLine("Enter your Name ");
        string name = Console.ReadLine();

        System.Console.WriteLine("Enter your FatherName ");
        string fatherName = Console.ReadLine();

        bool checkGensder = false;
        System.Console.WriteLine("Enter your Gender {Select, Male, Female, Transgender}");
        checkGensder = Enum.TryParse<Gender>(Console.ReadLine(), true, out Gender gender);

        System.Console.WriteLine("Enter your Mobile Number");
        long mobile = long.Parse(Console.ReadLine());

        bool checkDate = false;
        System.Console.WriteLine("Enter your DOB");
        checkDate = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dob);

        System.Console.WriteLine("Enter your MailID");
        string mailID = Console.ReadLine();

        System.Console.WriteLine("Enter your loction");
        string loction = Console.ReadLine();

        // System.Console.WriteLine("Enter your balance");
        // double amoumnt = double.Parse(Console.ReadLine());


        CustomerDetails newCustomer = new CustomerDetails(name, fatherName, gender, mobile, dob, mailID, loction);

        CustomerDetailsList.Add(newCustomer);

        System.Console.WriteLine("Customer registration successful Your Customer ID : " + newCustomer.CustomerID);

    }

    public static void CustomerLogin()
    {
        bool checKCustomer = false;
        do
        {
            System.Console.WriteLine("Enter Your Customer iD");
            string customerID = Console.ReadLine().ToUpper();
            foreach (CustomerDetails customer in CustomerDetailsList)
            {
                if (customerID == customer.CustomerID)
                {
                    checKCustomer = true;
                    CurrentCustomer = customer;
                    break;
                }
            }
            if (!checKCustomer)
            {
                System.Console.WriteLine("Invalid Customer ID");
            }

        } while (!checKCustomer);
        if (checKCustomer)
        {
            System.Console.WriteLine("Login SuccessFull");
            System.Console.WriteLine("Sub Menu");
            bool checkSubMenu = false;
            do
            {
                System.Console.WriteLine();

                System.Console.WriteLine("1. Show Profile\n2.  Order Food\n3 . Cancel Order\n4.  Modify Order\n5.Order History\n6. Recharge Wallet \n7.  Show Wallet Balance\n8.  Exit");
                System.Console.WriteLine();
                //checkSubMenu=char.TryParse(Console.ReadLine(),out char submenuChoice);
                checkSubMenu = int.TryParse(Console.ReadLine(), out int submenuChoice);
                switch (submenuChoice)
                {
                    case 1:
                        {
                            ShowProfile();
                            checkSubMenu = false;
                            break;
                        }
                    case 2:
                        {
                            OrderFood();
                            checkSubMenu = false;
                            break;
                        }
                    case 3:
                        {
                            CancelOrder();
                            checkSubMenu = false;
                            break;
                        }
                    case 4:
                        {
                            ModifyOrder();
                            checkSubMenu = false;
                            break;
                        }
                    case 5:
                        {
                            OrderHistory();

                            checkSubMenu = false;
                            break;
                        }
                    case 6:
                        {
                            RechargeWallet();
                            checkSubMenu = false;
                            break;
                        }
                    case 7:
                        {
                            ShowWalletBalance();
                            checkSubMenu = false;
                            break;
                        }
                    case 8:
                        {
                            break;
                        }
                    default:
                        {
                            System.Console.WriteLine();
                            System.Console.WriteLine("Invalid selection");
                            System.Console.WriteLine();
                            checkSubMenu = false;
                            break;
                        }
                }

            } while (!checkSubMenu);

        }
    }

    public static void ShowProfile()
    {
        System.Console.WriteLine($"CustomerID     : {CurrentCustomer.CustomerID}");
        System.Console.WriteLine($"Name           : {CurrentCustomer.Name}");
        System.Console.WriteLine($"FatherName     : {CurrentCustomer.FatherName}");
        System.Console.WriteLine($"MailID         : {CurrentCustomer.MailID}");
        System.Console.WriteLine($"Mobile         : {CurrentCustomer.Mobile}");
        System.Console.WriteLine($"WalletBalance  : {CurrentCustomer.WalletBalance}");

    }

    public static void ShowWalletBalance()
    {
        System.Console.WriteLine($"Your Wallet Balance : {CurrentCustomer.WalletBalance} ");
    }

    public static void RechargeWallet()
    {
        System.Console.WriteLine("Enter the Amoumnt to be Added");
        //double am
        bool checkAmmount = double.TryParse(Console.ReadLine(), out double amoumnt);
        CurrentCustomer.WalletRecharge(amoumnt);
        System.Console.WriteLine($"Your Wallet Balance : {CurrentCustomer.WalletBalance} ");
    }

    public static void OrderHistory()
    {
        bool checkEntries = false;
        foreach (OrderDetails order in OrderDetailsList)
        {
            if (CurrentCustomer.CustomerID == order.CustomerID)
            {
                checkEntries = true;
                System.Console.WriteLine();
                System.Console.WriteLine($"OrderID      : {order.OrderID}");
                System.Console.WriteLine($"DateOfOrder  : {order.DateOfOrder}");
                System.Console.WriteLine($"Status       : {order.Status}");
                System.Console.WriteLine($"TotalPrice   : {order.TotalPrice}");
                System.Console.WriteLine();
            }
        }
        if (!checkEntries)
        {
            System.Console.WriteLine("No Record Found");
        }
    }

    public static void CancelOrder()
    {
        bool checkEntries = false;
        /*a.	Show the list of orders placed by current logged in user whose status is “Ordered”.
b.	Ask the user to pick an order to be cancelled by OrderID.
c.	If OrderID is present, then change the order status to “Cancelled”. Refund the total price amount of current order to user’s WalletBalance then return the food items of the current order to FoodList. 
*/
        foreach (OrderDetails order in OrderDetailsList)
        {
            if (CurrentCustomer.CustomerID == order.CustomerID)
            {
                System.Console.WriteLine();
                System.Console.WriteLine($"OrderID      : {order.OrderID}");
                System.Console.WriteLine($"DateOfOrder  : {order.DateOfOrder}");
                System.Console.WriteLine($"Status       : {order.Status}");
                System.Console.WriteLine($"TotalPrice   : {order.TotalPrice}");
                System.Console.WriteLine();
            }
        }
        bool checkOrderid = false;
        string orderid;
        do
        {
            System.Console.WriteLine("Enter the order id to cancel");
            orderid = Console.ReadLine().ToUpper();
            foreach (OrderDetails order in OrderDetailsList)
            {
                if (orderid == order.OrderID && OrderStatus.Ordered == order.Status)
                {
                    checkOrderid = true;
                    checkEntries = true;
                    order.Status = OrderStatus.Cancelled;
                    CurrentCustomer.WalletRecharge(order.TotalPrice);
                    break;
                }
            }
            if (!checkOrderid)
            {
                System.Console.WriteLine("Invalid order id");
            }

        } while (!checkOrderid);
        if (checkOrderid)
        {
            foreach (ItemDetails item in ItemDetailsList)
            {
                if (item.OrderID == orderid)
                {
                    foreach (FoodDetails food in FoodDetailsList)
                    {
                        if (item.FoodID == food.FoodID)
                        {
                            food.QuantityAvailable += item.PurchaseCount;
                            break;


                        }

                    }
                }
            }
        }
        if (!checkEntries)
        {
            System.Console.WriteLine("No Record Found");
        }
    }


    public static void OrderFood()
    {

        OrderDetails newOrder = new OrderDetails(CurrentCustomer.CustomerID, 0, DateTime.Now, OrderStatus.Initiated);
        // Now.DateTimeToString("dd/MM/yyyy")Create OrderDetails object with CustomerID, TotalPrice = 0, DateOfOrder as today and OrderStatus = Initiated.

        //Create localItemList for adding your wishlist.
        List<ItemDetails> localItemList = new List<ItemDetails>();

        // Show all the list of food items available in store for processing the order.
        foreach (FoodDetails food in FoodDetailsList)
        {
            System.Console.WriteLine();
            System.Console.Write($" FoodID : {food.FoodID} ");
            System.Console.Write($" FoodName : {food.FoodName} ");
            System.Console.Write($" PricePerQuantity : {food.PricePerQuantity} ");
            System.Console.Write($" QuantityAvailable : {food.QuantityAvailable}");
            System.Console.WriteLine();
        }
        //Ask the FoodID, order quantity from user and check whether it is available. If not show FoodID Invalid or FoodQuantity unavailable based on the scenario. 
        bool checkFoodid = false;
        FoodDetails currentfood;
        bool checkCount = false;
        double totalPrice = 0;
        string foodid;
        string ans;
        string anspurchase;
        string ansRecharge;
        int count;
        do
        {
            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Enter the food id");
                foodid = Console.ReadLine().ToUpper();
                System.Console.WriteLine();
                System.Console.WriteLine("Enter count needed");
                checkCount = int.TryParse(Console.ReadLine(), out count);
                System.Console.WriteLine();
                checkCount = false;

                foreach (FoodDetails food in FoodDetailsList)
                {
                    if (food.FoodID == foodid)
                    {
                        checkFoodid = true;
                        if (food.QuantityAvailable >= count)
                        {
                            checkCount = true;
                            food.QuantityAvailable -= count;
                            ItemDetails newItem = new ItemDetails(newOrder.OrderID, foodid, count, count * food.PricePerQuantity);
                            localItemList.Add(newItem);
                            currentfood = food;
                            totalPrice += count * food.PricePerQuantity;
                            break;
                        }
                    }
                }
                if (!checkFoodid)
                {
                    System.Console.WriteLine("Invalid food id");
                }
                if (!checkCount)
                {
                    System.Console.WriteLine("Invalid food count");
                }

            } while (!checkFoodid || !checkCount);
            System.Console.WriteLine("Do you Want to continue yes or no");
            ans = Console.ReadLine().ToLower();
            while (ans != "yes" && ans != "no")
            {
                System.Console.WriteLine("Please enter correct option");
                System.Console.WriteLine("Do you Want to continue yes or no");
                ans = Console.ReadLine().ToLower();
            }

        } while (ans == "yes");
        if (ans == "no")
        {
            //If user select “No” then show “Do you want to confirm purchase.” If he says “No” return the localItemList of items count back to FoodDetails list.
            System.Console.WriteLine("Do you Want to confirm purchase yes or no");
            anspurchase = Console.ReadLine().ToLower();
            while (anspurchase != "yes" && anspurchase != "no")
            {
                System.Console.WriteLine("Please enter correct option");
                System.Console.WriteLine("Do you Want to confirm purchase yes or no");
                anspurchase = Console.ReadLine().ToLower();
            }


            if (anspurchase == "yes")
            {
                bool checkamoumnt = false;
                if (CurrentCustomer.WalletBalance >= totalPrice)
                {
                    //	Check whether the customer wallet has sufficient balance.
                    // j.	 If he has balance then, modify OrderDetails object which was created at beginning with TotalPrice and OrderStatus to “Ordered”. Deduct the total amount from user’s wallet balance. Add the localItemList to ItemList. 
                    newOrder.Status = OrderStatus.Ordered;
                    newOrder.TotalPrice = totalPrice;
                    // currentfood.QuantityAvailable-=count;
                    CurrentCustomer.DeductBalance(totalPrice);
                    ItemDetailsList.AddRange(localItemList);
                    OrderDetailsList.Add(newOrder);
                    System.Console.WriteLine("Your order is successfull Your order ID" + newOrder.OrderID);
                }

                else
                {
                    double ammountneeded = totalPrice - CurrentCustomer.WalletBalance;
                    System.Console.WriteLine("Insuffient balance Ammoumnt Required " + ammountneeded);
                    System.Console.WriteLine("Do you want to recharge  yes or no");

                    ansRecharge = Console.ReadLine().ToLower();
                    while (ansRecharge != "yes" && ansRecharge != "no")
                    {
                        System.Console.WriteLine("Please enter correct option");
                        System.Console.WriteLine("Do you Want to confirm purchase yes or no");
                        ansRecharge = Console.ReadLine().ToLower();
                    }
                    double amoumnt = 0;

                    if (ansRecharge == "yes")
                    {
                        do
                        {
                            System.Console.WriteLine("Enter the amounmnt to be added  ");
                            checkamoumnt = double.TryParse(Console.ReadLine(), out amoumnt);
                            CurrentCustomer.WalletRecharge(amoumnt);
                            ammountneeded = totalPrice - CurrentCustomer.WalletBalance;
                            while (ammountneeded >= amoumnt)
                            {
                                System.Console.WriteLine("Insuffient balance Ammoumnt Required " + ammountneeded);
                                //System.Console.WriteLine("");

                                System.Console.WriteLine("Do you want to recharge  yes or no");

                                ansRecharge = Console.ReadLine().ToLower();
                                while (ansRecharge != "yes" && ansRecharge != "no")
                                {
                                    System.Console.WriteLine("Please enter correct option");
                                    System.Console.WriteLine("Do you Want to  recharge yes or no");
                                    ansRecharge = Console.ReadLine().ToLower();
                                }
                                if (ansRecharge == "yes")
                                {
                                    System.Console.WriteLine("Enter the amounmnt to be added  ");
                                    checkamoumnt = double.TryParse(Console.ReadLine(), out amoumnt);
                                    CurrentCustomer.WalletRecharge(amoumnt);
                                    ammountneeded = totalPrice - CurrentCustomer.WalletBalance;
                                }
                                if (ansRecharge == "no")
                                {
                                    anspurchase = "no";
                                    break;
                                }

                            }
                        } while (ammountneeded >= amoumnt);
                        //CurrentCustomer.WalletRecharge(amoumnt);
                        newOrder.Status = OrderStatus.Ordered;
                        newOrder.TotalPrice = totalPrice;
                        CurrentCustomer.DeductBalance(totalPrice);
                        ItemDetailsList.AddRange(localItemList);
                        OrderDetailsList.Add(newOrder);
                        System.Console.WriteLine("Your order is successfull Your order ID " + newOrder.OrderID);
                    }



                    if (ansRecharge == "no")
                    {
                        anspurchase = "no";
                    }




                }
                if (anspurchase == "no")
                {
                    foreach (ItemDetails item in localItemList)
                    {
                        foreach (FoodDetails food in FoodDetailsList)
                        {
                            if (item.FoodID == food.FoodID && item.OrderID == newOrder.OrderID)
                            {
                                System.Console.WriteLine("Your order is not placed");
                                food.QuantityAvailable += item.PurchaseCount;
                                item.PurchaseCount = 0;
                                // localItemList.Remove()
                            }
                        }
                    }
                    System.Console.WriteLine("Your order is not placed");
                }
            }


        }
        // if(checkFoodid && checkCount)
        // {
        //     System.Console.WriteLine("Proceed with order");
        //    
        // }
        /*If it is available then, create ItemDetails object with created OrderID, FoodID, Quantity and Price of this order, deduct the available quantity and store the ItemDetails object in localItemList. Calculate total price of this order by summing it with current item’s price. */


    }

    public static void ModifyOrder()
    {
        bool checkEntries = false;
        string ansRecharge;
        bool checkamoumnt = false;


        foreach (OrderDetails order in OrderDetailsList)
        {
            if (CurrentCustomer.CustomerID == order.CustomerID && order.Status == OrderStatus.Ordered)
            {
                checkEntries = true;
                System.Console.WriteLine();
                System.Console.WriteLine($"OrderID      : {order.OrderID}");
                System.Console.WriteLine($"DateOfOrder  : {order.DateOfOrder}");
                System.Console.WriteLine($"Status       : {order.Status}");
                System.Console.WriteLine($"TotalPrice   : {order.TotalPrice}");
                System.Console.WriteLine();
            }
        }
        // foreach (OrderDetails order in OrderDetailsList)
        // {
        //     if (CurrentCustomer.CustomerID == order.CustomerID)
        //     {
        //         System.Console.WriteLine();
        //         System.Console.WriteLine($"OrderID      : {order.OrderID}");
        //         System.Console.WriteLine($"DateOfOrder  : {order.DateOfOrder}");
        //         System.Console.WriteLine($"Status       : {order.Status}");
        //         System.Console.WriteLine($"TotalPrice   : {order.TotalPrice}");
        //         System.Console.WriteLine();
        //     }
        // }
        bool checkOrderid = false;
        string orderid;
        do
        {
            System.Console.WriteLine("Enter the order id to Modify");
            orderid = Console.ReadLine().ToUpper();
            foreach (OrderDetails order in OrderDetailsList)
            {
                if (orderid == order.OrderID && OrderStatus.Ordered == order.Status)
                {
                    checkOrderid = true;
                    break;
                }
            }
            if (!checkOrderid)
            {
                System.Console.WriteLine("Invalid order id");
            }

        } while (!checkOrderid);
        foreach (ItemDetails item in ItemDetailsList)
        {
            if (orderid == item.OrderID)
            {
                System.Console.WriteLine($"FoodID        : {item.FoodID}");
                System.Console.WriteLine($"PurchaseCount : {item.PurchaseCount}");
            }
        }

        //Ask ItemID and check ItemID is valid. Then ask user to provide new item quantity.
        bool checkModify = false;
        double totalPrice = 0;
        System.Console.WriteLine("Enter the Item id to modfiy");
        string itemid = Console.ReadLine();
        System.Console.WriteLine("Enter the count to modify");
        bool checkcount = int.TryParse(Console.ReadLine(), out int count);
        foreach (OrderDetails order in OrderDetailsList)
        {
            if (orderid == order.OrderID && OrderStatus.Ordered == order.Status)
            {
                foreach (ItemDetails item in ItemDetailsList)
                {
                    if (itemid == item.FoodID && orderid == item.OrderID)
                    {

                        foreach (FoodDetails food in FoodDetailsList)
                        {
                            if (count <= food.QuantityAvailable && food.FoodID == item.FoodID)
                            {
                                totalPrice = count * food.PricePerQuantity;
                                if (CurrentCustomer.WalletBalance > totalPrice)
                                {
                                    item.PurchaseCount += count;
                                    food.QuantityAvailable -= count;
                                    checkModify = true;
                                    order.TotalPrice += count * food.PricePerQuantity;
                                    CurrentCustomer.DeductBalance(food.PricePerQuantity * count);

                                    System.Console.WriteLine($"Order ID {orderid} modified successfully");
                                    break;
                                }
                                else
                                {

                                    System.Console.WriteLine("Insufficient balance");
                                    double ammountneeded = totalPrice - CurrentCustomer.WalletBalance;
                                    System.Console.WriteLine("Insuffient balance Ammoumnt Required " + ammountneeded);
                                    System.Console.WriteLine("Do you want to recharge  yes or no");

                                    ansRecharge = Console.ReadLine().ToLower();
                                    while (ansRecharge != "yes" && ansRecharge != "no")
                                    {
                                        System.Console.WriteLine("Please enter correct option");
                                        System.Console.WriteLine("Do you Want to confirm purchase yes or no");
                                        ansRecharge = Console.ReadLine().ToLower();
                                    }
                                    double amoumnt = 0;

                                    if (ansRecharge == "yes")
                                    {
                                        do
                                        {
                                            System.Console.WriteLine("Enter the amounmnt to be added  ");
                                            checkamoumnt = double.TryParse(Console.ReadLine(), out amoumnt);
                                            CurrentCustomer.WalletRecharge(amoumnt);
                                            ammountneeded = totalPrice - CurrentCustomer.WalletBalance;
                                            while (ammountneeded >= amoumnt)
                                            {
                                                System.Console.WriteLine("Insuffient balance Ammoumnt Required " + ammountneeded);
                                                //System.Console.WriteLine("");

                                                System.Console.WriteLine("Do you want to recharge  yes or no");

                                                ansRecharge = Console.ReadLine().ToLower();
                                                while (ansRecharge != "yes" && ansRecharge != "no")
                                                {
                                                    System.Console.WriteLine("Please enter correct option");
                                                    System.Console.WriteLine("Do you Want to  recharge yes or no");
                                                    ansRecharge = Console.ReadLine().ToLower();
                                                }
                                                if (ansRecharge == "yes")
                                                {
                                                    System.Console.WriteLine("Enter the amounmnt to be added  ");
                                                    checkamoumnt = double.TryParse(Console.ReadLine(), out amoumnt);
                                                    CurrentCustomer.WalletRecharge(amoumnt);
                                                    ammountneeded = totalPrice - CurrentCustomer.WalletBalance;
                                                }

                                            }
                                            // CurrentCustomer.WalletRecharge(amoumnt);
                                            item.PurchaseCount += count;
                                            CurrentCustomer.DeductBalance(food.PricePerQuantity * count);
                                            food.QuantityAvailable -= count;
                                            checkModify = true;
                                            System.Console.WriteLine($"Order ID {orderid} modified successfully");
                                            break;

                                        } while (ammountneeded >= amoumnt);

                                    }
                                }
                            }
                        }
                    }
                }


            }
        }
        if (!checkModify)
        {
            System.Console.WriteLine("Invalid ");
        }
        if (!checkEntries)
        {
            System.Console.WriteLine("No Record Found");
        }

    }
}