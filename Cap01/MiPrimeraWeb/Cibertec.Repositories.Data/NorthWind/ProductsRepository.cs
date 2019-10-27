using Cibertec.Models;
using Cibertec.Repositories.NorthWind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper.NorthWind
{
    public class ProductsRepository : Repository<Products>, IProductRepository
    {
        public ProductsRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
