using Cibertec.Mvc.ActionFilters;
using Cibertec.UnitOfWork;
using log4net;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    [ErrorActionFilter]
    [Authorize]
    public class BaseController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        protected readonly ILog _log;

        public BaseController(IUnitOfWork IUnitOfWork, ILog log)
        {
            _log = log;
            _unitOfWork = IUnitOfWork;
        }
    }
}