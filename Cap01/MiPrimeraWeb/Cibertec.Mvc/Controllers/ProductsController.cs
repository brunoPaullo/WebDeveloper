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
    [RoutePrefix("Products")]
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork unitOfWork, ILog log) : base(unitOfWork, log)
        {
            
        }
        // GET: Products
        public ActionResult Index()
        {
            return View(_unitOfWork.Products.GetList()); ;
        }

        public PartialViewResult Create()
        {
            return PartialView("_Create", new Products());
        }

        [HttpPost]
        public ActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Products.Insert(products);
                return RedirectToAction("Index");
            }
            return View();
        }

        public PartialViewResult Update(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            return PartialView("_Update", product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Products products)
        {
            if (ModelState.IsValid)
            {
                products.Id = 0;
                _unitOfWork.Products.Update(products);
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            return PartialView("_Delete", product);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int ProductID)
        {
            _unitOfWork.Products.Delete(ProductID);
            return RedirectToAction("Index");

        }

        [Route("List/{page:int}/{rows:int}")]
        public PartialViewResult List(int page, int rows)
        {
            if (page <= 0 || rows <= 0) return PartialView(new List<Products>());
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;
            return PartialView("_List", _unitOfWork.Products.PageList(startRecord, endRecord));
        }

        public int Count(int rows)
        {
            var totalRecords = _unitOfWork.Products.Count();
            return totalRecords % rows != 0 ? (totalRecords / rows) + 1 : totalRecords / rows;
        }
    }
}