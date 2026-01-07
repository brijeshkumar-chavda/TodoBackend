using Microsoft.AspNetCore.Mvc;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public static List<Employee> employeeList = new List<Employee>();

        [HttpGet(Name = "GetEmployeesList")]
        public IActionResult GetEmployeeList()
        {
            Employee emp1 = new Employee();
            emp1.Id = 1;
            emp1.FirstName = "John";
            emp1.LastName = "Doe";
            emp1.PhoneNumber = 1234567890;
            emp1.DOB = new DateTime(1990, 1, 1);
            employeeList.Add(emp1);

            Employee emp2 = new Employee();
            emp2.Id = 2;
            emp2.FirstName = "Jane";
            emp2.LastName = "Smith";
            emp2.PhoneNumber = 1234567890;
            emp2.DOB = new DateTime(1985, 5, 15);
            employeeList.Add(emp2);

            Employee emp3 = new Employee();
            emp3.Id = 3;
            emp3.FirstName = "Alice";
            emp3.LastName = "Johnson";
            emp3.PhoneNumber = 1234567890;
            emp3.DOB = new DateTime(1992, 8, 22);
            employeeList.Add(emp3);
            return Ok(employeeList);
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            Employee employee = employeeList.Where(emp => emp.Id == id).FirstOrDefault();
            return Ok(employee);
        }

        [HttpPost(Name = "CreateEmployee")]
        public IActionResult CreateEmployee(Employee employee)
        {
            employeeList.Add(employee);
            return Ok(employeeList);
        }

        [HttpDelete(Name = "DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee employee = employeeList.Where(emp => emp.Id == id).FirstOrDefault();
            employeeList.Remove(employee);
            return Ok(employeeList);
        }

        [HttpPut("{id}", Name = "UpdateEmployee")]
        public IActionResult UpdateEmployee(int id, Employee updatedEmployee)
        {
            Employee employee = employeeList.Where(emp => emp.Id == id).FirstOrDefault();
            if (employee != null)
            {
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.PhoneNumber = updatedEmployee.PhoneNumber;
                employee.DOB = updatedEmployee.DOB;
            }
            return Ok(employeeList);
        }
    }
}