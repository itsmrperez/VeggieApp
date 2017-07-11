using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeggieApp.Web.Models
{
    public class Ingredients
    {
        public string Name { get; set; }
        public bool IsVeggie { get; set; }
        public int FamilyId { get; set; }
        public int Sweetness { get; set; }
        public string Measurment { get; set; }
        public int Quantity { get; set; }
      
    }
}