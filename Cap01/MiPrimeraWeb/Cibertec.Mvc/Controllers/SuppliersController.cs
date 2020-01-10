using Cibertec.Models;
using Cibertec.Repositories.Dapper.NorthWind;
using Cibertec.UnitOfWork;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    [RoutePrefix("Suppliers")]
    public class SuppliersController : BaseController
    {
        public SuppliersController(IUnitOfWork unitOfWork, ILog log) : base(unitOfWork, log)
        {
            
        }
        // GET: Suppliers
        public ActionResult Index()
        {
            return View(_unitOfWork.Suppliers.GetList());
        }

        public PartialViewResult Create()
        {
            return PartialView("_Create", new Suppliers());
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


        public PartialViewResult Update(int id)
        {
            var supplier = _unitOfWork.Suppliers.GetById(id);
            return PartialView("_Update", supplier);
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

        [Route("List/{page:int}/{rows:int}")]
        public PartialViewResult List(int page, int rows)
        {
            if (page <= 0 || rows <= 0) return PartialView(new List<Customers>());
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return PartialView("_List", _unitOfWork.Suppliers.PageList(startRecord, endRecord));
        }

        //[Route("Count/{rows:int}")] //No funciona
        public int Count(int rows)
        {
            var totalRecords = _unitOfWork.Suppliers.Count();
            return totalRecords % rows != 0 ? (totalRecords / rows) + 1 : totalRecords / rows;
        }
    }
}