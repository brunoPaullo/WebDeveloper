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
        } 
        
        public ICustomerRepository Customers { get; private set; }
    }
}
