﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeggieApp.Web.Models.Responses
{
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse()
        {

            this.IsSuccessful = true;
        }
    }
}