using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.NorthWind
{
    public interface ICustomerRepository : IRepository<Customers>
    {
        Customers GetById(string id);
        new bool Update(Customers entity);
        bool Delete(string id);

    }
}
