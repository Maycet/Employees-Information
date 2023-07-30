using System.Text.Json.Serialization;

namespace Employees.Models
{
    public class Employee
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("employee_name")]
        public string Name { get; set; } = "Not found!";

        [JsonPropertyName("employee_age")]
        public int Age { get; set; }

        [JsonPropertyName("employee_salary")]
        public decimal Salary { get; set; }

        [JsonPropertyName("profile_image")]
        public string ProfileImage { get; set; } = "https://maycet.github.io/img/alien.png";

        public decimal AnualSalary { get; set; }
    }
}