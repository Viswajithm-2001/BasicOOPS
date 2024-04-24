using System;
using System.Collections.Generic;
namespace ECommerce;
class Program
{
    public static void Main(string[] args)
    {
        List<CustomerDetail> custList = new List<CustomerDetail>();
        List<OrderDetail> orderList = new List<OrderDetail>();
        CustomerDetail customer1 = new CustomerDetail("Ravi", "Chennai", 9885858588, 50000, "ravi@mail.com");
        CustomerDetail customer2 = new CustomerDetail("Baskaran", "Chennai", 9888475757, 60000, "baskaran@mail/com");
        custList.Add(customer1);
        custList.Add(customer2);
        OrderDetail order1 = new OrderDetail(customer1.customerId, "PID101", ProductDetail.pid101Price, DateTime.Now, 2, Enum.Parse<ODetail>("Order"));
        OrderDetail order2 = new OrderDetail(customer2.customerId, "PID104", ProductDetail.pid103Price, DateTime.Now, 2, Enum.Parse<ODetail>("Order"));
        orderList.Add(order1);
        orderList.Add(order2);
        Console.WriteLine("_____SynCart_____");
        Console.WriteLine("E-Commerce Application for Buying Consumer Electronics Products");
        int choice;
        do
        {
            Console.WriteLine("_____Main Menu_____");
            Console.WriteLine("Enter\n1. Customer Registration\n2. Login\n3. Exit");
            Console.Write("Enter your choice : ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        //Customer Registration
                        Console.WriteLine("Customer Registration....");
                        Console.Write("Enter your Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter your City: ");
                        string city = Console.ReadLine();
                        Console.Write("Enter your Phone Number: ");
                        long phoneNumber = long.Parse(Console.ReadLine());
                        Console.Write("Enter your wallet balance: ");
                        double walBal = double.Parse(Console.ReadLine());
                        Console.Write("Enter your Mail ID : ");
                        string mailId = Console.ReadLine();
                        CustomerDetail createCustomer = new CustomerDetail(name, city, phoneNumber, walBal, mailId);
                        custList.Add(createCustomer);
                        Console.WriteLine("Here is your Customer ID : " + createCustomer.customerId);
                        break;
                    }
                case 2:
                    {
                        //Login
                        Console.WriteLine("Login Page...");
                        Console.Write("Enter your Customer ID: ");
                        string inputCID = Console.ReadLine();
                        bool flag = false;
                        char ch;
                        foreach (CustomerDetail customer in custList)
                        {
                            if (customer.customerId == inputCID)
                            {
                                flag = true;
                                do
                                {
                                    Console.WriteLine("Enter\na. Purchase\nb. Order History\nc. Cancel Order\nd. Wallet Balance\ne. Wallet Recharge\nf. Exit");
                                    ch = char.Parse(Console.ReadLine());
                                    switch (ch)
                                    {
                                        case 'a':
                                            {
                                                //purchase
                                                int delivcharge = 50;
                                                ProductDetail.ShowProductDetails();
                                                Console.Write("Enter product ID to purchase: ");
                                                string prodId = Console.ReadLine();
                                                ProductDetail.setProduct(prodId);
                                                Console.Write("Enter quantity : ");
                                                int quantity = int.Parse(Console.ReadLine());
                                                if (ProductDetail.IsAvailable(quantity))
                                                {
                                                    Console.WriteLine("the product is available..");
                                                    Console.Write("Do you want to proceed(yes/no): ");
                                                    if (Console.ReadLine() == "yes")
                                                    {
                                                        double amount = (quantity * ProductDetail.price * 1.0) + delivcharge;
                                                        ProductDetail.ReduceCount(prodId, quantity);
                                                        if (customer.walletBalance >= amount)
                                                        {
                                                            customer.DeductBalance(amount);
                                                            ODetail ordered = Enum.Parse<ODetail>("Order");
                                                            OrderDetail order = new OrderDetail(customer.customerId, prodId, amount, DateTime.Now, quantity, ordered);
                                                            orderList.Add(order);
                                                            Console.WriteLine("Order Placed Successfully. Order ID : " + order.orderID);

                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again");
                                                        }
                                                    }



                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Required count not available. Current availability is {ProductDetail.IDprod}");
                                                }

                                                break;
                                            }
                                        case 'b':
                                            {
                                                //order history
                                                Console.WriteLine("OrderId\t\tCustomer ID\t\tProduct ID\t\tTotalPrice\t\tPurchase date\t\t quantity Purchased\t\t Order Status");
                                                foreach (OrderDetail orders in orderList)
                                                {
                                                    if (orders.custID == customer.customerId)
                                                    {
                                                        Console.WriteLine(orders.orderID + "\t\t" + orders.custID + "\t\t\t" + orders.productID + "\t\t\t" + orders.Price + "  \t\t\t" + orders.orderedDate.ToString("dd/MM/yyyy") + "     \t\t\t\t" + orders.quantity + "\t\t\t" + orders.orderstatus);

                                                    }
                                                }
                                                break;
                                            }
                                        case 'c':
                                            {
                                                //cancel order
                                                Console.WriteLine("Enter orderId for cancelling..");
                                                Console.Write("Order ID : ");
                                                string orderid = Console.ReadLine();
                                                foreach (OrderDetail orders in orderList)
                                                {
                                                    if (customer.customerId != orders.custID && orders.orderstatus=="Order")
                                                    {
                                                        Console.WriteLine("you can't change someone's order status...");
                                                    }
                                                    else
                                                    {
                                                        if (customer.customerId != orders.custID && orders.orderstatus=="Order")
                                                    {
                                                        Console.WriteLine("you can't change someone's order status...");
                                                    }
                                                        else if (orders.orderstatus == "Ordered")
                                                        {
                                                            Console.Write("Enter Cancel to cancel your order : ");
                                                            string stat = Console.ReadLine();
                                                            if (stat == "Cancel")
                                                            {
                                                                customer.walletBalance += orders.Price;
                                                                ProductDetail.IncreaseCount(orders.productID, orders.quantity);
                                                                orders.orderstatus = "Cancelled";
                                                                Console.WriteLine("Order : " + orders.orderID + " " + orders.orderstatus + " successfully !");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("The order id should be cancelled or not ordered..");
                                                        }
                                                        break;


                                                    }

                                                }

                                                break;
                                            }
                                        case 'd':
                                            {
                                                //wallet balance
                                                Console.WriteLine("Your Wallet Balance is : " + customer.walletBalance);
                                                break;
                                            }
                                        case 'e':
                                            {
                                                //wallet recharge
                                                Console.Write("Do you wish to recharge(yes/no): ");
                                                string yon = Console.ReadLine();
                                                if (yon == "yes")
                                                {
                                                    Console.Write("Enter amount to recharge : ");
                                                    double amount = double.Parse(Console.ReadLine());
                                                    customer.WalletRecharge(amount);
                                                    Console.WriteLine($"Your recharge of Rs.{amount} is successful");
                                                }
                                                break;
                                            }
                                        case 'f':
                                            {
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Invalid Choice");
                                                break;
                                            }
                                    }
                                } while (ch != 'f');

                            }
                        }
                        if (!flag)
                            Console.WriteLine("Invalid customerID");

                        break;
                    }
                case 3:
                    {
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice..");
                        break;
                    }
            }


        } while (choice != 3);
    }
}