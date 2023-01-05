using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using MyDocAppointment.Infrastructure;
using MyDocAppointment.API.Controllers;

namespace MyDocAppointment.IntegrationTests
{
    public class BaseIntegrationTests
    {
        private DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source = MyTests.db").Options;

        protected HttpClient HttpClient { get; private set; }

        private AppDbContext databaseContext;   

        protected BaseIntegrationTests()
        {
            var application = new WebApplicationFactory<DoctorController>()
                .WithWebHostBuilder(builder => { });
            HttpClient = application.CreateClient();
            databaseContext = new AppDbContext(options);
            // CleanDatabases();
        }

        protected void CleanDatabases()
        {
            databaseContext.Doctors.RemoveRange(databaseContext.Doctors.ToList());
            databaseContext.Patients.RemoveRange(databaseContext.Patients.ToList());
            databaseContext.SaveChanges();
            databaseContext.Database.EnsureDeleted();
        }
    }
}