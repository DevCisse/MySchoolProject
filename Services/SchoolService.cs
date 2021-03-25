using Microsoft.EntityFrameworkCore;
using MySchoolProject.Data;
using MySchoolProject.Models;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Services
{

    public interface ISchoolService
    {
        Faculty AddFaculty(Faculty faculty);
        Faculty EditFaculty(Faculty faculty);

        Task<IEnumerable<Faculty>> GetFacultiesAsync();

        List<Faculty> GetFaculties();

        AdmissionList AddAdmission(AdmissionList admission);
        AdmissionList EditAdmission(AdmissionList admission);

        Faculty GetFaculty(int id);

        Department AddDepartment(Department department);
        Department EditDepartment(Department department);

        List<Department> GetDepartments();
    }

    public class SchoolService : ISchoolService
    {
        private readonly AppDbContext context;

        public SchoolService(AppDbContext context)
        {
            this.context = context;

            RepoDb.SqlServerBootstrap.Initialize();
        }

        public AdmissionList AddAdmission(AdmissionList admission)
        {
            context.AdmissionLists.Add(admission);
            context.SaveChanges();
            return admission;
        }

        public Department AddDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return department;
        }

        public Faculty AddFaculty(Faculty faculty)
        {
            context.Faculties.Add(faculty);
            context.SaveChanges();
            return faculty;
        }

        public AdmissionList EditAdmission(AdmissionList admission)
        {
            context.Attach(admission).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            context.SaveChanges();
            return admission;
        }

        public Department EditDepartment(Department department)
        {
            context.Attach(department).State = EntityState.Modified;
            context.SaveChanges();
            return department;
        }

        public Faculty EditFaculty(Faculty faculty)
        {
            context.Attach(faculty).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return faculty;
        }

        public List<Department> GetDepartments()
        {
            return context.Departments.Include(x=>x.Faculty).ToList();
        }

        public List<Faculty> GetFaculties()
        {
            return context.Faculties.ToList();
        }

        public async Task<IEnumerable<Faculty>> GetFacultiesAsync()
        {
            return await context.Faculties.ToListAsync();
        }

        public Faculty GetFaculty(int id)
        {
            return context.Faculties.FirstOrDefault(x => x.Id == id);
        }
    }
}
