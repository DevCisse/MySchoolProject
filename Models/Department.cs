using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }


        public int FacultyId { get; set; }
        public Faculty  Faculty { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

    }
}
