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
    public class OrderItemController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public OrderItemController()
        {
            _UnitOfWork = new NorthWindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
        }
        // GET: OrderItem
        public ActionResult Index(int id)
        {
            return View(_UnitOfWork.Details.GetListById(id));
        }
    }
}