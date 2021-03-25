using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Department Name is required")]
        public string Name { get; set; }
        [MaxLength(2,ErrorMessage ="Acronym cannot be more than two characters")]
        [Required(ErrorMessage ="Acronym is required")]

        public string Acronym { get; set; }


        [Required(ErrorMessage ="Faculty is required")]
        public int? FacultyId { get; set; }
        public Faculty  Faculty { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

    }
}
