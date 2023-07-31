# Employee MVC Application

This is an MVC application that consumes APIs to retrieve employee information and calculate their annual salary. The application is developed using ASP.NET Core 6 and Visual Studio.

## Requirements

- Visual Studio 2022 or higher.
- .NET 6 SDK installed.

## Usage Instructions

1. Clone the repository:

`git clone https://github.com/Maycet/Employees-Information`

2. Open the project in Visual Studio.

3. Configure Employee APIs:

   - Make sure you have an active internet connection so that the application can consume the following example APIs:
   
     - [http://dummy.restapiexample.com/api/v1/employees](http://dummy.restapiexample.com/api/v1/employees) (List of employees)
     - [http://dummy.restapiexample.com/api/v1/employee/1](http://dummy.restapiexample.com/api/v1/employee/1) (Employee information by specific ID)

4. Run the application:

   - Press F5 or click the "Start" button in Visual Studio to build and run the application.

5. Interact with the application:

   - Upon running the application, a web page will open in your default browser.
   - On the page, you'll see a table displaying the list of employees and a form to search for employee information by ID.
   - If you leave the ID field empty and click the "Search" button, the complete list of employees will be displayed.
   - If you enter a valid ID in the field and click the "Search" button, the information of the specific employee, including their annual salary, will be shown.

## Solution Structure

The main project is named "Employees" and is organized into different layers to separate responsibilities and follow good design practices:

- **DataAccess**: Contains the `EmployeesApiClient` class responsible for consuming the employee APIs.
- **BusinessLogic**: Contains the `EmployeesManager` class that calculates the annual salary of employees.
- **Controllers**: Contains the `EmployeesController` controller that handles requests related to employees.
- **Views**: Contains the `Index.cshtml` view to display employee information (and the other views to have a complete navigation control in the app).

Apart from the main project there is a console application that contains some unit tests for the business logic located in the Employees project.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE.txt) file for more details.

