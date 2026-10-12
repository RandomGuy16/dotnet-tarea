using System;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MiBotica.SolPedido.Entidades.Filter
{
    public class ExceptionFilterAtributes : Attribute, IExceptionFilter
    {
        public ILog Log
        {
            get
            {
                return LogManager.GetLogger(
                    System.Reflection.MethodBase.GetCurrentMethod()
                        .GetType());
            }
        }

        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.StatusCode = 500;
            Log.Error(filterContext.Exception);
        }
    }
}
