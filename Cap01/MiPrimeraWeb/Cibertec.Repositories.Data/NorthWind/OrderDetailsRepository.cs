using Cibertec.Models;
using Cibertec.Repositories.NorthWind;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
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

        public IEnumerable<OrderDetails> GetListByOrderId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<OrderDetails>().Where(a => a.OrderId.Equals(id));

                //Query
                //return connection.Query<OrderDetails>("SELECT OrderId, ProductId, UnitPrice, Quantity, Discount FROM OrderDetails WHERE OrderId = @id", new { id });

                //Store Procedure
                //return connection.Query<OrderDetails>("usp_GetDetailByOrder", new { OrderId = id }, commandType: CommandType.StoredProcedure);

                //ADO.NET
                /*string _query = "SELECT OrderId, ProductId, UnitPrice, Quantity, Discount FROM OrderDetails WHERE OrderId = @id";
                SqlCommand command = new SqlCommand(_query, connection);
                command.Parameters.AddWithValue("@id", id);
                List<OrderDetails> orderDetails = new List<OrderDetails>();

                try
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        orderDetails.Add(new OrderDetails()
                        {
                            OrderId = Int32.Parse(dataReader["OrderId"].ToString()),
                            ProductId= Int32.Parse(dataReader["ProductId"].ToString()),
                            UnitPrice = decimal.Parse(dataReader["UnitPrice"].ToString()),
                            Quantity = Int32.Parse(dataReader["Quantity"].ToString()),
                            Discount = decimal.Parse(dataReader["Discount"].ToString()),
                        });
                    }
                    dataReader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return orderDetails;*/
            }
        }
    }
}
