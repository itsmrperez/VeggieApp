using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeggieApp.Web.Models
{
    public class Foods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsVeggie { get; set; }
        public int FamilyId { get; set; }
        public int Sweetness { get; set; }
        public byte ColorId { get; set; }
    }
}