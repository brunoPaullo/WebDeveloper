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
using System.Data;

namespace Cibertec.Repositories.Dapper.NorthWind
{
    public class SuppliersRepository : Repository<Suppliers>, ISuppliersRepository
    {
        public SuppliersRepository(string connectionString) : base(connectionString)
        {
        }

        public new int Insert(Suppliers entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(@"Insert Suppliers 
                                                    (CompanyName, 
                                                    ContactName, 
                                                    ContactTitle, 
                                                    Address, 
                                                    City, 
                                                    Region, 
                                                    PostalCode, 
                                                    Country, 
                                                    Phone, 
                                                    Fax, 
                                                    HomePage) values
                                                     (@CompanyName, 
                                                       @ContactName, 
                                                       @ContactTitle, 
                                                       @Address, 
                                                       @City, 
                                                       @Region, 
                                                       @PostalCode, 
                                                       @Country, 
                                                       @Phone, 
                                                       @Fax, 
                                                       @HomePage)",
                                                   new
                                                   {
                                                       entity.CompanyName,
                                                       entity.ContactName,
                                                       entity.ContactTitle,
                                                       entity.Address,
                                                       entity.City,
                                                       entity.Region,
                                                       entity.PostalCode,
                                                       entity.Country,
                                                       entity.Phone,
                                                       entity.Fax,
                                                       entity.HomePage
                                                   });
                return result;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(@"Delete Suppliers
                                                   where SupplierID = @id",
                                                   new
                                                   {
                                                       id
                                                   });
                return true;
            }
        }

        public new Suppliers GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Suppliers>().Where(x => x.SupplierID.Equals(id)).SingleOrDefault();
            }
        }

        public new bool Update(Suppliers entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(@"Update Suppliers
                                                   set CompanyName = @CompanyName,
                                                       ContactName = @ContactName,
                                                       ContactTitle = @ContactTitle,
                                                       Address = @Address,
                                                       City = @City,
                                                       Region = @Region,
                                                       PostalCode = @PostalCode,
                                                       Country = @Country,
                                                       Phone = @Phone,
                                                       Fax = @Fax,
                                                       HomePage = @HomePage
                                                   where SupplierID = @id",
                                                   new
                                                   {
                                                       entity.CompanyName,
                                                       entity.ContactName,
                                                       entity.ContactTitle,
                                                       entity.Address,
                                                       entity.City,
                                                       entity.Region,
                                                       entity.PostalCode,
                                                       entity.Country,
                                                       entity.Phone,
                                                       entity.Fax,
                                                       entity.HomePage,
                                                       id = entity.SupplierID,
                                                   });
                return true;
            }
        }

        public IEnumerable<Suppliers> PageList(int starRow, int endRow)
        {
            if (starRow >= endRow) return new List<Suppliers>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@starRow", starRow);
                parameters.Add("@endRow", endRow);
                return connection.Query<Suppliers>("dbo.uspSupplierPagedList", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int Count()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("SELECT COUNT(EmployeeID) FROM dbo.Employees");
            }
        }
    }
}
