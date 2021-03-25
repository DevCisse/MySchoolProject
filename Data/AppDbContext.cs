using Microsoft.EntityFrameworkCore;
using MySchoolProject.Models;

namespace MySchoolProject.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context)
        {

        }
        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<CustomUserClaim> CustomUserClaims { get; set; }
        public DbSet<AdmissionList>  AdmissionLists{ get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<DocumentsUpload>  DocumentsUploads{ get; set; }
    }
}
