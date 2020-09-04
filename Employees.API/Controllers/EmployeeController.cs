using Emplolyees.Services;
using Employees.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudWithMongo.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }
        public HttpResponseMessage Get(string id)
        {

            Employee employee = _employeeService.Get(id);
            if (employee != null)
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee not found for provided id.");
        }

        public HttpResponseMessage GetAll()
        {
            List<Employee> employee = _employeeService.GetAll();
            if (employee.Any())
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No employee found.");
        }
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {

            if (string.IsNullOrEmpty(employee.id))
            {
                _employeeService.Insert(employee);
            }
            else
            {
                _employeeService.Update(employee.id, employee);
            }


        }
        public void Delete(string id)
        {
            _employeeService.Delete(id);
        }
        public void Put([FromBody] Employee employee)
        {
            _employeeService.Update(employee.id, employee);
        }
    }
}
