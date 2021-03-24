﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Models
{
    public class DocumentsUpload
    {
        public int Id { get; set; }
        public string Details { get; set; }

        public string Name { get; set; }


        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
