using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeggieApp.Web.Models
{
    public class Recipes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string AuthorId { get; set; }
        public List<Ingredients> Ingredients { get; set; }
    }
}