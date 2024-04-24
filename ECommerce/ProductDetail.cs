using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce
{
    public class ProductDetail
    {
        public static int pid101 = 10;
        public static string pid101PName = "Mobile(Samsung)";
        public static int pid101Price = 10000;
        public static int pid102 = 5;
        public static string pid102PName = "Tablet(Lenovo)";
        public static int pid102Price = 15000;
        public static int pid103 = 3;
        public static string pid103PName = "Camera(Sony)";
        public static int pid103Price = 20000;
        public static int pid104 = 5;
        public static string pid104PName = "iPhone";
        public static int pid104Price = 50000;
        public static int pid105 = 3;
        public static string pid105PName = "Laptop(Lenovo I3)";
        public static int pid105Price = 40000;
        public static int pid106 = 5;
        public static string pid106PName = "HeadPhone(Boat)";
        public static int pid106Price = 1000;
        public static int pid107 = 4;
        public static string pid107PName = "Speakers(Boat)";
        public static int pid107Price = 500;
        public static int IDprod;
        //public string productID;

        public static void ShowProductDetails()
        {
            Console.WriteLine("ProductID\t\tProduct Name\t\tAvailable stock\t\tTotal Price \t\tshipping duration");

            Console.WriteLine("PID101\t\t\t" + pid101PName + "\t\t\t" + pid101 + "\t\t\t" + pid101Price + "\t\t\t" + 3);
            Console.WriteLine("PID102\t\t\t" + pid102PName + "\t\t\t" + pid102 + "\t\t\t" + pid102Price + "\t\t\t" + 2);
            Console.WriteLine("PID103\t\t\t" + pid103PName + "\t\t\t" + pid103 + "\t\t\t" + pid103Price + "\t\t\t" + 4);
            Console.WriteLine("PID104\t\t\t" + pid104PName + "                         " + pid104 + "\t\t\t" + pid104Price + "\t\t\t" + 6);
            Console.WriteLine("PID105\t\t\t" + pid105PName + "               " + pid105 + "\t\t\t" + pid105Price + "\t\t\t" + 3);
            Console.WriteLine("PID106\t\t\t" + pid106PName + "\t\t\t" + pid106 + "\t\t\t" + pid106Price + "\t\t\t" + 2);
            Console.WriteLine("PID107\t\t\t" + pid107PName + "\t\t\t" + pid107 + "\t\t\t" + pid107Price + "\t\t\t" + 2);


        }
        public static int price;
        public static void setProduct(string id)
        {

            if (id == "PID101")
            {
                IDprod = pid101;
                price = pid101Price;
            }
            else if (id == "PID102")
            {
                IDprod = pid102;
                price = pid102Price;
            }
            else if (id == "PID103")
            {
                IDprod = pid103;
                price = pid103Price;
            }
            else if (id == "PID104")
            {
                IDprod = pid104;
                price = pid104Price;
            }
            else if (id == "PID105")
            {
                IDprod = pid105;
                price = pid105Price;
            }
            else if (id == "PID106")
            {
                IDprod = pid106;
                price = pid106Price;
            }
            else if (id == "PID107")
            {
                IDprod = pid107;
                price = pid107Price;
            }
            else
            {
                Console.WriteLine("Invalid ID");

            }
        }
        public static void ReduceCount(string id, int quantity)
        {
            if (id == "PID101")
            {
                pid101 -= quantity;
            }
            else if (id == "PID102")
            {
                pid102 -= quantity;
            }
            else if (id == "PID103")
            {
                pid103 -= quantity;
            }
            else if (id == "PID104")
            {
                pid104 -= quantity;
            }
            else if (id == "PID105")
            {
                pid105 -= quantity;
            }
            else if (id == "PID106")
            {
                pid106 -= quantity;
            }
            else if (id == "PID107")
            {
                pid107 -= quantity;
            }
        }
        public static void IncreaseCount(string id, int quantity)
        {
            if (id == "PID101")
            {
                pid101 += quantity;
            }
            else if (id == "PID102")
            {
                pid102 += quantity;
            }
            else if (id == "PID103")
            {
                pid103 += quantity;
            }
            else if (id == "PID104")
            {
                pid104 += quantity;
            }
            else if (id == "PID105")
            {
                pid105 += quantity;
            }
            else if (id == "PID106")
            {
                pid106 += quantity;
            }
            else if (id == "PID107")
            {
                pid107 += quantity;
            }
        }

        public static bool IsAvailable(int count)
        {
            if (IDprod >= count)
                return true;

            return false;
        }


    }
}