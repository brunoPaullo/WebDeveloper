using Cibertec.Models;
using Cibertec.Repositories.NorthWind;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Cibertec.Repositories.Dapper.NorthWind
{
    public class ProductsRepository : Repository<Products>, IProductRepository
    {
        public ProductsRepository(string connectionString) : base(connectionString)
        {
        }

        public new int Insert(Products entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(@"Insert Products 
                                                    (ProductName,
                                                    SupplierID,
                                                    CategoryID,
                                                    QuantityPerUnit,
                                                    UnitPrice,
                                                    UnitsInStock,
                                                    UnitsOnOrder,
                                                    ReorderLevel,
                                                    Discontinued) values
                                                     (@ProductName,
                                                     @SupplierID,
                                                     @CategoryID,
                                                     @QuantityPerUnit,
                                                     @UnitPrice,
                                                     @UnitsInStock,
                                                     @UnitsOnOrder,
                                                     @ReorderLevel,
                                                     @Discontinued)",
                                                   new
                                                   {
                                                       entity.ProductName,
                                                       entity.SupplierID,
                                                       entity.CategoryID,
                                                       entity.QuantityPerUnit,
                                                       entity.UnitPrice,
                                                       entity.UnitsInStock,
                                                       entity.UnitsOnOrder,
                                                       entity.ReorderLevel,
                                                       entity.Discontinued
                                                   });
                return result;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(@"Delete Products
                                                   where ProductID = @id",
                                                   new
                                                   {
                                                       id
                                                   });
                return true;
            }
        }

        public new Products GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Products>().Where(x => x.ProductID.Equals(id)).SingleOrDefault();
            }
        }

        public new bool Update(Products entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(@"Update Products
                                                   set ProductName = @ProductName,
                                                       SupplierID = @SupplierID,
                                                       CategoryID = @CategoryID,
                                                       QuantityPerUnit = @QuantityPerUnit,
                                                       UnitPrice = @UnitPrice,
                                                       UnitsInStock = @UnitsInStock,
                                                       UnitsOnOrder = @UnitsOnOrder,
                                                       ReorderLevel = @ReorderLevel,
                                                       Discontinued = @Discontinued
                                                   where ProductID = @id",
                                                   new
                                                   {
                                                       entity.ProductName,
                                                       entity.SupplierID,
                                                       entity.CategoryID,
                                                       entity.QuantityPerUnit,
                                                       entity.UnitPrice,
                                                       entity.UnitsInStock,
                                                       entity.UnitsOnOrder,
                                                       entity.ReorderLevel,
                                                       entity.Discontinued,
                                                       id = entity.ProductID,                                      
                                                   });
                return true;
            }
        }
    }
}
