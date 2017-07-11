using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VeggieApp.Web.Models;
using VeggieApp.Web.Services;
using VeggieApp.Web.Services.Entity;
using VeggieApp.Web.Services.Interfaces;
using WikiWebStarter.Web.Models.Responses;

namespace VeggieApp.Web.Controllers.Api
{
    [RoutePrefix("api/recipe")]
    public class RecipeApiController : ApiController
    {
        private IRecipeService _recipeService = null;
        public RecipeApiController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [Route("{Id}"), HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            ItemResponse<Recipes> response = new ItemResponse<Recipes>();
            //response.Item = _recipeService.Get(Id);
            response.Item = RecipeServiceV2.Get(Id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route(), HttpGet]
        public HttpResponseMessage Get()
        {
            ItemsResponse<Recipe> response = new ItemsResponse<Recipe>();
            response.Items = _recipeService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
