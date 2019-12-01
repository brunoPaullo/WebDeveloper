using Cibertec.Repositories.NorthWind;
using Cibertec.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper.NorthWind
{
    public class NorthWindUnitOfWork: IUnitOfWork
    {     
        public NorthWindUnitOfWork(string connectionString)
        {
            Customers = new CustomerRepository(connectionString);
            Details = new OrderDetailsRepository(connectionString);
            Orders = new OrdersRepository(connectionString);
            Products = new ProductsRepository(connectionString);
            Suppliers = new SuppliersRepository(connectionString);
            Employess = new EmployeesRepository(connectionString);
            Users = new UserRepository(connectionString);
        } 
        
        public ICustomerRepository Customers { get; private set; }

        public IOrderDetailsRepository Details { get; private set; }

        public IOrdersRepository Orders { get; private set; }

        public IProductRepository Products { get; private set; }

        public ISuppliersRepository Suppliers { get; private set; }

        public IEmployessRepository Employess { get; private set; }

        public IUserRepository Users { get; private set; }
    }
}
