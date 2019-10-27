using Cibertec.Repositories.NorthWind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IOrderDetailsRepository Details { get; }
        IOrdersRepository Orders { get; }
        IProductRepository Products { get; }
        ISuppliersRepository Suppliers { get; }
    }
}
