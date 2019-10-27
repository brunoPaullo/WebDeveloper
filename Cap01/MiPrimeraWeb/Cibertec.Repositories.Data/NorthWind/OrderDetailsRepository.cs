using Cibertec.Models;
using Cibertec.Repositories.NorthWind;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cibertec.Repositories.Dapper.NorthWind
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(string connectionString) : base(connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{type.Name}"; };

        }

        List<OrderDetails> IOrderDetailsRepository.GetListById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<OrderDetails>().Where(a => a.OrderId == id).ToList();
            }
        }
    }
}
