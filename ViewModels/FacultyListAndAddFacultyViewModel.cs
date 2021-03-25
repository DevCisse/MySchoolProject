using MySchoolProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.ViewModels
{
    public class FacultyListAndAddFacultyViewModel
    {
        public List<Faculty> Faculties { get; set; } = new List<Faculty>();

        [Required]
        public Faculty AddFaculty { get; set; } = new Faculty();
    }
}
