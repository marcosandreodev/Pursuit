using CoreMongoDBCrud.IRepository;
using CoreMongoDBCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreMongoDBCrud.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _empRepo = null;
        public EmployeesController(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetEmployees()
        {
            var employees = _empRepo.Gets();
            return Json(employees);
        }
        public JsonResult SaveEmp(Employee employee)
        {
            var emp = _empRepo.Save(employee);
            return Json(emp);
        }
        public JsonResult DeleteEmp(string empId)
        {
            string message = _empRepo.Delete(empId);
            return Json(message);
        }
    }
}
