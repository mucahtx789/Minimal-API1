namespace Minimal_API1.Model
{
    public interface IDataReporsitory
    {
        List<Employee> AddEmployee(Employee employee);
        List<Employee> GetEmployees();
        Employee PutEmployee(Employee employee);
    }
}