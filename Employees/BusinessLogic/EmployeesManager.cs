namespace Employees.BusinessLogic
{
    public class EmployeesManager
    {
        public decimal CalculateAnnualSalary(decimal monthlySalary) => Math.Round(monthlySalary * 12, 2);
    }
}