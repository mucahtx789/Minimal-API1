namespace Minimal_API1.Model
{
    public class DataSeeder
    {
        private readonly EmployeeDbContext employeeDbContext;

        public DataSeeder(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        public void Seed() 
        {
            if(!employeeDbContext.Employee.Any()) 
            {
                var employees = new List<Employee>()
                {
                    new Employee()
                    {
                        EmployeeName="Alex",
                        EmployeeCountry="Brezilya",
                        EmployeeId="10"
                    },
                    new Employee()
                    {
                        EmployeeName="Geralt",
                        EmployeeCountry="Polonya",
                        EmployeeId="11"
                    }
                };
                employeeDbContext.Employee.AddRange(employees);
                employeeDbContext.SaveChanges();
            }
        }

    }
}
