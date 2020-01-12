using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
namespace Cibertec.WebApi.Handler
{
    public class GlobalExceptionHandler: ExceptionHandler
    {
        private readonly ILog log = LogManager.GetLogger(typeof(GlobalExceptionHandler));
        public override void Handle(ExceptionHandlerContext contex)
        {
            log.Error(contex.Exception);
            contex.Result = new InternalServerErrorResult(contex.Request);
        }
    }
}