using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.Models;
namespace Cibertec.Repositories.NorthWind
{
    public interface IEmployessRepository: IRepository<Employees>
    {
        new int Insert(Employees entity);
        bool Delete(int id);
        new Employees GetById(int id);
        new bool Update(Employees entity);
    }
}
