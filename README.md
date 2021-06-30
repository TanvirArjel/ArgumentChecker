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

## Details

### For `string` type:

 1. **ThrowIfNull** - Throws **ArgumentNullException** if parameter value is `null`.
 2. **ThrowIfNullOrEmpty** - Throws **ArgumentNullException** if parameter value is `null` and throws **ArgumentException** if parameter value is `empty or whitespace`.
 3. **ThrowIfOutOfLength** - Throws **ArgumentOutOfRangeException** if parameter value is out of the specified length range.
 4. **ThrowIfNotValidEmail** - Throws **ArgumentException** if parameter value is not a valid email.

### For `IEnumerable<T>` type:

 1. **ThrowIfNull** - Throws **ArgumentNullException** if collection parameter value is `null`.
 2. **ThrowIfNullOrEmpty** - Throws **ArgumentNullException** if collection parameter value is `null` and throws **ArgumentException** if collection is `empty`.

### For nullable value types:

  1. **ThrowIfNull** - Throws **ArgumentNullException** if parameter value is `null`.

### For `Guid` type:
  1. **ThrowIfEmpty** - Throws **ArgumentException** if parameter value is a `empty` guid.
  
### For nullable `Guid` type:
  1. **ThrowIfNullOrEmpty** - Throws **ArgumentNullException** if parameter value is `null` guid and throws **ArgumentException** if parameter value is  a `empty` guid.

### For numeric types:

  1. **ThrowIfZeroOrNegative** - Throws **ArgumentOutOfRangeException** if parameter value is zero or negative.
  2. **ThrowIfNegative** - Throws **ArgumentOutOfRangeException** if parameter value is negative.
  3. **ThrowIfOutOfRange** - Throws **ArgumentOutOfRangeException** if parameter value is out of the specified range.

### For `DateTime` and `TimeSpan` type

  1. **ThrowIfOutOfRange** - Throws **ArgumentOutOfRangeException** if parameter value is out of the specified range.
