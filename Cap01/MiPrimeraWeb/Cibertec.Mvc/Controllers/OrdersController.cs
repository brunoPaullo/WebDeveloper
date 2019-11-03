using Cibertec.Repositories.Dapper.NorthWind;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController()
        {
            _unitOfWork = new NorthWindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
        }
        // GET: Orders
        public ActionResult Index()
        {
            return View(_unitOfWork.Orders.GetList());
        }

        public ActionResult Details(int id)
        {
            var model = _unitOfWork.Details.GetListByOrderId(id);
            return View(model);
        }
    }
}