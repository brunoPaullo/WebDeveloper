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
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController()
        {
            _unitOfWork = new NorthWindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
        }
        // GET: Products
        public ActionResult Index()
        {
            return View(_unitOfWork.Products.GetList()); ;
        }

        public ActionResult Create()
        {
            return View();
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

        public ActionResult Update(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            return View(product);
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
            var customer = _unitOfWork.Products.GetById(id);
            return View(customer);
        }


        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int ProductID)
        {
            _unitOfWork.Products.Delete(ProductID);
            return RedirectToAction("Index");

        }
    }
}