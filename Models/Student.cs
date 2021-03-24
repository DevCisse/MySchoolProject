using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        [Parameter] public string FirstName { get; set; }
        [Parameter] public string LastName { get; set; }
        public string MiddleName { get; set; }
        [DataType(DataType.Date)] public DateTime Dob { get; set; }
        public bool Status { get; set; }
        public EntryLevel EntryLevel { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<DocumentsUpload> DocumentsUploads { get; set; } = new List<DocumentsUpload>();

    }
}
