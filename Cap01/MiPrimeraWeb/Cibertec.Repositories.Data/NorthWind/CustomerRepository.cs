using Cibertec.Models;
using Cibertec.Repositories.NorthWind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper.NorthWind
{
   public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {

        public CustomerRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
