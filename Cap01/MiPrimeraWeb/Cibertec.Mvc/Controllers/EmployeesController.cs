using Cibertec.Models;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Empoyees
        public ActionResult Index()
        {
            return View(_unitOfWork.Employess.GetList()); ;
        }


        public ActionResult Update(int id)
        {
            var employee = _unitOfWork.Employess.GetById(id);
            return View(employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Employees employee)
        {
            if (!ModelState.IsValid)
            {
                _unitOfWork.Employess.Update(employee);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}