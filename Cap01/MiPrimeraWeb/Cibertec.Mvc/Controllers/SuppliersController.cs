using Cibertec.Models;
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
    public class SuppliersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SuppliersController()
        {
            _unitOfWork = new NorthWindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
        }
        // GET: Suppliers
        public ActionResult Index()
        {
            return View(_unitOfWork.Suppliers.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Suppliers.Insert(suppliers);
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Update(int id)
        {
            var supplier = _unitOfWork.Suppliers.GetById(id);
            return View(supplier);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Suppliers.Update(suppliers);
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            var supplier = _unitOfWork.Suppliers.GetById(id);
            return View(supplier);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int SupplierID)
        {
            _unitOfWork.Suppliers.Delete(SupplierID);
            return RedirectToAction("Index");

        }

    }
}