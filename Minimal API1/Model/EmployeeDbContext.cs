using Microsoft.EntityFrameworkCore;

namespace Minimal_API1.Model
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
            
        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }

        //projedeki appsettings.json dosyası
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            //appsetting.json daki bağlantı
           // string connectionString2 = "SERVER=DESKTOP-VI5LI79;Database=EmployeeDb;Trusted_Connection=True;TrustServerCertificate=True";
            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
