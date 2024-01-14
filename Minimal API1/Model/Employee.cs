namespace Minimal_API1.Model
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCountry { get; set; }
    }
  /*  public class EmployeeCollection
    {
        public List<Employee> Employees { get; set; }

        public List<Employee> GetEmployees() {


            return new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId="2",
                    EmployeeName="Ahmet",
                    EmployeeCountry="Turkey"
                },
                new Employee()
                {
                    EmployeeId="3",
                    EmployeeName="Görkem",
                    EmployeeCountry="Turkey"
                }
            };    
        }

    }*/
         
}
