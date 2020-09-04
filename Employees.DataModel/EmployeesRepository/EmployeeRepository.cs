using MongoDB.Bson;
using MongoDB.Driver;

using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;

namespace Employees.DataModel.EmployeesRepository
{
    public class EmployeeRepository
    {
        private IMongoDatabase _database;
        private string _tableName;
        private IMongoCollection<Employee> _collection;

        public EmployeeRepository(IMongoDatabase database,string tblName)
        {
            _tableName = tblName;
            _database = database;
            _collection = _database.GetCollection<Employee>(_tableName);
        }

        public List<Employee> Get() =>
                   _collection.Find(employee => true).ToList();

        public Employee Get(string id) =>
            _collection.Find<Employee>(employee => employee.id == id).FirstOrDefault();

        public Employee Create(Employee employee)
        {
            _collection.InsertOne(employee);
            return employee;
        }

        public void Update(string id, Employee employeeIn) =>
            _collection.ReplaceOne(employee => employee.id == id, employeeIn);

        public void Remove(Employee employeeIn) =>
            _collection.DeleteOne(employee => employee.id == employee.id);

        public void Remove(string id) =>
            _collection.DeleteOne(employee => employee.id == id);
    }
}