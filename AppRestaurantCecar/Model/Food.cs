using System;
using System.Collections.Generic;
using System.Text;

namespace AppRestaurantCecar.Model
{
    public class Food
    {
        public int Food_id { get; set; }
        public String Name { get; set; }
        public Double Price { get; set; }
        public String Description { get; set; }
        public String Image { get; set; }
        public Double Time { get; set; }
    }
}
