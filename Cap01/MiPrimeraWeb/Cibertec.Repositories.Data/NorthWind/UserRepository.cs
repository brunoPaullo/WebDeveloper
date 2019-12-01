using Cibertec.Models;
using Cibertec.Repositories.NorthWind;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories.Dapper.NorthWind
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public User CreateUser(User user)
        {
            using (var cnn = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", user.Email);
                parameters.Add("@password", user.Password);
                parameters.Add("@firstName", user.FirstName);
                parameters.Add("@lastName", user.LastName);               

                return cnn.QueryFirstOrDefault<User>("dbo.uspCreateUser", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public User VAlidateUer(string email, string password)
        {
            using (var cnn = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@password", password);

                return cnn.QueryFirstOrDefault<User>("dbo.uspValidateUser", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
