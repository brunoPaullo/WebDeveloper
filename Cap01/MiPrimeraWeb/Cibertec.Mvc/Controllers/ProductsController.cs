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
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public ProductsController()
        {
            _IUnitOfWork = new NorthWindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
        }
        // GET: Products
        public ActionResult Index()
        {
            return View(_IUnitOfWork.Products.GetList()); ;
        }
    }
}