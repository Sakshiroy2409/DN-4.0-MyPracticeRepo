﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_CustomModels.Filters
{
    public class CustomAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var hasAuth = context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);

            if (!hasAuth)
            {
                context.Result = new BadRequestObjectResult("No Authorization header found");
                return;
            }

            if (!token.ToString().Contains("Bearer"))
            {
                context.Result = new BadRequestObjectResult("Token is not a Bearer token");
            }
        }
    }
}