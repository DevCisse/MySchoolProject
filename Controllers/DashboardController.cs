using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySchoolProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly DbOperations operations;

        public DashboardController(DbOperations operations)
        {
            this.operations = operations;
        }
        public IActionResult Home()
        {
            var user = User;
           var name =  user.Identity.Name;

            

            return View();
        }
    }
}
