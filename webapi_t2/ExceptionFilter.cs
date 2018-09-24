using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace webapi_t2
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context) {

            if(context.Exception is ItemException) {
            context.Result = new BadRequestObjectResult("Too low level");
            }
        }
    }
}
