using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WikiWebStarter.Web.Models.Responses;

namespace VeggieApp.Web.Models.Responses
{
    public class ItemResponse<T> : SuccessResponse
    {
        public ItemResponse() { }

        public ItemResponse(T item)
        {
            Item = item;
        }

        public T Item { get; set; }

    }

    public class PairResponse<T, K> : ItemResponse<T>
    {

        public K Item2 { get; set; }


    }
}