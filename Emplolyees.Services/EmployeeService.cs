using Employees.DataModel;
using Employees.DataModel.EmployeesRepository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplolyees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository employeeRepository;
        public EmployeeService()
        {
           var connectionString = ConfigurationManager.AppSettings["MongoDBConectionString"];
            var client = new MongoClient(string.Format(connectionString,"&"));
            var databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            IMongoDatabase database = client.GetDatabase(databaseName);
            employeeRepository = new EmployeeRepository(database, "Employees");
        }
        void IEmployeeService.Insert(Employee employee)
        {
            employeeRepository.Create(employee);
        }

        Employee IEmployeeService.Get(string id)
        {
           return employeeRepository.Get(id);
        }

        List<Employee> IEmployeeService.GetAll()
        {
            return employeeRepository.Get();
        }

        void IEmployeeService.Delete(string id)
        {
             employeeRepository.Remove(id);
        }
        void IEmployeeService.Update(string id,Employee employee)
        {
            employeeRepository.Update(id, employee);
        }
    }
}


