using Employees.BusinessLogic;
using Employees.DataAccess;
using Employees.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employees.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeesApiClient _EmployeeApiClient;
        private readonly EmployeesManager _EmployeesManager;
        private readonly ILogger<EmployeesController> _Logger;

        public EmployeesController(EmployeesApiClient employeeApiClient, EmployeesManager employeesManager, ILogger<EmployeesController> logger)
        {
            _EmployeeApiClient = employeeApiClient;
            _EmployeesManager = employeesManager;
            _Logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Employee> Employees = await _EmployeeApiClient.GetEmployeesAsync();

            foreach (Employee Employee in Employees)
                Employee.AnualSalary = _EmployeesManager.CalculateAnnualSalary(Employee.Salary);

            return View(Employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            Employee? Employee = await _EmployeeApiClient.GetEmployeeByIdAsync(id);

            if (Employee != null)
            {
                Employee.AnualSalary = _EmployeesManager.CalculateAnnualSalary(Employee.Salary);
                if (string.IsNullOrWhiteSpace(Employee.ProfileImage)) Employee.ProfileImage = "https://maycet.github.io/img/alien.png";

                return View(Employee);
            }

            ViewData["EmployeeId"] = id;
            return View("EmployeeNotFound");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}