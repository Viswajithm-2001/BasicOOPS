using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce
{
    public enum ODetail {Default, Order, Cancel}
    public class OrderDetail
    {
        private int _orderId = 1000;
        public string orderID;
        public string custID;
        public string productID;
        public double Price;
        public int quantity;
        public string orderstatus;
        public DateTime orderedDate;
        public OrderDetail(string customerID,string productID,double TotalPrice,DateTime date,int quantity,ODetail order)
        {
            this.custID=customerID;
            this.productID=productID;
            this.Price = TotalPrice;
            this.quantity=quantity;
            this.orderedDate = date;
            if(order.ToString()=="Order")
            this.orderstatus="Ordered";
            else if(order.ToString()=="Cancel")
            this.orderstatus="Cancelled";
            else
            this.orderstatus="Default";
            orderID = "OID"+(++_orderId);
        }
    }
}