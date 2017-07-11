using Sabio.Web.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VeggieApp.Web.Models;
using VeggieApp.Web.Services.Interfaces;
using WikiDataProvider.Data;
using WikiDataProvider.Data.Extensions;

namespace VeggieApp.Web.Services
{
    public class RecipeService : BaseService, IRecipeService
    {
        public Recipe Get(int Id)
        {
            Recipe recipe = null;
            Ingredients ingredients = null;
            List<Ingredients> list = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Recipe_SelectById"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@RecipeId", Id);
                }
                , map: delegate (IDataReader reader, short set)
                {
                    if (set == 0)
                    {
                        if (recipe == null)
                        {
                            recipe = new Recipe();
                        }
                        recipe = MapRecipe(reader);
                    }
                    else if (set == 1)
                    {
                        if (ingredients == null)
                        {
                            ingredients = new Ingredients();
                        }
                        if (list == null)
                        {
                            list = new List<Ingredients>();
                        }
                        ingredients = MapIngredients(reader);
                        list.Add(ingredients);
                    }

                    //recipe.Ingredients = list;
                });

            return recipe;
        }

        public List<Recipe> Get()
        {
            Recipe recipe = null;
            List<Recipe> list = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Recipe_SelectAll"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    if (list == null)
                    {
                        list = new List<Recipe>();
                    }

                    if (recipe == null)
                    {
                        recipe = new Recipe();
                    }
                    
                    recipe = MapRecipe(reader);

                    list.Add(recipe);

                });

            return list;
        }

        private static Recipe MapRecipe(IDataReader reader)
        {
            Recipe r = new Recipe();
            int startingIndex = 0;
            r.Id = reader.GetSafeInt32(startingIndex++);
            r.Title = reader.GetSafeString(startingIndex++);
            r.Description = reader.GetSafeString(startingIndex++);
            r.CategoryId = reader.GetSafeInt32(startingIndex++);
            r.AuthorId = reader.GetSafeString(startingIndex++);

            return r;
        }

        private static Ingredients MapIngredients(IDataReader reader)
        {
            Ingredients i = new Ingredients();
            int startingIndex = 0;
            //i.Name = reader.GetSafeString(startingIndex++);
            //i.IsVeggie = reader.GetSafeBool(startingIndex++);
            //i.FamilyId = reader.GetSafeInt32(startingIndex++);
            //i.Sweetness = reader.GetSafeInt32(startingIndex++);
            //i.Measurment = reader.GetSafeString(startingIndex++);
            //i.Quantity = reader.GetSafeInt32(startingIndex++);

            return i;
        }
    }
}