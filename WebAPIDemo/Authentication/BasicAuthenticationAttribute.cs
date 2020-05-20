using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Text;
using System.Threading;
using System.Security.Principal;

namespace WebAPIDemo.Authentication
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string token = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                string[] userNamePwdArray = decodedToken.Split(':');
                string userName = userNamePwdArray[0];
                string password = userNamePwdArray[1];
                if(EmployeeSecurity.Login(userName,password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);

                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}