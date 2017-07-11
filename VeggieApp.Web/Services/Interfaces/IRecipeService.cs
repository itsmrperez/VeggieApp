using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieApp.Web.Models;

namespace VeggieApp.Web.Services.Interfaces
{
    public interface IRecipeService
    {
        Recipe Get(int Id);
        List<Recipe> Get();
    }
}
