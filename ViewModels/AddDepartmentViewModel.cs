using MySchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.ViewModels
{
    public class AddDepartmentViewModel
    {
        public Department Department { get; set; }
        public List<Faculty> Faculties { get; set; }
    }
}
