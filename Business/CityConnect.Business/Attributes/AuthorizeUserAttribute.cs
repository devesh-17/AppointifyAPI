using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using CityConnect.Business.Enums.General;
using CityConnect.Business.Helpers;
using CityConnect.Business.ViewModels.General;
using System;
using System.Collections.Generic;

namespace CityConnect.Business.Attributes
{
    public class AuthorizeUserAttribute : ActionFilterAttribute
    {
        public List<RoleAccessModel> _roleAccessList = new List<RoleAccessModel>();

        public AuthorizeUserAttribute(ModuleEnum module, AccessTypeEnum accessType)
        {
            _roleAccessList.Add(new RoleAccessModel(module, accessType));
        }

        public AuthorizeUserAttribute(ModuleEnum[] modules, AccessTypeEnum[] accessTypes)
        {
            for (int i = 0; i < modules.Length; i++)
            {
                _roleAccessList.Add(new RoleAccessModel(modules[i], accessTypes[i]));
            }
        }
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
                string apiToken = string.Empty;
                try
                {
                    apiToken = SessionHelper.GetUserToken(context.HttpContext);
                }
                catch (Exception e)
                {
                    RedirectToLogin(context);
                    return;
                }
                if (string.IsNullOrEmpty(apiToken))
                {
                    RedirectToLogin(context);
                    return;
                }

                //is user authenticated
                var isAuthorized = false;
                foreach (var item in _roleAccessList)
                {
                    if (AccessHelper.HasAccessToModuleForWeb(item.Module, item.AccessType))
                    {
                        isAuthorized = true;
                        break;
                    }
                }
                if (!isAuthorized)
                {
                    RedirectToUnauthorized(context);
                }
        }

        public static void RedirectToLogin(ActionExecutingContext filterContext)
        {
            var routeValues = new RouteValueDictionary
            {
                { "Area", "" },
                { "Action", "Index" },
                { "Controller", "Login" }
            };
            filterContext.Result = new RedirectToRouteResult(routeValues);
        }
        public static void RedirectToUnauthorized(ActionExecutingContext filterContext)
        {
            var routeValues = new RouteValueDictionary
            {
                { "Area", "" },
                { "Action", "UnauthorizedUser" },
                { "Controller", "Home" }
            };
            filterContext.Result = new RedirectToRouteResult(routeValues);
        }
    }
}
