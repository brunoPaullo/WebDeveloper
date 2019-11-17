using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.NorthWind
{
    public interface IProductRepository : IRepository<Products>
    {
        new int Insert(Products entity);
        bool Delete(int id);
        new Products GetById(int id);
        new bool Update(Products entity);
    }
}
