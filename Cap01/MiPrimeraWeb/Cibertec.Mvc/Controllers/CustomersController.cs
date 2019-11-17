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
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        /*public CustomersController()
        {
            _unitOfWork = new NorthWindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
        }*/

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View(_unitOfWork.Customers.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Customers.Insert(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Update(string id)
        {
            var customer = _unitOfWork.Customers.GetById(id);
            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Customers customer)
        {
            if (!ModelState.IsValid)
            {
                customer.Id = 0;
                _unitOfWork.Customers.Update(customer);
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(string id)
        {
            var customer = _unitOfWork.Customers.GetById(id);
            return View(customer);
        }

        //[HttpGet]
        [HttpPost]
        //[HttpPut]
        //[HttpPatch]
        //[HttpDelete]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomer(string CustomerID)
        {
            _unitOfWork.Customers.Delete(CustomerID);
            return RedirectToAction("Index");

        }
    }
}