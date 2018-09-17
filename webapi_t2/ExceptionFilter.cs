using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using webapi_t2.Models;
using webapi_t2.Controllers;

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
