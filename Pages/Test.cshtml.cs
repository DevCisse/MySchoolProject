using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MySchoolProject.Models;
using RepoDb;

namespace MySchoolProject.Pages
{
    public class TestModel : PageModel
    {
        private readonly IConfiguration configuration;

        public TestModel(IConfiguration configuration)
        {
            RepoDb.SqlServerBootstrap.Initialize();
            this.configuration = configuration;
        }
        public void OnGet()
        {
            AdmissionList list = new AdmissionList
            {
                Email = "Hassan@yahoo.com",
                FirstName = "Hassan",
                LastName = "Cisse"
            };


            using(var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var res = connection.Insert<AdmissionList,int>(list);

              
            }

        }



    }

}
