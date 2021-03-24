using RepoDb.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Models
{

    [Map("AdmissionLists")]
    public class AdmissionList
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public EntryLevel EntryLevel { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}
