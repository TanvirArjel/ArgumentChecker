# ArgumentChecker
This library can be used to check method parameters' values and throw appropriate exceptions to avoid confusing NullReferenceException in any C#, .NET application.

 ## ⭐ Give a star
   
   **If you find this library useful to you, please don't forget to encouraging me to do such more stuffs by giving a star (⭐) to this repository. Thank you.**
   
   ## ✈️ How to get started?

First install the lastest version of `TanvirArjel.ArgumentChecker` [nuget package](https://www.nuget.org/packages/TanvirArjel.ArgumentChecker) into your project as follows:
 
    Install-Package TanvirArjel.ArgumentChecker
    
 ## 🛠️ Usage:

```C#
public class EmployeeService
{
    public async Task CreateAsync(Employee employee)
    {
        employee.ThrowIfNull(nameof(employee));
        ...
    };
    
    public async Task GetByIdAsync(int employeeId)
    {
        employeeId.ThrowIfZeroOrNegative((nameof(employeeId));
        ...
    };
}
```
