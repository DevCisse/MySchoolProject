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
    public class EfcoreService
    {
        private readonly AppDbContext context;

        public EfcoreService(AppDbContext context)
        {
            this.context = context;

            RepoDb.SqlServerBootstrap.Initialize();
        }


        //public async Task<bool> Update(CustomUser customUser)
        //{
            
        //}


        public void Test()
        {
            using (var connection = new SqlConnection(""))
            {
                
            }


            AdmissionList list = new AdmissionList();


            context.Attach(list).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
