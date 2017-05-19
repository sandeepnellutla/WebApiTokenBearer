﻿using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;

namespace MSTCloud
{
    public class AuthorizeAttribute:System.Web.Http.AuthorizeAttribute 
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
        }
        
    }
}