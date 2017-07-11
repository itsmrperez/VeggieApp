using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeggieApp.Web.Models;

namespace VeggieApp.Web.Services.Entity
{
    public class RecipeServiceV2
    {
        
        public static Recipes Get(int Id)
        {
            Recipes recipe = new Recipes();
            Recipe recipeDb = new Recipe();

            using (VeggiesEntities context = new VeggiesEntities())
            {
                List<Ingredient> ingredientDb = new List<Ingredient>();
                Ingredients ingredient = null;

                List<Ingredients> list = new List<Ingredients>();

                recipeDb = context.Recipes.FirstOrDefault(x => x.Id == Id);
                recipe.Id = recipeDb.Id;
                recipe.Title = recipeDb.Title;
                recipe.Description = recipeDb.Description;
                recipe.CategoryId = recipeDb.CategoryId;
                recipe.AuthorId = recipeDb.AuthorId;

                ingredientDb = context.Ingredients.ToList();

                foreach(Ingredient i in ingredientDb)
                {
                    ingredient = new Ingredients();
                    ingredient.Name = i.Food.Name;
                    ingredient.IsVeggie = i.Food.IsVeggie;
                    ingredient.FamilyId = i.Food.FamilyId;
                    ingredient.Sweetness = i.Food.Sweetness;
                    ingredient.Measurment = i.Metric.Measurment;
                    //ingredient.Quantity = i.Quantity;

                    list.Add(ingredient);
                }

                recipe.Ingredients = list;
            }
            return recipe;

        }
    }
}