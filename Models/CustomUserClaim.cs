using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolProject.Models
{
    public class CustomUserClaim
    {
        public int Id { get; set; }
       
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }



        public Guid CustomUserId { get; set; }
        public CustomUser CustomUser { get; set; }


    }
}
