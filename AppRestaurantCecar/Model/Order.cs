using System;
using System.Collections.Generic;
using System.Text;

namespace AppRestaurantCecar.Model
{
    public class Order
    {
        public int Order_id { get; set; }
        public int Customer_id { get; set; }
        public int Food_id { get; set; }
        public int Quantity { get; set; }
        public Double Total { get; set; }
        public DateTime Date { get; set; }
        public String Status { get; set; }
    }
}
