using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.NorthWind
{
    public interface ISuppliersRepository : IRepository<Suppliers>
    {
        new int Insert(Suppliers entity);
        bool Delete(int id);
        new Suppliers GetById(int id);
        new bool Update(Suppliers entity);
    }
}
