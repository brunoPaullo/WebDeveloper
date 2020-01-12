using Cibertec.Models;
using Cibertec.UnitOfWork;
using log4net;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    [RoutePrefix("Customers")]
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

        [Route("List/{page:int}/{rows:int}")]
        public PartialViewResult List(int page, int rows)
        {
            if (page <= 0 || rows <= 0) return PartialView(new List<Customers>());
            var startRecord = ((page - 1) * rows) + 1;
            var endRecord = page * rows;

            /*
             Solicitar token
             var token = llamartoken(unsername,pasword,grant_type)
             list<customers> lscustomers = llamar al servicio(page, rows, token);
             */
            return PartialView("_List", _unitOfWork.Customers.PageList(startRecord, endRecord));
        }

        //[Route("Count/{rows:int}")] //No funciona
        public int Count(int rows)
        {
            var totalRecords = _unitOfWork.Customers.Count();
            return totalRecords % rows != 0 ? (totalRecords / rows) + 1 : totalRecords / rows;
        }

        //[Route("GetString/{param}")]
        public string GetString(int param)
        {
            return "ok";
        }
    }
}