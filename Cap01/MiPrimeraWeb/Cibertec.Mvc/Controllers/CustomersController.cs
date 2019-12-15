using Cibertec.Models;
using Cibertec.UnitOfWork;
using log4net;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    public class CustomersController : BaseController
    {
        //private readonly IUnitOfWork _unitOfWork;

        /*public CustomersController()
        {
            _unitOfWork = new NorthWindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
        }*/

        public CustomersController(IUnitOfWork unitOfWork, ILog log) : base(unitOfWork, log)
        {
        }

        public ActionResult Error()
        {
            throw new System.Exception("Prueba de validacion de error");
        }

        // GET: Customer
        public ActionResult Index()
        {
            //_log.Info("Ejecución de customer controller ok");
            //return View();
            return View(_unitOfWork.Customers.GetList());
        }

        // GET: Customer
        public ActionResult GetCustomers()
        {
            var customers = _unitOfWork.Customers.GetList();
            return View("_List", customers);
        }

        public PartialViewResult Create()
        {
            return PartialView("_Create", new Customers());
        }

        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Customers.Insert(customer);
                return RedirectToAction("Index");
            }
            return PartialView("_Create", customer);
        }

        public PartialViewResult Update(string id)
        {
            var customer = _unitOfWork.Customers.GetById(id);
            return PartialView("_Update", customer);
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
            return PartialView("_Update", customer);
        }


        public PartialViewResult Delete(string id)
        {
            var customer = _unitOfWork.Customers.GetById(id);
            return PartialView("_Delete", customer);
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
            var customer = _unitOfWork.Customers.GetById(CustomerID);
            return PartialView("_Delete", customer);

        }
    }
}