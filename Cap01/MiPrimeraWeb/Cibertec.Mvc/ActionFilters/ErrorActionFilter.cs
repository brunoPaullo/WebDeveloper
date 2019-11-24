using log4net;
using System.Web.Mvc;

namespace Cibertec.Mvc.ActionFilters
{
    public class ErrorActionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //base.OnException(filterContext);
            var log = LogManager.GetLogger(typeof(ErrorActionFilter));
            filterContext.ExceptionHandled = true;
            log.Error(filterContext.Exception);
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
        }
    }
}