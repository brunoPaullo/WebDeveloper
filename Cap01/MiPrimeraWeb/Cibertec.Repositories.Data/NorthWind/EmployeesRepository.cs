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
    public class EmployeesRepository : Repository<Employees>, IEmployessRepository
    {
        public EmployeesRepository(string connectionString) : base(connectionString)
        {
        }

        public new int Insert(Employees entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(@"Insert Employees 
                                                    (LastName, 
                                                     FirstName, 
                                                     Title, 
                                                     TitleOfCourtesy, 
                                                     BirthDate, 
                                                     HireDate, 
                                                     Address, 
                                                     City, 
                                                     Region, 
                                                     PostalCode, 
                                                     Country, 
                                                     HomePhone, 
                                                     Extension, 
                                                     Photo, 
                                                     Notes, 
                                                     ReportsTo, 
                                                     PhotoPath) values
                                                     (@LastName, 
                                                      @FirstName, 
                                                      @Title, 
                                                      @TitleOfCourtesy, 
                                                      @BirthDate, 
                                                      @HireDate, 
                                                      @Address, 
                                                      @City, 
                                                      @Region, 
                                                      @PostalCode, 
                                                      @Country, 
                                                      @HomePhone, 
                                                      @Extension, 
                                                      @Photo, 
                                                      @Notes, 
                                                      @ReportsTo, 
                                                      @PhotoPath)",
                                                   new
                                                   {
                                                       entity.LastName,
                                                       entity.FirstName,
                                                       entity.Title,
                                                       entity.TitleOfCourtesy,
                                                       entity.BirthDate,
                                                       entity.HireDate,
                                                       entity.Address,
                                                       entity.City,
                                                       entity.Region,
                                                       entity.PostalCode,
                                                       entity.Country,
                                                       entity.HomePhone,
                                                       entity.Extension,
                                                       entity.Photo,
                                                       entity.Notes,
                                                       entity.ReportsTo,
                                                       entity.PhotoPath
                                                   });
                return result;
            }
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(@"Delete Employees
                                                   where EmployeeId = @id",
                                                   new
                                                   {
                                                       id
                                                   });
                return true;
            }
        }

        public new Employees GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Employees>().Where(x => x.EmployeeId.Equals(id)).SingleOrDefault();
            }
        }

        public new bool Update(Employees entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Execute(@"Update Employees
                                                   set LastName=@LastName, 
                                                       FirstName=@FirstName, 
                                                       Title=@Title, 
                                                       TitleOfCourtesy=@TitleOfCourtesy, 
                                                       BirthDate=@BirthDate, 
                                                       HireDate=@HireDate, 
                                                       Address=@Address, 
                                                       City=@City, 
                                                       Region=@Region, 
                                                       PostalCode=@PostalCode, 
                                                       Country=@Country, 
                                                       HomePhone=@HomePhone, 
                                                       Extension=@Extension, 
                                                       Photo=@Photo, 
                                                       Notes=@Notes, 
                                                       ReportsTo=@ReportsTo, 
                                                       PhotoPath=@PhotoPath,
                                                       EmployeeID=@EmployeeId",
                                                   new
                                                   {
                                                       entity.LastName,
                                                       entity.FirstName,
                                                       entity.Title,
                                                       entity.TitleOfCourtesy,
                                                       entity.BirthDate,
                                                       entity.HireDate,
                                                       entity.Address,
                                                       entity.City,
                                                       entity.Region,
                                                       entity.PostalCode,
                                                       entity.Country,
                                                       entity.HomePhone,
                                                       entity.Extension,
                                                       entity.Photo,
                                                       entity.Notes,
                                                       entity.ReportsTo,
                                                       entity.PhotoPath,
                                                       entity.EmployeeId
                                                   });
                return true;
            }
        }
    }

}
