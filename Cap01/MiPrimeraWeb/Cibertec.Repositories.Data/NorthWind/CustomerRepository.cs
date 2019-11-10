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
    public class CustomerRepository : Repository<Customers>, ICustomerRepository
    {

        public CustomerRepository(string connectionString) : base(connectionString)
        {

        }

        public bool Delete(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(@"Delete Customers
                                                   where CustomerId = @id",
                                                   new
                                                   {
                                                       id
                                                   });
                return true;
            }
        }

        public Customers GetById(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Customers>().Where(x => x.CustomerID.Equals(id)).SingleOrDefault();
            }
        }

        public new bool Update(Customers entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(@"Update Customers
                                                   set CompanyName = @Company,
                                                       ContactName = @contact
                                                   where CustomerId = @id",
                                                   new
                                                   {
                                                       company = entity.CompanyName,
                                                       contact = entity.ContactName,
                                                       id = entity.CustomerID
                                                   });
                return true;
            }
        }
    }
}
