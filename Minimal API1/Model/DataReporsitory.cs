namespace Minimal_API1.Model
{
    public class DataReporsitory : IDataReporsitory
    {
        private readonly EmployeeDbContext db;

        public DataReporsitory(EmployeeDbContext db)
        {
            this.db = db;
        }
        public Employee GetEmployeeById(string id)
        {
            return db.Employee.Where(x => x.EmployeeId == id).FirstOrDefault();
        }
        public List<Employee> GetEmployees()
        {
            return db.Employee.ToList();
        }

        public Employee PutEmployee(Employee employee)
        {
            db.Employee.Update(employee);
            db.SaveChanges();
            return db.Employee.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();
        }

        public List<Employee> AddEmployee(Employee employee)
        {
            db.Employee.Add(employee);
            db.SaveChanges();
            return db.Employee.ToList();
        }

        
    }
}
