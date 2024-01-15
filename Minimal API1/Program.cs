using Microsoft.Extensions.Configuration;
using Minimal_API1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

namespace Minimal_API1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

          //  string connectionString2 = "SERVER=DESKTOP-VI5LI79;Database=EmployeeDb;Trusted_Connection=True;TrustServerCertificate=True";
            var connectionString = builder.Configuration.GetConnectionString("AppDb");
            
            builder.Services.AddDbContext<EmployeeDbContext>(x =>x.UseSqlServer(connectionString));

            builder.Services.AddTransient<DataSeeder>();

            var app = builder.Build();

            if (args.Length ==1 && args[0].ToLower()=="seeddata")
                SeedData(app);

            //proje sað týk konsole da aç powershell ps de run seeddata
            void  SeedData(IHost app)
            {
                var scopedFactory=app.Services.GetService<IServiceScopeFactory>();

                using(var scope = scopedFactory.CreateScope()) 
                {
                    var service=scope.ServiceProvider.GetService<DataSeeder>();
                    service.Seed();
                }
            }



            /*   app.MapGet("/", () => "Hello World!");

           app.MapGet("/musteri", (Func<Employee>)(() => {

                 return new Employee()
                 {
                     EmployeeId = "1",
                     EmployeeName = "Mücahit",
                     EmployeeCountry = "Turkey"
                 };
             }));*/

            //proje  <LangVersion>preview</LangVersion> fromservice
            app.MapGet("/employee/{id}", ([FromServices] EmployeeDbContext db, string id) =>
            {
                return db.Employee.Where(x=>x.EmployeeId==id).FirstOrDefault();
            });

          
            app.MapGet("/employees", ([FromServices] EmployeeDbContext db) =>
            {
                return db.Employee.ToList();
            }

            );

            app.MapPut("/employee/{id}", ([FromServices] EmployeeDbContext db, Employee employee) =>
            {
                db.Employee.Update(employee);
                db.SaveChanges();
                return db.Employee.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();
            });

            app.MapPost("/employee", ([FromServices] EmployeeDbContext db, Employee employee) =>
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return db.Employee.ToList();
            });

            /* app.MapGet("/musteriler", (Func<List< Employee >>)(() =>
             {
                 return new EmployeeCollection().GetEmployees();
             }

             ));

             app.MapGet("/musteri/{id}", async (htpp) =>

             {
                 if(!htpp.Request.RouteValues.TryGetValue("id",out var id)) { htpp.Response.StatusCode = 400; return; }

                 else
                 {
                     await htpp.Response.WriteAsJsonAsync(new EmployeeCollection().GetEmployees().FirstOrDefault(x => x.EmployeeId==(string)id));
                 }
             });*/

            app.Run();
        }

       
    }
}