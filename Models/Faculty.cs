using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Faculty Name is required")]
        public string Name { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
    }
}
