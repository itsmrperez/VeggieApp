using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeggieApp.Web.Core.Interfaces.Services
{
    public interface IIdentityProvider<T>
    {
        T GetCurrentUserId();
    }
}
