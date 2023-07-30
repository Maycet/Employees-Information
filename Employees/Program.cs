using Employees.BusinessLogic;
using Employees.DataAccess;

namespace Employees
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder Builder = WebApplication.CreateBuilder(args);

            Builder.Services.AddControllersWithViews();

            Builder.Logging.AddConsole();

            Builder.Services.AddHttpClient<EmployeesApiClient>();
            Builder.Services.AddScoped<EmployeesManager>();

            WebApplication Application = Builder.Build();

            if (!Application.Environment.IsDevelopment())
            {
                Application.UseExceptionHandler("/Employees/Error");
                Application.UseHsts();
            }

            Application.UseHttpsRedirection();
            Application.UseStaticFiles();

            Application.UseRouting();

            Application.UseAuthorization();

            Application.MapControllerRoute(
                name: "default",
                pattern: "{controller=Employees}/{action=Index}");

            Application.Run();
        }
    }
}