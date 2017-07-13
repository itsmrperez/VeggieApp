using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

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
                //MapRecipe(item);
                aRecipe = new Recipes();
                aRecipe.Title = item.Title;
                aRecipe.Description = item.Description;
                aRecipe.CategoryId = item.CategoryId;
                aRecipe.AuthorId = item.AuthorId;
                list.Add(aRecipe);
            }

            return list;
        }

        //public static Recipes Add(Recipes model)
        //{
        //    VeggiesEntities veggie = new VeggiesEntities();
        //    Recipes cool = new Recipes();
        //    veggie.Recipe_Insert(model.Title, model.Description, model.CategoryId, model.AuthorId, ObjectParameter id);
        //    return id;
        //}

        public static int AddV2(Recipe model)
        {
            using (VeggiesEntities veggie = new VeggiesEntities())
            {
                Recipe insert = veggie.Recipes.Add(model);
                veggie.SaveChanges();
                return insert.Id;
            }
        }

        public void Update(Recipe model)
        {
            using (VeggiesEntities veggie = new VeggiesEntities())
            {
                Recipe newRecipe = veggie.Recipes.FirstOrDefault(x => x.Id == model.Id);
                newRecipe.Title = model.Title;
                //newRecipe.Description = model.Description;
                //newRecipe.CategoryId = model.CategoryId;
                //newRecipe.AuthorId = model.AuthorId;
                veggie.SaveChanges();
            }
        }

        //private static Recipes MapRecipe(item)
        //{
        //    Recipes aRecipe = new Recipes();
        //    aRecipe = new Recipes();
        //    aRecipe.Title = item.Title;
        //    aRecipe.Description = item.Description;
        //    aRecipe.CategoryId = item.CategoryId;
        //    aRecipe.AuthorId = item.AuthorId;

        //    return aRecipe;
        //}
    }
}