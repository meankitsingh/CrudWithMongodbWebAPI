using Employees.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplolyees.Services
{
  
        public interface IEmployeeService
        {
            void Insert(Employee employee);
            Employee Get(string id);
            List<Employee> GetAll();
            void Delete(string id);
            void Update(string id,Employee employee);
        }

    }

