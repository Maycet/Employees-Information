using Employees.BusinessLogic;
using Xunit;

namespace Employees.Tests
{
    public class EmployeesManagerTests
    {
        [Fact]
        public void CalculateAnnualSalary_ShouldReturnCorrectValue()
        {
            EmployeesManager EmployeesManager = new();

            decimal MonthlySalary = 5000;
            decimal ExpectedAnnualSalary = 60000;

            Assert.Equal(ExpectedAnnualSalary, EmployeesManager.CalculateAnnualSalary(MonthlySalary));
        }

        [Theory]
        [InlineData(120000, 10000)]
        [InlineData(360000, 30000)]
        [InlineData(0, 0)]
        public void CalculateAnnualSalary_ShouldReturnCorrectValues(decimal expectedAnnualSalary, decimal salary)
        {
            EmployeesManager EmployeesManager = new();
            decimal AnnualSalary = EmployeesManager.CalculateAnnualSalary(salary);
            Assert.Equal(expectedAnnualSalary, AnnualSalary);
        }
    }
}