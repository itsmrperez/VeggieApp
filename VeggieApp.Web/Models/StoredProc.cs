using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VeggieApp.Web.Models
{
    public class StoredProc
    {
        public static Recipes GetRecipeById(int Id)
        {
            Recipes recipe = new Recipes();
            VeggiesEntities veggie = new VeggiesEntities();
            var result = veggie.Recipe_SelectById(Id);
            recipe.Title = result.FirstOrDefault().Title;
            return recipe;
        }

        public static List<Recipes> GetRecipes()
        {
            List<Recipes> list = new List<Recipes>();
            VeggiesEntities veggie = new VeggiesEntities();
            Recipes aRecipe = null;
            List<Recipe_SelectAll_Result> result = veggie.Recipe_SelectAll().ToList();

            foreach(Recipe_SelectAll_Result item in result)
            {
                aRecipe = new Recipes();
                aRecipe.Title = item.Title;
                aRecipe.Description = item.Description;
                aRecipe.CategoryId = item.CategoryId;
                aRecipe.AuthorId = item.AuthorId;
                list.Add(aRecipe);
            }

            return list;
        }
    }
}