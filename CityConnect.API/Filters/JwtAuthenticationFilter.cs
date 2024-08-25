using CityConnect.Business.ViewModels;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using CityConnect.Business.Helpers;
using System.IO;

namespace AAT.API.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class JwtAuthenticationFilter : Attribute, IAuthorizationFilter, IActionFilter
    {
        public static PersonModel ApplicationUserApiRequest { get; set; }
        private string requestModel = "";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
                ApplicationUserApiRequest = null;
                if (IsAuthenticated)
                {
                    var claimsIndentity = context.HttpContext.User.Identity as ClaimsIdentity;
                    ApplicationUserApiRequest = new PersonModel
                    {
                        Id = Convert.ToInt32(context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value),
                        Name = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Name")?.Value,
                        RoleId = Convert.ToInt32(context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "RoleId")?.Value)
                    };
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                if (ApplicationUserApiRequest != null)
                {
                    dynamic valuesCntlr = context.Controller as dynamic;
                    valuesCntlr.ApplicationUserApiRequest = ApplicationUserApiRequest;
                }

                //Action log to file          
                var model = ((System.Collections.Generic.Dictionary<string, object>)(context.ActionArguments)).Values;
                requestModel = JsonConvert.SerializeObject(model);
            }
            catch (Exception ex)
            {
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            try
            {
                if (((dynamic)((ObjectResult)context.Result).Value).MessageType.ToString() == "Error")
                {
                    var controllerName = ((ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
                    var actionName = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;
                    var fileName = controllerName + ' ' + actionName + ' ' + DateTime.UtcNow.Ticks.ToString() + ".txt";
                    var filePath = Directory.GetCurrentDirectory() + "/uploads/RequestLog/" + DateTime.Now.Date.Year + "_" + DateTime.Now.Date.Month.ToString("00") + "_" + DateTime.Now.Day.ToString("00");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    fileName = Path.Combine(filePath, fileName);
                    FileHelper.WriteLine(fileName, requestModel);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
