using Microsoft.EntityFrameworkCore;
using MIS3033_Retake_Exam3_Prakhyat.Models;

namespace MIS3033_Retake_Exam3_Prakhyat.Data
{
    public class DbCon1 : DbContext// Change DbCon to your own database connect class name
    {
        public DbSet<Patient> Patients { get; set; }// Define a table in the database. The table name here is: Students
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=129.15.67.240;Database=Prakhyat_Retake1_Exam3;Port=5432;Username=rach0006;Password=X6gBkNsgxgUPVwa8BHqR");
        }
    }
}
