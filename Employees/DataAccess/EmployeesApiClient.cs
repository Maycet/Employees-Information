using Employees.Models;
using System.Text.Json;

namespace Employees.DataAccess
{
    public class EmployeesApiClient
    {
        private readonly HttpClient _HttpClient;
        private readonly ILogger<EmployeesApiClient> _Logger;
        private const string _BaseUrl = "https://dummy.restapiexample.com/public/api/v1/";

        public EmployeesApiClient(HttpClient httpClient, ILogger<EmployeesApiClient> logger)
        {
            _HttpClient = httpClient;
            _Logger = logger;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            try
            {
                HttpResponseMessage Response = await _HttpClient.GetAsync($"{_BaseUrl}employees");

                Response.EnsureSuccessStatusCode();

                EmployeesApiResponse EmployeesResponse =
                    JsonSerializer.Deserialize<EmployeesApiResponse>(await Response.Content.ReadAsStringAsync()) ?? new EmployeesApiResponse();

                return EmployeesResponse.Data;
            }
            catch (Exception Exception)
            {
                _Logger.LogError(Exception, "Unexpected error on Employees query.");
                return new List<Employee>();
            }
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int employeeId)
        {
            try
            {
                HttpResponseMessage Response = await _HttpClient.GetAsync($"{_BaseUrl}employee/{employeeId}");

                Response.EnsureSuccessStatusCode();

                EmployeeApiResponse EmployeeResponse =
                    JsonSerializer.Deserialize<EmployeeApiResponse>(await Response.Content.ReadAsStringAsync()) ?? new EmployeeApiResponse();

                return EmployeeResponse.Data;
            }
            catch (Exception Exception)
            {
                _Logger.LogError(Exception, $"Unexpected error on Employee {employeeId} query.");
                return null;
            }
        }
    }

    class EmployeesApiResponse
    {
        public EmployeesApiResponse() { Data = new List<Employee>(); }

        public List<Employee> Data { get; set; }
    }

    class EmployeeApiResponse
    {
        public EmployeeApiResponse() { Data = new Employee(); }

        public Employee Data { get; set; }
    }
}